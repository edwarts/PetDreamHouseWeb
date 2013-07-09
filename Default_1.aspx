<%@ Page Title="Home :: PetDreamHouse.com" Language="VB" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubNavigationContainer" Runat="Server">
</asp:Content> 
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentContainer" Runat="Server">
    <uc:ImageSlider ID="Slider1" AutoSlide="True" Interval="2000" ImageFolder="/App/Images/Slider/" runat="server">
        <OnButton>/App/Images/Body/Slider_Button.png</OnButton>
        <OffButton>/App/Images/Body/Slider_Button-off.png</OffButton>
    </uc:ImageSlider>
    <table width="950" cellpadding="0" cellspacing="0" style="border-bottom:1px dashed #333333;margin-bottom:10px;">
        <tr>
            <td valign="top" width="240" class="HomeMenu">
                <asp:HyperLink ID="lnkHelpFaq" runat="server" NavigateUrl="/faq"><img src="/App/images/help-faq-button.png" /></asp:HyperLink>
                <asp:HyperLink ID="lnkDeliveryInformation" runat="server" NavigateUrl="/delivery"><img src="/App/images/delivery-button.png" /></asp:HyperLink>
                <asp:HyperLink ID="lnkContact" runat="server" NavigateUrl="/Contact"><img src="/App/images/contact-us-button.png" /></asp:HyperLink>
                <asp:HyperLink ID="lnkFeedback" runat="server" NavigateUrl="/feedback"><img src="/App/images/feedback-button.png" /></asp:HyperLink>
                <br />
                <img src="/App/Images/cat-dog.png" />

            </td>
            <td valign="top" style="padding:20px 25px 0px 25px; color:#474747;">
              	<h2 id="PagHeading" runat="server"></h2>
                <div id="PagBody" runat="server">
                
                </div>
              
            </td>
            <td valign="top" width="240" align="right">
                <uc:RightBlocks AdvertIDs="13,4" ID="Ads" runat="server"  style="float:right" />
            </td>
        </tr>
    </table>

    <uc:FooterBlocks ID="FB1" runat="server" CssClass="FooterBlocks" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

