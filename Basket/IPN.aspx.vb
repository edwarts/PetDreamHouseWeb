Imports Anetics.Web
Imports Anetics.Data
Imports SharedProperties
Imports System.Data

Partial Class Basket_IPN
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim r = New EasyIPN(Request)

        Dim db = New EasySql(Constring)
        db.ReturnType = EasyDBReturnType.Scope_Identity
        db.AddParameter("@IpnSession", r.custom)
        db.AddParameter("@IpnDate", Now)
        db.CommandText = db.InsertString("tblIPN", True) & vbCrLf
        Dim i = db.Execute

        For Each s As String In r.Properties.AllKeys
            db = New EasySql(Constring)
            db.AddParameter("@IpvIpnID", i)
            db.AddParameter("@IpvName", s)
            db.AddParameter("@IpvValue", r.Properties(s))
            db.Insert("tblIpnParameter", True)
        Next

        For Each c As CartItem In r.Items
            Dim BasID As Integer = c.Number.Split("-")(1)
            db = New EasySql(Constring)
            db.ReturnType = EasyDBReturnType.Rows_Affected
            db.AddParameter("@BasID", BasID)
            db.AddParameter("@BasComplete", 1)
            db.AddParameter("@BasSession", r.custom)
            db.AddParameter("@BasPrice", c.Amount)
            db.CommandText = "UPDATE tblBasket SET BasComplete = @BasComplete WHERE BasID = @BasID AND BasPrice = @BasPrice AND BasSession = @BasSession"
            Dim ii = db.Execute
        Next


        'TODO: Send Email

    End Sub
End Class
