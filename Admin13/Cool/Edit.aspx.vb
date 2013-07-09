Imports System.Data
Imports Anetics.Data
Imports SharedProperties
Imports Admin

Partial Class Admin13_Concepts_Edit
    Inherits System.Web.UI.Page
    Dim Imgpth As String = Server.MapPath("/Data/Image/Cool/")


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request("CoolID")) Then hdnConceptID.Value = Request("CoolID")
        If IsNumeric(Request.QueryString("tab")) And Not IsPostBack Then If Request("tab") < TabContainer1.Tabs.Count Then TabContainer1.ActiveTabIndex = Request.QueryString("tab")

        If hdnConceptID.Value > 0 And Not IsPostBack Then LoadConcept()

        tabImages.Visible = (hdnConceptID.Value > 0)
        tabNote.Visible = (hdnConceptID.Value > 0)
        MaintainScrollPositionOnPostBack = True

    End Sub

    Sub LoadConcept()

        Dim db = New EasySql
        db.AddParameter("@CooID", hdnConceptID.Value)
        db.ReturnType = EasyDBReturnType.DataRow
        db.CommandText = "SELECT * FROM tblCool WHERE CooID = @CooID"
        Dim dr As DataRow = db.Execute

        If dr Is Nothing Then Exit Sub

        h3Title.InnerText = "Edit Item"

        txtName.Text = CN(dr("CooName"))
        txtWhat.Text = CN(dr("CooWhat"))
        txtWhy.Text = CN(dr("CooWhy"))
        txtEstPrice.Text = CN(dr("CooEstPrice"))
        txtNotes.Text = CN(dr("CooNote"))
        ddlVisibility.SelectedValue = CN(dr("CooVisible"), 0)

        txtSubmitted.Text = Format(dr("CooSubmitted"), "ddd, dd MMM yyyy HH:mm")
        txtSubmitter.Text = CN(dr("CooSubmitterName"))
        txtSubmitterEmail.Text = CN(dr("CooSubmitterEmail"))

        txtSiteName.Text = CN(dr("CooSiteName"))
        txtSiteUrl.Text = CN(dr("CooSiteUrl"))

        cbxInStore.Checked = (dr("CooInStore") = 1)

        Dim ctf As String = CN(dr("CooTypeFlags"))
        cbxC.Checked = ctf.Contains("C")
        cbxD.Checked = ctf.Contains("D")
        cbxS.Checked = ctf.Contains("S")
        cbxO.Checked = ctf.Contains("O")


        For n As Integer = 1 To 5
            Dim hdn As HiddenField = tabImages.FindControl("hdnImg" & n)
            Dim img As Image = tabImages.FindControl("img" & n)
            Dim fl As App_Controls_SkinnedUpload = tabImages.FindControl("fl" & n)
            If CN(dr("CooImage" & n)) <> "" Then
                hdn.Value = CN(dr("CooImage" & n))
                img.ImageUrl = "/160x120R/Data/Image/Cool/" & CN(dr("CooImage" & n))
                fl.TextboxText = CN(dr("CooImage" & n))
            End If

        Next

        txtMetaTitle.Text = CN(dr("CooMetaTitle"))
        txtMetaDesc.Text = CN(dr("CooMetaDesc"))
        txtMetaKeywords.Text = CN(dr("CooMetaKeywords"))


    End Sub

    Sub SaveConceptDetail() Handles btnSaveDetails.Click

        Dim db = New EasySql
        db.AddParameter("@CooName", txtName.Text)
        db.AddParameter("@CooWhat", txtWhat.Text)
        db.AddParameter("@CooWhy", txtWhy.Text)
        db.AddParameter("@CooEstPrice", txtEstPrice.Text)
        db.AddParameter("@CooSubmitterName", txtSubmitter.Text)
        db.AddParameter("@CooSubmitterEmail", txtSubmitterEmail.Text)
        db.AddParameter("@CooSiteName", txtSiteName.Text)
        db.AddParameter("@CooSiteUrl", txtSiteUrl.Text)
        db.AddParameter("@CooVisible", ddlVisibility.SelectedValue)

        db.AddParameter("@CooMetaTitle", txtMetaTitle.Text)
        db.AddParameter("@CooMetaDesc", txtMetaDesc.Text)
        db.AddParameter("@CooMetaKeywords", txtMetaKeywords.Text)

        If cbxInStore.Checked Then
            db.AddParameter("@CooInStore", 1)
        Else
            db.AddParameter("@CooInStore", 0)
        End If


        Dim ctf As String = ""
        If cbxC.Checked Then ctf &= "C"
        If cbxD.Checked Then ctf &= "D"
        If cbxS.Checked Then ctf &= "S"
        If cbxO.Checked Then ctf &= "O"
        db.AddParameter("@CooTypeFlags", ctf)


        Dim i As Integer = 0

        If hdnConceptID.Value > 0 Then
            db.ReturnType = EasyDBReturnType.Rows_Affected
            db.AddParameter("@CooID", hdnConceptID.Value)
            db.CommandText = db.UpdateString("tblCool", "CooID = @CooID", "@CooID")
            i = db.Execute

        Else
            db.ReturnType = EasyDBReturnType.Scope_Identity
            db.CommandText = db.InsertString("tblCool")
            i = db.Execute
            If i > 0 Then hdnConceptID.Value = i

        End If

        If i > 0 Then
            lblDetailsResponse.Text = "Cool Item Saved"
        Else
            lblDetailsResponse.Text = "Cool Item Not Saved"
        End If

        tabImages.Visible = (hdnConceptID.Value > 0)
        tabNote.Visible = (hdnConceptID.Value > 0)


    End Sub

    Sub SaveConceptNote() Handles btnSaveNote.Click

        Dim db = New EasySql
        db.AddParameter("@CooNote", txtNotes.Text)

        Dim i As Integer = 0

        If hdnConceptID.Value > 0 Then
            db.ReturnType = EasyDBReturnType.Rows_Affected
            db.AddParameter("@CooID", hdnConceptID.Value)
            db.CommandText = db.UpdateString("tblCool", "CooID = @CooID", "@CooID")
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
        Dim col As String = "CooImage1"

        If fl Is fl1 Then img = img1 : hdn = hdnImg1 : col = "ColImage1"
        If fl Is fl2 Then img = img2 : hdn = hdnImg2 : col = "ColImage2"
        If fl Is fl3 Then img = img3 : hdn = hdnImg3 : col = "ColImage3"
        If fl Is fl4 Then img = img4 : hdn = hdnImg4 : col = "ColImage4"
        If fl Is fl5 Then img = img5 : hdn = hdnImg5 : col = "ColImage5"

        Dim fi = New IO.FileInfo(fl.PostedFile.FileName)
        Dim fn = Now.Ticks & fi.Extension


        fl.SaveAs(Imgpth & fn)
        hdn.Value = fn
        img.ImageUrl = "/160x120R/Data/Image/Cool/" & fn

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
        db.AddParameter("@CooImage1", hdnImg1.Value)
        db.AddParameter("@CooImage2", hdnImg2.Value)
        db.AddParameter("@CooImage3", hdnImg3.Value)
        db.AddParameter("@CooImage4", hdnImg4.Value)
        db.AddParameter("@CooImage5", hdnImg5.Value)

        Dim i As Integer = 0

        If hdnConceptID.Value > 0 Then
            db.ReturnType = EasyDBReturnType.Rows_Affected
            db.AddParameter("@CooID", hdnConceptID.Value)
            db.CommandText = db.UpdateString("tblCool", "CooID = @CooID", "@CooID")
            i = db.Execute

        End If

        If i > 0 Then
            lblImagesResponse.Text = "Images Saved"
        Else
            lblImagesResponse.Text = "Images Not Saved"
        End If

    End Sub

End Class
