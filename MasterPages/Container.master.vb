Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Data

Partial Class Container
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(s As Object, e As EventArgs) Handles MyBase.Init
        If Request.QueryString("originalUrl") <> "" Then
            form1.Action = HttpUtility.UrlDecode(Request.QueryString("originalUrl"))
        Else
            form1.Action = Request.Url.PathAndQuery
        End If

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim hst = SharedProperties.CurrentHost

        lnkHome.NavigateUrl = "/"

        'Set the header Links

        'btnLogin.NavigateUrl = "/login?ReturnUrl=" & HttpUtility.UrlEncode(form1.Action)


        lnkFacebook2.NavigateUrl = lnkFacebook.HRef
        lnkTwitter2.NavigateUrl = lnkTwitter.HRef
        lnkLinkedIn2.NavigateUrl = lnkLinkedIn.HRef
        lnkGoogle2.NavigateUrl = lnkGoogle.HRef

        Dim u = SharedProperties.ThisUser
        If Not u Is Nothing Then
            btnLogin.ImageUrl = "/App/Images/Body/Header/common/logout-topbutton.jpg"
            AddHandler btnLogin.Click, AddressOf Logout
            AddHandler btnLogin2.Click, AddressOf Logout

        Else
            AddHandler btnLogin.Click, AddressOf ShowLogin
            AddHandler btnLogin2.Click, AddressOf ShowLogin

        End If

    End Sub

    Protected Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender

        Dim lp = form1.Action.ToLower

        Dim al As App_Controls_RolloverLink = lnkMainHome

        For Each c As Control In MainNav.Controls
            If Not c.GetType.Equals(lnkMainHome.GetType) Then Continue For

            Dim hl As App_Controls_RolloverLink = c
            If Not lp.StartsWith(hl.NavigateUrl.ToLower) Then Continue For

            al = hl
        Next

        Try
            al.SetOn()
        Catch ex As Exception

        End Try

        Dim dr As DataRow = BasketManager.GetSummary
        lnkBasketSummary.Style.Add("display", "inline-block")
        lnkBasketSummary.Style.Add("padding", "5px 8px")
		lnkBasketSummary.Style.Add("margin-bottom", "4px")
        lnkBasketSummary.ForeColor = Drawing.Color.White
        lnkBasketSummary.Text = dr(0) & " Items &pound;" & FormatNumber(dr(1), 2)
    	End Sub

    Sub ShowLogin(s As Object, e As EventArgs)
        Login1.Show()

    End Sub

    Sub Logout(s As Object, e As EventArgs)
        SharedProperties.LogoffCurrentUser()
        LoopBack()
    End Sub

    Sub LoopBack() Handles Login1.StatusChanged
        Response.Redirect(form1.Action)
    End Sub

End Class

