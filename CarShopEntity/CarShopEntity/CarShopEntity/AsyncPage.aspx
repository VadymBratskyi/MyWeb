<%@ Page Title="" Async="true" Trace="true" AsyncTimeOut="20" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AsyncPage.aspx.cs" Inherits="CarShopEntity.AsyncPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Label runat="server" ID="output"></asp:Label>
    </div>
</asp:Content>
