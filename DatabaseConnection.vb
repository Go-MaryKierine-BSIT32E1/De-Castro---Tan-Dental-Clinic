Imports System.Data.OleDb

Module DatabaseConnection
    Public cn As New OleDbConnection
    Public cmd As OleDbCommand
    Public dr As OleDbDataReader
    Public sql As String
    Public Sub connection()
        cn.Close()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\John Gaylord\OneDrive\OneDrive - lyceum of alabang\Desktop\De Castro Dental Clinic\De Castro - Tan Dental Clinic\bin\Debug\Dental_Clinic_Database.accdb"
        cn.Open()
        MsgBox("Connection Success", MsgBoxStyle.Information, "Database Connection")

    End Sub
End Module
