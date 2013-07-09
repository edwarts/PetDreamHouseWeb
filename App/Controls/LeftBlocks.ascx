<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LeftBlocks.ascx.vb" Inherits="Controls_LeftBlocks" %>
<asp:panel id="Blocks" runat="server">
    <asp:HyperLink ID="lnkFAQ" NavigateUrl="/faq.aspx" runat="server"><img src="/App/Images/faq.png" style="display:block;padding:10px 0px;" /></asp:HyperLink> 
    <asp:HyperLink ID="lnkVote" NavigateUrl="/concept" runat="server"><img src="/App/Images/vote-now.png" style="display:block;padding:10px 0px 0px 0px;" /></asp:HyperLink>
</asp:panel>
