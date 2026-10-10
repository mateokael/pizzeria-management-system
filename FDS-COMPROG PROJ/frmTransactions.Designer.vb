<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTransactions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransactions))
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dgvTransactions = New System.Windows.Forms.DataGridView()
        Me.dgvTransactionDetails = New System.Windows.Forms.DataGridView()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnClearFilter = New System.Windows.Forms.Button()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnReprint = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOrder = New System.Windows.Forms.Button()
        Me.cboEditProduct = New System.Windows.Forms.ComboBox()
        Me.lblEditingInfo = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.cboFilterCustomer = New System.Windows.Forms.ComboBox()
        Me.numEditQty = New System.Windows.Forms.NumericUpDown()
        Me.btnDeleteItem = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblEditTotal = New System.Windows.Forms.Label()
        Me.btnConfirmPayment = New System.Windows.Forms.Button()
        Me.btnAddItem = New System.Windows.Forms.Button()
        CType(Me.dgvTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTransactionDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numEditQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Location = New System.Drawing.Point(212, 174)
        Me.dtpFrom.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(345, 27)
        Me.dtpFrom.TabIndex = 0
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Location = New System.Drawing.Point(212, 144)
        Me.dtpTo.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(345, 27)
        Me.dtpTo.TabIndex = 1
        '
        'dgvTransactions
        '
        Me.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTransactions.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransactions.EnableHeadersVisualStyles = False
        Me.dgvTransactions.Location = New System.Drawing.Point(123, 234)
        Me.dgvTransactions.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvTransactions.Name = "dgvTransactions"
        Me.dgvTransactions.RowHeadersWidth = 82
        Me.dgvTransactions.RowTemplate.Height = 33
        Me.dgvTransactions.Size = New System.Drawing.Size(949, 625)
        Me.dgvTransactions.TabIndex = 2
        '
        'dgvTransactionDetails
        '
        Me.dgvTransactionDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTransactionDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransactionDetails.Location = New System.Drawing.Point(1133, 183)
        Me.dgvTransactionDetails.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvTransactionDetails.Name = "dgvTransactionDetails"
        Me.dgvTransactionDetails.RowHeadersWidth = 82
        Me.dgvTransactionDetails.RowTemplate.Height = 33
        Me.dgvTransactionDetails.Size = New System.Drawing.Size(677, 435)
        Me.dgvTransactionDetails.TabIndex = 3
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblTotal.Location = New System.Drawing.Point(662, 152)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(56, 22)
        Me.lblTotal.TabIndex = 4
        Me.lblTotal.Text = "Total"
        '
        'btnFilter
        '
        Me.btnFilter.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_05_1445351
        Me.btnFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFilter.FlatAppearance.BorderSize = 0
        Me.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnFilter.Location = New System.Drawing.Point(645, 176)
        Me.btnFilter.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(178, 54)
        Me.btnFilter.TabIndex = 5
        Me.btnFilter.Text = "FILTER"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'btnClearFilter
        '
        Me.btnClearFilter.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_05_144535
        Me.btnClearFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClearFilter.FlatAppearance.BorderSize = 0
        Me.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearFilter.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnClearFilter.Location = New System.Drawing.Point(827, 174)
        Me.btnClearFilter.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Size = New System.Drawing.Size(179, 56)
        Me.btnClearFilter.TabIndex = 6
        Me.btnClearFilter.Text = "CLEAR FILTER"
        Me.btnClearFilter.UseVisualStyleBackColor = True
        '
        'btnVoid
        '
        Me.btnVoid.BackColor = System.Drawing.Color.Transparent
        Me.btnVoid.BackgroundImage = CType(resources.GetObject("btnVoid.BackgroundImage"), System.Drawing.Image)
        Me.btnVoid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVoid.FlatAppearance.BorderSize = 0
        Me.btnVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoid.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoid.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnVoid.Location = New System.Drawing.Point(326, 874)
        Me.btnVoid.Margin = New System.Windows.Forms.Padding(2)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(177, 65)
        Me.btnVoid.TabIndex = 7
        Me.btnVoid.Text = "VOID ORDER"
        Me.btnVoid.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.BackgroundImage = CType(resources.GetObject("btnDelete.BackgroundImage"), System.Drawing.Image)
        Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnDelete.Location = New System.Drawing.Point(898, 875)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(174, 65)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnReprint
        '
        Me.btnReprint.BackColor = System.Drawing.Color.Transparent
        Me.btnReprint.BackgroundImage = CType(resources.GetObject("btnReprint.BackgroundImage"), System.Drawing.Image)
        Me.btnReprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReprint.FlatAppearance.BorderSize = 0
        Me.btnReprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprint.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnReprint.Location = New System.Drawing.Point(1257, 845)
        Me.btnReprint.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReprint.Name = "btnReprint"
        Me.btnReprint.Size = New System.Drawing.Size(267, 113)
        Me.btnReprint.TabIndex = 9
        Me.btnReprint.Text = "REPRINT RECEIPT"
        Me.btnReprint.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_05_142608
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.FlatAppearance.BorderSize = 0
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Location = New System.Drawing.Point(94, 9)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(95, 79)
        Me.btnBack.TabIndex = 10
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label2.Location = New System.Drawing.Point(121, 144)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "FROM:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label1.Location = New System.Drawing.Point(121, 176)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 20)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "TO:"
        '
        'btnOrder
        '
        Me.btnOrder.BackColor = System.Drawing.Color.Transparent
        Me.btnOrder.BackgroundImage = CType(resources.GetObject("btnOrder.BackgroundImage"), System.Drawing.Image)
        Me.btnOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOrder.FlatAppearance.BorderSize = 0
        Me.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrder.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnOrder.Location = New System.Drawing.Point(123, 874)
        Me.btnOrder.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOrder.Name = "btnOrder"
        Me.btnOrder.Size = New System.Drawing.Size(199, 66)
        Me.btnOrder.TabIndex = 14
        Me.btnOrder.Text = "CREATE ORDER"
        Me.btnOrder.UseVisualStyleBackColor = False
        '
        'cboEditProduct
        '
        Me.cboEditProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEditProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEditProduct.ForeColor = System.Drawing.Color.DarkGreen
        Me.cboEditProduct.FormattingEnabled = True
        Me.cboEditProduct.Location = New System.Drawing.Point(1132, 717)
        Me.cboEditProduct.Margin = New System.Windows.Forms.Padding(2)
        Me.cboEditProduct.Name = "cboEditProduct"
        Me.cboEditProduct.Size = New System.Drawing.Size(265, 28)
        Me.cboEditProduct.TabIndex = 15
        '
        'lblEditingInfo
        '
        Me.lblEditingInfo.AutoSize = True
        Me.lblEditingInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblEditingInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditingInfo.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblEditingInfo.Location = New System.Drawing.Point(1010, 154)
        Me.lblEditingInfo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEditingInfo.Name = "lblEditingInfo"
        Me.lblEditingInfo.Size = New System.Drawing.Size(104, 20)
        Me.lblEditingInfo.TabIndex = 19
        Me.lblEditingInfo.Text = "Editing Info"
        '
        'btnUpdate
        '
        Me.btnUpdate.BackgroundImage = CType(resources.GetObject("btnUpdate.BackgroundImage"), System.Drawing.Image)
        Me.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnUpdate.Location = New System.Drawing.Point(1120, 622)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(171, 67)
        Me.btnUpdate.TabIndex = 20
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'lblStock
        '
        Me.lblStock.AutoSize = True
        Me.lblStock.BackColor = System.Drawing.Color.Transparent
        Me.lblStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStock.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblStock.Location = New System.Drawing.Point(1420, 725)
        Me.lblStock.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(56, 20)
        Me.lblStock.TabIndex = 21
        Me.lblStock.Text = "Stock"
        '
        'cboFilterCustomer
        '
        Me.cboFilterCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFilterCustomer.ForeColor = System.Drawing.Color.DarkGreen
        Me.cboFilterCustomer.FormattingEnabled = True
        Me.cboFilterCustomer.Location = New System.Drawing.Point(277, 109)
        Me.cboFilterCustomer.Margin = New System.Windows.Forms.Padding(2)
        Me.cboFilterCustomer.Name = "cboFilterCustomer"
        Me.cboFilterCustomer.Size = New System.Drawing.Size(280, 28)
        Me.cboFilterCustomer.TabIndex = 22
        '
        'numEditQty
        '
        Me.numEditQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numEditQty.ForeColor = System.Drawing.Color.DarkGreen
        Me.numEditQty.Location = New System.Drawing.Point(1132, 792)
        Me.numEditQty.Margin = New System.Windows.Forms.Padding(2)
        Me.numEditQty.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numEditQty.Name = "numEditQty"
        Me.numEditQty.Size = New System.Drawing.Size(263, 27)
        Me.numEditQty.TabIndex = 23
        Me.numEditQty.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnDeleteItem
        '
        Me.btnDeleteItem.BackgroundImage = CType(resources.GetObject("btnDeleteItem.BackgroundImage"), System.Drawing.Image)
        Me.btnDeleteItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDeleteItem.FlatAppearance.BorderSize = 0
        Me.btnDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteItem.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnDeleteItem.Location = New System.Drawing.Point(1616, 622)
        Me.btnDeleteItem.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteItem.Name = "btnDeleteItem"
        Me.btnDeleteItem.Size = New System.Drawing.Size(187, 67)
        Me.btnDeleteItem.TabIndex = 24
        Me.btnDeleteItem.Text = "DELETE ITEM"
        Me.btnDeleteItem.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label4.Location = New System.Drawing.Point(1129, 695)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(205, 20)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "EDIT/ ADD PRODUCT:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label5.Location = New System.Drawing.Point(1128, 770)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 20)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "EDIT QUANTITY:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label6.Location = New System.Drawing.Point(119, 112)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 20)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "CUSTOMERS:"
        '
        'lblEditTotal
        '
        Me.lblEditTotal.AutoSize = True
        Me.lblEditTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblEditTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblEditTotal.Location = New System.Drawing.Point(1414, 793)
        Me.lblEditTotal.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEditTotal.Name = "lblEditTotal"
        Me.lblEditTotal.Size = New System.Drawing.Size(68, 20)
        Me.lblEditTotal.TabIndex = 29
        Me.lblEditTotal.Text = "TOTAL"
        '
        'btnConfirmPayment
        '
        Me.btnConfirmPayment.BackColor = System.Drawing.Color.Transparent
        Me.btnConfirmPayment.BackgroundImage = CType(resources.GetObject("btnConfirmPayment.BackgroundImage"), System.Drawing.Image)
        Me.btnConfirmPayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfirmPayment.FlatAppearance.BorderSize = 0
        Me.btnConfirmPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirmPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmPayment.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnConfirmPayment.Location = New System.Drawing.Point(1528, 843)
        Me.btnConfirmPayment.Margin = New System.Windows.Forms.Padding(2)
        Me.btnConfirmPayment.Name = "btnConfirmPayment"
        Me.btnConfirmPayment.Size = New System.Drawing.Size(275, 115)
        Me.btnConfirmPayment.TabIndex = 30
        Me.btnConfirmPayment.Text = "CONFIRM PAYMENT"
        Me.btnConfirmPayment.UseVisualStyleBackColor = False
        '
        'btnAddItem
        '
        Me.btnAddItem.BackgroundImage = CType(resources.GetObject("btnAddItem.BackgroundImage"), System.Drawing.Image)
        Me.btnAddItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddItem.FlatAppearance.BorderSize = 0
        Me.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddItem.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnAddItem.Location = New System.Drawing.Point(1284, 622)
        Me.btnAddItem.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(171, 67)
        Me.btnAddItem.TabIndex = 31
        Me.btnAddItem.Text = "ADD"
        Me.btnAddItem.UseVisualStyleBackColor = True
        '
        'frmTransactions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_05_142512
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.btnAddItem)
        Me.Controls.Add(Me.btnConfirmPayment)
        Me.Controls.Add(Me.lblEditTotal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnDeleteItem)
        Me.Controls.Add(Me.numEditQty)
        Me.Controls.Add(Me.cboFilterCustomer)
        Me.Controls.Add(Me.lblStock)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.lblEditingInfo)
        Me.Controls.Add(Me.cboEditProduct)
        Me.Controls.Add(Me.btnOrder)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnReprint)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnVoid)
        Me.Controls.Add(Me.btnClearFilter)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.dgvTransactionDetails)
        Me.Controls.Add(Me.dgvTransactions)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmTransactions"
        Me.Text = "Form8"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTransactionDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numEditQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents dgvTransactions As DataGridView
    Friend WithEvents dgvTransactionDetails As DataGridView
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnFilter As Button
    Friend WithEvents btnClearFilter As Button
    Friend WithEvents btnVoid As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnReprint As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnOrder As Button
    Friend WithEvents cboEditProduct As ComboBox
    Friend WithEvents lblEditingInfo As Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents lblStock As Label
    Friend WithEvents cboFilterCustomer As ComboBox
    Friend WithEvents numEditQty As NumericUpDown
    Friend WithEvents btnDeleteItem As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblEditTotal As Label
    Friend WithEvents btnConfirmPayment As Button
    Friend WithEvents btnAddItem As Button
End Class
