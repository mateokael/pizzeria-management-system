Imports MySql.Data.MySqlClient

Public Class frmWelcome

    Private Sub frmWelcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TestConnection()
    End Sub

    Private Sub TestConnection()
        Try
            Dim conn As MySqlConnection = DBConnection.GetConnection()
            conn.Open()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Database connection failed: " & ex.Message)
        End Try
    End Sub


    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        frmAdminLogin.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Module2.OrderOpenedBy = "Customer"
        Dim frm As New frmCustomerOrder()
        frm.Show()
        Me.Hide()
    End Sub
End Class