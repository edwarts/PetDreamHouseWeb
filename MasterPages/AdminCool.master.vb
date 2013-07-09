
Partial Class MasterPages_AdminCool
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        SetLink()
    End Sub

    Sub SetLink()

        Dim A As HyperLink = lnkList
        Dim pth As String = Page.Form.Action.ToLower

        For Each c As Control In SubNav.Controls
            If c.GetType.Equals(A.GetType) Then
                If pth.StartsWith(CType(c, HyperLink).NavigateUrl.ToLower) Then A = c

            End If
        Next

        A.CssClass = "On"
    End Sub

End Class

