Imports Anetics.Data
Imports System.Data
Imports SharedProperties
Imports Admin

Partial Class Admin13_Default
    Inherits System.Web.UI.Page
    Dim tr As TableRow
    Dim th As TableHeaderCell
    Dim tc As TableCell

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        LoadProducts()
    End Sub

    Sub LoadProducts()

        Dim dt As DataTable = GetProductList()
        tbl.Rows.Clear()
        AddProductListHeader()

        For Each dr As DataRow In dt.Rows
            AddProductListRow(dr)
        Next

    End Sub

    Sub AddProductListHeader()
        tr = New TableRow

        th = New TableHeaderCell
        th.Text = "Product Name"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Width = 80
        th.Text = "Price"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Width = 60
        th.Text = "Sales"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Width = 60
        th.Text = "Options"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Width = 60
        th.Text = "Images"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Text = ""
        tr.Cells.Add(th)

        tbl.Rows.Add(tr)
    End Sub

    Sub AddProductListRow(dr As DataRow)
        tr = New TableRow

        tc = New TableCell
        tc.Text = CN(dr("PrdFullName"))
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.Text = "£" & dr("PrdPrice")
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.Text = dr("Sales")
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.Text = dr("Options")
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.Text = dr("Images")
        tr.Cells.Add(tc)

        tc = New TableCell

        Dim hl = New HyperLink
        hl.NavigateUrl = "/Admin13/Products/Edit?ProductID=" & dr("PrdID")
        hl.ImageUrl = "/App/Images/Icon/edit-icon.png"
        tc.Controls.Add(hl)

        hl = New HyperLink
        hl.NavigateUrl = "/Admin13/Products/Edit?ProductID=" & dr("PrdID") & "&tab=3"
        hl.ImageUrl = "/App/Images/Icon/pictures-icon.png"
        tc.Controls.Add(hl)

        Dim ib = New ImageButton
        ib.ID = "btnDelete_" & dr("PrdID")
        ib.ImageUrl = "/App/Images/Icon/delete-icon.png"
        ib.OnClientClick = "return confirm('Really delete this product?');"
        AddHandler ib.Click, AddressOf DeleteProduct

        tc.Controls.Add(ib)

        tr.Cells.Add(tc)
        tbl.Rows.Add(tr)

    End Sub

    Sub DeleteProduct(s As Object, e As EventArgs)
        Dim id As Integer = CType(s, ImageButton).ID.Split("_")(1)

        Dim db = New EasySql
        db.AddParameter("@PrdID", id)
        db.CommandText = "DELETE FROM tblProduct WHERE PrdID = @PrdID;"
        db.CommandText &= "DELETE FROM tblProductOption WHERE OptProductID = @PrdID;"
        db.CommandText &= "DELETE FROM tblProductImage WHERE PimProductID = @PrdID"
        db.Execute()

        LoadProducts()
    End Sub
End Class
