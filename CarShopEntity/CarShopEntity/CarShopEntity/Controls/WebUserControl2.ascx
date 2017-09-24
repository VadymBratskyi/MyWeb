<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl2.ascx.cs" Inherits="CarShopEntity.Controls.WebUserControl2" %>

<div style="padding: 10px">
   <asp:Panel runat="server" ID="panel" Width="400" Height="300" BorderStyle="Dashed">
       <asp:TextBox runat="server" ID="txtBox"></asp:TextBox>
       <asp:Calendar runat="server" ID="calendar" OnSelectionChanged="calendar_OnSelectionChanged"></asp:Calendar>
       <asp:Button runat="server" ID="btn" OnClick="btn_OnClick" Text="GetDate"/>   
   </asp:Panel> 
</div>