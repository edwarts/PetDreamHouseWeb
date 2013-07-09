<%@ Page Title="Frequently Asked Questions" Language="VB" MasterPageFile="~/MasterPages/about.master" AutoEventWireup="false" CodeFile="faq.aspx.vb" Inherits="faq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubNavigationContainer" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentContainer" Runat="Server">
    <h1>help/faqs</h1>
    <div style="border-top:1px dashed #000000;padding:10px 0px;min-height:700px;">
        <uc:RightBlocks AdvertIDs="8,5,11" ID="Ads" runat="server"  style="float:right" />
        <div class="FaqFilterLinks">
        	<img src="/App/Images/Body/Header/Common/faq/faq-choose.png" />
            <asp:HyperLink ID="lnkShowAll" NavigateUrl="/Faq" runat="server" ImageUrl="/App/images/Body/Header/Common/faq/faq-all.png"></asp:HyperLink>
            <asp:HyperLink ID="lnkForDesigners" NavigateUrl="/Faq/Designer" runat="server" ImageUrl="/App/images/Body/Header/Common/faq/faq-designers.png"></asp:HyperLink>
            <asp:HyperLink ID="lnkForCustomers" NavigateUrl="/Faq/Customer" runat="server" ImageUrl="/App/images/Body/Header/Common/faq/faq-customers.png"></asp:HyperLink>
        </div>
        <asp:Table ID="tblFaq" Width="650" CellSpacing="0" CellPadding="0" runat="server" CssClass="FaqTable">
        </asp:Table>
        
       
        

    </div> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

