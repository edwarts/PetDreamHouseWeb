<%@ Page Title="Product Page" Language="VB" MasterPageFile="~/MasterPages/Store.master" AutoEventWireup="false" CodeFile="Details.aspx.vb" Inherits="Store_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubNavigationContainer" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentContainer" Runat="Server">
    <img src="/App/Images/our-store-top.png" />
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td valign="top" style="width:410px;padding-right:30px; min-height:300px;">
                <div class="ProductText" style="">
                    <h2 id="hTitle" runat="server"></h2>
                    <h4 id="hTag" runat="server"></h4>
                    <h5 id="hDesigner" runat="server" class="Green">Features:</h5>
                    <h3>Price:</h3>
                    <span><h3 id="hPrice" runat="server" class="Price"></h3></span><span><h3 style="margin-left:20px;font-size:16px">Free UK Delivery</h3></span>
                   
                    <p id="pSummary" runat="server"></p>
                    <h5 class="Green">Features:</h5>
                    <div id="divFeatures" runat="server"></div>
                    <h5 class="Green">Dimensions:</h5>
                    <p id="pDimensions" runat="server"></p>
                    <br />
                   <!-- <b style="display:inline-block;width:100px;">Select Colour :</b> -->
                   <asp:DropDownList ID="ddlOption" runat="server" Width="250"></asp:DropDownList><br /><br />
                    <asp:ImageButton ID="imgAddToBasket" runat="server" ImageUrl="/App/Images/store-addtobasket.png" />
                    <asp:Hyperlink ID="lnkBasket" runat="server" ImageUrl="/App/Images/store-viewbasket.png" NavigateUrl="/Basket" />
                </div> 
            </td>
            <td valign="top">
                <div style="padding:0px 10px;color:#464646;position:relative;">
                    <table cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top">
                                <div style="width:450px;margin-left:0px;">
                                    <asp:Image ID="imgMain" Width="500" Height="375" runat="server" />
                                </div>
                                <!-- This is the thumbnail template -->
                                <asp:Image Width="93" Height="70" ID="imgThumbSample" runat="server" Visible="false" />
                                <!-- /This is the thumbnail template -->
                                <asp:Panel ID="pnlOtherImages" CssClass="ProductImages" runat="server">
                                </asp:Panel>
                                
                                <p style="padding-top:5px;">Available Colours:</p>
                                <asp:PlaceHolder ID="plcOptions" runat="server" />
 								
                                <div id="divFor" runat="server" class="SelectedAnimalTypes">
                                
                                </div>
                                
                                <hr />                               
                                <!-- Shares for Social Media -->
                                <div class="fb-like" data-send="false" data-layout="button_count" data-width="100" data-show-faces="false" data-font="arial" style="vertical-align:top"></div>
                                
                                <div class="twitter" style="display:inline"><a href="https://twitter.com/share" class="twitter-share-button">Tweet</a>
<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0];if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src="//platform.twitter.com/widgets.js";fjs.parentNode.insertBefore(js,fjs);}}(document,"script","twitter-wjs");</script></div>
								<div class="googleplus" style="display:inline"><g:plusone size="medium" annotation="none"></g:plusone>
								<script type="text/javascript">
  								window.___gcfg = {lang: 'en-GB'};

  								(function() {
    							var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
    							po.src = 'https://apis.google.com/js/plusone.js';
    							var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
  								})();
								</script>
								</div>
                                <!-- End of Shares for Social Media -->



                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <hr style="background-color:#262626;border:none;"  size="6" />
    <!-- <img src="/App/Images/view-other-products.jpg" />
    <div class="OtherProducts">
        <asp:PlaceHolder ID="plcOtherProducts" runat="server" />
    </div>
    <hr style="background-color:#262626;border:none;"  size="6" /> -->
    <br /><br />
        <uc:CommentsPanel ID="com1" Zone="Product" runat="server" />

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

