Imports System.Data.OleDb
Public Class Form1
    Private conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database2.accdb")
    ' Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database2.accdb"
    Dim dr As OleDbDataReader
    ' Dim ds As New DataSet
    ' Dim da As OleDb.OleDbDataAdapter
    ' Dim indec As Integer



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
                RichTextBox2.AppendText(dr("ID") & vbNewLine)
            End If

        End While
        dr.Close()
        conn.Close()
    End Sub

    Private Sub btnupdatenews_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()
        Dim query As String = "select * from newstable1"
        Dim cmd As New OleDbCommand(query, conn)

        Dim text As String = TextBox2.Text
        Dim id_num As Integer = CInt(TextBox3.Text)
        cmd.CommandText = "UPDATE newstable1 SET news2 ='" & text & "'WHERE ID = " & id_num & ";"


        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            cmd.Dispose()
        End Try

        conn.Close()
        Me.Close()
    End Sub

 
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn.Open()
        'Dim query As String = "select * from newstable1"
        'Dim cmd As New OleDbCommand(query, conn)

        Dim textnews As String = TextBox1.Text
        Dim profId As Integer = 1
        Dim query As String
        query = "INSERT INTO newstable1([prof_id],[news2]) Values (?,?)"
        Dim cmd As OleDbCommand = New OleDbCommand(query, conn)
        cmd.Parameters.Add(New OleDbParameter("prof_id", CType(profId, Integer)))
        cmd.Parameters.Add(New OleDbParameter("news2", CType(textnews, String)))
        Try
            cmd.ExecuteNonQuery() 'Executing Update Command
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message) 'Error Message
        End Try

        conn.Close()
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class
