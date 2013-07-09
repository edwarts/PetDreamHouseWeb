Imports Anetics.Data
Imports System.Data
Imports SharedProperties

Partial Class Controls_VotePanel
    Inherits System.Web.UI.UserControl

    Public Event ItemChanged()

    Dim cid As Integer = 0
    Dim Usr As DataRow
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblResponse.Text = ""


    End Sub

    Public Property TargetControl As String
        Get
            Return ModalPopupExtender1.TargetControlID
        End Get
        Set(value As String)
            ModalPopupExtender1.TargetControlID = value
        End Set
    End Property

    Public Sub LoadCurrentVote(ConceptID As Integer)
        imgVote.ImageUrl = "/data/image/gen/starbar.aspx?v=0&t=large"
        hdnConceptID.Value = ConceptID
    End Sub

    Public Sub Show()
        ModalPopupExtender1.Show()
    End Sub

    Public Sub Hide()
        ModalPopupExtender1.Hide()
    End Sub

    Sub SubmitVote() Handles btnSaveVote.Click

        Dim db = New EasySQL(Constring)
        db.AddParameter("@CvtUserID", 0)
        db.AddParameter("@CvtConceptID", hdnConceptID.Value)
        db.AddParameter("@CvtVote", txtNewVote.Text)
        db.AddParameter("@CvtDate", Now)
        db.Insert("tblConceptVote")

        txtNewVote.Text = 0
        If db.ErrorString = "" Then RaiseEvent ItemChanged()
    End Sub
End Class
