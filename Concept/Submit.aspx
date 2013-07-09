<%@ Page Title="Submit A Design" Language="VB" MasterPageFile="~/MasterPages/Concept.master" AutoEventWireup="false" CodeFile="Submit.aspx.vb" Inherits="Concept_Submit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubNavigationContainer" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentContainer" Runat="Server">
    <h1>Submit a Design</h1>
    <div style="border-top:1px dashed #000000;padding:10px 0px;min-height:700px;">
        <asp:HiddenField ID="Img1" runat="server" Value="" />
        <asp:HiddenField ID="Img2" runat="server" Value="" />
        <asp:HiddenField ID="Img3" runat="server" Value="" />
        <asp:HiddenField ID="Img4" runat="server" Value="" />
        <asp:HiddenField ID="Img5" runat="server" Value="" />
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td width="590" valign="top">
                    <div style="width:560px;">
                        <h2>Name your product design</h2>
                        You need to provide the name of the product (if you have one) or a simple description of it such as "Puppy House" so that people immediately understand its purpose
                        <br /><br />
                        My product is called: <asp:TextBox ID="txtName" runat="server" Width="250" MaxLength="40" ></asp:TextBox> max 40 characters
                        <br /><br />

                        <h2>Describe your product</h2>
                        This is where you explain the product, what it does, how it works, what it might be made of and the sort of animals it suits.
                        Enter your description below<br />
                        <asp:TextBox ID="txtDescription" runat="server" Width="500" Height="120" TextMode="MultiLine" MaxLength="1500" onkeydown="return LimitText(this,1500,'counter');"></asp:TextBox>
                        <div id="counter">1500 Characters Max</div>
                        <br /><br />
                        <div style="display:inline-block;width:300px;">
                            If you have an estimated retail price in mind, enter it here in UK pounds, this is optional
                        </div>
                        &pound; <asp:TextBox ID="txtEstPrice" Width="50" runat="server"></asp:TextBox>
                        <br /><br />

                        <h2>This product is designed for...</h2>
                        <div class="ConceptSubmitSetType">
                            <asp:CheckBox ID="cbxC" runat="server" Text="Cats" />
                            <asp:CheckBox ID="cbxD" runat="server" Text="Dogs" />
                            <asp:CheckBox ID="cbxS" runat="server" Text="Small" />
                            <asp:CheckBox ID="cbxO" runat="server" Text="Other" />
                        </div>
                        <br /><br />

                        <h2>Acceptance of designs</h2>
                        When you submit a design it will not appear on the website until our team has approved it.<br />
                        This is to prevent material that is unsuitable for the website
                        <br /><br />
                        You will receive an email confirming that we have received your design.<br />
                        We aim to review all submitted designs within 48 hours of submission. 
                        <br /><br />
                        By clicking <b>"Accept and Save"</b> i confirm that i have read and understood the <a href="/SubmissionTerms">terms of submission</a>
                        <br /><br />

                        <asp:button ID="btnSave" runat="server" Text="Accept and Save"></asp:button>
                        <asp:Label ID="lblResponse" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                    </div>
                </td>
                <td width="340" valign="top">
                    <div style="position:relative;right:0px;">
                        <h2>Product pictures or drawings</h2>
                        You must load at least one picture of your product. 
                        The first image you upload will be the one people see first so that should be the best one you have. 
                        You can upload upto 4 additional images in addition to the first one
                        <br /><br />
                        The site layout means that landscape images will work best.
                        <br /><br />
                        <div style="margin-bottom:10px;height:75px;">
                            <asp:Image ID="Image1" runat="server" Width="100" Height="75" style="float:right;margin-left:10px;border:1px solid #545454;" />
                            <b>Main Picture</b>
                            <uc:SkinnedUpload ID="UpMain" runat="server" />
                        </div>
                        <div style="margin-bottom:10px;height:75px;">
                            <asp:Image ID="Image2" runat="server" Width="100" Height="75" style="float:right;margin-left:10px;border:1px solid #545454;" />
                            <b>2nd Picture</b>
                            <uc:SkinnedUpload ID="SkinnedUpload1" runat="server" />
                        </div>
                        <div style="margin-bottom:10px;height:75px;">
                            <asp:Image ID="Image3" runat="server" Width="100" Height="75" style="float:right;margin-left:10px;border:1px solid #545454;" />
                            <b>3rd Picture</b>
                            <uc:SkinnedUpload ID="SkinnedUpload2" runat="server" />
                        </div>
                        <div style="margin-bottom:10px;height:75px;">
                            <asp:Image ID="Image4" runat="server" Width="100" Height="75" style="float:right;margin-left:10px;border:1px solid #545454;" />
                            <b>4th Picture</b>
                            <uc:SkinnedUpload ID="SkinnedUpload3" runat="server" />
                        </div>
                        <div style="margin-bottom:10px;height:75px;">
                            <asp:Image ID="Image5" runat="server" Width="100" Height="75" style="float:right;margin-left:10px;border:1px solid #545454;" />
                            <b>5th Picture</b>
                            <uc:SkinnedUpload ID="SkinnedUpload4" runat="server" />
                        </div>
                    <!-- PAGE CONTENT HERE -->
        
                    </div>
                </td>
            </tr>
        </table>
    </div> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

