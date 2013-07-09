Imports Anetics.Data
Imports System.Data
Imports SharedProperties
Imports Admin

Partial Class Admin13_Products_PromoList
    Inherits System.Web.UI.Page
    Dim tr As TableRow
    Dim th As TableHeaderCell
    Dim tc As TableCell

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        LoadPromos()
    End Sub

    Sub LoadPromos()

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataTable
        db.CommandText = "SELECT * FROM tblPromoCodes ORDER BY ProStart ASC"

        Dim dt As DataTable = db.Execute()
        tbl.Rows.Clear()
        AddPromoListHeader()

        For Each dr As DataRow In dt.Rows
            AddPromoListRow(dr)
        Next

    End Sub

    Sub AddPromoListHeader()
        tr = New TableRow

        th = New TableHeaderCell
        th.Text = "Description"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Width = 150
        th.Text = "Code"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.HorizontalAlign = HorizontalAlign.Center
        th.Width = 100
        th.Text = "Discount"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Width = 100
        th.Text = "Start"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Width = 100
        th.Text = "End"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Text = ""
        tr.Cells.Add(th)

        tbl.Rows.Add(tr)
    End Sub

    Sub AddPromoListRow(dr As DataRow)
        tr = New TableRow

        tc = New TableCell
        Dim img = "ok-icon.png"
        If dr("ProEnabled") = 0 Then img = "stop-icon.png"
        tc.Text = "<img src=""/App/Images/Icon/" & img & """ align=""middle"" /> "
        tc.Text &= CN(dr("ProName"))
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.Text = dr("ProCode")
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.HorizontalAlign = HorizontalAlign.Center

        If dr("ProPercent") = 0 Then
            tc.Text = "£" & dr("ProAmount")
        Else
            tc.Text = dr("ProPercent") & "%"
        End If

        If dr("ProMinSpend") > 0 Then
            tc.Text &= " if > £" & dr("ProMinSpend")
        End If

        tr.Cells.Add(tc)

        tc = New TableCell
        tc.Text = Format(dr("ProStart"), "dd MMM yyyy")
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.Text = Format(dr("ProEnd"), "dd MMM yyyy")
        tr.Cells.Add(tc)

        tc = New TableCell

        Dim hl = New HyperLink
        hl.NavigateUrl = "/Admin13/Products/Promo/" & dr("ProID") & "/Edit"
        hl.ImageUrl = "/App/Images/Icon/edit-icon.png"
        tc.Controls.Add(hl)

        Dim ib = New ImageButton
        ib.ID = "btnDelete_" & dr("ProID")
        ib.ImageUrl = "/App/Images/Icon/delete-icon.png"
        ib.OnClientClick = "return confirm('Really delete this Promotion?');"
        AddHandler ib.Click, AddressOf DeletePromo

        tc.Controls.Add(ib)

        tr.Cells.Add(tc)
        tbl.Rows.Add(tr)

    End Sub

    Sub DeletePromo(s As Object, e As EventArgs)
        Dim id As Integer = CType(s, ImageButton).ID.Split("_")(1)

        Dim db = New EasySql
        db.AddParameter("@ProID", id)
        db.CommandText = "DELETE FROM tblPromoCodes WHERE ProID = @ProID;"
        db.Execute()

        LoadPromos()
    End Sub

End Class
