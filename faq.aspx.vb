Imports Anetics.Data
Imports System.Data
Imports SharedProperties

Partial Class faq
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadFaq()

    End Sub

    Sub LoadFaq()
        Dim tr As TableRow = Nothing
        Dim tc As TableCell = Nothing

        Dim filter As String = ""
        If Request.QueryString("view") <> "" Then filter = Request.QueryString("view").ToLower

        lnkShowAll.Visible = (filter <> "")
        lnkForCustomers.Visible = (Not filter = "customer")
        lnkForDesigners.Visible = (Not filter = "designer")

        Dim db = New EasySQL(Constring)
        db.ReturnType = EasyDBReturnType.DataTable
        db.AddParameter("@filter", filter)
        db.CommandText = "SELECT * FROM tblFaq WHERE FaqCategory LIKE '%'+@filter+'%' ORDER BY FaqPriority ASC, FaqID ASC"
        Dim dt As DataTable = db.Execute()

        For Each dr As DataRow In dt.Rows
            tr = New TableRow
            tr.CssClass = "Question"

            tc = New TableCell
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = "<img src=""/App/images/faq-Q.jpg"" />"
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.VerticalAlign = VerticalAlign.Middle
            tc.Text = dr("FaqQuestion")
            tr.Cells.Add(tc)

            tblFaq.Rows.Add(tr)

            tr = New TableRow
            tr.CssClass = "Answer"

            tc = New TableCell
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = "<img src=""/App/images/faq-A.jpg"" />"
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = dr("FaqAnswer").ToString.Replace(vbCrLf, "<br />")
            tr.Cells.Add(tc)

            tblFaq.Rows.Add(tr)


        Next
    End Sub
End Class
