Imports System.Text.RegularExpressions
Imports System.IO

Partial Class App_CSS_Alternate_Browser
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim di = New DirectoryInfo(Server.MapPath("/") & "app/css/alternate/")

        Dim arr = New List(Of String)
        For Each fi As FileInfo In di.GetFiles("*.css")
            arr.Add(fi.Name.Replace(fi.Extension, ""))
        Next

        Dim re = New Regex("(" & Join(arr.ToArray, "|") & ")", RegexOptions.IgnoreCase Or RegexOptions.Singleline)

        Dim m = re.Match(Request.UserAgent)

        If m.Success Then

            Dim txt = File.ReadAllText(Server.MapPath("/") & "app/css/alternate/" & m.Groups(1).Value & ".css")

            Response.Clear()
            Response.ContentType = "text/css"
            Response.Write(txt)
            Response.End()

        Else
            Response.Clear()
            Response.ContentType = "text/css"
            Response.Write("")
            Response.End()
        End If

    End Sub
End Class
