Imports System.Drawing
Imports System.Drawing.Imaging

Partial Class Data_Image_Gen_Starbar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim t = Request.QueryString("t")
        Dim v As Double = Request.QueryString("v")
        If v > 5 Then v = 5
        v = v * 10

        Dim overlay = Server.MapPath("/data/image/gen/starbar.png")
        If t = "small" Then overlay = Server.MapPath("/data/image/gen/starbar-small.png")

        Dim fbmp = New Bitmap(overlay)

        Dim bbmp = New Bitmap(fbmp.Width, fbmp.Height)
        Dim g = Graphics.FromImage(bbmp)

        Dim p1 As Double = (fbmp.Width / 100) * 2

        Dim w As Integer = (p1 * v) - 1

        Dim c = ColorTranslator.FromHtml("#464646")

        g.FillRectangle(New SolidBrush(c), 1, 1, w, fbmp.Height - 2)


        g.DrawImage(fbmp, 0, 0, fbmp.Width, fbmp.Height)
        g.Save()

        fbmp.Dispose()

        Dim ms = New IO.MemoryStream
        bbmp.Save(ms, ImageFormat.Png)
        bbmp.Dispose()

        ms.Position = 0

        Response.Clear()
        Response.ContentType = "image/png"
        ms.WriteTo(Response.OutputStream)
        Response.End()

    End Sub
End Class
