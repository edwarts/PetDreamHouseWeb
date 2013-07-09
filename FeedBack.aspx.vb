Imports SharedProperties

Partial Class FeedBack
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
        lblResponse.Text = ""

        SetField(txtName, txtName.Text <> "", "Name is missing", lblResponse)
        SetField(txtEmail, IsEmail(txtEmail.Text), "Email is Invalid", lblResponse)
        SetField(txtFeedback, txtFeedback.Text <> "", "Feedback is missing", lblResponse)

        lblResponse.ForeColor = Drawing.Color.Red
        If lblResponse.Text <> "" Then Exit Sub


        'TODO: do something here
        Dim ed = New EmailDispatcher
        Dim txt = ed.FillTemplate("Feedback.html", Nothing)
        txt = Replace(txt, "[name]", txtName.Text)
        txt = Replace(txt, "[email]", txtEmail.Text)
        txt = Replace(txt, "[comments]", txtFeedback.Text)

        ed.SendEmail("Website Feedback", "support@petdreamhouse.com", "Feedback from Pet Dream House Website", txt)

        lblResponse.ForeColor = Drawing.Color.Red
        lblResponse.Text = "Thank You, your feedback was received &nbsp;&nbsp;"
    End Sub
End Class
