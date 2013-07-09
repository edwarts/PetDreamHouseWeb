<%@ Page Title="Edit Concept" Language="VB" MasterPageFile="~/MasterPages/AdminConcepts.master" AutoEventWireup="false" CodeFile="Edit.aspx.vb" Inherits="Admin13_Concepts_Edit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubContentBody" Runat="Server">
    <asp:HiddenField ID="hdnConceptID" Value="0" runat="server" />
    <div style="padding:10px;">
        <h3 id="h3Title" runat="server">Add New Concept</h3>
        <br />
        <asp:TabContainer ID="TabContainer1" runat="server" CssClass="Tabs">
            <asp:TabPanel ID="tabDetails" runat="server" HeaderText="Details">
                <ContentTemplate>
                    <div class="ProductEditor" style="padding:15px;">

                            <b>Visibility</b>
                            <asp:DropDownList id="ddlVisibility" runat="server">
                                <asp:ListItem Value="0" Text="Hidden"></asp:ListItem>    
                                <asp:ListItem Value="1" Text="Visible"></asp:ListItem>    
                            </asp:DropDownList>
                            <br /><br />
                            
                            <b>Status</b>
                            <asp:DropDownList id="ddlStatus" runat="server"></asp:DropDownList>
                            <br /><br />
                            
                            <b>Name</b>
                            <asp:TextBox ID="txtFullName" Width="300" runat="server"></asp:TextBox>
                            <br /><br />

                            <b>Summary</b>
                            <asp:TextBox ID="txtSummary" Width="400" TextMode="MultiLine" Rows="8" runat="server"></asp:TextBox>
                            <br /><br />

                            <b>Estimated Price</b>
                            <asp:TextBox ID="txtEstPrice" Width="60" runat="server"></asp:TextBox>
                            <br /><br />

                            <b>Designer</b>
                            <asp:DropDownList id="ddlDesigner" runat="server"></asp:DropDownList>
                            <br /><br />

                            <b>Designer Website URL</b>
                            <asp:TextBox ID="txtDesignerUrl" Width="300" runat="server"></asp:TextBox> <i>(optional)</i>
                            <br /><br />
                            
                            <b>Submitted</b>
                            <asp:TextBox ID="txtSubmitted" readonly="true" Width="200" runat="server"></asp:TextBox>
                            <br /><br />

                            <b>Designed For</b>
                            <div class="AdminSubmitSetType">
                                <asp:CheckBox ID="cbxC" runat="server" Text="Cats" />
                                <asp:CheckBox ID="cbxD" runat="server" Text="Dogs" />
                                <asp:CheckBox ID="cbxS" runat="server" Text="Small" />
                                <asp:CheckBox ID="cbxO" runat="server" Text="Other" />
                            </div>
                            <br /><br />

                            <b>Meta Title</b>
                            <asp:TextBox ID="txtMetaTitle" Width="600" runat="server"></asp:TextBox>
                            <br /><br />

                            <b>Meta Description</b>
                            <asp:TextBox ID="txtMetaDesc" Width="600" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                            <br /><br />

                            <b>Meta Keywords</b>
                            <asp:TextBox ID="txtMetaKeywords" Width="600" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                            <br /><br />

                        <div style="text-align:right;margin:5px 0px;">
                            <asp:Label ID="lblDetailsResponse" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                            <asp:Button ID="btnSaveDetails" runat="server" Text="Save Details" />
                        </div>

                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            
            <asp:TabPanel ID="tabNote" runat="server" HeaderText="Notes">
                <ContentTemplate>
                    <div class="ProductEditor" style="padding:15px;">
                        <asp:TextBox ID="txtNotes" Width="800" TextMode="MultiLine" height="350" runat="server"></asp:TextBox>
                        <div style="text-align:right;margin:5px 0px;">
                            <asp:Label ID="lblNoteResponse" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                            <asp:Button ID="btnSaveNote" runat="server" Text="Save Note" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>

            <asp:TabPanel ID="tabImages" runat="server" HeaderText="Images">
                <ContentTemplate>
                    <div class="ProductEditor" style="padding:0px 15px 15px 15px;">
                        
                        <div style="text-align:left;padding:10px 0px;">
                            <asp:Button ID="btnSaveImages" runat="server" Text="Save Image Collection" />
                            <asp:Label ID="lblImagesResponse" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                        </div>
                        <div class="ConceptImagePanel">
                            <asp:HiddenField ID="hdnImg1" runat="server" Value="" />
                            <asp:Image ID="img1" runat="server" ImageUrl="/160x120/somepath/No-image.jpg" />
                            <strong>Main Image</strong>
                            <uc:SkinnedUpload ID="fl1" runat="server" />
                        </div>
                        
                        <div class="ConceptImagePanel">
                            <asp:HiddenField ID="hdnImg2" runat="server" Value="" />
                            <asp:Image ID="img2" runat="server" ImageUrl="/160x120/somepath/No-image.jpg" />
                            <strong>Second Image</strong>
                            <uc:SkinnedUpload ID="fl2" runat="server" />
                        </div>
                        
                        <div class="ConceptImagePanel">
                            <asp:HiddenField ID="hdnImg3" runat="server" Value="" />
                            <asp:Image ID="img3" runat="server" ImageUrl="/160x120/somepath/No-image.jpg" />
                            <strong>Third Image</strong>
                            <uc:SkinnedUpload ID="fl3" runat="server" />
                        </div>
                        
                        <div class="ConceptImagePanel">
                            <asp:HiddenField ID="hdnImg4" runat="server" Value="" />
                            <asp:Image ID="img4" runat="server" ImageUrl="/160x120/somepath/No-image.jpg" />
                            <strong>Fourth Image</strong>
                            <uc:SkinnedUpload ID="fl4" runat="server" />
                        </div>
                        
                        <div class="ConceptImagePanel">
                            <asp:HiddenField ID="hdnImg5" runat="server" Value="" />
                            <asp:Image ID="img5" runat="server" ImageUrl="/160x120/somepath/No-image.jpg" />
                            <strong>Fifth Image</strong>
                            <uc:SkinnedUpload ID="fl5" runat="server" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>


    </div>

</asp:Content>

