<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CommentsPanel.ascx.vb" Inherits="App_Controls_CommentsPanel" %>

        <asp:UpdatePanel ID="UPD" runat="server">
            <ContentTemplate>
                <div id="mainDiv" runat="server" style="border-top:1px dashed #000000;padding:10px 0px;min-height:300px;">
            
                    <div style="display:inline-block; width:500px;vertical-align:top;margin-right:20px">
                        <h2 style="display:inline-block;">Add a Comment</h2> <b>(Registered users only)</b>
                        <br />
                        <p>If you are a registered user of PetDreamHouse.com you can add your comments on this item.</p>
                        <p>Please keep your comments constructive and we reserver the right to remove any that are inappropriate to the sites aim's and objectives when promoting items.</p>
                        <p>Your name will appear alongside your comment</p>
                        <asp:TextBox ID="txtComment" runat="server" Width="480" TextMode="MultiLine" Rows="10"></asp:TextBox><br />
                        <div style=" text-align:right;margin-top:5px;">
                            <asp:Label ID="lblResponse" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                            <asp:button ID="btnSubmitComment" runat="server" Text="Submit" Width="90" style="margin-right:15px;" />
                        </div>
                    </div>
                    <div style="display:inline-block; width:425px; vertical-align:top; max-height:500px;overflow:auto;">
                        <h2>Visitor Comments</h2>
                        <br />
                        <asp:Panel ID="pnlComments" runat="server" style="border-bottom:1px dashed #000000;">
                        
                        </asp:Panel>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
