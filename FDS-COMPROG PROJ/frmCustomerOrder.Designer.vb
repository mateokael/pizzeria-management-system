<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCustomerOrder
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
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnPlaceOrder = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.dgvOrder = New System.Windows.Forms.DataGridView()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtContactNo = New System.Windows.Forms.MaskedTextBox()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.flpMenu = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblSelectedProduct = New System.Windows.Forms.Label()
        Me.nudQty = New System.Windows.Forms.NumericUpDown()
        CType(Me.dgvOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Transparent
        Me.btnAdd.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_11_091352
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(728, 816)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(253, 117)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_11_091520
        Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(1777, 181)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(231, 105)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnPlaceOrder
        '
        Me.btnPlaceOrder.BackColor = System.Drawing.Color.Transparent
        Me.btnPlaceOrder.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_11_091634
        Me.btnPlaceOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPlaceOrder.FlatAppearance.BorderSize = 0
        Me.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlaceOrder.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlaceOrder.Location = New System.Drawing.Point(1766, 571)
        Me.btnPlaceOrder.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPlaceOrder.Name = "btnPlaceOrder"
        Me.btnPlaceOrder.Size = New System.Drawing.Size(310, 147)
        Me.btnPlaceOrder.TabIndex = 4
        Me.btnPlaceOrder.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_11_090031
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(83, 77)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(230, 105)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Firebrick
        Me.lblTotal.Location = New System.Drawing.Point(1009, 828)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(164, 25)
        Me.lblTotal.TabIndex = 6
        Me.lblTotal.Text = "ORDER TOTAL"
        '
        'dgvOrder
        '
        Me.dgvOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvOrder.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrder.GridColor = System.Drawing.Color.Firebrick
        Me.dgvOrder.Location = New System.Drawing.Point(1014, 181)
        Me.dgvOrder.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvOrder.Name = "dgvOrder"
        Me.dgvOrder.RowHeadersWidth = 82
        Me.dgvOrder.RowTemplate.Height = 33
        Me.dgvOrder.Size = New System.Drawing.Size(748, 537)
        Me.dgvOrder.TabIndex = 9
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(1006, 771)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(159, 27)
        Me.txtFirstName.TabIndex = 10
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(1194, 770)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(251, 27)
        Me.txtLastName.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Firebrick
        Me.Label1.Location = New System.Drawing.Point(1005, 741)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 25)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "FIRST NAME:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Firebrick
        Me.Label2.Location = New System.Drawing.Point(1189, 741)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(275, 25)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "LAST NAME (OPTIONAL):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Firebrick
        Me.Label3.Location = New System.Drawing.Point(1480, 741)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(302, 25)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "CONTACT NO. (OPTIONAL):"
        '
        'txtContactNo
        '
        Me.txtContactNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactNo.Location = New System.Drawing.Point(1485, 769)
        Me.txtContactNo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContactNo.Name = "txtContactNo"
        Me.txtContactNo.Size = New System.Drawing.Size(251, 27)
        Me.txtContactNo.TabIndex = 14
        '
        'cboCategory
        '
        Me.cboCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.ForeColor = System.Drawing.Color.Firebrick
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(582, 117)
        Me.cboCategory.Margin = New System.Windows.Forms.Padding(2)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(375, 28)
        Me.cboCategory.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Firebrick
        Me.Label4.Location = New System.Drawing.Point(427, 116)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 25)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "CATEGORY:"
        '
        'flpMenu
        '
        Me.flpMenu.AutoScroll = True
        Me.flpMenu.BackColor = System.Drawing.Color.Linen
        Me.flpMenu.Location = New System.Drawing.Point(83, 181)
        Me.flpMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.flpMenu.Name = "flpMenu"
        Me.flpMenu.Size = New System.Drawing.Size(898, 620)
        Me.flpMenu.TabIndex = 18
        '
        'lblSelectedProduct
        '
        Me.lblSelectedProduct.AutoSize = True
        Me.lblSelectedProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedProduct.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblSelectedProduct.Location = New System.Drawing.Point(79, 828)
        Me.lblSelectedProduct.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSelectedProduct.Name = "lblSelectedProduct"
        Me.lblSelectedProduct.Size = New System.Drawing.Size(72, 24)
        Me.lblSelectedProduct.TabIndex = 19
        Me.lblSelectedProduct.Text = "Label5"
        '
        'nudQty
        '
        Me.nudQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudQty.Location = New System.Drawing.Point(522, 828)
        Me.nudQty.Margin = New System.Windows.Forms.Padding(2)
        Me.nudQty.Name = "nudQty"
        Me.nudQty.Size = New System.Drawing.Size(177, 45)
        Me.nudQty.TabIndex = 20
        '
        'frmCustomerOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_11_091001
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.nudQty)
        Me.Controls.Add(Me.lblSelectedProduct)
        Me.Controls.Add(Me.flpMenu)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtContactNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.dgvOrder)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnPlaceOrder)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmCustomerOrder"
        Me.Text = "frmCustomerOrder"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnPlaceOrder As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblTotal As Label
    Friend WithEvents dgvOrder As DataGridView
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtLastName As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtContactNo As MaskedTextBox
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents flpMenu As FlowLayoutPanel
    Friend WithEvents lblSelectedProduct As Label
    Friend WithEvents nudQty As NumericUpDown
End Class
