<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="CarShopEntity.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <table>
               <tr>
                   <td>Login</td>
                   <td><asp:TextBox runat="server" ID="logTxt"></asp:TextBox></td>
               </tr>
               <tr>
                   <td>Password</td>
                   <td><asp:TextBox runat="server" ID="passTxt" TextMode="Password"></asp:TextBox></td>
               </tr>
               <tr>
                   <td colspan="2">
                       <asp:Button runat="server" ID="btLogIn" Text="logIn" OnClick="btLogIn_Click"/>
                       <asp:Button runat="server" ID="btMamber" Text="logIn2" OnClick="btLogIn_Click1"/>
                       <a href="Register.aspx">Rigistration</a>
                       <asp:Label runat="server" ID="errorLogMss"></asp:Label>
                   </td>                   
               </tr>
           </table>
        </div>
    </form>
</body>
</html>
