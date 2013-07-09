<%@ Page Title="View Details" Language="VB" MasterPageFile="~/MasterPages/Concept.master" AutoEventWireup="false" CodeFile="Details.aspx.vb" Inherits="Concept_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubNavigationContainer" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentContainer" Runat="Server">
    <img src="/App/Images/design-concepts-top.png" />

    <table width="100%" cellspacing="0" cellpadding="0" class="ConceptView">
        <tr>
            <td valign="top" width="620">
                <div class="DisplayLeft">
                    <asp:Image ID="imgStatus" ImageUrl="/App/Images/Concept Images/vote2.png" CssClass="StatusIcon" runat="server" />
                    <h1 id="hDesignTitle" class="DesignTitle" runat="server"></h1>
                    <asp:Label ID="lblDesigner" CssClass="DesignedBy" runat="server"></asp:Label>
                    <br />
                    <asp:Image ID="imgMain" ImageUrl="" CssClass="ConceptMainImage" runat="server" /><br />
                    <div style="margin-top:3px;" class="Thumbs" id="Thumbs" runat="server">
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
                <div style="float:right;">
                    <asp:HyperLink ID="lnkEditDesign" Visible="false" runat="server" ImageUrl="/App/Images/edit-design.png" NavigateUrl="/Concept/Submit" ></asp:HyperLink>
                    <asp:HyperLink ID="lnkBack" runat="server" ImageUrl="/App/Images/goback.jpg" NavigateUrl="/Concept" style=""></asp:HyperLink>
                </div>
                <div class="DisplayRight">
                    <asp:Image CssClass="Stars" ID="imgStars" runat="server" />
                    <asp:Label ID="lblLargeVote" runat="server" Text="0.0" CssClass="VoteLarge"></asp:Label>
                    <h2>Submit your score for this design</h2>
                    <div class="VoteRBS" id="VoteOptions" runat="server">
                        <table width="300px">
                        	<tr>
                            <td width="40" align="center"><asp:RadioButton GroupName="Vote" ID="V1" runat="server" /></td>
                            <td width="40" align="center"><asp:RadioButton GroupName="Vote" ID="V2" runat="server" /></td>
                            <td width="40" align="center"><asp:RadioButton GroupName="Vote" ID="V3" runat="server" /></td>
                            <td width="40" align="center"><asp:RadioButton GroupName="Vote" ID="V4" runat="server" /></td>
                            <td width="40" align="center"><asp:RadioButton GroupName="Vote" ID="V5" runat="server" /></td>
                            <td rowspan="2" width="300" align="right"><asp:ImageButton ID="btnSubmitVote" runat="server" CssClass="VoteButton" ImageUrl="/App/Images/submit-vote-button.png" /></td></tr>
                            <td align="center" width="40">1</td>
                            <td align="center" width="40">2</td>
                            <td align="center" width="40">3</td>
                            <td align="center" width="40">4</td>
                            <td align="center" width="40">5</td>
                         </table>
                    </div>
                  
                    
                    <div>
                        <asp:Label ID="lblVoteResponse" CssClass="VoteResponse" runat="server" ></asp:Label>
                    </div>

                    
                    <h2 style="margin:10px 0px 0px 0px;">Product Concept Details</h2>
                    <div class="DottedLine"></div>
                    <div class="Description">
                        <p><asp:Label ID="lblDesc" runat="server"></asp:Label></p>
                   
                        <asp:Label ID="lblEstPrice" runat="server" Text="Estimated Price: £300.00" Font-Bold="true"></asp:Label>

                    </div>
                    
                    <h2 style="margin:10px 0px 0px 0px;">For which animals</h2>
                    <div class="DottedLine"></div>
                                <div style="float:right;margin-top:10px; color:#545454;">
                                    <b>Date Submitted:</b> <asp:Label ID="lblDateSubmitted" runat="server" CssClass="Green"></asp:Label>
                                </div>
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

    <uc:CommentsPanel ID="com1" Zone="Concept" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

