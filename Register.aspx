<%@ Page Title="Member Login" Language="VB" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="login" %>

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
                    <td rowspan="4" valign="top" style="padding-right:80px">
                        <h3 style="padding:0px;margin:0px 0px 5px 0px;">Registration</h3>
                        <span style="line-height:normal;">You will need to register with us in order to <strong>vote, post comments or submit a pet furniture design</strong>.  As soon as you have registered you can do all of these and it only takes a few seconds to complete the registration.</span>
                    </td>
                    <td><b>Name</b></td>
                    <td><asp:TextBox ID="txtVoterName" runat="server" Width="200" onkeypress="checkEnter(event);"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><b>Email</b></td>
                    <td><asp:TextBox ID="txtVoterEmail" runat="server" Width="200"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><b>Password</b></td>
                    <td><asp:TextBox ID="txtVoterPassword" TextMode="Password" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Label ID="lblVoterResponse" CssClass="ResponseLabel" runat="server"></asp:Label>
                        <asp:Button ID="btnVoterRegister" runat="server" Text="Register" />
                    </td>
                </tr>

                <tr>
                    <td colspan="3">
                        <div style="border-top:1px dashed #000000;margin:30px 0px;"></div> 
                    </td>
                </tr>

                <tr>
                    <td colspan="3">
                        <p>By registering with Pet Dream House you accept the terms of our Privacy Policy which can be in full accessed by <a href="/Privacy.aspx">clicking here</a>.  The summary of which is that we may contact you with news about our products but you can opt out of future emails.  If you submit designs we may need to contact you about them for the duration of the time the are visible on the website prior to us entering into a separate agreement about proptypes or production.</p>
                        <p>
                        <span style="font-family:adelle, arial;font-size:18px;color:#333333;">
                    Please get in touch with us if you have any questions ...
                </span> 
                	<br /><br />
                        <a href="/about.aspx"><img src="/App/Images/signature.png" /></a></p>
                        
                    </td>
                </tr>
            </table>
			</h3></h3></h3>

        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

