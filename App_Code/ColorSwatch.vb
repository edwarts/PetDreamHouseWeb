Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Drawing.Imaging
Public Class ColorSwatch

    Public Shared Function Create(HtmlColor As String) As String
        Dim c = ColorTranslator.FromHtml(HtmlColor)
        Return Create(c)
    End Function

    Public Shared Function Create(R As Integer, G As Integer, B As Integer) As String
        Dim c = Color.FromArgb(R, G, B)
        Return Create(c)
    End Function

    Public Shared Function Create(c As Color) As String
        Dim bmp = New Bitmap(42, 23)
        Dim g = Graphics.FromImage(bmp)
        g.FillRectangle(New SolidBrush(c), 0, 0, bmp.Width, bmp.Height)
        g.Save()
        Dim fi = New IO.FileInfo(HttpContext.Current.Server.MapPath("/") & "Data/Image/Swatch/" & ColorTranslator.ToHtml(c).Replace("#", "") & ".jpg")
        If fi.Exists Then Return fi.Name

        bmp.Save(fi.FullName, GetCodec(fi.Extension), Nothing)
        bmp.Dispose()
        Return fi.Name
    End Function

    Private Shared Function GetCodec(ext As String) As ImageCodecInfo

        Dim c = ImageCodecInfo.GetImageEncoders
        For Each ic As ImageCodecInfo In c
            If ic.FilenameExtension.ToLower.Contains(ext.ToLower) Then Return ic
        Next

        Return Nothing
    End Function
End Class
