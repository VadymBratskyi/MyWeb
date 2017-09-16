<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CarModelPage.aspx.cs" Inherits="CarShopEntity.CarModelPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <a href="MyHandler.aspx">Link HTTP</a>
                <br/>
                <a href="/Handler/TextHandler.ashx">Txtx Handler</a>
                <br/>
                <a href="/Handler/ImgHandler.ashx">Img Handler</a>
            </div>
        </div>
        <div class="row" style="padding-top: 10px">
            <div class="col-md-12">
                <ul>
                    <li><a href="/Docs/File1.test">File 1</a></li>
                    <li><a href="/Docs/File2.test">File 2</a></li>
                    <li><a href="/Docs/File3.test">File 3</a></li>
                </ul>
            </div>
        </div>
        <div class="row" style="padding-top: 10px">
            <div class="col-md-12">
                <a href="/ImageSource/view.axd">Images</a>
                <br/>
                <br/>
                <a href="CarsPage.aspx">carsPage</a>
                <a href="TypeCarsPage.aspx">typesPage</a>
            </div>
        </div>
    </div>
</asp:Content>
