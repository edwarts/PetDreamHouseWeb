Imports SharedProperties
Imports System.Data
Imports Anetics.Data
Imports Admin

Partial Class Admin13_Settings_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadSettings()
    End Sub

    Sub LoadSettings()

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataTable
        Dim dt As DataTable = db.Select("tblSetting")

        tbl.Rows.Clear()
        AddHeader()
        For Each dr As DataRow In dt.Select("", "SetDisplayName ASC")

            AddRow(dr)

        Next
    End Sub

    Sub AddHeader()
        Dim tr As New TableRow

        Dim th = New TableHeaderCell
        th.Text = "Name"
        th.Width = 200
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Text = "Value"
        tr.Cells.Add(th)

        tbl.Rows.Add(tr)
    End Sub

    Sub AddRow(dr As DataRow)
        Dim tr As New TableRow

        Dim th = New TableCell
        th.Text = CN(dr("SetDisplayName"), CN(dr("SetName")))
        tr.Cells.Add(th)

        th = New TableCell
        Dim tb = New TextBox
        tb.Width = 400
        tb.ID = "txtSet_" & dr("SetID")
        tb.Text = CN(dr("SetValue"))
        th.Controls.Add(tb)

        Dim btn = New Button
        btn.ID = "btnSet_" & dr("SetID")
        btn.Text = "Update"
        AddHandler btn.Click, AddressOf UpdateSetting
        th.Controls.Add(btn)

        Dim lbl = New Label
        lbl.ID = "lblSet_" & dr("SetID")
        lbl.Text = ""
        lbl.Font.Bold = True

        th.Controls.Add(lbl)

        tr.Cells.Add(th)

        tbl.Rows.Add(tr)
    End Sub

    Sub UpdateSetting(s As Object, e As EventArgs)
        Dim id As Integer = CType(s, Button).ID.Split("_")(1)

        Dim val As TextBox = tbl.FindControl("txtSet_" & id)

        Dim db = New EasySql
        db.AddParameter("@SetID", id)
        db.AddParameter("@SetValue", val.Text)

        db.Update("tblSetting", "SetID = @SetID", "@SetID")

        Dim lbl As Label = tbl.FindControl("lblSet_" & id)
        If db.ErrorString = "" Then
            lbl.Text = "OK"
            lbl.ForeColor = Drawing.Color.Green
        Else
            lbl.Text = "Error"
            lbl.ForeColor = Drawing.Color.Red
        End If
    End Sub
End Class
