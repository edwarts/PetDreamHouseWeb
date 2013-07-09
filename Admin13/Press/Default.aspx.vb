Imports Anetics.Data
Imports System.Data
Imports SharedProperties
Imports Admin

Partial Class Admin13_Faq_Default
    Inherits System.Web.UI.Page
    Dim tr As TableRow
    Dim th As TableHeaderCell
    Dim tc As TableCell

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        LoadProducts()
    End Sub

    Sub LoadProducts()

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataTable
        db.CommandText = "SELECT * " & vbCrLf
        db.CommandText &= "FROM tblPress ORDER BY PrsDate DESC"

        Dim dt As DataTable = db.Execute
        tbl.Rows.Clear()
        AddConceptListHeader()

        For Each dr As DataRow In dt.Rows
            AddConceptListRow(dr)
        Next

    End Sub

    Sub AddConceptListHeader()
        tr = New TableRow

        th = New TableHeaderCell
        th.Text = "Title"
        tr.Cells.Add(th)


        th = New TableHeaderCell
        th.Width = 150
        th.Text = "Date"
        tr.Cells.Add(th)


        th = New TableHeaderCell
        th.Width = 80
        th.Text = ""
        tr.Cells.Add(th)

        tbl.Rows.Add(tr)
    End Sub

    Sub AddConceptListRow(dr As DataRow)
        tr = New TableRow

        tc = New TableCell
        tc.Text = CN(dr("PrsTitle"))
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.Text = Format(dr("PrsDate"), "dd MMMM yyyy")
        tr.Cells.Add(tc)

        tc = New TableCell

        Dim hl = New HyperLink
        hl.NavigateUrl = "/Admin13/press/Edit?PressID=" & dr("PrsID")
        hl.ImageUrl = "/App/Images/Icon/edit-icon.png"
        tc.Controls.Add(hl)

        Dim ib = New ImageButton
        ib.ID = "btnDelete_" & dr("PrsID")
        ib.ImageUrl = "/App/Images/Icon/delete-icon.png"
        ib.OnClientClick = "return confirm('Really delete this item?');"
        AddHandler ib.Click, AddressOf DeleteFaq

        tc.Controls.Add(ib)

        tr.Cells.Add(tc)
        tbl.Rows.Add(tr)

    End Sub

    Sub DeleteFaq(s As Object, e As EventArgs)
        Dim id As Integer = CType(s, ImageButton).ID.Split("_")(1)

        Dim db = New EasySql
        db.AddParameter("@PrsID", id)
        db.CommandText = "DELETE FROM tblPress WHERE PrsID = @PrsID;"
        db.Execute()

        LoadProducts()
    End Sub

End Class
