<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdjustmentHistory
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
        Me.dgvAdjustments = New System.Windows.Forms.DataGridView()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.cboFilterReason = New System.Windows.Forms.ComboBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnClearFilter = New System.Windows.Forms.Button()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.btnEXIT = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvAdjustments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAdjustments
        '
        Me.dgvAdjustments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAdjustments.Location = New System.Drawing.Point(36, 182)
        Me.dgvAdjustments.Name = "dgvAdjustments"
        Me.dgvAdjustments.RowHeadersWidth = 51
        Me.dgvAdjustments.RowTemplate.Height = 24
        Me.dgvAdjustments.Size = New System.Drawing.Size(1138, 507)
        Me.dgvAdjustments.TabIndex = 0
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(778, 122)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(360, 22)
        Me.dtpFrom.TabIndex = 1
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(778, 150)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(360, 22)
        Me.dtpTo.TabIndex = 2
        '
        'cboFilterReason
        '
        Me.cboFilterReason.FormattingEnabled = True
        Me.cboFilterReason.Location = New System.Drawing.Point(36, 152)
        Me.cboFilterReason.Name = "cboFilterReason"
        Me.cboFilterReason.Size = New System.Drawing.Size(355, 24)
        Me.cboFilterReason.TabIndex = 3
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(396, 128)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(142, 48)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "FILTER"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'btnClearFilter
        '
        Me.btnClearFilter.Location = New System.Drawing.Point(544, 128)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Size = New System.Drawing.Size(128, 48)
        Me.btnClearFilter.TabIndex = 5
        Me.btnClearFilter.Text = "CLEAR FILTER"
        Me.btnClearFilter.UseVisualStyleBackColor = True
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(33, 122)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(51, 17)
        Me.lblCount.TabIndex = 6
        Me.lblCount.Text = "Label1"
        '
        'btnEXIT
        '
        Me.btnEXIT.Location = New System.Drawing.Point(36, 21)
        Me.btnEXIT.Name = "btnEXIT"
        Me.btnEXIT.Size = New System.Drawing.Size(155, 45)
        Me.btnEXIT.TabIndex = 7
        Me.btnEXIT.Text = "EXIT"
        Me.btnEXIT.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(699, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "FROM:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(699, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "TO:"
        '
        'frmAdjustmentHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1222, 721)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnEXIT)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.btnClearFilter)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.cboFilterReason)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.dgvAdjustments)
        Me.Name = "frmAdjustmentHistory"
        Me.Text = "ss"
        CType(Me.dgvAdjustments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvAdjustments As DataGridView
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents cboFilterReason As ComboBox
    Friend WithEvents btnFilter As Button
    Friend WithEvents btnClearFilter As Button
    Friend WithEvents lblCount As Label
    Friend WithEvents btnEXIT As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
