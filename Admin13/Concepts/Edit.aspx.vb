Imports System.Data
Imports Anetics.Data
Imports SharedProperties
Imports Admin

Partial Class Admin13_Concepts_Edit
    Inherits System.Web.UI.Page
    Dim Imgpth As String = Server.MapPath("/Data/Image/Concept/")


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request("ConceptID")) Then hdnConceptID.Value = Request("ConceptID")
        If IsNumeric(Request.QueryString("tab")) And Not IsPostBack Then If Request("tab") < TabContainer1.Tabs.Count Then TabContainer1.ActiveTabIndex = Request.QueryString("tab")

        If Not IsPostBack Then LoadDrops()

        If hdnConceptID.Value > 0 And Not IsPostBack Then LoadConcept()

        tabImages.Visible = (hdnConceptID.Value > 0)
        tabNote.Visible = (hdnConceptID.Value > 0)

    End Sub

    Sub LoadDrops()
        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataSet
        db.CommandText = "SELECT * FROM tblUser ORDER BY UsrName ASC;"
        db.CommandText &= "SELECT * FROM tblConceptStatus"

        Dim ds As DataSet = db.Execute

        ddlDesigner.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim li As New ListItem(CN(dr("UsrName")), dr("UsrID"))
            ddlDesigner.Items.Add(li)
        Next

        ddlStatus.Items.Clear()
        For Each dr As DataRow In ds.Tables(1).Rows
            Dim li As New ListItem(CN(dr("CstName")), dr("CstID"))
            ddlStatus.Items.Add(li)
        Next
    End Sub

    Sub LoadConcept()

        Dim db = New EasySql
        db.AddParameter("@ConID", hdnConceptID.Value)
        db.ReturnType = EasyDBReturnType.DataRow
        db.CommandText = "SELECT * FROM tblConcept WHERE ConID = @ConID"
        Dim dr As DataRow = db.Execute

        If dr Is Nothing Then Exit Sub

        h3Title.InnerText = "Edit Concept"

        txtFullName.Text = CN(dr("ConName"))
        txtSummary.Text = CN(dr("ConSummary"))
        txtEstPrice.Text = CN(dr("ConEstPrice"))
        txtNotes.Text = CN(dr("ConNote"))
        ddlStatus.SelectedValue = CN(dr("ConStatus"), 0)
        ddlDesigner.SelectedValue = CN(dr("ConDesignerID"), 0)
        txtSubmitted.Text = Format(dr("ConSubmitted"), "ddd, dd MMM yyyy HH:mm")
        ddlVisibility.SelectedValue = dr("ConAccepted")

        txtDesignerUrl.Text = CN(dr("ConDesignerUrl"))


        Dim ctf As String = CN(dr("ConTypeFlags"))
        cbxC.Checked = ctf.Contains("C")
        cbxD.Checked = ctf.Contains("D")
        cbxS.Checked = ctf.Contains("S")
        cbxO.Checked = ctf.Contains("O")

        For n As Integer = 1 To 5
            Dim hdn As HiddenField = tabImages.FindControl("hdnImg" & n)
            Dim img As Image = tabImages.FindControl("img" & n)
            Dim fl As App_Controls_SkinnedUpload = tabImages.FindControl("fl" & n)
            If CN(dr("ConImage" & n)) <> "" Then
                hdn.Value = CN(dr("ConImage" & n))
                img.ImageUrl = "/160x120R/Data/Image/Concept/" & CN(dr("ConImage" & n))
                fl.TextboxText = CN(dr("ConImage" & n))
            End If

        Next

        txtMetaTitle.Text = CN(dr("ConMetaTitle"))
        txtMetaDesc.Text = CN(dr("ConMetaDesc"))
        txtMetaKeywords.Text = CN(dr("ConMetaKeywords"))

    End Sub

    Sub SaveConceptDetail() Handles btnSaveDetails.Click

        Dim db = New EasySql
        db.AddParameter("@ConStatus", ddlStatus.SelectedValue)
        db.AddParameter("@ConName", txtFullName.Text)
        db.AddParameter("@ConSummary", txtSummary.Text)
        db.AddParameter("@ConEstPrice", txtEstPrice.Text)
        db.AddParameter("@ConDesignerID", ddlDesigner.SelectedValue)
        db.AddParameter("@ConAccepted", ddlVisibility.SelectedValue)

        db.AddParameter("@ConMetaTitle", txtMetaTitle.Text)
        db.AddParameter("@ConMetaDesc", txtMetaDesc.Text)
        db.AddParameter("@ConMetaKeywords", txtMetaKeywords.Text)


        If txtDesignerUrl.Text <> "" Then
            If Not Uri.TryCreate(txtDesignerUrl.Text, UriKind.Absolute, Nothing) Then
                lblDetailsResponse.Text = "Invalid url format, should begine with http(s)://"
                Exit Sub
            Else

            End If
        End If

        db.AddParameter("@ConDesignerUrl", txtDesignerUrl.Text)

        Dim ctf As String = ""
        If cbxC.Checked Then ctf &= "C"
        If cbxD.Checked Then ctf &= "D"
        If cbxS.Checked Then ctf &= "S"
        If cbxO.Checked Then ctf &= "O"
        db.AddParameter("@ConTypeFlags", ctf)

        Dim i As Integer = 0

        If hdnConceptID.Value > 0 Then
            db.ReturnType = EasyDBReturnType.Rows_Affected
            db.AddParameter("@ConID", hdnConceptID.Value)
            db.CommandText = db.UpdateString("tblConcept", "ConID = @ConID", "@ConID")
            i = db.Execute

        Else
            db.ReturnType = EasyDBReturnType.Scope_Identity
            db.CommandText = db.InsertString("tblConcept")
            i = db.Execute
            If i > 0 Then hdnConceptID.Value = i

        End If

        If i > 0 Then
            lblDetailsResponse.Text = "Concept Saved"
        Else
            lblDetailsResponse.Text = "Concept Not Saved"
        End If

        tabImages.Visible = (hdnConceptID.Value > 0)
        tabNote.Visible = (hdnConceptID.Value > 0)


    End Sub

    Sub SaveConceptNote() Handles btnSaveNote.Click

        Dim db = New EasySql
        db.AddParameter("@ConNote", txtNotes.Text)

        Dim i As Integer = 0

        If hdnConceptID.Value > 0 Then
            db.ReturnType = EasyDBReturnType.Rows_Affected
            db.AddParameter("@ConID", hdnConceptID.Value)
            db.CommandText = db.UpdateString("tblConcept", "ConID = @ConID", "@ConID")
            i = db.Execute

        End If

        If i > 0 Then
            lblNoteResponse.Text = "Note Saved"
        Else
            lblNoteResponse.Text = "Note Not Saved"
        End If

    End Sub

    Sub UploadImage(s As Object, Filename As String) Handles fl1.UploadRequested, fl2.UploadRequested, fl3.UploadRequested, fl4.UploadRequested, fl5.UploadRequested
        Dim img As Image = img1
        Dim hdn As HiddenField = hdnImg1
        Dim fl As App_Controls_SkinnedUpload = s
        Dim col As String = "ConImage1"

        If fl Is fl1 Then img = img1 : hdn = hdnImg1 : col = "ColImage1"
        If fl Is fl2 Then img = img2 : hdn = hdnImg2 : col = "ColImage2"
        If fl Is fl3 Then img = img3 : hdn = hdnImg3 : col = "ColImage3"
        If fl Is fl4 Then img = img4 : hdn = hdnImg4 : col = "ColImage4"
        If fl Is fl5 Then img = img5 : hdn = hdnImg5 : col = "ColImage5"

        Dim fi = New IO.FileInfo(fl.PostedFile.FileName)
        Dim fn = Now.Ticks & fi.Extension


        fl.SaveAs(Imgpth & fn)
        hdn.Value = fn
        img.ImageUrl = "/160x120R/Data/Image/Concept/" & fn

    End Sub

    Sub ClearImage(s As Object, e As EventArgs) Handles fl1.DeleteRequested, fl2.DeleteRequested, fl3.DeleteRequested, fl4.DeleteRequested, fl5.DeleteRequested
        Dim img As Image = img1
        Dim hdn As HiddenField = hdnImg1
        Dim fl As App_Controls_SkinnedUpload = s
        Dim col As String = "ConImage1"

        If fl Is fl1 Then img = img1 : hdn = hdnImg1 : col = "ColImage1"
        If fl Is fl2 Then img = img2 : hdn = hdnImg2 : col = "ColImage2"
        If fl Is fl3 Then img = img3 : hdn = hdnImg3 : col = "ColImage3"
        If fl Is fl4 Then img = img4 : hdn = hdnImg4 : col = "ColImage4"
        If fl Is fl5 Then img = img5 : hdn = hdnImg5 : col = "ColImage5"

        hdn.Value = ""
        img.ImageUrl = "/160x120R/No-image.jpg"
    End Sub

    Sub SaveImages() Handles btnSaveimages.Click

        Dim db = New EasySql
        db.AddParameter("@ConImage1", hdnImg1.Value)
        db.AddParameter("@ConImage2", hdnImg2.Value)
        db.AddParameter("@ConImage3", hdnImg3.Value)
        db.AddParameter("@ConImage4", hdnImg4.Value)
        db.AddParameter("@ConImage5", hdnImg5.Value)

        Dim i As Integer = 0

        If hdnConceptID.Value > 0 Then
            db.ReturnType = EasyDBReturnType.Rows_Affected
            db.AddParameter("@ConID", hdnConceptID.Value)
            db.CommandText = db.UpdateString("tblConcept", "ConID = @ConID", "@ConID")
            i = db.Execute

        End If

        If i > 0 Then
            lblImagesResponse.Text = "Images Saved"
        Else
            lblImagesResponse.Text = "Images Not Saved"
        End If

    End Sub

End Class
