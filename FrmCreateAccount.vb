Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip

Public Class FrmCreateAccount

    Private Sub FrmCreateAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call connection()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtLastName.Clear()
        txtFirstName.Clear()
        txtContactNo.Clear()
        txtEmail.Clear()
        txtAddress.Clear()
        txtAge.Clear()
        txtMI.Clear()
        txtUsername.Clear()
        txtPIN.Clear()
        txtCPIN.Clear()
        cboGender.ResetText()
        cboPosition.ResetText()
        DateTimePicker2.ResetText()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If String.IsNullOrEmpty(txtUsername.Text) OrElse String.IsNullOrEmpty(txtLastName.Text) OrElse String.IsNullOrEmpty(txtFirstName.Text) OrElse String.IsNullOrEmpty(txtMI.Text) OrElse String.IsNullOrEmpty(txtAddress.Text) OrElse String.IsNullOrEmpty(txtContactNo.Text) OrElse String.IsNullOrEmpty(txtEmail.Text) OrElse String.IsNullOrEmpty(txtAge.Text) OrElse String.IsNullOrEmpty(cboGender.Text) OrElse String.IsNullOrEmpty(cboPosition.Text) Then
            MsgBox("Inputs cannot be empty. Please fill up the fields", MsgBoxStyle.Critical)
        ElseIf txtUsername.TextLength < 10 Then
            MsgBox("Username must be atleast 10 characters above", MsgBoxStyle.Critical)
        ElseIf String.IsNullOrEmpty(txtPIN.Text) OrElse String.IsNullOrEmpty(txtCPIN.Text) Then
            MsgBox("Inputs cannot be empty. Please fill up the fields", MsgBoxStyle.Critical)
        ElseIf txtPIN.TextLength < 8 And txtCPIN.TextLength < 8 Then
            MsgBox("PIN must be atleast 8 characters above", MsgBoxStyle.Critical)
        Else
            Call checkAccounts()
        End If
    End Sub

    Private Sub SaveData()
        sql = "Insert into tblAccounts([Username],[LastName],[FirstName],[MI],[Address],[ContactNo],[Email],[Age],[Bdate],[Gender],[Position],[AccountStatus])Values([@Username],[@LastName],[@FirstName],[@MI],[@Address],[@ContactNo],[@Email],[@Age],[@Bdate],[@Gender],[@Position],[@AccountStatus])"
        cmd = New OleDbCommand(sql, cn)
        With cmd
            .Parameters.AddWithValue("[@Username]", txtUsername.Text)
            .Parameters.AddWithValue("[@LastName]", txtLastName.Text)
            .Parameters.AddWithValue("[@FirstName]", txtFirstName.Text)
            .Parameters.AddWithValue("[@MI]", txtMI.Text)
            .Parameters.AddWithValue("[@Address]", txtAddress.Text)
            .Parameters.AddWithValue("[@ContactNo]", txtContactNo.Text)
            .Parameters.AddWithValue("[@Email]", txtEmail.Text)
            .Parameters.AddWithValue("[@Age]", txtAge.Text)
            .Parameters.AddWithValue("[@Bdate]", DateTimePicker2.Value.ToString)
            .Parameters.AddWithValue("[@Gender]", cboGender.Text)
            .Parameters.AddWithValue("[@Position]", cboPosition.Text)
            .Parameters.AddWithValue("[@AccountStatus]", "Active")
            .ExecuteNonQuery()
        End With
        MsgBox("New Account Successfully Created", MsgBoxStyle.Information, "Client Account")
    End Sub
    Private Sub SavePIN()
        If txtPIN.Text <> txtCPIN.Text Then
            MsgBox("Pin Mismatched. Please check your PIN carefully", MsgBoxStyle.Critical)
        Else
            sql = "Insert into tblPIN(Username,PIN)Values(@Username,@PIN)"
            cmd = New OleDbCommand(sql, cn)
            With cmd
                .Parameters.AddWithValue("@Username", txtUsername.Text)
                .Parameters.AddWithValue("@PIN", txtPIN.Text)
                .ExecuteNonQuery()
                SaveData()
            End With
        End If
    End Sub

    Private Sub checkAccounts()
        sql = "Select Username from tblAccounts where Username= '" & txtUsername.Text & "'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.Read = True Then
            MsgBox("Account is already existed", MsgBoxStyle.Exclamation)
        Else
            SavePIN()
        End If
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Close()
    End Sub
End Class

