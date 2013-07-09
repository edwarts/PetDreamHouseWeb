<%@ Page Title="Administrator Management" Language="VB" MasterPageFile="~/MasterPages/AdminSettings.master" AutoEventWireup="false" CodeFile="Admins.aspx.vb" Inherits="Admin13_Settings_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubContentBody" Runat="Server">
    <div style="padding:10px;">
        <asp:HyperLink ID="lnkNewAdmin" runat="server" NavigateUrl="/Admin13/Settings/Admins/Add">Add New Administrator</asp:HyperLink>
        <br /><br />
        <asp:Table ID="tbl" Width="100%" runat="server" CssClass="SkinnedTable" CellSpacing="0"></asp:Table>

    </div>
</asp:Content>

