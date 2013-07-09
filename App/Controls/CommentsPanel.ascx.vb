Imports Anetics.Data
Imports System.Data
Imports SharedProperties

Partial Class App_Controls_CommentsPanel
    Inherits System.Web.UI.UserControl
    Dim pu As DataRow
    Dim au As DataRow

    Public Property Zone As String = ViewState("CommentZone")
    Public Property IdParameter As Integer = ViewState("IdParameter")
    Public ReadOnly Property ObjectID As Integer
        Get
            Return Request.QueryString(Zone & "ID")
        End Get
    End Property
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        pu = ThisUser
        au = Admin.ThisAdmin
        LoadComments()

    End Sub


    Sub SubmitComment() Handles btnSubmitComment.Click
        If pu Is Nothing Then
            lblResponse.Text = "You must be logged in to comment"
            Exit Sub
        End If

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.Rows_Affected
        db.AddParameter("@ComZone", Zone)
        db.AddParameter("@ComUser", pu("UsrID"))
        db.AddParameter("@ComItem", ObjectID)
        db.AddParameter("@ComComment", txtComment.Text)

        Dim i = db.Insert("tblComment", True)

        If i > 0 Then
            lblResponse.Text = "Thank You your comment has been added &nbsp;&nbsp;"
            Dim ed = New EmailDispatcher

            Dim txt = ed.FillTemplate("NewComment.html", pu)

            Dim lnk = "<a href=""http://" & Request.Url.Host & Page.Form.Action & """>Click here to view the comment online</a>"

            txt = txt.Replace("[name]", pu("UsrName"))
            txt = txt.Replace("[link]", lnk)
            txt = txt.Replace("[commentText]", txtComment.Text.Replace(vbCrLf, "<br>").Replace(vbCr, "<br>").Replace(vbLf, "<br>"))

            Dim ob = ed.SendEmailToOwner("Comment Added in Zone: " & Zone, txt)

            txtComment.Text = ""


        Else
            lblResponse.Text = "Comment Not Added"
        End If

    End Sub

    Sub LoadComments()

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataTable
        db.AddParameter("@ObjID", ObjectID)
        db.CommandText = "SELECT * FROM tblComment,tblUser WHERE ComZone = '" & Zone & "' AND ComUser = UsrID AND ComItem = @ObjID ORDER BY ComDate DESC"
        db.ThowErrors = True
        Dim dt As DataTable = db.Execute

        pnlComments.Controls.Clear()

        For Each dr As DataRow In dt.Rows

            Dim div = New Panel
            div.CssClass = "Comment"

            Dim lbl = New Label
            lbl.CssClass = "Date"
            lbl.Text = Format(dr("ComDate"), "dd MMM yyyy")
            div.Controls.Add(lbl)

            lbl = New Label
            lbl.CssClass = "Name"
            lbl.Text = dr("UsrName")
            div.Controls.Add(lbl)

            Dim Sd As Boolean = False

            If Not pu Is Nothing Then If pu("UsrID") = dr("ComUser") Then Sd = True
            If Not au Is Nothing Then Sd = True
            If Sd Then
                Dim btn = New ImageButton
                btn.ID = "btnDeleteComment_" & dr("ComID")
                btn.CssClass = "Delete"
                btn.ToolTip = "Delete Comment"
                btn.ImageUrl = "/App/Images/Icon/delete-icon.png"
                div.Controls.Add(btn)
                AddHandler btn.Click, AddressOf CommentDelete
            End If

            lbl = New Label
            lbl.CssClass = "Text"
            lbl.Text = CN(dr("ComComment")).ToString.Replace(vbCrLf, "<br>").Replace(vbCr, "<br>").Replace(vbLf, "<br>")
            div.Controls.Add(lbl)

            pnlComments.Controls.Add(div)

        Next


    End Sub

    Protected Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender
        LoadComments()

    End Sub

    Sub CommentDelete(s As Object, e As EventArgs)
        Dim id = CType(s, ImageButton).ID.Split("_")(1)

        Dim db = New EasySql
        db.AddParameter("@ComID", id)
        db.CommandText = "DELETE FROM tblComment WHERE ComID = @ComID"
        db.Execute()

    End Sub

End Class
