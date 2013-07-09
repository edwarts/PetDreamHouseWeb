<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/Cool.master" AutoEventWireup="false" CodeFile="Submit.aspx.vb" Inherits="Cool_Submit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubNavigationContainer" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentContainer" Runat="Server">
<asp:UpdatePanel ID="UPD" runat="server">
<ContentTemplate>
    <img src="/App/Images/cool-stuff-top.png" />
    <h1 class="PageHeading" style="font-size:32px;">Submit Your Stuff</h1>
    <div style="border-top:1px dashed #000000;padding:10px 0px;min-height:700px;">
        <uc:RightBlocks AdvertIDs="8,6,1" ID="Ads" runat="server"  style="float:right" />
        
        <div style="width:650px;">
            <h2>See, Own or Like something? Then let us know and we'll feature it.</h2>
            If you've seen a product that you think other like-minded pet owners would enjoy, just let us 
            know the details below and we'll have a look.  If we agree with you and think it compliments 
            what we're doing then we'll feature it in our Cool Stuff Section.  
            <br /><br />
            You don't need to register.  Just tell us the details, send us a web link and explain why you
            like it. Don't send a picture, we'll visit the site and check those out in case anything is copyright.
            <br /><br />

            <div style="display:inline-block; vertical-align:top; width:340px;margin-bottom:20px;">
                Your Name (Required)<br />
                <asp:TextBox ID="txtYourName" runat="server" width="300"></asp:TextBox>
            </div>
            <div style="display:inline-block; vertical-align:top;">
                Your Email Address (Required)<br />
                <asp:TextBox ID="txtYourEmail" runat="server" width="300"></asp:TextBox>
            </div>
            
            <div style="display:inline-block; vertical-align:top; width:340px;margin-bottom:20px;">
                Name of Product<br />
                <asp:TextBox ID="txtProductName" runat="server" width="300"></asp:TextBox>
            </div>
            <div style="display:inline-block; vertical-align:top;">
                URL of Product ( <b>http://</b>www.nameofpage ... ) <br />
                <asp:TextBox ID="txtProductUrl" runat="server" width="300"></asp:TextBox>
            </div>

            <div style="display:inline-block; vertical-align:top; width:640px;margin-bottom:20px;">
                What is it? Describe the Product<br />
                <asp:TextBox ID="txtWhat" runat="server" TextMode="MultiLine" Height="100" width="640"></asp:TextBox>
            </div>

            <div style="display:inline-block; vertical-align:top; width:640px;margin-bottom:20px;">
                Why do you like it?<br />
                <asp:TextBox ID="txtWhy" runat="server" TextMode="MultiLine" Height="100" width="640"></asp:TextBox>
            </div>
            
            <h2>This product is designed for...</h2>
            <div class="ConceptSubmitSetType">
                <asp:CheckBox ID="cbxC" runat="server" Text="Cats" />
                <asp:CheckBox ID="cbxD" runat="server" Text="Dogs" />
                <asp:CheckBox ID="cbxS" runat="server" Text="Small" />
                <asp:CheckBox ID="cbxO" runat="server" Text="Other" />
            </div>
            <br /><br />

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
            <asp:Label ID="lblResponse" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
            <br /><br />
            Note that we will vet all submissions and reserve the right to amend or change any text you send.  
            We will not pass your details on to any third party.
        </div>
    </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

