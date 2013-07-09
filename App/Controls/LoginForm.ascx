<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LoginForm.ascx.vb" Inherits="Controls_LoginRegister" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Button ID="btnSilentOpen" runat="server" style="display:none;" />
<asp:HiddenField ID="hdnConceptID" runat="server" Value="0" />
<asp:Panel ID="pnlTerminal" runat="server" Width="400" height="257" CssClass="Popup" style="display:none;border:none; background-color:transparent; background-image:url(/App/Images/LogonBG.png);">
    <asp:Image ID="imgClose" CssClass="PopupCloser" runat="server" ImageUrl="/App/images/icon/delete-icon.png" style="top:15px;right:15px;" />
    <div class="LoginForm">


        <div style="height:180px;padding:10px; margin-top:80px">
      
<h2>Please Login</h2>

            <b style="display:inline-block;width:100px;">Email Address</b>
            <asp:TextBox ID="txtPLEmail" runat="server" Width="200"></asp:TextBox>
            <br /><br />
                    
            <b style="display:inline-block;width:100px;">Password</b>
            <asp:TextBox ID="txtPLPassword" TextMode="Password" runat="server" Width="150"></asp:TextBox>
            <br /><br />
                    
            <asp:Hyperlink ID="lnkPublicRegister" runat="server" NavigateUrl="/Register" Text="Not Registered?" style="margin-right:30px;"></asp:HyperLink> 
            <asp:Hyperlink ID="lnkLostPass" runat="server" NavigateUrl="/LostPassword" Text="Forgotten Password?"></asp:HyperLink>
            <div class="PopupControls">
                <asp:Label ID="lblPLResponse" runat="server" ForeColor="Red"></asp:Label>
                <asp:Button ID="btnPublicLogin" runat="server" text="Login" />
            </div>
        </div>
    </div>
</asp:Panel>

<asp:ModalPopupExtender ID="ModalPopupExtender1" PopupControlID="pnlTerminal" runat="server" CancelControlID="imgClose" BackgroundCssClass="ModalBG" TargetControlID="btnSilentOpen">
</asp:ModalPopupExtender>
