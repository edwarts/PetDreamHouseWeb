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

        Dim db = New EasySql(Constring)
        db.ReturnType = EasyDBReturnType.DataTable
        db.CommandText = "SELECT * FROM tblPress ORDER BY PrsDate DESC"
        Dim dt As DataTable = db.Execute()

        For Each dr As DataRow In dt.Rows
            tr = New TableRow
            tr.CssClass = "Title"

            tc = New TableCell
            tc.VerticalAlign = VerticalAlign.Middle
            tc.Text = "<img src=""/App/images/press-bullet.jpg"" />"
            tc.Width = 30
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = dr("PrsTitle")
            If dr("PrsLink") <> "" Then tc.Text = "<a href=""" & dr("PrsLink") & """>" & tc.Text & "</a>"
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.VerticalAlign = VerticalAlign.Top
            tc.HorizontalAlign = HorizontalAlign.Right
            tc.Text = Format(dr("PrsDate"), "MMM yyyy")
            If dr("PrsLink") <> "" Then tc.Text = "<a href=""" & dr("PrsLink") & """>" & tc.Text & "</a>"
            tr.Cells.Add(tc)

            tblFaq.Rows.Add(tr)

            tr = New TableRow
            tr.CssClass = "Description"

            tc = New TableCell
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = ""
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = dr("PrsDesc").ToString.Replace(vbCrLf, "<br />")
            If dr("PrsLink") <> "" Then tc.Text = "<a href=""" & dr("PrsLink") & """>" & tc.Text & "</a>"
            tr.Cells.Add(tc)

            tblFaq.Rows.Add(tr)


        Next
    End Sub
End Class
