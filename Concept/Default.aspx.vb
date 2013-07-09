Imports Anetics.Data
Imports System.Data
Imports SharedProperties

Partial Class ConceptDefault
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        LoadConcepts()

        'to make 8 items
        'LoadConcepts()

    End Sub

    Dim n As Integer = 0

    Sub LoadConcepts()
        Dim db = New EasySQL(Constring)
        db.ReturnType = EasyDBReturnType.DataTable
        db.CommandText = "SELECT *," & vbCrLf
        db.CommandText &= "COALESCE((SELECT AVG(CvtVote) FROM tblConceptVote WHERE CvtConceptID = ConID),0) as Vote" & vbCrLf
        db.CommandText &= "" & vbCrLf
        db.CommandText &= "FROM tblConcept,tblUser,tblConceptStatus WHERE ConDesignerID = UsrID AND CstID = ConStatus AND ConAccepted = 1"

        Dim dt As DataTable = db.Execute

        If db.ErrorString <> "" And Request.IsLocal Then
            Throw New Exception(db.ErrorString)
        End If

        If dt Is Nothing Then Exit Sub

        For Each dr As DataRow In dt.Rows

            AddConceptItem(dr)
            n += 1
        Next


    End Sub

    Sub AddConceptItem(dr As DataRow)

        Dim ItemUrl As String = "/Concept/" & dr("ConID") & "/" & dr("ConName").ToString.Replace(" ", "_")

        Dim div = New Panel
        div.CssClass = "ConceptListItem"

        Dim m = n Mod 4

        If m = 0 And n > 0 Then

            Dim d = New HtmlGenericControl("div")
            d.Style.Add("border-top", "1px dashed #9a8c83")
            d.Style.Add("padding", "10px")
            d.Style.Add("height", "1px")
            pnlProducts.Controls.Add(d)

        End If

        If m = 0 Then
            div.Style.Add("margin-left", "0px")
        Else
            div.Style.Add("margin-left", "80px")
        End If

        'div.Attributes.Add("onclick", "location.href='/Concept/" & dr("ConID") & "/" & dr("ConName").ToString.Replace(" ", "_") & "';")


        Dim img = New Image
        img.CssClass = "StatusImage"
        img.ImageUrl = "/App/Images/Concept Images/" & dr("CstListImage")
        div.Controls.Add(img)

        Dim a = New HyperLink
        a.NavigateUrl = ItemUrl
        img = New Image
        img.CssClass = "Image"
        img.ImageUrl = "/165x175/Data/Image/Concept/" & dr("ConImage1")
        a.Controls.Add(img)
        div.Controls.Add(a)

        Dim lbl = New Label
        lbl.CssClass = "Name"
        lbl.Text = dr("ConName")
        div.Controls.Add(lbl)

        Dim hl = New HyperLink
        hl.CssClass = "Designer"
        hl.Text = "By " & dr("UsrName")
        hl.NavigateUrl = "/Concept/" & dr("ConID") & "/" & dr("ConName").ToString.Replace(" ", "_")
        div.Controls.Add(hl)

        lbl = New Label
        lbl.CssClass = "Score"
        lbl.Text = "Current score:"
        div.Controls.Add(lbl)

        Dim p = New Panel
        img = New Image
        img.CssClass = "StarBar"
        img.ImageUrl = "/data/image/gen/starbar.aspx?v=" & dr("Vote") & "&t=small"
        p.Controls.Add(img)

        lbl = New Label
        lbl.CssClass = "CurrentScore"
        lbl.Text = FormatNumber(dr("Vote"), 1)
        p.Controls.Add(lbl)

        div.Controls.Add(p)



        pnlProducts.Controls.Add(div)
    End Sub
End Class
