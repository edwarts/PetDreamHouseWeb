<%@ Page Title="Controlpanel Home" Language="VB" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Admin13_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <asp:panel ID="SubNav" CssClass="SubNav" runat="server">
        <asp:HyperLink ID="lnkList" runat="server" NavigateUrl="/Admin13/Products/" Text="Manage Products"></asp:HyperLink><!--
     --><asp:HyperLink ID="lnkAdd" runat="server" NavigateUrl="/Admin13/Concepts" Text="Manage Concepts"></asp:HyperLink><!--
     --><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="/Admin13/Cool" Text="Manage Cool Stuff"></asp:HyperLink><!--
     --><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="/Admin13/Settings" Text="System Settings"></asp:HyperLink>
    </asp:panel>

</asp:Content>

