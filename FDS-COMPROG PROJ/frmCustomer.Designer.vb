<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomers))
        Me.dgvCustomers = New System.Windows.Forms.DataGridView()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtContactNo = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnClearSearch = New System.Windows.Forms.Button()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCustomers
        '
        Me.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCustomers.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomers.EnableHeadersVisualStyles = False
        Me.dgvCustomers.Location = New System.Drawing.Point(186, 400)
        Me.dgvCustomers.Name = "dgvCustomers"
        Me.dgvCustomers.RowHeadersWidth = 82
        Me.dgvCustomers.RowTemplate.Height = 33
        Me.dgvCustomers.Size = New System.Drawing.Size(1497, 1055)
        Me.dgvCustomers.TabIndex = 0
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtFirstName.Location = New System.Drawing.Point(1800, 530)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(727, 38)
        Me.txtFirstName.TabIndex = 1
        '
        'txtContactNo
        '
        Me.txtContactNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactNo.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtContactNo.Location = New System.Drawing.Point(1803, 872)
        Me.txtContactNo.Name = "txtContactNo"
        Me.txtContactNo.Size = New System.Drawing.Size(727, 38)
        Me.txtContactNo.TabIndex = 2
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtLastName.Location = New System.Drawing.Point(1802, 706)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(727, 38)
        Me.txtLastName.TabIndex = 3
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(676, 338)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(805, 38)
        Me.txtSearch.TabIndex = 4
        '
        'btnClearSearch
        '
        Me.btnClearSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnClearSearch.BackgroundImage = CType(resources.GetObject("btnClearSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnClearSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClearSearch.FlatAppearance.BorderSize = 0
        Me.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearSearch.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnClearSearch.Location = New System.Drawing.Point(406, 305)
        Me.btnClearSearch.Name = "btnClearSearch"
        Me.btnClearSearch.Size = New System.Drawing.Size(214, 86)
        Me.btnClearSearch.TabIndex = 6
        Me.btnClearSearch.Text = "CLEAR SEARCH"
        Me.btnClearSearch.UseVisualStyleBackColor = False
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.BackColor = System.Drawing.Color.Transparent
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblCount.Location = New System.Drawing.Point(680, 302)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(108, 32)
        Me.lblCount.TabIndex = 8
        Me.lblCount.Text = "Label1"
        '
        'btnBack
        '
        Me.btnBack.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_05_142608
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.FlatAppearance.BorderSize = 0
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Location = New System.Drawing.Point(186, 31)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(156, 139)
        Me.btnBack.TabIndex = 9
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Black
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnAdd.Location = New System.Drawing.Point(1767, 994)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(429, 150)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Black
        Me.btnUpdate.BackgroundImage = CType(resources.GetObject("btnUpdate.BackgroundImage"), System.Drawing.Image)
        Me.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnUpdate.Location = New System.Drawing.Point(2224, 994)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(429, 150)
        Me.btnUpdate.TabIndex = 11
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Black
        Me.btnDelete.BackgroundImage = CType(resources.GetObject("btnDelete.BackgroundImage"), System.Drawing.Image)
        Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnDelete.Location = New System.Drawing.Point(2224, 1150)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(429, 150)
        Me.btnDelete.TabIndex = 12
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label1.Location = New System.Drawing.Point(1796, 477)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 32)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "FIRST NAME:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label2.Location = New System.Drawing.Point(1797, 656)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 32)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "LAST NAME:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label3.Location = New System.Drawing.Point(1797, 822)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(301, 32)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "CONTACT NUMBER:"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Button1.Location = New System.Drawing.Point(1767, 1150)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(429, 150)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "CLEAR"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmCustomers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_05_142512
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(2886, 1648)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.btnClearSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtContactNo)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.dgvCustomers)
        Me.DoubleBuffered = True
        Me.Name = "frmCustomers"
        Me.Text = "frmCustomer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvCustomers As DataGridView
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtContactNo As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnClearSearch As Button
    Friend WithEvents lblCount As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
End Class
