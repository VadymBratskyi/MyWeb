<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CarsPage.aspx.cs" Inherits="CarShopEntity.CarsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

        $(function () {
            $("#slider-range").slider({
                range: true,
                min: 0,
                max: 300000,
                values: [0, 300000],
                slide: function (event, ui) {
                    $("#<%=amount.ClientID%>").val("$" + ui.values[0] + " - $" + ui.values[1]);
                    $("#<%=hdPriceFrom.ClientID%>").val(ui.values[0]);
                    $("#<%=hdPriceTo.ClientID%>").val(ui.values[1]);
                }
            });
            $("#<%=amount.ClientID%>").val("$" + $("#slider-range").slider("values", 0) +
                " - $" + $("#slider-range").slider("values", 1));
        });

        function shovDelete(value) {
            if (confirm("Вы уверенны")) {
                $.ajax({
                    type: "POST",
                    url: "CarsPage.aspx/DeleteCar",
                    data: JSON.stringify({
                        carId: value
                    }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }
        }
        
        function OnSuccess(response) {
            location.reload();
        }

        function shovInfo(value) {
            location.href = 'CarInfoPage.aspx?carId=' + value;
        }

        function shovEdit(value) {
            location.href = 'CarEditPage.aspx?carId=' + value;
        }

        $(document).ready(function() {
            $("#menu-toggle").click(function (e) {
                e.preventDefault();
                $("#wrapper").toggleClass("toggled");
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hdPriceTo"/>
    <asp:HiddenField runat="server" ID="hdPriceFrom"/>
    <div class="container-fluid" id="listAdd">
        <span style="font-family: Times New Roman; font-size: 30px; font-weight: bold">Список автомобилей</span>
        <button id="btCreate" type="button" class="btn btn-default"  data-toggle="modal" data-target="#myModal">Добавить автомобиль</button>
    </div>
    <div id="wrapper">
        <!-- Sidebar -->
        <div id="sidebar-wrapper">
            <ul class="sidebar-nav">
                <li class="sidebar-brand">
                    <div class="text-center">
                        <span class="txtStyleMain">Фильтр</span>
                    </div>
                </li>
                <li>
                    <div class="dv text-center">
                        <asp:TextBox runat="server" CssClass="form-control" ID="tbSearch" placeholder="поиск.."></asp:TextBox>
                        <br/>
                        <asp:Button runat="server" ID="btSearch" CssClass="btn btn-default" ValidationGroup="group_1" Text="Поиск" OnClick="OnClick"/>
                    </div>
                </li>
                <li>
                    <div class="dv">
                        <p>
                            <label>Цена автомобиля:</label>
                            <asp:TextBox type="text" ID="amount" ReadOnly="True" style="color:#f6931f; font-weight:bold;" runat="server" CssClass="form-control"></asp:TextBox>
                        </p>
                        <div id="slider-range"></div>
                    </div>
                </li>
                <li>
                    <div class="dv">
                        <h4 style="padding-left: 35px;">Название автомобилей</h4>    
                        <asp:CheckBoxList runat="server" ID="chСarslist" CssClass="checkbox-inline"/>
                    </div>
                </li>
                <li>
                    <div class="dv">
                        <h4>Тип автомобиля</h4>    
                        <asp:CheckBoxList runat="server" ID="chTipelist" CssClass="checkbox-inline"/>
                    </div>
                </li>
                <li>
                    <div class="dv text-center">
                        <h4>Обем двигателя</h4>    
                        <asp:TextBox runat="server" ID="engFrom" Width="50" CssClass="form-control" style="margin-right: 25px; display: inline" placeholder="от"></asp:TextBox>
                        <asp:TextBox runat="server" ID="engTo" Width="50" CssClass="form-control" style="display: inline" placeholder="до"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <div class="dv">
                        <asp:Button type="button" ID="btSearchSecond" class="btn btn-info"  ValidationGroup="group_1" Text="Применить фильтр" OnClick="btSearchSecond_OnClick"  runat="server"/>
                    </div>
                </li>
            </ul>
        </div>
        <!-- /#sidebar-wrapper -->

        <!-- Page Content -->
        <div id="page-content-wrapper">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">
                        <a href="#menu-toggle" class="btFilter" style="text-decoration: none"id="menu-toggle">ф<br/>и<br/>л<br/>ь<br/>т<br/>р</a>
                        <asp:ScriptManager runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <table class="table table-condensed">
                                    <thead>
                                        <tr>
                                            <th style="width: 400px;">Изображение</th>
                                            <th>Информация</th>
                                            <th>Цена</th>
                                            <th>Операции</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Literal runat="server" ID="lbRowtable"></asp:Literal>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btSearch" />
                                <asp:AsyncPostBackTrigger ControlID="btSearchSecond"/>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <!-- /#page-content-wrapper -->

    </div>
    <!-- /#wrapper -->
    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <span class="modal-title" id="exampleModalLabel">Добавить автомобиль</span>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:FileUpload runat="server" ID="loadimg"/> 
                    <table class="table table-bordered">
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Название авто"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text="Двигатель авто"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddNamecar"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="tbEngine" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbEngine" ForeColor="red" ValidationGroup="group_2" ErrorMessage="Is'nt empty"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Модель авто"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text="Топливо"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox runat="server" ID="tbModelCar" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbModelCar" ForeColor="red" ValidationGroup="group_2" ErrorMessage="Is'nt empty"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="tbFuel" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbModelCar" ForeColor="red" ValidationGroup="group_2" ErrorMessage="Is'nt empty"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Тип авто"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text="Дата випуска"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList CssClass="form-control"  runat="server" ID="ddType"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="tbDateIssue" CssClass="form-control" Text="" TextMode="Date"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbDateIssue" ForeColor="red" ValidationGroup="group_2" ErrorMessage="Is'nt empty"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Цвет"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text="Цена"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox runat="server" ID="tbColor" CssClass="form-control" TextMode="Color"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="tbPrice" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbPrice" ForeColor="red" ValidationGroup="group_2" ErrorMessage="Is'nt empty"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Закрыть</button>
                    <asp:Button runat="server" ID="btSub" Text="Сохранить" CssClass="btn btn-primary" ValidationGroup="group_2" OnClick="btSub_OnClick"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
