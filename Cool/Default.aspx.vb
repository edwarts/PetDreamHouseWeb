Imports Anetics.Data
Imports System.Data
Imports SharedProperties

Partial Class Cool_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadCool()
    End Sub

    Dim n As Integer = 0

    Sub LoadCool()
        Dim db = New EasySQL(Constring)
        db.ReturnType = EasyDBReturnType.DataTable
        db.CommandText = "SELECT *" & vbCrLf
        db.CommandText &= "FROM tblCool WHERE CooVisible = 1"

        Dim dt As DataTable = db.Execute

        If db.ErrorString <> "" And Request.IsLocal Then
            Throw New Exception(db.ErrorString)
        End If

        If dt Is Nothing Then Exit Sub

        For Each dr As DataRow In dt.Rows
            AddCoolItem(dr)
            n += 1
        Next


    End Sub

    Sub AddCoolItem(dr As DataRow)

        Dim ItemUrl As String = "/Cool/" & dr("CooID") & "/" & dr("CooName").ToString.Replace(" ", "_")

        Dim div = New Panel
        div.CssClass = "CoolListItem"

        Dim m = n Mod 4

        If m = 0 And n > 0 Then

            Dim d = New HtmlGenericControl("div")
            d.Style.Add("border-top", "1px dashed #9a8c83")
            d.Style.Add("padding", "10px")
            d.Style.Add("height", "1px")
            pnlProducts.Controls.Add(d)

        End If

        If m = 0 Then
            div.Style.Add("margin-left", "0px")
        Else
            div.Style.Add("margin-left", "80px")
        End If

        'div.Attributes.Add("onclick", "location.href='/cool/" & dr("CooID") & "/" & dr("CooName").ToString.Replace(" ", "_") & "';")


        Dim a = New HyperLink
        a.NavigateUrl = ItemUrl
        Dim img = New Image
        img.CssClass = "Image"
        img.ImageUrl = "/165x175/Data/Image/Cool/" & dr("CooImage1")
        a.Controls.Add(img)
        div.Controls.Add(a)

        Dim lbl = New Label
        lbl.CssClass = "Name"
        lbl.Text = dr("CooName")
        div.Controls.Add(lbl)

        Dim hl = New HyperLink
        hl.CssClass = "From"
        If dr("CooInStore") = 0 Then
            hl.Text = "From " & CN(dr("CooSiteName"))
            hl.NavigateUrl = ItemUrl
        Else
            hl.ImageUrl = "/app/images/store-graphic-oblong.png"
            hl.NavigateUrl = "/Products"
        End If

        div.Controls.Add(hl)


        pnlProducts.Controls.Add(div)
    End Sub

End Class
