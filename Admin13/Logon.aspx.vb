Imports Admin

Partial Class Admin13_Logon
    Inherits System.Web.UI.Page
    Dim ret As String = "/Admin13"
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("end") <> "" Then
                MyCookie("AdminSession") = ""
            End If
        End If

        If Request.QueryString("ReturnURL") <> "" Then
            ret = HttpUtility.UrlDecode(Request.QueryString("ReturnURL"))
        End If
        If txtUsername.Text <> "" And txtPassword.Text <> "" Then DoLogon()
    End Sub

    Sub DoLogon()
        Dim i = AdminLogon(txtUsername.Text, txtPassword.Text)
        If i Then
            Response.Redirect(ret)
        Else
            lblResponse.Text = "Invalid Username/Password &nbsp;&nbsp;"
        End If
    End Sub
End Class
