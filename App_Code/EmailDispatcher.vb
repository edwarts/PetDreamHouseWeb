Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail
Imports System.Configuration.ConfigurationManager
Imports System.IO
Imports System.Data
Imports SharedProperties

Public Class EmailDispatcher

    Public Function SendEmailToOwner(Subject As String, Html As String) As SmtpStatusCode
        Return SendEmail(MyAppSettings("ES_FromName"), MyAppSettings("ES_EmailAddress"), Subject, Html)
    End Function

    Public Function SendEmail(RecipientName As String, RecipientEmail As String, Subject As String, Html As String) As SmtpStatusCode

        Dim mai = New MailMessage
        mai.From = New MailAddress(MyAppSettings("ES_EmailAddress"), MyAppSettings("ES_FromName"))
        mai.Sender = mai.From

        mai.To.Add(New MailAddress(RecipientEmail, RecipientName))

        For Each i As String In Split(MyAppSettings("ES_CC"), ";")
            If i.Trim = "" Then Continue For
            mai.CC.Add(i)
        Next

        For Each i As String In Split(MyAppSettings("ES_BCC"), ";")
            If i.Trim = "" Then Continue For
            mai.Bcc.Add(i)
        Next

        mai.Subject = Subject
        mai.IsBodyHtml = True
        mai.Body = Html

        Dim smtp = New SmtpClient(MyAppSettings("ES_Mailserver"))
        Try
            If MyAppSettings("ES_Username") <> "" And MyAppSettings("ES_Password") <> "" Then
                smtp.Credentials = New NetworkCredential(MyAppSettings("ES_Username"), MyAppSettings("ES_Password"))
            End If
            smtp.EnableSsl = CBool(MyAppSettings("ES_UseSSL"))

            smtp.Send(mai)
            Return SmtpStatusCode.Ok

        Catch sx As SmtpException
            Return sx.StatusCode
        Catch ex As Exception
            Return SmtpStatusCode.GeneralFailure
        End Try
    End Function

    Public Function FillTemplate(filename As String, dr As DataRow) As String
        Dim fi = New FileInfo(filename)
        If Not fi.Exists Then
            fi = New FileInfo(HttpContext.Current.Server.MapPath("/App/Template/") & filename)
        End If
        If Not fi.Exists Then
            Return ""
        End If

        Dim txt As String = File.ReadAllText(fi.FullName)

        If Not dr Is Nothing Then
            For Each dc As DataColumn In dr.Table.Columns
                txt = Replace(txt, "[" & dc.ColumnName & "]", CN(dr(dc.ColumnName)))
            Next
        End If
        txt = Replace(txt, "[host]", HttpContext.Current.Request.Url.Host)

        Return txt

    End Function

End Class
