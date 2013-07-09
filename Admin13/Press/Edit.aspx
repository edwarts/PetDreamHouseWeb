<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/AdminPress.master" AutoEventWireup="false" CodeFile="Edit.aspx.vb" Inherits="Admin13_Faq_Edit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubContentBody" Runat="Server">
        <asp:HiddenField ID="hdnFaqID" Value="0" runat="server" />

        <div class="ProductEditor" style="padding:15px;">
            <h3 id="h3Title" runat="server">Add Press Entry</h3>
            <br />

                <b>Title</b>
                <asp:TextBox ID="txtTitle" Width="600" runat="server"></asp:TextBox>
                <br /><br />

                <b>Date</b>
                <asp:TextBox ID="txtDate" Width="120" runat="server"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" TodaysDateFormat="dd MMMM yyyy" Format="dd MMMM yyyy">
            </asp:CalendarExtender>
                <br /><br />
                                            
                <b>Description</b>
                <asp:TextBox ID="txtDescription" Width="600" TextMode="MultiLine" Rows="8" runat="server"></asp:TextBox>
                <br /><br />

                <b>Link</b>
                <asp:TextBox ID="txtLink" Width="600" runat="server"></asp:TextBox>
                <br /><br />


            <div style="text-align:right;margin:5px 0px;">
                <asp:Label ID="lblResponse" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                <asp:Button ID="btnSave" runat="server" Text="Save" />
            </div>

        </div>

</asp:Content>

