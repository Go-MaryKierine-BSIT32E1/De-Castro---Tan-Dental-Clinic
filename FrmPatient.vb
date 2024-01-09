Imports System.Data.OleDb

Public Class FrmPatient
    Private Sub FrmPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call connection()
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Close()
    End Sub

    Private Sub btnListPatient_Click(sender As Object, e As EventArgs) Handles btnListPatient.Click
        FrmListofPatients.Show()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtPatientID.Clear()
        txtFirstName.Clear()
        txtLastName.Clear()
        txtMiddleName.Clear()
        txtContactNo.Clear()
        txtAddress.Clear()
        txtAge.Clear()
        txtOccupation.Clear()
        txtReference.Clear()
        cboGender.ResetText()
        DateTimePicker1.ResetText()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtPatientID.Text) OrElse String.IsNullOrEmpty(txtLastName.Text) OrElse String.IsNullOrEmpty(txtFirstName.Text) OrElse String.IsNullOrEmpty(txtMiddleName.Text) OrElse String.IsNullOrEmpty(cboGender.Text) OrElse String.IsNullOrEmpty(txtAge.Text) OrElse String.IsNullOrEmpty(txtOccupation.Text) OrElse String.IsNullOrEmpty(txtContactNo.Text) OrElse String.IsNullOrEmpty(txtAddress.Text) OrElse String.IsNullOrEmpty(txtReference.Text) Then
            MsgBox("Inputs cannot be empty. Please fill up the fields", MsgBoxStyle.Critical)
        Else
            Call SaveData()
        End If
    End Sub

    Private Sub SaveData()
        sql = "Insert into tblPatientInformation([Patient ID],[LastName],[FirstName],[MiddleName],[Gender],[Age],[Occupation],[ContactNo],[Address],[Reference],[Date])Values([@Patient ID],[@LastName],[@FirstName],[@MiddleName],[@Gender],[@Age],[@Occupation],[@ContactNo],[Address],[@Reference],[@Date])"
        cmd = New OleDbCommand(sql, cn)
        With cmd
            .Parameters.AddWithValue("[@Username]", txtLastName.Text)
            .Parameters.AddWithValue("[@LastName]", txtFirstName.Text)
            .Parameters.AddWithValue("[@FirstName]", txtMiddleName.Text)
            .Parameters.AddWithValue("[@MI]", cboGender.Text)
            .Parameters.AddWithValue("[@Address]", txtAge.Text)
            .Parameters.AddWithValue("[@ContactNo]", txtOccupation.Text)
            .Parameters.AddWithValue("[@Email]", txtContactNo.Text)
            .Parameters.AddWithValue("[@Age]", txtAddress.Text)
            .Parameters.AddWithValue("[@Bdate]", DateTimePicker1.Value.ToString)
            .Parameters.AddWithValue("[@Gender]", txtReference.Text)
            .ExecuteNonQuery()
        End With
        MsgBox("New Patient Information Successfully Saved", MsgBoxStyle.Information)
    End Sub
End Class