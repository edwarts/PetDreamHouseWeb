Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Collections.Generic
Imports System.ComponentModel

<ParseChildren(True), PersistChildren(True)>
Partial Class ImageSlider
    Inherits System.Web.UI.UserControl

    Public Property ImageFolder As String
    Public Property Interval As Integer = 2000
    Public Property AutoSlide As Boolean = True

    Public Sub New()
        Images = New SlideCollection
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.PreRender

        btns.Style.Add("position", "absolute")
        btns.Style.Add("bottom", "10px")
        btns.Style.Add("right", "10px")

        Dim pth = Server.MapPath(ImageFolder)
        Dim di = New DirectoryInfo(pth)

        Dim fis = di.GetFiles

        pnlSlider.Attributes.Add("onmouseover", "SetSlider(false);")
        pnlSlider.Attributes.Add("onmouseout", "SetSlider(true);")

        For n As Integer = 0 To Images.Items.Count - 1
            If n = 0 Then
                pnlSlider.BackImageUrl = Images.Items(n).ImageUrl
                lnk.NavigateUrl = Images.Items(n).NavigateUrl
                lnk.Target = Images.Items(n).Target
            End If


            Dim btn = New HtmlImage
            btn.ID = "SliderBtn_" & n
            btn.ClientIDMode = UI.ClientIDMode.Static
            btn.Attributes.Add("Index", n)
            btn.Attributes.Add("RelatedImage", Images.Items(n).ImageUrl)
            btn.Attributes.Add("onclick", "SliderChange(this,'" & Images.Items(n).NavigateUrl & "','" & Images.Items(n).Target & "','" & OffButton & "','" & OnButton & "');")
            btn.Style.Add("cursor", "pointer")
            If n = 0 Then
                btn.Src = OnButton
            Else
                btn.Src = OffButton
            End If
            btns.Controls.Add(btn)


            AjaxControlToolkit.ToolkitScriptManager.RegisterStartupScript(Me, Me.GetType, Me.ID, "try{SliderInit('" & pnlSlider.ClientID & "');} catch(e){}", True)
        Next

    End Sub

    <Bindable(True), Browsable(True), PersistenceMode(PersistenceMode.InnerProperty)> Public Property OnButton As String
    <Bindable(True), Browsable(True), PersistenceMode(PersistenceMode.InnerProperty)> Public Property OffButton As String
    <Bindable(True), Browsable(True), PersistenceMode(PersistenceMode.InnerProperty)> Public Property Images As SlideCollection

    Public Sub AddImage(ImageUrl As String, NavigateUrl As String, Target As String)
        Dim i = New ImageSliderImage
        i.ImageUrl = ImageUrl
        i.NavigateUrl = NavigateUrl
        i.Target = Target
        Images.Items.Add(i)
    End Sub

    Protected Overrides Sub Render(writer As System.Web.UI.HtmlTextWriter)
        MyBase.Render(writer)
    End Sub
End Class

<ParseChildren(True), PersistChildren(True)>
Public Class SlideCollection
    Inherits System.Web.UI.UserControl

    Public Property Items As ObjectModel.Collection(Of ImageSliderImage)


    Public Sub New()
        Items = New ObjectModel.Collection(Of ImageSliderImage)
    End Sub

    <Bindable(True), Browsable(True), PersistenceMode(PersistenceMode.InnerProperty)> Public WriteOnly Property Add As ImageSliderImage
        Set(value As ImageSliderImage)
            Items.Add(value)
        End Set
    End Property

End Class

Public Class ImageSliderImage

    Public Sub New()

    End Sub

    <Bindable(True), Browsable(True), PersistenceMode(PersistenceMode.Attribute)> Public Property ImageUrl As String
    <Bindable(True), Browsable(True), PersistenceMode(PersistenceMode.Attribute)> Public Property NavigateUrl As String
    <Bindable(True), Browsable(True), PersistenceMode(PersistenceMode.Attribute)> Public Property Target As String = "_SELF"

End Class
