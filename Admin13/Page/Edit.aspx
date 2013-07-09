<%@ Page Title="Edit Page" Language="VB" MasterPageFile="~/MasterPages/AdminPage.master" AutoEventWireup="false" CodeFile="Edit.aspx.vb" Inherits="Admin13_Page_Edit" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubContentBody" Runat="Server">
    <div style="padding:20px;position:relative;">
        <h3 id="h3PageName" runat="server">Page Editor</h3>
        <br />
        <asp:UpdatePanel ID="UPD" runat="server">
            <ContentTemplate>
                <div style="position:absolute;top:20px;right:40px;text-align:right;">
                    <asp:Label ID="lblSaveDetailResponse" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                    <asp:Button ID="btnSaveDetails" runat="server" Text="Save Details" />
                </div>
                <asp:TabContainer ID="TabContainer1" runat="server" CssClass="Tabs">
                    <asp:TabPanel ID="TabDetails" HeaderText="Details" runat="server">
                        <ContentTemplate>
                            <div style="padding:20px;">
                                <b style="display:inline-block;width:120px;">
                                Page Heading
                                </b>
                                <asp:TextBox ID="txtHeading" runat="server" Width="400"></asp:TextBox>
                                <br /><br />
                                
                                <b style="display:inline-block;width:120px;">
                                Page Subtitle
                                </b>
                                <asp:TextBox ID="txtSubTitle" runat="server" Width="500"></asp:TextBox>
                                <br /><br />

                                <CKEditor:CKEditorControl ID="txtBody" runat="server"></CKEditor:CKEditorControl>
                                <br /><br />

                                <b style="display:inline-block;width:120px;">
                                Page Meta Title
                                </b>
                                <asp:TextBox ID="txtPageTitle" runat="server" Width="400"></asp:TextBox>
                                <br /><br />

                                <b style="display:inline-block;width:120px;vertical-align:top;">
                                Meta Keywords
                                </b>
                                <asp:TextBox ID="txtMetaKeys" TextMode="MultiLine" Rows="3" runat="server" Width="600"></asp:TextBox>
                                <br /><br />

                                <b style="display:inline-block;width:120px; vertical-align:top;">
                                Meta Description
                                </b>
                                <asp:TextBox ID="txtMetaDesc" TextMode="MultiLine" Rows="3" runat="server" Width="600"></asp:TextBox>
                                <br /><br />

                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                 
                    <asp:TabPanel ID="TabHeaderImage" HeaderText="Header Image" runat="server">
                        <ContentTemplate>
                            <div style="padding:20px;width:805px;">
                                <div style="width:800px;display:inline-block;vertical-align:top;">
                                    <h3>Header Image</h3>
                                    <br />
                                    <asp:Panel ID="pnlHeaderImage" runat="server">
                                        <div style="display:inline-block;width:190px;">
                                            <asp:DropDownList ID="ddlHeaderImage" runat="server"></asp:DropDownList><br />
                                            <asp:Image ID="imgHeaderImage" Runat="server" style="margin:5px 0px;" />
                                        </div>
                            
                                    </asp:Panel>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>

                    <asp:TabPanel ID="TabAdvertsF" HeaderText="Footer Advertisements" runat="server">
                        <ContentTemplate>
                            <div style="padding:20px;width:805px;">
                                <div style="width:800px;display:inline-block;vertical-align:top;">
                                    <h3>Footer Advertisements</h3>
                                    <br />
                                    <asp:Panel ID="pnlFooterBlocks" runat="server">
                                        <div style="display:inline-block;width:190px;">
                                            <asp:DropDownList ID="ddlFB1" runat="server"></asp:DropDownList><br />
                                            <asp:Image ID="imgFB1" Runat="server" style="margin:5px 0px;" />
                                        </div>

                                        <div style="display:inline-block;width:190px;">
                                            <asp:DropDownList ID="ddlFB2" runat="server"></asp:DropDownList><br />
                                            <asp:Image ID="imgFB2" Runat="server" />
                                        </div>

                                        

                                        <div style="display:inline-block;width:190px;">
                                            <asp:DropDownList ID="ddlFB3" runat="server"></asp:DropDownList><br />
                                            <asp:Image ID="imgFB3" Runat="server" />
                                        </div>
                                        

                                        <div style="display:inline-block;width:190px;">
                                            <asp:DropDownList ID="ddlFB4" runat="server"></asp:DropDownList><br />
                                            <asp:Image ID="imgFB4" Runat="server" />
                                        </div>
                                        
                                    </asp:Panel>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>

                    <asp:TabPanel ID="TabAdvertsS" HeaderText="Side Advertisements" runat="server">
                        <ContentTemplate>
                            <div style="padding:20px;width:805px;">
                                <div style="width:800px;display:inline-block;vertical-align:top;">
                                    <h3>Side Advertisements</h3>
                                    <br />
                                    <asp:Panel ID="pnlSideAdverts" runat="server">
                                        <div style="display:block; vertical-align:top;">
                                            <asp:DropDownList ID="ddlSD1" runat="server"></asp:DropDownList>
                                            <asp:Image ID="imgSD1" Runat="server" style="margin:5px 0px;" />
                                            <asp:HyperLink ID="lnkSD1" runat="server" style="display:inline-block;padding:15px 10px;vertical-align:top;" />
                                        </div>

                                        <div style="display:block; vertical-align:top;">
                                            <asp:DropDownList ID="ddlSD2" runat="server"></asp:DropDownList>
                                            <asp:Image ID="imgSD2" Runat="server" />
                                            <asp:HyperLink ID="lnkSD2" runat="server" style="display:inline-block;margin:15px 0px;vertical-align:top;" />
                                        </div>

                                        

                                        <div style="display:block; vertical-align:top;">
                                            <asp:DropDownList ID="ddlSD3" runat="server"></asp:DropDownList>
                                            <asp:Image ID="imgSD3" Runat="server" />
                                            <asp:HyperLink ID="lnkSD3" runat="server" style="display:inline-block;margin:15px 0px;vertical-align:top;" />
                                        </div>
                                        

                                        <div style="display:block; vertical-align:top;">
                                            <asp:DropDownList ID="ddlSD4" runat="server"></asp:DropDownList>
                                            <asp:Image ID="imgSD4" Runat="server" />
                                            <asp:HyperLink ID="lnkSD4" runat="server" style="display:inline-block;margin:15px 0px;vertical-align:top;" />
                                        </div>
                                        
                                        <div style="display:block; vertical-align:top;">
                                            <asp:DropDownList ID="ddlSD5" runat="server"></asp:DropDownList>
                                            <asp:Image ID="imgSD5" Runat="server" />
                                            <asp:HyperLink ID="lnkSD5" runat="server" style="display:inline-block;margin:15px 0px;vertical-align:top;" />
                                        </div>
                                        
                                    </asp:Panel>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>

            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    <script type="text/javascript">
    </script>
</asp:Content>

