

$(document).ready(function () {
    LoadGrid();
    PlusMinusButton();
    ChangePosition();
});


function ChangePosition() {
    $(".btn-position").click(function(e) {
        
        var type = $(this).attr("data-type");
  
    });
}


function PlusMinusButton() {
    $('.btn-number').click(function (e) {
        e.preventDefault();
        
        var fieldName = $(this).attr("data-field");
        var type = $(this).attr("data-type");
        var tbInput = $("input[name='" + fieldName + "']");
        var currenValue = parseInt(tbInput.val());

        if (!isNaN(currenValue)) {
            if (type == "minus") {
                if (currenValue > tbInput.attr("min")) {
                    tbInput.val(currenValue - 1).change();
                }
                if (parseInt(tbInput.val()) == tbInput.attr("min")) {
                    $(this).attr("disabled", true);
                }
            } else if (type == "plus") {
                if (currenValue < tbInput.attr("max")) {
                    tbInput.val(currenValue + 1).change();
                }
                if (parseInt(tbInput.val()) == tbInput.attr("max")) {
                    $(this).attr("disabled", true);
                }
            }
        } else {
            tbInput.val(0);
        }
    });

    $(".txt-number").change(function() {

        var minVal = parseInt($(this).attr("min"));
        var maxVal = parseInt($(this).attr("max"));
        var currentValue = parseInt($(this).val());

        var name = $(this).attr("name");
        if (currentValue >= minVal) {
            $(".btn-number[data-type='minus'][data-field='" + name + "']").removeAttr("disabled");
        } else {
            alert('Sorry, the minimum value was reached');
            $(this).val($(this).data("oldValue"));
        }

        if (currentValue <= maxVal) {
            $(".btn-number[data-type='plus'][data-field='" + name + "']").removeAttr('disabled');
        } else {
            alert('Sorry, the maximum value was reached');
            $(this).val($(this).data('oldValue'));
        }
    });

    $(".txt-number").focusin(function() {
        $(this).data('oldValue',$(this).val());
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


function LoadGrid() {
    var widthBlok = $("#jqg").parent().width();
    
    $("#jqg").jqGrid({
        url: 'Handler/GetData.ashx',
        datatype: 'json',
        mtype: 'POST',
        postData: {
            'lastpage': function() { return $("#jqg").getGridParam("lastpage") }
        },
        height: '250px',
        width: widthBlok,
        colNames: ['CarName', 'ModelName', 'TypeName', 'Color', 'Engine', 'Fuel', 'IssueDate', ''],
        colModel: [
            { name: 'CarName', index: 'CarName', width: 55},
            { name: 'CarModel', index: 'CarModel', width: 55},
            { name: 'CarType', index: 'CarType', width: 55},
            { name: 'Color', index: 'Color', width: 55 },
            { name: 'Engine', index: 'Engine', width: 55 },
            { name: 'Fuel', index: 'Fuel', width: 55},
            { name: 'IssueDate', index: 'IssueDate', width: 55 },
            { name: 'ImgPath', index: 'ImgPath', hidden: true }
        ],
        rowNum: 10, // число отображаемых строк
        rowList: [10, 20, 30],
        pager: 'GridPager',
        scroll: 1,
        rownumbers: true,
        rownumWidth: 40,
        recordpos: "left",
        sortname: 'CarName', // сортировка по умолчанию по столбцу Id
        sortorder: "asc", // порядок сортировки desc
        viewrecords: true,
        caption: "Список cars",
        onSelectRow: function (id) {
            var rowData = $("#jqg").getRowData(id);
            $("#imgSrc").attr("src", rowData["ImgPath"]);
            $(".btn-position").removeAttr("disabled");
        },
        loadComplate: function () {
           
        }
    });

    $("#jqg").jqGrid('sortableRows');
}