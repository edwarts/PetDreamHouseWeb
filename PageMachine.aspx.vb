Imports System.Data
Imports SharedProperties
Imports Anetics.Data

Partial Class Store_About
    Inherits System.Web.UI.Page
    Dim dr As DataRow = Nothing

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.PreInit
        Dim sec = Request.QueryString("section")
        dr = GetPageData(sec)

        If dr Is Nothing Then Exit Sub
        Page.MasterPageFile = "/MasterPages/" & CN(dr("PagMasterPage"), "about.master")

    End Sub



    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim sec = Request.QueryString("section")

        If dr Is Nothing Then Exit Sub


        HeaderImage.Visible = (CN(dr("PagHeaderImage"), 0) > 0)
        HeaderImage.ImageUrl = "/Data/Image/Headers/" & CN(dr("HedImage"))
        PagHeading.InnerText = CN(dr("PagHeading"))

		' Gary commented this out as it seems to work better without it
        'If HeaderImage.Visible Then
        '    mainDiv.Style("border-top") = "none"
        'End If

        Page.Title = PagHeading.InnerText
        PagSubTitle.InnerText = CN(dr("PagSubTitle"))

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

    Function GetPageData(name As String) As DataRow
        Dim db = New EasySql
        db.AddParameter("@PagTag", name)
        db.ReturnType = EasyDBReturnType.DataRow

        Dim b = New EasySqlJoinBuilder("tblPage", True)
        b.AddJoin(JoinOption.LEFT, "tblHeaderImages", "PagHeaderImage = HedID")
        db.CommandText = b.CommandText

        db.CommandText &= " WHERE PagTag = @PagTag"

        db.ThowErrors = True
        Dim dr As DataRow = db.Execute

        Return dr
    End Function
End Class
