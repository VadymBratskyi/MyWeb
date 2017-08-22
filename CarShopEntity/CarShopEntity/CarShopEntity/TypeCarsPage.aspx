<%@ Page Title="" MasterPageFile="~/SiteMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="TypeCarsPage.aspx.cs" Inherits="CarShopEntity.TypeCarsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/kendo/kendo.common.min.css" rel="stylesheet" />
    <link href="Content/kendo/kendo.rtl.min.css" rel="stylesheet" />
    <link href="Content/kendo/kendo.flat.min.css" rel="stylesheet" />
    <link href="Content/kendo/kendo.flat.mobile.min.css" rel="stylesheet" />
    <link href="Content/typeCarsCss/typeCars.css" rel="stylesheet" />
    <link href="Content/mySrtyle.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/css/tether.min.css">
    <link href="Content/cropper.css" rel="stylesheet" />

    <script src="Scripts/kendo/jszip.min.js" type="text/javascript"></script>
    <script src="Scripts/kendo/kendo.all.min.js" type="text/javascript"></script>
    <script src="Scripts/zoomsl-3.0.js"></script>
    <script src="Scripts/scriptTypeCars/typeCars.js"></script>
    <script src="Scripts/cropper.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row" style="padding: 20px">
            <div class="col-md-12">
                <table class="table-condensed" style="width: 100%;">
                    <tr>
                        <td>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddPrinters"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CssClass="btn btn-sm  btn-default">
                                <span class="glyphicon glyphicon-print"></span>
                            </asp:LinkButton>
                        </td>
                        <td>
                            <input type="checkbox" id="twoPage" class="k-checkbox" checked="checked">
                            <label class="k-checkbox-label" for="twoPage">
                                <img src="Content/img/2_size.gif" style="width: 30px; height: 25px; margin-top: -5px;" />
                            </label>
                        </td>
                        <td>
                            <div class="btn-group">
                                <button type="button" class="btn btn-sm btn-default btn-position" id="btFirstUp" data-type="firstUp" disabled="disabled">
                                    <img src="Content/img/first-up.png" style="width: 11px; height: 17px"/>
                                </button>
                                <button type="button" class="btn btn-sm btn-default btn-position" id="btUp"  data-type="Up" disabled="disabled">
                                    <span class="glyphicon glyphicon-arrow-up"></span>
                                </button>
                                <button type="button" class="btn btn-sm btn-default btn-position" id="btDown" data-type="Down" disabled="disabled">
                                    <span class="glyphicon glyphicon-arrow-down"></span>
                                </button>
                                <button type="button" class="btn btn-sm btn-default btn-position" id="btLastDown" data-type="lastDown" disabled="disabled">
                                    <img src="Content/img/last-bottom.png" style="width: 11px; height: 17px"/>
                                </button>
                            </div>
                        </td>
                        <td>
                            <div class="btn-group">
                                <button type="button" class="btn btn-sm btn-default" id="btCancelAll" title="Отменить все изменения">
                                    <span class="glyphicon glyphicon-remove"></span>
                                </button>
                                <button type="button" class="btn btn-sm btn-default" id="btSaveAll" title="Сохранить все изменения">
                                    <span class="glyphicon glyphicon-floppy-disk"></span>
                                </button>
                            </div>
                        </td>
                        <td>
                            <div class="btn-group">
                                <button type="button" id="btStop" class="btn btn-sm btn-default btn-slider" disabled="disabled" data-type="stop">
                                    <span class="glyphicon glyphicon-stop"></span>
                                </button>
                                <button type="button" id="btPlay" class="btn  btn-sm btn-default btn-slider" data-type="play">
                                    <span id="iconBtPlaPause" class="glyphicon glyphicon-play"></span>
                                </button>
                            </div>
                            <button type="button" id="btSetType" class="btn  btn-sm btn-default btn-slider" data-type="set">
                                <span>Set</span>
                            </button>
                            <button type="button" id="btDeleteScan" class="btn  btn-sm btn-default btn-slider" data-type="delete">
                                <span>DeleteScan</span>
                            </button>
                        </td>
                        <td>
                            <div class="input-group">
                                <span class="input-group-btn">
                                    <button type="button" class="btn btn-sm btn-danger btn-number" value="3" data-type="minus" data-field="speed">
                                        <span>-3</span>
                                    </button>
                                    <button type="button" class="btn btn-sm btn-danger btn-number" value="1" data-type="minus" data-field="speed">
                                        <span>-1</span>
                                    </button>
                                    <button type="button" class="btn btn-sm btn-danger btn-number" value="0.5" data-type="minus" data-field="speed">
                                        <span>-0.5</span>
                                    </button>
                                </span>
                                <input type="text" name="speed" class="form-control input-sm txt-number" style="min-width: 40px;" value="1" min="0.5" max="10">
                                <span class="input-group-btn">
                                    <button type="button" class="btn btn-sm btn-success btn-number" value="0.5" data-type="plus" data-field="speed">
                                        <span>+0.5</span>
                                    </button>
                                    <button type="button" class="btn btn-sm btn-success btn-number" value="1" data-type="plus" data-field="speed">
                                        <span>+1</span>
                                    </button>
                                    <button type="button" class="btn btn-sm btn-success btn-number" value="3" data-type="plus" data-field="speed">
                                        <span>+3</span>
                                    </button>
                                </span>
                            </div> 
                        </td>
                        <td>
                            <div class="input-group">
                                <span class="input-group-btn">
                                    <button type="button" class="btn btn-sm btn-default btn-number" data-type="minus" data-field="skip">
                                        <span class="glyphicon glyphicon-minus"></span>
                                    </button>
                                </span>
                                <input type="text" name="skip" class="form-control input-sm txt-number" style="min-width: 50px;" value="1" min="1" max="100">
                                <span class="input-group-btn">
                                    <button type="button" class="btn btn-sm btn-default btn-number" data-type="plus" data-field="skip">
                                        <span class="glyphicon glyphicon-plus"></span>
                                    </button>
                                </span>
                                <span class="input-group-btn">
                                    <button type="button" class="btn btn-sm btn-default" id="btSkip" title="Пропустить количество строк">
                                        <span class="glyphicon glyphicon-chevron-right"></span>
                                    </button>
                                </span>
                            </div>
                        </td>
                        <td>
                            <div class="btn-group">
                                <button type="button" class="btn btn-sm btn-primary btn-crop" data-method="crope" data-option="crop" title="Crop">
                                    <span class="docs-tooltip" data-toggle="tooltip" data-animation="false" title="Crop">
                                        <span class="fa fa-crop"></span>
                                    </span>
                                </button>
                                <button type="button" class="btn btn-sm btn-primary btn-crop" data-method="setDragMode" data-option="move" title="Move">
                                    <span class="docs-tooltip" data-toggle="tooltip" data-animation="false" title="Move">
                                        <span class="fa fa-arrows"></span>
                                    </span>
                                </button>
                            </div>

                            <div class="btn-group">
                                <button type="button" class="btn btn-sm btn-primary btn-crop" data-method="rotate" data-option="-90" title="Rotate Left">
                                    <span class="docs-tooltip" data-toggle="tooltip" data-animation="false" title="Rotate Left">
                                        <span class="fa fa-rotate-left"></span>
                                    </span>
                                </button>
                                <button type="button" class="btn btn-sm btn-primary btn-crop" data-method="rotate" data-option="90" title="Rotate Right">
                                    <span class="docs-tooltip" data-toggle="tooltip" data-animation="false" title="Rotate Right">
                                        <span class="fa fa-rotate-right"></span>
                                    </span>
                                </button>
                            </div>

                            <div class="btn-group">
                                <button type="button" class="btn btn-sm btn-primary btn-crop" data-method="reset" title="Reset">
                                    <span class="docs-tooltip" data-toggle="tooltip" data-animation="false" title="Reset">
                                        <span class="fa fa-refresh"></span>
                                    </span>
                                </button>
                                <button type="button" class="btn btn-sm btn-danger btn-crop" data-method="dest" title="Cancel">
                                    <span class="docs-tooltip" data-toggle="tooltip" data-animation="false" title="Cancel">
                                        <span class="fa fa-ban"></span>
                                    </span>
                                </button>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="row">
                    <div class="col-sm-4">
                        <div class="k-content">
                            <table style="width: 100%">
                                <tr style="background-color: #363940; color: #fff;">
                                    <td class="td">Cars</td>
                                    <td class="td">Types</td>
                                </tr>
                                <tr> 
                                    <td>
                                        <select id="lbCar" style="width: 100%; height: 333px" title="Название авто"></select>
                                    </td>
                                    <td>    
                                        <select id="lbType" style="width:100%; height: 333px" title="Тип авто"></select>
                                    </td>
                               </tr>
                                <tr style="background-color: #363940; color: #ffffff; height: 37px">
                                    <td class="td" colspan="2"><i class="glyphicon glyphicon-refresh"></i></td>
                                </tr>
                            </table>
                       </div>
                    </div>
                    <div class="col-sm-8">
                        <div id="grid"></div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="img-container"  style="width: 75%; height: 60%; display: none">
                  <img id="imgSrc" style="width: 100%; height: 100%" class="img-responsive img-container img-thumbnail">
                </div>
            </div>
        </div>
    </div> 
</asp:Content>
