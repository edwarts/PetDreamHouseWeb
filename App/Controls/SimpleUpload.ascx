<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SimpleUpload.ascx.vb" Inherits="App_Controls_SimpleUpload" %>
<asp:panel ID="pnl" runat="server" style="display:inline-block;position:relative">
    <input type="text" id="nm" runat="server" style="width:220px;" />
    <asp:Panel ID="UpBtn" runat="server" style="display:inline-block;position:relative;margin-top:4px;">
        <asp:FileUpload ID="FUP" runat="server" style="position:absolute;top:0px;left:0px;opacity:0;filter:alpha(opacity=0); z-index:1001;" />
        <input type="button" id="btn" runat="server" value="Browse" />
    </asp:Panel>
</asp:panel>