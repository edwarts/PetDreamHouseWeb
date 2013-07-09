Imports Anetics.Data
Imports SharedProperties

Partial Class Cool_Submit
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click

        If txtYourName.Text = "" Then lblResponse.Text = "Missing Name &nbsp;&nbsp;" : Exit Sub
        If Not IsEmail(txtYourEmail.Text) Then lblResponse.Text = "Invalid Email Address &nbsp;&nbsp;" : Exit Sub

        If txtProductName.Text = "" Then lblResponse.Text = " &nbsp;&nbsp;Missing Product Name" : Exit Sub
        If txtProductUrl.Text = "" Then lblResponse.Text = " &nbsp;&nbsp;Missing Product Web Address" : Exit Sub
        If Not IsUrl(txtProductUrl.Text) Then lblResponse.Text = " &nbsp;&nbsp;Invalid Web Address" : Exit Sub
        If txtWhat.Text = "" Then lblResponse.Text = " &nbsp;&nbsp;Missing Description" : Exit Sub
        If txtWhy.Text = "" Then lblResponse.Text = " &nbsp;&nbsp;Missing Reason" : Exit Sub

        lblResponse.Text = "OK &nbsp;&nbsp;"

        Dim db = New EasySql(Constring)
        db.ReturnType = EasyDBReturnType.Scope_Identity

        db.AddParameter("@CooName", txtProductName.Text)
        db.AddParameter("@CooWhat", txtWhat.Text)
        db.AddParameter("@CooWhy", txtWhy.Text)
        db.AddParameter("@CooSiteUrl", txtProductUrl.Text)
        db.AddParameter("@CooSubmitterEmail", txtYourEmail.Text)
        db.AddParameter("@CooSubmitterName", txtYourName.Text)

        Dim ctf As String = ""
        If cbxC.Checked Then ctf &= "C"
        If cbxD.Checked Then ctf &= "D"
        If cbxS.Checked Then ctf &= "S"
        If cbxO.Checked Then ctf &= "O"
        db.AddParameter("@CooTypeFlags", ctf)


        Dim i As Integer = db.Insert("tblCool")

        If i > 0 Then
            txtProductName.Text = ""
            txtProductUrl.Text = ""
            txtWhat.Text = ""
            txtWhy.Text = ""
            lblResponse.Text = " &nbsp;&nbsp;Thank you for sending us this item."

            Dim ed = New EmailDispatcher

            Dim txt = ed.FillTemplate("NewCoolSubmission.html", Nothing)

            txt = Replace(txt, "[name]", txtYourName.Text)
            txt = Replace(txt, "[email]", txtYourEmail.Text)
            txt = Replace(txt, "[CoolID]", i)
            txt = Replace(txt, "[CoolName]", txtProductName.Text)

            Dim ob = ed.SendEmail(txtYourName.Text, txtYourEmail.Text, "Cool Stuff Submission", txt)
            ob = ed.SendEmailToOwner("Cool Stuff Submission", txt)

        Else
            lblResponse.Text = "Failed Insert, please check your input &nbsp;&nbsp;"
        End If

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        MaintainScrollPositionOnPostBack = True
    End Sub
End Class
