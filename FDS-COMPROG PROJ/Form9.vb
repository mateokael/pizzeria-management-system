Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class frmReports

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = DateTime.Today.AddMonths(-1)
        dtpTo.Value = DateTime.Today
    End Sub

    Private Sub btnComputeIncome_Click(sender As Object, e As EventArgs) Handles btnComputeIncome.Click
        If dtpFrom.Value.Date > dtpTo.Value.Date Then
            MessageBox.Show("From date cannot be later than To date.")
            Return
        End If
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "SELECT COALESCE(SUM(td.Quantity * td.UnitPrice), 0) AS TotalIncome
             FROM transactions t
             JOIN transactiondetails td ON t.TransactionID = td.TransactionID
             WHERE t.Status = 'Completed'
             AND t.TransactionDate BETWEEN @from AND @to", conn)
        cmd.Parameters.AddWithValue("@from", dtpFrom.Value.Date.ToString("yyyy-MM-dd"))
        cmd.Parameters.AddWithValue("@to", dtpTo.Value.Date.ToString("yyyy-MM-dd 23:59:59"))
        Dim result = cmd.ExecuteScalar()
        conn.Close()
        Dim total As Decimal = If(IsDBNull(result), 0, Convert.ToDecimal(result))
        lblIncome.Text = "Total Income: ₱" & total.ToString("0.00")
    End Sub

    Private Sub btnReport1_Click(sender As Object, e As EventArgs) Handles btnReport1.Click
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "SELECT p.ProductName, c.CategoryName AS Category,
                    SUM(td.Quantity) AS TotalSold,
                    SUM(td.Quantity * td.UnitPrice) AS TotalRevenue
             FROM transactiondetails td
             INNER JOIN products p ON td.ProductID = p.ProductID
             INNER JOIN categories c ON p.CategoryID = c.CategoryID
             INNER JOIN transactions t ON td.TransactionID = t.TransactionID
             WHERE t.Status = 'Completed'
             GROUP BY p.ProductID, p.ProductName, c.CategoryName
             ORDER BY TotalSold DESC", conn)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No data available for this report.")
            Return
        End If

        ExportReportToPdf(dt, "Best Selling Products",
            {"Product", "Category", "Total Sold", "Total Revenue"})
    End Sub

    Private Sub btnReport2_Click(sender As Object, e As EventArgs) Handles btnReport2.Click
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "SELECT DATE(t.TransactionDate) AS SaleDate,
                    COUNT(DISTINCT t.TransactionID) AS TotalTransactions,
                    SUM(td.Quantity * td.UnitPrice) AS TotalSales
             FROM transactions t
             INNER JOIN transactiondetails td ON t.TransactionID = td.TransactionID
             WHERE t.Status = 'Completed'
             GROUP BY DATE(t.TransactionDate)
             ORDER BY SaleDate DESC", conn)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No data available for this report.")
            Return
        End If

        ExportReportToPdf(dt, "Sales Summary by Date",
            {"Date", "Total Transactions", "Total Sales"})
    End Sub

    Private Sub btnReport3_Click(sender As Object, e As EventArgs) Handles btnReport3.Click
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "SELECT ec.CategoryName,
                    COUNT(e.ExpenseID) AS TotalEntries,
                    SUM(e.Amount) AS TotalAmount
             FROM expenses e
             INNER JOIN expensecategories ec ON e.CategoryID = ec.CategoryID
             GROUP BY ec.CategoryID, ec.CategoryName
             ORDER BY TotalAmount DESC", conn)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No data available for this report.")
            Return
        End If

        ExportReportToPdf(dt, "Expenses by Category",
            {"Category", "Total Entries", "Total Amount"})
    End Sub

    Private Sub btnReport4_Click(sender As Object, e As EventArgs) Handles btnReport4.Click
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "SELECT i.IngredientName, i.Unit,
                    b.RemainingQty,
                    b.ExpiryDate,
                    DATEDIFF(b.ExpiryDate, CURDATE()) AS DaysUntilExpiry
             FROM ingredientbatches b
             INNER JOIN ingredients i ON b.IngredientID = i.IngredientID
             WHERE b.ExpiryDate >= CURDATE()
               AND b.RemainingQty > 0
               AND b.IsVoided = 0
             ORDER BY b.ExpiryDate ASC", conn)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No data available for this report.")
            Return
        End If

        ExportReportToPdf(dt, "Expiring Stock Report",
            {"Ingredient", "Unit", "Remaining Qty", "Expiry Date", "Days Until Expiry"})
    End Sub

    ' =========================================================
    ' SHARED PDF EXPORT (iTextSharp, replaces Crystal Reports)
    ' =========================================================
    Private Sub ExportReportToPdf(dt As DataTable, title As String, columnHeaders As String())
        Dim sfd As New SaveFileDialog()
        sfd.Filter = "PDF Files|*.pdf"
        sfd.FileName = title.Replace(" ", "_") & "_" & DateTime.Now.ToString("yyyyMMdd") & ".pdf"
        If sfd.ShowDialog() <> DialogResult.OK Then Return

        Dim doc As New Document(PageSize.A4, 30, 30, 30, 30)
        Try
            PdfWriter.GetInstance(doc, New FileStream(sfd.FileName, FileMode.Create))
            doc.Open()

            ' ── Logo ─────────────────────────────────────────
            Dim logoPath = Path.Combine(Application.StartupPath, "logo.png")
            If File.Exists(logoPath) Then
                Dim logo = iTextSharp.text.Image.GetInstance(logoPath)
                logo.ScaleToFit(100, 100)
                logo.Alignment = iTextSharp.text.Image.ALIGN_LEFT
                doc.Add(logo)
            End If

            ' ── Title ────────────────────────────────────────
            Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD)
            Dim titlePara As New Paragraph(title, titleFont)
            titlePara.SpacingBefore = 10
            titlePara.SpacingAfter = 5
            doc.Add(titlePara)

            Dim subFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.ITALIC, BaseColor.GRAY)
            doc.Add(New Paragraph($"Generated on {DateTime.Now:MMMM dd, yyyy hh:mm tt}", subFont))
            doc.Add(New Paragraph(" "))

            ' ── Table ────────────────────────────────────────
            Dim table As New PdfPTable(dt.Columns.Count)
            table.WidthPercentage = 100
            table.SpacingBefore = 10

            Dim headerFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE)
            For Each header In columnHeaders
                Dim cell As New PdfPCell(New Phrase(header, headerFont))
                cell.BackgroundColor = New BaseColor(70, 130, 90)
                cell.Padding = 6
                table.AddCell(cell)
            Next

            Dim bodyFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9)
            For Each row As DataRow In dt.Rows
                For Each col As DataColumn In dt.Columns
                    Dim cell As New PdfPCell(New Phrase(row(col).ToString(), bodyFont))
                    cell.Padding = 5
                    table.AddCell(cell)
                Next
            Next

            doc.Add(table)
        Catch ex As Exception
            MessageBox.Show("PDF export failed: " & ex.Message)
            Return
        Finally
            doc.Close()
        End Try

        If MessageBox.Show("Report exported successfully. Open it now?", "Export Complete",
                        MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Process.Start(sfd.FileName)
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmAdminDashboard.Show()
        Me.Close()
    End Sub

End Class