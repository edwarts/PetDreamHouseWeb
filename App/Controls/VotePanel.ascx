<%@ Control Language="VB" AutoEventWireup="false" CodeFile="VotePanel.ascx.vb" Inherits="Controls_VotePanel" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Button ID="btnSilentOpen" runat="server" style="display:none;" />
<asp:HiddenField ID="hdnConceptID" runat="server" Value="0" />
<asp:Panel ID="pnlTerminal" runat="server" Width="400" Height="200" CssClass="Popup" style="display:none;">
    <asp:Image ID="imgClose" CssClass="PopupCloser" runat="server" ImageUrl="/App/images/icon/delete-icon.png" />
    <asp:label ID="lblTitle" CssClass="PopupTitle" runat="server" Text="Submit your Vote"></asp:label>
    <div style="padding:25px;position:relative;">
        <asp:Image ID="imgVote" runat="server" />
        
        <br />
        <br />
        <asp:TextBox ID="txtNewVote" Width="188" runat="server" onchange="UpdateSlider();"></asp:TextBox>
        <asp:Label ID="lblShowValue" runat="server" class="VoteValue"></asp:Label>
    </div> 
    <asp:SliderExtender ID="SliderExtender1" Length="188" BoundControlID="lblShowValue" BehaviorID="sliderBehavior" TargetControlID="txtNewVote" runat="server" Maximum="5" Decimals="1" Steps="11">
    </asp:SliderExtender>
    <div class="PopupControls">
        <asp:Label ID="lblResponse" runat="server" ForeColor="Red"></asp:Label>
        <asp:ImageButton ID="btnSaveVote" runat="server" CssClass="VoteButton" ImageUrl="/App/Images/submit-vote-button.png" />    
    </div>

    <script type="text/javascript">
        function pageLoad(sender, e) {
            var slider = $find('sliderBehavior');
            slider.add_valueChanged(UpdateSlider);
        }

        function UpdateSlider(sender, e) {
            var val = document.getElementById("<% =txtNewVote.ClientID %>").value;

            document.getElementById("<% =imgVote.ClientID %>").setAttribute("src", "/data/image/gen/starbar.aspx?v=" + val);

        }
    </script>
</asp:Panel>

<asp:ModalPopupExtender ID="ModalPopupExtender1" PopupControlID="pnlTerminal" runat="server" CancelControlID="imgClose" BackgroundCssClass="ModalBG" TargetControlID="btnSilentOpen">
</asp:ModalPopupExtender>
