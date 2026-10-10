Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Public Class frmCustomerOrder

    ' ── cart lives ONLY in memory now — no Orders / OrderDetails table ────────
    Dim dtCart As New DataTable("Cart")
    Dim isLoading As Boolean = False

    ' ── tile menu (replaces dgvMenu) ───────────────────────────────────────
    Private Const TILE_WIDTH As Integer = 150
    Private Const TILE_HEIGHT As Integer = 150

    Private productPrices As New Dictionary(Of Integer, Decimal)
    Private productStock As New Dictionary(Of Integer, Integer) ' cart-aware "can still add this many" — NEVER shown to customer
    Private productNames As New Dictionary(Of Integer, String)
    Private productImageFilenames As New Dictionary(Of Integer, String)

    Private SelectedProductID As Integer = 0
    Private SelectedProductName As String = ""
    Private SelectedPrice As Decimal = 0

    ' ── NEW: live reservation pool — how much of each ingredient the CURRENT
    ' cart has already claimed. Shared across all products, so two pizzas that
    ' use the same ingredient correctly compete for the same remaining supply.
    ' Cleared whenever the cart is emptied (order placed or cancelled).
    Private reservedIngredients As New Dictionary(Of Integer, Decimal)

    Private Sub frmCustomerOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitCartTable()
        SetupCartGridColumns()
        LoadCategories()
        LoadMenu()
        RefreshCartGrid()
        UpdateTotal()
        nudQty.Minimum = 1
        nudQty.Value = 1
        lblSelectedProduct.Text = "No item selected"
        dgvOrder.DefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvOrder.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
    End Sub

    Private Sub LoadCategories()
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand("SELECT CategoryName FROM categories ORDER BY CategoryName", conn)
        Dim reader = cmd.ExecuteReader()

        cboCategory.Items.Clear()
        cboCategory.Items.Add("All Categories")
        While reader.Read()
            cboCategory.Items.Add(reader("CategoryName").ToString())
        End While
        reader.Close()
        conn.Close()

        cboCategory.SelectedIndex = 0 ' default to "All Categories"
    End Sub

    ' ── cart setup ───────────────────────────────────────────────────────────
    Private Sub InitCartTable()
        dtCart.Columns.Add("ProductID", GetType(Integer))
        dtCart.Columns.Add("ProductName", GetType(String))
        dtCart.Columns.Add("Quantity", GetType(Integer))
        dtCart.Columns.Add("UnitPrice", GetType(Decimal))
        dtCart.Columns.Add("Subtotal", GetType(Decimal))
        dtCart.Columns.Add("Selected", GetType(Boolean))
    End Sub

    Private Sub SetupCartGridColumns()
        dgvOrder.AutoGenerateColumns = False
        dgvOrder.Columns.Clear()

        dgvOrder.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ProductID", .DataPropertyName = "ProductID", .Visible = False})
        dgvOrder.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "Selected", .DataPropertyName = "Selected", .HeaderText = ""})
        dgvOrder.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ProductName", .DataPropertyName = "ProductName", .HeaderText = "Item", .ReadOnly = True})

        Dim colMinus As New DataGridViewButtonColumn With {.Name = "Minus", .Text = "−", .UseColumnTextForButtonValue = True, .Width = 40}
        dgvOrder.Columns.Add(colMinus)

        dgvOrder.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Quantity", .DataPropertyName = "Quantity", .HeaderText = "Qty", .ReadOnly = True, .Width = 50})

        Dim colPlus As New DataGridViewButtonColumn With {.Name = "Plus", .Text = "+", .UseColumnTextForButtonValue = True, .Width = 40}
        dgvOrder.Columns.Add(colPlus)

        dgvOrder.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "UnitPrice", .DataPropertyName = "UnitPrice", .HeaderText = "Price", .ReadOnly = True})
        dgvOrder.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Subtotal", .DataPropertyName = "Subtotal", .HeaderText = "Total", .ReadOnly = True})
    End Sub

    Private Sub RefreshCartGrid()
        isLoading = True
        dgvOrder.DataSource = dtCart
        dgvOrder.AllowUserToAddRows = False
        isLoading = False
    End Sub

    ' ── helpers ──────────────────────────────────────────────────────────────
    Private Function GetCustomerName() As String
        Dim fn = txtFirstName.Text.Trim()
        Dim ln = txtLastName.Text.Trim()
        If String.IsNullOrWhiteSpace(fn) Then Return ""
        Return If(String.IsNullOrWhiteSpace(ln), fn, fn & " " & ln)
    End Function

    Private Function GetOrCreateCustomerID(conn As MySqlConnection, transaction As MySqlTransaction) As Integer
        Dim fn = txtFirstName.Text.Trim()
        Dim ln = txtLastName.Text.Trim()

        Dim cmdFind As New MySqlCommand(
        "SELECT CustomerID FROM customers
         WHERE TRIM(LOWER(FirstName)) = TRIM(LOWER(@fn))
           AND TRIM(LOWER(COALESCE(LastName, ''))) = TRIM(LOWER(@ln))
         LIMIT 1", conn, transaction)
        cmdFind.Parameters.AddWithValue("@fn", fn)
        cmdFind.Parameters.AddWithValue("@ln", ln)
        Dim result = cmdFind.ExecuteScalar()
        If result IsNot Nothing Then Return Convert.ToInt32(result)

        Dim cmdInsert As New MySqlCommand(
        "INSERT INTO customers (FirstName, LastName, ContactNo, DateAdded)
         VALUES (@fn, @ln, @contact, NOW())", conn, transaction)
        cmdInsert.Parameters.AddWithValue("@fn", fn)
        cmdInsert.Parameters.AddWithValue("@ln", If(String.IsNullOrWhiteSpace(ln), DBNull.Value, ln))
        Dim contact = txtContactNo.Text.Trim()
        cmdInsert.Parameters.AddWithValue("@contact", If(String.IsNullOrWhiteSpace(contact), DBNull.Value, contact))
        cmdInsert.ExecuteNonQuery()
        Return CInt(cmdInsert.LastInsertedId)
    End Function

    ' ── raw stock (ignores the cart entirely) — still used for the FINAL
    ' re-check right before committing an order in the database. ───────────
    Private Function GetAvailableStock(productID As Integer, conn As MySqlConnection,
                                        Optional transaction As MySqlTransaction = Nothing) As Integer
        Dim cmd As New MySqlCommand(
            "SELECT pi.QtyRequired,
        COALESCE((SELECT SUM(RemainingQty) FROM ingredientbatches
                  WHERE IngredientID = pi.IngredientID AND ExpiryDate >= CURDATE()
                        AND IsVoided = 0), 0) AS AvailQty
 FROM productingredients pi
 WHERE pi.ProductID = @pid", conn, transaction)
        cmd.Parameters.AddWithValue("@pid", productID)
        Dim reader = cmd.ExecuteReader()
        Dim minUnits As Integer = Integer.MaxValue
        Dim hasRecipe As Boolean = False
        While reader.Read()
            hasRecipe = True
            Dim qtyRequired = Convert.ToDecimal(reader("QtyRequired"))
            Dim availQty = Convert.ToDecimal(reader("AvailQty"))
            If qtyRequired <= 0 Then Continue While
            Dim units = CInt(Math.Floor(availQty / qtyRequired))
            If units < minUnits Then minUnits = units
        End While
        reader.Close()
        If Not hasRecipe Then Return 0
        Return minUnits
    End Function

    ' ── NEW: fetch a product's recipe (ingredient + qty required per unit). ──
    Private Function GetProductRecipe(productID As Integer, conn As MySqlConnection,
                                       Optional transaction As MySqlTransaction = Nothing) As List(Of (IngredientID As Integer, QtyRequired As Decimal))
        Dim cmd As New MySqlCommand("SELECT IngredientID, QtyRequired FROM productingredients WHERE ProductID = @pid", conn, transaction)
        cmd.Parameters.AddWithValue("@pid", productID)
        Dim reader = cmd.ExecuteReader()
        Dim recipe As New List(Of (IngredientID As Integer, QtyRequired As Decimal))
        While reader.Read()
            recipe.Add((Convert.ToInt32(reader("IngredientID")), Convert.ToDecimal(reader("QtyRequired"))))
        End While
        reader.Close()
        Return recipe
    End Function

    ' ── NEW: raw DB remaining for ONE ingredient (not a whole product). ─────
    Private Function GetIngredientDbRemaining(ingredientID As Integer, conn As MySqlConnection,
                                               Optional transaction As MySqlTransaction = Nothing) As Decimal
        Dim cmd As New MySqlCommand(
            "SELECT COALESCE(SUM(RemainingQty),0) FROM ingredientbatches
 WHERE IngredientID = @iid AND ExpiryDate >= CURDATE() AND IsVoided = 0", conn, transaction)
        cmd.Parameters.AddWithValue("@iid", ingredientID)
        Return Convert.ToDecimal(cmd.ExecuteScalar())
    End Function

    ' ── NEW: how many MORE of this product can still be added, given what's
    ' ALREADY reserved by everything currently sitting in the cart (including
    ' other products that share the same ingredients). This is the number
    ' that drives tiles/qty caps — it is NEVER shown as raw text to the customer. ──
    Private Function GetAvailableStockConsideringCart(productID As Integer, conn As MySqlConnection) As Integer
        Dim recipe = GetProductRecipe(productID, conn)
        If recipe.Count = 0 Then Return 0

        Dim minUnits As Integer = Integer.MaxValue
        For Each ing In recipe
            If ing.QtyRequired <= 0 Then Continue For
            Dim dbRemaining = GetIngredientDbRemaining(ing.IngredientID, conn)
            Dim reserved As Decimal = 0
            reservedIngredients.TryGetValue(ing.IngredientID, reserved)
            Dim trulyAvailable = dbRemaining - reserved
            If trulyAvailable < 0 Then trulyAvailable = 0
            Dim units = CInt(Math.Floor(trulyAvailable / ing.QtyRequired))
            If units < minUnits Then minUnits = units
        Next
        Return minUnits
    End Function

    ' ── NEW: add to the reservation pool when qty is added to the cart. ─────
    Private Sub ReserveIngredientsForProduct(productID As Integer, qty As Integer, conn As MySqlConnection)
        Dim recipe = GetProductRecipe(productID, conn)
        For Each ing In recipe
            Dim current As Decimal = 0
            reservedIngredients.TryGetValue(ing.IngredientID, current)
            reservedIngredients(ing.IngredientID) = current + (ing.QtyRequired * qty)
        Next
    End Sub

    ' ── NEW: release from the reservation pool when qty is removed from cart. ──
    Private Sub ReleaseIngredientsForProduct(productID As Integer, qty As Integer, conn As MySqlConnection)
        Dim recipe = GetProductRecipe(productID, conn)
        For Each ing In recipe
            Dim current As Decimal = 0
            reservedIngredients.TryGetValue(ing.IngredientID, current)
            Dim newVal = current - (ing.QtyRequired * qty)
            If newVal < 0 Then newVal = 0
            reservedIngredients(ing.IngredientID) = newVal
        Next
    End Sub

    Private Function GetCartQtyForProduct(productID As Integer) As Integer
        Dim total As Integer = 0
        For Each r As DataRow In dtCart.Rows
            If r.RowState <> DataRowState.Deleted AndAlso Convert.ToInt32(r("ProductID")) = productID Then
                total += Convert.ToInt32(r("Quantity"))
            End If
        Next
        Return total
    End Function

    ' ── MENU: picture tiles instead of DataGridView. No stock numbers shown. ──
    Private Sub LoadMenu(Optional categoryFilter As String = "All Categories")
        isLoading = True
        flpMenu.Controls.Clear()
        productPrices.Clear()
        productStock.Clear()
        productNames.Clear()
        productImageFilenames.Clear()

        Dim conn = DBConnection.GetConnection()
        conn.Open()

        Dim query =
"SELECT p.ProductID, p.ProductName, c.CategoryName AS Category, p.Price, p.ImageFilename
 FROM products p
 JOIN categories c ON p.CategoryID = c.CategoryID
 WHERE p.IsActive = 1
   AND (@cat = 'All Categories' OR c.CategoryName = @cat)
 ORDER BY p.ProductName"

        Dim cmd As New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@cat", categoryFilter)
        Dim reader = cmd.ExecuteReader()

        Dim rows As New List(Of (ID As Integer, Name As String, Price As Decimal, Img As String))
        While reader.Read()
            Dim imgVal = If(reader("ImageFilename") Is DBNull.Value, Nothing, reader("ImageFilename").ToString())
            rows.Add((Convert.ToInt32(reader("ProductID")), reader("ProductName").ToString(),
                      Convert.ToDecimal(reader("Price")), imgVal))
        End While
        reader.Close()

        For Each r In rows
            ' Cart-aware: accounts for everything already reserved by this cart,
            ' including OTHER products that share the same ingredients.
            Dim stock = GetAvailableStockConsideringCart(r.ID, conn)
            If stock <= 0 Then Continue For ' hide items with nothing left to give

            productPrices(r.ID) = r.Price
            productStock(r.ID) = stock
            productNames(r.ID) = r.Name
            productImageFilenames(r.ID) = r.Img

            Dim btn As New Button()
            btn.Size = New Size(TILE_WIDTH, TILE_HEIGHT)
            btn.Text = r.Name & vbCrLf & FormatPeso(r.Price) ' no stock count shown
            btn.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            btn.ForeColor = Color.White
            btn.FlatStyle = FlatStyle.Flat
            btn.TextAlign = ContentAlignment.BottomCenter
            btn.ImageAlign = ContentAlignment.TopCenter

            Dim loadedImage = LoadProductImageFromDisk(r.Img, TILE_WIDTH, TILE_HEIGHT)
            If loadedImage IsNot Nothing Then
                btn.Image = loadedImage
                btn.BackColor = Color.FromArgb(46, 125, 50)    ' pizza green (basil)
            Else
                btn.BackColor = Color.FromArgb(230, 126, 34)   ' pizza orange (crust/tomato) for no-photo fallback
            End If

            btn.Tag = r.ID
            AddHandler btn.Click, AddressOf ProductButton_Click
            flpMenu.Controls.Add(btn)
        Next

        conn.Close()
        isLoading = False
    End Sub

    Private Function LoadProductImageFromDisk(imageFilename As String, tileWidth As Integer, tileHeight As Integer) As Image
        If String.IsNullOrWhiteSpace(imageFilename) Then Return Nothing
        Try
            Dim fullPath = Path.Combine(Application.StartupPath, "ProductImages", imageFilename)
            If Not File.Exists(fullPath) Then Return Nothing
            Dim bytes = File.ReadAllBytes(fullPath)
            Using ms As New MemoryStream(bytes)
                Using original = Image.FromStream(ms)
                    Return StretchToFill(original, tileWidth, tileHeight)
                End Using
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function StretchToFill(source As Image, targetW As Integer, targetH As Integer) As Bitmap
        Dim result As New Bitmap(targetW, targetH)
        Dim srcRatio As Double = source.Width / CDbl(source.Height)
        Dim targetRatio As Double = targetW / CDbl(targetH)
        Dim srcRect As Rectangle
        If srcRatio > targetRatio Then
            Dim cropWidth = CInt(source.Height * targetRatio)
            Dim xOffset = (source.Width - cropWidth) \ 2
            srcRect = New Rectangle(xOffset, 0, cropWidth, source.Height)
        Else
            Dim cropHeight = CInt(source.Width / targetRatio)
            Dim yOffset = (source.Height - cropHeight) \ 2
            srcRect = New Rectangle(0, yOffset, source.Width, cropHeight)
        End If
        Using g = Graphics.FromImage(result)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.DrawImage(source, New Rectangle(0, 0, targetW, targetH), srcRect, GraphicsUnit.Pixel)
        End Using
        Return result
    End Function

    ' Clicking a tile selects it as the "current" product. No stock text shown.
    Private Sub ProductButton_Click(sender As Object, e As EventArgs)
        Try
            Dim btn = CType(sender, Button)
            SelectedProductID = CInt(btn.Tag)
            SelectedProductName = productNames(SelectedProductID)
            SelectedPrice = productPrices(SelectedProductID)

            lblSelectedProduct.Text = "Selected: " & SelectedProductName & " — " & FormatPeso(SelectedPrice)

            nudQty.Maximum = Math.Max(1, productStock(SelectedProductID))
            nudQty.Value = 1
        Catch ex As Exception
            MessageBox.Show("Could not select this product: " & ex.Message)
        End Try
    End Sub

    ' ── cart stepper buttons (+ / −) ─────────────────────────────────────────
    Private Sub dgvOrder_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrder.CellContentClick
        If isLoading Then Return
        If e.RowIndex < 0 Then Return

        Dim colName = dgvOrder.Columns(e.ColumnIndex).Name
        If colName <> "Minus" AndAlso colName <> "Plus" Then Return

        Dim gridRow = dgvOrder.Rows(e.RowIndex)
        Dim dataRow = CType(gridRow.DataBoundItem, DataRowView).Row
        Dim productID = Convert.ToInt32(dataRow("ProductID"))
        Dim currentQty = Convert.ToInt32(dataRow("Quantity"))
        Dim unitPrice = Convert.ToDecimal(dataRow("UnitPrice"))

        Dim conn = DBConnection.GetConnection()
        conn.Open()

        If colName = "Plus" Then
            Dim moreAvailable = GetAvailableStockConsideringCart(productID, conn)
            If moreAvailable < 1 Then
                MessageBox.Show("No more of this item can be added right now.")
                conn.Close()
                Return
            End If

            ReserveIngredientsForProduct(productID, 1, conn)
            dataRow("Quantity") = currentQty + 1
            dataRow("Subtotal") = (currentQty + 1) * unitPrice

        ElseIf colName = "Minus" Then
            If currentQty <= 1 Then
                If MessageBox.Show("Remove this item from your order?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    ReleaseIngredientsForProduct(productID, currentQty, conn)
                    dtCart.Rows.Remove(dataRow)
                    conn.Close()
                    RefreshCartGrid()
                    UpdateTotal()
                    LoadMenu(cboCategory.SelectedItem.ToString())
                    Return
                End If
                conn.Close()
                Return
            End If

            ReleaseIngredientsForProduct(productID, 1, conn)
            dataRow("Quantity") = currentQty - 1
            dataRow("Subtotal") = (currentQty - 1) * unitPrice
        End If

        conn.Close()
        UpdateTotal()
        LoadMenu(cboCategory.SelectedItem.ToString()) ' refresh tile availability since reservations changed
    End Sub

    Private Sub UpdateTotal()
        Dim total As Decimal = 0
        For Each r As DataRow In dtCart.Rows
            If r.RowState <> DataRowState.Deleted Then total += Convert.ToDecimal(r("Subtotal"))
        Next
        lblTotal.Text = "Total: ₱" & total.ToString("0.00")
    End Sub

    ' ── Add to Cart: reserves ingredients the moment it's added. ─────────────
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If SelectedProductID = 0 Then
            MessageBox.Show("Please select a pizza first.")
            Return
        End If

        Dim qty = CInt(nudQty.Value)

        Dim conn = DBConnection.GetConnection()
        conn.Open()

        Dim moreAvailable = GetAvailableStockConsideringCart(SelectedProductID, conn)
        If qty > moreAvailable Then
            MessageBox.Show("Not enough of this item available to add that quantity.")
            conn.Close()
            Return
        End If

        ReserveIngredientsForProduct(SelectedProductID, qty, conn)
        conn.Close()

        Dim existing = dtCart.Select("ProductID = " & SelectedProductID)
        If existing.Length > 0 Then
            existing(0)("Quantity") = Convert.ToInt32(existing(0)("Quantity")) + qty
            existing(0)("Subtotal") = Convert.ToInt32(existing(0)("Quantity")) * SelectedPrice
        Else
            Dim newRow = dtCart.NewRow()
            newRow("ProductID") = SelectedProductID
            newRow("ProductName") = SelectedProductName
            newRow("Quantity") = qty
            newRow("UnitPrice") = SelectedPrice
            newRow("Subtotal") = qty * SelectedPrice
            newRow("Selected") = False
            dtCart.Rows.Add(newRow)
        End If

        RefreshCartGrid()
        UpdateTotal()
        LoadMenu(cboCategory.SelectedItem.ToString()) ' refresh tile availability

        lblSelectedProduct.Text = "Selected: " & SelectedProductName & " — " & FormatPeso(SelectedPrice)
        nudQty.Maximum = Math.Max(1, If(productStock.ContainsKey(SelectedProductID), productStock(SelectedProductID), 1))
        nudQty.Value = 1
    End Sub

    ' ── legacy bulk-remove (checkbox based) — still releases reservations correctly. ──
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim rowsToRemove As New List(Of DataRow)
        For Each gridRow As DataGridViewRow In dgvOrder.Rows
            If gridRow.Cells("Selected").Value IsNot Nothing AndAlso
               Convert.ToBoolean(gridRow.Cells("Selected").Value) = True Then
                rowsToRemove.Add(CType(gridRow.DataBoundItem, DataRowView).Row)
            End If
        Next

        If rowsToRemove.Count = 0 Then
            MessageBox.Show("Please check at least one item to delete.") : Return
        End If

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        For Each r In rowsToRemove
            Dim productID = Convert.ToInt32(r("ProductID"))
            Dim qty = Convert.ToInt32(r("Quantity"))
            ReleaseIngredientsForProduct(productID, qty, conn)
            dtCart.Rows.Remove(r)
        Next
        conn.Close()

        RefreshCartGrid()
        UpdateTotal()
        LoadMenu(cboCategory.SelectedItem.ToString())
    End Sub

    ' ── place order (the ONLY place that writes to the database) ──────────────
    Private Sub btnPlaceOrder_Click(sender As Object, e As EventArgs) Handles btnPlaceOrder.Click
        If dtCart.Rows.Count = 0 Then MessageBox.Show("No items in order.") : Return

        If String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            MessageBox.Show("Please enter the customer's first name.")
            txtFirstName.Focus()
            Return
        End If
        Dim customerName = GetCustomerName()

        Dim total As Decimal = 0
        For Each r As DataRow In dtCart.Rows
            total += Convert.ToDecimal(r("Subtotal"))
        Next

        If MessageBox.Show(
        $"Customer: {customerName}" & Environment.NewLine &
        $"Total: ₱{total.ToString("0.00")}" & Environment.NewLine & Environment.NewLine &
        "Place this order? Please pay at the counter after confirming.",
        "Confirm Order", MessageBoxButtons.YesNo) = DialogResult.No Then Return

        Dim connSave = DBConnection.GetConnection()
        connSave.Open()
        Dim trans = connSave.BeginTransaction()
        Dim transactionID As Integer = 0
        Try
            ' Final real-DB re-check (raw, not cart-aware — this is the actual commit point).
            For Each r As DataRow In dtCart.Rows
                Dim productID = Convert.ToInt32(r("ProductID"))
                Dim qty = Convert.ToInt32(r("Quantity"))
                Dim productName = r("ProductName").ToString()
                Dim available = GetAvailableStock(productID, connSave, trans)
                If qty > available Then
                    Throw New Exception($"{productName} is no longer available in the quantity requested. Please adjust your cart.")
                End If
            Next

            Dim customerID = GetOrCreateCustomerID(connSave, trans)

            Dim cmdTxn As New MySqlCommand(
            "INSERT INTO transactions (CustomerID, TransactionDate, Status, AmountPaid)
             VALUES (@cid, NOW(), 'Pending', NULL)", connSave, trans)
            cmdTxn.Parameters.AddWithValue("@cid", customerID)
            cmdTxn.ExecuteNonQuery()
            transactionID = CInt(cmdTxn.LastInsertedId)

            For Each r As DataRow In dtCart.Rows
                Dim productID = Convert.ToInt32(r("ProductID"))
                Dim qty = Convert.ToInt32(r("Quantity"))
                Dim unitPrice = Convert.ToDecimal(r("UnitPrice"))

                Dim cmdDetail As New MySqlCommand(
                "INSERT INTO transactiondetails (TransactionID, ProductID, Quantity, UnitPrice)
                 VALUES (@tid, @pid, @qty, @price)", connSave, trans)
                cmdDetail.Parameters.AddWithValue("@tid", transactionID)
                cmdDetail.Parameters.AddWithValue("@pid", productID)
                cmdDetail.Parameters.AddWithValue("@qty", qty)
                cmdDetail.Parameters.AddWithValue("@price", unitPrice)
                cmdDetail.ExecuteNonQuery()

                ' Hard reserve — actually deduct real DB stock now.
                DeductStockFIFO(productID, qty, connSave, trans)
            Next

            trans.Commit()
        Catch ex As Exception
            trans.Rollback()
            MessageBox.Show("Order failed: " & ex.Message)
            connSave.Close()
            Return
        End Try
        connSave.Close()

        MessageBox.Show(
        $"✅ Order placed! Your order number is #{transactionID}" & Environment.NewLine &
        $"Total: ₱{total.ToString("0.00")}" & Environment.NewLine & Environment.NewLine &
        "Please proceed to the counter to pay.", "Order Confirmed")

        txtFirstName.Clear()
        txtLastName.Clear()
        dtCart.Clear()
        reservedIngredients.Clear() ' real DB stock now reflects the order — reservation pool resets
        RefreshCartGrid()
        UpdateTotal()
        SelectedProductID = 0
        lblSelectedProduct.Text = "No item selected"

        LoadMenu() ' refresh tiles for the next customer
    End Sub

    Private Sub DeductStockFIFO(productID As Integer, qty As Integer,
                                 conn As MySqlConnection, transaction As MySqlTransaction)
        Dim recipe = GetProductRecipe(productID, conn, transaction)

        For Each ing In recipe
            Dim needed = CInt(Math.Ceiling(ing.QtyRequired * qty))
            Dim remaining = needed

            Dim cmdBatches As New MySqlCommand(
                "SELECT BatchID, RemainingQty FROM ingredientbatches
 WHERE IngredientID = @iid AND ExpiryDate >= CURDATE() AND RemainingQty > 0 AND IsVoided = 0
 ORDER BY ExpiryDate ASC", conn, transaction)
            cmdBatches.Parameters.AddWithValue("@iid", ing.IngredientID)
            Dim readerBatches = cmdBatches.ExecuteReader()
            Dim batches As New List(Of (ID As Integer, Qty As Integer))
            While readerBatches.Read()
                batches.Add((Convert.ToInt32(readerBatches("BatchID")), Convert.ToInt32(readerBatches("RemainingQty"))))
            End While
            readerBatches.Close()

            For Each batch In batches
                If remaining <= 0 Then Exit For
                Dim deduct = Math.Min(remaining, batch.Qty)
                Dim cmdDeduct As New MySqlCommand(
                    "UPDATE ingredientbatches SET RemainingQty = RemainingQty - @deduct WHERE BatchID = @bid",
                    conn, transaction)
                cmdDeduct.Parameters.AddWithValue("@deduct", deduct)
                cmdDeduct.Parameters.AddWithValue("@bid", batch.ID)
                cmdDeduct.ExecuteNonQuery()
                remaining -= deduct
            Next
            If remaining > 0 Then
                Throw New Exception($"Insufficient stock for ingredient ID {ing.IngredientID} during checkout.")
            End If
        Next
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("Cancel and Exit?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            txtFirstName.Clear()
            txtLastName.Clear()
            dtCart.Clear()
            reservedIngredients.Clear() ' nothing in the cart anymore — release everything
            RefreshCartGrid()
            UpdateTotal()

            If Module2.OrderOpenedBy = "Customer" Then
                frmWelcome.Show()
            Else
                frmTransactions.Show()  ' Manager or Cashier
            End If
            Me.Close()
        End If
    End Sub



    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        If isLoading Then Return
        LoadMenu(cboCategory.SelectedItem.ToString())
    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged
    End Sub

    Private Sub lblSelectedProduct_Click(sender As Object, e As EventArgs) Handles lblSelectedProduct.Click
    End Sub

    Private Sub nudQty_ValueChanged(sender As Object, e As EventArgs) Handles nudQty.ValueChanged

    End Sub
End Class