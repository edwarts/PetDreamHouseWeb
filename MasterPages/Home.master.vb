
Partial Class Home
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim hst = SharedProperties.CurrentHost

        lnkStore.NavigateUrl = "http://" & hst(1) & "/Products"
    End Sub
End Class

