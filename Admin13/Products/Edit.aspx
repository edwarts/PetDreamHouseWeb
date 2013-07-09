<%@ Page Title="Edit Product Details" Language="VB" MasterPageFile="~/MasterPages/AdminProducts.master" AutoEventWireup="false" CodeFile="Edit.aspx.vb" Inherits="Admin13_Products_Edit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubContentBody" Runat="Server">
    <asp:HiddenField ID="hdnProductID" Value="0" runat="server" />
    <div style="padding:10px;">
        <h3 id="h3Title" runat="server">Add New Product</h3>
        <br />
        <asp:TabContainer ID="TabContainer1" runat="server" CssClass="Tabs">
            <asp:TabPanel ID="tabDetails" runat="server" HeaderText="Details">
                <ContentTemplate>
                    <div class="ProductEditor" style="padding:15px;">
                
                            <b>Visibility</b>
                            <asp:DropDownList ID="ddlVisibility" runat="server">
                                <asp:ListItem Value="0" Text="Product Hidden"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Product Visible"></asp:ListItem>
                            </asp:DropDownList>
                            <br /><br />

                            <b>Full Name</b>
                            <asp:TextBox ID="txtFullName" Width="300" runat="server"></asp:TextBox>
                            <br /><br />

                            <b>Strap Line</b>
                            <asp:TextBox ID="txtStrapLine" Width="400" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
                            <br /><br />

                            <b>Summary</b>
                            <asp:TextBox ID="txtSummary" Width="400" TextMode="MultiLine" Rows="8" runat="server"></asp:TextBox>
                            <br /><br />

                            <b>Features</b>
                            <asp:TextBox ID="txtFeatures" Width="600" TextMode="MultiLine" Wrap="false" Rows="8" runat="server"></asp:TextBox>
                            <br /><br />

                            <b>Dimensions</b>
                            <asp:TextBox ID="txtDimensions" Width="600" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                            <br /><br />

                            <b>Price</b>
                            <asp:TextBox ID="txtPrice" Width="60" runat="server"></asp:TextBox>
                            <br /><br />

                            <b>Designer</b>
                            <asp:TextBox ID="txtDesigner" Width="300" runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="txtNotes" Width="800" TextMode="MultiLine" height="500" runat="server"></asp:TextBox>
                        <div style="text-align:right;margin:5px 0px;">
                            <asp:Label ID="lblNoteResponse" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                            <asp:Button ID="btnSaveNote" runat="server" Text="Save Note" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>

            <asp:TabPanel ID="tabOptions" runat="server" HeaderText="Options">
                <ContentTemplate>
                    <div class="ProductEditor" style="padding:15px;">
                        <div style="padding:5px 0px;">
                            <strong>Add Option</strong>
                            <asp:TextBox ID="txtNewOption" runat="server" Width="300"></asp:TextBox>
                            <asp:FileUpload ID="flNewOption" runat="server" />
                            <asp:Button ID="btnSaveNewOption" runat="server" Text="Add" />
                        </div>


                        <asp:Table ID="tblOptions" runat="server" CssClass="SkinnedTable" Width="100%" CellSpacing="0"></asp:Table>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            
            <asp:TabPanel ID="tabImages" runat="server" HeaderText="Images">
                <ContentTemplate>
                    <div class="ProductEditor" style="padding:0px 15px 15px 15px;">
                        <div style="padding:5px 0px 10px 0px;">
                            <uc:SimpleUpload ID="flPim" runat="server" />
                            <asp:Button ID="btnUploadPim" runat="server" Text="Upload" />
                             <asp:Label ID="lblPimUploadResponse" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                       </div>
                        <asp:Panel ID="pnlImages" runat="server">

                        </asp:Panel>
                        <div style="text-align:left;margin:5px 0px 10px 0px;">
                            <asp:Button ID="btnImageSave" runat="server" Text="Update Default Image" />
                            <asp:Label ID="lblImageResponse" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                        </div>
                   </div>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>

    
    
    
    </div>
</asp:Content>

