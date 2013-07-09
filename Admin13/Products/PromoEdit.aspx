<%@ Page Title="Edit Promotion" Language="VB" MasterPageFile="~/MasterPages/AdminProducts.master" AutoEventWireup="false" CodeFile="PromoEdit.aspx.vb" Inherits="Admin13_Products_PromoEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubContentBody" Runat="Server">
<asp:HiddenField ID="hdnPromoID" Value="0" runat="server" />
    <div style="padding:10px;">
        <h3 id="h3Title" runat="server">Add New Promotion</h3>
        <br />
        <asp:TabContainer ID="TabContainer1" runat="server" CssClass="Tabs">
            <asp:TabPanel ID="tabDetails" runat="server" HeaderText="Details">
                <ContentTemplate>
                    <div class="ProductEditor" style="padding:15px;">
                
                            <b>Status</b>
                            <asp:DropDownList ID="ddlStatus" runat="server">
                                <asp:ListItem Value="0" Text="Disabled"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Enabled"></asp:ListItem>
                            </asp:DropDownList>
                            <br /><br />

                            <b>Description</b>
                            <asp:TextBox ID="txtDescription" Width="400" runat="server"></asp:TextBox>
                            <br /><br />

                            <b>Code</b>
                            <asp:TextBox ID="txtCode" Width="200" runat="server"></asp:TextBox>
                            <br /><br />

                            <b>Discount</b>
                            <asp:TextBox ID="txtDiscount" Width="80" runat="server" Text="0"></asp:TextBox>
                            <asp:DropDownList ID="ddlPromoType" runat="server">
                                <asp:ListItem Value="P" Text="Percent"></asp:ListItem>
                                <asp:ListItem Value="A" Text="Fixed Amount" Enabled="false"></asp:ListItem>
                            </asp:DropDownList>
                            <br /><br />

                            <b>Minimum Spend</b>
                            <asp:TextBox ID="txtMinSpend" Width="80" runat="server" Text="0.00"></asp:TextBox>
                            <br /><br />

                            <b>Start Date</b>
                            <asp:TextBox ID="txtStart" Width="120" runat="server"></asp:TextBox> <i>@ 00:00</i>
                            <br /><br />
                        <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtStart" runat="server" Format="d MMM yyyy" TodaysDateFormat="d MMM yyyy">
                        </asp:CalendarExtender>

                            <b>End Date</b>
                            <asp:TextBox ID="txtEnd" Width="120" runat="server"></asp:TextBox> <i>@ 23:59</i>
                            <br /><br />
                        <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtEnd" runat="server" Format="d MMM yyyy" TodaysDateFormat="d MMM yyyy">
                        </asp:CalendarExtender>

                        <div style="text-align:right;margin:5px 0px;">
                            <asp:Label ID="lblDetailsResponse" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                            <asp:Button ID="btnSaveDetails" runat="server" Text="Save Details" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>

        </asp:TabContainer>

    
    
    
    </div></asp:Content>

