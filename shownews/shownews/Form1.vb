Imports System.Data.OleDb
Public Class Form1
    Private conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database2.accdb")
    Dim dr As OleDbDataReader
   

    

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.Open()

        Dim are As Integer = 2
        Dim id As Int32 = 1
        Dim query As String = "select * from newstable1"
        Dim cmd As New OleDbCommand(query, conn)
        'da.Fill(ds, "mynews")
        dr = cmd.ExecuteReader()
        While dr.Read
            'If () Then
            If dr("prof_id") = id Then
                RichTextBox1.AppendText(dr("news2") & vbNewLine)

            End If

        End While
        dr.Close()
        conn.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
