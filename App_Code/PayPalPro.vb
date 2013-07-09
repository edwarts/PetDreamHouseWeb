Imports Microsoft.VisualBasic
Imports com.paypal.sdk.services
Imports com.paypal.sdk.profiles
Imports com.paypal.soap.api
Imports System.Configuration.ConfigurationManager
Imports SharedProperties

Public Class PayPalPro
    Public Sub New()
    End Sub
    Public Function DoDirectPayment(SessionID As String, paymentAmount As Double, buyerLastName As String, buyerFirstName As String, buyerAddress1 As String, buyerAddress2 As String, buyerCity As String, _
     buyerState As String, buyerZipCode As String, creditCardType As CreditCardTypeType, creditCardNumber As String, CVV2 As String, Expiry As Date, paymentAction As PaymentActionCodeType) As String
        Dim caller As New CallerServices()

        Dim profile As IAPIProfile = ProfileFactory.createSignatureAPIProfile()
        profile.APIUsername = MyAppSettings("PP_API_User")
        profile.APIPassword = MyAppSettings("PP_API_Password")
        profile.APISignature = MyAppSettings("PP_Signature")
        profile.Environment = MyAppSettings("PP_Mode")
        caller.APIProfile = profile


        ' Create the request object.
        Dim pp_Request As New DoDirectPaymentRequestType()
        pp_Request.Version = "51.0"

        ' Add request-specific fields to the request.
        ' Create the request details object.
        pp_Request.DoDirectPaymentRequestDetails = New DoDirectPaymentRequestDetailsType()

        pp_Request.DoDirectPaymentRequestDetails.IPAddress = HttpContext.Current.Request.UserHostAddress
        pp_Request.DoDirectPaymentRequestDetails.MerchantSessionId = SessionID
        pp_Request.DoDirectPaymentRequestDetails.PaymentAction = paymentAction

        pp_Request.DoDirectPaymentRequestDetails.CreditCard = New CreditCardDetailsType()

        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CreditCardNumber = creditCardNumber
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CreditCardType = creditCardType
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CVV2 = CVV2
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.ExpMonth = Expiry.Month
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.ExpYear = Expiry.Year
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.ExpMonthSpecified = True
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.ExpYearSpecified = True
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner = New PayerInfoType()
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Payer = ""
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerID = ""
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerStatus = PayPalUserStatusCodeType.unverified
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerCountry = CountryCodeType.US

        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address = New AddressType()
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Street1 = buyerAddress1
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Street2 = buyerAddress2
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.CityName = buyerCity
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.StateOrProvince = buyerState
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.PostalCode = buyerZipCode
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.CountryName = "USA"
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Country = CountryCodeType.US
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.CountrySpecified = True

        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerName = New PersonNameType()
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerName.FirstName = buyerFirstName
        pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerName.LastName = buyerLastName
        pp_Request.DoDirectPaymentRequestDetails.PaymentDetails = New PaymentDetailsType()
        pp_Request.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal = New BasicAmountType()
        ' NOTE: The only currency supported by the Direct Payment API at this time is US dollars (USD).

        pp_Request.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal.currencyID = CurrencyCodeType.USD
        pp_Request.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal.Value = paymentAmount

        ' Execute the API operation and obtain the response.
        Dim pp_response As New DoDirectPaymentResponseType()
        pp_response = DirectCast(caller.Call("DoDirectPayment", pp_Request), DoDirectPaymentResponseType)
        Return pp_response.Ack.ToString()
    End Function
End Class
