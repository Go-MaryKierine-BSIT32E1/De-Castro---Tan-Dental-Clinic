Imports System.Data.OleDb
Imports System.Net

Public Class Form1
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        sql = "SELECT * from queryAccounts where Username='" & txtUsername.Text & "' and PIN='" & txtPIN.Text & "' and AccountStatus= 'Active'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        If String.IsNullOrEmpty(txtUsername.Text) OrElse String.IsNullOrEmpty(txtPIN.Text) Then
            MsgBox("Inputs cannot be empty. Please enter your valid Username and PIN", MsgBoxStyle.Critical)
        ElseIf dr.Read = True Then
            MsgBox("Login Success!", MsgBoxStyle.Information)
            FrmMainDashbaord.ShowDialog()
        Else
            Call checkUserAccount()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) 
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        FrmCreateAccount.ShowDialog()
    End Sub

    Private Sub DisableAccount()
        sql = "Update tblAccounts SET AccountStatus=@AccountStatus where Username=@Username"
        cmd = New OleDbCommand(sql, cn)
        With cmd
            .Parameters.AddWithValue("@AccountStatus", "Disabled")
            .Parameters.AddWithValue("@Username", txtUsername.Text)
            .ExecuteNonQuery()
        End With
        MsgBox("Your Account is disabled", MsgBoxStyle.Exclamation)
        btnLogin.Enabled = False
    End Sub

    Private Sub CheckIfDisabled()
        sql = "Select AccountStatus from queryAccounts where Username='" & txtUsername.Text & "' and AccountStatus = 'Disable'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.Read = True Then
            Call DisableAccount()
        Else
            MsgBox("Log in failed", MsgBoxStyle.Critical)
            lblAttemptNum.Text = lblAttemptNum.Text - 1
            If lblAttemptNum.Text = 0 Then
                MsgBox("You reached the attempt limits", MsgBoxStyle.Critical)
                Call DisableAccount()
            End If
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call connection()
    End Sub

    Private Sub checkUserAccount()
        sql = $"SELECT * FROM tblPIN WHERE [Username] = '{txtUsername.Text}'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.Read = True Then
            Call CheckIfDisabled()
        Else
            MsgBox("Account Doesnt Exist", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class
