<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="CarShopEntity.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 style="color: red; font-weight: bold">Error in page</h1>
        <hr/>
        <h3><strong>Inner Exception</strong></h3>
        <asp:Literal runat="server" ID="errorLiteral"></asp:Literal>
    </div>
</asp:Content>
