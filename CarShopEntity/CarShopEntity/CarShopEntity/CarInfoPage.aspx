<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CarInfoPage.aspx.cs" Inherits="CarShopEntity.CarInfoPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        tr,th,td {
            padding: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <table class="table table-bordered">
                <thead>
                    <th width="300px">Изображение</th>
                    <th>Информация</th>
                    <th>Операции</th>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <asp:Image runat="server" Width="600" Height="450" ID="imgCar"/>
                        </td>
                        <td>
                            <h3><%= CarName%> <%= CarModel%></h3>
                            <table>
                                <tr>
                                    <th>Двигатель</th>
                                    <th>Топливо</th>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="lbEng"></asp:Label></td>
                                    <td><asp:Label runat="server" ID="lbFuel"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>Тип</th>
                                    <th>Цвет</th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lbType"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="lbColor" ReadOnly="True" Enabled="False" TextMode="Color"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Дата выпуска</th>
                                    <th>Цена</th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lbdate"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lbPrice"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <div class="btn-group-vertical">
                                <asp:Button runat="server" ID="btnEdit" CssClass="btn btn-warning" Text="Редактировать" OnClick="btnEdit_OnClick"/>
                                <asp:Button runat="server" ID="btnDelite" CssClass="btn btn-danger" OnClick="btnDelite_OnClick" OnClientClick="return confirm('Вы уверенны?')" Text="Удалить"/>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
