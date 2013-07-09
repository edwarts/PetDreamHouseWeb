Imports Anetics.Data
Imports System.Data
Imports SharedProperties

Partial Class login
    Inherits System.Web.UI.Page
    Dim ret As String = "/"
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim lf = Form.FindControl("Login1")
        If Not lf Is Nothing Then lf.Visible = False

        Dim lfs As ImageButton = Form.FindControl("btnLogin")
        If Not lfs Is Nothing Then
            lfs.OnClientClick = "return false;"
        End If

        lblVoterResponse.Text = ""

        If Request.QueryString("ReturnUrl") <> "" Then
            ret = HttpUtility.UrlDecode(Request.QueryString("ReturnUrl"))
            If ret.ToLower.StartsWith("/login") Then ret = "/"
            If ret.ToLower.StartsWith("/lostpassword") Then ret = "/"
        End If
    End Sub


    Protected Sub btnVoterRegister_Click(sender As Object, e As System.EventArgs) Handles btnVoterRegister.Click
		
		If txtVoterName.Text = "" Then lblVoterResponse.Text = "Name Missing! " : Exit Sub
        If Not IsEmail(txtVoterEmail.Text) Then lblVoterResponse.Text = "Email Invalid! " : Exit Sub
        If txtVoterPassword.Text = "" Then lblVoterResponse.Text = "Password Missing! " : Exit Sub

        Dim ex = PublicUserFindByEmail(txtVoterEmail.Text)
        If Not ex Is Nothing Then
            lblVoterResponse.Text = "The email address is already registered! "
            Exit Sub
        End If

        Dim i = PublicRegister(txtVoterName.Text, txtVoterEmail.Text, txtVoterPassword.Text)
        If i Then
            SendRegistrationEmail("NewUser.html")
            ret = HttpUtility.UrlDecode(ret)
            Response.Redirect(ret)
        Else
            lblVoterResponse.Text = "There was an error! "
        End If

    End Sub


    Sub SendRegistrationEmail(template As String)
        Dim u = ThisUser


        Dim ed = New EmailDispatcher

        Dim txt = ed.FillTemplate(template, u)

        Dim ob = ed.SendEmail(u("UsrName"), u("UsrEmailAddress"), "Registration Details", txt)

    End Sub
End Class
