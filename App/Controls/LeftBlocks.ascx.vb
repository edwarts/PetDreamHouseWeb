
Partial Class Controls_LeftBlocks
    Inherits System.Web.UI.UserControl

    Public Property style As String
        Get
            Return Blocks.Attributes("style")
        End Get
        Set(value As String)
            Blocks.Attributes.Add("style", value)
        End Set
    End Property
    Public Property CssClass As String
        Get
            Return Blocks.CssClass
        End Get
        Set(value As String)
            Blocks.CssClass = value
        End Set
    End Property

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim hst = SharedProperties.CurrentHost

        lnkFAQ.NavigateUrl = "http://" & hst(1) & "/faq.aspx"
        lnkVote.NavigateUrl = "http://" & hst(1) & "/concept"
    End Sub
End Class
