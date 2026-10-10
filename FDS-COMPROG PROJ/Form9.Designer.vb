<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReports))
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.btnComputeIncome = New System.Windows.Forms.Button()
        Me.lblIncome = New System.Windows.Forms.Label()
        Me.btnReport1 = New System.Windows.Forms.Button()
        Me.btnReport2 = New System.Windows.Forms.Button()
        Me.btnReport3 = New System.Windows.Forms.Button()
        Me.btnReport4 = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Location = New System.Drawing.Point(206, 649)
        Me.dtpFrom.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(377, 28)
        Me.dtpFrom.TabIndex = 0
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Location = New System.Drawing.Point(206, 688)
        Me.dtpTo.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(377, 28)
        Me.dtpTo.TabIndex = 1
        '
        'btnComputeIncome
        '
        Me.btnComputeIncome.BackColor = System.Drawing.Color.Transparent
        Me.btnComputeIncome.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_05_144926
        Me.btnComputeIncome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnComputeIncome.FlatAppearance.BorderSize = 0
        Me.btnComputeIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnComputeIncome.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComputeIncome.ForeColor = System.Drawing.Color.Firebrick
        Me.btnComputeIncome.Location = New System.Drawing.Point(165, 788)
        Me.btnComputeIncome.Margin = New System.Windows.Forms.Padding(2)
        Me.btnComputeIncome.Name = "btnComputeIncome"
        Me.btnComputeIncome.Size = New System.Drawing.Size(385, 150)
        Me.btnComputeIncome.TabIndex = 2
        Me.btnComputeIncome.Text = "COMPUTE INCOME"
        Me.btnComputeIncome.UseVisualStyleBackColor = False
        '
        'lblIncome
        '
        Me.lblIncome.AutoSize = True
        Me.lblIncome.BackColor = System.Drawing.Color.Transparent
        Me.lblIncome.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncome.ForeColor = System.Drawing.Color.Firebrick
        Me.lblIncome.Location = New System.Drawing.Point(177, 762)
        Me.lblIncome.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblIncome.Name = "lblIncome"
        Me.lblIncome.Size = New System.Drawing.Size(196, 24)
        Me.lblIncome.TabIndex = 3
        Me.lblIncome.Text = "Total Income: ₱0.00"
        '
        'btnReport1
        '
        Me.btnReport1.BackColor = System.Drawing.Color.Transparent
        Me.btnReport1.BackgroundImage = CType(resources.GetObject("btnReport1.BackgroundImage"), System.Drawing.Image)
        Me.btnReport1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReport1.FlatAppearance.BorderSize = 0
        Me.btnReport1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReport1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport1.ForeColor = System.Drawing.Color.Firebrick
        Me.btnReport1.Location = New System.Drawing.Point(675, 200)
        Me.btnReport1.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReport1.Name = "btnReport1"
        Me.btnReport1.Size = New System.Drawing.Size(427, 195)
        Me.btnReport1.TabIndex = 4
        Me.btnReport1.Text = "Best Selling Products"
        Me.btnReport1.UseVisualStyleBackColor = False
        '
        'btnReport2
        '
        Me.btnReport2.BackColor = System.Drawing.Color.Transparent
        Me.btnReport2.BackgroundImage = CType(resources.GetObject("btnReport2.BackgroundImage"), System.Drawing.Image)
        Me.btnReport2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReport2.FlatAppearance.BorderSize = 0
        Me.btnReport2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReport2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport2.ForeColor = System.Drawing.Color.Firebrick
        Me.btnReport2.Location = New System.Drawing.Point(1124, 200)
        Me.btnReport2.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReport2.Name = "btnReport2"
        Me.btnReport2.Size = New System.Drawing.Size(427, 195)
        Me.btnReport2.TabIndex = 5
        Me.btnReport2.Text = "Sales Summary by Date"
        Me.btnReport2.UseVisualStyleBackColor = False
        '
        'btnReport3
        '
        Me.btnReport3.BackColor = System.Drawing.Color.Transparent
        Me.btnReport3.BackgroundImage = CType(resources.GetObject("btnReport3.BackgroundImage"), System.Drawing.Image)
        Me.btnReport3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReport3.FlatAppearance.BorderSize = 0
        Me.btnReport3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReport3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport3.ForeColor = System.Drawing.Color.Firebrick
        Me.btnReport3.Location = New System.Drawing.Point(1124, 417)
        Me.btnReport3.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReport3.Name = "btnReport3"
        Me.btnReport3.Size = New System.Drawing.Size(427, 223)
        Me.btnReport3.TabIndex = 6
        Me.btnReport3.Text = "Expenses by Category"
        Me.btnReport3.UseVisualStyleBackColor = False
        '
        'btnReport4
        '
        Me.btnReport4.BackColor = System.Drawing.Color.Transparent
        Me.btnReport4.BackgroundImage = CType(resources.GetObject("btnReport4.BackgroundImage"), System.Drawing.Image)
        Me.btnReport4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReport4.FlatAppearance.BorderSize = 0
        Me.btnReport4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReport4.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport4.ForeColor = System.Drawing.Color.Firebrick
        Me.btnReport4.Location = New System.Drawing.Point(675, 417)
        Me.btnReport4.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReport4.Name = "btnReport4"
        Me.btnReport4.Size = New System.Drawing.Size(427, 223)
        Me.btnReport4.TabIndex = 7
        Me.btnReport4.Text = "Expiring Stock Report"
        Me.btnReport4.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_05_131258
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.FlatAppearance.BorderSize = 0
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Location = New System.Drawing.Point(119, 26)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(151, 132)
        Me.btnBack.TabIndex = 8
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Firebrick
        Me.Label2.Location = New System.Drawing.Point(108, 653)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 24)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "FROM:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Firebrick
        Me.Label1.Location = New System.Drawing.Point(139, 692)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 24)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "TO:"
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.FDS_COMPROG_PROJ.My.Resources.Resources.Screenshot_2026_07_05_155349
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnReport4)
        Me.Controls.Add(Me.btnReport3)
        Me.Controls.Add(Me.btnReport2)
        Me.Controls.Add(Me.btnReport1)
        Me.Controls.Add(Me.lblIncome)
        Me.Controls.Add(Me.btnComputeIncome)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmReports"
        Me.Text = "Form9"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents btnComputeIncome As Button
    Friend WithEvents lblIncome As Label
    Friend WithEvents btnReport1 As Button
    Friend WithEvents btnReport2 As Button
    Friend WithEvents btnReport3 As Button
    Friend WithEvents btnReport4 As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
