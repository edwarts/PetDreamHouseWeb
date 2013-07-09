Imports SharedProperties

Partial Class Controls_RightContact
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

    End Sub


    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
        lblResponse.Text = ""

        SetField(txtComments, txtComments.Text <> "", "Message Invalid", lblResponse)
        SetField(txtEmail, IsEmail(txtEmail.Text), "Email Invalid", lblResponse)
        SetField(txtName, txtName.Text <> "", "Name Invalid", lblResponse)

        If lblResponse.Text <> "" Then Exit Sub

        'TODO: Do Something Here

        Dim ed = New EmailDispatcher
        Dim txt = ed.FillTemplate("Contact.html", Nothing)
        txt = Replace(txt, "[name]", txtName.Text)
        txt = Replace(txt, "[email]", txtEmail.Text)
		txt = Replace(txt, "[comments]", txtComments.Text)
        txt = Replace(txt, "[telephone]", txtTelephone.Text)
		txt = Replace(txt, "[type]", ddlType.Text)

        ed.SendEmail("Website Comment", "support@petdreamhouse.com", "Contact Form from Pet Dream House Website", txt)

        lblResponse.Text = "Thank You, the form has been received &nbsp;&nbsp;"

    End Sub

End Class
