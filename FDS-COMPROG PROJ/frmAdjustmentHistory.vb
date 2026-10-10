Imports MySql.Data.MySqlClient

Public Class frmAdjustmentHistory

    Private Sub frmAdjustmentHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFilterReasons()
        dtpFrom.Value = DateTime.Today.AddMonths(-1)
        dtpTo.Value = DateTime.Today
        LoadAdjustmentHistory()
    End Sub

    Private Sub LoadFilterReasons()
        cboFilterReason.Items.Clear()
        cboFilterReason.Items.Add("All Reasons")
        cboFilterReason.Items.AddRange({"Wrong Entry", "Spoilage", "Breakage", "Theft", "Miscount", "Other"})
        cboFilterReason.DropDownStyle = ComboBoxStyle.DropDownList
        cboFilterReason.SelectedIndex = 0
    End Sub

    Private Sub LoadAdjustmentHistory(Optional dateFrom As DateTime = Nothing,
                                       Optional dateTo As DateTime = Nothing,
                                       Optional reasonFilter As String = "All Reasons")
        ' IngredientID isn't stored directly on batch_adjustments (kept in 3NF),
        ' so we reach the ingredient name via ingredientbatches.
        Dim query As String =
        "SELECT ba.AdjustmentID, i.IngredientName, ba.ActionType,
                ba.OldRemainingQty, ba.NewRemainingQty,
                ba.OldCostPerUnit, ba.NewCostPerUnit,
                ba.OldExpiryDate, ba.NewExpiryDate,
                ba.Reason, ba.Notes, ba.AdjustedDate
         FROM batch_adjustments ba
         JOIN ingredientbatches b ON ba.BatchID = b.BatchID
         JOIN ingredients i ON b.IngredientID = i.IngredientID
         WHERE 1=1"

        If dateFrom <> Nothing Then query &= " AND ba.AdjustedDate >= @from"
        If dateTo <> Nothing Then query &= " AND ba.AdjustedDate <= @to"
        If reasonFilter <> "All Reasons" Then query &= " AND ba.Reason = @reason"

        query &= " ORDER BY ba.AdjustedDate DESC"

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(query, conn)
        If dateFrom <> Nothing Then cmd.Parameters.AddWithValue("@from", dateFrom.ToString("yyyy-MM-dd 00:00:00"))
        If dateTo <> Nothing Then cmd.Parameters.AddWithValue("@to", dateTo.ToString("yyyy-MM-dd 23:59:59"))
        If reasonFilter <> "All Reasons" Then cmd.Parameters.AddWithValue("@reason", reasonFilter)

        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        dgvAdjustments.DataSource = dt
        dgvAdjustments.AllowUserToAddRows = False
        dgvAdjustments.ReadOnly = True ' this is a log - never editable

        If dgvAdjustments.Columns.Contains("AdjustmentID") Then dgvAdjustments.Columns("AdjustmentID").Visible = False

        dgvAdjustments.Columns("IngredientName").HeaderText = "Ingredient"
        dgvAdjustments.Columns("ActionType").HeaderText = "Action"
        dgvAdjustments.Columns("OldRemainingQty").HeaderText = "Old Qty"
        dgvAdjustments.Columns("NewRemainingQty").HeaderText = "New Qty"
        dgvAdjustments.Columns("OldCostPerUnit").HeaderText = "Old Cost"
        dgvAdjustments.Columns("NewCostPerUnit").HeaderText = "New Cost"
        dgvAdjustments.Columns("OldExpiryDate").HeaderText = "Old Expiry"
        dgvAdjustments.Columns("NewExpiryDate").HeaderText = "New Expiry"
        dgvAdjustments.Columns("AdjustedDate").HeaderText = "Date Adjusted"

        For Each row As DataGridViewRow In dgvAdjustments.Rows
            Dim reason = row.Cells("Reason").Value.ToString()
            Select Case reason
                Case "Theft"
                    row.DefaultCellStyle.BackColor = Color.LightCoral
                    row.DefaultCellStyle.ForeColor = Color.DarkRed
                Case "Spoilage", "Breakage"
                    row.DefaultCellStyle.BackColor = Color.LightYellow
                Case Else
                    ' Wrong Entry / Miscount / Other - routine corrections, no highlight
            End Select
        Next

        lblCount.Text = $"{dt.Rows.Count} adjustment(s) found"
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        If dtpFrom.Value.Date > dtpTo.Value.Date Then
            MessageBox.Show("'From' date cannot be later than 'To' date.")
            Return
        End If
        LoadAdjustmentHistory(
            dateFrom:=dtpFrom.Value.Date,
            dateTo:=dtpTo.Value.Date,
            reasonFilter:=cboFilterReason.SelectedItem.ToString())
    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        dtpFrom.Value = DateTime.Today.AddMonths(-1)
        dtpTo.Value = DateTime.Today
        cboFilterReason.SelectedIndex = 0
        LoadAdjustmentHistory()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnEXIT.Click

        Me.Close()
    End Sub

End Class