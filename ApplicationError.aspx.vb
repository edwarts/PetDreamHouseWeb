
Partial Class ApplicationError
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim ex = GetError()

        If ex Is Nothing Then Exit Sub

        lblMessage.Text = ex.Message
        lblStack.Text = ex.StackTrace.Replace(vbCrLf, "<br />")
    End Sub

    Function GetError() As Exception
        Dim ex As Exception = Nothing
        ex = Server.GetLastError
        If ex Is Nothing Then Return Nothing

        While Not ex.InnerException Is Nothing
            ex = ex.InnerException
        End While
        Return ex
    End Function
End Class
