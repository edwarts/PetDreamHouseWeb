Imports System.Web.UI.WebControls
Imports System.ComponentModel

Partial Class App_Controls_SimpleUpload
    Inherits System.Web.UI.UserControl

    Public Event UploadRequested(Sender As Object, Filename As String)
    Public Event DeleteRequested(Sender As Object, e As EventArgs)

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim j As String = ""
        j = "document.getElementById('" & nm.ClientID & "').value=this.value.substring(this.value.lastIndexOf('\\')+1);"
        FUP.Attributes.Add("onchange", j)

        FUP.Width = 65
        btn.Style.Add("width", "65px")
        btn.Style.Add("cursor", "pointer")
        FUP.Style.Add("cursor", "pointer")
    End Sub

    Public Property CssClass As String
        Get
            Return FUP.CssClass
        End Get
        Set(value As String)
            FUP.CssClass = value
            btn.Attributes.Add("class", value)
        End Set
    End Property

    Public Property Width As Unit
        Get
            Return FUP.Width
        End Get
        Set(value As Unit)
            FUP.Width = value
            btn.Style.Add("width", value.Value & "px")

        End Set
    End Property

    Public ReadOnly Property HasFile As Boolean
        Get
            Return FUP.HasFile
        End Get
    End Property

    Public ReadOnly Property PostedFile As HttpPostedFile
        Get
            Return FUP.PostedFile
        End Get
    End Property
    Public ReadOnly Property Filename As String
        Get
            Return FUP.FileName
        End Get
    End Property

    Sub SaveAs(Filename As String)
        FUP.SaveAs(Filename)
    End Sub

    Public Property TextboxText As String
        Get
            Return nm.Value
        End Get
        Set(value As String)
            nm.Value = value
        End Set
    End Property

End Class
