<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/About.master" AutoEventWireup="false" CodeFile="PageMachineWithLeft.aspx.vb" Inherits="Store_About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubNavigationContainer" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentContainer" Runat="Server">
        <asp:Image ID="HeaderImage" runat="server" style="" />
    
    <div id="mainDiv" runat="server" style="border-top:1px dashed #000000;padding:0px 0px;min-height:700px;">
        <table width="950" cellpadding="0" cellspacing="0" style="border-bottom:1px dashed #333333;margin-bottom:10px;">
            <tr>
                <td valign="top" style="padding:0px 20px 0px 0px"><uc:LeftBlocks ID="LinkBlocks1" runat="server" /></td>
                <td valign="top" style="padding:15px 23px 10px 3px; color:#474747;">
                    <div>
                        <!-- <h2 class="StandardText" id="PagTitle" runat="server">THIS DOES NOT SEEM NEEDED</h2> -->
        
                        <h2 id="PagHeading" runat="server"><!-- Fed from DB --></h2>
                        <div id="PagBody" runat="server">
                            <!-- Fed from DB -->
                        </div>
	                </div>
                </td>
                <td valign="top"><uc:RightBlocks AdvertIDs="13,4" ID="Ads" runat="server"  style="float:right" /></td>
            </tr>
        </table>
        <uc:FooterBlocks ID="FB1" runat="server" CssClass="FooterBlocks" />
        </div>
                 

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

