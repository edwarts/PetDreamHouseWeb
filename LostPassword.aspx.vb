Imports Anetics.Data
Imports System.Data
Imports SharedProperties
Imports Anetics.Crypto.CryptoService

Partial Class LostPassword
    Inherits System.Web.UI.Page
    Dim ret As String = "/"
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblLoginResponse.Text = ""

        If Request.QueryString("havekey") = "true" Then
            SetKeyPanel(True)
        End If
        If Request.QueryString("key") <> "" Then txtKey.Text = Request.QueryString("key").Trim

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As System.EventArgs) Handles btnLogin.Click

        Dim u = PublicUserFindByEmail(txtLoginEmail.Text)

        If u Is Nothing Then
            lblLoginResponse.Text = "Email Address not Registered! "

            SetKeyPanel(False)
        Else

            Dim k As String = GenerateResetKey(8)
            Dim db = New EasySQL(Constring)
            db.AddParameter("@UsrID", u("UsrID"))
            db.AddParameter("@UsrPassResetKey", k)
            db.Update("tblUser", "UsrID = @UsrID", "@UsrID")
            u("UsrPassResetKey") = k
            u.AcceptChanges()
            If db.ErrorString = "" Then


                Dim ed = New EmailDispatcher
                Dim txt As String = ed.FillTemplate("LostPassword.html", u)

                Dim ob = ed.SendEmail(u("UsrName"), u("UsrEmailAddress"), "Password Reset Key", txt)

            End If

            txtEmail.Text = txtLoginEmail.Text
            txtNewPassword.Text = ""
            txtKey.Text = ""

            lblLoginResponse.Text = ""
            SetKeyPanel(True)
        End If

    End Sub

    Sub SetKeyPanel(s As Boolean)
        tr1.Visible = s
        tr2.Visible = s
        tr3.Visible = s
        tr4.Visible = s
        tr5.Visible = s

    End Sub


    Sub ResetNow() Handles btnReset.Click

        Dim db = New EasySQL(Constring)
        db.ReturnType = EasyDBReturnType.Rows_Affected
        db.AddParameter("@NewPassword", HashString(txtNewPassword.Text))
        db.AddParameter("@UsrEmailAddress", txtEmail.Text)
        db.AddParameter("@UsrPassResetKey", txtKey.Text.Trim)
        db.AddParameter("@UsrSession", ThisSession)
        db.CommandText = "UPDATE tblUser SET UsrPassword = @NewPassword,UsrPassResetKey = null WHERE UsrEmailAddress = @UsrEmailAddress AND UsrPassResetKey = @UsrPassResetKey AND UsrPassResetKey is not null"

        db.ThowErrors = True
        Dim i = db.Execute

        If i < 1 Then
            lblPasswordSetResponse.Text = "Sorry we couldnt update your password, please check and re-enter your key"
        Else
            lblPasswordSetResponse.Text = "Thank you, your password was reset, you may now login."
        End If



    End Sub

End Class
