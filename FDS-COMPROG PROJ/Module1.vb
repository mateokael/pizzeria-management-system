Imports MySql.Data.MySqlClient

Module DBConnection
    Public Function GetConnection() As MySqlConnection
        Dim conn As New MySqlConnection("Server=localhost;Database=pizzeria_db;Uid=root;Pwd=;")
        Return conn
    End Function

    Public Function FormatPeso(amount As Decimal) As String
        Return "₱" & amount.ToString("N2")
    End Function


End Module