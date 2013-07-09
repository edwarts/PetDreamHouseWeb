<%@ Page Title="Contact Us" Language="VB" MasterPageFile="~/MasterPages/About.master" AutoEventWireup="false" CodeFile="Contact.aspx.vb" Inherits="Contact_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubNavigationContainer" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentContainer" Runat="Server">
    <h1 class="PageHeading" id="PagHeading" runat="server">Contact Pet Dream House</h1>
    <div style="border-top:1px dashed #000000;padding:10px 0px;min-height:700px;">
        <div style="float:right;">
            <uc:RightContact ID="ContactForm1" style="" runat="server" />
            <uc:RightBlocks AdvertIDs="8" ID="Ads" runat="server" />
        </div>
        <div style="width:650px;">
      
        <div id="PagBody" runat="server">
        </div>

    </div> 
	<uc:FooterBlocks ID="FB1" runat="server" CssClass="FooterBlocks" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

