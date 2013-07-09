Imports Anetics.Data
Imports System.Data
Imports SharedProperties

Partial Class Controls_LoginRegister
    Inherits System.Web.UI.UserControl

    Public Event StatusChanged()

    Dim cid As Integer = 0
    Dim Usr As DataRow
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        lnkPublicRegister.NavigateUrl = "/Register?ReturnUrl=" & HttpUtility.UrlEncode(Page.Form.Action)

        If txtPLEmail.Text <> "" And txtPLPassword.Text <> "" Then
            Dim i = PublicLogon(txtPLEmail.Text, txtPLPassword.Text)

            If Not i Then
                lblPLResponse.Text = "The Logon Failed! "
                txtPLPassword.Text = ""
                Show()
            Else
                txtPLEmail.Text = ""
                txtPLPassword.Text = ""
                RaiseEvent StatusChanged()
            End If
        End If

    End Sub

    Public Property TargetControl As String
        Get
            Return ModalPopupExtender1.TargetControlID
        End Get
        Set(value As String)
            ModalPopupExtender1.TargetControlID = value
        End Set
    End Property


    Public Sub Show()
        ModalPopupExtender1.Show()
    End Sub

    Public Sub Hide()
        ModalPopupExtender1.Hide()
    End Sub

End Class
