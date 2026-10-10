Imports MySql.Data.MySqlClient

Public Class frmCustomers

    Dim isLoading As Boolean = False
    Dim selectedCustomerID As Integer = 0
    '  Dim pendingDeleteID As Integer = 0

    Private Sub frmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCustomers()
        ClearEditPanel()
        dgvCustomers.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvCustomers.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
    End Sub

    ' ── load / display customers ─────────────────────────────────────────
    Private Sub LoadCustomers(Optional searchTerm As String = "")
        isLoading = True

        Dim query As String =
            "SELECT CustomerID, FirstName, LastName, ContactNo, DateAdded
             FROM customers WHERE 1=1"
        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            query &= " AND (FirstName LIKE @search OR LastName LIKE @search)"
        End If
        query &= " ORDER BY FirstName, LastName"

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(query, conn)
        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            cmd.Parameters.AddWithValue("@search", "%" & searchTerm.Trim() & "%")
        End If
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        dgvCustomers.DataSource = dt
        dgvCustomers.AllowUserToAddRows = False
        dgvCustomers.ReadOnly = True

        dgvCustomers.Columns("CustomerID").Visible = False
        dgvCustomers.Columns("FirstName").DisplayIndex = 0
        dgvCustomers.Columns("LastName").DisplayIndex = 1
        dgvCustomers.Columns("ContactNo").DisplayIndex = 2
        dgvCustomers.Columns("DateAdded").DisplayIndex = 3

        isLoading = False
        lblCount.Text = $"{dt.Rows.Count} customer(s) found"
    End Sub

    ' ── select a row: load it into the edit panel ────────────────────────
    Private Sub dgvCustomers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomers.CellClick
        If isLoading Then Return
        If e.RowIndex < 0 Then Return

        Dim row = dgvCustomers.Rows(e.RowIndex)
        selectedCustomerID = Convert.ToInt32(row.Cells("CustomerID").Value)
        '  pendingDeleteID = 0

        txtFirstName.Text = row.Cells("FirstName").Value.ToString()
        txtLastName.Text = If(IsDBNull(row.Cells("LastName").Value), "", row.Cells("LastName").Value.ToString())
        txtContactNo.Text = If(IsDBNull(row.Cells("ContactNo").Value), "", row.Cells("ContactNo").Value.ToString())
    End Sub

    ' ── validation shared by Add/Update ──────────────────────────────────
    Private Function TryGetValidatedInput(ByRef firstName As String, ByRef lastName As String,
                                           ByRef contactNo As String) As Boolean
        firstName = txtFirstName.Text.Trim()
        If String.IsNullOrWhiteSpace(firstName) Then
            MessageBox.Show("Please enter a first name.")
            txtFirstName.Focus()
            Return False
        End If

        lastName = txtLastName.Text.Trim()

        contactNo = txtContactNo.Text.Trim()
        If Not String.IsNullOrWhiteSpace(contactNo) Then
            If Not System.Text.RegularExpressions.Regex.IsMatch(contactNo, "^[0-9+\-\s]+$") Then
                MessageBox.Show("Please enter a valid contact number.")
                txtContactNo.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    ' ── add ───────────────────────────────────────────────────────────────
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim firstName As String = "", lastName As String = "", contactNo As String = ""
        If Not TryGetValidatedInput(firstName, lastName, contactNo) Then Return

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "INSERT INTO customers (FirstName, LastName, ContactNo, DateAdded)
             VALUES (@fn, @ln, @contact, NOW())", conn)
        cmd.Parameters.AddWithValue("@fn", firstName)
        cmd.Parameters.AddWithValue("@ln", If(String.IsNullOrWhiteSpace(lastName), DBNull.Value, lastName))
        cmd.Parameters.AddWithValue("@contact", If(String.IsNullOrWhiteSpace(contactNo), DBNull.Value, contactNo))
        cmd.ExecuteNonQuery()
        conn.Close()

        MessageBox.Show("Customer added successfully.")
        LoadCustomers()
        ClearEditPanel()
    End Sub

    ' ── update ────────────────────────────────────────────────────────────
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedCustomerID = 0 Then
            MessageBox.Show("Please select a customer to update.")
            Return
        End If

        Dim firstName As String = "", lastName As String = "", contactNo As String = ""
        If Not TryGetValidatedInput(firstName, lastName, contactNo) Then Return

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(
            "UPDATE customers SET FirstName = @fn, LastName = @ln, ContactNo = @contact
             WHERE CustomerID = @cid", conn)
        cmd.Parameters.AddWithValue("@fn", firstName)
        cmd.Parameters.AddWithValue("@ln", If(String.IsNullOrWhiteSpace(lastName), DBNull.Value, lastName))
        cmd.Parameters.AddWithValue("@contact", If(String.IsNullOrWhiteSpace(contactNo), DBNull.Value, contactNo))
        cmd.Parameters.AddWithValue("@cid", selectedCustomerID)
        cmd.ExecuteNonQuery()
        conn.Close()

        MessageBox.Show("Customer updated successfully.")
        LoadCustomers(txtSearch.Text)
        ClearEditPanel()
    End Sub

    ' ── delete ────────────────────────────────────────────────────────────
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedCustomerID = 0 Then
            MessageBox.Show("Please select a customer to delete.")
            Return
        End If

        Dim result As DialogResult = MessageBox.Show(
        "Are you sure you want to delete this customer?",
        "Confirm Delete",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Return
        End If

        Dim conn = DBConnection.GetConnection()
        conn.Open()

        Try
            Dim cmd As New MySqlCommand("DELETE FROM customers WHERE CustomerID = @cid", conn)
            cmd.Parameters.AddWithValue("@cid", selectedCustomerID)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Customer deleted successfully.")

        Catch ex As MySqlException
            MessageBox.Show("Cannot delete this customer because they have existing transactions on record.")
        End Try

        conn.Close()

        LoadCustomers(txtSearch.Text)
        ClearEditPanel()
    End Sub

    ' ── clear ─────────────────────────────────────────────────────────────


    Private Sub ClearEditPanel()
        selectedCustomerID = 0
        '   pendingDeleteID = 0
        txtFirstName.Clear()
        txtLastName.Clear()
        txtContactNo.Clear()
    End Sub



    Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
        txtSearch.Clear()
        LoadCustomers()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmAdminDashboard.Show()
        Me.Close()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadCustomers(txtSearch.Text)
    End Sub

    Private Sub dgvCustomers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomers.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ClearEditPanel()
    End Sub
End Class