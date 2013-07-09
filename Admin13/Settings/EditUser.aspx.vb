Imports SharedProperties
Imports System.Data
Imports Anetics.Data
Imports Admin
Imports Anetics.Crypto.CryptoService

Partial Class Admin13_Settings_EditUser
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request("UsrID")) Then hdnUserID.Value = Request("UsrID")

        If Not IsPostBack And hdnUserID.Value > 0 Then LoadUser()

    End Sub

    Sub LoadUser()
        h3Title.InnerText = "Edit User"

        Dim db = New EasySql
        db.AddParameter("@UsrID", hdnUserID.Value)
        db.ReturnType = EasyDBReturnType.DataRow
        Dim dr As DataRow = db.Select("tblUser")

        If dr Is Nothing Then Exit Sub

        txtName.Text = CN(dr("UsrName"))
        txtEmail.Text = CN(dr("UsrEmailAddress"))

    End Sub

    Sub SaveUser() Handles btnSave.Click

        Dim db = New EasySql
        db.AddParameter("@UsrName", txtName.Text)
        db.AddParameter("@UsrEmailAddress", txtEmail.Text)
        If txtPassword.Text <> "" Then
            db.AddParameter("@UsrPassword", HashString(txtPassword.Text))
        End If

        Dim i As Integer = 0

        If hdnUserID.Value = 0 Then
            db.ReturnType = EasyDBReturnType.Scope_Identity
            If txtPassword.Text = "" Then
                lblResponse.Text = "Password Missing!"
                Exit Sub
            End If

            i = db.Insert("tblUser", True, "UsrEmailAddress")
            If i > 0 Then
                hdnUserID.Value = i
                lblResponse.Text = "User Created"
            Else
                If db.ErrorString = "" Then
                    lblResponse.Text = "User Exists"
                Else
                    lblResponse.Text = db.ErrorString
                End If
            End If
        Else
            db.ReturnType = EasyDBReturnType.Rows_Affected
            db.AddParameter("@UsrID", hdnUserID.Value)
            i = db.Update("tblUser", "UsrID = @UsrID", "@UsrID")
            If i > 0 Then
                lblResponse.Text = "User Updated"
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
