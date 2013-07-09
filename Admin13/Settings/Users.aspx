<%@ Page Title="User Management" Language="VB" MasterPageFile="~/MasterPages/AdminSettings.master" AutoEventWireup="false" CodeFile="Users.aspx.vb" Inherits="Admin13_Settings_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubContentBody" Runat="Server">
    <div style="padding:10px;">
        <asp:HyperLink ID="lnkNewUser" runat="server" NavigateUrl="/Admin13/Settings/Users/Add">Add New User</asp:HyperLink>
        <asp:DropDownList ID="ddlSortField" runat="server" AutoPostBack="true">
            <asp:ListItem Selected="True" Value="UsrCreated" Text="Created"></asp:ListItem>
            <asp:ListItem Value="UsrName" Text="Name"></asp:ListItem>
            <asp:ListItem Value="UsrEmailAddress" Text="Email Address"></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlSortDir" runat="server" AutoPostBack="true">
            <asp:ListItem Value="ASC" Text="Ascending"></asp:ListItem>
            <asp:ListItem Selected="True" Value="DESC" Text="Descending"></asp:ListItem>
        </asp:DropDownList>
        <br /><br />
        
        <asp:Table ID="tbl" Width="100%" runat="server" CssClass="SkinnedTable" CellSpacing="0"></asp:Table>

    </div>
</asp:Content>

