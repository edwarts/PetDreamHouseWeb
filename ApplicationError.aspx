<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ApplicationError.aspx.vb" Inherits="ApplicationError" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fatal Error</title>
    
</head>
<body style="font-family:Arial;">
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMessage" Font-Bold="true" Font-Size="16px" runat="server"></asp:Label>
        <br /><br />
        <asp:Label ID="lblStack" runat="server" Font-Size="12px"></asp:Label>
    </div>
    </form>
</body>
</html>
