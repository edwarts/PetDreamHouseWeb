Imports Anetics.Data
Imports System.Data
Imports SharedProperties

Partial Class Cool_Details
    Inherits System.Web.UI.Page
    Dim pu As DataRow
    Dim au As DataRow

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        MaintainScrollPositionOnPostBack = True
        pu = ThisUser

        If CoolID > 0 Then LoadCool()
    End Sub

    Sub LoadCool()
        Dim db = New EasySQL(Constring)
        db.ReturnType = EasyDBReturnType.DataRow
        db.AddParameter("@CooID", CoolID)
        db.CommandText = "SELECT *" & vbCrLf
        db.CommandText &= "FROM tblCool WHERE CooID = @CooID"

        Dim dr As DataRow = db.Execute
        If dr Is Nothing Then Exit Sub

        imgStatus.ImageUrl = "/App/Images/Cool-Item-Icon.png"
        hDesignTitle.InnerHtml = dr("CooName")
        lblFrom.Text = "From " & dr("CooSiteName")
        lblWhat.Text = dr("CooWhat").ToString.Replace(vbCrLf, "<br />")
        lblWhy.Text = dr("CooWhy").ToString.Replace(vbCrLf, "<br />")

        imgMain.ImageUrl = "/550x412R/Data/Image/Cool/" & dr("CooImage1")
        imgMain.AlternateText = "Pet Dream House " & dr("CooName")

        imgMain.Visible = True

        For n As Integer = 1 To 5
            If CN(dr("CooImage" & n)) <> "" Then
                Dim img As Image = imgs.FindControl("Image" & n)
                img.ImageUrl = "/" & imgSample.Width.Value & "x" & imgSample.Height.Value & "/Data/Image/Cool/" & dr("CooImage" & n)
                img.Visible = True
                img.Attributes.Add("onclick", "document.getElementById('" & imgMain.ClientID & "').setAttribute('src','/550x412R/Data/Image/Cool/" & dr("CooImage" & n) & "');")
            Else

            End If

        Next

        lnkWhere.Target = "_blank"
        lnkWhere.NavigateUrl = dr("CooSiteUrl")

        If IsNumeric(CN(dr("CooEstPrice"))) Then
            lblEstPrice.Text = "Buying Details: <span>On sale at £" & FormatNumber(dr("CooEstPrice"), 2) & "</span>"
        Else
            lblEstPrice.Text = "Buying Details: <span>TBC</span>"
        End If

        Dim ct As String = CN(dr("CooTypeFlags"))
        divFor.Controls.Clear()
        For Each i As Char In ct
            Dim img = New HtmlImage
            img.Src = "/App/Images/Types/" & i & ".png"
            divFor.Controls.Add(img)
        Next

        AddMeta(CN(dr("CooMetaTitle")), CN(dr("CooMetaDesc")), CN(dr("CooMetaKeywords")))

        lnkInStore.Visible = (dr("CooInStore") = 1)

    End Sub

    Sub AddMeta(pTitle As String, Desc As String, Keywords As String)

        If Desc <> "" Then
            Dim m = New HtmlMeta
            m.Name = "Description"
            m.Content = Desc
            Header.Controls.Add(m)
        End If

        If Keywords <> "" Then
            Dim m = New HtmlMeta
            m.Name = "Keywords"
            m.Content = Keywords
            Header.Controls.Add(m)
        End If

        If pTitle <> "" Then
            Title = pTitle
        End If

    End Sub

End Class
