Public Class frmAdminDashboard

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnExpenses.Click
        frmExpenses.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmInventory.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        frmCustomerOrder.Show()
        Me.Hide()
    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnTransactions.Click
        frmTransactions.Show()
        Me.Hide()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        frmReports.Show()
        Me.Hide()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Logout?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            frmWelcome.Show()
            Me.Close()
        End If
    End Sub

    Private Sub btnCustomers_Click(sender As Object, e As EventArgs) Handles btnCustomers.Click
        frmCustomers.Show()
        Me.Hide()
    End Sub

    Private Sub frmAdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmEmployees.Show()
        Me.Hide()
    End Sub
End Class