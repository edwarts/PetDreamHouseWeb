Imports SharedProperties
Imports System.Data
Imports Anetics.Data
Imports Admin

Partial Class Admin13_Settings_Users
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadUsers()
    End Sub

    Sub LoadUsers()

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataTable
        Dim dt As DataTable = db.Select("tblUser")

        tbl.Rows.Clear()
        AddHeader()
        For Each dr As DataRow In dt.Select("", ddlSortField.SelectedValue & " " & ddlSortDir.SelectedValue)

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
        th.Text = "Email Address"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Text = "Created"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Text = ""
        tr.Cells.Add(th)

        tbl.Rows.Add(tr)
    End Sub

    Sub AddRow(dr As DataRow)
        Dim tr As New TableRow

        Dim th = New TableCell
        th.Text = CN(dr("UsrName"))
        tr.Cells.Add(th)

        th = New TableCell
        th.Text = CN(dr("UsrEmailAddress"))
        tr.Cells.Add(th)

        th = New TableCell
        th.Text = Format(dr("UsrCreated"), "ddd, dd MMM yyyy HH:mm")
        tr.Cells.Add(th)

        th = New TableCell
        Dim lnk = New HyperLink
        lnk.NavigateUrl = "/Admin13/Settings/Users/Edit/" & dr("UsrID")
        lnk.ImageUrl = "/App/Images/Icon/edit-icon.png"
        th.Controls.Add(lnk)

        Dim ib = New ImageButton
        ib.ID = "Del_" & dr("UsrID")
        ib.OnClientClick = "return confirm('Really delete this user?');"
        ib.ImageUrl = "/App/Images/Icon/delete-icon.png"
        AddHandler ib.Click, AddressOf DeleteUser
        th.Controls.Add(ib)

        tr.Cells.Add(th)

        tbl.Rows.Add(tr)
    End Sub

    Sub DeleteUser(s As Object, e As EventArgs)
        Dim id As Integer = CType(s, ImageButton).ID.Split("_")(1)

        Dim val As TextBox = tbl.FindControl("txtSet_" & id)

        Dim db = New EasySql
        db.AddParameter("@UsrID", id)

        db.Delete("tblUser")

        LoadUsers()
    End Sub

End Class
