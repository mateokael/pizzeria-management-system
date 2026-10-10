Imports MySql.Data.MySqlClient

Public Class frmAdminLogin

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Please enter username and password.")
            Return
        End If
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
        "SELECT e.EmployeeID, p.PositionName FROM employees e
         JOIN positions p ON e.PositionID = p.PositionID
         JOIN credentials c ON c.EmployeeID = e.EmployeeID
         WHERE c.Username = @u AND c.Password = @p
           AND e.Status = 'Active' AND p.IsSystemRole = TRUE", conn)
        cmd.Parameters.AddWithValue("@u", txtUsername.Text)
        cmd.Parameters.AddWithValue("@p", txtPassword.Text)
        Dim reader = cmd.ExecuteReader()

        Dim employeeID As Integer = 0
        Dim role As String = ""
        If reader.Read() Then
            employeeID = Convert.ToInt32(reader("EmployeeID"))
            role = reader("PositionName").ToString()
        End If
        reader.Close()
        conn.Close()

        If role = "" Then
            MessageBox.Show("Invalid credentials.")
            txtPassword.Clear()
            Return
        End If

        Module2.CurrentUserRole = role
        Module2.CurrentEmployeeID = employeeID   ' NEW

        If role = "Manager" Then
            frmAdminDashboard.Show()
            frmWelcome.Hide()
            txtPassword.Clear()
            Me.Hide()
        ElseIf role = "Cashier" Then
            frmTransactions.Show()
            frmWelcome.Hide()
            txtPassword.Clear()
            Me.Hide()
        Else
            MessageBox.Show("Unrecognized role.")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        frmWelcome.Show()
        Me.Close()
    End Sub

    Private Sub frmAdminLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

End Class