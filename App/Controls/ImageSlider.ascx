<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ImageSlider.ascx.vb" Inherits="ImageSlider"  %>
        <asp:Panel ID="pnlSlider" runat="server" Width="950" Height="339" style="position:relative;">
        <asp:hyperlink ID="lnk" runat="server" NavigateUrl="http://www.google.com">
            <div id="SliderImgs" style="width:950px;height:339px;position:absolute;top:0px;left:0px;"></div>
        </asp:hyperlink>
        <asp:Panel ID="btns" runat="server" style="position:absolute;bottom:15px;right:15px;z-index:1001;"></asp:Panel>
        </asp:Panel>

