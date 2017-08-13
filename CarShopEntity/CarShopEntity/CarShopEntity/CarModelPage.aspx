<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CarModelPage.aspx.cs" Inherits="CarShopEntity.CarModelPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/myScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-4">
                <div class="panel panel-default">
                    <fieldset class="panel-body">
                        <legend>Сканування</legend>
                        <div class="col-sm-5">
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddPrinters"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:LinkButton runat="server" CssClass="btn btn-default">
                                <span class="glyphicon glyphicon-print"></span>
                            </asp:LinkButton>
                        </div>
                        <div class="col-sm-5">
                            <asp:CheckBox runat="server" id="chBothSides" CssClass="checkbox checkbox-inline" Text="С обеих сторон"/>
                        </div>
                    </fieldset>
                </div>
            </div>
            <div class="col-md-4">
               <div class="panel panel-default">
                   <fieldset class="panel-body">
                       <legend>Слайдшоу</legend>
                       <div class="col-sm-4"style="padding: 0; width: inherit">
                           <button type="button"id="btStop" class="btn btn-default">
                               <span class="glyphicon glyphicon-stop"></span>
                           </button>
                           <button type="button" id="btPlayStop" class="btn btn-default">
                               <span class="glyphicon glyphicon-play"></span>
                           </button>
                       </div>
                       <div class="col-sm-4" style="padding: 0 10px 0 10px">
                           <div class="input-group">
                               <span class="input-group-btn">
                                   <button type="button" class="btn btn-danger btn-number" data-type="minus" data-field="speed">
                                       <span class="glyphicon glyphicon-minus"></span>
                                   </button>
                               </span>
                               <input type="text" name="speed" class="form-control txt-number" style="min-width: 50px;" value="1" min="1" max="10">
                               <span class="input-group-btn">
                                   <button type="button" class="btn btn-success btn-number" data-type="plus" data-field="speed">
                                       <span class="glyphicon glyphicon-plus"></span>
                                   </button>
                               </span>
                           </div>
                       </div>
                       <div class="col-sm-4" style="padding: 0 10px 0 20px">
                           <div class="input-group">
                               <span class="input-group-btn">
                                   <button type="button" class="btn btn-default btn-number" data-type="minus" data-field="skip">
                                       <span class="glyphicon glyphicon-minus"></span>
                                   </button>
                               </span>
                               <input type="text" name="skip" class="form-control txt-number" style="min-width: 50px;" value="1" min="1" max="100">
                               <span class="input-group-btn">
                                   <button type="button" class="btn btn-default btn-number" data-type="plus" data-field="skip">
                                       <span class="glyphicon glyphicon-plus"></span>
                                   </button>
                               </span>
                           </div>
                       </div>
                   </fieldset>
               </div>
            </div>
            <div class="col-md-4">
               <div class="panel panel-default">
                   <fieldset class="panel-body">
                       <legend>Преміщення скан копії</legend>
                       <div class="col-sm-6">
                           <div class="btn-group">
                               <button type="button" class="btn btn-default btn-position" id="btFirstUp" data-type="firstUp" disabled="disabled">
                                   <img src="Content/img/first-up.png" style="width: 11px; height: 18px"/>
                               </button>
                               <button type="button" class="btn btn-default btn-position" id="btUp"  data-type="Up" disabled="disabled">
                                   <span class="glyphicon glyphicon-arrow-up"></span>
                               </button>
                               <button type="button" class="btn btn-default btn-position" id="btDown" data-type="Down" disabled="disabled">
                                   <span class="glyphicon glyphicon-arrow-down"></span>
                               </button>
                               <button type="button" class="btn btn-default btn-position" id="btLastDown" data-type="lastDown" disabled="disabled">
                                   <img src="Content/img/last-bottom.png" style="width: 11px; height: 18px"/>
                               </button>
                           </div>
                       </div>
                       <div class="col-sm-6">
                           <button type="button" class="btn btn-default">
                               <span class="glyphicon glyphicon-remove"></span>
                           </button>
                           <button type="button" class="btn btn-default">
                               <span class="glyphicon glyphicon-floppy-disk"></span>
                           </button>
                       </div>
                   </fieldset>
               </div>
            </div>
        </div>
        <div class="row" style="padding: 50px;">
            <div class="container-fluid">
                <div class="col-md-7">
                    <table id="jqg" class="table"></table>
                    <div id="GridPager"></div>
                </div>
                <div class="col-md-5">
                    <img id="imgSrc" class="img-thumbnail"width="550" height="600" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
