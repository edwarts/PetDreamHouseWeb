Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Partial Class Data_Image_Gen_Img
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            Dim w = 0
            Dim h = 0
            Dim z = 100
            Dim q = 80
            Dim src = Request.QueryString("src")
            Dim fi = New FileInfo(Server.MapPath(src))
            Dim bmp = New Bitmap(fi.FullName)

            If IsNumeric(Request.QueryString("w")) Then w = Request.QueryString("w") Else w = bmp.Width
            If IsNumeric(Request.QueryString("h")) Then h = Request.QueryString("h") Else h = bmp.Height
            If IsNumeric(Request.QueryString("z")) Then z = Request.QueryString("z") Else z = 100
            If IsNumeric(Request.QueryString("q")) Then q = Request.QueryString("q") Else q = 80

            If z < 100 Then z = 100
            If q > 100 Then q = 100

            Crop(bmp, w, h, z)

            Dim OutCodec As ImageCodecInfo = Nothing
            Dim mime As String = "image/jpeg"

            Dim cd = ImageCodecInfo.GetImageEncoders
            For Each c As ImageCodecInfo In cd
                If c.FilenameExtension.ToLower.Contains(fi.Extension.ToLower) Then
                    OutCodec = c
                    mime = c.MimeType
                    Exit For
                End If
            Next

            Dim enc = New EncoderParameters(1)
            enc.Param(0) = New EncoderParameter(Encoder.Quality, q)

            Dim ms = New IO.MemoryStream
            bmp.Save(ms, OutCodec, enc)
            bmp.Dispose()

            ms.Position = 0

            Response.Clear()
            Response.ContentType = mime
            ms.WriteTo(Response.OutputStream)
            Response.End()

        Catch ex As Exception

        End Try
    End Sub

    Sub Crop(ByRef bmp As Bitmap, w As Integer, h As Integer, z As Double)

        Dim bw = bmp.Width
        Dim bh = bmp.Height

        Dim tw = bw
        Dim th = bh



        Dim div = bw / bh

        While tw > w And th > h
            tw -= 1
            th = tw / div
        End While

        tw = tw * (z / 100)
        th = th * (z / 100)

        Dim sbmp = New Bitmap(w, h)

        Dim ox As Integer = (w - tw) / 2
        Dim oy As Integer = (h - th) / 2

        Dim g = Graphics.FromImage(sbmp)
        g.DrawImage(bmp, ox, oy, tw, th)
        g.Save()
        bmp = sbmp
        'sbmp.Dispose()

    End Sub
End Class
