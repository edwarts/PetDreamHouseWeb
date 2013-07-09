Imports com.paypal.sdk.services
Imports com.paypal.sdk.profiles
Imports com.paypal.soap.api
Imports System.Configuration.ConfigurationManager

Partial Class Basket_Payment
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Sub PayPro()

        Dim pp = New PayPalPro
        Dim i = pp.DoDirectPayment("12345",
                                   100,
                                   "Salter",
                                   "Chris",
                                   "2 Holderness Cottages",
                                    "Thorngumbald",
                                    "Hull",
                                    "East Riding of Yorkshire",
                                    "HU12 9NB",
                                    CreditCardTypeType.Visa,
                                    "1234123412341234",
                                    "999",
                                    Now.AddMonths(1),
                                    PaymentActionCodeType.Sale
                                    )







    End Sub
End Class
