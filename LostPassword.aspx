<%@ Page Title="Member Login" Language="VB" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="false" CodeFile="LostPassword.aspx.vb" Inherits="LostPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubNavigationContainer" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentContainer" Runat="Server">
    <h1>PetDreamHouse Login</h1>
    <div style="border-top:1px dashed #000000;padding:10px 0px;min-height:700px;">
        <div style="float:right;">
            <uc:RightBlocks AdvertIDs="8,2,4" ID="Ads" runat="server" />
        </div>
        <div style="width:650px;padding:20px 0px;">
            <table width="100%" style="line-height:28px;">
                <tr>
                    <td rowspan="2" valign="top" style="padding-right:40px">
                        <h2 style="padding:0px;margin:0px 0px 10px 0px;">Password Reset</h2>
                        <span style="line-height:normal;">Please enter your email address on the right and we'll send you a password reset key.</span>
                    </td>
                    <td><b>Email</b></td>
                    <td><asp:TextBox ID="txtLoginEmail" runat="server" Width="200"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Label ID="lblLoginResponse" CssClass="ResponseLabel" runat="server"></asp:Label>
                        <asp:Button ID="btnLogin" runat="server" Text="Reset" />
                    </td>
                </tr>
                
                <tr>
                    <td colspan="3">
                        <div style="border-top:1px dashed #000000;margin:30px 0px;"></div> 
                    </td>
                </tr>
                
                <tr id="tr1" runat="server" visible="false">
                    <td rowspan="3" valign="top" style="padding-right:80px">
                        <h2 style="padding:0px;margin:0px 0px 10px 0px;">Enter Key</h2>
                        <span style="line-height:normal;">Please check your inbox for your password reset key.</span>
                    </td>
                    <td><b>Reset Key</b></td>
                    <td><asp:TextBox ID="txtKey" runat="server" Width="200"></asp:TextBox></td>
                </tr>
                <tr id="tr2" runat="server" visible="false">
                    <td width="140"><b>Email Address</b></td>
                    <td><asp:TextBox ID="txtEmail" runat="server" Width="200"></asp:TextBox></td>
                </tr>
                <tr id="tr5" runat="server" visible="false">
                    <td width="140"><b>New Password</b></td>
                    <td><asp:TextBox ID="txtNewPassword" TextMode="Password" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <tr id="tr3" runat="server" visible="false">
                    <td colspan="2" align="right">
                        <asp:Label ID="lblPasswordSetResponse" CssClass="ResponseLabel" runat="server"></asp:Label>
                        <asp:Button ID="btnReset" runat="server" Text="Save" />
                    </td>
                </tr>

                <tr id="tr4" runat="server" visible="false">
                    <td colspan="3">
                        <div style="border-top:1px dashed #000000;margin:30px 0px;"></div> 
                    </td>
                </tr>
            </table>


        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

