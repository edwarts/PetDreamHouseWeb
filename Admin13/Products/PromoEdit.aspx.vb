Imports System.Data
Imports Anetics.Data
Imports SharedProperties
Imports Admin

Partial Class Admin13_Products_PromoEdit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request("id")) Then hdnPromoID.Value = Request("id")

        If Not IsPostBack And hdnPromoID.Value > 0 Then LoadDetails()

        If Not IsPostBack And hdnPromoID.Value = 0 Then
            txtStart.Text = Format(Now, "dd MMM yyyy")
            txtEnd.Text = Format(Now.AddMonths(1), "dd MMM yyyy")
        End If

    End Sub

    Sub LoadDetails()

        Dim db = New EasySql
        db.AddParameter("@ProID", hdnPromoID.Value)
        db.ReturnType = EasyDBReturnType.DataRow
        db.CommandText = "SELECT * FROM tblPromoCodes WHERE ProID = @ProID"
        Dim dr As DataRow = db.Execute

        If dr Is Nothing Then Exit Sub

        txtDescription.Text = CN(dr("ProName"))
        txtCode.Text = CN(dr("ProCode"))

        If dr("ProPercent") = 0 Then
            ddlPromoType.SelectedValue = "A"
            txtDiscount.Text = CN(dr("ProAmount"))
        Else
            ddlPromoType.SelectedValue = "P"
            txtDiscount.Text = CN(dr("ProPercent"))
        End If

        txtMinSpend.Text = FormatNumber(dr("ProMinSpend"), 2)

        txtStart.Text = Format(dr("ProStart"), "dd MMM yyyy")
        txtEnd.Text = Format(dr("ProEnd"), "dd MMM yyyy")
        ddlStatus.SelectedValue = dr("ProEnabled")


    End Sub

    Sub SavePromo() Handles btnSaveDetails.Click

        If txtDescription.Text = "" Then lblDetailsResponse.Text = "Description Missing" : Exit Sub
        If txtCode.Text = "" Then lblDetailsResponse.Text = "Code Missing" : Exit Sub
        If Not IsNumeric(txtDiscount.Text) Then lblDetailsResponse.Text = "Discount Invalid" : Exit Sub
        If Not IsNumeric(txtMinSpend.Text) Then lblDetailsResponse.Text = "Min Spend Invalid" : Exit Sub
        If Not IsDate(txtStart.Text) Then lblDetailsResponse.Text = "Invalid Start Date" : Exit Sub
        If Not IsDate(txtEnd.Text) Then lblDetailsResponse.Text = "Invalid End Date" : Exit Sub

        Dim db = New EasySql

        db.AddParameter("@ProEnabled", ddlStatus.SelectedValue)
        db.AddParameter("@ProName", txtDescription.Text)
        db.AddParameter("@ProCode", txtCode.Text)

        If ddlPromoType.SelectedValue = "P" Then
            db.AddParameter("@ProPercent", txtDiscount.Text)
            db.AddParameter("@ProAmount", 0)
        Else
            db.AddParameter("@ProPercent", 0)
            db.AddParameter("@ProAmount", txtDiscount.Text)
        End If

        db.AddParameter("@ProMinSpend", txtMinSpend.Text)

        db.AddParameter("@ProStart", txtStart.Text & " 00:00")
        db.AddParameter("@ProEnd", txtEnd.Text & " 23:59")

        Dim i = 0

        If hdnPromoID.Value = 0 Then
            db.ReturnType = EasyDBReturnType.Scope_Identity
            db.CommandText = db.InsertString("tblPromoCodes")
            i = db.Execute
            If i > 0 Then hdnPromoID.Value = i
        Else
            db.AddParameter("@ProID", hdnPromoID.Value)
            db.ReturnType = EasyDBReturnType.Rows_Affected
            db.CommandText = db.UpdateString("tblPromoCodes", "ProID = @ProID", "@ProID")
            i = db.Execute
        End If

        If i > 0 Then
            lblDetailsResponse.Text = "Details Saved "
        Else
            lblDetailsResponse.Text = "Failed to Save Details"
        End If

        If db.ErrorString <> "" Then lblDetailsResponse.Text = db.ErrorString
    End Sub
End Class
