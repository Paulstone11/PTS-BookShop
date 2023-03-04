Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Books
    Dim Con As New SqlConnection("Server = CHAOS\SQLEXPRESS; Database= BookshopVb;Integrated Security=True;Connect Timeout=30")
    Private Sub Populate()
        Con.Open()
        Dim query = "select * from BookTbl"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(query, Con)
        Dim builider As SqlCommandBuilder
        builider = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        BooksDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub Filter()
        Con.Open()
        Dim query = "select * from BookTbl where Category='" & ComboBox2.SelectedItem.ToString() & "'"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(query, Con)
        Dim builider As SqlCommandBuilder
        builider = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        BooksDGV.DataSource = ds.Tables(0)
        Con.Close()

    End Sub
    Private Sub Clear()
        BookNameTb.Text = ""
        QtyTb.Text = ""
        PriceTb.Text = ""
        AuthorTb.Text = ""
        Catcb.SelectedIndex = -1
        Key = 0
    End Sub
    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If BookNameTb.Text = "" Or AuthorTb.Text = "" Or QtyTb.Text = "" Or PriceTb.Text = "" Or Catcb.SelectedIndex = -1 Then
            MsgBox("Missing Imformation")
        Else
            Con.Open()
            Dim Query As String
            Query = "insert into BookTbl values('" & BookNameTb.Text & "','" & AuthorTb.Text & "','" & Catcb.SelectedItem.ToString & "','" & QtyTb.Text & "','" & PriceTb.Text & "')"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(Query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Book Saved Successfully")
            Con.Close()
            Populate()
            Clear()

        End If
    End Sub
    Dim Key = 0

    Private Sub Books_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Populate()


    End Sub

    Private Sub BooksDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles BooksDGV.CellMouseClick
        Dim row As DataGridViewRow = BooksDGV.Rows(e.RowIndex)
        BookNameTb.Text = row.Cells(1).Value.ToString
        AuthorTb.Text = row.Cells(2).Value.ToString
        Catcb.SelectedItem = row.Cells(3).Value.ToString
        QtyTb.Text = row.Cells(4).Value.ToString
        PriceTb.Text = row.Cells(5).Value.ToString
        If BookNameTb.Text = "" Then
            Key = 0
        Else
            Key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Application.Exit()
    End Sub

    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        If BookNameTb.Text = "" Or AuthorTb.Text = "" Or QtyTb.Text = "" Or PriceTb.Text = "" Or Catcb.SelectedIndex = -1 Then
            MsgBox("Missing Imformation")
        Else
            Con.Open()
            Dim query As String
            query = "Update BookTbl set Title='" & BookNameTb.Text & "',Author='" & AuthorTb.Text & "',Category='" & Catcb.SelectedItem.ToString & "',Quantity='" & QtyTb.Text & "', Price ='" & PriceTb.Text & "' where BId=" & Key & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Book Updated Successfully")
            Con.Close()
            Populate()
            Clear()

        End If
    End Sub

    Private Sub Catcb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Catcb.SelectedIndexChanged

    End Sub

    Private Sub ClearBtn_Click(sender As Object, e As EventArgs) Handles ClearBtn.Click
        Clear()
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        If Key = 0 Then
            MsgBox("Select The Book To Be Deleted")
        Else
            Con.Open()
            Dim Query As String
            Query = "Delete from BookTbl where BId=" & Key & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(Query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Book Deleted Successfully")
            Con.Close()
            Populate()
            Clear()
        End If
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

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Dim Obj = New Dashboard()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Filter()
    End Sub

    Private Sub BunifuThinButton25_Click(sender As Object, e As EventArgs) Handles BunifuThinButton25.Click
        Populate()
    End Sub
End Class