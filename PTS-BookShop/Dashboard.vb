Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Dashboard
    Dim Con As New SqlConnection("Server = CHAOS\SQLEXPRESS; Database= BookshopVb;Integrated Security=True;Connect Timeout=30")
    Private Sub CountBooks()
        Dim BookNum As Integer
        Con.Open()
        Dim sql = "select COUNT(*) from BookTbl"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, Con)
        BookNum = cmd.ExecuteScalar
        Booktbl.Text = BookNum
        Con.Close()
    End Sub
    Private Sub CountUsers()
        Dim UserNum As Integer
        Con.Open()
        Dim sql = "select COUNT(*) from UserTbl"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, Con)
        UserNum = cmd.ExecuteScalar
        Usertbl.Text = UserNum
        Con.Close()
    End Sub
    Private Sub SumAmount()
        Dim Amount As Integer
        Con.Open()
        Dim sql = "select Sum(Amount) from BillTbl"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, Con)
        Amount = cmd.ExecuteScalar
        Amountbl.Text = Convert.ToString(Amount) + " Kip"
        Con.Close()

    End Sub
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CountBooks()
        CountUsers()
        SumAmount()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Application.Exit()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Dim Obj = New Books()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Dim Obj = New Users()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim Obj = New Login()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Application.Exit()
    End Sub
End Class