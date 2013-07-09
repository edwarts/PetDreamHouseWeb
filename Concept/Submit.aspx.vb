Imports System.Data
Imports Anetics.Data
Imports SharedProperties
Imports System.IO

Partial Class Concept_Submit
    Inherits System.Web.UI.Page
    Dim usr As DataRow = Nothing

    Dim imgPath As String = "/Data/Image/Concept/"
    Dim DesignID As Integer = 0

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request.QueryString("DesignID")) Then DesignID = Request.QueryString("DesignID")
        usr = ThisUser
        If usr Is Nothing Then Response.Redirect("/login")

        If Not IsPostBack Then
            If DesignID > 0 Then LoadDesign()
        End If

        If Img1.Value = "" Then Image1.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=blank.jpg"
        If Img2.Value = "" Then Image2.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=blank.jpg"
        If Img3.Value = "" Then Image3.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=blank.jpg"
        If Img4.Value = "" Then Image4.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=blank.jpg"
        If Img5.Value = "" Then Image5.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=blank.jpg"

        MaintainScrollPositionOnPostBack = True
    End Sub

    Sub LoadDesign()

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataRow
        db.AddParameter("@ConID", DesignID)
        db.AddParameter("@ConDesignerID", usr("UsrID"))
        db.CommandText = "SELECT * FROM tblConcept WHERE ConID = @ConID AND ConDesignerID = @ConDesignerID"

        Dim dr As DataRow = db.Execute
        If dr Is Nothing Then Exit Sub

        txtName.Text = CN(dr("ConName"))
        txtDescription.Text = CN(dr("ConSummary"))
        txtEstPrice.Text = CN(dr("ConEstPrice"), "0.00")

        If CN(dr("ConImage1")) <> "" Then
            Img1.Value = dr("ConImage1")
            Image1.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=" & imgPath & Img1.Value
        End If

        If CN(dr("ConImage2")) <> "" Then
            Img2.Value = dr("ConImage2")
            Image2.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=" & imgPath & Img2.Value
        End If

        If CN(dr("ConImage3")) <> "" Then
            Img3.Value = dr("ConImage3")
            Image3.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=" & imgPath & Img3.Value
        End If

        If CN(dr("ConImage4")) <> "" Then
            Img4.Value = dr("ConImage4")
            Image4.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=" & imgPath & Img4.Value
        End If

        If CN(dr("ConImage5")) <> "" Then
            Img5.Value = dr("ConImage5")
            Image5.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=" & imgPath & Img5.Value
        End If

        Dim ctf As String = CN(dr("ConTypeFlags"))
        cbxC.Checked = ctf.Contains("C")
        cbxD.Checked = ctf.Contains("D")
        cbxS.Checked = ctf.Contains("S")
        cbxO.Checked = ctf.Contains("O")
    End Sub


    Function CreateFilename(fi As FileInfo) As FileInfo
        Dim fn = New FileInfo(fi.DirectoryName & "\" & Anetics.Crypto.CryptoService.HashString(fi.FullName & Now, Anetics.Crypto.HashType.MD5) & fi.Extension)
        Return fn
    End Function

    Protected Sub UpMain_UploadRequested(s As Object, fn As String) Handles UpMain.UploadRequested, SkinnedUpload1.UploadRequested, SkinnedUpload2.UploadRequested, SkinnedUpload3.UploadRequested, SkinnedUpload4.UploadRequested
        Dim su As App_Controls_SkinnedUpload = s
        If Not su.HasFile Then Exit Sub


        Dim fi = New FileInfo(Server.MapPath(imgPath) & su.Filename)
        Dim saf = CreateFilename(fi)

        su.SaveAs(saf.FullName)

        If s Is UpMain Then Img1.Value = saf.Name : Image1.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=" & imgPath & Img1.Value
        If s Is SkinnedUpload1 Then Img2.Value = saf.Name : Image2.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=" & imgPath & Img2.Value
        If s Is SkinnedUpload2 Then Img3.Value = saf.Name : Image3.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=" & imgPath & Img3.Value
        If s Is SkinnedUpload3 Then Img4.Value = saf.Name : Image4.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=" & imgPath & Img4.Value
        If s Is SkinnedUpload4 Then Img5.Value = saf.Name : Image5.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=" & imgPath & Img5.Value

    End Sub

    Sub DeleteImage(s As Object, e As EventArgs) Handles UpMain.DeleteRequested, SkinnedUpload1.DeleteRequested, SkinnedUpload2.DeleteRequested, SkinnedUpload3.DeleteRequested, SkinnedUpload4.DeleteRequested
        Dim ob As App_Controls_SkinnedUpload = s

        If s Is UpMain Then Img1.Value = "" : Image1.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=blank.jpg"
        If s Is SkinnedUpload1 Then Img2.Value = "" : Image2.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=blank.jpg"
        If s Is SkinnedUpload2 Then Img3.Value = "" : Image3.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=blank.jpg"
        If s Is SkinnedUpload3 Then Img4.Value = "" : Image4.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=blank.jpg"
        If s Is SkinnedUpload4 Then Img5.Value = "" : Image5.ImageUrl = "/Data/ImgGen.aspx?w=100&h=75&src=blank.jpg"


    End Sub

    Sub Save() Handles btnSave.Click
        lblResponse.Text = ""
        If txtName.Text = "" Then lblResponse.Text = "Product Name Missing &nbsp;&nbsp;"
        If txtDescription.Text = "" Then lblResponse.Text = "Product Description Missing &nbsp;&nbsp;"
        If Img1.Value = "" Then lblResponse.Text = "You must add at least 1 image &nbsp;&nbsp;"

        If lblResponse.Text <> "" Then Exit Sub


        Dim db = New EasySQL(Constring)
        db.AddParameter("@ConStatus", 1)
        db.AddParameter("@ConName", txtName.Text)
        db.AddParameter("@ConSummary", txtDescription.Text)
        db.AddParameter("@ConDesignerID", usr("UsrID"))
        If IsNumeric(txtEstPrice.Text) Then db.AddParameter("@ConEstPrice", txtEstPrice.Text)
        db.AddParameter("@ConSubmitted", Now)
        db.AddParameter("@ConImage1", Img1.Value)
        db.AddParameter("@ConImage2", Img2.Value)
        db.AddParameter("@ConImage3", Img3.Value)
        db.AddParameter("@ConImage4", Img4.Value)
        db.AddParameter("@ConImage5", Img5.Value)
        db.AddParameter("@ConAccepted", 0)

        Dim ctf As String = ""
        If cbxC.Checked Then ctf &= "C"
        If cbxD.Checked Then ctf &= "D"
        If cbxS.Checked Then ctf &= "S"
        If cbxO.Checked Then ctf &= "O"
        db.AddParameter("@ConTypeFlags", ctf)

        Dim i As Integer = 0

        If DesignID > 0 Then
            db.AddParameter("@ConID", DesignID)
            db.CommandText = db.UpdateString("tblConcept", "ConID = @ConID", "@ConID")
            db.ReturnType = EasyDBReturnType.Rows_Affected
            i = db.Execute
        Else
            db.CommandText = db.InsertString("tblConcept")
            db.ReturnType = EasyDBReturnType.Scope_Identity
            i = db.Execute

            If i > 0 Then

                Dim ed = New EmailDispatcher

                Dim txt = ed.FillTemplate("NewConceptSubmission.html", usr)

                txt = Replace(txt, "[ConceptID]", i)
                txt = Replace(txt, "[ConceptName]", txtName.Text)

                Dim ob = ed.SendEmail(usr("UsrName"), usr("UsrEmailAddress"), "Concept Submission", txt)
                ob = ed.SendEmailToOwner("Concept Submission", txt)
            End If

        End If

        If i > 0 Then Response.Redirect("/Donesubmission")

        If db.ErrorString <> "" Then
            If Request.IsLocal Then
                lblResponse.Text = db.ErrorString
            Else
                lblResponse.Text = "WARNING Could not save this design &nbsp;&nbsp;"
            End If
        End If
    End Sub
End Class
