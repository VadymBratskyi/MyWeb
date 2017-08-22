var rowObject;
var rowIndex = 0;
var count;
var timeIndex = 0;
var angle = 90;
var deg = 0;
var speed = 1000;
var typeindex = 0;
var timer1 = null;
var timer2 = null;
var mainGrid;
var carId;
var typeDataSource;
var mainDataSource;
var changesRowIndex = new Array();

$(document).ready(function () {
    buildListBoxCar();
    buildListBoxType();
    buildGrid();
    btnChangePositionInGrid();
    btnChangeSpeed();
    btnSkipInGrid();
    btnSlider();
    croppImg();
    DeleteSaveData();
});


function DeleteSaveData() {

    $("#btCancelAll").click(function() {

        if (changesRowIndex.length > 0) {
      
            for (var i = 0; i < changesRowIndex.length; i++) {

                var dataItem = mainGrid.dataSource.view()[changesRowIndex[i]];
                dataItem.Type = null;
            }
            $('#grid').data('kendoGrid').refresh();
        }

        typeindex = 0;
        $("#btSetType").removeAttr("disabled");
        var listBox = $("#lbType").data("kendoListBox");
        listBox.select(listBox.items()[0]);

    });

    $("#btSaveAll").click(function() {
        alert("save");
    });
}


function croppImg() {
    var $image = $("#imgSrc");
    $image.cropper("destroy");
    $image.cropper({ "autoCrop": false });

    $(".btn-crop").on("click", function() {
        var $this = $(this);
        var data = $this.data();
        if ($image[0].src != "") {
            switch (data.method) {
            case "rotate":
                $image.cropper("rotate", data.option);
                break;
            case "crope":
                $image.cropper("setDragMode", data.option);
                $("button[data-option='crop']").addClass("active");
                break;
            case "setDragMode":
                $image.cropper(data.method, data.option);
                break;
            case "dest":
                $image.cropper("destroy");
                $("button[data-option='crop']").removeClass("active");
                break;
            case "reset":
                $image.cropper("reset");
                $image.cropper("clear");
                $("button[data-option='crop']").removeClass("active");
            default:
                break;
            }
        }
    });
}


function btnSlider() {
    

    $(".btn-slider").click(function () {

        var btType = $(this).attr("data-type");
        timeIndex = rowIndex;
        
        if (btType == "play") {

            $("#btPlay").attr("data-type", "pause");

            $("#iconBtPlaPause").removeClass("glyphicon-play").addClass("glyphicon-pause");
            $("#btStop").removeAttr("disabled");


            timer1 = setTimeout(function run() {
                slideShou(timeIndex++);
                timer2 = setTimeout(run, speed);
                if (timeIndex > count) {
                    clearTimeout(timer2);
                    clearTimeout(timer1);
                    alert('Слайд шоу достиг последнего документа');
                    $("#iconBtPlaPause").removeClass("glyphicon-pause").addClass("glyphicon-play");
                    $("#btStop").attr("disabled", true);
                    $("#btPlay").attr("data-type", "play");
                }
            }, 100);

        }

        if (btType == "pause") {
            clearTimeout(timer2);
            clearTimeout(timer1);
            $("#iconBtPlaPause").removeClass("glyphicon-pause").addClass("glyphicon-play");
            $("#btPlay").attr("data-type", "play");
        }

        if (btType == "stop") {
            if (timer1 != null) {
                clearTimeout(timer2);
                clearTimeout(timer1);
                $("#iconBtPlaPause").removeClass("glyphicon-pause").addClass("glyphicon-play");
                mainGrid.select("tr:eq(0)");
                alert('Слайд шоу остановлен');
                $(this).attr("disabled", true);
            }
        }

        if (btType == "set") {
           
            var listBox = $("#lbType").data("kendoListBox");
            
            if (typeindex < listBox.dataSource.data().length && rowObject!=null) {

                listBox.select(listBox.items()[typeindex]);
                var dataList = listBox.dataSource.view()[typeindex];
                rowObject.Type = dataList;
                typeindex += 1;
                $('#grid').data('kendoGrid').refresh();
                mainGrid.select("tr:eq(" + rowIndex + ")");
                changesRowIndex.push(rowIndex);
            }
            if (typeindex == listBox.dataSource.data().length) {
                $(this).attr("disabled", true);
            }
        }

        if (btType == "delete") {
            var grid = $("#grid").data("kendoGrid");
            $("#grid").find(".k-state-selected").each(function() {
                grid.removeRow($(this).closest('tr'));
            });
            $('#grid').data('kendoGrid').refresh();
        }
            

    });
}


function btnChangeSpeed() {
    $('.btn-number').click(function (e) {
        e.preventDefault();

        var bt = $(this);
        var fieldName = $(this).attr("data-field");
        var type = $(this).attr("data-type");
        var tbInput = $("input[name='" + fieldName + "']");
        var btVal = parseFloat(bt.val());
        var currenValue = parseFloat(tbInput.val());

        if (!isNaN(currenValue)) {
            if (fieldName == "speed") {
                plusMinus(bt, fieldName, type, btVal, currenValue, tbInput);
            } else if (fieldName == "skip") {
                plusMinus(bt, fieldName, type, 1, currenValue, tbInput);
            }
        } else {
            tbInput.val(0);
        }
    });

    $(".txt-number").change(function () {
        var minVal = parseFloat($(this).attr("min"));
        var maxVal = parseInt($(this).attr("max"));
        var currentValue = parseFloat($(this).val());
        var name = $(this).attr("name");

        if (name == "speed") {
            speed = parseFloat($(this).val()) * 1000;
        }

        if (currentValue != "") {
            if (currentValue >= minVal) {
                $(".btn-number[data-type='minus'][data-field='" + name + "']").removeAttr("disabled");
                if (name == "speed") {
                    disabledButton(currentValue);
                }
            } else {
                alert('К сожалению, минимальное значение было достигнуто');
                speed = $(this).data("oldValue") * 1000;
                $(this).val($(this).data("oldValue")).change();
                disabledButton($(this).val());
            }

            if (currentValue <= maxVal) {
                $(".btn-number[data-type='plus'][data-field='" + name + "']").removeAttr('disabled');
                if (name == "speed") {
                    disabledButton(currentValue);
                }
            } else {
                alert('К сожалению, максимальное значение было достигнуто');
                speed = $(this).data("oldValue") * 1000;
                $(this).val($(this).data('oldValue')).change();
                disabledButton($(this).val());
            }
        }
        
    });

    $(".txt-number").focusin(function () {
        $(this).data('oldValue', $(this).val());
    });

    $(".txt-number").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });
}


function btnChangePositionInGrid() {

    $(".btn-position").click(function () {

        var dtType = $(this).attr("data-type");
        var row = mainGrid.dataSource.getByUid(rowObject.uid);

        switch (dtType) {
        case "firstUp":
            dragAndDrop(row, 0);
            scrollingContent();
            break;
        case "Up":
            rowIndex = rowIndex - 1;
            if (rowIndex < 0) {
                rowIndex = 0;
            }
            dragAndDrop(row, rowIndex);
            scrollingContent();
            break;
        case "Down":
            rowIndex = rowIndex + 1;
            if (rowIndex >= count) {
                rowIndex = count-1;
            }
            dragAndDrop(row, rowIndex);
            scrollingContent();
            break;
        case "lastDown":
            dragAndDrop(row, count - 1);
            scrollingContent();
            break;
        default:
        }
    });
}

function btnSkipInGrid() {
    $("#btSkip").click(function () {
        var tbInput = $("input[name='skip']");
        var currenValue = parseInt(tbInput.val());

        if (!isNaN(currenValue)) {
            if (currenValue <= count) {
                mainGrid.select("tr:eq(" + (currenValue) + ")");
                scrollingContent();
            } else {
                alert('К сожалению, ваше значение больше количества записей! Их' + count);
                tbInput.val(tbInput.data('oldValue'));
            }
        }
    });
}

function zoom() {
    $('#imgSrc').imagezoomsl({
        zoomrange: [1, 12],
        zoomstart: 2,
        innerzoom: true,
        magnifierborder: "none"
    });
}

function getFromSelectRow() {
    rowObject = mainGrid.dataItem(mainGrid.select());
    rowIndex = mainGrid.select().index();

    $("#imgSrc").attr("src", rowObject.ImgPath);
    $("#imgSrc").cropper("destroy");
    $("button[data-option='crop']").removeClass("active");
    $(".btn-position").removeAttr("disabled");
    $(".img-container").show();

    var d1 = $(".magnifier").remove();
    var d2 = $(".statusdiv").remove();
    var d3 = $(".tracker").remove();

    zoom();
}

function scrollingContent() {
    var rowTop = mainGrid.select()[0].offsetTop;
    var heightRow = mainGrid.content[0].scrollHeight / count;
    $("#grid div.k-grid-content").scrollTop(rowTop-heightRow);
}



function plusMinus(bt, fieldName, type, time, currenValue, tbInput) {

    if (type == "minus") {
        if (currenValue > tbInput.attr("min")) {
            tbInput.val(currenValue - time).change();
        }
        if (parseFloat(tbInput.val()) == tbInput.attr("min")) {
            bt.attr("disabled", true);
        }
    } else if (type == "plus") {
        if (currenValue < tbInput.attr("max")) {
            tbInput.val(currenValue + time).change();
        }
        if (parseFloat(tbInput.val()) == tbInput.attr("max")) {
            bt.attr("disabled", true);
        }
    }
}

function disabledButton(val) {

    var value = parseFloat(val);

    if ((value - 3) < 0.5) {
        $(".btn-number[value='3'][data-type='minus']").attr("disabled", true);
    }
    if ((value - 1) < 0.5) {
        $(".btn-number[value='1'][data-type='minus']").attr("disabled", true);
    }
    if ((value - 0.5) < 0.5) {
        $(".btn-number[value='0.5'][data-type='minus']").attr("disabled", true);
    }

    if ((value + 3) > 10) {
        $(".btn-number[value='3'][data-type='plus']").attr("disabled", true);
    }
    if ((value + 1) > 10) {
        $(".btn-number[value='1'][data-type='plus']").attr("disabled", true);
    }
    if ((value + 0.5) > 10) {
        $(".btn-number[value='0.5'][data-type='plus']").attr("disabled", true);
    }

}


function dragAndDrop(row, idPosition) {
    mainGrid.dataSource.remove(row);
    mainGrid.dataSource.insert(idPosition, row);
    mainGrid.select("tr:eq(" + (idPosition) + ")");
    mainGrid.dataSource.getByUid(row.uid).set("dirty", true);

    var dirtyItems = $.grep(mainGrid.dataSource.view(), function (f) {
        return f.dirty === true;
    });

    for (var a = 0; a < dirtyItems.length; a++) {
        var thisItem = dirtyItems[a];
        mainGrid.tbody.find("tr[data-uid='" + thisItem.get("uid") + "']").find("td:eq(0)").addClass("k-dirty-cell");
        mainGrid.tbody.find("tr[data-uid='" + thisItem.get("uid") + "']").find("td:eq(0)").prepend('<span class="k-dirty"></span>')
    };
}

function slideShou(id) {
    mainGrid.select("tr:eq(" + (id) + ")");
    scrollingContent();
}


function buildListBoxCar() {

    var data = GetDataSourceToCar();

    $("#lbCar").kendoListBox({
        selectable: "single",
        dataSource: data,
        dataTextField: "CarName",
        dataValueField: "Id",
        change: function() {
            var index = this.select().index(),
                dataItem = this.dataSource.view()[index];
            carId = dataItem.id;

            typeindex = 0;
            $("#btSetType").removeAttr("disabled");

            typeDataSource = GetDataSourceToType(carId);
            var listBox = $("#lbType").data("kendoListBox");
            listBox.setDataSource(typeDataSource);

            clearImgDiv();
          
            mainDataSource = GetDataSourceToGrid(carId);
            var setDataGrid = $("#grid").data("kendoGrid");
            setDataGrid.setDataSource(mainDataSource);
            
        }
    });
}



function buildListBoxType() {

    var data = GetDataSourceToType();

    $("#lbType").kendoListBox({
        dataSource: data,
        dataTextField: "TypeName",
        dataValueField: "Id",
        change: function () {
            var index = this.select().index(),
                dataItem = this.dataSource.view()[index];

            //$("#imgSrc").removeAttr("src");
            //$("#imgSrc").removeAttr("data-large");
            //croppImg();
            //mainDataSource = buildDataSource(false, false, true, carId, dataItem.Id);
            //var setDataGrid =  $("#grid").data("kendoGrid");
            //setDataGrid.setDataSource(mainDataSource);
        }
    });
}

function getType(type) {
    if (type != null) {
        return type.TypeName;
    } else {
        return "";
    }
}

function buildGrid() {

    $.fn.reverse = [].reverse; //save a new function from Array.reverse

    mainDataSource = GetDataSourceToGrid();
    
    mainGrid = $("#grid").kendoGrid({
        dataSource: mainDataSource,
        columns: [
            { field: "CarModel" },
            { field: "Color" },
            { field: "Engine" },
            { field: "Fuel" },
            {
                Title: "Type",
                field: "Type",
                template: "#=getType(Type)#",
                editor: function (container, options) { 
                    var input = $('<input name="' + options.field + '"/>');
                    input.appendTo(container);
                    input.kendoDropDownList({
                        dataSource: GetDataSourceToType(carId),
                        dataTextField: "TypeName",
                        dataValueField: "Id"
                    }).appendTo(container);
                }
            },
            { field: "IssueDate" }
        ],
        editable: true,
        scrollable: true,
        navigatable: true,
        selectable: "single, row",
        height: 400,
        pageable: {
            previousNext: false,
            numeric: false,
            refresh: true,
            info: false,
            pageSizes: false
        },
        change: function (e) {
            getFromSelectRow();
        },
        dataBound: function (e) {
            count = mainGrid.dataSource.data().length;
        }
    }).data("kendoGrid");

    var selectedClass = 'k-state-selected';
    $(document).on('click', '#grid tbody tr', function (e) {
        if (e.ctrlKey || e.metaKey) {
            $(this).toggleClass(selectedClass);
        } else {
            $(this).addClass(selectedClass).siblings().removeClass(selectedClass);
        }
    });

    mainGrid.table.kendoDraggable({
        filter: "tbody tr",
        group: "gridGroup",
        axis: "y",
        hint: function (item) {
            var helper = $('<div class="k-grid k-widget drag-helper"/>');
            if (!item.hasClass(selectedClass)) {
                item.addClass(selectedClass).siblings().removeClass(selectedClass);
            }
            var elements = item.parent().children('.' + selectedClass).clone();
            item.data('multidrag', elements).siblings('.' + selectedClass).remove();
            return helper.append(elements);
        }
    });

    mainGrid.table.kendoDropTarget({
        group: "gridGroup",
        drop: function (e) {

            var draggedRows = e.draggable.hint.find("tr");
            e.draggable.hint.hide();
            var dropLocation = $(document.elementFromPoint(e.clientX, e.clientY)),
                dropGridRecord = mainDataSource.getByUid(dropLocation.parent().attr("data-uid"));
            if (dropLocation.is("th")) {
                return;
            }

            var beginningRangePosition = mainDataSource.indexOf(dropGridRecord), //beginning of the range of dropped row(s)
                rangeLimit = mainDataSource.indexOf(mainDataSource.getByUid(draggedRows.first().attr("data-uid"))); //start of the range of where the rows were dragged from


            if (rangeLimit > beginningRangePosition) {
                draggedRows.reverse();
            }

            draggedRows.each(function () {
                var thisUid = $(this).attr("data-uid"),
                    itemToMove = mainDataSource.getByUid(thisUid);
                mainDataSource.remove(itemToMove);
                mainDataSource.insert(beginningRangePosition, itemToMove);
            });

            draggedRows.each(function () {
                var thisUid = $(this).attr("data-uid");
                mainDataSource.getByUid(thisUid).set("dirty", true);
            });

            var dirtyItems = $.grep(mainDataSource.view(), function (f) {
                return f.dirty === true;
            });

            for (var a = 0; a < dirtyItems.length; a++) {
                var thisItem = dirtyItems[a];
                mainGrid.tbody.find("tr[data-uid='" + thisItem.get("uid") + "']").find("td:eq(0)").addClass("k-dirty-cell");
                mainGrid.tbody.find("tr[data-uid='" + thisItem.get("uid") + "']").find("td:eq(0)").prepend('<span class="k-dirty"></span>')
            };
        }
    });
}


function clearImgDiv() {
    
    $("#imgSrc").cropper("destroy");
    $("#imgSrc").removeAttr("src");
    $("#imgSrc").removeAttr("data-large");
    $(".img-container").hide();
}

function GetDataSourceToCar() {
    return new kendo.data.DataSource({
        transport: {
            read: {
                type: "POST",
                url: "/Handler/GetDataKendoList.ashx",
                dataType: "json",
                data: {
                    'isCar': true
                }
            }
        },
        schema: {
            model: {
                id: "Id",
                CarName: "CarName"
            }
        }
    });
}


function GetDataSourceToType(carId) {
    return new kendo.data.DataSource({
        transport: {
            read: {
                type: "POST",
                url: "/Handler/GetDataKendoList.ashx",
                dataType: "json",
                data: {
                    'isType': true,
                    'CarId': carId
                }
            }
        },
        schema: {
            model: {
                id: "Id",
                CarName: "TypeName"
            }
        }
    });
}


function GetDataSourceToGrid(carId) {

       var dataModel = kendo.data.Model.define({
            id: "Id",
            fields: {
                CarModel: { type: "string", editable: false },
                Color: { type: "string", editable: false },
                Engine: { type: "string", editable: false },
                Fuel: { type: "string", editable: false },
                TypeId: { editable: true },
                IssueDate: { type: "string", editable: false },
                ImgPath: { type: "string", editable: false }
            }
       });

        return new kendo.data.DataSource({
        schema: {
            model: dataModel
        },
        transport: {
            read: {
                type: "POST",
                url: "/Handler/GetDataKendoList.ashx",
                dataType: "json",
                data: {
                    "isModel": true,
                    "CarId": carId
                }
            }
        }

        });
}