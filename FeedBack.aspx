<%@ Page Title="Customer Feedback" Language="VB" MasterPageFile="~/MasterPages/about.master" AutoEventWireup="false" CodeFile="FeedBack.aspx.vb" Inherits="FeedBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubNavigationContainer" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentContainer" Runat="Server">
    <h1>Feedback directly to Pet Dream House</h1>
    <div style="border-top:1px dashed #000000;padding:10px 0px;min-height:700px;">
        <uc:RightBlocks AdvertIDs="8,11,4" ID="Ads" runat="server"  style="float:right" />
        <div style="width:650px;">
        
            <h2>Tell us what you think, we'd love to hear from you</h2>
        
            <p>Complete the form below to help us improve what we do, how we work and the pet furniture we offer.  Your comments are only used internally by our team to help us understand how we can improve our pet furniture business.  We'd not publish anything without obtaining your explicit permission.</p>
        
            <div style="display:inline-block;width:230px;">
                <span>Your name (Required)</span><br />
                <asp:TextBox ID="txtName" runat="server" Width="225"></asp:TextBox>
            </div>

            <div style="display:inline-block;width:240px;margin-left:30px;">
                <span>Your email address (Required)</span><br />
                <asp:TextBox ID="txtEmail" runat="server" Width="225"></asp:TextBox>
            </div>
            <br /><br /><br />
        
            <span>Your feedback to us</span><br />
                <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine" height="200" Width="650"></asp:TextBox>
            <br /><br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Feedback" />
            <asp:Label ID="lblResponse" runat="server" style="display:inline-block;" />
        </div>
        
        <br /><br /><br /><br /><br /><br />
        <div style="height:160px;margin-bottom:20px;">
        	<a href="/Products"><img src="/App/Images/Cubes/our-store.png" width="235px" style="float:left; margin-left:0px" /></a>
    	    <a href="/Concept/howitworks"><img src="/App/Images/Cubes/design-uploads.png" width="235px" style="float:left; margin-left:2px" /></a>
    	    <a href="/Designer"><img src="/App/Images/Cubes/from-designer-to-you.png" width="235px" style="float:left; margin-left:2px" /></a>
     	    <a href="/Concept"><img src="/App/Images/Cubes/vote.png" width="235px" style="float:left; margin-left:2px" /></a>
    	</div>

    </div> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

