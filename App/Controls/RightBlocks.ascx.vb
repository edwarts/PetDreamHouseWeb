Imports Anetics.Data
Imports System.Data
Imports SharedProperties

Partial Class Controls_RightBlocks
    Inherits System.Web.UI.UserControl

    Public Property AdvertIDs As String = "8"


    Public Property style As String
        Get
            Return Blocks.Attributes("style")
        End Get
        Set(value As String)
            Blocks.Attributes.Add("style", value)
        End Set
    End Property
    Public Property CssClass As String
        Get
            Return Blocks.CssClass
        End Get
        Set(value As String)
            Blocks.CssClass = value
        End Set
    End Property

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Request.IsLocal Then
            Dim di = New IO.DirectoryInfo(Server.MapPath("/Data/Image/Advertisements/"))
            For Each fi As IO.FileInfo In di.GetFiles
                Dim db = New EasySQL(Constring)
                db.AddParameter("@AdvImage", fi.Name)
                db.AddParameter("@AdvLink", "/")

                db.Insert("tblAdvert", True)
            Next
        End If

        Try

            Dim db = New EasySQL(Constring)
            db.ReturnType = EasyDBReturnType.DataTable
            db.CommandText = "SELECT * FROM tblAdvert"
            Dim dt As DataTable = db.Execute

            For Each i As String In Split(AdvertIDs, ",")
                If Not IsNumeric(i) Then Continue For
                Dim drs = dt.Select("AdvID = " & i)
                If drs.Length = 0 Then Continue For

                Dim dr = drs(0)

                Dim lnk = New HyperLink
                lnk.NavigateUrl = dr("AdvLink")

                Dim img = New Image
                img.AlternateText = "Pet Dream House"
                img.ImageUrl = "/Data/Image/Advertisements/" & dr("AdvImage")

                lnk.Controls.Add(img)

                Blocks.Controls.Add(lnk)

            Next
        Catch ex As Exception

        End Try

    End Sub
End Class
