Imports Anetics.Data
Imports System.Data
Imports SharedProperties

Partial Class Store_Product
    Inherits System.Web.UI.Page
    Dim ProductID As Integer = 0

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request.QueryString("ProductID")) Then ProductID = Request.QueryString("ProductID")


        If ProductID > 0 Then LoadProductDetail()

        LoadOtherProducts()
    End Sub

    Sub LoadProductDetail()
        Dim db = New EasySQL(Constring)
        db.ReturnType = EasyDBReturnType.DataSet
        db.AddParameter("@PrdID", ProductID)
        db.CommandText = "SELECT * FROM tblProduct WHERE PrdID = @PrdID;"
        db.CommandText &= "SELECT * FROM tblProductOption WHERE OptProductID = @PrdID ORDER BY OptPriority ASC,OptID ASC;"
        db.CommandText &= "SELECT * FROM tblProductImage WHERE PimProductID = @PrdID ORDER BY PimDefault DESC, PimPriority ASC,PimID ASC"
        Dim ds As DataSet = db.Execute
        If ds Is Nothing Then Exit Sub

        If ds.Tables(0).Rows.Count <> 1 Then Exit Sub
        Dim dr As DataRow = ds.Tables(0).Rows(0)


        Page.Title = "Pet Dream House - " & CN(dr("PrdFullName"))

        hTitle.InnerText = CN(dr("PrdFullName"))
        hTag.InnerText = CN(dr("PrdTagLine"))

        hDesigner.InnerHtml = "By " & CN(dr("PrdDesignerName"))

        hPrice.InnerText = "£" & CN(dr("PrdPrice"), "TBA")

        pSummary.InnerHtml = CN(dr("PrdSummary")).ToString.Replace(vbCrLf, "<br />")

        Dim ul = New HtmlGenericControl("ul")

        For Each i As String In Split(CN(dr("PrdFeature")), vbCrLf)
            Dim li As New HtmlGenericControl("li")
            li.InnerText = i
            ul.Controls.Add(li)
        Next

        divFeatures.Controls.Add(ul)

        pDimensions.InnerHtml = CN(dr("PrdDimensions")).ToString.Replace(vbCrLf, "<br />")

        If Not IsPostBack Then
            Dim li As New ListItem
            li.Text = "Select your colour then add to basket"
            li.Value = 0
            ddlOption.Items.Add(li)
        End If

        For Each pr As DataRow In ds.Tables(1).Rows

            Dim dv = New Panel
            dv.CssClass = "Swatch"

            Dim img = New Image
            img.CssClass = "SwatchImage"
            img.ImageUrl = "/40x20/Data/Image/Swatch/" & pr("OptSwatch")
            img.AlternateText = "Pet Dream House " & pr("OptName")
            dv.Controls.Add(img)

            Dim lbl = New Label
            lbl.CssClass = "SwatchText"
            lbl.Text = pr("OptName")
            dv.Controls.Add(lbl)

            plcOptions.Controls.Add(dv)

            If Not IsPostBack Then
                Dim li = New ListItem
                li.Text = pr("OptName")
                li.Value = pr("OptID")
                ddlOption.Items.Add(li)
            End If

        Next

        Dim LW As Integer = imgMain.Width.Value
        Dim LH As Integer = imgMain.Height.Value

        For Each ir As DataRow In ds.Tables(2).Rows
            If imgMain.ImageUrl = "" Then
                imgMain.ImageUrl = "/" & LW & "x" & LH & "/data/image/product/" & ir("PimImage")
                imgMain.AlternateText = "Pet Dream House " & dr("PrdFullName")

            End If

            Dim url = "/" & imgThumbSample.Width.Value & "x" & imgThumbSample.Height.Value & "/data/image/product/" & ir("PimImage")

            Dim img = New Image
            img.ToolTip = "Click to view"
            img.Attributes.Add("onclick", "ChangeProductImage('/" & LW & "x" & LH & "/data/image/product/" & ir("PimImage") & "','" & imgMain.ClientID & "');")
            img.ImageUrl = url

            pnlOtherImages.Controls.Add(img)
        Next

        Dim ct As String = CN(dr("PrdTypeFlags"))
        divFor.Controls.Clear()
        For Each i As Char In ct
            Dim img = New HtmlImage
            img.Src = "/App/Images/Types/" & i & ".png"
            divFor.Controls.Add(img)
        Next


        AddMeta(CN(dr("PrdMetaTitle")), CN(dr("PrdMetaDesc")), CN(dr("PrdMetaKeywords")))

    End Sub

    Sub AddMeta(pTitle As String, Desc As String, Keywords As String)

        If Desc <> "" Then
            Dim m = New HtmlMeta
            m.Name = "Description"
            m.Content = Desc
            Header.Controls.Add(m)
        End If

        If Keywords <> "" Then
            Dim m = New HtmlMeta
            m.Name = "Keywords"
            m.Content = Keywords
            Header.Controls.Add(m)
        End If

        If pTitle <> "" Then
            Title = pTitle
        End If

    End Sub

    Sub LoadOtherProducts()
        Dim db = New EasySQL(Constring)
        db.ReturnType = EasyDBReturnType.DataSet
        db.CommandText = "SELECT *," & vbCrLf
        db.CommandText &= "(SELECT top(1)PimImage FROM tblProductImage WHERE PimProductID = PrdID ORDER BY PimPriority ASC,PimID ASC) as PrdImage" & vbCrLf
        db.CommandText &= " FROM tblProduct;"
        db.CommandText &= "SELECT * FROM tblProductBinding,tblCategory WHERE PrbCategoryID = CatID;"
        Dim ds As DataSet = db.Execute

        If db.ErrorString <> "" Then Throw New Exception(db.ErrorString)

        For Each dr As DataRow In ds.Tables(0).Rows



            Dim div = New Panel
            div.Attributes.Add("onclick", "location.href='/Products/" & dr("PrdID") & "/" & dr("PrdFullName").ToString.Replace(" ", "_").Replace("'", "") & "';")
            div.CssClass = "OtherProduct"

            If plcOtherProducts.Controls.Count = 0 Then
                div.Style.Add("margin-left", "0px")
            Else
                div.Style.Add("margin-left", "84px")
            End If

            Dim img = New Image
            img.CssClass = "OtherProductImage"
            img.ImageUrl = "/data/image/product/" & dr("PrdImage")

            div.Controls.Add(img)

            Dim lbl = New Label
            lbl.CssClass = "OtherProductName"
            lbl.Text = dr("PrdFullName")
            div.Controls.Add(lbl)

            lbl = New Label
            lbl.CssClass = "OtherProductPrice"
            lbl.Text = "£" & dr("PrdPrice")
            div.Controls.Add(lbl)

            Dim a = New HyperLink
            a.CssClass = "OtherProductDesigner"
            a.Text = "By " & dr("PrdDesignerName")
            a.NavigateUrl = "/Products/" & dr("PrdID") & "/" & dr("PrdFullName").ToString.Replace(" ", "_").Replace("'", "")
            div.Controls.Add(a)

            For Each cr As DataRow In ds.Tables(1).Select("PrbProductID = '" & dr("PrdID") & "'")

                Dim ci = New Image
                ci.CssClass = "OtherProductCategoryImage"
                ci.ImageUrl = "/Data/Image/Icon/" & cr("CatIcon")
                div.Controls.Add(ci)

            Next


            plcOtherProducts.Controls.Add(div)
        Next

        If plcOtherProducts.Controls.Count < 4 Then LoadOtherProducts()
    End Sub

    Protected Sub imgAddToBasket_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgAddToBasket.Click

        If ddlOption.SelectedValue = 0 Then
            AjaxControlToolkit.ToolkitScriptManager.RegisterStartupScript(Me, Me.GetType, "SelOpt", "alert('You need to choose a colour');", True)
            Exit Sub
        End If

        If BasketManager.AddProduct(ProductID, ddlOption.SelectedValue) Then
            AjaxControlToolkit.ToolkitScriptManager.RegisterStartupScript(Me, Me.GetType, "Added", "alert('Product added to basket');", True)
        Else
            AjaxControlToolkit.ToolkitScriptManager.RegisterStartupScript(Me, Me.GetType, "NotAdded", "alert('ERROR The product could not be added to your basket!');", True)
        End If
    End Sub
End Class
