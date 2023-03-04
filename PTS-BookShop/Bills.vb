Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Bills
    Dim Con As New SqlConnection("Server = CHAOS\SQLEXPRESS; Database= BookshopVb;Integrated Security=True;Connect Timeout=30")
    Public Property UserName As String
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
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Bills_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Populate()
        Unametbl.Text = UserName
    End Sub
    Dim Key = 0, Stock = 0, i = 0, Grdtotal = 0

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Application.Exit()
    End Sub
    Private Sub Clear()
        Key = 0
        QtyTb.Text = ""
        Pricetb.Text = ""
        ClientNameTb.Text = ""
        BNameTb.Text = ""
    End Sub
    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        Clear()
    End Sub
    Private Sub BunifuThinButton25_Click(sender As Object, e As EventArgs) Handles BunifuThinButton25.Click

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.Show()

    End Sub
    Private Sub AddBill()
        Try
            Con.Open()
            Dim Query As String
            Query = "insert into BillTbl values('" & BNameTb.Text & "','" & ClientNameTb.Text & "'," & Grdtotal & ")"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(Query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Bill Saved Successfully")
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString("PTSBookShop", New Font("Century Gothic", 25), Brushes.MidnightBlue, 300, 40)
        e.Graphics.DrawString("-----Your Bill-----", New Font("Century Gothic", 16), Brushes.MidnightBlue, 320, 100)
        Dim bm As New Bitmap(Me.BillDVG.Width, Me.BillDVG.Height)
        BillDVG.DrawToBitmap(bm, New Rectangle(0, 0, Me.BillDVG.Width, Me.BillDVG.Height))
        e.Graphics.DrawImage(bm, 200, 150)
        e.Graphics.DrawString(Grdtotal.ToString + "Kip", New Font("Century Gothic", 15), Brushes.MidnightBlue, 400, 500)
        e.Graphics.DrawString("======= Thank You =======", New Font("Century Gothic", 15), Brushes.Crimson, 280, 580)
    End Sub

    Private Sub TotalBill_Click(sender As Object, e As EventArgs) Handles TotalBill.Click

    End Sub

    Private Sub Update()
        Dim NewQty = Stock - Convert.ToInt32(QtyTb.Text)
        Con.Open()
        Dim query As String
        query = "Update BookTbl set Quantity=" & NewQty & " where BId=" & Key & ""
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, Con)
        cmd.ExecuteNonQuery()
        MsgBox("Book Updated Successfully")
        Con.Close()
        Populate()
    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click

        If Pricetb.Text = "" Or QtyTb.Text = "" Then
            MsgBox("Enter The Quantity")
        ElseIf Key = 0 Then
            MsgBox("Select The Book")
        ElseIf Convert.ToInt32(QtyTb.Text) > Stock Then
            MsgBox("Not Enough Stock")
        Else
                Dim rnum As Integer = BillDVG.Rows.Add()
                i = i + 1
                Dim total = Convert.ToInt32(QtyTb.Text) * Convert.ToInt32(Pricetb.Text)
                BillDVG.Rows.Item(rnum).Cells("Column1").Value = i
                BillDVG.Rows.Item(rnum).Cells("Column2").Value = BNameTb.Text
                BillDVG.Rows.Item(rnum).Cells("Column3").Value = Pricetb.Text
                BillDVG.Rows.Item(rnum).Cells("Column4").Value = QtyTb.Text
                BillDVG.Rows.Item(rnum).Cells("Column5").Value = total
                Grdtotal = Grdtotal + total
                Dim Tot As String
            Tot = Convert.ToString(Grdtotal) + " Kip"
            TotalBill.Text = Tot
            Update()
            AddBill()
        End If

    End Sub

    Private Sub BooksDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles BooksDGV.CellContentClick
        Dim row As DataGridViewRow = BooksDGV.Rows(e.RowIndex)
        BNameTb.Text = row.Cells(1).Value.ToString
        Pricetb.Text = row.Cells(5).Value.ToString
        Stock = Convert.ToInt32(row.Cells(4).Value.ToString)
        If BNameTb.Text = "" Then
            Key = 0
        Else
            Key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub
End Class