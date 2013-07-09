<%@ Page Title="Shopping Basket" Language="VB" MasterPageFile="~/MasterPages/Store.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Basket_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubNavigationContainer" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentContainer" Runat="Server">
    <h1>Shopping Basket</h1>
    <div style="border-top:1px dashed #000000;padding:10px 0px;min-height:700px;">
    <uc:RightBlocks AdvertIDs="29" ID="Ads" runat="server"  style="float:right" />
        <!-- <div style="float:right;width:200px;">
            <h2>Basket Summary</h2>
            <div style="border-top:1px dashed #000000;"></div>
            <b style="display:inline-block;width:100px;margin-bottom:15px;">Basket Items</b>
            <asp:label ID="lblBasketItems" runat="server" style="display:inline-block;width:95px;text-align:center;" ></asp:label>

            <b id="ttt" runat="server" style="display:inline-block;width:100px;margin-bottom:15px;">Total Items</b>
            <asp:label ID="lblTotalItems" runat="server" style="display:inline-block;width:95px;text-align:center;" ></asp:label>

            <b style="display:inline-block;width:100px;margin-bottom:15px;">Total Price</b>
            <asp:label ID="lblTotalCost" runat="server" style="display:inline-block;width:95px;text-align:center;"></asp:label>

            <asp:Button ID="btnBuy" runat="server" Text="Buy Now" Width="200" />
            
        </div> -->
        <h3>Your Current Basket</h3>
        <asp:Table ID="tblBasket" CssClass="BasketTable" runat="server" Width="650" CellPadding="0" CellSpacing="0"></asp:Table>

        <asp:Panel ID="pnlNoItems" runat="server" Width="650" CssClass="WarningLabel">
            <h3 style="color:#ffffff">You have nothing in your shopping basket or your basket has expired.</h3>
        </asp:Panel>

        <div id="divDiscounts" runat="server" style="text-align:right;width:650px;margin-top:20px;">
            <h3>Enter a discount or promotional code</h3>
            <asp:TextBox ID="txtPromo" runat="server" Width="150"></asp:TextBox>
            <asp:Button ID="btnSetPromo" runat="server" Text="Apply" />
        </div>
        
        <asp:Panel ID="pnlDiscount" runat="server" Width="650" Visible="false" HorizontalAlign="Right" >
            <br />
            <h3 runat="server" id="lblDiscount"></h3>
            <h5 runat="server" id="lblDiscountType"></h5>
        </asp:Panel> 

        <div style="text-align:right;width:650px;margin-top:20px;">
            <asp:Button ID="btnBuy2" runat="server" Text="Pay Now" />
        </div> 
            <awc:EasyPaypal ID="PP1" Command="_cart" runat="server">
            </awc:EasyPaypal>
            
            <h3 style="margin-top:30px">Secure Payment by PayPal</h3>
            <p>You <strong>do not</strong> need a PayPal account to make a payment, you can make a one-off payment by Debit Card or Credit Card</p>
            <p>When you press Pay Now you will be directed to PayPal for the secure payment process and returned here once the payment is complete.</p>
            
    </div>    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

