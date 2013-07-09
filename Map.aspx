<%@ Page Title="Site Map" Language="VB" MasterPageFile="~/MasterPages/Store.master" AutoEventWireup="false" CodeFile="Map.aspx.vb" Inherits="Map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubNavigationContainer" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentContainer" Runat="Server">
    <h1>Site Map for Pet Dream House</h1>
    <div style="border-top:1px dashed #000000;padding:10px 0px;min-height:600px;">
        <uc:RightBlocks AdvertIDs="8,6,1" ID="Ads" runat="server"  style="float:right" />
        
        <div id="container_for_map" style="width:650px;">
        
        <div style="width:300px; float:left">
        <br />
        <h2>Designer Pet Furniture</h2>
        
        <h3>About us</h3>
        <p><a href="/">Home Page</a></p>
        <p><a href="/about">About PetDreamHouse.com</a></p>
        <p><a href="/modern">Modern Pet Revolution</a></p>
        <p><a href="/websiteterms">Terms &amp; Conditions</a></p>
        <p><a href="/privacy">Privacy Policy</a></p>
        <br />
        
        <h3>Our Store</h3>
        <p><a href="/Products">Store</a></p>
        <p><a href="/designer">Designer To You</a></p>
        <p><a href="/Basket">My Basket</a></p>
        <p><a href="/Delivery">Delvery &amp; Refunds</a></p>
        <br />
      
        
        
        <h3>Concept Store</h3>
        <p><a href="/Concept">Design Concepts</a></p>
        <p><a href="/Concept/howitworks">How It Works</a></p>
        <p><a href="/Concept/Submit.aspx">Submit A Design</a></p>
        <p><a href="/submissionterms">Terms of Submission</a></p>
        <br />
          </div>
          
         <div style="width:300px; float:right; margin-top:55px">
        
        <h3>Cool Stuff Store</h3>
        <p><a href="/Cool">Cool Stuff</a></p>
        <p><a href="/cool/Submit.aspx">Send Your Stuff</a></p>
        <br /> 
        
        <h3>How can we help?</h3>
        <p><a href="/contact">Contact Us</a></p>
        <p><a href="/feedback.aspx">Feedback</a></p>
        <p><a href="/faq.aspx">Help / FAQ</a></p>
        <br /> 
      
                </div>
                </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubFooterContainer" Runat="Server">
</asp:Content>

