Imports Anetics.Data
Imports System.Data
Imports SharedProperties
Imports Admin

Partial Class Admin13_Default
    Inherits System.Web.UI.Page
    Dim tr As TableRow
    Dim th As TableHeaderCell
    Dim tc As TableCell

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        LoadProducts()
    End Sub

    Sub LoadProducts()

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataTable
        db.CommandText = "SELECT * " & vbCrLf
        db.CommandText &= "FROM tblCool ORDER BY CooName ASC"

        Dim dt As DataTable = db.Execute
        tbl.Rows.Clear()
        AddConceptListHeader()

        For Each dr As DataRow In dt.Rows
            AddConceptListRow(dr)
        Next

    End Sub

    Sub AddConceptListHeader()
        tr = New TableRow

        th = New TableHeaderCell
        th.Text = "Name"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Width = 200
        th.Text = "Submitted By"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Width = 80
        th.Text = "Visibility"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Width = 80
        th.Text = "Est Price"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Text = ""
        tr.Cells.Add(th)

        tbl.Rows.Add(tr)
    End Sub

    Sub AddConceptListRow(dr As DataRow)
        tr = New TableRow

        tc = New TableCell
        tc.Text = CN(dr("CooName"))
        tr.Cells.Add(tc)

        tc = New TableCell
        Dim lnk As New HyperLink
        lnk.NavigateUrl = "mailto:" & dr("CooSubmitterEmail")
        lnk.Text = dr("CooSubmitterName")
        lnk.ForeColor = Drawing.Color.Black
        tc.Controls.Add(lnk)
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.Text = "Visible"
        If dr("CooVisible") = 0 Then tc.Text = "Hidden"
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.Text = "£" & dr("CooEstPrice")
        tr.Cells.Add(tc)

        tc = New TableCell

        Dim hl = New HyperLink
        hl.NavigateUrl = "/Admin13/Cool/Edit?CoolID=" & dr("CooID")
        hl.ImageUrl = "/App/Images/Icon/edit-icon.png"
        tc.Controls.Add(hl)

        hl = New HyperLink
        hl.NavigateUrl = "/Admin13/Cool/Edit?CoolID=" & dr("CooID") & "&tab=2"
        hl.ImageUrl = "/App/Images/Icon/pictures-icon.png"
        tc.Controls.Add(hl)

        Dim ib = New ImageButton
        ib.ID = "btnDelete_" & dr("CooID")
        ib.ImageUrl = "/App/Images/Icon/delete-icon.png"
        ib.OnClientClick = "return confirm('Really delete this item?');"
        AddHandler ib.Click, AddressOf DeleteConcept

        tc.Controls.Add(ib)

        tr.Cells.Add(tc)
        tbl.Rows.Add(tr)

    End Sub

    Sub DeleteConcept(s As Object, e As EventArgs)
        Dim id As Integer = CType(s, ImageButton).ID.Split("_")(1)

        Dim db = New EasySql
        db.AddParameter("@CooID", id)
        db.CommandText = "DELETE FROM tblCool WHERE CooID = @CooID;"
        db.Execute()

        LoadProducts()
    End Sub
End Class
