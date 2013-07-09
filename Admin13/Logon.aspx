<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Logon.aspx.vb" Inherits="Admin13_Logon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Please Logon</title>
    <link href="/App/CSS/Inputs.css" rel="stylesheet" type="text/css" />
    <link href="/App/CSS/Admin.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color:#545454;">
    <form id="form1" runat="server">
    <div style="width:330px;margin:30px auto;padding:10px 40px 40px 40px; background-color:White; border:1px solid black;">
        <h3 style="margin:10px 0px;">Please Logon</h3>
        <b style="display:inline-block;width:120px;">Email Address</b>
        <asp:TextBox ID="txtUsername" runat="server" Width="200"></asp:TextBox>
        <br /><br />
        
        <b style="display:inline-block;width:120px;">Password</b>
        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
        <asp:Button ID="btnLogon" runat="server" Text="Logon" />
        <br /><br />
        <asp:Label ID="lblResponse" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>&nbsp;
        <br /><br />
    </div>
    </form>
</body>
</html>
