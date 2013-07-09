<%@ Page Title="View Details" Language="VB" MasterPageFile="~/MasterPages/Cool.master" AutoEventWireup="false" CodeFile="Details.aspx.vb" Inherits="Cool_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubNavigationContainer" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentContainer" Runat="Server">
    <img src="/App/Images/cool-stuff-top.png" />

    <table width="100%" cellspacing="0" cellpadding="0" class="CoolView">
        <tr>
            <td valign="top" width="620">
                <div class="DisplayLeft">
                    <asp:Image ID="imgStatus" ImageUrl="/App/Images/Concept Images/vote2.png" CssClass="StatusIcon" runat="server" />
                    <h1 id="hDesignTitle" class="DesignTitle" runat="server"></h1>
                    <asp:Label ID="lblFrom" CssClass="From" runat="server"></asp:Label>
                    <br />
                    <asp:Image ID="imgMain" ImageUrl="" CssClass="MainImage" runat="server" /><br />
                    <div style="margin-top:3px;" class="Thumbs" id="imgs" runat="server">
                        <asp:Image ID="imgSample" Width="100" Height="75" runat="server" Visible="false" />
                        <asp:Image ID="Image1" Width="100" Height="75" runat="server" Visible="false" />
                        <asp:Image ID="Image2" Width="100" Height="75" runat="server" Visible="false" />
                        <asp:Image ID="Image3" Width="100" Height="75" runat="server" Visible="false" />
                        <asp:Image ID="Image4" Width="100" Height="75" runat="server" Visible="false" />
                        <asp:Image ID="Image5" Width="100" Height="75" runat="server" Visible="false" />

                    </div>
                </div>
            </td>
            <td valign="top" width="330">
                <asp:HyperLink ID="lnkBack" runat="server" ImageUrl="/App/Images/goback.jpg" NavigateUrl="/Cool" style="float:right;"></asp:HyperLink>
                <asp:HyperLink ID="lnkInStore" runat="server" ImageUrl="/App/Images/our_store.png" NavigateUrl="/Products" style="float:left;"></asp:HyperLink>
                <div class="DisplayRight">

                    <h2 style="margin:20px 0px 0px 0px;">What is it?</h2>
                    <div class="DottedLine"></div>
                    <p><asp:Label ID="lblWhat" runat="server" CssClass="What"></asp:Label>
                    <asp:Label Visible="false" ID="lblEstPrice" runat="server" CssClass="Price"></asp:Label>
                    </p>
                    <h2 style="margin:10px 0px 0px 0px;">Features</h2>
                    <div class="DottedLine"></div>
                    <asp:Label ID="lblWhy" runat="server" CssClass="Why"></asp:Label>

                    <asp:HyperLink Visible="false" ID="lnkWhere" CssClass="Where" Text="Click here to visit the website" runat="server"></asp:HyperLink>
                    <br />
                    <h2 style="margin:10px 0px 0px 0px;">For which animals</h2>
                    <div class="DottedLine"></div>
                    <div id="divFor" runat="server" class="SelectedAnimalTypes">
                                
                    </div>
                    
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
                    
               </div>
            </td>
        </tr>
    </table>
    
    <uc:CommentsPanel ID="com1" Zone="Cool" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

