Imports Anetics.Data
Imports System.Data
Imports SharedProperties

Partial Class App_Controls_FooterBlocks
    Inherits System.Web.UI.UserControl

    Public Property BlockIDs As String

    Public Property CssClass As String

    Protected Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender
        Dim p = Split(BlockIDs, ",")

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataTable
        db.CommandText = ""

        For Each i As String In p
            If i.Trim = "" Then Continue For

            If db.CommandText <> "" Then
                db.CommandText &= "UNION ALL" & vbCrLf
            End If
            db.CommandText &= "SELECT * FROM tblFooterBlocks WHERE BlkID = " & i & vbCrLf
        Next

        If db.CommandText = "" Then Exit Sub

        Dim dt As DataTable = db.Execute



        For Each dr As DataRow In dt.Rows

            Dim a As New HyperLink
            a.NavigateUrl = CN(dr("BlkLink"), "/")

            Dim img = New Image
            img.ImageUrl = "/235x160/Data/Image/Cubes/" & CN(dr("BlkImage"))
            img.AlternateText = "Pet Dream House " & dr("BlkName")
            a.Controls.Add(img)

            pnl.Controls.Add(a)
        Next

        pnl.CssClass = CssClass

    End Sub
End Class
