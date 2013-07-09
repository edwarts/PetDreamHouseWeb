Imports Anetics.Data
Imports System.Data
Imports SharedProperties

Partial Class Concept_Details
    Inherits System.Web.UI.Page
    Dim ConceptID As Integer = 0
    Dim pu As DataRow
    Dim au As DataRow

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request.QueryString("ConceptID")) Then ConceptID = Request.QueryString("ConceptID")
        pu = ThisUser

        If pu Is Nothing Then
            btnSubmitVote.OnClientClick = "return RequestLogonDialog();"
        End If

        If ConceptID > 0 Then LoadConcept()

    End Sub

    Sub LoadConcept()
        Dim db = New EasySQL(Constring)
        db.ReturnType = EasyDBReturnType.DataRow
        db.AddParameter("@ConID", ConceptID)
        db.CommandText = "SELECT *," & vbCrLf
        db.CommandText &= "COALESCE((SELECT AVG(CvtVote) FROM tblConceptVote WHERE CvtConceptID = ConID),0) as Vote" & vbCrLf
        db.CommandText &= "" & vbCrLf
        db.CommandText &= "FROM tblConcept,tblUser,tblConceptStatus WHERE ConDesignerID = UsrID AND CstID = ConStatus AND ConID = @ConID"

        Dim dr As DataRow = db.Execute
        If dr Is Nothing Then Exit Sub

        imgStatus.ImageUrl = "/App/Images/Concept Images/" & dr("CstIcon")
        hDesignTitle.InnerHtml = dr("ConName")
        lblDesigner.Text = "By " & dr("UsrName")

        If CN(dr("ConDesignerUrl")) <> "" Then
            lblDesigner.Text = "By <a href=""" & dr("ConDesignerUrl") & """>" & dr("UsrName") & "<a>"
        End If

        lblLargeVote.Text = FormatNumber(dr("Vote"), 1)
        lblDateSubmitted.Text = Format(CN(dr("ConSubmitted"), Now), "dd MMM yyyy")

        lblDesc.Text = CN(dr("ConSummary")).ToString.Replace(vbCrLf, "<br />")

        imgMain.ImageUrl = "/550x412R/Data/Image/Concept/" & dr("ConImage1")
        imgMain.AlternateText = "Pet Dream House " & dr("ConName")

        imgStars.ImageUrl = "/data/image/gen/starbar.aspx?v=" & dr("Vote") & "&t=large"


        For n As Integer = 1 To 5
            If CN(dr("ConImage" & n)) <> "" Then

                Dim im As Image = Thumbs.FindControl("Image" & n)

                im.ImageUrl = "/" & imgSample.Width.Value & "x" & imgSample.Height.Value & "R/Data/Image/Concept/" & dr("ConImage" & n)
                im.Visible = True
                im.Attributes.Add("onclick", "document.getElementById('" & imgMain.ClientID & "').setAttribute('src','/550x412R/Data/Image/Concept/" & dr("ConImage" & n) & "');")
            End If

        Next

        If IsNumeric(CN(dr("ConEstPrice"))) Then
            lblEstPrice.Text = "Estimated Price: £" & FormatNumber(dr("ConEstPrice"), 2)
        Else
            lblEstPrice.Text = "Estimated Price: £ TBA"
        End If


        Dim v As Integer = -1

        Try
            v = PublicUserFindVote(pu("UsrID"), ConceptID)
        Catch ex As Exception
        End Try

        If v > -1 Then
            If v = 1 Then V1.Checked = True Else V1.Enabled = False
            If v = 2 Then V2.Checked = True Else V2.Enabled = False
            If v = 3 Then V3.Checked = True Else V3.Enabled = False
            If v = 4 Then V4.Checked = True Else V4.Enabled = False
            If v = 5 Then V5.Checked = True Else V5.Enabled = False

            lblVoteResponse.Text = "You Voted " & v & " For this Concept"
            btnSubmitVote.Visible = False
        End If

        If Not pu Is Nothing Then
            If pu("UsrID") = dr("UsrID") Then
                lnkEditDesign.NavigateUrl = "/Concept/Submit?DesignID=" & dr("ConID")
                lblVoteResponse.Text = "You cannot vote for your own Concept"
            End If
            btnSubmitVote.Visible = (Not pu("UsrID") = dr("UsrID"))
            VoteOptions.Visible = btnSubmitVote.Visible
            lnkEditDesign.Visible = Not btnSubmitVote.Visible
        End If

        Dim ct As String = CN(dr("ConTypeFlags"))
        divFor.Controls.Clear()
        For Each i As Char In ct
            Dim img = New HtmlImage
            img.Src = "/App/Images/Types/" & i & ".png"
            divFor.Controls.Add(img)
        Next

        AddMeta(CN(dr("ConMetaTitle")), CN(dr("ConMetaDesc")), CN(dr("ConMetaKeywords")))

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

    Sub LoadCurrentVote()
        Dim db = New EasySQL(Constring)
        db.ReturnType = EasyDBReturnType.DataRow
        db.AddParameter("@ConID", ConceptID)
        db.CommandText = "SELECT COALESCE(AVG(CvtVote),0) FROM tblConceptVote WHERE CvtConceptID = @ConID" & vbCrLf

        Dim dr As DataRow = db.Execute
        If dr Is Nothing Then Exit Sub

        imgStars.ImageUrl = "/data/image/gen/starbar.aspx?v=" & dr(0) & "&t=large"
        lblLargeVote.Text = FormatNumber(dr(0), 1)

        Dim v As Integer = -1

        Try
            v = PublicUserFindVote(pu("UsrID"), ConceptID)
        Catch ex As Exception
        End Try

        If v > -1 Then
            If v = 1 Then V1.Checked = True Else V1.Enabled = False
            If v = 2 Then V2.Checked = True Else V2.Enabled = False
            If v = 3 Then V3.Checked = True Else V3.Enabled = False
            If v = 4 Then V4.Checked = True Else V4.Enabled = False
            If v = 5 Then V5.Checked = True Else V5.Enabled = False

            lblVoteResponse.Text = "You Voted " & v & " For this Concept"
            btnSubmitVote.Visible = False
        End If

    End Sub

    Protected Sub btnSubmitVote_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnSubmitVote.Click
        Dim v = 0
        If V1.Checked Then v = 1
        If V2.Checked Then v = 2
        If V3.Checked Then v = 3
        If V4.Checked Then v = 4
        If V5.Checked Then v = 5


        If pu Is Nothing Then
            Response.Redirect("/login?ReturnUrl=" & HttpUtility.UrlEncode(Form.Action))
        Else
            If v = 0 Then
                lblVoteResponse.Text = "You must select a vote between 1 and 5"
                Exit Sub
            End If

            Dim db = New EasySQL(Constring)
            db.ReturnType = EasyDBReturnType.Rows_Affected
            db.AddParameter("@CvtUserID", pu("UsrID"))
            db.AddParameter("@CvtConceptID", ConceptID)
            db.AddParameter("@CvtVote", v)
            db.AddParameter("@CvtDate", Now)
            db.CommandText = db.InsertString("tblConceptVote", True, "CvtUserID,CvtConceptID")
            Dim i = db.Execute()

            If i > 0 Then
                lblVoteResponse.Text = "Thank you, Your vote was submitted"
                LoadCurrentVote()
            Else
                lblVoteResponse.Text = "You have already voted for this concept"
            End If
        End If
    End Sub





End Class
