Imports SharedProperties
Imports Admin

Partial Class MasterPages_Admin
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        If Request.QueryString("originalUrl") <> "" Then
            form1.Action = Request.QueryString("originalUrl")
        Else
            form1.Action = Request.Url.PathAndQuery
        End If

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim u = ThisAdmin
        If u Is Nothing Then
            Response.Redirect("/Admin13/Logon.aspx?ReturnURL=" & HttpUtility.UrlEncode(form1.Action))
        End If

        SetLink()

    End Sub

    Sub SetLink()

        Dim A As HyperLink = lnkHome
        Dim pth As String = Request.Url.LocalPath.ToLower

        For Each c As Control In MainNav.Controls
            If c.GetType.Equals(A.GetType) Then
                If pth.StartsWith(CType(c, HyperLink).NavigateUrl.ToLower) Then A = c

            End If
        Next

        A.CssClass = "On"
    End Sub
End Class

