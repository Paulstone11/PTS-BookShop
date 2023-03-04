Imports System.Data.SqlClient
Public Class Login
    Dim Con As New SqlConnection("Server = CHAOS\SQLEXPRESS; Database= BookshopVb;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles UNameTb.TextChanged


    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        If UNameTb.Text = "" Or PasswordTb.Text = "" Then
            MsgBox("Enter Username And Password")
        Else
            Con.Open()
            Dim query = "select * from UserTbl where Name='" & UNameTb.Text & "' and Password='" & PasswordTb.Text & "'"
            cmd = New SqlCommand(query, Con)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet
            sda.Fill(ds)
            Dim a As Integer
            a = ds.Tables(0).Rows.Count
            If a = 0 Then
                MsgBox("Wrong UserName And Password")
            Else
                Dim Bill = New Bills
                Bill.UserName = UNameTb.Text
                Bill.Show()
                Me.Hide()

            End If

            Con.Close()
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Application.Exit()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim Obj = New AdminLogin()
        Obj.Show()
        Me.Hide()
    End Sub
End Class