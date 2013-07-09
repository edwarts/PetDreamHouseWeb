<%@ Page Title="Edit Administrator" Language="VB" MasterPageFile="~/MasterPages/AdminSettings.master" AutoEventWireup="false" CodeFile="EditAdmin.aspx.vb" Inherits="Admin13_Settings_EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubContentBody" Runat="Server">
    <asp:HiddenField ID="hdnUserID" Value="0" runat="server" />
    <div style="padding:10px;">
        <h3 id="h3Title" runat="server">Add Administrator</h3>
        <br />
        <div class="ProductEditor" style="padding:15px;">
            <b>Name</b>
            <asp:TextBox ID="txtName" Width="300" runat="server"></asp:TextBox>
            <br /><br />

            <b>Email Address</b>
            <asp:TextBox ID="txtEmail" Width="300" runat="server"></asp:TextBox>
            <br /><br />

            <b>Password</b>
            <asp:TextBox ID="txtPassword" Width="150" runat="server"></asp:TextBox>
            <i>leave blank if no change</i>
            <br /><br />

            <asp:Button ID="btnSave" runat="server" Text="Save" />
            <asp:Label ID="lblResponse" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
        </div>
    </div>

</asp:Content>

