<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Maturski_A.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <link rel="stylesheet" href="mojCSS.css">
</head>
<body>
    <form id="form1" runat="server" >
       
        <div>
            <label>Email:</label><asp:TextBox ID="txtemail" runat="server"></asp:TextBox><br />
            <label>Lozinka:</label><asp:TextBox ID="txtlozinka" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="btnsign_in" runat="server" Text="UPIS" OnClick="btnsign_in_Click" />
           
        </div>
    </form>
</body>
</html>
