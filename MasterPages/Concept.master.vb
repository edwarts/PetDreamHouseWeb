Imports SharedProperties

Partial Class Concept
    Inherits System.Web.UI.MasterPage

    Sub Page_Load(s As Object, e As EventArgs) Handles MyBase.Load

        Dim u = ThisUser

        If u Is Nothing Then
            lnkSubmit.NavigateUrl = ""
            lnkSubmit.OnClientClick = "return RequestLogonDialog();"
        End If

    End Sub

    Sub SetLink() Handles Me.Load
        Dim pth = Page.Form.Action.Split("?")(0).ToLower

        Dim rl As App_Controls_RolloverLink = Nothing

        For Each c As Control In NavControls.Controls
            Dim t = c.GetType.Name
            If Not t.Equals("app_controls_rolloverlink_ascx") Then Continue For

            Dim lnk = CType(c, App_Controls_RolloverLink).NavigateUrl
            If pth.StartsWith(lnk.ToLower) Then rl = c

        Next

        If Not rl Is Nothing Then rl.SetOn()

    End Sub

End Class

