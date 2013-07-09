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

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataTable
        db.CommandText = "SELECT *, " & vbCrLf
        db.CommandText &= "COALESCE((SELECT AVG(CvtVote) FROM tblConceptVote WHERE CvtConceptID = ConID),0) as Rating," & vbCrLf
        db.CommandText &= "COALESCE((SELECT count(*) FROM tblConceptVote WHERE CvtConceptID = ConID),0) as RatingCount," & vbCrLf
        db.CommandText &= "(SELECT CstName FROM tblConceptStatus WHERE CstID = ConStatus) as Status" & vbCrLf
        db.CommandText &= "FROM tblConcept,tblUser WHERE ConDesignerID = UsrID ORDER BY ConName ASC"

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
        th.Text = "Product Name"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Width = 200
        th.Text = "Designer"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Width = 80
        th.Text = "Visiblity"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Width = 80
        th.Text = "Status"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Width = 80
        th.Text = "Est Price"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Width = 120
        th.Text = "Rating"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Text = ""
        tr.Cells.Add(th)

        tbl.Rows.Add(tr)
    End Sub

    Sub AddConceptListRow(dr As DataRow)
        tr = New TableRow

        tc = New TableCell
        tc.Text = CN(dr("ConName"))
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.Text = dr("UsrName")
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.Text = "Hidden"
        If dr("ConAccepted") = 1 Then tc.Text = "Visible"
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.Text = dr("Status")
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.Text = "£" & dr("ConEstPrice")
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.Text = FormatNumber(dr("Rating"), 1) & " from " & dr("RatingCount") & " Votes"
        tr.Cells.Add(tc)

        tc = New TableCell

        Dim hl = New HyperLink
        hl.NavigateUrl = "/Admin13/Concepts/Edit?ConceptID=" & dr("ConID")
        hl.ImageUrl = "/App/Images/Icon/edit-icon.png"
        tc.Controls.Add(hl)

        hl = New HyperLink
        hl.NavigateUrl = "/Admin13/Concepts/Edit?ConceptID=" & dr("ConID") & "&tab=2"
        hl.ImageUrl = "/App/Images/Icon/pictures-icon.png"
        tc.Controls.Add(hl)

        Dim ib = New ImageButton
        ib.ID = "btnDelete_" & dr("ConID")
        ib.ImageUrl = "/App/Images/Icon/delete-icon.png"
        ib.OnClientClick = "return confirm('Really delete this concept?');"
        AddHandler ib.Click, AddressOf DeleteConcept

        tc.Controls.Add(ib)

        tr.Cells.Add(tc)
        tbl.Rows.Add(tr)

    End Sub

    Sub DeleteConcept(s As Object, e As EventArgs)
        Dim id As Integer = CType(s, ImageButton).ID.Split("_")(1)

        Dim db = New EasySql
        db.AddParameter("@ConID", id)
        db.CommandText = "DELETE FROM tblConcept WHERE ConID = @ConID;"
        db.Execute()

        LoadProducts()
    End Sub
End Class
