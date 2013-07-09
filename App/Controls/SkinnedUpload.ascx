<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SkinnedUpload.ascx.vb" Inherits="App_Controls_SkinnedUpload" %>
<asp:panel ID="pnl" runat="server" style="display:inline-block;position:relative">
    <input type="text" id="nm" runat="server" style="width:220px;" /><br />
    <asp:Panel ID="UpBtn" runat="server" style="display:inline-block;position:relative;margin-top:4px;">
        <asp:FileUpload ID="FUP" runat="server" style="position:absolute;top:0px;left:0px;opacity:0;filter:alpha(opacity=0); z-index:1001;" />
        <input type="button" id="btn" runat="server" value="Browse" />
    </asp:Panel>
    <asp:Button ID="btnUpload" runat="server" Text="Upload" Width="66" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="66" />

</asp:panel>