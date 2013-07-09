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
        Dim dt As DataTable = db.Select("tblAdminUsers")

        tbl.Rows.Clear()
        AddHeader()
        For Each dr As DataRow In dt.Select("", "AdmName ASC")

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
        th.Text = "Last Login"
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Text = ""
        tr.Cells.Add(th)

        tbl.Rows.Add(tr)
    End Sub

    Sub AddRow(dr As DataRow)
        Dim tr As New TableRow

        Dim th = New TableCell
        th.Text = CN(dr("AdmName"))
        tr.Cells.Add(th)

        th = New TableCell
        th.Text = CN(dr("AdmEmail"))
        tr.Cells.Add(th)

        th = New TableCell
        If IsDate(dr("AdmLastLogin")) Then
            th.Text = Format(dr("AdmLastLogin"), "ddd, dd MMM yyyy HH:mm")
        Else
            th.Text = "Never"
        End If
        tr.Cells.Add(th)

        th = New TableCell
        Dim lnk = New HyperLink
        lnk.NavigateUrl = "/Admin13/Settings/Admins/Edit/" & dr("AdmID")
        lnk.ImageUrl = "/App/Images/Icon/edit-icon.png"
        th.Controls.Add(lnk)

        If dr("AdmProtected") = 0 Then
            Dim ib = New ImageButton
            ib.ID = "Del_" & dr("AdmID")
            ib.OnClientClick = "return confirm('Really delete this admin?');"
            ib.ImageUrl = "/App/Images/Icon/delete-icon.png"
            AddHandler ib.Click, AddressOf DeleteAdmin
            th.Controls.Add(ib)
        End If
        tr.Cells.Add(th)

        tbl.Rows.Add(tr)
    End Sub

    Sub DeleteAdmin(s As Object, e As EventArgs)
        Dim id As Integer = CType(s, ImageButton).ID.Split("_")(1)

        Dim val As TextBox = tbl.FindControl("txtSet_" & id)

        Dim db = New EasySql
        db.AddParameter("@AdmID", id)

        db.Delete("tblAdminUsera")

        LoadUsers()
    End Sub

End Class
