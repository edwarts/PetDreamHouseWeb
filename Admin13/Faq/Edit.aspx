<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/AdminFaq.master" AutoEventWireup="false" CodeFile="Edit.aspx.vb" Inherits="Admin13_Faq_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubContentBody" Runat="Server">
        <asp:HiddenField ID="hdnFaqID" Value="0" runat="server" />

        <div class="ProductEditor" style="padding:15px;">
            <h3 id="h3Title" runat="server">Add Frequently Asked Question</h3>
            <br />
                <b>Category</b>
                <asp:DropDownList id="ddlCategory" runat="server">
                    <asp:ListItem Value="customer" Text="Customer"></asp:ListItem>
                    <asp:ListItem Value="designer" Text="Designer"></asp:ListItem>
                </asp:DropDownList>
                <br /><br />
                            
                <b>Question</b>
                <asp:TextBox ID="txtQuestion" Width="600" TextMode="MultiLine" Rows="8" runat="server"></asp:TextBox>
                <br /><br />

                <b>Answer</b>
                <asp:TextBox ID="txtAnswer" Width="600" TextMode="MultiLine" Rows="8" runat="server"></asp:TextBox>
                <br /><br />

            <div style="text-align:right;margin:5px 0px;">
                <asp:Label ID="lblResponse" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                <asp:Button ID="btnSave" runat="server" Text="Save" />
            </div>

        </div>

</asp:Content>

