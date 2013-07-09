
Partial Class Admin13_Session
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If IsDate(Session("Test")) Then
            lbl.Text = Session("Test")
        Else
            Session("Test") = Now
        End If
    End Sub
End Class
