<%@ Page Title="Frequently Asked Questions" Language="VB" MasterPageFile="~/MasterPages/about.master" AutoEventWireup="false" CodeFile="Press.aspx.vb" Inherits="faq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubNavigationContainer" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentContainer" Runat="Server">
    <h1>press coverage</h1>
    <div style="border-top:1px dashed #000000;padding:10px 0px;min-height:700px;">
        <uc:RightBlocks AdvertIDs="8,5,11" ID="Ads" runat="server"  style="float:right" />

        <asp:Table ID="tblFaq" Width="680" CellSpacing="0" CellPadding="0" runat="server" CssClass="PressTable">
        </asp:Table>
        
       
        

    </div> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

