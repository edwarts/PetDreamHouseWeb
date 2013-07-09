<%@ Control Language="VB" AutoEventWireup="false" CodeFile="RightContact.ascx.vb" Inherits="Controls_RightContact" %>
<asp:panel id="Blocks" runat="server">
    <div class="ContactForm">
        <h2>Send us your questions or your comments</h2>
        <span>Your name (Required)</span>
        <asp:TextBox ID="txtName" runat="server" Width="220"></asp:TextBox>
        <br /><br />

        <span>Your email address (Required)</span>
        <asp:TextBox ID="txtEmail" runat="server" Width="220"></asp:TextBox>
        <br /><br />

        <span>Telephone No.</span>
        <asp:TextBox ID="txtTelephone" runat="server" Width="220"></asp:TextBox>
        <br /><br />

        <span>How can we help you?</span>
        <asp:DropDownList ID="ddlType" runat="server" Width="222">
            <asp:ListItem Value="General Questions" Text="General Questions"></asp:ListItem>
            <asp:ListItem Value="Product Information" Text="Product Information"></asp:ListItem>
            <asp:ListItem Value="Delivery Queries" Text="Delivery Queries"></asp:ListItem>
            <asp:ListItem Value="Customer Complaints" Text="Customer Complaints"></asp:ListItem>
            <asp:ListItem Value="Submitting Designs" Text="Submitting Designs"></asp:ListItem>
        </asp:DropDownList>
        <br /><br />

        <span>Comments / Question (Required)</span>
        <asp:TextBox ID="txtComments" TextMode="MultiLine" Rows="8" runat="server" Width="220"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Form" /><br /><br />
        <asp:Label ID="lblResponse" ForeColor="Red" runat="server" style="display:inline-block;" ></asp:Label>
    </div>
</asp:panel>
