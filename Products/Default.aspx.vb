Imports Anetics.Data
Imports System.Data
Imports SharedProperties

Partial Class Store_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'LoadFirstProduct()

        LoadProducts()

    End Sub

    Sub LoadFirstProduct()
        Dim db = New EasySQL(Constring)
        db.ReturnType = EasyDBReturnType.DataRow
        db.CommandText = "SELECT top(1)* FROM tblProduct"
        Dim dr As DataRow = db.Execute

        If dr Is Nothing Then Exit Sub



        Response.Redirect("/Products/" & dr("PrdID") & "/" & dr("PrdFullName").ToString.Replace(" ", "_"))

    End Sub

    Dim n As Integer = 0

    Sub LoadProducts()
        Dim db = New EasySQL(Constring)
        db.ReturnType = EasyDBReturnType.DataSet
        db.CommandText = "SELECT *," & vbCrLf
        db.CommandText &= "(SELECT top(1)PimImage FROM tblProductImage WHERE PimProductID = PrdID ORDER BY PimDefault DESC, PimPriority ASC,PimID ASC) as PrdImage" & vbCrLf
        db.CommandText &= " FROM tblProduct WHERE PrdVisible = 1;"
        Dim ds As DataSet = db.Execute

        If db.ErrorString <> "" Then Throw New Exception(db.ErrorString)

        For Each dr As DataRow In ds.Tables(0).Rows

            If ds.Tables(0).Rows.Count = 1 Then
                Jump("/Products/" & dr("PrdID") & "/" & dr("PrdFullName").ToString.Replace(" ", "_"))
            End If

            '<div style="border-top:1px dashed #000000;padding:10px 0px;min-height:700px;">

            Dim div = New Panel
            div.Attributes.Add("onclick", "location.href='/Products/" & dr("PrdID") & "/" & dr("PrdFullName").ToString.Replace(" ", "_").Replace("'", "") & "';")
            div.CssClass = "ProductList"

            If n Mod 4 = 0 Then
                div.Style.Add("margin-left", "0px")
            Else
                div.Style.Add("margin-left", "84px")
            End If

            Dim img = New Image
            img.CssClass = "ProductImage"
            img.ImageUrl = "/165x175/data/image/product/" & dr("PrdImage")

            div.Controls.Add(img)

            Dim lbl = New Label
            lbl.CssClass = "ProductName"
            lbl.Text = dr("PrdFullName")
            div.Controls.Add(lbl)

            Dim a = New HyperLink
            a.CssClass = "ProductDesigner"
            a.Text = "By " & dr("PrdDesignerName")
            a.NavigateUrl = "/Products/" & dr("PrdID") & "/" & dr("PrdFullName").ToString.Replace(" ", "_").Replace("'", "")
            div.Controls.Add(a)

            '<!-- Begin  Display product price add by jerome -->
            Dim lblProductPrice = New Label
            lblProductPrice.CssClass = "ProductName"
            lblProductPrice.Text = "Price:£" & CN(dr("PrdPrice"), "TBA")
            div.Controls.Add(lblProductPrice)
            '<!--End Display product price add by jerome-->


            pnlProducts.Controls.Add(div)
            n += 1

            If n Mod 4 = 0 Then
                If n > 0 Then
                    Dim d = New HtmlGenericControl("div")
                    d.Style.Add("border-top", "1px dashed #9a8c83")
                    d.Style.Add("padding", "10px")
                    d.Style.Add("height", "1px")
                    pnlProducts.Controls.Add(d)
                End If
            End If
        Next

    End Sub

    Sub Jump(url As String)
        Response.Redirect(url)
    End Sub
End Class
