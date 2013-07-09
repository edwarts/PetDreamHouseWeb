Imports Anetics.Data
Imports System.Data
Imports SharedProperties
Imports Admin

Partial Class Admin13_Faq_Edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request("PressID")) Then hdnFaqID.Value = Request("PressID")
        lblResponse.Text = ""

        If Not IsPostBack Then txtDate.Text = Format(Now, "dd MMMM yyyy")

        If Not IsPostBack And hdnFaqID.Value > 0 Then LoadFaq()

        Page.Title = h3Title.InnerText
    End Sub

    Sub LoadFaq()
        h3Title.InnerText = "Edit Press Entry"

        Dim db = New EasySql
        db.AddParameter("@PrsID", hdnFaqID.Value)
        db.ReturnType = EasyDBReturnType.DataRow
        db.CommandText = "SELECT * FROM tblPress WHERE PrsID = @PrsID"
        Dim dr As DataRow = db.Execute

        If dr Is Nothing Then Exit Sub

        txtTitle.Text = CN(dr("PrsTitle"))
        txtDate.Text = Format(dr("PrsDate"), "dd MMMM yyyy")
        txtLink.Text = CN(dr("PrsLink"))
        txtDescription.Text = CN(dr("PrsDesc"))
    End Sub

    Sub SaveFaq() Handles btnSave.Click

        Dim db = New EasySql
        db.AddParameter("@PrsTitle", txtTitle.Text)
        db.AddParameter("@PrsDate", txtDate.Text)
        db.AddParameter("@PrsLink", txtLink.Text)
        db.AddParameter("@PrsDesc", txtDescription.Text)

        Dim i As Integer = 0

        If hdnFaqID.Value > 0 Then
            db.AddParameter("@PrsID", hdnFaqID.Value)
            db.ReturnType = EasyDBReturnType.Rows_Affected
            i = db.Update("tblPress", "PrsID = @PrsID", "@PrsID")

        Else
            db.ReturnType = EasyDBReturnType.Scope_Identity
            i = db.Insert("tblPress")
        End If

        If i > 0 Then
            lblResponse.Text = "Item Saved &nbsp;&nbsp;"
        Else
            lblResponse.Text = "Item NOT SAVED &nbsp;&nbsp;"
        End If
    End Sub
End Class
