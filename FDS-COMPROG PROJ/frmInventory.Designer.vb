<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInventory
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventory))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btnRemovePhoto = New System.Windows.Forms.Button()
        Me.btnUploadPhoto = New System.Windows.Forms.Button()
        Me.pbProductPreview = New System.Windows.Forms.PictureBox()
        Me.lblProductCount = New System.Windows.Forms.Label()
        Me.btnClearProductSearch = New System.Windows.Forms.Button()
        Me.txtProductSearch = New System.Windows.Forms.TextBox()
        Me.txtProductPrice = New System.Windows.Forms.TextBox()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.cboProductCategory = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnDeleteProduct = New System.Windows.Forms.Button()
        Me.btnUpdateProduct = New System.Windows.Forms.Button()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.btnClearProduct = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnDeleteBatch = New System.Windows.Forms.Button()
        Me.btnUpdateBatch = New System.Windows.Forms.Button()
        Me.txtAdjustNotes = New System.Windows.Forms.TextBox()
        Me.cboAdjustReason = New System.Windows.Forms.ComboBox()
        Me.dtpBatchExpiry = New System.Windows.Forms.DateTimePicker()
        Me.txtBatchCost = New System.Windows.Forms.TextBox()
        Me.txtBatchQty = New System.Windows.Forms.TextBox()
        Me.cboSupplier = New System.Windows.Forms.ComboBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.cboPackSize = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCostPerUnit = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvBatches = New System.Windows.Forms.DataGridView()
        Me.lblTotalCost = New System.Windows.Forms.Label()
        Me.cboFilterProduct = New System.Windows.Forms.ComboBox()
        Me.lblCurrentStock = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpExpiry = New System.Windows.Forms.DateTimePicker()
        Me.cboProduct = New System.Windows.Forms.ComboBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnRestock = New System.Windows.Forms.Button()
        Me.btnClearFilter = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnDeleteExpired = New System.Windows.Forms.Button()
        Me.lblExpiredCount = New System.Windows.Forms.Label()
        Me.dgvExpired = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cboRecipeIngredient = New System.Windows.Forms.ComboBox()
        Me.cboRecipeProduct = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnRecipeRemoveLine = New System.Windows.Forms.Button()
        Me.btnRecipeAddLine = New System.Windows.Forms.Button()
        Me.btnUpdateRecipe = New System.Windows.Forms.Button()
        Me.txtRecipeQty = New System.Windows.Forms.TextBox()
        Me.txtIngredientSearch = New System.Windows.Forms.TextBox()
        Me.txtIngredientName = New System.Windows.Forms.TextBox()
        Me.dgvRecipe = New System.Windows.Forms.DataGridView()
        Me.lblIngredientCount = New System.Windows.Forms.Label()
        Me.btnClearIngredientSearch = New System.Windows.Forms.Button()
        Me.cboIngredientUnit = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnDeleteIngredient = New System.Windows.Forms.Button()
        Me.btnUpdateIngredient = New System.Windows.Forms.Button()
        Me.btnAddIngredient = New System.Windows.Forms.Button()
        Me.btnClearIngredient = New System.Windows.Forms.Button()
        Me.dgvIngredients = New System.Windows.Forms.DataGridView()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtSupplierAddress = New System.Windows.Forms.TextBox()
        Me.txtSupplierContact = New System.Windows.Forms.TextBox()
        Me.txtSupplierContactName = New System.Windows.Forms.TextBox()
        Me.txtSupplierName = New System.Windows.Forms.TextBox()
        Me.btnDeleteSupplier = New System.Windows.Forms.Button()
        Me.btnUpdateSupplier = New System.Windows.Forms.Button()
        Me.btnAddSupplier = New System.Windows.Forms.Button()
        Me.btnClearSupplier = New System.Windows.Forms.Button()
        Me.dgvSuppliers = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.pbProductPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvBatches, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvExpired, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvRecipe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvIngredients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvSuppliers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(300, 150)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1924, 1055)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 15
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_04_2246091
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.Label31)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.btnRemovePhoto)
        Me.TabPage1.Controls.Add(Me.btnUploadPhoto)
        Me.TabPage1.Controls.Add(Me.pbProductPreview)
        Me.TabPage1.Controls.Add(Me.lblProductCount)
        Me.TabPage1.Controls.Add(Me.btnClearProductSearch)
        Me.TabPage1.Controls.Add(Me.txtProductSearch)
        Me.TabPage1.Controls.Add(Me.txtProductPrice)
        Me.TabPage1.Controls.Add(Me.txtProductName)
        Me.TabPage1.Controls.Add(Me.cboProductCategory)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.btnDeleteProduct)
        Me.TabPage1.Controls.Add(Me.btnUpdateProduct)
        Me.TabPage1.Controls.Add(Me.btnAddProduct)
        Me.TabPage1.Controls.Add(Me.btnClearProduct)
        Me.TabPage1.Controls.Add(Me.btnBack)
        Me.TabPage1.Controls.Add(Me.dgvProducts)
        Me.TabPage1.Location = New System.Drawing.Point(4, 154)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Size = New System.Drawing.Size(1916, 897)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "PRODUCTS MENU"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ForeColor = System.Drawing.Color.Firebrick
        Me.Label31.Location = New System.Drawing.Point(1389, 66)
        Me.Label31.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(188, 20)
        Me.Label31.TabIndex = 35
        Me.Label31.Text = "PRODUCT DETAILS:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.Firebrick
        Me.Label26.Location = New System.Drawing.Point(1245, 318)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(176, 20)
        Me.Label26.TabIndex = 34
        Me.Label26.Text = "PRODUCT PHOTO:"
        '
        'btnRemovePhoto
        '
        Me.btnRemovePhoto.BackgroundImage = CType(resources.GetObject("btnRemovePhoto.BackgroundImage"), System.Drawing.Image)
        Me.btnRemovePhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRemovePhoto.FlatAppearance.BorderSize = 0
        Me.btnRemovePhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemovePhoto.ForeColor = System.Drawing.Color.Firebrick
        Me.btnRemovePhoto.Location = New System.Drawing.Point(1476, 434)
        Me.btnRemovePhoto.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRemovePhoto.Name = "btnRemovePhoto"
        Me.btnRemovePhoto.Size = New System.Drawing.Size(209, 70)
        Me.btnRemovePhoto.TabIndex = 33
        Me.btnRemovePhoto.Text = "REMOVE"
        Me.btnRemovePhoto.UseVisualStyleBackColor = True
        '
        'btnUploadPhoto
        '
        Me.btnUploadPhoto.BackgroundImage = CType(resources.GetObject("btnUploadPhoto.BackgroundImage"), System.Drawing.Image)
        Me.btnUploadPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUploadPhoto.FlatAppearance.BorderSize = 0
        Me.btnUploadPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUploadPhoto.ForeColor = System.Drawing.Color.Firebrick
        Me.btnUploadPhoto.Location = New System.Drawing.Point(1472, 365)
        Me.btnUploadPhoto.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUploadPhoto.Name = "btnUploadPhoto"
        Me.btnUploadPhoto.Size = New System.Drawing.Size(213, 65)
        Me.btnUploadPhoto.TabIndex = 32
        Me.btnUploadPhoto.Text = "UPLOAD"
        Me.btnUploadPhoto.UseVisualStyleBackColor = True
        '
        'pbProductPreview
        '
        Me.pbProductPreview.Location = New System.Drawing.Point(1215, 340)
        Me.pbProductPreview.Margin = New System.Windows.Forms.Padding(2)
        Me.pbProductPreview.Name = "pbProductPreview"
        Me.pbProductPreview.Size = New System.Drawing.Size(231, 222)
        Me.pbProductPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbProductPreview.TabIndex = 31
        Me.pbProductPreview.TabStop = False
        '
        'lblProductCount
        '
        Me.lblProductCount.AutoSize = True
        Me.lblProductCount.BackColor = System.Drawing.Color.Transparent
        Me.lblProductCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductCount.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblProductCount.Location = New System.Drawing.Point(546, 44)
        Me.lblProductCount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProductCount.Name = "lblProductCount"
        Me.lblProductCount.Size = New System.Drawing.Size(65, 20)
        Me.lblProductCount.TabIndex = 30
        Me.lblProductCount.Text = "Label1"
        '
        'btnClearProductSearch
        '
        Me.btnClearProductSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnClearProductSearch.BackgroundImage = CType(resources.GetObject("btnClearProductSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnClearProductSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClearProductSearch.FlatAppearance.BorderSize = 0
        Me.btnClearProductSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearProductSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearProductSearch.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnClearProductSearch.Location = New System.Drawing.Point(308, 66)
        Me.btnClearProductSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClearProductSearch.Name = "btnClearProductSearch"
        Me.btnClearProductSearch.Size = New System.Drawing.Size(203, 43)
        Me.btnClearProductSearch.TabIndex = 29
        Me.btnClearProductSearch.Text = "CLEAR SEARCH"
        Me.btnClearProductSearch.UseVisualStyleBackColor = False
        '
        'txtProductSearch
        '
        Me.txtProductSearch.Location = New System.Drawing.Point(530, 74)
        Me.txtProductSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtProductSearch.Name = "txtProductSearch"
        Me.txtProductSearch.Size = New System.Drawing.Size(622, 27)
        Me.txtProductSearch.TabIndex = 27
        '
        'txtProductPrice
        '
        Me.txtProductPrice.Location = New System.Drawing.Point(1208, 269)
        Me.txtProductPrice.Margin = New System.Windows.Forms.Padding(2)
        Me.txtProductPrice.Name = "txtProductPrice"
        Me.txtProductPrice.Size = New System.Drawing.Size(488, 27)
        Me.txtProductPrice.TabIndex = 17
        '
        'txtProductName
        '
        Me.txtProductName.Location = New System.Drawing.Point(1207, 122)
        Me.txtProductName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(490, 27)
        Me.txtProductName.TabIndex = 16
        '
        'cboProductCategory
        '
        Me.cboProductCategory.ForeColor = System.Drawing.Color.Firebrick
        Me.cboProductCategory.FormattingEnabled = True
        Me.cboProductCategory.Location = New System.Drawing.Point(1208, 191)
        Me.cboProductCategory.Margin = New System.Windows.Forms.Padding(2)
        Me.cboProductCategory.Name = "cboProductCategory"
        Me.cboProductCategory.Size = New System.Drawing.Size(490, 28)
        Me.cboProductCategory.TabIndex = 26
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Firebrick
        Me.Label8.Location = New System.Drawing.Point(1205, 247)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(166, 20)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "PRODUCT PRICE:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Firebrick
        Me.Label9.Location = New System.Drawing.Point(1206, 169)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(205, 20)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "PRODUCT CATEGORY"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Firebrick
        Me.Label10.Location = New System.Drawing.Point(1204, 100)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(163, 20)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "PRODUCT NAME:"
        '
        'btnDeleteProduct
        '
        Me.btnDeleteProduct.BackgroundImage = CType(resources.GetObject("btnDeleteProduct.BackgroundImage"), System.Drawing.Image)
        Me.btnDeleteProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDeleteProduct.FlatAppearance.BorderSize = 0
        Me.btnDeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteProduct.ForeColor = System.Drawing.Color.Firebrick
        Me.btnDeleteProduct.Location = New System.Drawing.Point(1472, 683)
        Me.btnDeleteProduct.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteProduct.Name = "btnDeleteProduct"
        Me.btnDeleteProduct.Size = New System.Drawing.Size(249, 95)
        Me.btnDeleteProduct.TabIndex = 22
        Me.btnDeleteProduct.Text = "DELETE"
        Me.btnDeleteProduct.UseVisualStyleBackColor = True
        '
        'btnUpdateProduct
        '
        Me.btnUpdateProduct.BackgroundImage = CType(resources.GetObject("btnUpdateProduct.BackgroundImage"), System.Drawing.Image)
        Me.btnUpdateProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUpdateProduct.FlatAppearance.BorderSize = 0
        Me.btnUpdateProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateProduct.ForeColor = System.Drawing.Color.Firebrick
        Me.btnUpdateProduct.Location = New System.Drawing.Point(1472, 595)
        Me.btnUpdateProduct.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdateProduct.Name = "btnUpdateProduct"
        Me.btnUpdateProduct.Size = New System.Drawing.Size(249, 95)
        Me.btnUpdateProduct.TabIndex = 21
        Me.btnUpdateProduct.Text = "UPDATE"
        Me.btnUpdateProduct.UseVisualStyleBackColor = True
        '
        'btnAddProduct
        '
        Me.btnAddProduct.BackgroundImage = CType(resources.GetObject("btnAddProduct.BackgroundImage"), System.Drawing.Image)
        Me.btnAddProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddProduct.FlatAppearance.BorderSize = 0
        Me.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddProduct.ForeColor = System.Drawing.Color.Firebrick
        Me.btnAddProduct.Location = New System.Drawing.Point(1186, 595)
        Me.btnAddProduct.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(249, 95)
        Me.btnAddProduct.TabIndex = 20
        Me.btnAddProduct.Text = "ADD"
        Me.btnAddProduct.UseVisualStyleBackColor = True
        '
        'btnClearProduct
        '
        Me.btnClearProduct.BackgroundImage = CType(resources.GetObject("btnClearProduct.BackgroundImage"), System.Drawing.Image)
        Me.btnClearProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClearProduct.FlatAppearance.BorderSize = 0
        Me.btnClearProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearProduct.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClearProduct.Location = New System.Drawing.Point(1186, 683)
        Me.btnClearProduct.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClearProduct.Name = "btnClearProduct"
        Me.btnClearProduct.Size = New System.Drawing.Size(243, 95)
        Me.btnClearProduct.TabIndex = 19
        Me.btnClearProduct.Text = "CLEAR"
        Me.btnClearProduct.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_05_131258
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.FlatAppearance.BorderSize = 0
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Location = New System.Drawing.Point(93, 44)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(108, 65)
        Me.btnBack.TabIndex = 13
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'dgvProducts
        '
        Me.dgvProducts.AllowUserToAddRows = False
        Me.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducts.Location = New System.Drawing.Point(114, 133)
        Me.dgvProducts.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.RowHeadersWidth = 82
        Me.dgvProducts.RowTemplate.Height = 33
        Me.dgvProducts.Size = New System.Drawing.Size(1038, 622)
        Me.dgvProducts.TabIndex = 11
        '
        'TabPage2
        '
        Me.TabPage2.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_05_142512
        Me.TabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage2.Controls.Add(Me.Label30)
        Me.TabPage2.Controls.Add(Me.Label29)
        Me.TabPage2.Controls.Add(Me.Label28)
        Me.TabPage2.Controls.Add(Me.Label27)
        Me.TabPage2.Controls.Add(Me.Button5)
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.btnDeleteBatch)
        Me.TabPage2.Controls.Add(Me.btnUpdateBatch)
        Me.TabPage2.Controls.Add(Me.txtAdjustNotes)
        Me.TabPage2.Controls.Add(Me.cboAdjustReason)
        Me.TabPage2.Controls.Add(Me.dtpBatchExpiry)
        Me.TabPage2.Controls.Add(Me.txtBatchCost)
        Me.TabPage2.Controls.Add(Me.txtBatchQty)
        Me.TabPage2.Controls.Add(Me.cboSupplier)
        Me.TabPage2.Controls.Add(Me.txtQuantity)
        Me.TabPage2.Controls.Add(Me.cboPackSize)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.txtCostPerUnit)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.dgvBatches)
        Me.TabPage2.Controls.Add(Me.lblTotalCost)
        Me.TabPage2.Controls.Add(Me.cboFilterProduct)
        Me.TabPage2.Controls.Add(Me.lblCurrentStock)
        Me.TabPage2.Controls.Add(Me.dtpFrom)
        Me.TabPage2.Controls.Add(Me.dtpTo)
        Me.TabPage2.Controls.Add(Me.dtpExpiry)
        Me.TabPage2.Controls.Add(Me.cboProduct)
        Me.TabPage2.Controls.Add(Me.btnFilter)
        Me.TabPage2.Controls.Add(Me.btnRestock)
        Me.TabPage2.Controls.Add(Me.btnClearFilter)
        Me.TabPage2.Location = New System.Drawing.Point(4, 154)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Size = New System.Drawing.Size(1916, 897)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "STOCKS"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label30.Location = New System.Drawing.Point(1440, 348)
        Me.Label30.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(109, 20)
        Me.Label30.TabIndex = 43
        Me.Label30.Text = "PACK SIZE:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label29.Location = New System.Drawing.Point(1688, 133)
        Me.Label29.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(96, 20)
        Me.Label29.TabIndex = 42
        Me.Label29.Text = "RESTOCK"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label28.Location = New System.Drawing.Point(620, 505)
        Me.Label28.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(181, 20)
        Me.Label28.TabIndex = 41
        Me.Label28.Text = "ADJUSTMENT INFO"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label27.Location = New System.Drawing.Point(227, 505)
        Me.Label27.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(155, 20)
        Me.Label27.TabIndex = 40
        Me.Label27.Text = "BATCH DETAILS"
        '
        'Button5
        '
        Me.Button5.BackgroundImage = CType(resources.GetObject("Button5.BackgroundImage"), System.Drawing.Image)
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.DarkGreen
        Me.Button5.Location = New System.Drawing.Point(1007, 618)
        Me.Button5.Margin = New System.Windows.Forms.Padding(2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(203, 92)
        Me.Button5.TabIndex = 39
        Me.Button5.Text = "logs"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label25.Location = New System.Drawing.Point(1445, 269)
        Me.Label25.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(105, 20)
        Me.Label25.TabIndex = 38
        Me.Label25.Text = "SUPPLIER:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label20.Location = New System.Drawing.Point(146, 690)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(149, 20)
        Me.Label20.TabIndex = 37
        Me.Label20.Text = "BATCH EXPIRY:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label19.Location = New System.Drawing.Point(565, 617)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(182, 20)
        Me.Label19.TabIndex = 36
        Me.Label19.Text = "ADDITIONAL NOTE:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label18.Location = New System.Drawing.Point(558, 545)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(91, 20)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "REASON:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label17.Location = New System.Drawing.Point(140, 617)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(225, 20)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "BATCH COST PER UNIT:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label11.Location = New System.Drawing.Point(140, 545)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(174, 20)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "BATCH QUANTITY:"
        '
        'btnDeleteBatch
        '
        Me.btnDeleteBatch.BackgroundImage = CType(resources.GetObject("btnDeleteBatch.BackgroundImage"), System.Drawing.Image)
        Me.btnDeleteBatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDeleteBatch.FlatAppearance.BorderSize = 0
        Me.btnDeleteBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteBatch.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnDeleteBatch.Location = New System.Drawing.Point(1114, 532)
        Me.btnDeleteBatch.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteBatch.Name = "btnDeleteBatch"
        Me.btnDeleteBatch.Size = New System.Drawing.Size(203, 92)
        Me.btnDeleteBatch.TabIndex = 32
        Me.btnDeleteBatch.Text = "DELETE"
        Me.btnDeleteBatch.UseVisualStyleBackColor = True
        '
        'btnUpdateBatch
        '
        Me.btnUpdateBatch.BackgroundImage = CType(resources.GetObject("btnUpdateBatch.BackgroundImage"), System.Drawing.Image)
        Me.btnUpdateBatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUpdateBatch.FlatAppearance.BorderSize = 0
        Me.btnUpdateBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateBatch.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnUpdateBatch.Location = New System.Drawing.Point(907, 532)
        Me.btnUpdateBatch.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdateBatch.Name = "btnUpdateBatch"
        Me.btnUpdateBatch.Size = New System.Drawing.Size(203, 92)
        Me.btnUpdateBatch.TabIndex = 31
        Me.btnUpdateBatch.Text = "UPDATE"
        Me.btnUpdateBatch.UseVisualStyleBackColor = True
        '
        'txtAdjustNotes
        '
        Me.txtAdjustNotes.Location = New System.Drawing.Point(559, 640)
        Me.txtAdjustNotes.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAdjustNotes.Name = "txtAdjustNotes"
        Me.txtAdjustNotes.Size = New System.Drawing.Size(303, 27)
        Me.txtAdjustNotes.TabIndex = 30
        '
        'cboAdjustReason
        '
        Me.cboAdjustReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAdjustReason.FormattingEnabled = True
        Me.cboAdjustReason.Location = New System.Drawing.Point(562, 568)
        Me.cboAdjustReason.Margin = New System.Windows.Forms.Padding(2)
        Me.cboAdjustReason.Name = "cboAdjustReason"
        Me.cboAdjustReason.Size = New System.Drawing.Size(299, 28)
        Me.cboAdjustReason.TabIndex = 29
        '
        'dtpBatchExpiry
        '
        Me.dtpBatchExpiry.Location = New System.Drawing.Point(150, 727)
        Me.dtpBatchExpiry.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpBatchExpiry.Name = "dtpBatchExpiry"
        Me.dtpBatchExpiry.Size = New System.Drawing.Size(354, 27)
        Me.dtpBatchExpiry.TabIndex = 28
        '
        'txtBatchCost
        '
        Me.txtBatchCost.Location = New System.Drawing.Point(144, 640)
        Me.txtBatchCost.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBatchCost.Name = "txtBatchCost"
        Me.txtBatchCost.Size = New System.Drawing.Size(345, 27)
        Me.txtBatchCost.TabIndex = 27
        '
        'txtBatchQty
        '
        Me.txtBatchQty.Location = New System.Drawing.Point(144, 567)
        Me.txtBatchQty.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBatchQty.Name = "txtBatchQty"
        Me.txtBatchQty.Size = New System.Drawing.Size(345, 27)
        Me.txtBatchQty.TabIndex = 26
        '
        'cboSupplier
        '
        Me.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSupplier.ForeColor = System.Drawing.Color.DarkGreen
        Me.cboSupplier.FormattingEnabled = True
        Me.cboSupplier.Location = New System.Drawing.Point(1589, 269)
        Me.cboSupplier.Margin = New System.Windows.Forms.Padding(2)
        Me.cboSupplier.Name = "cboSupplier"
        Me.cboSupplier.Size = New System.Drawing.Size(323, 28)
        Me.cboSupplier.TabIndex = 25
        '
        'txtQuantity
        '
        Me.txtQuantity.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtQuantity.Location = New System.Drawing.Point(1589, 396)
        Me.txtQuantity.Margin = New System.Windows.Forms.Padding(2)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(323, 27)
        Me.txtQuantity.TabIndex = 24
        '
        'cboPackSize
        '
        Me.cboPackSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPackSize.ForeColor = System.Drawing.Color.DarkGreen
        Me.cboPackSize.FormattingEnabled = True
        Me.cboPackSize.Location = New System.Drawing.Point(1589, 348)
        Me.cboPackSize.Margin = New System.Windows.Forms.Padding(2)
        Me.cboPackSize.Name = "cboPackSize"
        Me.cboPackSize.Size = New System.Drawing.Size(323, 28)
        Me.cboPackSize.TabIndex = 23
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_05_142608
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(1692, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 70)
        Me.Button1.TabIndex = 21
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label7.Location = New System.Drawing.Point(1427, 536)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 20)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "UNIT PRICE:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label6.Location = New System.Drawing.Point(1445, 399)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 20)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "QUANTITY:"
        '
        'txtCostPerUnit
        '
        Me.txtCostPerUnit.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtCostPerUnit.Location = New System.Drawing.Point(1589, 532)
        Me.txtCostPerUnit.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCostPerUnit.Name = "txtCostPerUnit"
        Me.txtCostPerUnit.Size = New System.Drawing.Size(341, 27)
        Me.txtCostPerUnit.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label5.Location = New System.Drawing.Point(688, 58)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(174, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "FILTER PRODUCT:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label4.Location = New System.Drawing.Point(1399, 209)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(173, 20)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "PRODUCT STOCK:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label3.Location = New System.Drawing.Point(1427, 472)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 20)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "SET EXPIRY:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label1.Location = New System.Drawing.Point(238, 84)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 20)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "TO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label2.Location = New System.Drawing.Point(210, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "FROM:"
        '
        'dgvBatches
        '
        Me.dgvBatches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBatches.EnableHeadersVisualStyles = False
        Me.dgvBatches.Location = New System.Drawing.Point(105, 133)
        Me.dgvBatches.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvBatches.Name = "dgvBatches"
        Me.dgvBatches.RowHeadersWidth = 82
        Me.dgvBatches.RowTemplate.Height = 33
        Me.dgvBatches.Size = New System.Drawing.Size(1263, 339)
        Me.dgvBatches.TabIndex = 1
        '
        'lblTotalCost
        '
        Me.lblTotalCost.AutoSize = True
        Me.lblTotalCost.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblTotalCost.Location = New System.Drawing.Point(1055, 46)
        Me.lblTotalCost.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTotalCost.Name = "lblTotalCost"
        Me.lblTotalCost.Size = New System.Drawing.Size(96, 20)
        Me.lblTotalCost.TabIndex = 6
        Me.lblTotalCost.Text = "TotalCost:"
        '
        'cboFilterProduct
        '
        Me.cboFilterProduct.ForeColor = System.Drawing.Color.DarkGreen
        Me.cboFilterProduct.FormattingEnabled = True
        Me.cboFilterProduct.Location = New System.Drawing.Point(692, 84)
        Me.cboFilterProduct.Margin = New System.Windows.Forms.Padding(2)
        Me.cboFilterProduct.Name = "cboFilterProduct"
        Me.cboFilterProduct.Size = New System.Drawing.Size(325, 28)
        Me.cboFilterProduct.TabIndex = 7
        '
        'lblCurrentStock
        '
        Me.lblCurrentStock.AutoSize = True
        Me.lblCurrentStock.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblCurrentStock.Location = New System.Drawing.Point(1435, 167)
        Me.lblCurrentStock.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCurrentStock.Name = "lblCurrentStock"
        Me.lblCurrentStock.Size = New System.Drawing.Size(131, 20)
        Me.lblCurrentStock.TabIndex = 2
        Me.lblCurrentStock.Text = "Current Stock:"
        '
        'dtpFrom
        '
        Me.dtpFrom.CalendarForeColor = System.Drawing.Color.Firebrick
        Me.dtpFrom.CalendarTitleForeColor = System.Drawing.Color.Firebrick
        Me.dtpFrom.Location = New System.Drawing.Point(291, 48)
        Me.dtpFrom.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(361, 27)
        Me.dtpFrom.TabIndex = 4
        '
        'dtpTo
        '
        Me.dtpTo.CalendarForeColor = System.Drawing.Color.Firebrick
        Me.dtpTo.CalendarTitleForeColor = System.Drawing.Color.Firebrick
        Me.dtpTo.Location = New System.Drawing.Point(291, 82)
        Me.dtpTo.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(361, 27)
        Me.dtpTo.TabIndex = 5
        '
        'dtpExpiry
        '
        Me.dtpExpiry.Location = New System.Drawing.Point(1589, 468)
        Me.dtpExpiry.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpExpiry.Name = "dtpExpiry"
        Me.dtpExpiry.Size = New System.Drawing.Size(341, 27)
        Me.dtpExpiry.TabIndex = 10
        '
        'cboProduct
        '
        Me.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProduct.ForeColor = System.Drawing.Color.DarkGreen
        Me.cboProduct.FormattingEnabled = True
        Me.cboProduct.Location = New System.Drawing.Point(1589, 207)
        Me.cboProduct.Margin = New System.Windows.Forms.Padding(2)
        Me.cboProduct.Name = "cboProduct"
        Me.cboProduct.Size = New System.Drawing.Size(323, 28)
        Me.cboProduct.TabIndex = 0
        '
        'btnFilter
        '
        Me.btnFilter.BackgroundImage = CType(resources.GetObject("btnFilter.BackgroundImage"), System.Drawing.Image)
        Me.btnFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFilter.FlatAppearance.BorderSize = 0
        Me.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFilter.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnFilter.Location = New System.Drawing.Point(1036, 68)
        Me.btnFilter.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(174, 52)
        Me.btnFilter.TabIndex = 8
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'btnRestock
        '
        Me.btnRestock.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_05_1445351
        Me.btnRestock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRestock.FlatAppearance.BorderSize = 0
        Me.btnRestock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRestock.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnRestock.Location = New System.Drawing.Point(1589, 590)
        Me.btnRestock.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRestock.Name = "btnRestock"
        Me.btnRestock.Size = New System.Drawing.Size(243, 108)
        Me.btnRestock.TabIndex = 3
        Me.btnRestock.Text = "RESTOCK"
        Me.btnRestock.UseVisualStyleBackColor = True
        '
        'btnClearFilter
        '
        Me.btnClearFilter.BackgroundImage = CType(resources.GetObject("btnClearFilter.BackgroundImage"), System.Drawing.Image)
        Me.btnClearFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClearFilter.FlatAppearance.BorderSize = 0
        Me.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearFilter.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnClearFilter.Location = New System.Drawing.Point(1214, 68)
        Me.btnClearFilter.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Size = New System.Drawing.Size(155, 54)
        Me.btnClearFilter.TabIndex = 9
        Me.btnClearFilter.Text = "Clear Filter"
        Me.btnClearFilter.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_04_2246091
        Me.TabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage3.Controls.Add(Me.btnDeleteExpired)
        Me.TabPage3.Controls.Add(Me.lblExpiredCount)
        Me.TabPage3.Controls.Add(Me.dgvExpired)
        Me.TabPage3.Location = New System.Drawing.Point(4, 154)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage3.Size = New System.Drawing.Size(1916, 897)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "EXPIRY DELETION"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnDeleteExpired
        '
        Me.btnDeleteExpired.ForeColor = System.Drawing.Color.Firebrick
        Me.btnDeleteExpired.Location = New System.Drawing.Point(219, 37)
        Me.btnDeleteExpired.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteExpired.Name = "btnDeleteExpired"
        Me.btnDeleteExpired.Size = New System.Drawing.Size(173, 86)
        Me.btnDeleteExpired.TabIndex = 13
        Me.btnDeleteExpired.Text = "Delete Expired"
        Me.btnDeleteExpired.UseVisualStyleBackColor = True
        '
        'lblExpiredCount
        '
        Me.lblExpiredCount.AutoSize = True
        Me.lblExpiredCount.ForeColor = System.Drawing.Color.Firebrick
        Me.lblExpiredCount.Location = New System.Drawing.Point(406, 97)
        Me.lblExpiredCount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblExpiredCount.Name = "lblExpiredCount"
        Me.lblExpiredCount.Size = New System.Drawing.Size(133, 20)
        Me.lblExpiredCount.TabIndex = 14
        Me.lblExpiredCount.Text = "Expired Count:"
        '
        'dgvExpired
        '
        Me.dgvExpired.AllowUserToAddRows = False
        Me.dgvExpired.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvExpired.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExpired.EnableHeadersVisualStyles = False
        Me.dgvExpired.Location = New System.Drawing.Point(195, 127)
        Me.dgvExpired.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvExpired.Name = "dgvExpired"
        Me.dgvExpired.RowHeadersWidth = 82
        Me.dgvExpired.RowTemplate.Height = 33
        Me.dgvExpired.Size = New System.Drawing.Size(1555, 623)
        Me.dgvExpired.TabIndex = 12
        '
        'TabPage4
        '
        Me.TabPage4.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_05_1553491
        Me.TabPage4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage4.Controls.Add(Me.Label35)
        Me.TabPage4.Controls.Add(Me.Label34)
        Me.TabPage4.Controls.Add(Me.Label33)
        Me.TabPage4.Controls.Add(Me.Label32)
        Me.TabPage4.Controls.Add(Me.cboRecipeIngredient)
        Me.TabPage4.Controls.Add(Me.cboRecipeProduct)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.Label15)
        Me.TabPage4.Controls.Add(Me.Label16)
        Me.TabPage4.Controls.Add(Me.btnRecipeRemoveLine)
        Me.TabPage4.Controls.Add(Me.btnRecipeAddLine)
        Me.TabPage4.Controls.Add(Me.btnUpdateRecipe)
        Me.TabPage4.Controls.Add(Me.txtRecipeQty)
        Me.TabPage4.Controls.Add(Me.txtIngredientSearch)
        Me.TabPage4.Controls.Add(Me.txtIngredientName)
        Me.TabPage4.Controls.Add(Me.dgvRecipe)
        Me.TabPage4.Controls.Add(Me.lblIngredientCount)
        Me.TabPage4.Controls.Add(Me.btnClearIngredientSearch)
        Me.TabPage4.Controls.Add(Me.cboIngredientUnit)
        Me.TabPage4.Controls.Add(Me.Label12)
        Me.TabPage4.Controls.Add(Me.Label13)
        Me.TabPage4.Controls.Add(Me.btnDeleteIngredient)
        Me.TabPage4.Controls.Add(Me.btnUpdateIngredient)
        Me.TabPage4.Controls.Add(Me.btnAddIngredient)
        Me.TabPage4.Controls.Add(Me.btnClearIngredient)
        Me.TabPage4.Controls.Add(Me.dgvIngredients)
        Me.TabPage4.Location = New System.Drawing.Point(4, 154)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage4.Size = New System.Drawing.Size(1916, 897)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "INGREDIENTS AND RECIPE"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.ForeColor = System.Drawing.Color.Firebrick
        Me.Label35.Location = New System.Drawing.Point(1425, 516)
        Me.Label35.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(217, 20)
        Me.Label35.TabIndex = 72
        Me.Label35.Text = "RECIPE ADJUSTMENTS"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.ForeColor = System.Drawing.Color.Firebrick
        Me.Label34.Location = New System.Drawing.Point(1439, 107)
        Me.Label34.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(184, 20)
        Me.Label34.TabIndex = 71
        Me.Label34.Text = "PRODUCT RECIPES"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.Firebrick
        Me.Label33.Location = New System.Drawing.Point(360, 67)
        Me.Label33.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(133, 20)
        Me.Label33.TabIndex = 70
        Me.Label33.Text = "INGREDIENTS"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.Firebrick
        Me.Label32.Location = New System.Drawing.Point(196, 567)
        Me.Label32.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(204, 20)
        Me.Label32.TabIndex = 69
        Me.Label32.Text = "INGREDIENT DETAILS"
        '
        'cboRecipeIngredient
        '
        Me.cboRecipeIngredient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRecipeIngredient.ForeColor = System.Drawing.Color.Firebrick
        Me.cboRecipeIngredient.FormattingEnabled = True
        Me.cboRecipeIngredient.Location = New System.Drawing.Point(1224, 655)
        Me.cboRecipeIngredient.Margin = New System.Windows.Forms.Padding(2)
        Me.cboRecipeIngredient.Name = "cboRecipeIngredient"
        Me.cboRecipeIngredient.Size = New System.Drawing.Size(400, 28)
        Me.cboRecipeIngredient.TabIndex = 68
        '
        'cboRecipeProduct
        '
        Me.cboRecipeProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRecipeProduct.ForeColor = System.Drawing.Color.Firebrick
        Me.cboRecipeProduct.FormattingEnabled = True
        Me.cboRecipeProduct.Location = New System.Drawing.Point(1228, 578)
        Me.cboRecipeProduct.Margin = New System.Windows.Forms.Padding(2)
        Me.cboRecipeProduct.Name = "cboRecipeProduct"
        Me.cboRecipeProduct.Size = New System.Drawing.Size(400, 28)
        Me.cboRecipeProduct.TabIndex = 67
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Firebrick
        Me.Label14.Location = New System.Drawing.Point(1221, 713)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 20)
        Me.Label14.TabIndex = 66
        Me.Label14.Text = "QUANTITY"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Firebrick
        Me.Label15.Location = New System.Drawing.Point(1225, 634)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 20)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "INGREDIENT"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Firebrick
        Me.Label16.Location = New System.Drawing.Point(1226, 556)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(178, 20)
        Me.Label16.TabIndex = 64
        Me.Label16.Text = "RECIPE PRODUCT:"
        '
        'btnRecipeRemoveLine
        '
        Me.btnRecipeRemoveLine.BackgroundImage = CType(resources.GetObject("btnRecipeRemoveLine.BackgroundImage"), System.Drawing.Image)
        Me.btnRecipeRemoveLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRecipeRemoveLine.FlatAppearance.BorderSize = 0
        Me.btnRecipeRemoveLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecipeRemoveLine.ForeColor = System.Drawing.Color.Firebrick
        Me.btnRecipeRemoveLine.Location = New System.Drawing.Point(1647, 644)
        Me.btnRecipeRemoveLine.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRecipeRemoveLine.Name = "btnRecipeRemoveLine"
        Me.btnRecipeRemoveLine.Size = New System.Drawing.Size(174, 58)
        Me.btnRecipeRemoveLine.TabIndex = 63
        Me.btnRecipeRemoveLine.Text = "REMOVE ITEM"
        Me.btnRecipeRemoveLine.UseVisualStyleBackColor = True
        '
        'btnRecipeAddLine
        '
        Me.btnRecipeAddLine.BackgroundImage = CType(resources.GetObject("btnRecipeAddLine.BackgroundImage"), System.Drawing.Image)
        Me.btnRecipeAddLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRecipeAddLine.FlatAppearance.BorderSize = 0
        Me.btnRecipeAddLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecipeAddLine.ForeColor = System.Drawing.Color.Firebrick
        Me.btnRecipeAddLine.Location = New System.Drawing.Point(1647, 567)
        Me.btnRecipeAddLine.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRecipeAddLine.Name = "btnRecipeAddLine"
        Me.btnRecipeAddLine.Size = New System.Drawing.Size(174, 59)
        Me.btnRecipeAddLine.TabIndex = 62
        Me.btnRecipeAddLine.Text = "ADD ITEM"
        Me.btnRecipeAddLine.UseVisualStyleBackColor = True
        '
        'btnUpdateRecipe
        '
        Me.btnUpdateRecipe.BackgroundImage = CType(resources.GetObject("btnUpdateRecipe.BackgroundImage"), System.Drawing.Image)
        Me.btnUpdateRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUpdateRecipe.FlatAppearance.BorderSize = 0
        Me.btnUpdateRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateRecipe.ForeColor = System.Drawing.Color.Firebrick
        Me.btnUpdateRecipe.Location = New System.Drawing.Point(1647, 718)
        Me.btnUpdateRecipe.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdateRecipe.Name = "btnUpdateRecipe"
        Me.btnUpdateRecipe.Size = New System.Drawing.Size(174, 61)
        Me.btnUpdateRecipe.TabIndex = 61
        Me.btnUpdateRecipe.Text = "UPDATE QTY"
        Me.btnUpdateRecipe.UseVisualStyleBackColor = True
        '
        'txtRecipeQty
        '
        Me.txtRecipeQty.ForeColor = System.Drawing.Color.Firebrick
        Me.txtRecipeQty.Location = New System.Drawing.Point(1225, 735)
        Me.txtRecipeQty.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRecipeQty.Name = "txtRecipeQty"
        Me.txtRecipeQty.Size = New System.Drawing.Size(399, 27)
        Me.txtRecipeQty.TabIndex = 60
        '
        'txtIngredientSearch
        '
        Me.txtIngredientSearch.ForeColor = System.Drawing.Color.Firebrick
        Me.txtIngredientSearch.Location = New System.Drawing.Point(187, 100)
        Me.txtIngredientSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIngredientSearch.Name = "txtIngredientSearch"
        Me.txtIngredientSearch.Size = New System.Drawing.Size(518, 27)
        Me.txtIngredientSearch.TabIndex = 46
        '
        'txtIngredientName
        '
        Me.txtIngredientName.ForeColor = System.Drawing.Color.Firebrick
        Me.txtIngredientName.Location = New System.Drawing.Point(115, 629)
        Me.txtIngredientName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIngredientName.Name = "txtIngredientName"
        Me.txtIngredientName.Size = New System.Drawing.Size(399, 27)
        Me.txtIngredientName.TabIndex = 38
        '
        'dgvRecipe
        '
        Me.dgvRecipe.AllowUserToAddRows = False
        Me.dgvRecipe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRecipe.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvRecipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecipe.Location = New System.Drawing.Point(1198, 139)
        Me.dgvRecipe.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvRecipe.Name = "dgvRecipe"
        Me.dgvRecipe.RowHeadersWidth = 82
        Me.dgvRecipe.RowTemplate.Height = 33
        Me.dgvRecipe.Size = New System.Drawing.Size(623, 354)
        Me.dgvRecipe.TabIndex = 59
        '
        'lblIngredientCount
        '
        Me.lblIngredientCount.AutoSize = True
        Me.lblIngredientCount.ForeColor = System.Drawing.Color.Firebrick
        Me.lblIngredientCount.Location = New System.Drawing.Point(924, 104)
        Me.lblIngredientCount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblIngredientCount.Name = "lblIngredientCount"
        Me.lblIngredientCount.Size = New System.Drawing.Size(55, 20)
        Me.lblIngredientCount.TabIndex = 48
        Me.lblIngredientCount.Text = "count"
        '
        'btnClearIngredientSearch
        '
        Me.btnClearIngredientSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnClearIngredientSearch.BackgroundImage = CType(resources.GetObject("btnClearIngredientSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnClearIngredientSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClearIngredientSearch.FlatAppearance.BorderSize = 0
        Me.btnClearIngredientSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearIngredientSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearIngredientSearch.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClearIngredientSearch.Location = New System.Drawing.Point(707, 92)
        Me.btnClearIngredientSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClearIngredientSearch.Name = "btnClearIngredientSearch"
        Me.btnClearIngredientSearch.Size = New System.Drawing.Size(199, 43)
        Me.btnClearIngredientSearch.TabIndex = 47
        Me.btnClearIngredientSearch.Text = "CLEAR SEARCH"
        Me.btnClearIngredientSearch.UseVisualStyleBackColor = False
        '
        'cboIngredientUnit
        '
        Me.cboIngredientUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIngredientUnit.ForeColor = System.Drawing.Color.Firebrick
        Me.cboIngredientUnit.FormattingEnabled = True
        Me.cboIngredientUnit.Location = New System.Drawing.Point(113, 697)
        Me.cboIngredientUnit.Margin = New System.Windows.Forms.Padding(2)
        Me.cboIngredientUnit.Name = "cboIngredientUnit"
        Me.cboIngredientUnit.Size = New System.Drawing.Size(401, 28)
        Me.cboIngredientUnit.TabIndex = 45
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Firebrick
        Me.Label12.Location = New System.Drawing.Point(111, 673)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(175, 20)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "INGREDIENT UNIT:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Firebrick
        Me.Label13.Location = New System.Drawing.Point(111, 600)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(185, 20)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "INGREDIENT NAME:"
        '
        'btnDeleteIngredient
        '
        Me.btnDeleteIngredient.BackgroundImage = CType(resources.GetObject("btnDeleteIngredient.BackgroundImage"), System.Drawing.Image)
        Me.btnDeleteIngredient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDeleteIngredient.FlatAppearance.BorderSize = 0
        Me.btnDeleteIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteIngredient.ForeColor = System.Drawing.Color.Firebrick
        Me.btnDeleteIngredient.Location = New System.Drawing.Point(867, 675)
        Me.btnDeleteIngredient.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteIngredient.Name = "btnDeleteIngredient"
        Me.btnDeleteIngredient.Size = New System.Drawing.Size(246, 69)
        Me.btnDeleteIngredient.TabIndex = 42
        Me.btnDeleteIngredient.Text = "DELETE"
        Me.btnDeleteIngredient.UseVisualStyleBackColor = True
        '
        'btnUpdateIngredient
        '
        Me.btnUpdateIngredient.BackgroundImage = CType(resources.GetObject("btnUpdateIngredient.BackgroundImage"), System.Drawing.Image)
        Me.btnUpdateIngredient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUpdateIngredient.FlatAppearance.BorderSize = 0
        Me.btnUpdateIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateIngredient.ForeColor = System.Drawing.Color.Firebrick
        Me.btnUpdateIngredient.Location = New System.Drawing.Point(867, 584)
        Me.btnUpdateIngredient.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdateIngredient.Name = "btnUpdateIngredient"
        Me.btnUpdateIngredient.Size = New System.Drawing.Size(246, 69)
        Me.btnUpdateIngredient.TabIndex = 41
        Me.btnUpdateIngredient.Text = "UPDATE"
        Me.btnUpdateIngredient.UseVisualStyleBackColor = True
        '
        'btnAddIngredient
        '
        Me.btnAddIngredient.BackgroundImage = CType(resources.GetObject("btnAddIngredient.BackgroundImage"), System.Drawing.Image)
        Me.btnAddIngredient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddIngredient.FlatAppearance.BorderSize = 0
        Me.btnAddIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddIngredient.ForeColor = System.Drawing.Color.Firebrick
        Me.btnAddIngredient.Location = New System.Drawing.Point(582, 584)
        Me.btnAddIngredient.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddIngredient.Name = "btnAddIngredient"
        Me.btnAddIngredient.Size = New System.Drawing.Size(246, 69)
        Me.btnAddIngredient.TabIndex = 40
        Me.btnAddIngredient.Text = "ADD"
        Me.btnAddIngredient.UseVisualStyleBackColor = True
        '
        'btnClearIngredient
        '
        Me.btnClearIngredient.BackgroundImage = CType(resources.GetObject("btnClearIngredient.BackgroundImage"), System.Drawing.Image)
        Me.btnClearIngredient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClearIngredient.FlatAppearance.BorderSize = 0
        Me.btnClearIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearIngredient.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClearIngredient.Location = New System.Drawing.Point(582, 675)
        Me.btnClearIngredient.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClearIngredient.Name = "btnClearIngredient"
        Me.btnClearIngredient.Size = New System.Drawing.Size(246, 69)
        Me.btnClearIngredient.TabIndex = 39
        Me.btnClearIngredient.Text = "CLEAR"
        Me.btnClearIngredient.UseVisualStyleBackColor = True
        '
        'dgvIngredients
        '
        Me.dgvIngredients.AllowUserToAddRows = False
        Me.dgvIngredients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvIngredients.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIngredients.Location = New System.Drawing.Point(103, 139)
        Me.dgvIngredients.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvIngredients.Name = "dgvIngredients"
        Me.dgvIngredients.RowHeadersWidth = 82
        Me.dgvIngredients.RowTemplate.Height = 33
        Me.dgvIngredients.Size = New System.Drawing.Size(1091, 399)
        Me.dgvIngredients.TabIndex = 37
        '
        'TabPage5
        '
        Me.TabPage5.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_05_1553492
        Me.TabPage5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage5.Controls.Add(Me.Label36)
        Me.TabPage5.Controls.Add(Me.Label24)
        Me.TabPage5.Controls.Add(Me.Label23)
        Me.TabPage5.Controls.Add(Me.Label22)
        Me.TabPage5.Controls.Add(Me.Label21)
        Me.TabPage5.Controls.Add(Me.txtSupplierAddress)
        Me.TabPage5.Controls.Add(Me.txtSupplierContact)
        Me.TabPage5.Controls.Add(Me.txtSupplierContactName)
        Me.TabPage5.Controls.Add(Me.txtSupplierName)
        Me.TabPage5.Controls.Add(Me.btnDeleteSupplier)
        Me.TabPage5.Controls.Add(Me.btnUpdateSupplier)
        Me.TabPage5.Controls.Add(Me.btnAddSupplier)
        Me.TabPage5.Controls.Add(Me.btnClearSupplier)
        Me.TabPage5.Controls.Add(Me.dgvSuppliers)
        Me.TabPage5.Location = New System.Drawing.Point(4, 154)
        Me.TabPage5.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage5.Size = New System.Drawing.Size(1916, 897)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "SUPPLIERS"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label36.ForeColor = System.Drawing.Color.Firebrick
        Me.Label36.Location = New System.Drawing.Point(1360, 89)
        Me.Label36.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(295, 20)
        Me.Label36.TabIndex = 55
        Me.Label36.Text = "SUPPLIER INFO/ ADJUSTMENTS"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label24.ForeColor = System.Drawing.Color.Firebrick
        Me.Label24.Location = New System.Drawing.Point(1286, 430)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(104, 20)
        Me.Label24.TabIndex = 54
        Me.Label24.Text = "ADDRESS:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label23.ForeColor = System.Drawing.Color.Firebrick
        Me.Label23.Location = New System.Drawing.Point(1284, 332)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(102, 20)
        Me.Label23.TabIndex = 53
        Me.Label23.Text = "CONTACT:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label22.ForeColor = System.Drawing.Color.Firebrick
        Me.Label22.Location = New System.Drawing.Point(1284, 238)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(160, 20)
        Me.Label22.TabIndex = 52
        Me.Label22.Text = "CONTACT NAME:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label21.ForeColor = System.Drawing.Color.Firebrick
        Me.Label21.Location = New System.Drawing.Point(1284, 138)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(163, 20)
        Me.Label21.TabIndex = 51
        Me.Label21.Text = "SUPPLIER NAME:"
        '
        'txtSupplierAddress
        '
        Me.txtSupplierAddress.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtSupplierAddress.ForeColor = System.Drawing.Color.Firebrick
        Me.txtSupplierAddress.Location = New System.Drawing.Point(1288, 463)
        Me.txtSupplierAddress.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSupplierAddress.Name = "txtSupplierAddress"
        Me.txtSupplierAddress.Size = New System.Drawing.Size(446, 27)
        Me.txtSupplierAddress.TabIndex = 50
        '
        'txtSupplierContact
        '
        Me.txtSupplierContact.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtSupplierContact.ForeColor = System.Drawing.Color.Firebrick
        Me.txtSupplierContact.Location = New System.Drawing.Point(1288, 360)
        Me.txtSupplierContact.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSupplierContact.Name = "txtSupplierContact"
        Me.txtSupplierContact.Size = New System.Drawing.Size(446, 27)
        Me.txtSupplierContact.TabIndex = 49
        '
        'txtSupplierContactName
        '
        Me.txtSupplierContactName.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtSupplierContactName.ForeColor = System.Drawing.Color.Firebrick
        Me.txtSupplierContactName.Location = New System.Drawing.Point(1288, 268)
        Me.txtSupplierContactName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSupplierContactName.Name = "txtSupplierContactName"
        Me.txtSupplierContactName.Size = New System.Drawing.Size(446, 27)
        Me.txtSupplierContactName.TabIndex = 48
        '
        'txtSupplierName
        '
        Me.txtSupplierName.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtSupplierName.ForeColor = System.Drawing.Color.Firebrick
        Me.txtSupplierName.Location = New System.Drawing.Point(1288, 168)
        Me.txtSupplierName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSupplierName.Name = "txtSupplierName"
        Me.txtSupplierName.Size = New System.Drawing.Size(446, 27)
        Me.txtSupplierName.TabIndex = 47
        '
        'btnDeleteSupplier
        '
        Me.btnDeleteSupplier.BackColor = System.Drawing.Color.Transparent
        Me.btnDeleteSupplier.BackgroundImage = CType(resources.GetObject("btnDeleteSupplier.BackgroundImage"), System.Drawing.Image)
        Me.btnDeleteSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDeleteSupplier.FlatAppearance.BorderSize = 0
        Me.btnDeleteSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteSupplier.ForeColor = System.Drawing.Color.Firebrick
        Me.btnDeleteSupplier.Location = New System.Drawing.Point(1553, 641)
        Me.btnDeleteSupplier.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteSupplier.Name = "btnDeleteSupplier"
        Me.btnDeleteSupplier.Size = New System.Drawing.Size(246, 69)
        Me.btnDeleteSupplier.TabIndex = 46
        Me.btnDeleteSupplier.Text = "DELETE"
        Me.btnDeleteSupplier.UseVisualStyleBackColor = False
        '
        'btnUpdateSupplier
        '
        Me.btnUpdateSupplier.BackColor = System.Drawing.Color.Transparent
        Me.btnUpdateSupplier.BackgroundImage = CType(resources.GetObject("btnUpdateSupplier.BackgroundImage"), System.Drawing.Image)
        Me.btnUpdateSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUpdateSupplier.FlatAppearance.BorderSize = 0
        Me.btnUpdateSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateSupplier.ForeColor = System.Drawing.Color.Firebrick
        Me.btnUpdateSupplier.Location = New System.Drawing.Point(1553, 550)
        Me.btnUpdateSupplier.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdateSupplier.Name = "btnUpdateSupplier"
        Me.btnUpdateSupplier.Size = New System.Drawing.Size(246, 69)
        Me.btnUpdateSupplier.TabIndex = 45
        Me.btnUpdateSupplier.Text = "UPDATE"
        Me.btnUpdateSupplier.UseVisualStyleBackColor = False
        '
        'btnAddSupplier
        '
        Me.btnAddSupplier.BackColor = System.Drawing.Color.Transparent
        Me.btnAddSupplier.BackgroundImage = CType(resources.GetObject("btnAddSupplier.BackgroundImage"), System.Drawing.Image)
        Me.btnAddSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddSupplier.FlatAppearance.BorderSize = 0
        Me.btnAddSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddSupplier.ForeColor = System.Drawing.Color.Firebrick
        Me.btnAddSupplier.Location = New System.Drawing.Point(1268, 550)
        Me.btnAddSupplier.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddSupplier.Name = "btnAddSupplier"
        Me.btnAddSupplier.Size = New System.Drawing.Size(246, 69)
        Me.btnAddSupplier.TabIndex = 44
        Me.btnAddSupplier.Text = "ADD"
        Me.btnAddSupplier.UseVisualStyleBackColor = False
        '
        'btnClearSupplier
        '
        Me.btnClearSupplier.BackColor = System.Drawing.Color.Transparent
        Me.btnClearSupplier.BackgroundImage = CType(resources.GetObject("btnClearSupplier.BackgroundImage"), System.Drawing.Image)
        Me.btnClearSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClearSupplier.FlatAppearance.BorderSize = 0
        Me.btnClearSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearSupplier.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClearSupplier.Location = New System.Drawing.Point(1268, 641)
        Me.btnClearSupplier.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClearSupplier.Name = "btnClearSupplier"
        Me.btnClearSupplier.Size = New System.Drawing.Size(246, 69)
        Me.btnClearSupplier.TabIndex = 43
        Me.btnClearSupplier.Text = "CLEAR"
        Me.btnClearSupplier.UseVisualStyleBackColor = False
        '
        'dgvSuppliers
        '
        Me.dgvSuppliers.AllowUserToAddRows = False
        Me.dgvSuppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSuppliers.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSuppliers.Location = New System.Drawing.Point(110, 69)
        Me.dgvSuppliers.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvSuppliers.Name = "dgvSuppliers"
        Me.dgvSuppliers.RowHeadersWidth = 82
        Me.dgvSuppliers.RowTemplate.Height = 33
        Me.dgvSuppliers.Size = New System.Drawing.Size(1121, 661)
        Me.dgvSuppliers.TabIndex = 0
        '
        'frmInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.TabControl1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmInventory"
        Me.Text = "Form6"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.pbProductPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvBatches, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgvExpired, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.dgvRecipe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvIngredients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.dgvSuppliers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents cboRecipeIngredient As ComboBox
    Friend WithEvents cboRecipeProduct As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents btnRecipeRemoveLine As Button
    Friend WithEvents btnRecipeAddLine As Button
    Friend WithEvents btnUpdateRecipe As Button
    Friend WithEvents txtRecipeQty As TextBox
    Friend WithEvents txtIngredientSearch As TextBox
    Friend WithEvents txtIngredientName As TextBox
    Friend WithEvents dgvRecipe As DataGridView
    Friend WithEvents lblIngredientCount As Label
    Friend WithEvents btnClearIngredientSearch As Button
    Friend WithEvents cboIngredientUnit As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents btnDeleteIngredient As Button
    Friend WithEvents btnUpdateIngredient As Button
    Friend WithEvents btnAddIngredient As Button
    Friend WithEvents btnClearIngredient As Button
    Friend WithEvents dgvIngredients As DataGridView
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents btnDeleteExpired As Button
    Friend WithEvents lblExpiredCount As Label
    Friend WithEvents dgvExpired As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Button1 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCostPerUnit As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvBatches As DataGridView
    Friend WithEvents lblTotalCost As Label
    Friend WithEvents cboFilterProduct As ComboBox
    Friend WithEvents lblCurrentStock As Label
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents dtpExpiry As DateTimePicker
    Friend WithEvents cboProduct As ComboBox
    Friend WithEvents btnFilter As Button
    Friend WithEvents btnRestock As Button
    Friend WithEvents btnClearFilter As Button
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents lblProductCount As Label
    Friend WithEvents btnClearProductSearch As Button
    Friend WithEvents txtProductSearch As TextBox
    Friend WithEvents txtProductPrice As TextBox
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents cboProductCategory As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnDeleteProduct As Button
    Friend WithEvents btnUpdateProduct As Button
    Friend WithEvents btnAddProduct As Button
    Friend WithEvents btnClearProduct As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents dgvSuppliers As DataGridView
    Friend WithEvents btnDeleteSupplier As Button
    Friend WithEvents btnUpdateSupplier As Button
    Friend WithEvents btnAddSupplier As Button
    Friend WithEvents btnClearSupplier As Button
    Friend WithEvents txtSupplierName As TextBox
    Friend WithEvents txtSupplierAddress As TextBox
    Friend WithEvents txtSupplierContact As TextBox
    Friend WithEvents txtSupplierContactName As TextBox
    Friend WithEvents cboPackSize As ComboBox
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents cboSupplier As ComboBox
    Friend WithEvents txtBatchQty As TextBox
    Friend WithEvents dtpBatchExpiry As DateTimePicker
    Friend WithEvents txtBatchCost As TextBox
    Friend WithEvents txtAdjustNotes As TextBox
    Friend WithEvents cboAdjustReason As ComboBox
    Friend WithEvents btnDeleteBatch As Button
    Friend WithEvents btnUpdateBatch As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents pbProductPreview As PictureBox
    Friend WithEvents btnUploadPhoto As Button
    Friend WithEvents btnRemovePhoto As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Label26 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
End Class
