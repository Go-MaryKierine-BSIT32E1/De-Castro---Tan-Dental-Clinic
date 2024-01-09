Public Class FrmMainDashbaord
    Private Sub FrmMainDashbaord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call connection()
    End Sub

    Private Sub LogOutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With FrmPatient
            .TopLevel = False
            Panel3.Controls.Add(FrmPatient)
            .BringToFront()
            .Show()
        End With
    End Sub
End Class