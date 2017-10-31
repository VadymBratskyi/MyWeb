<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CarShopEntity.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" cellpadding="5" celspacing="0">
                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="validName" ErrorMessage="*" 
                            ForeColor="Red" ControlToValidate="txtName">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="validPass" ErrorMessage="*" 
                            ForeColor="Red" ControlToValidate="txtPassword">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Compire Password</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCompirePassword" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidatorPassword" runat="server" ErrorMessage="*"
                            ForeColor="Red" ControlToValidate="txtPassword" ControlToCompare="txtCompirePassword" />
                    </td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="emailValid" ErrorMessage="*" 
                            ForeColor="Red" ControlToValidate="txtEmail">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" ID="btRegistr" Text="Registr" OnClick="btRegistr_Click"/>
                    </td>
                </tr>
            </table>
            <asp:Label runat="server" ID="errorMessage"></asp:Label>
        </div>
    </form>
</body>
</html>
