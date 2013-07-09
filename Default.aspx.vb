Imports Anetics.Data
Imports System.Data
Imports SharedProperties

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataTable
        db.CommandText = "SELECT * FROM tblImageSlider WHERE SliEnabled = 1"
        Dim dt As datatable = db.Execute

        For Each dr As DataRow In dt.Rows
            Slider1.AddImage(dr("SliImageUrl"), dr("SliNavigateUrl"), dr("SliTarget"))
        Next

        LoadPageContent()

    End Sub

    Sub LoadPageContent()
        Dim dr As DataRow = GetPageData("home")
        If dr Is Nothing Then Exit Sub

        Page.Title = CN(dr("PagPageTitle"))

        PagHeading.InnerText = CN(dr("PagHeading"))
        PagBody.InnerHtml = CN(dr("PagBody"))

        Ads.AdvertIDs = CN(dr("PagRightBlocks"))
        FB1.BlockIDs = CN(dr("PagBottomBlocks"))

        Dim m As New HtmlMeta
        m.Name = "Keywords"
        m.Content = CN(dr("PagMetaKeywords"))
        Page.Header.Controls.AddAt(0, m)

        m = New HtmlMeta
        m.Name = "Description"
        m.Content = CN(dr("PagMetaDescription"))
        Page.Header.Controls.AddAt(0, m)


    End Sub


End Class
