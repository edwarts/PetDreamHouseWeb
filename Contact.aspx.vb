Imports System.Data
Imports SharedProperties

Partial Class Contact_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        LoadPageContent()

    End Sub

    Protected Sub Page_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit

    End Sub

    Sub LoadPageContent()
        Dim dr As DataRow = GetPageData("contact")
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
