Imports Anetics.Data
Imports System.Data
Imports SharedProperties
Imports Admin

Partial Class Admin13_Faq_Edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request("FaqID")) Then hdnFaqID.Value = Request("FaqID")
        lblResponse.Text = ""

        If Not IsPostBack And hdnFaqID.Value > 0 Then LoadFaq()

        Page.Title = h3Title.InnerText
    End Sub

    Sub LoadFaq()
        h3Title.InnerText = "Edit Frequently Asked Question"

        Dim db = New EasySql
        db.AddParameter("@FaqID", hdnFaqID.Value)
        db.ReturnType = EasyDBReturnType.DataRow
        db.CommandText = "SELECT * FROM tblFaq WHERE FaqID = @FaqID"
        Dim dr As DataRow = db.Execute

        If dr Is Nothing Then Exit Sub

        txtQuestion.Text = CN(dr("FaqQuestion"))
        txtAnswer.Text = CN(dr("FaqAnswer"))

    End Sub

    Sub SaveFaq() Handles btnSave.Click

        Dim db = New EasySql
        db.AddParameter("@FaqCategory", ddlCategory.SelectedValue)
        db.AddParameter("@FaqQuestion", txtQuestion.Text)
        db.AddParameter("@FaqAnswer", txtAnswer.Text)

        Dim i As Integer = 0

        If hdnFaqID.Value > 0 Then
            db.AddParameter("@FaqID", hdnFaqID.Value)
            db.ReturnType = EasyDBReturnType.Rows_Affected
            i = db.Update("tblFaq", "FaqID = @FaqID", "@FaqID")

        Else
            db.ReturnType = EasyDBReturnType.Scope_Identity
            i = db.Insert("tblFaq")
        End If

        If i > 0 Then
            lblResponse.Text = "Item Saved &nbsp;&nbsp;"
        Else
            lblResponse.Text = "Item NOT SAVED &nbsp;&nbsp;"
        End If
    End Sub
End Class
