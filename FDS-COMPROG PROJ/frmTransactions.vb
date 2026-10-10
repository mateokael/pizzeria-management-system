Imports MySql.Data.MySqlClient

Public Class frmTransactions

    Dim isLoading As Boolean = False
    Dim selectedTransactionID As Integer = 0

    Dim editingDetailID As Integer = 0
    Dim originalDetailProductID As Integer = 0
    Dim originalDetailQty As Integer = 0

    Dim pendingVoidID As Integer = 0
    Dim pendingDeleteID As Integer = 0



    Private Sub LoadFilterCustomers()
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
        "SELECT CustomerID, CONCAT(FirstName, ' ', COALESCE(LastName, '')) AS CustomerName
         FROM customers ORDER BY FirstName", conn)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        Dim allRow = dt.NewRow()
        allRow("CustomerID") = 0
        allRow("CustomerName") = "All Customers"
        dt.Rows.InsertAt(allRow, 0)

        cboFilterCustomer.DisplayMember = "CustomerName"
        cboFilterCustomer.ValueMember = "CustomerID"
        cboFilterCustomer.DataSource = dt
        cboFilterCustomer.SelectedIndex = 0
    End Sub

    Private Sub frmTransactions_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        LoadFilterCustomers()
    End Sub
    Private Sub frmTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = DateTime.Today.AddMonths(-1)
        dtpTo.Value = DateTime.Today
        cboEditProduct.Enabled = False
        numEditQty.Enabled = False

        LoadEditProductComboBox()
        LoadFilterCustomers()
        LoadTransactions()
        ClearEditPanel()
        ApplyRolePermissions()
        dgvTransactions.DefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvTransactions.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvTransactionDetails.DefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvTransactionDetails.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)

    End Sub

    Private Sub ShowMessage(text As String, Optional isError As Boolean = False)
        If String.IsNullOrEmpty(text) Then Return
        MessageBox.Show(text)
    End Sub

    Private Sub ApplyRolePermissions()
        If Module2.CurrentUserRole = "Cashier" Then
            btnVoid.Enabled = False
            btnDelete.Enabled = False

        End If
    End Sub


    ' ── CHANGED: stock is now derived from the product's recipe + ingredient
    ' batches (mirrors frmCustomerOrder.GetAvailableStock / frmInventory.GetProductAvailableStock).
    Private Function GetAvailableStock(productID As Integer) As Integer
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "SELECT pi.QtyRequired,
                    COALESCE((SELECT SUM(RemainingQty) FROM ingredientbatches
                              WHERE IngredientID = pi.IngredientID AND ExpiryDate >= CURDATE() AND IsVoided = 0), 0) AS AvailQty
             FROM productingredients pi
             WHERE pi.ProductID = @pid", conn)
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
        conn.Close()
        If Not hasRecipe Then Return 0
        Return minUnits
    End Function

    ' ── load transactions ────────────────────────────────────────────────
    Public Sub LoadTransactions(Optional dateFrom As DateTime = Nothing,
                              Optional dateTo As DateTime = Nothing,
                              Optional customerID As Integer = 0)
        isLoading = True
        Dim query As String =
        "SELECT t.TransactionID, t.TransactionDate, t.Status, t.AmountPaid,
                CONCAT(COALESCE(c.FirstName, 'Walk-in'), ' ', COALESCE(c.LastName, '')) AS CustomerName,
                (SELECT COALESCE(SUM(td.Quantity * td.UnitPrice), 0)
                   FROM transactiondetails td WHERE td.TransactionID = t.TransactionID) AS TotalAmount
         FROM transactions t
         LEFT JOIN customers c ON t.CustomerID = c.CustomerID
         WHERE 1=1"
        If dateFrom <> Nothing Then query &= " AND t.TransactionDate >= @from"
        If dateTo <> Nothing Then query &= " AND t.TransactionDate <= @to"
        If customerID > 0 Then query &= " AND t.CustomerID = @cid"
        query &= " ORDER BY t.TransactionDate DESC"

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(query, conn)
        If dateFrom <> Nothing Then cmd.Parameters.AddWithValue("@from", dateFrom.ToString("yyyy-MM-dd"))
        If dateTo <> Nothing Then cmd.Parameters.AddWithValue("@to", dateTo.ToString("yyyy-MM-dd 23:59:59"))
        If customerID > 0 Then cmd.Parameters.AddWithValue("@cid", customerID)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        dgvTransactions.DataSource = dt
        dgvTransactions.AllowUserToAddRows = False
        dgvTransactions.ReadOnly = True
        If dgvTransactions.Columns.Contains("TransactionID") Then dgvTransactions.Columns("TransactionID").DisplayIndex = 0
        If dgvTransactions.Columns.Contains("CustomerName") Then dgvTransactions.Columns("CustomerName").DisplayIndex = 1
        If dgvTransactions.Columns.Contains("TransactionDate") Then dgvTransactions.Columns("TransactionDate").DisplayIndex = 2
        If dgvTransactions.Columns.Contains("TotalAmount") Then dgvTransactions.Columns("TotalAmount").DisplayIndex = 3
        If dgvTransactions.Columns.Contains("AmountPaid") Then dgvTransactions.Columns("AmountPaid").DisplayIndex = 4
        If dgvTransactions.Columns.Contains("Status") Then dgvTransactions.Columns("Status").DisplayIndex = 5

        For Each row As DataGridViewRow In dgvTransactions.Rows
            If row.Cells("Status").Value.ToString() = "Voided" Then
                row.DefaultCellStyle.BackColor = Color.LightCoral
                row.DefaultCellStyle.ForeColor = Color.DarkRed
            End If
        Next
        isLoading = False
        UpdateTotalLabel()
    End Sub

    ' ── select a transaction row: load its details into edit panel ──
    Private Sub dgvTransactions_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTransactions.CellClick
        If isLoading Then Return
        If e.RowIndex < 0 Then Return

        Dim row = dgvTransactions.Rows(e.RowIndex)
        Dim clickedID = Convert.ToInt32(row.Cells("TransactionID").Value)

        If clickedID <> selectedTransactionID Then
            pendingVoidID = 0
            pendingDeleteID = 0
        End If

        selectedTransactionID = clickedID
        LoadTransactionDetails(selectedTransactionID)
        ShowMessage("")

        ' Enable Add Item controls as soon as an order is selected — no need to
        ' click an existing line item first just to add a new product.
        Dim statusConn = DBConnection.GetConnection()
        statusConn.Open()
        Dim cmdStatus As New MySqlCommand("SELECT Status FROM transactions WHERE TransactionID = @tid", statusConn)
        cmdStatus.Parameters.AddWithValue("@tid", selectedTransactionID)
        Dim txnStatus = cmdStatus.ExecuteScalar().ToString()
        statusConn.Close()

        Dim isPending = (txnStatus = "Pending")
        cboEditProduct.Enabled = isPending
        numEditQty.Enabled = isPending

        editingDetailID = 0
        originalDetailProductID = 0
        originalDetailQty = 0
        cboEditProduct.SelectedIndex = -1
        numEditQty.Value = numEditQty.Minimum
        lblStock.Text = ""
        lblEditingInfo.Text = If(isPending,
        $"TXN-{selectedTransactionID}: select a product + qty and click Add Item, or click an existing line below to edit it.",
        $"TXN-{selectedTransactionID}: {txnStatus} orders cannot be modified.")
    End Sub

    Private Sub LoadTransactionDetails(transactionID As Integer)
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "SELECT td.DetailID, td.ProductID, p.ProductName, td.Quantity, td.UnitPrice,
                    (td.Quantity * td.UnitPrice) AS Subtotal
             FROM transactiondetails td
             JOIN products p ON td.ProductID = p.ProductID
             WHERE td.TransactionID = @tid", conn)
        cmd.Parameters.AddWithValue("@tid", transactionID)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        dgvTransactionDetails.DataSource = dt
        dgvTransactionDetails.AllowUserToAddRows = False
        dgvTransactionDetails.ReadOnly = True
        If dgvTransactionDetails.Columns.Contains("DetailID") Then
            dgvTransactionDetails.Columns("DetailID").Visible = False
        End If
        If dgvTransactionDetails.Columns.Contains("ProductID") Then
            dgvTransactionDetails.Columns("ProductID").Visible = False
        End If

        UpdateEditTotalLabel()
    End Sub

    ' ── select a line item: load product/qty into edit panel ─────────────────
    Private Sub dgvTransactionDetails_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTransactionDetails.CellClick
        If isLoading Then Return
        If e.RowIndex < 0 Then Return

        Dim row = dgvTransactionDetails.Rows(e.RowIndex)
        editingDetailID = Convert.ToInt32(row.Cells("DetailID").Value)
        originalDetailProductID = Convert.ToInt32(row.Cells("ProductID").Value)
        originalDetailQty = Convert.ToInt32(row.Cells("Quantity").Value)

        EnsureProductInEditCombo(originalDetailProductID, row.Cells("ProductName").Value.ToString())

        cboEditProduct.Enabled = True
        numEditQty.Enabled = True
        cboEditProduct.SelectedValue = originalDetailProductID
        numEditQty.Value = originalDetailQty
        lblEditingInfo.Text = $"Editing line item #{editingDetailID} (TXN-{selectedTransactionID})."
        UpdateStockLabel()
        UpdateEditTotalLabel()
    End Sub

    ' ── product combo: only products with computed available stock > 0 ───────
    Private Sub LoadEditProductComboBox()
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand("SELECT ProductID, ProductName, Price FROM products WHERE IsActive = 1 ORDER BY ProductName", conn)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dtAll As New DataTable
        adapter.Fill(dtAll)
        conn.Close()

        Dim dt As New DataTable
        dt.TableName = "EditProducts"
        dt.Columns.Add("ProductID", GetType(Integer))
        dt.Columns.Add("ProductName", GetType(String))
        dt.Columns.Add("Price", GetType(Decimal))
        dt.Columns.Add("Stock", GetType(Integer))

        For Each row As DataRow In dtAll.Rows
            Dim pid = Convert.ToInt32(row("ProductID"))
            Dim stock = GetAvailableStock(pid)
            If stock > 0 Then
                Dim newRow = dt.NewRow()
                newRow("ProductID") = pid
                newRow("ProductName") = row("ProductName")
                newRow("Price") = row("Price")
                newRow("Stock") = stock
                dt.Rows.Add(newRow)
            End If
        Next

        cboEditProduct.DataSource = dt
        cboEditProduct.DisplayMember = "ProductName"
        cboEditProduct.ValueMember = "ProductID"
        cboEditProduct.SelectedIndex = -1
    End Sub

    ' If the line's current product has 0 remaining stock (all reserved by
    ' this line already), it won't be in the "has stock" combo — add it back
    ' in temporarily so the user can still keep the same product/qty.
    Private Sub EnsureProductInEditCombo(productID As Integer, productName As String)
        Dim dt = CType(cboEditProduct.DataSource, DataTable)
        If dt Is Nothing Then Return
        Dim existing = dt.Select("ProductID = " & productID)
        If existing.Length = 0 Then
            Dim conn = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT Price FROM products WHERE ProductID = @pid", conn)
            cmd.Parameters.AddWithValue("@pid", productID)
            Dim price = Convert.ToDecimal(cmd.ExecuteScalar())
            conn.Close()

            Dim newRow = dt.NewRow()
            newRow("ProductID") = productID
            newRow("ProductName") = productName
            newRow("Price") = price
            newRow("Stock") = 0
            dt.Rows.Add(newRow)
        End If
    End Sub

    Private Sub cboEditProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEditProduct.SelectedIndexChanged
        UpdateStockLabel()
        UpdateEditTotalLabel()
    End Sub

    Private Sub numEditQty_ValueChanged(sender As Object, e As EventArgs) Handles numEditQty.ValueChanged
        UpdateStockLabel()
        UpdateEditTotalLabel()
    End Sub

    Private Sub UpdateStockLabel()
        If cboEditProduct.SelectedItem Is Nothing Then
            lblStock.Text = ""
            Return
        End If
        Dim dt = CType(cboEditProduct.DataSource, DataTable)
        Dim selectedRow = dt.Rows(cboEditProduct.SelectedIndex)
        Dim productID = Convert.ToInt32(selectedRow("ProductID"))
        Dim available = GetAvailableStock(productID)

        ' If this is the same product already on the line being edited, its
        ' current quantity is already reserved, so the real ceiling is
        ' available + originalDetailQty.
        If editingDetailID <> 0 AndAlso productID = originalDetailProductID Then
            available += originalDetailQty
        End If

        Dim enteredQty = Convert.ToInt32(numEditQty.Value)
        Dim remainingAfter = available - enteredQty

        lblStock.Text = $"Available Stock: {available} — after this: {Math.Max(0, remainingAfter)} left (not yet saved)"
    End Sub

    ' ── shows the live prospective total for the transaction currently being
    ' edited (all existing line items, with the pending line-item edit, if
    ' any, applied on top) ─────────────────────────────────────────────────
    Private Sub UpdateEditTotalLabel()
        If selectedTransactionID = 0 Then
            lblEditTotal.Text = ""
            Return
        End If

        Dim newQty As Integer = 0
        Dim newPrice As Decimal = 0
        Dim updatingDetail = (editingDetailID <> 0)

        If updatingDetail Then
            If cboEditProduct.SelectedItem Is Nothing Then
                lblEditTotal.Text = "Edit Total: ₱0.00"
                Return
            End If
            Dim dtCombo = CType(cboEditProduct.DataSource, DataTable)
            Dim selectedRow = dtCombo.Rows(cboEditProduct.SelectedIndex)
            newPrice = Convert.ToDecimal(selectedRow("Price"))
            newQty = Convert.ToInt32(numEditQty.Value)
        End If

        Dim total As Decimal = 0
        For Each row As DataGridViewRow In dgvTransactionDetails.Rows
            Dim rowDetailID = Convert.ToInt32(row.Cells("DetailID").Value)
            If updatingDetail AndAlso rowDetailID = editingDetailID Then
                total += newQty * newPrice
            Else
                total += Convert.ToDecimal(row.Cells("Subtotal").Value)
            End If
        Next

        lblEditTotal.Text = "Edit Total: ₱" & total.ToString("0.00")
    End Sub

    Private Sub ClearEditPanel()
        cboEditProduct.Enabled = False
        numEditQty.Enabled = False

        selectedTransactionID = 0
        editingDetailID = 0
        originalDetailProductID = 0
        originalDetailQty = 0

        numEditQty.Value = numEditQty.Minimum
        cboEditProduct.SelectedIndex = -1
        lblStock.Text = ""
        lblEditingInfo.Text = "Select a transaction to edit."
        lblEditTotal.Text = ""
    End Sub

    ' ── recipe-aware ingredient restore/deduct helpers ──────────────────────
    Private Sub RestoreStockForProduct(productID As Integer, qty As Integer,
                                    conn As MySqlConnection, transaction As MySqlTransaction)
        Dim cmdRecipe As New MySqlCommand(
        "SELECT IngredientID, QtyRequired FROM productingredients WHERE ProductID = @pid", conn, transaction)
        cmdRecipe.Parameters.AddWithValue("@pid", productID)
        Dim reader = cmdRecipe.ExecuteReader()
        Dim recipe As New List(Of (IngredientID As Integer, QtyRequired As Decimal))
        While reader.Read()
            recipe.Add((Convert.ToInt32(reader("IngredientID")), Convert.ToDecimal(reader("QtyRequired"))))
        End While
        reader.Close()

        For Each ing In recipe
            Dim restoreQty = CInt(Math.Ceiling(ing.QtyRequired * qty))

            Dim cmdStock As New MySqlCommand(
            "UPDATE ingredientbatches SET RemainingQty = RemainingQty + @qty
             WHERE BatchID = (
                SELECT BatchID FROM (
                    SELECT BatchID FROM ingredientbatches
                    WHERE IngredientID = @iid
                      AND IsVoided = 0
                      AND ExpiryDate >= CURDATE()
                    ORDER BY ExpiryDate DESC LIMIT 1
                ) AS sub
             )", conn, transaction)
            cmdStock.Parameters.AddWithValue("@qty", restoreQty)
            cmdStock.Parameters.AddWithValue("@iid", ing.IngredientID)
            Dim rowsAffected = cmdStock.ExecuteNonQuery()

            If rowsAffected = 0 Then
                Throw New Exception($"Could not restore stock for ingredient ID {ing.IngredientID} — no active, non-expired batch found to restore into.")
            End If
        Next
    End Sub

    Private Sub DeductStockForProduct(productID As Integer, qty As Integer,
                                   conn As MySqlConnection, transaction As MySqlTransaction)
        Dim cmdRecipe As New MySqlCommand(
        "SELECT IngredientID, QtyRequired FROM productingredients WHERE ProductID = @pid", conn, transaction)
        cmdRecipe.Parameters.AddWithValue("@pid", productID)
        Dim readerRecipe = cmdRecipe.ExecuteReader()
        Dim recipe As New List(Of (IngredientID As Integer, QtyRequired As Decimal))
        While readerRecipe.Read()
            recipe.Add((Convert.ToInt32(readerRecipe("IngredientID")), Convert.ToDecimal(readerRecipe("QtyRequired"))))
        End While
        readerRecipe.Close()

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
                Throw New Exception($"Insufficient stock for ingredient ID {ing.IngredientID} while updating this order.")
            End If
        Next
    End Sub

    ' ── update button: only handles editing an existing line item's product/qty.
    ' Payment is handled exclusively via Confirm Payment now — AmountPaid is no
    ' longer editable here.
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedTransactionID = 0 Then
            ShowMessage("Please select a transaction first.", True)
            Return
        End If

        Dim connCheck = DBConnection.GetConnection()
        connCheck.Open()
        Dim cmdCheck As New MySqlCommand("SELECT Status FROM transactions WHERE TransactionID = @tid", connCheck)
        cmdCheck.Parameters.AddWithValue("@tid", selectedTransactionID)
        Dim status = cmdCheck.ExecuteScalar().ToString()
        connCheck.Close()
        If status <> "Pending" Then
            ShowMessage("Only Pending orders can be edited. Completed orders can't be modified here.", True)
            Return
        End If

        If editingDetailID = 0 Then
            ShowMessage("Please click a line item to edit first, or use Add Item to add a new product.", True)
            Return
        End If

        If cboEditProduct.SelectedItem Is Nothing Then
            ShowMessage("Please select a product.", True)
            Return
        End If
        Dim dt = CType(cboEditProduct.DataSource, DataTable)
        Dim selectedRow = dt.Rows(cboEditProduct.SelectedIndex)
        Dim newProductID = Convert.ToInt32(selectedRow("ProductID"))
        Dim newPrice = Convert.ToDecimal(selectedRow("Price"))
        Dim newQty = Convert.ToInt32(numEditQty.Value)

        ' ── stock check ──
        Dim available = GetAvailableStock(newProductID)
        If newProductID = originalDetailProductID Then
            available += originalDetailQty
        End If
        If newQty > available Then
            ShowMessage($"Insufficient stock. Only {available} unit(s) available for this product.", True)
            Return
        End If

        ' ── write to DB ──
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim trans = conn.BeginTransaction()
        Try
            RestoreStockForProduct(originalDetailProductID, originalDetailQty, conn, trans)
            DeductStockForProduct(newProductID, newQty, conn, trans)

            Dim cmdDetail As New MySqlCommand(
                "UPDATE transactiondetails SET ProductID = @pid, UnitPrice = @price, Quantity = @qty
                 WHERE DetailID = @did", conn, trans)
            cmdDetail.Parameters.AddWithValue("@pid", newProductID)
            cmdDetail.Parameters.AddWithValue("@price", newPrice)
            cmdDetail.Parameters.AddWithValue("@qty", newQty)
            cmdDetail.Parameters.AddWithValue("@did", editingDetailID)
            cmdDetail.ExecuteNonQuery()

            trans.Commit()
            ShowMessage("Updated successfully.")
        Catch ex As Exception
            trans.Rollback()
            ShowMessage("Update failed: " & ex.Message, True)
            conn.Close()
            Return
        End Try
        conn.Close()

        Dim keepTransactionID = selectedTransactionID
        LoadEditProductComboBox()
        LoadTransactions()
        LoadTransactionDetails(keepTransactionID)
        selectedTransactionID = keepTransactionID
    End Sub

    ' ── NEW: add another product line to the currently selected Pending order ──
    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        If selectedTransactionID = 0 Then
            ShowMessage("Please select a transaction first.", True)
            Return
        End If

        Dim connCheck = DBConnection.GetConnection()
        connCheck.Open()
        Dim cmdCheck As New MySqlCommand("SELECT Status FROM transactions WHERE TransactionID = @tid", connCheck)
        cmdCheck.Parameters.AddWithValue("@tid", selectedTransactionID)
        Dim status = cmdCheck.ExecuteScalar().ToString()
        connCheck.Close()
        If status <> "Pending" Then
            ShowMessage("Only Pending orders can have items added. Completed orders can't be modified here.", True)
            Return
        End If

        If cboEditProduct.SelectedItem Is Nothing Then
            ShowMessage("Please select a product to add.", True)
            Return
        End If
        Dim dt = CType(cboEditProduct.DataSource, DataTable)
        Dim selectedRow = dt.Rows(cboEditProduct.SelectedIndex)
        Dim productID = Convert.ToInt32(selectedRow("ProductID"))
        Dim price = Convert.ToDecimal(selectedRow("Price"))
        Dim qtyToAdd = Convert.ToInt32(numEditQty.Value)

        Dim conn = DBConnection.GetConnection()
        conn.Open()

        ' Does this product already have a line on this order?
        Dim cmdExisting As New MySqlCommand(
        "SELECT DetailID, Quantity FROM transactiondetails WHERE TransactionID = @tid AND ProductID = @pid", conn)
        cmdExisting.Parameters.AddWithValue("@tid", selectedTransactionID)
        cmdExisting.Parameters.AddWithValue("@pid", productID)
        Dim readerExisting = cmdExisting.ExecuteReader()
        Dim existingDetailID As Integer = 0
        Dim existingQty As Integer = 0
        If readerExisting.Read() Then
            existingDetailID = Convert.ToInt32(readerExisting("DetailID"))
            existingQty = Convert.ToInt32(readerExisting("Quantity"))
        End If
        readerExisting.Close()

        ' Stock check accounts for what's already reserved by this same line, if any.
        ' Stock check accounts for what's already reserved by this same line, if any.
        Dim available = GetAvailableStock(productID)
        If existingDetailID <> 0 Then available += existingQty

        Dim totalRequestedQty = If(existingDetailID <> 0, existingQty + qtyToAdd, qtyToAdd)
        If totalRequestedQty > available Then
            ShowMessage($"Insufficient stock. Only {available} unit(s) available for this product.", True)
            conn.Close()
            Return
        End If

        Dim trans = conn.BeginTransaction()
        Try
            DeductStockForProduct(productID, qtyToAdd, conn, trans)

            If existingDetailID <> 0 Then
                ' Same product already on this order — bump its quantity instead of a new row.
                Dim newQty = existingQty + qtyToAdd
                Dim cmdBump As New MySqlCommand(
                "UPDATE transactiondetails SET Quantity = @qty, UnitPrice = @price WHERE DetailID = @did", conn, trans)
                cmdBump.Parameters.AddWithValue("@qty", newQty)
                cmdBump.Parameters.AddWithValue("@price", price)
                cmdBump.Parameters.AddWithValue("@did", existingDetailID)
                cmdBump.ExecuteNonQuery()
            Else
                Dim cmdInsert As New MySqlCommand(
                "INSERT INTO transactiondetails (TransactionID, ProductID, Quantity, UnitPrice)
                 VALUES (@tid, @pid, @qty, @price)", conn, trans)
                cmdInsert.Parameters.AddWithValue("@tid", selectedTransactionID)
                cmdInsert.Parameters.AddWithValue("@pid", productID)
                cmdInsert.Parameters.AddWithValue("@qty", qtyToAdd)
                cmdInsert.Parameters.AddWithValue("@price", price)
                cmdInsert.ExecuteNonQuery()
            End If

            trans.Commit()
            ShowMessage("Item added to order.")
        Catch ex As Exception
            trans.Rollback()
            ShowMessage("Add item failed: " & ex.Message, True)
            conn.Close()
            Return
        End Try
        conn.Close()

        Dim keepTransactionID = selectedTransactionID
        cboEditProduct.SelectedIndex = -1
        numEditQty.Value = numEditQty.Minimum
        editingDetailID = 0
        originalDetailProductID = 0
        originalDetailQty = 0
        LoadEditProductComboBox()
        LoadTransactions()
        LoadTransactionDetails(keepTransactionID)
        selectedTransactionID = keepTransactionID
    End Sub

    Private Sub UpdateTotalLabel()
        Dim total As Decimal = 0
        For Each row As DataGridViewRow In dgvTransactions.Rows
            Dim status = row.Cells("Status").Value.ToString().Trim()
            If status.Equals("Completed", StringComparison.OrdinalIgnoreCase) Then
                total += Convert.ToDecimal(row.Cells("TotalAmount").Value)
            End If
        Next
        lblTotal.Text = "Total Sales: ₱" & total.ToString("0.00")
    End Sub

    ' ── filter ──────────────────────────────────────────────────────────────
    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        If dtpFrom.Value.Date > dtpTo.Value.Date Then
            ShowMessage("From date cannot be later than To date.", True)
            Return
        End If
        ShowMessage("")
        Dim selectedCustomerID = Convert.ToInt32(cboFilterCustomer.SelectedValue)
        LoadTransactions(dtpFrom.Value.Date, dtpTo.Value.Date, selectedCustomerID)
    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        dtpFrom.Value = DateTime.Today.AddMonths(-1)
        cboFilterCustomer.SelectedIndex = 0
        dtpTo.Value = DateTime.Today
        ShowMessage("")
        LoadTransactions()
    End Sub


    Private Sub btnVoid_Click(sender As Object, e As EventArgs) Handles btnVoid.Click
        If selectedTransactionID = 0 Then
            ShowMessage("Please select a transaction.", True)
            Return
        End If

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmdCheck As New MySqlCommand(
            "SELECT Status FROM transactions WHERE TransactionID = @tid", conn)
        cmdCheck.Parameters.AddWithValue("@tid", selectedTransactionID)
        Dim status = cmdCheck.ExecuteScalar().ToString()
        If status = "Voided" Then
            ShowMessage("Transaction is already voided.", True)
            conn.Close()
            Return
        End If
        If status <> "Pending" Then
            ShowMessage("Only Pending orders can be voided. Completed orders can't be reversed here.", True)
            conn.Close()
            Return
        End If

        If pendingVoidID <> selectedTransactionID Then
            pendingVoidID = selectedTransactionID
            pendingDeleteID = 0
            ShowMessage($"Click Void again to confirm voiding TXN-{selectedTransactionID}. Stock will be restored.", True)
            conn.Close()
            Return
        End If

        pendingVoidID = 0
        Dim trans = conn.BeginTransaction()
        Try
            Dim cmdItems As New MySqlCommand(
                "SELECT ProductID, Quantity FROM transactiondetails WHERE TransactionID = @tid",
                conn, trans)
            cmdItems.Parameters.AddWithValue("@tid", selectedTransactionID)
            Dim reader = cmdItems.ExecuteReader()
            Dim items As New List(Of (ProductID As Integer, Qty As Integer))
            While reader.Read()
                items.Add((Convert.ToInt32(reader("ProductID")), Convert.ToInt32(reader("Quantity"))))
            End While
            reader.Close()

            For Each item In items
                RestoreStockForProduct(item.ProductID, item.Qty, conn, trans)
            Next

            Dim cmdVoid As New MySqlCommand(
                "UPDATE transactions SET Status = 'Voided' WHERE TransactionID = @tid",
                conn, trans)
            cmdVoid.Parameters.AddWithValue("@tid", selectedTransactionID)
            cmdVoid.ExecuteNonQuery()

            trans.Commit()
            ShowMessage("Transaction voided. Stock restored.")
        Catch ex As Exception
            trans.Rollback()
            ShowMessage("Void failed: " & ex.Message, True)
        End Try
        conn.Close()
        LoadEditProductComboBox()
        LoadTransactions()
    End Sub

    ' ── delete: currently PENDING-ONLY. Voided/Completed transactions cannot
    ' be deleted from history through this button. ──────────────────────────
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedTransactionID = 0 Then
            ShowMessage("Please select a transaction.", True)
            Return
        End If

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmdCheck As New MySqlCommand("SELECT Status FROM transactions WHERE TransactionID = @tid", conn)
        cmdCheck.Parameters.AddWithValue("@tid", selectedTransactionID)
        Dim result = cmdCheck.ExecuteScalar()
        If result Is Nothing Then
            ShowMessage("Transaction no longer exists.", True)
            conn.Close()
            Return
        End If
        Dim status = result.ToString()

        If status = "Completed" Then
            ShowMessage("Completed orders cannot be deleted. They remain in history permanently as a sales record.", True)
            conn.Close()
            Return
        End If
        ' status is now either "Pending" or "Voided" — both deletable.

        If pendingDeleteID <> selectedTransactionID Then
            pendingDeleteID = selectedTransactionID
            pendingVoidID = 0
            ShowMessage($"Click Delete again to permanently delete TXN-{selectedTransactionID}.", True)
            conn.Close()
            Return
        End If

        pendingDeleteID = 0
        Dim trans = conn.BeginTransaction()
        Try
            ' Only restore stock if this is a Pending order — a Voided order
            ' already had its stock restored when it was voided, so restoring
            ' again here would double-credit the ingredients.
            If status = "Pending" Then
                Dim cmdItems As New MySqlCommand(
                "SELECT ProductID, Quantity FROM transactiondetails WHERE TransactionID = @tid", conn, trans)
                cmdItems.Parameters.AddWithValue("@tid", selectedTransactionID)
                Dim reader = cmdItems.ExecuteReader()
                Dim items As New List(Of (ProductID As Integer, Qty As Integer))
                While reader.Read()
                    items.Add((Convert.ToInt32(reader("ProductID")), Convert.ToInt32(reader("Quantity"))))
                End While
                reader.Close()

                For Each item In items
                    RestoreStockForProduct(item.ProductID, item.Qty, conn, trans)
                Next
            End If

            Dim cmdDetails As New MySqlCommand(
            "DELETE FROM transactiondetails WHERE TransactionID = @tid", conn, trans)
            cmdDetails.Parameters.AddWithValue("@tid", selectedTransactionID)
            cmdDetails.ExecuteNonQuery()
            Dim cmdTxn As New MySqlCommand(
            "DELETE FROM transactions WHERE TransactionID = @tid", conn, trans)
            cmdTxn.Parameters.AddWithValue("@tid", selectedTransactionID)
            cmdTxn.ExecuteNonQuery()
            trans.Commit()

            If status = "Pending" Then
                ShowMessage("Transaction deleted. Stock restored.")
            Else
                ShowMessage("Voided transaction deleted.")
            End If
        Catch ex As Exception
            trans.Rollback()
            ShowMessage("Delete failed: " & ex.Message, True)
            conn.Close()
            Return
        End Try
        conn.Close()
        dgvTransactionDetails.DataSource = Nothing
        ClearEditPanel()
        LoadEditProductComboBox()
        LoadTransactions()
    End Sub

    ' ── reprint ────────────────────────────────────────────────────────────
    Private Sub btnReprint_Click(sender As Object, e As EventArgs) Handles btnReprint.Click
        If selectedTransactionID = 0 Then
            ShowMessage("Please select a transaction.", True)
            Return
        End If

        Dim conn = DBConnection.GetConnection()
        conn.Open()

        Dim cmdInfo As New MySqlCommand(
        "SELECT t.TransactionDate, t.AmountPaid,
                CONCAT(COALESCE(c.FirstName,'Walk-in'), ' ', COALESCE(c.LastName,'')) AS CustomerName,
                CONCAT(emp.FirstName, ' ', emp.LastName) AS ConfirmedByName
         FROM transactions t
         LEFT JOIN customers c ON t.CustomerID = c.CustomerID
         LEFT JOIN employees emp ON t.ConfirmedByEmployeeID = emp.EmployeeID
         WHERE t.TransactionID = @tid", conn)
        cmdInfo.Parameters.AddWithValue("@tid", selectedTransactionID)
        Dim reader = cmdInfo.ExecuteReader()
        Dim txnDate As DateTime = DateTime.Now
        Dim customerName As String = "Walk-in"
        Dim confirmedByName As String = "N/A"
        Dim amountPaid As Decimal = 0D
        If reader.Read() Then
            txnDate = Convert.ToDateTime(reader("TransactionDate"))
            customerName = reader("CustomerName").ToString()
            If Not IsDBNull(reader("AmountPaid")) Then amountPaid = Convert.ToDecimal(reader("AmountPaid"))
            If Not IsDBNull(reader("ConfirmedByName")) Then confirmedByName = reader("ConfirmedByName").ToString()
        End If
        reader.Close()

        Dim cmdItems As New MySqlCommand(
        "SELECT p.ProductName, td.Quantity, td.UnitPrice, (td.Quantity * td.UnitPrice) AS Subtotal
         FROM transactiondetails td
         JOIN products p ON td.ProductID = p.ProductID
         WHERE td.TransactionID = @tid", conn)
        cmdItems.Parameters.AddWithValue("@tid", selectedTransactionID)
        Dim adapter As New MySqlDataAdapter(cmdItems)
        Dim dsReceipt As New DataSet
        adapter.Fill(dsReceipt, "dtReceiptItems")
        conn.Close()

        Dim total As Decimal = 0
        For Each row As DataRow In dsReceipt.Tables("dtReceiptItems").Rows
            total += Convert.ToDecimal(row("Subtotal"))
        Next

        Dim report As New rptReceipt
        report.SetDataSource(dsReceipt.Tables("dtReceiptItems"))
        report.SetParameterValue("TransactionID", selectedTransactionID)
        report.SetParameterValue("CustomerName", customerName)
        report.SetParameterValue("TransactionDate", txnDate)
        report.SetParameterValue("Total", total)
        report.SetParameterValue("AmountPaid", amountPaid)
        report.SetParameterValue("ChangeDue", amountPaid - total)
        report.SetParameterValue("ConfirmedBy", confirmedByName)

        Dim frm As New frmReceiptViewer
        frm.CrystalReportViewer1.ReportSource = report
        frm.Show()

        ShowMessage("Receipt reprinted.")
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If Module2.CurrentUserRole = "Cashier" Then
            frmAdminLogin.Show()   ' or a dedicated cashier landing form, if you have one
        Else
            frmAdminDashboard.Show()
        End If
        Me.Close()
    End Sub

    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        Module2.OrderOpenedBy = Module2.CurrentUserRole  ' "Manager" or "Cashier"
        Dim frm As New frmCustomerOrder()
        frm.Show()
        Me.Hide()
    End Sub


    ' ── deleting a line item restores ingredient stock via recipe ───────────
    Private Sub btnDeleteItem_Click(sender As Object, e As EventArgs) Handles btnDeleteItem.Click
        If editingDetailID = 0 Then
            ShowMessage("Please select a line item first.", True)
            Return
        End If

        Dim connCheck = DBConnection.GetConnection()
        connCheck.Open()
        Dim cmdCheck As New MySqlCommand("SELECT Status FROM transactions WHERE TransactionID = @tid", connCheck)
        cmdCheck.Parameters.AddWithValue("@tid", selectedTransactionID)
        Dim status = cmdCheck.ExecuteScalar().ToString()
        connCheck.Close()
        If status <> "Pending" Then
            ShowMessage("Only Pending orders can have items removed. Completed orders can't be modified here.", True)
            Return
        End If

        If dgvTransactionDetails.Rows.Count <= 1 Then
            ShowMessage("Cannot delete the only item in a transaction. Delete the whole transaction instead.", True)
            Return
        End If

        If MessageBox.Show("Delete this line item? Stock will be restored.",
                    "Confirm Delete", MessageBoxButtons.YesNo) = DialogResult.No Then Return

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim trans = conn.BeginTransaction()
        Try
            RestoreStockForProduct(originalDetailProductID, originalDetailQty, conn, trans)
            Dim cmdDelete As New MySqlCommand(
        "DELETE FROM transactiondetails WHERE DetailID = @did", conn, trans)
            cmdDelete.Parameters.AddWithValue("@did", editingDetailID)
            cmdDelete.ExecuteNonQuery()
            trans.Commit()
            ShowMessage("Line item deleted. Stock restored.")
        Catch ex As Exception
            trans.Rollback()
            ShowMessage("Delete failed: " & ex.Message, True)
            conn.Close()
            Return
        End Try
        conn.Close()

        Dim keepTransactionID = selectedTransactionID
        editingDetailID = 0
        originalDetailProductID = 0
        originalDetailQty = 0
        cboEditProduct.SelectedIndex = -1
        cboEditProduct.Enabled = False
        numEditQty.Value = numEditQty.Minimum
        numEditQty.Enabled = False
        lblStock.Text = ""
        LoadEditProductComboBox()
        LoadTransactions()
        LoadTransactionDetails(keepTransactionID)
        selectedTransactionID = keepTransactionID
    End Sub

    Private Sub dgvTransactions_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTransactions.CellContentClick
    End Sub

    Private Sub lblTotal_Click(sender As Object, e As EventArgs) Handles lblTotal.Click
    End Sub

    Private Sub lblEditTotal_Click(sender As Object, e As EventArgs) Handles lblEditTotal.Click
    End Sub

    Private Sub btnConfirmPayment_Click(sender As Object, e As EventArgs) Handles btnConfirmPayment.Click

        If selectedTransactionID = 0 Then
            ShowMessage("Please select a transaction.", True)
            Return
        End If

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmdCheck As New MySqlCommand("SELECT Status FROM transactions WHERE TransactionID = @tid", conn)
        cmdCheck.Parameters.AddWithValue("@tid", selectedTransactionID)
        Dim status = cmdCheck.ExecuteScalar().ToString()
        If status <> "Pending" Then
            ShowMessage("Only Pending orders can be confirmed for payment.", True)
            conn.Close()
            Return
        End If

        Dim cmdTotal As New MySqlCommand(
        "SELECT COALESCE(SUM(Quantity * UnitPrice), 0) FROM transactiondetails WHERE TransactionID = @tid", conn)
        cmdTotal.Parameters.AddWithValue("@tid", selectedTransactionID)
        Dim total = Convert.ToDecimal(cmdTotal.ExecuteScalar())
        conn.Close()

        Dim paidInput = InputBox($"Order #{selectedTransactionID}" & Environment.NewLine &
                              $"Total: ₱{total.ToString("0.00")}" & Environment.NewLine &
                              "Enter amount paid:", "Confirm Payment")
        If String.IsNullOrWhiteSpace(paidInput) Then Return
        Dim amountPaid As Decimal
        If Not Decimal.TryParse(paidInput, amountPaid) OrElse amountPaid < total Then
            ShowMessage("Amount paid must be equal to or greater than total.", True)
            Return
        End If
        Dim change = amountPaid - total

        Dim connUpdate = DBConnection.GetConnection()
        connUpdate.Open()
        Dim cmdUpdate As New MySqlCommand(
"UPDATE transactions SET Status = 'Completed', AmountPaid = @paid, ConfirmedByEmployeeID = @eid WHERE TransactionID = @tid", connUpdate)
        cmdUpdate.Parameters.AddWithValue("@paid", amountPaid)
        cmdUpdate.Parameters.AddWithValue("@eid", Module2.CurrentEmployeeID)
        cmdUpdate.Parameters.AddWithValue("@tid", selectedTransactionID)
        cmdUpdate.ExecuteNonQuery()
        connUpdate.Close()

        MessageBox.Show($"Payment confirmed! Change: ₱{change.ToString("0.00")}")
        LoadTransactions()

        ' Print receipt now that payment is actually confirmed
        PrintReceiptFor(selectedTransactionID, amountPaid, change)
    End Sub

    ' Extracted from btnReprint_Click so both Confirm Payment and Reprint can call it.
    Private Sub PrintReceiptFor(transactionID As Integer, amountPaid As Decimal, change As Decimal)
        Dim conn = DBConnection.GetConnection()
        conn.Open()

        Dim cmdInfo As New MySqlCommand(
"SELECT t.TransactionDate,
        CONCAT(COALESCE(c.FirstName,'Walk-in'), ' ', COALESCE(c.LastName,'')) AS CustomerName,
        CONCAT(emp.FirstName, ' ', emp.LastName) AS ConfirmedByName
 FROM transactions t
 LEFT JOIN customers c ON t.CustomerID = c.CustomerID
 LEFT JOIN employees emp ON t.ConfirmedByEmployeeID = emp.EmployeeID
 WHERE t.TransactionID = @tid", conn)
        cmdInfo.Parameters.AddWithValue("@tid", transactionID)
        Dim reader = cmdInfo.ExecuteReader()
        Dim txnDate As DateTime = DateTime.Now
        Dim customerName As String = "Walk-in"
        Dim confirmedByName As String = "N/A"
        If reader.Read() Then
            txnDate = Convert.ToDateTime(reader("TransactionDate"))
            customerName = reader("CustomerName").ToString()
            If Not IsDBNull(reader("ConfirmedByName")) Then
                confirmedByName = reader("ConfirmedByName").ToString()
            End If
        End If
        reader.Close()

        Dim cmdItems As New MySqlCommand(
        "SELECT p.ProductName, td.Quantity, td.UnitPrice, (td.Quantity * td.UnitPrice) AS Subtotal
         FROM transactiondetails td
         JOIN products p ON td.ProductID = p.ProductID
         WHERE td.TransactionID = @tid", conn)
        cmdItems.Parameters.AddWithValue("@tid", transactionID)
        Dim adapter As New MySqlDataAdapter(cmdItems)
        Dim dsReceipt As New DataSet
        adapter.Fill(dsReceipt, "dtReceiptItems")
        conn.Close()

        Dim total As Decimal = 0
        For Each row As DataRow In dsReceipt.Tables("dtReceiptItems").Rows
            total += Convert.ToDecimal(row("Subtotal"))
        Next

        Dim report As New rptReceipt
        report.SetDataSource(dsReceipt.Tables("dtReceiptItems"))
        report.SetParameterValue("TransactionID", transactionID)
        report.SetParameterValue("CustomerName", customerName)
        report.SetParameterValue("TransactionDate", txnDate)
        report.SetParameterValue("Total", total)
        report.SetParameterValue("AmountPaid", amountPaid)
        report.SetParameterValue("ChangeDue", change)
        report.SetParameterValue("ConfirmedBy", confirmedByName)

        Dim frm As New frmReceiptViewer
        frm.CrystalReportViewer1.ReportSource = report
        frm.Show()
    End Sub

End Class