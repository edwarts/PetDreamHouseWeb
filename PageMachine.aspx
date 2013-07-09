<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/About.master" AutoEventWireup="false" CodeFile="PageMachine.aspx.vb" Inherits="Store_About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubNavigationContainer" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentContainer" Runat="Server">
        <asp:Image ID="HeaderImage" runat="server" style="" />
    <h1 class="PageHeading" id="PagHeading" runat="server"><!-- Fed from DB --></h1>
    <div id="mainDiv" runat="server" style="border-top:1px dashed #000000;padding:10px 0px;min-height:700px;">
        <uc:RightBlocks AdvertIDs="8,6,1" ID="Ads" runat="server"  style="float:right" />

        
    <div style="width:650px;">
        <!-- <h2 class="StandardText" id="PagTitle" runat="server">THIS DOES NOT SEEM NEEDED</h2> -->
        
        <h2 id="PagSubTitle" runat="server"><!-- Fed from DB --></h2>
        <div id="PagBody" runat="server">
            <!-- Fed from DB -->
        </div>
	</div>
    <uc:FooterBlocks ID="FB1" runat="server" CssClass="FooterBlocks" />
    </div> 

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

