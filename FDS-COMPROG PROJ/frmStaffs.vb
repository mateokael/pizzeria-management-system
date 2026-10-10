Imports MySql.Data.MySqlClient

Public Class frmEmployees

    Dim isLoading As Boolean = False
    Dim selectedEmployeeID As Integer = 0

    Private Sub frmEmployees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPositions()
        LoadStatuses()
        LoadFilterPositions()
        LoadFilterStatuses()
        LoadEmployees()

        dgvEmployees.DefaultCellStyle.ForeColor = Color.DarkGreen
        dgvEmployees.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkGreen
        dgvEmployees.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
    End Sub

    ' ── combo box setup (edit panel) — pulled from positions table, not hardcoded ──
    Private Sub LoadPositions()
        cboPosition.Items.Clear()
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand("SELECT PositionName FROM positions ORDER BY PositionName", conn)
        Dim reader = cmd.ExecuteReader()
        While reader.Read()
            cboPosition.Items.Add(reader("PositionName").ToString())
        End While
        reader.Close()
        conn.Close()
    End Sub

    Private Sub LoadStatuses()
        cboStatus.Items.Clear()
        cboStatus.Items.AddRange({"Active", "Inactive"})
        cboStatus.SelectedIndex = 0
    End Sub

    ' ── combo box setup (filter panel) ──────────────────────────────────
    Private Sub LoadFilterPositions()
        cboFilterPosition.Items.Clear()
        cboFilterPosition.Items.Add("All")
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand("SELECT PositionName FROM positions ORDER BY PositionName", conn)
        Dim reader = cmd.ExecuteReader()
        While reader.Read()
            cboFilterPosition.Items.Add(reader("PositionName").ToString())
        End While
        reader.Close()
        conn.Close()
        cboFilterPosition.SelectedIndex = 0
    End Sub

    Private Sub LoadFilterStatuses()
        cboFilterStatus.Items.Clear()
        cboFilterStatus.Items.Add("All")
        cboFilterStatus.Items.AddRange({"Active", "Inactive"})
        cboFilterStatus.SelectedIndex = 0
    End Sub

    ' ── filter change handlers ──────────────────────────────────────────
    Private Sub cboFilterPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterPosition.SelectedIndexChanged
        If isLoading Then Return
        LoadEmployees()
    End Sub

    Private Sub cboFilterStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterStatus.SelectedIndexChanged
        If isLoading Then Return
        LoadEmployees()
    End Sub

    ' ── does the currently-typed/selected position require login credentials? ──
    Private Function PositionRequiresLogin(positionName As String) As Boolean
        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand("SELECT IsSystemRole FROM positions WHERE PositionName = @pos", conn)
        cmd.Parameters.AddWithValue("@pos", positionName)
        Dim result = cmd.ExecuteScalar()
        conn.Close()
        If result Is Nothing Then Return False
        Return Convert.ToBoolean(result)
    End Function

    ' ── load / display employees (LEFT JOIN credentials — most employees won't have a row there) ──
    Private Sub LoadEmployees()
        isLoading = True

        Dim positionFilter As String = If(cboFilterPosition.SelectedItem IsNot Nothing, cboFilterPosition.SelectedItem.ToString(), "All")
        Dim statusFilter As String = If(cboFilterStatus.SelectedItem IsNot Nothing, cboFilterStatus.SelectedItem.ToString(), "All")

        Dim query As String =
            "SELECT e.EmployeeID, e.FirstName, e.LastName, e.ContactNo, p.PositionName AS Position,
                    c.Username, e.DateHired, e.Status
             FROM employees e
             JOIN positions p ON e.PositionID = p.PositionID
             LEFT JOIN credentials c ON c.EmployeeID = e.EmployeeID
             WHERE 1=1"

        If positionFilter <> "All" Then
            query &= " AND p.PositionName = @position"
        End If
        If statusFilter <> "All" Then
            query &= " AND e.Status = @status"
        End If

        query &= " ORDER BY e.FirstName, e.LastName"

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim cmd As New MySqlCommand(query, conn)
        If positionFilter <> "All" Then
            cmd.Parameters.AddWithValue("@position", positionFilter)
        End If
        If statusFilter <> "All" Then
            cmd.Parameters.AddWithValue("@status", statusFilter)
        End If

        Dim adapter As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        adapter.Fill(dt)
        conn.Close()

        dgvEmployees.DataSource = dt
        dgvEmployees.AllowUserToAddRows = False
        dgvEmployees.ReadOnly = True

        dgvEmployees.Columns("EmployeeID").Visible = False
        dgvEmployees.Columns("FirstName").DisplayIndex = 0
        dgvEmployees.Columns("LastName").DisplayIndex = 1
        dgvEmployees.Columns("ContactNo").DisplayIndex = 2
        dgvEmployees.Columns("Position").DisplayIndex = 3
        dgvEmployees.Columns("Username").DisplayIndex = 4
        dgvEmployees.Columns("DateHired").DisplayIndex = 5
        dgvEmployees.Columns("Status").DisplayIndex = 6

        isLoading = False
        lblCount.Text = $"{dt.Rows.Count} employee(s) found"
    End Sub

    ' ── select a row: load it into the edit panel ─────────────────────────
    Private Sub dgvEmployees_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmployees.CellClick
        If isLoading Then Return
        If e.RowIndex < 0 Then Return

        Dim row = dgvEmployees.Rows(e.RowIndex)
        selectedEmployeeID = Convert.ToInt32(row.Cells("EmployeeID").Value)

        txtFirstName.Text = row.Cells("FirstName").Value.ToString()
        txtLastName.Text = If(IsDBNull(row.Cells("LastName").Value), "", row.Cells("LastName").Value.ToString())
        txtContactNo.Text = If(IsDBNull(row.Cells("ContactNo").Value), "", row.Cells("ContactNo").Value.ToString())
        cboPosition.Text = If(IsDBNull(row.Cells("Position").Value), "", row.Cells("Position").Value.ToString())
        txtUsername.Text = If(IsDBNull(row.Cells("Username").Value), "", row.Cells("Username").Value.ToString())
        txtPassword.Text = ""  ' never populate password back into the field

        If Not IsDBNull(row.Cells("DateHired").Value) Then
            dtpDateHired.Value = Convert.ToDateTime(row.Cells("DateHired").Value)
        Else
            dtpDateHired.Value = DateTime.Today
        End If

        cboStatus.Text = If(IsDBNull(row.Cells("Status").Value), "Active", row.Cells("Status").Value.ToString())

        UpdateLoginFieldsEnabled()
    End Sub

    ' ── enable/disable Username/Password fields based on selected position ──
    Private Sub cboPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPosition.SelectedIndexChanged
        UpdateLoginFieldsEnabled()
    End Sub

    Private Sub UpdateLoginFieldsEnabled()
        Dim requiresLogin = PositionRequiresLogin(cboPosition.Text.Trim())
        txtUsername.Enabled = requiresLogin
        txtPassword.Enabled = requiresLogin
        If Not requiresLogin Then
            txtUsername.Text = ""
            txtPassword.Text = ""
        End If
    End Sub

    ' ── validation shared by Add/Update ────────────────────────────────────
    Private Function TryGetValidatedInput(ByRef firstName As String, ByRef lastName As String,
                                   ByRef contactNo As String, ByRef position As String,
                                   ByRef dateHired As Date, ByRef status As String,
                                   ByRef username As String, ByRef password As String,
                                   alreadyHasCredentials As Boolean) As Boolean
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

        position = cboPosition.Text.Trim()
        If String.IsNullOrWhiteSpace(position) Then
            MessageBox.Show("Please select or enter a position.")
            cboPosition.Focus()
            Return False
        End If

        dateHired = dtpDateHired.Value.Date
        If dateHired > DateTime.Today Then
            MessageBox.Show("Date hired cannot be in the future.")
            dtpDateHired.Focus()
            Return False
        End If

        status = If(String.IsNullOrWhiteSpace(cboStatus.Text), "Active", cboStatus.Text.Trim())

        username = txtUsername.Text.Trim()
        password = txtPassword.Text.Trim()

        ' Inactive employees don't need login credentials — skip the requirement checks
        ' entirely; their credentials row (if any) will be removed on save regardless
        ' of what's typed in these fields.
        If PositionRequiresLogin(position) AndAlso status <> "Inactive" Then
            If String.IsNullOrWhiteSpace(username) Then
                MessageBox.Show($"Username is required for the {position} position.")
                txtUsername.Focus()
                Return False
            End If
            If String.IsNullOrWhiteSpace(password) AndAlso Not alreadyHasCredentials Then
                MessageBox.Show($"Password is required for the {position} position.")
                txtPassword.Focus()
                Return False
            End If
        ElseIf status = "Inactive" Then
            username = ""
            password = ""
        Else
            username = ""
            password = ""
        End If

        Return True
    End Function

    ' ── add ─────────────────────────────────────────────────────────────────
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim firstName As String = "", lastName As String = "", contactNo As String = "",
            position As String = "", status As String = "", username As String = "", password As String = ""
        Dim dateHired As Date = DateTime.Today
        ' btnAdd_Click — brand new employee, never has credentials yet:

        If Not TryGetValidatedInput(firstName, lastName, contactNo, position, dateHired, status, username, password, alreadyHasCredentials:=False) Then Return

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim trans = conn.BeginTransaction()

        Try
            ' username uniqueness check now against credentials, not employees
            If Not String.IsNullOrWhiteSpace(username) Then
                Dim cmdCheck As New MySqlCommand("SELECT COUNT(*) FROM credentials WHERE Username = @u", conn, trans)
                cmdCheck.Parameters.AddWithValue("@u", username)
                If Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0 Then
                    MessageBox.Show("That username is already taken.")
                    trans.Rollback()
                    conn.Close()
                    Return
                End If
            End If

            Dim cmdPos As New MySqlCommand("SELECT PositionID FROM positions WHERE PositionName = @pos", conn, trans)
            cmdPos.Parameters.AddWithValue("@pos", position)
            Dim positionID = Convert.ToInt32(cmdPos.ExecuteScalar())

            Dim cmd As New MySqlCommand(
                "INSERT INTO employees (FirstName, LastName, ContactNo, PositionID, DateHired, Status, DateAdded)
                 VALUES (@fn, @ln, @contact, @pid, @hired, @status, NOW())", conn, trans)
            cmd.Parameters.AddWithValue("@fn", firstName)
            cmd.Parameters.AddWithValue("@ln", If(String.IsNullOrWhiteSpace(lastName), DBNull.Value, lastName))
            cmd.Parameters.AddWithValue("@contact", If(String.IsNullOrWhiteSpace(contactNo), DBNull.Value, contactNo))
            cmd.Parameters.AddWithValue("@pid", positionID)
            cmd.Parameters.AddWithValue("@hired", dateHired)
            cmd.Parameters.AddWithValue("@status", status)
            cmd.ExecuteNonQuery()

            Dim newEmployeeID = CInt(cmd.LastInsertedId)

            ' only insert a credentials row if this position actually needs one
            If Not String.IsNullOrWhiteSpace(username) Then
                Dim cmdCred As New MySqlCommand(
                    "INSERT INTO credentials (EmployeeID, Username, Password) VALUES (@eid, @user, @pass)", conn, trans)
                cmdCred.Parameters.AddWithValue("@eid", newEmployeeID)
                cmdCred.Parameters.AddWithValue("@user", username)
                cmdCred.Parameters.AddWithValue("@pass", password)
                cmdCred.ExecuteNonQuery()
            End If

            trans.Commit()
        Catch ex As Exception
            trans.Rollback()
            MessageBox.Show("Failed to add employee: " & ex.Message)
            conn.Close()
            Return
        End Try

        conn.Close()
        MessageBox.Show("Employee added successfully.")
        LoadEmployees()
    End Sub

    ' ── update ──────────────────────────────────────────────────────────────
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedEmployeeID = 0 Then
            MessageBox.Show("Please select an employee to update.")
            Return
        End If

        Dim firstName As String = "", lastName As String = "", contactNo As String = "",
    position As String = "", status As String = "", username As String = "", password As String = ""
        Dim dateHired As Date = DateTime.Today

        Dim alreadyHasCredentials As Boolean = False
        Dim connCheck = DBConnection.GetConnection()
        connCheck.Open()
        Dim cmdExists As New MySqlCommand("SELECT COUNT(*) FROM credentials WHERE EmployeeID = @sid", connCheck)
        cmdExists.Parameters.AddWithValue("@sid", selectedEmployeeID)
        alreadyHasCredentials = Convert.ToInt32(cmdExists.ExecuteScalar()) > 0
        connCheck.Close()

        If Not TryGetValidatedInput(firstName, lastName, contactNo, position, dateHired, status, username, password, alreadyHasCredentials) Then Return

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim trans = conn.BeginTransaction()

        Try
            If Not String.IsNullOrWhiteSpace(username) Then
                Dim cmdCheck As New MySqlCommand("SELECT COUNT(*) FROM credentials WHERE Username = @u AND EmployeeID <> @sid", conn, trans)
                cmdCheck.Parameters.AddWithValue("@u", username)
                cmdCheck.Parameters.AddWithValue("@sid", selectedEmployeeID)
                If Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0 Then
                    MessageBox.Show("That username is already taken.")
                    trans.Rollback()
                    conn.Close()
                    Return
                End If
            End If

            Dim cmdPos As New MySqlCommand("SELECT PositionID FROM positions WHERE PositionName = @pos", conn, trans)
            cmdPos.Parameters.AddWithValue("@pos", position)
            Dim positionID = Convert.ToInt32(cmdPos.ExecuteScalar())

            Dim cmd As New MySqlCommand(
        "UPDATE employees SET FirstName = @fn, LastName = @ln, ContactNo = @contact,
         PositionID = @pid, DateHired = @hired, Status = @status
         WHERE EmployeeID = @sid", conn, trans)
            cmd.Parameters.AddWithValue("@fn", firstName)
            cmd.Parameters.AddWithValue("@ln", If(String.IsNullOrWhiteSpace(lastName), DBNull.Value, lastName))
            cmd.Parameters.AddWithValue("@contact", If(String.IsNullOrWhiteSpace(contactNo), DBNull.Value, contactNo))
            cmd.Parameters.AddWithValue("@pid", positionID)
            cmd.Parameters.AddWithValue("@hired", dateHired)
            cmd.Parameters.AddWithValue("@status", status)
            cmd.Parameters.AddWithValue("@sid", selectedEmployeeID)
            cmd.ExecuteNonQuery()

            ' Reuse the check from the top of the method instead of querying again.
            Dim hasCredRow = alreadyHasCredentials

            If status = "Inactive" Then
                ' Deactivated employees lose login access entirely, regardless of position —
                ' remove their credentials row if they have one.
                If hasCredRow Then
                    Dim cmdCred As New MySqlCommand("DELETE FROM credentials WHERE EmployeeID = @sid", conn, trans)
                    cmdCred.Parameters.AddWithValue("@sid", selectedEmployeeID)
                    cmdCred.ExecuteNonQuery()
                End If

            ElseIf Not String.IsNullOrWhiteSpace(username) Then
                If hasCredRow Then
                    ' update username always; only touch the password if a new one was actually typed
                    If Not String.IsNullOrWhiteSpace(password) Then
                        Dim cmdCred As New MySqlCommand(
                    "UPDATE credentials SET Username = @user, Password = @pass WHERE EmployeeID = @sid", conn, trans)
                        cmdCred.Parameters.AddWithValue("@user", username)
                        cmdCred.Parameters.AddWithValue("@pass", password)
                        cmdCred.Parameters.AddWithValue("@sid", selectedEmployeeID)
                        cmdCred.ExecuteNonQuery()
                    Else
                        Dim cmdCred As New MySqlCommand(
                    "UPDATE credentials SET Username = @user WHERE EmployeeID = @sid", conn, trans)
                        cmdCred.Parameters.AddWithValue("@user", username)
                        cmdCred.Parameters.AddWithValue("@sid", selectedEmployeeID)
                        cmdCred.ExecuteNonQuery()
                    End If
                Else
                    ' position was switched TO a login-requiring one — password is mandatory in that case
                    ' (TryGetValidatedInput already enforced this, so password is guaranteed non-blank here)
                    Dim cmdCred As New MySqlCommand(
                "INSERT INTO credentials (EmployeeID, Username, Password) VALUES (@sid, @user, @pass)", conn, trans)
                    cmdCred.Parameters.AddWithValue("@sid", selectedEmployeeID)
                    cmdCred.Parameters.AddWithValue("@user", username)
                    cmdCred.Parameters.AddWithValue("@pass", password)
                    cmdCred.ExecuteNonQuery()
                End If

            ElseIf hasCredRow Then
                ' position was switched AWAY from a login-requiring one — remove old credentials entirely
                Dim cmdCred As New MySqlCommand("DELETE FROM credentials WHERE EmployeeID = @sid", conn, trans)
                cmdCred.Parameters.AddWithValue("@sid", selectedEmployeeID)
                cmdCred.ExecuteNonQuery()
            End If

            trans.Commit()
        Catch ex As Exception
            trans.Rollback()
            MessageBox.Show("Failed to update employee: " & ex.Message)
            conn.Close()
            Return
        End Try

        conn.Close()
        MessageBox.Show("Employee updated successfully.")
        LoadEmployees()
    End Sub

    ' ── delete ──────────────────────────────────────────────────────────────
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedEmployeeID = 0 Then
            MessageBox.Show("Please select an employee to delete.")
            Return
        End If

        ' ── check for existing transaction history BEFORE asking to confirm delete ──
        Dim connCheck = DBConnection.GetConnection()
        connCheck.Open()
        Dim cmdCheck As New MySqlCommand(
        "SELECT COUNT(*) FROM transactions WHERE ConfirmedByEmployeeID = @eid", connCheck)
        cmdCheck.Parameters.AddWithValue("@eid", selectedEmployeeID)
        Dim hasTransactions = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0
        connCheck.Close()

        If hasTransactions Then
            MessageBox.Show("This employee has existing transaction records and cannot be deleted." & Environment.NewLine &
                         "To remove them from active use, select the employee, set Status to 'Inactive', and click Update instead.",
                         "Cannot Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Dim conn = DBConnection.GetConnection()
        conn.Open()
        Dim deleted As Boolean = False
        Try
            Dim cmd As New MySqlCommand("DELETE FROM employees WHERE EmployeeID = @sid", conn)
            cmd.Parameters.AddWithValue("@sid", selectedEmployeeID)
            cmd.ExecuteNonQuery()
            deleted = True
            MessageBox.Show("Employee deleted successfully.")
        Catch ex As MySqlException
            MessageBox.Show("Cannot delete this employee because they have existing records linked." & Environment.NewLine &
                         "Set their Status to 'Inactive' instead.")
        End Try
        conn.Close()

        If deleted Then
            selectedEmployeeID = 0
            LoadEmployees()
        End If
    End Sub

    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btn.Click
        frmAdminDashboard.Show()
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        selectedEmployeeID = 0
        txtFirstName.Clear()
        txtLastName.Clear()
        txtContactNo.Clear()
        cboPosition.SelectedIndex = -1
        txtUsername.Clear()
        txtPassword.Clear()
        dtpDateHired.Value = DateTime.Today
        cboStatus.SelectedIndex = 0
        UpdateLoginFieldsEnabled()
    End Sub

End Class