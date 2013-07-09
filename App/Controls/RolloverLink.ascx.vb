
Partial Class App_Controls_RolloverLink
    Inherits System.Web.UI.UserControl
    Public Property AutoActivate As Boolean
    Public Property ImageFolder As String
    Public Property OnImage As String
    Public Property OffImage As String
    Public Property NavigateUrl As String
        Get
            Return lnk.NavigateUrl
        End Get
        Set(value As String)
            lnk.NavigateUrl = value
        End Set
    End Property

    Public Property OnClientClick As String
        Get
            Return lnk.Attributes("onclick")
        End Get
        Set(value As String)
            lnk.Attributes("onclick") = value
        End Set
    End Property

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Init
        If Not ImageFolder.Trim.EndsWith("/") Then ImageFolder = ImageFolder.Trim & "/"

        img.ImageUrl = ImageFolder & OffImage
        img.Attributes.Add("onmouseover", "this.src='" & ImageFolder & OnImage & "';")
        img.Attributes.Add("onmouseout", "this.src='" & ImageFolder & OffImage & "';")

    End Sub

    Sub SetOn()
        img.ImageUrl = ImageFolder & OnImage
        img.Attributes.Add("onmouseover", "this.src='" & ImageFolder & OnImage & "';")
        img.Attributes.Add("onmouseout", "this.src='" & ImageFolder & OnImage & "';")
    End Sub

    Sub SetOff()
        img.ImageUrl = ImageFolder & OffImage
        img.Attributes.Add("onmouseover", "this.src='" & ImageFolder & OnImage & "';")
        img.Attributes.Add("onmouseout", "this.src='" & ImageFolder & OffImage & "';")

    End Sub

    Protected Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender

    End Sub
End Class

Public Enum ImageState
    [On] = 1
    [Off] = 2
End Enum