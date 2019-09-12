//Titulo para la exportación de archivos
var FileTitle = 'Control Inventario';
// si crud true tiene grid si no es solo captura
CRUD = true;
note = false;
//edit
var nameEntity = 'ControlInventario';
//form //edit
var CatInventarioName = $('#ControlInventarioName');
///variable para el nombre del proyecto publicado puesto que cambian las rutas
//dejar en blanco si se trabaja de manera local
var publish = '';//'webdeploy/';
//form //edit
//edit
//var DataTable = $('#DataTable');
var inventario = $('#inventario');
var BtnAddInventario = $('#BtnAddInventario');
var partnerIDControl = $('#partnerIDControl');
var inventarioControl = $('#inventarioControl');
//edit
var colModel = [
    //{ label: 'Opciones', name: 'Opciones', width: 30, formatter: CustomCellOptions },
    { label: 'Id_inventario', name: 'Id_inventario', width: 30, hidden: true },
    { label: 'Nombre', name: 'catnombre', width: 30 },
    { label: '# Control', name: 'num_control', width: 30 },
    { label: 'ID Socio', name: 'id_socio', width: 30 },
    { label: 'Socio', name: 'socioName', width: 80 },
    { label: 'Entregar', name: 'Entregar', width: 30, formatter: CustomCellOptions }
];
function CreateObject() {
    data = {
        Id_inventario: ''
        , catnombre: ''
        , num_control: ''
        , id_socio: ''
        , socioName: ''
        , Entregar: 1
    };
}

//function CreateDataTable(model) {
//    DataTable.jqGrid({
//        viewrecords: true,
//        datatype: "local",
//        colModel: model,
//        gridview: true,
//        height: 400,
//        width: 600,
//        //rowNum: 7,
//        //pager: "#DataTablePager",
//        rowattr: CheckActives
//    });
//}

function CustomCellOptions(cellValue, options, rowdata, action) {
    return '<button type="button" class="btn btn-sm btn-success" onclick="updateInventario(' + rowdata.Id_inventario + ')">' +
        '<img src="../' + publish + 'Content/icons/baseline-assignment_turned_in-white-18/1x/baseline_assignment_turned_in_white_18dp.png" />' +
        '</button>';
}


var inventarioDataControl = {
    Id_inventario: ''
    , Num_control: ''
    , Id_socio: ''
    , Activo: 1
};



function updateInventario(id_inventario) {
    var path = '../' + publish + 'ControlInventario/UpdateControlInventario/';
    inventarioDataControl.Id_inventario = id_inventario;
    //console.log(inventarioData);
    ajaxPostCall(path, ReturnJson(inventarioDataControl)).done(function (response) {
        UpdateInv();
    });
}

function UpdateElementInv(response) {
    //console.log(response);
    updateTable(DataTable, response);
}

function UpdateInv() {
    var path = '../' + publish + 'Pago/GetSocios/';
    ajaxPostCall(path, ReturnJson('')).done(function (response) {
        $('#partnerIDControl option').remove();
        $.each(response, function (responseValue, item) {
            if (item.activo) {
                partnerIDControl.append('<option data-tokens="' + item.id_socio + '" value=' + item.id_socio + '>' + item.num_socio + " " + item.nombre + " " + item.ap_paterno + " " + item.ap_materno + '</option>');
            }
        });
        $('#partnerIDControl').selectpicker();
        $('#partnerIDControl').selectpicker('refresh');
    });
     path = '../' + publish + 'ControlInventario/GetControlInventario/';
    ajaxPostCall(path, ReturnJson('')).done(function (response) {
        $('#inventario option').remove();
        $.each(response, function (responseValue, item) {
            inventarioControl.append('<option data-tokens="' + item.Id_inventario + '" value=' + item.Id_inventario + ' data-numControl=' + item.num_control + '>' + item.nombre + " --- " + item.num_control + '</option>');
        });
        $('#inventario').selectpicker();
        $('#inventario').selectpicker('refresh');
        UpdateElementInv(response);
    });
}

$(document).ready(function () {
    UpdateInv();

    $('#BtnAdd').click(function () {
        var path = '../' + publish + 'Pago/GetSocios/';
        ajaxPostCall(path, ReturnJson('')).done(function (response) {
            $('#partnerIDControl option').remove();
            $.each(response, function (responseValue, item) {
                partnerIDControl.append('<option data-tokens="' + item.id_socio + '" value=' + item.id_socio + '>' + item.num_socio + " " + item.nombre + " " + item.ap_paterno + " " + item.ap_materno + '</option>');
            });
            $('#partnerIDControl').selectpicker();
            $('#partnerIDControl').selectpicker('refresh');
        });
        path = '../' + publish + 'ControlInventario/GetControlInventarioAsignado/';
        ajaxPostCall(path, ReturnJson('')).done(function (response) {
            $('#inventarioControl option').remove();
            $.each(response, function (responseValue, item) {
                inventarioControl.append('<option data-tokens="' + item.Id_inventario + '" value=' + item.Id_inventario + ' data-numControl=' + item.num_control + '>' + item.nombre + " --- " + item.num_control + '</option>');
            });
            $('#inventarioControl').selectpicker();
            $('#inventarioControl').selectpicker('refresh');
        });
    });
    $('#btnUpdateInventario').click(function () {

        var path = '../' + publish + 'ControlInventario/SaveControlInventarioAsignado/';
        console.log(inventarioDataControl);
        ajaxPostCall(path, ReturnJson(inventarioDataControl)).done(function (response) {
            //console.log(response);
            $('#ModalData').modal("toggle");
            UpdateInv();
        });
    });

    inventarioControl.on("change", function () {
        inventarioDataControl.Id_inventario = inventarioControl.val();
        inventarioDataControl.Id_socio = partnerIDControl.val();
        var dataname = $("option[value=" + $(this).val() + "]", this).attr('data-numcontrol');
        inventarioDataControl.Num_control = dataname;
    });

});