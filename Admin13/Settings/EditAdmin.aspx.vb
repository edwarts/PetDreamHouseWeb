Imports SharedProperties
Imports System.Data
Imports Anetics.Data
Imports Admin
Imports Anetics.Crypto.CryptoService

Partial Class Admin13_Settings_EditUser
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request("AdmID")) Then hdnUserID.Value = Request("AdmID")

        If Not IsPostBack And hdnUserID.Value > 0 Then LoadUser()

    End Sub

    Sub LoadUser()
        h3Title.InnerText = "Edit Administrator"

        Dim db = New EasySql
        db.AddParameter("@AdmID", hdnUserID.Value)
        db.ReturnType = EasyDBReturnType.DataRow
        Dim dr As DataRow = db.Select("tblAdminUsers")

        If dr Is Nothing Then Exit Sub

        txtName.Text = CN(dr("AdmName"))
        txtEmail.Text = CN(dr("AdmEmail"))

    End Sub

    Sub SaveUser() Handles btnSave.Click

        Dim db = New EasySql
        db.AddParameter("@AdmName", txtName.Text)
        db.AddParameter("@AdmEmail", txtEmail.Text)
        If txtPassword.Text <> "" Then
            db.AddParameter("@AdmPassword", HashString(txtPassword.Text))
        End If

        Dim i As Integer = 0

        If hdnUserID.Value = 0 Then
            db.ReturnType = EasyDBReturnType.Scope_Identity
            If txtPassword.Text = "" Then
                lblResponse.Text = "Password Missing!"
                Exit Sub
            End If

            i = db.Insert("tblAdminUsers", True, "AdmEmail")
            If i > 0 Then
                hdnUserID.Value = i
                lblResponse.Text = "Administrator Created"
            Else
                If db.ErrorString = "" Then
                    lblResponse.Text = "Administrator Exists"
                Else
                    lblResponse.Text = db.ErrorString
                End If
            End If
        Else
            db.ReturnType = EasyDBReturnType.Rows_Affected
            db.AddParameter("@AdmID", hdnUserID.Value)
            i = db.Update("tblAdminUsers", "AdmID = @AdmID", "@AdmID")
            If i > 0 Then
                lblResponse.Text = "Administrator Updated"
            Else
                If db.ErrorString = "" Then
                    lblResponse.Text = "No Changes Made"
                Else
                    lblResponse.Text = db.ErrorString
                End If
            End If
        End If

    End Sub
End Class
