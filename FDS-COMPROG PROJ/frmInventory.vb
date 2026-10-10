Imports MySql.Data.MySqlClient
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.IO



' =========================================================
' DESIGNER CONTROLS SUMMARY:
'
' Tab: tabIngredients
'   dgvIngredients (DataGridView)
'   txtIngredientName (TextBox), cboIngredientUnit (ComboBox, DropDownList style)
'   txtIngredientSearch (TextBox) - live search as you type
'   btnClearIngredientSearch (Button) - clears search
'   lblIngredientCount (Label) - shows result count
'   btnAddIngredient, btnUpdateIngredient, btnDeleteIngredient, btnClearIngredient (Buttons)
'
' Tab: tabRecipe
'   cboRecipeProduct, dgvRecipe, cboRecipeIngredient, txtRecipeQty
'   btnRecipeAddLine, btnRecipeRemoveLine, btnRecipeSave
'
' Products tab:
'   txtProductSearch (TextBox) - live search via TextChanged
'   btnClearProductSearch (Button) - clears search
'   lblProductCount (Label)
'   NOTE: btnProductSearch is no longer used (search is live) - remove it from the designer.
'
' "Active Batches" tab -> ingredient batches (cboProduct/cboFilterProduct pick INGREDIENTS)
'   cboPackSize (ComboBox) - hardcoded restock pack sizes based on the selected
'        ingredient's Unit (g -> 500g/1kg/5kg/25kg sack, ml -> 500ml/1L/5L/20L,
'        pcs -> 1 pc/Box of 12/Box of 24/Box of 50). Auto-repopulates whenever
'        cboProduct's selection changes.
'   txtQuantity means "how many of that pack size" (e.g. 3 boxes, 2 sacks),
'        NOT a raw base-unit count.
'   txtCostPerUnit means "cost per ONE pack" (e.g. cost of one box, one kg),
'        NOT cost per base unit.
'   cboSupplier (ComboBox) - who this restock is from. Required to restock.
'
'   NEW - inline batch adjustment controls (no dialog), sit next to
'   Update/Delete on this same tab:
'     txtBatchQty        - editable RemainingQty for the clicked batch
'     txtBatchCost       - editable CostPerUnit for the clicked batch
'     dtpBatchExpiry     - editable ExpiryDate for the clicked batch
'     cboAdjustReason    - REQUIRED for both Update and Delete, always
'                          (Wrong Entry / Spoilage / Breakage / Theft / Miscount / Other)
'     txtAdjustNotes     - optional free-text notes
'     btnUpdateBatch     - applies edits to ingredientbatches + logs adjustment
'     btnDeleteBatch     - deletes the batch + logs adjustment
'
'   dgvBatches now also carries a hidden SupplierName column (LEFT JOIN
'   supplier_deliveries -> suppliers) and a hidden IngredientID column
'   (needed so adjustments can be logged against the right ingredient).
'
' Tab: tabSuppliers (new TabPage)
'   dgvSuppliers (DataGridView)
'   txtSupplierName, txtSupplierContactName, txtSupplierContact, txtSupplierAddress (TextBoxes)
'   btnAddSupplier, btnUpdateSupplier, btnDeleteSupplier, btnClearSupplier (Buttons)
'
' NOTE ON total_cost: supplier_deliveries.total_cost was a derived column
' (quantity_base * cost_per_base_unit) and has been DROPPED - it's computed
' on the fly wherever needed instead, same as ingredientbatches.TotalCost
' already was in dgvBatches / dgvExpired.
' =========================================================

Public Class frmInventory

    Dim isLoading As Boolean = False


    Private currentImageBitmap As Bitmap = Nothing
    Private imageWasCleared As Boolean = False


    ' Represents one hardcoded restock pack-size choice, e.g. "Box of 24" = 24 pcs.
    Private Class PackSizeOption
        Public Property Label As String
        Public Property BaseQty As Decimal
        Public Sub New(labelText As String, baseQty As Decimal)
            Me.Label = labelText
            Me.BaseQty = baseQty
        End Sub
    End Class

    Private Sub frmInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductsTab()
        LoadIngredientsTab()
        LoadRecipeTab()
        LoadActiveBatchesTab()
        LoadExpiredTab()
        LoadFilterIngredients()
        LoadProductCategories()
        LoadIngredientUnits()
        LoadSuppliersTab()
        LoadSupplierDropdown()
        LoadAdjustReasons()

        ShowPlaceholderImage()
        dtpFrom.Value = DateTime.Today.AddMonths(-1)
        dtpTo.Value = DateTime.Today
        dtpExpiry.MinDate = DateTime.Today.AddDays(1)

        dgvBatches.DefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvBatches.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvExpired.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvExpired.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvIngredients.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvIngredients.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvRecipe.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvRecipe.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvSuppliers.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvSuppliers.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)



    End Sub

    Private Sub LoadIngredientUnits()
        cboIngredientUnit.Items.Clear()
        cboIngredientUnit.Items.AddRange({"g", "ml", "pcs"})
        cboIngredientUnit.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' Reasons available for both Update and Delete adjustments on a batch.
    Private Sub LoadAdjustReasons()
        cboAdjustReason.Items.Clear()
        cboAdjustReason.Items.AddRange({"Wrong Entry", "Spoilage", "Breakage", "Theft", "Miscount", "Other"})
        cboAdjustReason.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' =========================================================
    ' Shared helper: compute a product's available stock from its
    ' recipe + current (non-expired) ingredient batches.
    ' =========================================================
    Public Shared Function GetProductAvailableStock(productID As Integer, conn As MySqlConnection,
                                                  Optional transaction As MySqlTransaction = Nothing) As Integer
        Dim cmd As New MySqlCommand(
        "SELECT pi.QtyRequired,
                COALESCE((SELECT SUM(RemainingQty) FROM ingredientbatches
                          WHERE IngredientID = pi.IngredientID AND ExpiryDate >= CURDATE()
                                AND IsVoided = 0), 0) AS AvailQty
         FROM productingredients pi
         WHERE pi.ProductID = @pid", conn, transaction)
        ' ... rest unchanged
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

    Private Sub LoadProductCategories()
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand("SELECT CategoryID, CategoryName FROM categories ORDER BY CategoryName", conn)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        cboProductCategory.DisplayMember = "CategoryName"
        cboProductCategory.ValueMember = "CategoryID"
        cboProductCategory.DataSource = dt
    End Sub


    ' =========================================================
    ' PRODUCTS TAB (name/category/price, stock is computed, live search)
    ' =========================================================



    Private Sub LoadProductsTab(Optional searchTerm As String = "")
        isLoading = True
        Dim conn = DBConnection.GetConnection()
        conn.Open()

        Dim query As String =
"SELECT p.ProductID, p.ProductName, c.CategoryName AS Category, p.Price, p.ImageFilename
 FROM products p
 INNER JOIN categories c ON p.CategoryID = c.CategoryID
 WHERE p.IsActive = 1"

        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            query &= " AND p.ProductName LIKE @search"
        End If

        query &= " ORDER BY c.CategoryName, p.ProductName"

        Dim cmd As New MySqlCommand(query, conn)
        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            cmd.Parameters.AddWithValue("@search", "%" & searchTerm.Trim() & "%")
        End If

        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        dt.Columns.Add("Stock", GetType(Integer))
        For Each row As DataRow In dt.Rows
            row("Stock") = GetProductAvailableStock(Convert.ToInt32(row("ProductID")), conn)
        Next
        conn.Close()

        dgvProducts.DataSource = dt
        dgvProducts.AllowUserToAddRows = False
        dgvProducts.ReadOnly = True
        dgvProducts.MultiSelect = True
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        dgvProducts.Columns("ProductID").Visible = False
        dgvProducts.Columns("ImageFilename").Visible = False
        dgvProducts.Columns("ProductName").DisplayIndex = 0
        dgvProducts.Columns("Category").DisplayIndex = 1
        dgvProducts.Columns("Price").DisplayIndex = 2
        dgvProducts.Columns("Stock").DisplayIndex = 3
        dgvProducts.Columns("Stock").HeaderText = "Producible Qty"
        dgvProducts.EnableHeadersVisualStyles = False
        dgvProducts.DefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvProducts.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)

        For Each row As DataGridViewRow In dgvProducts.Rows
            Dim stock = Convert.ToInt32(row.Cells("Stock").Value)
            If stock = 0 Then
                row.DefaultCellStyle.BackColor = Color.LightCoral
                row.DefaultCellStyle.ForeColor = Color.DarkRed
            ElseIf stock <= 10 Then
                row.DefaultCellStyle.BackColor = Color.LightYellow
            End If
        Next

        isLoading = False
        lblProductCount.Text = $"{dt.Rows.Count} product(s)"
    End Sub

    ' ── UPDATED: also loads the clicked product's photo preview, and resets any
    ' staged (unsaved) photo edits from whatever product was selected before.
    Private Sub dgvProducts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellClick
        If isLoading Then Return
        If e.RowIndex < 0 Then Return

        Dim row = dgvProducts.Rows(e.RowIndex)
        txtProductName.Text = row.Cells("ProductName").Value.ToString()
        txtProductPrice.Text = row.Cells("Price").Value.ToString()

        Dim categoryName = row.Cells("Category").Value.ToString()
        For i = 0 To cboProductCategory.Items.Count - 1
            Dim rowView = CType(cboProductCategory.Items(i), DataRowView)
            If rowView("CategoryName").ToString() = categoryName Then
                cboProductCategory.SelectedIndex = i
                Exit For
            End If
        Next

        ' Reset any unsaved photo staging, then load this product's actual photo from disk
        currentImageBitmap = Nothing
        imageWasCleared = False
        Dim fileNameValue = row.Cells("ImageFilename").Value
        LoadImageForProduct(If(fileNameValue Is DBNull.Value OrElse fileNameValue Is Nothing, Nothing, fileNameValue.ToString()))
    End Sub

    ' Loads the product's image straight from the ProductImages folder next to the .exe.
    Private Sub LoadImageForProduct(imageFilename As String)
        If pbProductPreview.Image IsNot Nothing Then
            pbProductPreview.Image.Dispose()
            pbProductPreview.Image = Nothing
        End If

        If String.IsNullOrWhiteSpace(imageFilename) Then
            ShowPlaceholderImage()
            Exit Sub
        End If

        Dim fullPath = Path.Combine(Application.StartupPath, "ProductImages", imageFilename)
        If File.Exists(fullPath) Then
            Dim bytes = File.ReadAllBytes(fullPath)
            Using ms As New MemoryStream(bytes)
                pbProductPreview.Image = Image.FromStream(ms)
            End Using
        Else
            ShowPlaceholderImage() ' filename set in DB but file missing/moved
        End If
    End Sub

    ' Shows a generic "no photo" placeholder instead of leaving the box blank.
    Private Sub ShowPlaceholderImage()
        Dim placeholderPath = Path.Combine(Application.StartupPath, "ProductImages", "placeholder.png")
        If File.Exists(placeholderPath) Then
            pbProductPreview.Image = Image.FromFile(placeholderPath)
        Else
            ' Fallback if even the placeholder file is missing: draw a simple gray box with text
            Dim bmp As New Bitmap(pbProductPreview.Width, pbProductPreview.Height)
            Using g = Graphics.FromImage(bmp)
                g.Clear(Color.Gainsboro)
                Using sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                    g.DrawString("No Photo", New Font("Segoe UI", 10, FontStyle.Bold), Brushes.Gray,
                             New RectangleF(0, 0, bmp.Width, bmp.Height), sf)
                End Using
            End Using
            pbProductPreview.Image = bmp
        End If
    End Sub
    ' ── Upload Photo ─────────────────────────────────────────
    Private Sub btnUploadPhoto_Click(sender As Object, e As EventArgs) Handles btnUploadPhoto.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            ofd.Title = "Select Product Photo"
            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    Using sourceImg As Image = Image.FromFile(ofd.FileName)
                        Dim fitted = ResizeImageToFitTransparent(sourceImg, 300, 300)
                        currentImageBitmap = fitted
                        imageWasCleared = False
                        If pbProductPreview.Image IsNot Nothing Then pbProductPreview.Image.Dispose()
                        pbProductPreview.Image = fitted
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading photo: " & ex.Message)
                End Try
            End If
        End Using
    End Sub

    Private Sub btnRemovePhoto_Click(sender As Object, e As EventArgs) Handles btnRemovePhoto.Click
        If pbProductPreview.Image IsNot Nothing Then
            pbProductPreview.Image.Dispose()
            pbProductPreview.Image = Nothing
        End If
        currentImageBitmap = Nothing
        imageWasCleared = True
        MessageBox.Show("Photo cleared. Click Add/Update to save this change.")
    End Sub

    ' Resizes/pads an image to exactly targetW x targetH, preserving aspect ratio and transparency.
    Private Function ResizeImageToFitTransparent(source As Image, targetW As Integer, targetH As Integer) As Bitmap
        Dim result As New Bitmap(targetW, targetH, PixelFormat.Format32bppArgb)
        Dim srcRatio As Double = source.Width / CDbl(source.Height)
        Dim targetRatio As Double = targetW / CDbl(targetH)
        Dim drawW As Integer, drawH As Integer
        If srcRatio > targetRatio Then
            drawW = targetW
            drawH = CInt(targetW / srcRatio)
        Else
            drawH = targetH
            drawW = CInt(targetH * srcRatio)
        End If
        Dim offsetX = (targetW - drawW) \ 2
        Dim offsetY = (targetH - drawH) \ 2
        Using g = Graphics.FromImage(result)
            g.CompositingMode = CompositingMode.SourceOver
            g.CompositingQuality = CompositingQuality.HighQuality
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.SmoothingMode = SmoothingMode.HighQuality
            g.Clear(Color.Transparent)
            g.DrawImage(source, New Rectangle(offsetX, offsetY, drawW, drawH))
        End Using
        Return result
    End Function

    ' Writes currentImageBitmap to ProductImages\{productId}.png, returns the filename.
    Private Function SaveStagedImageToDisk(productId As Integer) As String
        If currentImageBitmap Is Nothing Then Return Nothing
        Dim imagesFolder = Path.Combine(Application.StartupPath, "ProductImages")
        If Not Directory.Exists(imagesFolder) Then Directory.CreateDirectory(imagesFolder)
        Dim fileName = productId.ToString() & ".png"
        Dim destPath = Path.Combine(imagesFolder, fileName)
        currentImageBitmap.Save(destPath, ImageFormat.Png)
        Return fileName
    End Function

    Private Sub DeleteImageFile(imageFilename As String)
        If String.IsNullOrWhiteSpace(imageFilename) Then Exit Sub
        Dim fullPath = Path.Combine(Application.StartupPath, "ProductImages", imageFilename)
        Try
            If File.Exists(fullPath) Then File.Delete(fullPath)
        Catch
            ' non-fatal — an orphaned file isn't worth blocking the save over
        End Try
    End Sub

    ' ── UPDATED: btnAddProduct_Click now saves the staged photo (if any) after the
    ' insert, using the new auto-increment ProductID as the filename.
    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        If String.IsNullOrWhiteSpace(txtProductName.Text) Then
            MessageBox.Show("Please enter a product name.")
            txtProductName.Focus()
            Return
        End If
        If cboProductCategory.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a category.")
            Return
        End If
        If String.IsNullOrWhiteSpace(txtProductPrice.Text) Then
            MessageBox.Show("Please enter a price.")
            txtProductPrice.Focus()
            Return
        End If
        Dim price As Decimal
        If Not Decimal.TryParse(txtProductPrice.Text, price) OrElse price < 0 Then
            MessageBox.Show("Please enter a valid price.")
            txtProductPrice.Focus()
            Return
        End If

        Dim productName = txtProductName.Text.Trim()
        Dim categoryID = Convert.ToInt32(cboProductCategory.SelectedValue)

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
        "INSERT INTO products (ProductName, CategoryID, Price) VALUES (@name, @catid, @price)", conn)
        cmd.Parameters.AddWithValue("@name", productName)
        cmd.Parameters.AddWithValue("@catid", categoryID)
        cmd.Parameters.AddWithValue("@price", price)
        cmd.ExecuteNonQuery()
        Dim newProductId = CInt(cmd.LastInsertedId)

        If currentImageBitmap IsNot Nothing Then
            Dim savedFileName = SaveStagedImageToDisk(newProductId)
            Dim cmdImg As New MySqlCommand("UPDATE products SET ImageFilename = @fname WHERE ProductID = @id", conn)
            cmdImg.Parameters.AddWithValue("@fname", savedFileName)
            cmdImg.Parameters.AddWithValue("@id", newProductId)
            cmdImg.ExecuteNonQuery()
        End If
        conn.Close()

        ClearProductFields()
        LoadProductsTab(txtProductSearch.Text)
        LoadRecipeTab()
    End Sub

    ' ── UPDATED: btnUpdateProduct_Click now saves/replaces/clears the photo, mirroring
    ' the seafood frmProducts logic (new photo replaces old file; Remove Photo clears it).
    Private Sub btnUpdateProduct_Click(sender As Object, e As EventArgs) Handles btnUpdateProduct.Click
        If dgvProducts.CurrentRow Is Nothing Then
            MessageBox.Show("Please click a product row to update.")
            Return
        End If
        If String.IsNullOrWhiteSpace(txtProductName.Text) Then
            MessageBox.Show("Please enter a product name.")
            txtProductName.Focus()
            Return
        End If
        If cboProductCategory.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a category.")
            Return
        End If
        Dim price As Decimal
        If Not Decimal.TryParse(txtProductPrice.Text, price) OrElse price < 0 Then
            MessageBox.Show("Please enter a valid price.")
            txtProductPrice.Focus()
            Return
        End If

        Dim productID = Convert.ToInt32(dgvProducts.CurrentRow.Cells("ProductID").Value)
        Dim productName = txtProductName.Text.Trim()
        Dim categoryID = Convert.ToInt32(cboProductCategory.SelectedValue)

        Dim existingFileNameCell = dgvProducts.CurrentRow.Cells("ImageFilename").Value
        Dim existingFileName As String = If(existingFileNameCell Is DBNull.Value OrElse existingFileNameCell Is Nothing,
                                         Nothing, existingFileNameCell.ToString())

        Dim conn = DBConnection.GetConnection()
        conn.Open()

        Dim newFileName = existingFileName ' unchanged unless a photo was uploaded/removed
        If currentImageBitmap IsNot Nothing Then
            newFileName = SaveStagedImageToDisk(productID)
            If Not String.IsNullOrWhiteSpace(existingFileName) AndAlso
           Not existingFileName.Equals(newFileName, StringComparison.OrdinalIgnoreCase) Then
                DeleteImageFile(existingFileName)
            End If
        ElseIf imageWasCleared Then
            DeleteImageFile(existingFileName)
            newFileName = Nothing
        End If

        Dim cmd As New MySqlCommand(
    "UPDATE products SET ProductName = @name, CategoryID = @catid, Price = @price, ImageFilename = @fname
     WHERE ProductID = @pid", conn)
        cmd.Parameters.AddWithValue("@name", productName)
        cmd.Parameters.AddWithValue("@catid", categoryID)
        cmd.Parameters.AddWithValue("@price", price)
        cmd.Parameters.AddWithValue("@fname", If(newFileName Is Nothing, CObj(DBNull.Value), CObj(newFileName)))
        cmd.Parameters.AddWithValue("@pid", productID)
        cmd.ExecuteNonQuery()
        conn.Close()

        imageWasCleared = False
        ClearProductFields()
        LoadProductsTab(txtProductSearch.Text)
        LoadRecipeTab()
    End Sub

    ' ── UPDATED: clears the photo preview/staging too, not just text fields.
    Private Sub ClearProductFields()
        txtProductName.Clear()
        txtProductPrice.Clear()
        If cboProductCategory.Items.Count > 0 Then cboProductCategory.SelectedIndex = 0

        If pbProductPreview.Image IsNot Nothing Then
            pbProductPreview.Image.Dispose()
            pbProductPreview.Image = Nothing
        End If
        ShowPlaceholderImage()
        currentImageBitmap = Nothing
        imageWasCleared = False
    End Sub

    Private Sub txtProductSearch_TextChanged(sender As Object, e As EventArgs) Handles txtProductSearch.TextChanged
        LoadProductsTab(txtProductSearch.Text)
    End Sub

    Private Sub btnClearProductSearch_Click(sender As Object, e As EventArgs) Handles btnClearProductSearch.Click
        txtProductSearch.Clear()
    End Sub

    ' =========================================================
    ' INGREDIENTS TAB (CRUD for raw materials, with live search)
    ' =========================================================

    Private Sub LoadIngredientsTab(Optional searchTerm As String = "")
        isLoading = True
        Dim conn = DBConnection.GetConnection()
        conn.Open()

        Dim query As String =
    "SELECT i.IngredientID, i.IngredientName, i.Unit,
     COALESCE(SUM(CASE WHEN b.ExpiryDate >= CURDATE() AND b.IsVoided = 0 THEN b.RemainingQty ELSE 0 END), 0) AS Stock
     FROM ingredients i
     LEFT JOIN ingredientbatches b ON i.IngredientID = b.IngredientID
     WHERE 1=1"

        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            query &= " AND i.IngredientName LIKE @search"
        End If

        query &= " GROUP BY i.IngredientID, i.IngredientName, i.Unit
                   ORDER BY i.IngredientName"

        Dim cmd As New MySqlCommand(query, conn)
        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            cmd.Parameters.AddWithValue("@search", "%" & searchTerm.Trim() & "%")
        End If

        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        dt.Columns.Add("Selected", GetType(Boolean))
        For Each row As DataRow In dt.Rows
            row("Selected") = False
        Next
        conn.Close()

        dgvIngredients.DataSource = dt
        dgvIngredients.AllowUserToAddRows = False
        dgvIngredients.Columns("IngredientID").Visible = False
        dgvIngredients.Columns("Selected").ReadOnly = False
        dgvIngredients.Columns("IngredientName").ReadOnly = True
        dgvIngredients.Columns("Unit").ReadOnly = True
        dgvIngredients.Columns("Stock").ReadOnly = True

        dgvIngredients.Columns("Selected").DisplayIndex = 0
        dgvIngredients.Columns("IngredientName").DisplayIndex = 1
        dgvIngredients.Columns("Unit").DisplayIndex = 2
        dgvIngredients.Columns("Stock").DisplayIndex = 3

        isLoading = False
        lblIngredientCount.Text = $"{dt.Rows.Count} ingredient(s)"
    End Sub

    Private Sub dgvIngredients_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIngredients.CellClick
        If isLoading Then Return
        If e.RowIndex < 0 Then Return
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        Dim colName = dgvIngredients.Columns(e.ColumnIndex).Name
        If colName = "Selected" Then Return

        Dim row = dgvIngredients.Rows(e.RowIndex)
        txtIngredientName.Text = row.Cells("IngredientName").Value.ToString()
        Dim unit = row.Cells("Unit").Value.ToString()
        Dim idx = cboIngredientUnit.Items.IndexOf(unit)
        cboIngredientUnit.SelectedIndex = idx ' -1 if not found, which just clears selection
    End Sub

    Private Function TryReadIngredientFields(ByRef name As String, ByRef unit As String) As Boolean
        If String.IsNullOrWhiteSpace(txtIngredientName.Text) Then
            MessageBox.Show("Please enter an ingredient name.")
            txtIngredientName.Focus()
            Return False
        End If
        If cboIngredientUnit.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a unit (g, ml, or pcs).")
            Return False
        End If
        name = txtIngredientName.Text.Trim()
        unit = cboIngredientUnit.SelectedItem.ToString()
        Return True
    End Function

    Private Sub btnAddIngredient_Click(sender As Object, e As EventArgs) Handles btnAddIngredient.Click
        Dim name As String = "", unit As String = ""
        If Not TryReadIngredientFields(name, unit) Then Return

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "INSERT INTO ingredients (IngredientName, Unit) VALUES (@name, @unit)", conn)
        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@unit", unit)
        cmd.ExecuteNonQuery()
        conn.Close()

        ClearIngredientFields()
        LoadIngredientsTab(txtIngredientSearch.Text)
        LoadFilterIngredients()
        LoadRecipeTab()
    End Sub

    Private Sub btnUpdateIngredient_Click(sender As Object, e As EventArgs) Handles btnUpdateIngredient.Click
        Dim selectedRows As New List(Of DataGridViewRow)
        For Each row As DataGridViewRow In dgvIngredients.Rows
            If row.Cells("Selected").Value IsNot Nothing AndAlso
               Convert.ToBoolean(row.Cells("Selected").Value) = True Then
                selectedRows.Add(row)
            End If
        Next
        If selectedRows.Count <> 1 Then
            MessageBox.Show("Please check exactly one ingredient to update.")
            Return
        End If

        Dim name As String = "", unit As String = ""
        If Not TryReadIngredientFields(name, unit) Then Return

        Dim ingredientID = Convert.ToInt32(selectedRows(0).Cells("IngredientID").Value)
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "UPDATE ingredients SET IngredientName = @name, Unit = @unit WHERE IngredientID = @iid", conn)
        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@unit", unit)
        cmd.Parameters.AddWithValue("@iid", ingredientID)
        cmd.ExecuteNonQuery()
        conn.Close()

        ClearIngredientFields()
        LoadIngredientsTab(txtIngredientSearch.Text)
        LoadFilterIngredients()
        LoadRecipeTab()
    End Sub

    Private Sub btnDeleteIngredient_Click(sender As Object, e As EventArgs) Handles btnDeleteIngredient.Click

        Dim toDelete As New List(Of Integer)
        For Each row As DataGridViewRow In dgvIngredients.Rows
            If row.Cells("Selected").Value IsNot Nothing AndAlso
       Convert.ToBoolean(row.Cells("Selected").Value) = True Then
                toDelete.Add(Convert.ToInt32(row.Cells("IngredientID").Value))
            End If
        Next
        If toDelete.Count = 0 Then
            MessageBox.Show("Please check at least one ingredient to delete.")
            Return
        End If
        If MessageBox.Show($"Delete {toDelete.Count} ingredient(s)? This also deletes their batches, delivery history, and removes them from any recipes.",
                   "Confirm Delete", MessageBoxButtons.YesNo) = DialogResult.No Then Return

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim tx = conn.BeginTransaction()
        Try
            For Each iid In toDelete
                Dim cmdDeliv As New MySqlCommand("DELETE FROM supplier_deliveries WHERE ingredient_id = @iid", conn, tx)
                cmdDeliv.Parameters.AddWithValue("@iid", iid)
                cmdDeliv.ExecuteNonQuery()

                Dim cmdRecipe As New MySqlCommand("DELETE FROM productingredients WHERE IngredientID = @iid", conn, tx)
                cmdRecipe.Parameters.AddWithValue("@iid", iid)
                cmdRecipe.ExecuteNonQuery()

                Dim cmdBatch As New MySqlCommand("DELETE FROM ingredientbatches WHERE IngredientID = @iid", conn, tx)
                cmdBatch.Parameters.AddWithValue("@iid", iid)
                cmdBatch.ExecuteNonQuery()

                Dim cmd As New MySqlCommand("DELETE FROM ingredients WHERE IngredientID = @iid", conn, tx)
                cmd.Parameters.AddWithValue("@iid", iid)
                cmd.ExecuteNonQuery()
            Next
            tx.Commit()
            MessageBox.Show("Deleted successfully.")
        Catch ex As Exception
            tx.Rollback()
            MessageBox.Show("Delete failed: " & ex.Message)
        End Try
        conn.Close()

        ClearIngredientFields()
        LoadIngredientsTab(txtIngredientSearch.Text)
        LoadActiveBatchesTab()
        LoadExpiredTab()
        LoadFilterIngredients()
        LoadRecipeTab()
    End Sub
    Private Sub btnClearIngredient_Click(sender As Object, e As EventArgs) Handles btnClearIngredient.Click
        ClearIngredientFields()
    End Sub

    Private Sub ClearIngredientFields()
        txtIngredientName.Clear()
        cboIngredientUnit.SelectedIndex = -1
    End Sub

    ' ── Ingredient search: LIVE (TextChanged) + Clear button ────────────
    Private Sub txtIngredientSearch_TextChanged(sender As Object, e As EventArgs) Handles txtIngredientSearch.TextChanged
        LoadIngredientsTab(txtIngredientSearch.Text)
    End Sub

    Private Sub btnClearIngredientSearch_Click(sender As Object, e As EventArgs) Handles btnClearIngredientSearch.Click
        txtIngredientSearch.Clear()
        ' TextChanged fires automatically and reloads with no filter
    End Sub

    ' Dropdown of ALL products (for the products grid, no change needed there),
    ' plus dropdown of INGREDIENTS used for restocking + the filter combo.
    Private Sub LoadFilterIngredients()
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand("SELECT IngredientID, IngredientName FROM ingredients ORDER BY IngredientName", conn)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()
        Dim allRow = dt.NewRow()
        allRow("IngredientID") = 0
        allRow("IngredientName") = "All Ingredients"
        dt.Rows.InsertAt(allRow, 0)
        cboFilterProduct.DisplayMember = "IngredientName"
        cboFilterProduct.ValueMember = "IngredientID"
        cboFilterProduct.DataSource = dt
        cboFilterProduct.SelectedIndex = 0

        Dim conn2 = DBConnection.GetConnection()
        conn2.Open()
        Dim cmd2 As New MySqlCommand(
        "SELECT i.IngredientID, i.IngredientName, i.Unit,
         COALESCE(SUM(CASE WHEN b.ExpiryDate >= CURDATE() AND b.IsVoided = 0 THEN b.RemainingQty ELSE 0 END), 0) AS Stock
         FROM ingredients i
         LEFT JOIN ingredientbatches b ON i.IngredientID = b.IngredientID
         GROUP BY i.IngredientID, i.IngredientName, i.Unit
         ORDER BY i.IngredientName", conn2)
        Dim adapter2 As New MySqlDataAdapter(cmd2)
        Dim dt2 As New DataTable
        adapter2.Fill(dt2)
        conn2.Close()
        cboProduct.DisplayMember = "IngredientName"
        cboProduct.ValueMember = "IngredientID"
        cboProduct.DataSource = dt2
    End Sub
    ' =========================================================
    ' RECIPE TAB (bill of materials per product)
    ' =========================================================

    Dim selectedRecipeIngredientID As Integer = 0

    Private Sub dgvRecipe_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRecipe.CellClick
        If e.RowIndex < 0 Then Return

        Dim row = dgvRecipe.Rows(e.RowIndex)
        selectedRecipeIngredientID = Convert.ToInt32(row.Cells("IngredientID").Value)

        cboRecipeIngredient.SelectedValue = selectedRecipeIngredientID
        txtRecipeQty.Text = row.Cells("QtyRequired").Value.ToString()
    End Sub

    Private Sub LoadRecipeTab()

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand("SELECT ProductID, ProductName FROM products WHERE IsActive = 1 ORDER BY ProductName", conn)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)


        Dim cmdIng As New MySqlCommand("SELECT IngredientID, IngredientName, Unit FROM ingredients ORDER BY IngredientName", conn)
        Dim adapterIng As New MySqlDataAdapter(cmdIng)
        Dim dtIng As New DataTable
        adapterIng.Fill(dtIng)
        conn.Close()

        cboRecipeProduct.DisplayMember = "ProductName"
        cboRecipeProduct.ValueMember = "ProductID"
        cboRecipeProduct.DataSource = dt

        cboRecipeIngredient.DisplayMember = "IngredientName"
        cboRecipeIngredient.ValueMember = "IngredientID"
        cboRecipeIngredient.DataSource = dtIng

        If dt.Rows.Count > 0 Then LoadRecipeLines(Convert.ToInt32(dt.Rows(0)("ProductID")))
    End Sub

    Private Sub cboRecipeProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRecipeProduct.SelectedIndexChanged
        If cboRecipeProduct.SelectedValue Is Nothing Then Return
        LoadRecipeLines(Convert.ToInt32(cboRecipeProduct.SelectedValue))
    End Sub

    Private Sub LoadRecipeLines(productID As Integer)
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "SELECT pi.IngredientID, i.IngredientName, i.Unit, pi.QtyRequired
             FROM productingredients pi
             JOIN ingredients i ON pi.IngredientID = i.IngredientID
             WHERE pi.ProductID = @pid
             ORDER BY i.IngredientName", conn)
        cmd.Parameters.AddWithValue("@pid", productID)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        dgvRecipe.DataSource = dt
        dgvRecipe.AllowUserToAddRows = False
        dgvRecipe.ReadOnly = True
        If dgvRecipe.Columns.Contains("IngredientID") Then dgvRecipe.Columns("IngredientID").Visible = False
    End Sub

    Private Sub btnRecipeAddLine_Click(sender As Object, e As EventArgs) Handles btnRecipeAddLine.Click
        If cboRecipeProduct.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a product first.")
            Return
        End If
        If cboRecipeIngredient.SelectedValue Is Nothing Then
            MessageBox.Show("Please select an ingredient.")
            Return
        End If
        Dim qty As Decimal
        If Not Decimal.TryParse(txtRecipeQty.Text, qty) OrElse qty <= 0 Then
            MessageBox.Show("Please enter a valid quantity required (> 0).")
            txtRecipeQty.Focus()
            Return
        End If

        Dim productID = Convert.ToInt32(cboRecipeProduct.SelectedValue)
        Dim ingredientID = Convert.ToInt32(cboRecipeIngredient.SelectedValue)

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "INSERT INTO productingredients (ProductID, IngredientID, QtyRequired)
             VALUES (@pid, @iid, @qty)
             ON DUPLICATE KEY UPDATE QtyRequired = @qty", conn)
        cmd.Parameters.AddWithValue("@pid", productID)
        cmd.Parameters.AddWithValue("@iid", ingredientID)
        cmd.Parameters.AddWithValue("@qty", qty)
        cmd.ExecuteNonQuery()
        conn.Close()

        txtRecipeQty.Clear()
        LoadRecipeLines(productID)
        LoadProductsTab(txtProductSearch.Text)
    End Sub

    Private Sub btnRecipeRemoveLine_Click(sender As Object, e As EventArgs) Handles btnRecipeRemoveLine.Click
        If dgvRecipe.CurrentRow Is Nothing Then
            MessageBox.Show("Please click a recipe line to remove.")
            Return
        End If
        If cboRecipeProduct.SelectedValue Is Nothing Then Return

        Dim productID = Convert.ToInt32(cboRecipeProduct.SelectedValue)
        Dim ingredientID = Convert.ToInt32(dgvRecipe.CurrentRow.Cells("IngredientID").Value)

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "DELETE FROM productingredients WHERE ProductID = @pid AND IngredientID = @iid", conn)
        cmd.Parameters.AddWithValue("@pid", productID)
        cmd.Parameters.AddWithValue("@iid", ingredientID)
        cmd.ExecuteNonQuery()
        conn.Close()

        LoadRecipeLines(productID)
        LoadProductsTab(txtProductSearch.Text)
    End Sub

    Private Sub btnUpdateRecipe_Click(sender As Object, e As EventArgs) Handles btnUpdateRecipe.Click
        If cboRecipeProduct.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a product first.")
            Return
        End If
        If selectedRecipeIngredientID = 0 Then
            MessageBox.Show("Please click a recipe line to update.")
            Return
        End If

        Dim qty As Decimal
        If Not Decimal.TryParse(txtRecipeQty.Text, qty) OrElse qty <= 0 Then
            MessageBox.Show("Please enter a valid quantity required (> 0).")
            txtRecipeQty.Focus()
            Return
        End If

        Dim productID = Convert.ToInt32(cboRecipeProduct.SelectedValue)

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
        "UPDATE productingredients SET QtyRequired = @qty
         WHERE ProductID = @pid AND IngredientID = @iid", conn)
        cmd.Parameters.AddWithValue("@qty", qty)
        cmd.Parameters.AddWithValue("@pid", productID)
        cmd.Parameters.AddWithValue("@iid", selectedRecipeIngredientID)
        cmd.ExecuteNonQuery()
        conn.Close()

        txtRecipeQty.Clear()
        selectedRecipeIngredientID = 0
        LoadRecipeLines(productID)
        LoadProductsTab(txtProductSearch.Text)
        MessageBox.Show("Recipe line updated.")
    End Sub

    ' =========================================================
    ' SUPPLIERS TAB (CRUD)
    ' =========================================================

    Private Sub LoadSuppliersTab()
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
        "SELECT supplier_id, supplier_name, contact_name, contact, address
         FROM suppliers ORDER BY supplier_name", conn)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        dgvSuppliers.DataSource = dt

        dgvSuppliers.Columns("supplier_name").HeaderText = "Supplier Name"
        dgvSuppliers.Columns("contact_name").HeaderText = "Contact Person"
        dgvSuppliers.Columns("contact").HeaderText = "Contact No."
        dgvSuppliers.Columns("address").HeaderText = "Address"

        dgvSuppliers.AllowUserToAddRows = False
        dgvSuppliers.ReadOnly = True
        dgvSuppliers.MultiSelect = True
        dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSuppliers.Columns("supplier_id").Visible = False
    End Sub


    Private Sub dgvSuppliers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSuppliers.CellClick
        If e.RowIndex < 0 Then Return
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        Dim colName = dgvSuppliers.Columns(e.ColumnIndex).Name
        If colName = "Selected" Then Return

        Dim row = dgvSuppliers.Rows(e.RowIndex)
        txtSupplierName.Text = row.Cells("supplier_name").Value.ToString()
        txtSupplierContactName.Text = row.Cells("contact_name").Value.ToString()
        txtSupplierContact.Text = row.Cells("contact").Value.ToString()
        txtSupplierAddress.Text = row.Cells("address").Value.ToString()
    End Sub

    Private Sub btnAddSupplier_Click(sender As Object, e As EventArgs) Handles btnAddSupplier.Click
        If String.IsNullOrWhiteSpace(txtSupplierName.Text) Then
            MessageBox.Show("Please enter a supplier name.")
            txtSupplierName.Focus()
            Return
        End If

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "INSERT INTO suppliers (supplier_name, contact_name, contact, address)
             VALUES (@name, @cname, @contact, @addr)", conn)
        cmd.Parameters.AddWithValue("@name", txtSupplierName.Text.Trim())
        cmd.Parameters.AddWithValue("@cname", If(String.IsNullOrWhiteSpace(txtSupplierContactName.Text), DBNull.Value, txtSupplierContactName.Text.Trim()))
        cmd.Parameters.AddWithValue("@contact", If(String.IsNullOrWhiteSpace(txtSupplierContact.Text), DBNull.Value, txtSupplierContact.Text.Trim()))
        cmd.Parameters.AddWithValue("@addr", If(String.IsNullOrWhiteSpace(txtSupplierAddress.Text), DBNull.Value, txtSupplierAddress.Text.Trim()))
        cmd.ExecuteNonQuery()
        conn.Close()

        ClearSupplierFields()
        LoadSuppliersTab()
        LoadSupplierDropdown()
    End Sub

    Private Sub btnUpdateSupplier_Click(sender As Object, e As EventArgs) Handles btnUpdateSupplier.Click
        If dgvSuppliers.CurrentRow Is Nothing Then
            MessageBox.Show("Please click a supplier row to update.")
            Return
        End If
        If String.IsNullOrWhiteSpace(txtSupplierName.Text) Then
            MessageBox.Show("Please enter a supplier name.")
            txtSupplierName.Focus()
            Return
        End If

        Dim supplierID = Convert.ToInt32(dgvSuppliers.CurrentRow.Cells("supplier_id").Value)
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
        "UPDATE suppliers SET supplier_name = @name, contact_name = @cname,
                               contact = @contact, address = @addr
         WHERE supplier_id = @sid", conn)
        cmd.Parameters.AddWithValue("@name", txtSupplierName.Text.Trim())
        cmd.Parameters.AddWithValue("@cname", If(String.IsNullOrWhiteSpace(txtSupplierContactName.Text), DBNull.Value, txtSupplierContactName.Text.Trim()))
        cmd.Parameters.AddWithValue("@contact", If(String.IsNullOrWhiteSpace(txtSupplierContact.Text), DBNull.Value, txtSupplierContact.Text.Trim()))
        cmd.Parameters.AddWithValue("@addr", If(String.IsNullOrWhiteSpace(txtSupplierAddress.Text), DBNull.Value, txtSupplierAddress.Text.Trim()))
        cmd.Parameters.AddWithValue("@sid", supplierID)
        cmd.ExecuteNonQuery()
        conn.Close()

        ClearSupplierFields()
        LoadSuppliersTab()
        LoadSupplierDropdown()
    End Sub

    Private Sub btnDeleteSupplier_Click(sender As Object, e As EventArgs) Handles btnDeleteSupplier.Click
        If dgvSuppliers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select at least one supplier to delete (click a row, or Ctrl/Shift+click for multiple).")
            Return
        End If

        Dim toDelete As New List(Of Integer)
        For Each row As DataGridViewRow In dgvSuppliers.SelectedRows
            toDelete.Add(Convert.ToInt32(row.Cells("supplier_id").Value))
        Next

        If MessageBox.Show($"Delete {toDelete.Count} supplier(s)? Their past delivery history will remain but won't be deletable independently.",
                       "Confirm Delete", MessageBoxButtons.YesNo) = DialogResult.No Then Return

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Try
            For Each sid In toDelete
                Dim cmd As New MySqlCommand("DELETE FROM suppliers WHERE supplier_id = @sid", conn)
                cmd.Parameters.AddWithValue("@sid", sid)
                cmd.ExecuteNonQuery()
            Next
            MessageBox.Show("Deleted successfully.")
        Catch ex As Exception
            MessageBox.Show("Delete failed - this supplier likely has delivery history on record: " & ex.Message)
        End Try
        conn.Close()

        ClearSupplierFields()
        LoadSuppliersTab()
        LoadSupplierDropdown()
    End Sub
    Private Sub btnClearSupplier_Click(sender As Object, e As EventArgs) Handles btnClearSupplier.Click
        ClearSupplierFields()
    End Sub

    Private Sub ClearSupplierFields()
        txtSupplierName.Clear()
        txtSupplierContactName.Clear()
        txtSupplierContact.Clear()
        txtSupplierAddress.Clear()
    End Sub

    ' Supplier dropdown used on the Restock screen.
    Private Sub LoadSupplierDropdown()
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand("SELECT supplier_id, supplier_name FROM suppliers ORDER BY supplier_name", conn)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        cboSupplier.DisplayMember = "supplier_name"
        cboSupplier.ValueMember = "supplier_id"
        cboSupplier.DataSource = dt
        cboSupplier.SelectedIndex = -1
    End Sub

    ' =========================================================
    ' INGREDIENT BATCHES TAB (restock ingredients + inline adjustments)
    ' =========================================================

    Private Sub LoadActiveBatchesTab(Optional ingredientID As Integer = 0,
                                     Optional dateFrom As DateTime = Nothing,
                                     Optional dateTo As DateTime = Nothing)
        isLoading = True
        ' total_cost is NOT stored anywhere here - it's always computed on the
        ' fly from Quantity * CostPerUnit, same as before. SupplierName is
        ' pulled in via LEFT JOIN so a batch with no recorded delivery still shows.
        Dim query As String =
    "SELECT b.BatchID, b.IngredientID, i.IngredientName, i.Unit, b.Quantity, b.RemainingQty,
            b.CostPerUnit, (b.Quantity * b.CostPerUnit) AS TotalCost,
            b.RestockDate, b.ExpiryDate,
            s.supplier_name AS SupplierName
     FROM ingredientbatches b
     INNER JOIN ingredients i ON b.IngredientID = i.IngredientID
     LEFT JOIN supplier_deliveries sd ON b.BatchID = sd.batch_id
     LEFT JOIN suppliers s ON sd.supplier_id = s.supplier_id
     WHERE b.ExpiryDate >= CURDATE() AND b.RemainingQty > 0 AND b.IsVoided = 0"
        If ingredientID > 0 Then query &= " AND b.IngredientID = @iid"
        If dateFrom <> Nothing Then query &= " AND b.RestockDate >= @from"
        If dateTo <> Nothing Then query &= " AND b.RestockDate <= @to"
        query &= " ORDER BY b.ExpiryDate ASC"

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(query, conn)
        If ingredientID > 0 Then cmd.Parameters.AddWithValue("@iid", ingredientID)
        If dateFrom <> Nothing Then cmd.Parameters.AddWithValue("@from", dateFrom.ToString("yyyy-MM-dd"))
        If dateTo <> Nothing Then cmd.Parameters.AddWithValue("@to", dateTo.ToString("yyyy-MM-dd"))
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        dgvBatches.DataSource = dt
        dgvBatches.AllowUserToAddRows = False
        dgvBatches.ReadOnly = True
        If dgvBatches.Columns.Contains("BatchID") Then dgvBatches.Columns("BatchID").Visible = False
        If dgvBatches.Columns.Contains("IngredientID") Then dgvBatches.Columns("IngredientID").Visible = False

        For Each row As DataGridViewRow In dgvBatches.Rows
            If Not IsDBNull(row.Cells("ExpiryDate").Value) Then
                Dim expiry = Convert.ToDateTime(row.Cells("ExpiryDate").Value)
                Dim daysLeft = (expiry - DateTime.Today).Days
                If daysLeft <= 7 Then
                    row.DefaultCellStyle.BackColor = Color.LightCoral
                    row.DefaultCellStyle.ForeColor = Color.DarkRed
                ElseIf daysLeft <= 30 Then
                    row.DefaultCellStyle.BackColor = Color.LightYellow
                End If
            End If
        Next

        isLoading = False
        UpdateTotalLabel(dt)
    End Sub

    Private Sub UpdateTotalLabel(dt As DataTable)
        Dim total As Decimal = 0
        For Each row As DataRow In dt.Rows
            total += Convert.ToDecimal(row("TotalCost"))
        Next
        lblTotalCost.Text = "Total Restock Cost: ₱" & total.ToString("0.00")
    End Sub

    ' Click a batch row -> populate the inline adjustment fields and reset
    ' the reason/notes so a stale reason can't accidentally carry over.
    Private Sub dgvBatches_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBatches.CellClick
        If isLoading OrElse e.RowIndex < 0 Then Return
        Dim row = dgvBatches.Rows(e.RowIndex)
        txtBatchQty.Text = row.Cells("RemainingQty").Value.ToString()
        txtBatchCost.Text = row.Cells("CostPerUnit").Value.ToString()
        dtpBatchExpiry.Value = Convert.ToDateTime(row.Cells("ExpiryDate").Value)
        cboAdjustReason.SelectedIndex = -1
        txtAdjustNotes.Clear()

        txtBatchQty.Enabled = True
        txtBatchCost.Enabled = True
        dtpBatchExpiry.Enabled = True
    End Sub

    ' ── Hardcoded pack-size choices, keyed off the ingredient's base Unit ────
    Private Function GetPackSizeOptions(unit As String) As List(Of PackSizeOption)
        Select Case unit
            Case "pcs"
                Return New List(Of PackSizeOption) From {
                    New PackSizeOption("1 pc", 1),
                    New PackSizeOption("Box of 12", 12),
                    New PackSizeOption("Box of 24", 24),
                    New PackSizeOption("Box of 50", 50)
                }
            Case "g"
                Return New List(Of PackSizeOption) From {
                    New PackSizeOption("500 g", 500),
                    New PackSizeOption("1 kg", 1000),
                    New PackSizeOption("5 kg", 5000),
                    New PackSizeOption("25 kg sack", 25000)
                }
            Case "ml"
                Return New List(Of PackSizeOption) From {
                    New PackSizeOption("500 ml", 500),
                    New PackSizeOption("1 L", 1000),
                    New PackSizeOption("5 L", 5000),
                    New PackSizeOption("20 L", 20000)
                }
            Case Else
                Return New List(Of PackSizeOption) From {New PackSizeOption("1 " & unit, 1)}
        End Select
    End Function

    ' Selecting an ingredient to restock repopulates the pack-size choices
    ' (based on its Unit) and shows current stock.
    Private Sub cboProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProduct.SelectedIndexChanged
        If cboProduct.SelectedItem Is Nothing Then Return
        Dim row = CType(cboProduct.SelectedItem, DataRowView)
        Dim unit = row("Unit").ToString()
        lblCurrentStock.Text = $"Current Stock: {row("Stock")} {unit}"

        cboPackSize.DataSource = GetPackSizeOptions(unit)
        cboPackSize.DisplayMember = "Label"
        cboPackSize.ValueMember = "BaseQty"
        If cboPackSize.Items.Count > 0 Then cboPackSize.SelectedIndex = 0
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim selectedIngredientID = Convert.ToInt32(cboFilterProduct.SelectedValue)
        If dtpFrom.Value.Date > dtpTo.Value.Date Then
            MessageBox.Show("'From' date cannot be later than 'To' date.")
            Return
        End If
        LoadActiveBatchesTab(
            ingredientID:=selectedIngredientID,
            dateFrom:=dtpFrom.Value.Date,
            dateTo:=dtpTo.Value.Date)
    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        cboFilterProduct.SelectedIndex = 0
        dtpFrom.Value = DateTime.Today.AddMonths(-1)
        dtpTo.Value = DateTime.Today
        LoadActiveBatchesTab()
    End Sub

    ' CHANGED: txtQuantity = how many of the selected pack size (e.g. "3" boxes),
    ' txtCostPerUnit = cost of ONE pack (e.g. cost of one box). The actual
    ' ingredientbatches row is still stored in base units, same as before -
    ' the pack-size math just happens here, once, on the way in.
    ' total_cost is no longer stored on supplier_deliveries - it's derived,
    ' so it's dropped from the insert entirely.
    Private Sub btnRestock_Click(sender As Object, e As EventArgs) Handles btnRestock.Click
        If cboProduct.SelectedItem Is Nothing Then
            MessageBox.Show("Please select an ingredient.")
            Return
        End If
        If cboPackSize.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a pack size.")
            Return
        End If
        If cboSupplier.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a supplier.")
            Return
        End If
        Dim supplierID = Convert.ToInt32(cboSupplier.SelectedValue)

        Dim ingredientID = Convert.ToInt32(cboProduct.SelectedValue)
        Dim ingredientRow = CType(cboProduct.SelectedItem, DataRowView)
        Dim ingredientName = ingredientRow("IngredientName").ToString()
        Dim baseUnit = ingredientRow("Unit").ToString()

        Dim packOption = CType(cboPackSize.SelectedItem, PackSizeOption)
        Dim baseQtyPerPack = packOption.BaseQty

        If String.IsNullOrWhiteSpace(txtQuantity.Text) Then
            MessageBox.Show($"Please enter how many of ""{packOption.Label}"" you're restocking.")
            txtQuantity.Focus()
            Return
        End If
        Dim numPacks As Decimal
        If Not Decimal.TryParse(txtQuantity.Text, numPacks) OrElse numPacks <= 0 Then
            MessageBox.Show("Please enter a valid quantity.")
            txtQuantity.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtCostPerUnit.Text) Then
            MessageBox.Show($"Please enter the cost of one ""{packOption.Label}"".")
            txtCostPerUnit.Focus()
            Return
        End If
        Dim costPerPack As Decimal
        If Not Decimal.TryParse(txtCostPerUnit.Text, costPerPack) OrElse costPerPack < 0 Then
            MessageBox.Show("Please enter a valid cost.")
            txtCostPerUnit.Focus()
            Return
        End If

        Dim expiryDate = dtpExpiry.Value.Date
        If expiryDate <= DateTime.Today Then
            MessageBox.Show("Expiry date must be in the future.")
            Return
        End If

        ' --- pack-size conversion happens here, once, on the way in ---
        Dim baseQty As Integer = CInt(Math.Round(numPacks * baseQtyPerPack))
        Dim costPerBaseUnit As Decimal = costPerPack / baseQtyPerPack
        Dim totalCost = numPacks * costPerPack ' == baseQty * costPerBaseUnit (used for the expense row only)

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim transaction = conn.BeginTransaction()
        Try
            Dim cmdBatch As New MySqlCommand(
            "INSERT INTO ingredientbatches (IngredientID, Quantity, RemainingQty, CostPerUnit, RestockDate, ExpiryDate)
             VALUES (@iid, @qty, @qty, @cpu, @date, @expiry)", conn, transaction)
            cmdBatch.Parameters.AddWithValue("@iid", ingredientID)
            cmdBatch.Parameters.AddWithValue("@qty", baseQty)
            cmdBatch.Parameters.AddWithValue("@cpu", costPerBaseUnit)
            cmdBatch.Parameters.AddWithValue("@date", DateTime.Today)
            cmdBatch.Parameters.AddWithValue("@expiry", expiryDate)
            cmdBatch.ExecuteNonQuery()
            Dim newBatchID = CInt(cmdBatch.LastInsertedId)

            ' total_cost column dropped - no longer inserted here.
            Dim cmdDelivery As New MySqlCommand(
"INSERT INTO supplier_deliveries (supplier_id, ingredient_id, batch_id, pack_label,
                                   cost_per_base_unit, delivery_date, expiry_date)
 VALUES (@sid, @iid, @bid, @label, @cpu, @date, @expiry)", conn, transaction)
            cmdDelivery.Parameters.AddWithValue("@sid", supplierID)
            cmdDelivery.Parameters.AddWithValue("@iid", ingredientID)
            cmdDelivery.Parameters.AddWithValue("@bid", newBatchID)
            cmdDelivery.Parameters.AddWithValue("@label", packOption.Label)
            cmdDelivery.Parameters.AddWithValue("@cpu", costPerBaseUnit)
            cmdDelivery.Parameters.AddWithValue("@date", DateTime.Today)
            cmdDelivery.Parameters.AddWithValue("@expiry", expiryDate)
            cmdDelivery.ExecuteNonQuery()

            Dim cmdExpense As New MySqlCommand(
            "INSERT INTO expenses (CategoryID, Description, Amount, ExpenseDate, IsAutoGenerated)
             VALUES (
                (SELECT CategoryID FROM expensecategories WHERE CategoryName = 'Restock'),
                @desc, @amount, @date, 1
             )", conn, transaction)
            cmdExpense.Parameters.AddWithValue("@desc", $"{ingredientName} x{numPacks} {packOption.Label} @ ₱{costPerPack} each = {baseQty}{baseUnit} (Expiry: {expiryDate:yyyy-MM-dd})")
            cmdExpense.Parameters.AddWithValue("@amount", totalCost)
            cmdExpense.Parameters.AddWithValue("@date", DateTime.Today)
            cmdExpense.ExecuteNonQuery()

            transaction.Commit()

            txtQuantity.Clear()
            txtCostPerUnit.Clear()
        Catch ex As Exception
            transaction.Rollback()
            MessageBox.Show("Restock failed: " & ex.Message)
        End Try
        conn.Close()

        LoadProductsTab(txtProductSearch.Text)
        LoadIngredientsTab(txtIngredientSearch.Text)
        LoadActiveBatchesTab()
        LoadFilterIngredients()
    End Sub

    ' ── Update an existing batch (RemainingQty / CostPerUnit / ExpiryDate) ──
    ' Reason is always required, no time-window exception.
    Private Sub btnUpdateBatch_Click(sender As Object, e As EventArgs) Handles btnUpdateBatch.Click
        If dgvBatches.CurrentRow Is Nothing Then
            MessageBox.Show("Please click a batch to update.")
            Return
        End If
        If cboAdjustReason.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a reason for this change.")
            Return
        End If

        Dim newQty As Integer, newCost As Decimal
        If Not Integer.TryParse(txtBatchQty.Text, newQty) OrElse newQty < 0 Then
            MessageBox.Show("Enter a valid quantity.")
            Return
        End If
        If Not Decimal.TryParse(txtBatchCost.Text, newCost) OrElse newCost < 0 Then
            MessageBox.Show("Enter a valid cost.")
            Return
        End If

        Dim row = dgvBatches.CurrentRow
        Dim batchID = Convert.ToInt32(row.Cells("BatchID").Value)
        Dim ingredientID = Convert.ToInt32(row.Cells("IngredientID").Value)
        Dim oldQty = Convert.ToInt32(row.Cells("RemainingQty").Value)
        Dim oldCost = Convert.ToDecimal(row.Cells("CostPerUnit").Value)
        Dim oldExpiry = Convert.ToDateTime(row.Cells("ExpiryDate").Value)
        Dim newExpiry = dtpBatchExpiry.Value.Date

        If newQty > oldQty Then
            MessageBox.Show("Quantity can't be increased here. To add stock, use Restock instead.")
            Return
        End If

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim tx = conn.BeginTransaction()
        Try
            Dim cmd As New MySqlCommand(
            "UPDATE ingredientbatches SET RemainingQty=@qty, CostPerUnit=@cost, ExpiryDate=@exp
             WHERE BatchID=@bid", conn, tx)
            cmd.Parameters.AddWithValue("@qty", newQty)
            cmd.Parameters.AddWithValue("@cost", newCost)
            cmd.Parameters.AddWithValue("@exp", newExpiry)
            cmd.Parameters.AddWithValue("@bid", batchID)
            cmd.ExecuteNonQuery()

            LogAdjustment(conn, tx, batchID, "Update", oldQty, newQty, oldCost, newCost,
              oldExpiry, newExpiry, cboAdjustReason.Text, txtAdjustNotes.Text)

            MaybeExpenseLoss(conn, tx, cboAdjustReason.Text, oldQty - newQty, newCost)

            tx.Commit()
        Catch ex As Exception
            tx.Rollback()
            MessageBox.Show("Update failed: " & ex.Message)
        End Try
        conn.Close()

        LoadActiveBatchesTab()
        LoadIngredientsTab(txtIngredientSearch.Text)
        LoadProductsTab(txtProductSearch.Text)
    End Sub

    ' ── Delete an existing batch outright ────────────────────────────────
    ' Reason is always required, no time-window exception.
    Private Sub btnDeleteBatch_Click(sender As Object, e As EventArgs) Handles btnDeleteBatch.Click
        If dgvBatches.CurrentRow Is Nothing Then
            MessageBox.Show("Please click a batch to delete.")
            Return
        End If
        If cboAdjustReason.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a reason for this deletion.")
            Return
        End If
        If MessageBox.Show("Void this batch? It will no longer count as available stock, but its history will be kept.",
                        "Confirm Delete", MessageBoxButtons.YesNo) = DialogResult.No Then Return

        Dim row = dgvBatches.CurrentRow
        Dim batchID = Convert.ToInt32(row.Cells("BatchID").Value)
        Dim ingredientID = Convert.ToInt32(row.Cells("IngredientID").Value)
        Dim oldQty = Convert.ToInt32(row.Cells("RemainingQty").Value)
        Dim oldCost = Convert.ToDecimal(row.Cells("CostPerUnit").Value)
        Dim oldExpiry = Convert.ToDateTime(row.Cells("ExpiryDate").Value)

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim tx = conn.BeginTransaction()
        Try
            LogAdjustment(conn, tx, batchID, "Delete", oldQty, 0, oldCost, oldCost,
              oldExpiry, oldExpiry, cboAdjustReason.Text, txtAdjustNotes.Text)

            MaybeExpenseLoss(conn, tx, cboAdjustReason.Text, oldQty, oldCost)

            Dim cmd As New MySqlCommand(
            "UPDATE ingredientbatches SET IsVoided = 1, RemainingQty = 0 WHERE BatchID = @bid", conn, tx)
            cmd.Parameters.AddWithValue("@bid", batchID)
            cmd.ExecuteNonQuery()

            tx.Commit()
        Catch ex As Exception
            tx.Rollback()
            MessageBox.Show("Delete failed: " & ex.Message)
        End Try
        conn.Close()

        ' at the end of btnDeleteBatch_Click, after a successful delete
        txtBatchQty.Enabled = False
        txtBatchCost.Enabled = False
        dtpBatchExpiry.Enabled = False

        LoadActiveBatchesTab()
        LoadIngredientsTab(txtIngredientSearch.Text)
        LoadProductsTab(txtProductSearch.Text)
    End Sub

    ' ── Shared helpers for batch adjustments ─────────────────────────────

    Private Sub LogAdjustment(conn As MySqlConnection, tx As MySqlTransaction, batchID As Integer,
                       actionType As String, oldQty As Integer, newQty As Integer,
                       oldCost As Decimal, newCost As Decimal,
                       oldExpiry As DateTime, newExpiry As DateTime,
                       reason As String, notes As String)
        Dim cmd As New MySqlCommand(
    "INSERT INTO batch_adjustments
     (BatchID, ActionType, OldRemainingQty, NewRemainingQty, OldCostPerUnit, NewCostPerUnit,
      OldExpiryDate, NewExpiryDate, Reason, Notes, AdjustedDate)
     VALUES (@bid, @act, @oq, @nq, @oc, @nc, @oe, @ne, @reason, @notes, @date)", conn, tx)
        cmd.Parameters.AddWithValue("@bid", batchID)
        cmd.Parameters.AddWithValue("@act", actionType)
        cmd.Parameters.AddWithValue("@oq", oldQty)
        cmd.Parameters.AddWithValue("@nq", newQty)
        cmd.Parameters.AddWithValue("@oc", oldCost)
        cmd.Parameters.AddWithValue("@nc", newCost)
        cmd.Parameters.AddWithValue("@oe", oldExpiry)
        cmd.Parameters.AddWithValue("@ne", newExpiry)
        cmd.Parameters.AddWithValue("@reason", reason)
        cmd.Parameters.AddWithValue("@notes", If(String.IsNullOrWhiteSpace(notes), CObj(DBNull.Value), notes))
        cmd.Parameters.AddWithValue("@date", DateTime.Now)
        cmd.ExecuteNonQuery()
    End Sub

    ' Only Spoilage/Breakage/Theft generate an automatic "Loss" expense.
    ' Wrong Entry / Miscount / Other are treated as bookkeeping corrections,
    ' not real losses, so no expense is created for those.
    Private Sub MaybeExpenseLoss(conn As MySqlConnection, tx As MySqlTransaction,
                                  reason As String, qtyLost As Integer, costPerUnit As Decimal)
        If qtyLost <= 0 Then Return
        Dim lossReasons = {"Spoilage", "Breakage", "Theft"}
        If Not lossReasons.Contains(reason) Then Return

        Dim cmd As New MySqlCommand(
            "INSERT INTO expenses (CategoryID, Description, Amount, ExpenseDate, IsAutoGenerated)
             VALUES ((SELECT CategoryID FROM expensecategories WHERE CategoryName='Loss'),
                     @desc, @amount, @date, 1)", conn, tx)
        cmd.Parameters.AddWithValue("@desc", $"{reason}: {qtyLost} units lost")
        cmd.Parameters.AddWithValue("@amount", qtyLost * costPerUnit)
        cmd.Parameters.AddWithValue("@date", DateTime.Today)
        cmd.ExecuteNonQuery()
    End Sub




    ' =========================================================
    ' EXPIRED TAB (expired INGREDIENT batches)
    ' =========================================================

    Private Sub LoadExpiredTab()
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "SELECT b.BatchID, i.IngredientName, i.Unit, b.Quantity, b.RemainingQty,
                    b.CostPerUnit, (b.Quantity * b.CostPerUnit) AS TotalCost,
                    b.RestockDate, b.ExpiryDate,
                    DATEDIFF(CURDATE(), b.ExpiryDate) AS DaysExpired
             FROM ingredientbatches b
             INNER JOIN ingredients i ON b.IngredientID = i.IngredientID
             WHERE b.ExpiryDate < CURDATE() AND b.IsVoided = 0
             ORDER BY b.ExpiryDate ASC", conn)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        dgvExpired.DataSource = dt
        dgvExpired.AllowUserToAddRows = False
        dgvExpired.ReadOnly = True
        If dgvExpired.Columns.Contains("BatchID") Then dgvExpired.Columns("BatchID").Visible = False

        For Each row As DataGridViewRow In dgvExpired.Rows
            row.DefaultCellStyle.BackColor = Color.LightCoral
            row.DefaultCellStyle.ForeColor = Color.DarkRed
        Next

        lblExpiredCount.Text = $"Expired Batches: {dt.Rows.Count} batch(es) found"
    End Sub

    Private Sub btnDeleteExpired_Click(sender As Object, e As EventArgs) Handles btnDeleteExpired.Click
        If dgvExpired.Rows.Count = 0 Then
            MessageBox.Show("No expired batches to delete.")
            Return
        End If
        If MessageBox.Show(
        "Delete all expired batches? This will log each as a Spoilage loss and cannot be undone.",
        "Confirm Delete", MessageBoxButtons.YesNo) = DialogResult.No Then Return

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim tx = conn.BeginTransaction()
        Try
            Dim cmdSelect As New MySqlCommand(
            "SELECT BatchID, RemainingQty, CostPerUnit, ExpiryDate
             FROM ingredientbatches WHERE ExpiryDate < CURDATE() AND IsVoided = 0", conn, tx)
            Dim reader = cmdSelect.ExecuteReader()
            Dim expiredBatches As New List(Of (BatchID As Integer, Qty As Integer, Cost As Decimal, Expiry As DateTime))
            While reader.Read()
                expiredBatches.Add((Convert.ToInt32(reader("BatchID")), Convert.ToInt32(reader("RemainingQty")),
                                 Convert.ToDecimal(reader("CostPerUnit")), Convert.ToDateTime(reader("ExpiryDate"))))
            End While
            reader.Close()

            For Each b In expiredBatches
                LogAdjustment(conn, tx, b.BatchID, "Delete", b.Qty, 0, b.Cost, b.Cost,
                          b.Expiry, b.Expiry, "Spoilage", "Auto-cleared: batch expired")
                MaybeExpenseLoss(conn, tx, "Spoilage", b.Qty, b.Cost)

                Dim cmdVoid As New MySqlCommand(
                "UPDATE ingredientbatches SET IsVoided = 1, RemainingQty = 0 WHERE BatchID = @bid", conn, tx)
                cmdVoid.Parameters.AddWithValue("@bid", b.BatchID)
                cmdVoid.ExecuteNonQuery()
            Next

            tx.Commit()
            MessageBox.Show($"{expiredBatches.Count} expired batch(es) cleared and logged as spoilage.")
        Catch ex As Exception
            tx.Rollback()
            MessageBox.Show("Delete failed: " & ex.Message)
        End Try
        conn.Close()

        LoadProductsTab(txtProductSearch.Text)
        LoadIngredientsTab(txtIngredientSearch.Text)
        LoadActiveBatchesTab()
        LoadExpiredTab()
        LoadFilterIngredients()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmAdminDashboard.Show()
        Me.Close()
    End Sub

    Private Sub cboFilterProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterProduct.SelectedIndexChanged
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
    End Sub

    Private Sub TabPage5_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub TabPage4_Click(sender As Object, e As EventArgs) Handles TabPage4.Click
    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnAddSupplier.Click

    End Sub

    Private Sub TabPage5_Click_1(sender As Object, e As EventArgs) Handles TabPage5.Click

    End Sub

    Private Sub cboSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSupplier.SelectedIndexChanged

    End Sub

    Private Sub dgvSuppliers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSuppliers.CellContentClick

    End Sub

    Private Sub btnProductSearch_Click(sender As Object, e As EventArgs)

    End Sub

    ' ── Soft-deletes a product (sets IsActive = 0) instead of a hard DELETE.
    ' Keeps existing productingredients/transactiondetails/images intact so past
    ' orders and recipes still resolve correctly — the product just stops
    ' showing up in LoadProductsTab (which already filters WHERE IsActive = 1)
    ' and stops appearing as a tile in frmCustomerOrder.
    Private Sub btnDeleteProduct_Click(sender As Object, e As EventArgs) Handles btnDeleteProduct.Click
        If dgvProducts.CurrentRow Is Nothing Then
            MessageBox.Show("Please click a product row to delete.")
            Return
        End If

        Dim productID = Convert.ToInt32(dgvProducts.CurrentRow.Cells("ProductID").Value)
        Dim productName = dgvProducts.CurrentRow.Cells("ProductName").Value.ToString()

        If MessageBox.Show($"Delete ""{productName}""? It will be hidden from the menu and inventory list, but its order history and recipe will be kept.",
                        "Confirm Delete", MessageBoxButtons.YesNo) = DialogResult.No Then Return

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Try
            Dim cmd As New MySqlCommand("UPDATE products SET IsActive = 0 WHERE ProductID = @pid", conn)
            cmd.Parameters.AddWithValue("@pid", productID)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Product deleted successfully.")
        Catch ex As Exception
            MessageBox.Show("Delete failed: " & ex.Message)
        End Try
        conn.Close()

        ClearProductFields()
        LoadProductsTab(txtProductSearch.Text)
        LoadRecipeTab()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmAdjustmentHistory.Show()


    End Sub

    Private Sub btnClearProduct_Click(sender As Object, e As EventArgs) Handles btnClearProduct.Click

        ClearProductFields()

    End Sub
End Class