Imports System.Data
Imports SharedProperties
Imports System.Configuration.ConfigurationManager
Imports Anetics.Data

Partial Class Basket_Default
    Inherits System.Web.UI.Page
    Dim tr As TableRow
    Dim tc As TableCell
    Dim ib As ImageButton

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        divDiscounts.Visible = AppSettings("BS_EnableDiscounts")

        LoadBasket(True)
        PP1.Debug = False
        PP1.Mode = Anetics.Web.StateMode.Live
        PP1.Command = Anetics.Web.CmdType._cart
        PP1.CommandProperties.Custom = ThisSession
        PP1.CommandProperties.BusinessName = MyAppSettings("PP_Username")
        PP1.CommandProperties.CurrencyCode = MyAppSettings("PP_Currency")
        PP1.CommandProperties.NotifyUrl = "http://" & Request.Url.Host & "/Basket/IPN.aspx"
        PP1.CommandProperties.ReturnUrl = "http://" & Request.Url.Host & "/PayPalDone"
        PP1.CommandProperties.CancelReturnUrl = "http://" & Request.Url.Host & "/Basket"
        PP1.CommandProperties.PageStyle = MyAppSettings("PP_Style")
        PP1.AssignTrigger(btnBuy)
        PP1.AssignTrigger(btnBuy2)

        btnBuy2.Text = "Pay £" & FormatNumber(PP1.Subtotal - PP1.Discount, 2) & " Now"

        pnlDiscount.Visible = PP1.Discount > 0
        lblDiscount.InnerHtml = "YOU SAVE: £" & FormatNumber(PP1.Discount, 2)
        lblDiscount.Style.Add("color", "red")

        divDiscounts.Visible = AppSettings("BS_EnableDiscounts")
        pnlDiscount.Visible = AppSettings("BS_EnableDiscounts")

    End Sub

    Protected Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender
        LoadBasket(False)

        Dim dr As DataRow = BasketManager.GetSummary

        Dim tot = PP1.Subtotal
        Dim dis = PP1.Discount

        lblBasketItems.Text = CN(dr(0), 0)
        lblTotalCost.Text = "£" & FormatNumber(CN(dr(1), 0), 2)
        lblTotalItems.Text = CN(dr(2), 0)

        lblTotalItems.Visible = CBool(MyAppSettings("AllowBasketQuantityModification"))
        ttt.Visible = lblTotalItems.Visible


        btnBuy.Visible = (CN(dr(0), 0) > 0)
        btnBuy2.Visible = btnBuy.Visible

        pnlNoItems.Visible = (CN(dr(0), 0) = 0)
    End Sub

    Sub LoadBasket(IsPreLoad As Boolean)
        tblBasket.Rows.Clear()

        Dim db As New EasySql
        db.AddParameter("@sess", ThisSession)
        db.ReturnType = EasyDBReturnType.DataRow
        db.CommandText = "SELECT" & vbCrLf
        db.CommandText &= "COALESCE((SELECT SUM(BasPrice * BasQuantity) FROM tblBasket WHERE BasSession = @sess AND BasComplete = 0),0) as Tot," & vbCrLf
        db.CommandText &= "COALESCE((SELECT TOP(1)BasDiscountMin FROM tblBasket WHERE BasSession = @sess AND BasComplete = 0),0) as MinSpend," & vbCrLf
        db.CommandText &= "COALESCE((SELECT TOP(1)BasDiscountAmount FROM tblBasket WHERE BasSession = @sess AND BasComplete = 0),0) as FixedDiscount," & vbCrLf
        db.CommandText &= "COALESCE((SELECT TOP(1)BasDiscountRate FROM tblBasket WHERE BasSession = @sess AND BasComplete = 0),0) as PercentDiscount," & vbCrLf
        db.CommandText &= "COALESCE((SELECT COUNT(*) FROM tblBasket WHERE BasSession = @sess AND BasComplete = 0),0) as NumItems" & vbCrLf

        Dim sr As DataRow = db.Execute
        Dim Tot As Double = sr("Tot")
        Dim DiscountAmount As Double = sr("FixedDiscount")
        Dim DiscountPercent As Double = (sr("PercentDiscount") / 100)
        Dim NumItems As Double = sr("NumItems")
        Dim MinSpend As Double = sr("MinSpend")



        Dim AllowDiscount As Boolean = (Tot > CN(sr("MinSpend"), 0))
        Dim HasDiscount As Boolean = (DiscountAmount + DiscountPercent) > 0


        Dim DiscountMode As Integer = 0
        Dim TotalDiscount As Double = 0

        Dim dt As DataTable = BasketManager.GetContents
        PP1.CommandProperties.Items.Clear()

        Dim CartTop As Double = 0

        For Each dr As DataRow In dt.Rows


            Dim pi = New Anetics.Web.CartItem
            pi.Name = dr("PrdFullName") & " (" & dr("OptName") & ")"
            pi.Number = "REF:" & dr("PrdID") & "-" & dr("BasID")
            pi.Amount = dr("BasPrice")
            pi.Quantity = dr("BasQuantity")

            If HasDiscount And AllowDiscount Then
                Dim Disc As Double = 0
                Disc += (dr("BasPrice") * DiscountPercent)
                If DiscountMode = 0 Then


                    pi.Amount = pi.Amount - Disc
                    pi.Amount = pi.Amount - (DiscountAmount / sr("NumItems")) / pi.Quantity
                    pi.DiscountAmount = 0
                    pi.DiscountRate = 0
                    TotalDiscount += Disc * pi.Quantity

                Else

                    pi.DiscountAmount = DiscountAmount
                    pi.DiscountRate = DiscountPercent

                    TotalDiscount += Disc
                End If

            End If


            PP1.CommandProperties.Items.Add(pi)

            tr = New TableRow

            tc = New TableCell
            tc.CssClass = "Name"
            tc.Text = "<b>" & dr("PrdFullName") & "</b>"
            tc.Text &= "<i>Option: " & dr("OptName") & "</i>"
            tr.Cells.Add(tc)

            If CBool(MyAppSettings("AllowBasketQuantityModification")) Then
                tc = New TableCell
                tc.CssClass = "Quantity"

                Dim tb = New TextBox
                tb.Text = dr("BasQuantity")
                tb.ID = "Quant_" & dr("BasID")
                tb.Width = 30
                tc.Controls.Add(tb)

                ib = New ImageButton
                ib.ImageAlign = ImageAlign.AbsMiddle
                ib.ID = "SetQuant_" & dr("BasID")
                ib.ImageUrl = "/App/Images/Icon/refresh-icon.png"
                If IsPreLoad Then
                    AddHandler ib.Click, AddressOf UpdateQuantity
                End If
                tc.Controls.Add(ib)

                tr.Cells.Add(tc)
            End If

            tc = New TableCell
            tc.CssClass = "Price"
            tc.HorizontalAlign = HorizontalAlign.Right
            tc.Text = "<b>£" & FormatNumber(pi.Amount * dr("BasQuantity"), 2) & "</b>"
            If CBool(MyAppSettings("AllowBasketQuantityModification")) And dr("BasQuantity") > 1 Then
                tc.Text &= "<i>£" & FormatNumber(pi.Amount, 2) & " ea</i>"
            End If
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Width = 20
            ib = New ImageButton
            ib.ToolTip = "Remove this Item"
            ib.ImageAlign = ImageAlign.AbsMiddle
            ib.ID = "Delete_" & dr("BasID")
            ib.ImageUrl = "/App/Images/Icon/delete-icon.png"
            If IsPreLoad Then
                AddHandler ib.Click, AddressOf RemoveItem
            End If
            tc.Controls.Add(ib)
            tr.Cells.Add(tc)

            tblBasket.Rows.Add(tr)
        Next

        TotalDiscount += DiscountAmount

        lblDiscountType.InnerText = ""

        If HasDiscount And AllowDiscount Then
            pnlDiscount.Visible = True
            lblDiscount.InnerText = "YOU SAVE £" & FormatNumber(TotalDiscount, 2)

            If DiscountAmount > 0 And DiscountPercent > 0 Then
                lblDiscountType.InnerHtml = "Applied Discount: £" & FormatNumber(DiscountAmount, 2) & " + " & DiscountPercent * 100 & "%"

            ElseIf DiscountAmount > 0 And DiscountPercent = 0 Then
                lblDiscountType.InnerHtml = "Applied Discount: £" & FormatNumber(DiscountAmount, 2)

            ElseIf DiscountAmount = 0 And DiscountPercent > 0 Then
                lblDiscountType.InnerHtml = "Applied Discount: " & DiscountPercent * 100 & "%"

            End If

        ElseIf HasDiscount And Not AllowDiscount Then
            pnlDiscount.Visible = True
            lblDiscount.InnerText = "Spend £" & FormatNumber(MinSpend, 2) & " or more to activate your discount"

        Else
            pnlDiscount.Visible = False
        End If

        lblDiscount.Visible = HasDiscount

    End Sub

    Sub UpdateQuantity(sender As Object, e As EventArgs)

        Dim ib As ImageButton = sender
        Dim BasID As Integer = ib.ID.Split("_")(1)
        Dim tc As TableCell = ib.Parent
        Dim tb As TextBox = tc.FindControl("Quant_" & BasID)

        If IsNumeric(tb.Text) Then BasketManager.UpdateQuantity(BasID, tb.Text)

        LoadBasket(False)

        btnBuy2.Text = "Pay £" & FormatNumber(PP1.Subtotal - PP1.Discount, 2) & " Now"

        pnlDiscount.Visible = PP1.Discount > 0
        lblDiscount.InnerHtml = "YOU SAVE: £" & FormatNumber(PP1.Discount, 2)
        lblDiscount.Style.Add("color", "red")


    End Sub

    Sub RemoveItem(sender As Object, e As EventArgs)

        Dim ib As ImageButton = sender
        Dim BasID As Integer = ib.ID.Split("_")(1)

        BasketManager.RemoveProduct(BasID)

    End Sub

    Sub AssignDiscount() Handles btnSetPromo.Click

        Dim db = New easysql
        db.CommandText = "UPDATE tblBasket SET " & vbCrLf
        db.CommandText &= "BasDiscountID = COALESCE((SELECT TOP(1)ProID FROM tblPromoCodes WHERE ProCode = @code),0)," & vbCrLf
        db.CommandText &= "BasDiscountAmount = COALESCE((SELECT TOP(1)ProAmount  FROM tblPromoCodes WHERE ProCode = @code),0)," & vbCrLf
        db.CommandText &= "BasDiscountRate = COALESCE((SELECT TOP(1)ProPercent  FROM tblPromoCodes WHERE ProCode = @code),0)," & vbCrLf
        db.CommandText &= "BasDiscountMin = COALESCE((SELECT TOP(1)ProMinSpend  FROM tblPromoCodes WHERE ProCode = @code),0)" & vbCrLf
        db.CommandText &= "WHERE BasSession = @sess AND BasComplete = 0 AND (SELECT COUNT(*) FROM tblPromoCodes WHERE ProCode = @code AND GETDATE() BETWEEN ProStart AND ProEnd) > 0" & vbCrLf


        db.AddParameter("@sess", ThisSession)
        db.AddParameter("@code", txtPromo.Text.Trim)
        db.Execute()

        LoadBasket(False)

        btnBuy2.Text = "Pay £" & FormatNumber(PP1.Subtotal - PP1.Discount, 2) & " Now"

        pnlDiscount.Visible = PP1.Discount > 0
        lblDiscount.InnerHtml = "YOU SAVE: £" & FormatNumber(PP1.Discount, 2)
        lblDiscount.Style.Add("color", "red")

    End Sub
End Class
