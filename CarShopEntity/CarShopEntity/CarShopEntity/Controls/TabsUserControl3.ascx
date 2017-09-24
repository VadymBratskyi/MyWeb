<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TabsUserControl3.ascx.cs" Inherits="CarShopEntity.Controls.TabsUserControl3" %>
<%@ Import Namespace="System.ComponentModel" %>


<asp:Repeater runat="server" ID="tabRepetr" OnItemCommand="tabRepetr_OnItemCommand">
    <HeaderTemplate>
        <table>
            <tr>
    </HeaderTemplate>
    <ItemTemplate>
            <td>
                <asp:Button runat="server" ID="pageBtn" 
                    Text="<%#Container.DataItem%>" 
                    BackColor="<%#GetBackColor(Container)%>" 
                    BorderStyle="None"/>
            </td>
    </ItemTemplate>
    <FooterTemplate>
            </tr>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Panel runat="server" ID="panel" BackColor="Gray" Width="100%" Height="10px"></asp:Panel>
