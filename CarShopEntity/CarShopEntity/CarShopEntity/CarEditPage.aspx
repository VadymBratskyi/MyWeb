<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CarEditPage.aspx.cs" Inherits="CarShopEntity.CarEditPage" %>
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
                            <table>
                                <tr>
                                    <th>Название</th>
                                    <th>Модель</th>
                                </tr>
                                <tr>
                                    <td><asp:DropDownList CssClass="form-control" runat="server" ID="dbNamecar"></asp:DropDownList></td>
                                    <td><asp:TextBox CssClass="form-control"  runat="server" ID="tbModelCar"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th>Двигатель</th>
                                    <th>Топливо</th>
                                </tr>
                                <tr>
                                    <td><asp:TextBox CssClass="form-control"  runat="server" ID="tbEng"></asp:TextBox></td>
                                    <td><asp:TextBox CssClass="form-control"  runat="server" ID="tbFuel"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th>Тип</th>
                                    <th>Цвет</th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList CssClass="form-control"  runat="server" ID="dbType"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="tbColor" TextMode="Color"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Дата выпуска</th>
                                    <th>Цена</th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox CssClass="form-control"  runat="server" ID="tbDate" TextMode="Date"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control"  runat="server" ID="tbPrice" TextMode="Number"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br/>
                                        <br/>
                                        <br/>
                                        <br/>
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:FileUpload runat="server" ID="imgLoader"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <div class="btn-group-vertical">
                                <asp:Button runat="server" ID="btnSave" CssClass="btn btn-warning" Text="Сохранить" OnClick="btnSave_OnClick" />
                                <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger" Text="Отмена" OnClick="btnCancel_OnClick"/>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
