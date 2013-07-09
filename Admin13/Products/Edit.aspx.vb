Imports System.Data
Imports Anetics.Data
Imports SharedProperties
Imports Admin

Partial Class Admin13_Products_Edit
    Inherits System.Web.UI.Page
    Dim ProductID As Integer = 0

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request("ProductID")) Then hdnProductID.Value = Request("ProductID")
        If IsNumeric(Request.QueryString("tab")) And Not IsPostBack Then If Request("tab") < TabContainer1.Tabs.Count Then TabContainer1.ActiveTabIndex = Request.QueryString("tab")

        If hdnProductID.Value > 0 And Not IsPostBack Then LoadProduct()

        tabOptions.Visible = (hdnProductID.Value > 0)
        tabImages.Visible = (hdnProductID.Value > 0)
        tabNote.Visible = (hdnProductID.Value > 0)

        lblDetailsResponse.Text = ""
        lblImageResponse.Text = ""
        lblNoteResponse.Text = ""
        lblPimUploadResponse.Text = ""
        flPim.TextboxText = ""

        LoadOptions()
        LoadImages()
    End Sub

    Sub LoadProduct()
        h3Title.InnerText = "Edit Product Details"

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataRow
        db.AddParameter("@PrdID", hdnProductID.Value)

        Dim dr As DataRow = db.Select("tblProduct")

        txtFullName.Text = CN(dr("PrdFullName"))
        txtStrapLine.Text = CN(dr("PrdTagLine"))
        txtSummary.Text = CN(dr("PrdSummary"))
        txtFeatures.Text = CN(dr("PrdFeature"))
        txtDimensions.Text = CN(dr("PrdDimensions"))
        txtPrice.Text = CN(dr("PrdPrice"))
        txtDesigner.Text = CN(dr("PrdDesignerName"))
        txtNotes.Text = CN(dr("PrdNote"))

        ddlVisibility.SelectedValue = CN(dr("PrdVisible"), 0)

        Dim ctf As String = CN(dr("PrdTypeFlags"))
        cbxC.Checked = ctf.Contains("C")
        cbxD.Checked = ctf.Contains("D")
        cbxS.Checked = ctf.Contains("S")
        cbxO.Checked = ctf.Contains("O")

        txtMetaTitle.Text = CN(dr("PrdMetaTitle"))
        txtMetaDesc.Text = CN(dr("PrdMetaDesc"))
        txtMetaKeywords.Text = CN(dr("PrdMetaKeywords"))

    End Sub

    Sub LoadOptions()
        Dim db = New EasySql(Constring)
        db.ReturnType = EasyDBReturnType.DataTable
        db.AddParameter("@OptProductID", CInt(hdnProductID.Value))
        db.CommandText = "SELECT * FROM tblProductOption WHERE OptProductID = @OptProductID"

        tblOptions.Rows.Clear()

        Dim dt As DataTable = db.Execute
        AddOptionHeader()
        For Each dr As DataRow In dt.Rows
            AddOptionRow(dr)
        Next
    End Sub

    Sub AddOptionHeader()
        Dim tr As New TableRow

        Dim th As New TableHeaderCell
        th.Text = ""
        th.Width = 45
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Text = "Name"
        th.Width = 450
        tr.Cells.Add(th)

        th = New TableHeaderCell
        th.Text = ""
        tr.Cells.Add(th)

        tblOptions.Rows.Add(tr)

    End Sub

    Sub AddOptionRow(dr As DataRow)
        Dim tr As New TableRow

        Dim tc As New TableCell

        Dim img As New HtmlImage
        img.Src = "/40x20/Data/Image/Swatch/" & dr("OptSwatch")
        img.Style.Add("border", "1px solid #545454")
        tc.Controls.Add(img)
        tr.Cells.Add(tc)

        tc = New TableCell
        Dim tb As New TextBox
        tb.ID = "txtOption_" & dr("OptID")
        tb.Text = dr("OptName")
        tb.Width = tblOptions.Rows(0).Cells(1).Width.Value - 10
        tc.Controls.Add(tb)

        tr.Cells.Add(tc)

        tc = New TableCell

        Dim ib = New Button
        ib.ID = "btnSaveOption_" & dr("OptID")
        ib.Text = "Save"
        AddHandler ib.Click, AddressOf SaveOptionRow
        tc.Controls.Add(ib)

        ib = New Button
        ib.ID = "btnDeleteOption_" & dr("OptID")
        ib.Text = "Delete"
        AddHandler ib.Click, AddressOf DeleteOptionRow
        tc.Controls.Add(ib)

        tr.Cells.Add(tc)

        tblOptions.Rows.Add(tr)

    End Sub

    Sub LoadImages()
        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataTable
        db.AddParameter("@PimProductID", hdnProductID.Value)
        db.CommandText = "SELECT * FROM tblProductImage WHERE PimProductID = @PimProductID"

        Dim dt As DataTable = db.Execute

        pnlImages.Controls.Clear()

        For Each dr As DataRow In dt.Rows

            Dim pnl = New Panel
            pnl.CssClass = "ProductImagePanel"

            Dim img = New Image
            img.ImageUrl = "/200x150R/Data/Image/Product/" & dr("pimImage")
            pnl.Controls.Add(img)

            Dim rb = New RadioButton
            rb.ID = "Pim_" & dr("PimID")
            rb.Checked = False
            rb.GroupName = "ProductImages"
            If dr("PimDefault") = 1 Then rb.Checked = True
            rb.Text = "Make Default Image"

            pnl.Controls.Add(rb)

            Dim ib = New ImageButton
            ib.OnClientClick = "return confirm('Really delete this image?');"
            ib.ImageUrl = "/App/Images/Icon/delete-icon.png"
            ib.ID = "DelPim_" & dr("PimID")
            AddHandler ib.Click, AddressOf DeleteProductImage
            pnl.Controls.Add(ib)

            pnlImages.Controls.Add(pnl)
        Next

    End Sub



    Sub SaveProduct() Handles btnSaveDetails.Click


        Dim db = New EasySql
        db.AddParameter("@PrdFullName", txtFullName.Text)
        db.AddParameter("@PrdTagLine", txtStrapLine.Text)
        db.AddParameter("@PrdSummary", txtSummary.Text)
        db.AddParameter("@PrdFeature", txtFeatures.Text)
        db.AddParameter("@PrdDimensions", txtDimensions.Text)
        db.AddParameter("@PrdPrice", txtPrice.Text)
        db.AddParameter("@PrdDesignerName", txtDesigner.Text)
        db.AddParameter("@PrdNote", txtNotes.Text)
        db.AddParameter("@PrdVisible", ddlVisibility.SelectedValue)

        db.AddParameter("@PrdMetaTitle", txtMetaTitle.Text)
        db.AddParameter("@PrdMetaDesc", txtMetaDesc.Text)
        db.AddParameter("@PrdMetaKeywords", txtMetaKeywords.Text)



        Dim ctf As String = ""
        If cbxC.Checked Then ctf &= "C"
        If cbxD.Checked Then ctf &= "D"
        If cbxS.Checked Then ctf &= "S"
        If cbxO.Checked Then ctf &= "O"
        db.AddParameter("@PrdTypeFlags", ctf)


        Dim i As Integer = 0

        If hdnProductID.Value > 0 Then
            db.ReturnType = EasyDBReturnType.Rows_Affected
            db.AddParameter("@PrdID", hdnProductID.Value)
            db.CommandText = db.UpdateString("tblProduct", "PrdID = @PrdID", "@PrdID")
            i = db.Execute

        Else
            db.ReturnType = EasyDBReturnType.Scope_Identity
            db.CommandText = db.InsertString("tblProduct")
            i = db.Execute
            If i > 0 Then hdnProductID.Value = i

        End If

        If i > 0 Then
            lblDetailsResponse.Text = "Product Saved"
        Else
            lblDetailsResponse.Text = "Product Not Saved"
        End If

        tabOptions.Visible = (hdnProductID.Value > 0)
        tabImages.Visible = (hdnProductID.Value > 0)
        tabNote.Visible = (hdnProductID.Value > 0)

    End Sub

    Sub SaveNote() Handles btnSaveNote.Click


        Dim db = New EasySql
        db.AddParameter("@PrdNote", txtNotes.Text)

        Dim i As Integer = 0

        If hdnProductID.Value > 0 Then
            db.ReturnType = EasyDBReturnType.Rows_Affected
            db.AddParameter("@PrdID", hdnProductID.Value)
            db.CommandText = db.UpdateString("tblProduct", "PrdID = @PrdID", "@PrdID")
            i = db.Execute

        Else
            db.ReturnType = EasyDBReturnType.Scope_Identity
            db.CommandText = db.InsertString("tblProduct")
            i = db.Execute
            If i > 0 Then hdnProductID.Value = i

        End If

        If i > 0 Then
            lblNoteResponse.Text = "Notes Saved"
        Else
            lblNoteResponse.Text = "Notes Not Saved"
        End If
    End Sub

    Sub AddOption() Handles btnSaveNewOption.Click

        If Not flNewOption.HasFile Then Exit Sub
        Dim fi = New IO.FileInfo("C:\" & flNewOption.FileName)

        Dim fn = Now.Ticks & fi.Extension

        flNewOption.SaveAs(Server.MapPath("/Data/Image/Swatch/") & fn)

        Dim db = New EasySql(Constring)
        db.AddParameter("@OptProductID", hdnProductID.Value)
        db.AddParameter("@OptName", txtNewOption.Text)
        db.AddParameter("@OptSwatch", fn)
        db.Insert("tblProductOption", True, "OptName")
        db.Execute()

        txtNewOption.Text = ""

        LoadOptions()
    End Sub

    Sub SaveOptionRow(s As Object, e As EventArgs)
        Dim id As Integer = CType(s, Button).ID.Split("_")(1)

        Dim tb As TextBox = tblOptions.FindControl("txtOption_" & id)

        Dim db = New EasySql(Constring)
        db.AddParameter("@OptID", id)
        db.AddParameter("@OptName", tb.Text)
        db.CommandText = "UPDATE tblProductOption SET OptName = @OptName WHERE OptID = @OptID"
        db.Execute()

        LoadOptions()
    End Sub

    Sub DeleteOptionRow(s As Object, e As EventArgs)
        Dim id As Integer = CType(s, Button).ID.Split("_")(1)

        Dim db = New EasySql(Constring)
        db.AddParameter("@OptID", id)
        db.CommandText = "DELETE FROM tblProductOption WHERE OptID = @OptID"
        db.Execute()

        LoadOptions()
    End Sub

    Sub UploadNewImage() Handles btnUploadPim.Click
        If Not flPim.HasFile Then Exit Sub
        Dim fi = New IO.FileInfo("C:\" & flPim.Filename)
        Dim fn As String = Now.Ticks & fi.Extension

        Try
            flPim.SaveAs(Server.MapPath("/Data/Image/Product/") & fn)


            Dim db = New EasySql
            db.ReturnType = EasyDBReturnType.Scope_Identity
            db.AddParameter("@PimProductID", hdnProductID.Value)
            db.AddParameter("@PimImage", fn)

            Dim i = db.Insert("tblProductImage")

            If i > 0 Then
                lblPimUploadResponse.Text = "Image Uploaded"
                LoadImages()
                Exit Sub
            Else
                lblPimUploadResponse.Text = "Failed to Upload Image"
            End If
        Catch ex As Exception

        End Try

    End Sub

    Sub SaveImages() Handles btnImageSave.Click
        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.Scope_Identity
        db.AddParameter("@PimProductID", hdnProductID.Value)

        db.CommandText = ""
        For Each c As Control In pnlImages.Controls
            If Not c.GetType.Equals(pnlImages.GetType) Then Continue For

            Dim img As Image = c.Controls(0)
            Dim rb As RadioButton = c.Controls(1)
            Dim d = 0
            If rb.Checked Then d = 1
            db.CommandText &= "UPDATE tblProductImage SET PimDefault = " & d & " WHERE PimProductID = @PimProductID AND PimID = " & rb.ID.Split("_")(1) & ";" & vbCrLf
        Next

        db.Execute()
        If db.ErrorString = "" Then
            lblImageResponse.Text = "Default Image Updated"
            Exit Sub
        Else
            lblImageResponse.Text = "Failed to Update Default Image"
        End If

    End Sub

    Sub DeleteProductImage(s As Object, e As EventArgs)
        Dim ib As ImageButton = s

        Dim id = ib.ID.Split("_")(1)

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataRow
        db.AddParameter("@PimID", id)
        db.AddParameter("@Filename", "")
        db.CommandText = "SET @Filename = (SELECT PimImage FROM tblProductImage WHERE PimID = @PimID);" & vbCrLf
        db.CommandText &= "DELETE FROM tblProductImage WHERE PimID = @PimID;" & vbCrLf
        db.CommandText &= "SELECT @Filename;"

        Dim dr As DataRow = db.Execute
        If dr Is Nothing Then
            LoadImages()
            Exit Sub
        End If

        Dim fn = dr(0)

        If fn <> "" Then
            Try
                Dim fi = New IO.FileInfo(Server.MapPath("/Data/Image/Product/") & fn)
                If fi.Exists Then fi.Delete()
            Catch ex As Exception

            End Try
        End If
        LoadImages()
    End Sub
End Class
