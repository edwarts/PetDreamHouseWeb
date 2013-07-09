Imports SharedProperties
Imports System.Data
Imports Anetics.Data

Partial Class Admin13_Page_Edit
    Inherits System.Web.UI.Page
    Dim SubSection As String = ""

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Request.QueryString("SubSection") <> "" Then SubSection = Request.QueryString("SubSection")

        LoadBlocks()

        If Not IsPostBack Then LoadData()
    End Sub

    Sub LoadBlocks()
        If IsPostBack Then Exit Sub
        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataSet
        db.CommandText = "SELECT * FROM tblFooterBlocks ORDER BY BlkName ASC;"
        db.CommandText &= "SELECT * FROM tblAdvert ORDER BY AdvName ASC;"
        db.CommandText &= "SELECT * FROM tblHeaderImages ORDER BY HedName ASC"


        Dim ds As DataSet = db.Execute

        For n As Integer = 1 To 4
            Dim ddl As DropDownList = pnlFooterBlocks.FindControl("ddlFB" & n)
            Dim img As Image = pnlFooterBlocks.FindControl("imgFB" & n)
            img.Style.Add("margin", "5px 0px")
            img.Width = 180
            img.Height = 120
            ddl.Items.Clear()
            ddl.EnableViewState = True
            ddl.AutoPostBack = True

            ddl.Items.Add(New ListItem("No Image", 0))

            For Each dr As DataRow In ds.Tables(0).Rows

                Dim li As New ListItem
                li.Text = dr("BlkName")
                li.Value = dr("BlkID")
                ddl.Items.Add(li)
            Next
            If ddl.Items.Count >= n Then ddl.SelectedIndex = n - 1
            ShowFooterBlock(ddl, Nothing)


        Next

        For n As Integer = 1 To 5
            Dim ddl As DropDownList = pnlSideAdverts.FindControl("ddlSD" & n)
            ddl.Width = 250
            Dim img As Image = pnlSideAdverts.FindControl("imgSD" & n)
            img.Style.Add("margin", "5px 0px")
            ddl.Items.Clear()
            ddl.EnableViewState = True
            ddl.AutoPostBack = True
            ddl.Style.Add("vertical-align", "top")
            ddl.Style.Add("margin", "15px 0px")

            ddl.Items.Add(New ListItem("No Image", 0))

            For Each dr As DataRow In ds.Tables(1).Rows
                Dim li As New ListItem
                li.Text = CN(dr("AdvName"), CN(dr("AdvImage")))
                li.Value = dr("AdvID")
                ddl.Items.Add(li)
            Next
            If ddl.Items.Count >= n Then ddl.SelectedIndex = n - 1
            ShowSideBlock(ddl, Nothing)
        Next

        ddlHeaderImage.Items.Clear()
        ddlHeaderImage.Items.Add(New ListItem("No Image", 0))

        ddlHeaderImage.Width = 250

        imgHeaderImage.Style.Add("margin", "5px 0px")
        ddlHeaderImage.EnableViewState = True
        ddlHeaderImage.AutoPostBack = True
        ddlHeaderImage.Style.Add("vertical-align", "top")
        ddlHeaderImage.Style.Add("margin", "15px 0px")
        For Each dr As DataRow In ds.Tables(2).Rows
            Dim li As New ListItem
            li.Text = dr("HedName")
            li.Value = dr("HedID")
            ddlHeaderImage.Items.Add(li)
        Next
        ShowHeaderBlock(ddlHeaderImage, Nothing)

    End Sub

    Sub ShowFooterBlock(s As Object, e As EventArgs) Handles ddlFB1.SelectedIndexChanged, ddlFB2.SelectedIndexChanged, ddlFB3.SelectedIndexChanged, ddlFB4.SelectedIndexChanged
        Dim img As Image = Nothing
        Dim ddl As DropDownList = s

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataRow
        db.AddParameter("@BlkID", ddl.SelectedValue)
        db.CommandText = "SELECT * FROM tblFooterBlocks WHERE BlkID = @BlkID"


        Dim dr As DataRow = db.Execute

        If s Is ddlFB1 Then img = imgFB1
        If s Is ddlFB2 Then img = imgFB2
        If s Is ddlFB3 Then img = imgFB3
        If s Is ddlFB4 Then img = imgFB4

        img.Visible = (Not dr Is Nothing)
        If dr Is Nothing Then Exit Sub

        img.ImageUrl = "/180x120R/App/Images/Cubes/" & dr("BlkImage")
    End Sub

    Sub ShowSideBlock(s As Object, e As EventArgs) Handles ddlSD1.SelectedIndexChanged, ddlSD2.SelectedIndexChanged, ddlSD3.SelectedIndexChanged, ddlSD4.SelectedIndexChanged, ddlSD5.SelectedIndexChanged
        Dim img As Image = Nothing
        Dim lnk As HyperLink = Nothing
        Dim ddl As DropDownList = s

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataRow
        db.AddParameter("@AdvID", ddl.SelectedValue)
        db.CommandText = "SELECT * FROM tblAdvert WHERE AdvID = @AdvID"


        Dim dr As DataRow = db.Execute

        If s Is ddlSD1 Then img = imgSD1 : lnk = lnkSD1
        If s Is ddlSD2 Then img = imgSD2 : lnk = lnkSD2
        If s Is ddlSD3 Then img = imgSD3 : lnk = lnkSD3
        If s Is ddlSD4 Then img = imgSD4 : lnk = lnkSD4
        If s Is ddlSD5 Then img = imgSD5 : lnk = lnkSD5

        img.Visible = (Not dr Is Nothing)
        lnk.Visible = (Not dr Is Nothing)
        If dr Is Nothing Then Exit Sub

        img.ImageUrl = "/Data/Image/Advertisements/" & dr("AdvImage")
        lnk.Text = CN(dr("AdvLink"))
        lnk.NavigateUrl = CN(dr("AdvLink"))
    End Sub

    Sub ShowHeaderBlock(s As Object, e As EventArgs) Handles ddlHeaderImage.SelectedIndexChanged
        Dim img As Image = imgHeaderImage
        Dim lnk As HyperLink = Nothing
        Dim ddl As DropDownList = s

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataRow
        db.AddParameter("@HedID", ddl.SelectedValue)
        db.CommandText = "SELECT * FROM tblHeaderImages WHERE HedID = @HedID"


        Dim dr As DataRow = db.Execute

        imgHeaderImage.Visible = (Not dr Is Nothing)

        If dr Is Nothing Then Exit Sub

        img.ImageUrl = "/Data/Image/Headers/" & dr("HedImage")
        'lnk.Text = CN(dr("HedNavigateUrl"))
        'lnk.NavigateUrl = lnk.Text
    End Sub

    Sub LoadData()

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataRow
        db.AddParameter("@PagTag", SubSection)
        Dim dr As DataRow = db.Select("tblPage", EasyDBReturnType.DataRow)


        If dr Is Nothing Then Exit Sub

        h3PageName.InnerText = CN(dr("PagName"))

        txtHeading.Text = CN(dr("PagHeading"))
        txtSubTitle.Text = CN(dr("PagSubTitle"))
        txtBody.Text = CN(dr("PagBody"))
        txtMetaKeys.Text = CN(dr("PagMetaKeywords"))
        txtMetaDesc.Text = CN(dr("PagMetaDescription"))
        txtPageTitle.Text = CN(dr("PagPageTitle"))

        Dim fb = Split(CN(dr("PagBottomBlocks"), ""), ",")
        For n As Integer = 0 To fb.Length - 1
            Try
                Dim ddl As DropDownList = pnlFooterBlocks.FindControl("ddlFB" & n + 1)
                ddl.SelectedValue = fb(n)
                ShowFooterBlock(ddl, Nothing)
            Catch ex As Exception

            End Try
        Next

        Dim sb = Split(CN(dr("PagRightBlocks"), ""), ",")
        For n As Integer = 0 To sb.Length - 1
            Try
                Dim ddl As DropDownList = pnlSideAdverts.FindControl("ddlSD" & n + 1)
                ddl.SelectedValue = sb(n)
                ShowSideBlock(ddl, Nothing)
            Catch ex As Exception

            End Try
        Next

        ddlHeaderImage.SelectedValue = CN(dr("PagHeaderImage"), 0)
        ShowHeaderBlock(ddlHeaderImage, Nothing)

        TabHeaderImage.Visible = (dr("PagAllowHeaderImage") = 1)
        If Not TabHeaderImage.Visible Then ddlHeaderImage.SelectedValue = 0

    End Sub

    Sub SaveDetails(s As Object, e As EventArgs) Handles btnSaveDetails.Click

        Dim db As New EasySql
        db.AddParameter("@PagTag", SubSection)
        db.AddParameter("@PagHeading", txtHeading.Text)
        db.AddParameter("@PagSubTitle", txtSubTitle.Text)
        db.AddParameter("@PagBody", txtBody.Text)
        db.AddParameter("@PagMetaKeywords", txtMetaKeys.Text)
        db.AddParameter("@PagMetaDescription", txtMetaDesc.Text)
        db.AddParameter("@PagPageTitle", txtPageTitle.Text)
        db.ReturnType = EasyDBReturnType.Rows_Affected

        Dim fb = New String() {ddlFB1.SelectedValue, ddlFB2.SelectedValue, ddlFB3.SelectedValue, ddlFB4.SelectedValue}
        db.AddParameter("@PagBottomBlocks", Join(fb, ","))

        Dim sb = New String() {ddlSD1.SelectedValue, ddlSD2.SelectedValue, ddlSD3.SelectedValue, ddlSD4.SelectedValue, ddlSD5.SelectedValue}
        db.AddParameter("@PagRightBlocks", Join(sb, ","))

        db.AddParameter("@PagHeaderImage", ddlHeaderImage.SelectedValue)

        Dim i = db.Update("tblPage", "PagTag = @PagTag", "@PagTag")

        If i > 0 Then
            lblSaveDetailResponse.Text = "Page Saved &nbsp;&nbsp;"
        Else
            lblSaveDetailResponse.Text = "WARNING - Save Failed &nbsp;"
        End If
    End Sub
End Class

