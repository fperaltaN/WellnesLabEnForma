//Titulo para la exportación de archivos
var FileTitle = 'Inventario';
// si crud true tiene grid si no es solo captura
CRUD = true;
note = false;
//edit
var nameEntity = 'CatInventario';
//form //edit
var CatInventarioName = $('#CatInventarioName');
//edit
var colModel = [
    { label: 'Opciones', name: 'Opciones', width: 30, formatter: CustomCellOptions },
    { label: 'Id_cat_inventario', name: 'Id_cat_inventario', width: 0, hidden: true },
    { label: 'Nombre', name: 'nombre', width: 30 },
    { label: 'activo', name: 'activo', width: 0, hidden: true }
];
var colModelInventario = [
    { label: 'Opciones', name: 'Opciones', width: 5, formatter: CustomCellOptionsInventario },
    { label: 'Id_cat_inventario', name: 'Id_cat_inventario', width: 0, hidden: true },
    { label: 'Nombre', name: 'nombre', width: 5 },
    { label: 'Número de Control', name: 'Num_control', width: 5 },
    { label: 'activo', name: 'activo', width: 0, hidden: true }
];
//edit
function CreateObject(getLastNumber) {
    data = {
        Optiones: '',
        Id_cat_inventario: '',
        nombre: ''
    };
}
//edit
function FillInputs() {
    idDataSource = data.Id_cat_inventario;
    CatInventarioName.val(data.nombre);

}
function GetInputs() {
    data.Id_cat_inventario = idDataSource
    data.nombre = CatInventarioName.val();
}
function SetDeleteMsg() {
    SetDeleteData(' Inventario NÚM: ' + data.Id_cat_inventario + ' --- NOMBRE: ' + data.nombre);
}

function UpdateElement(response) {
    console.log(response);
    //poner id
    if (response[0].num_socio > 0) {
        partnerNumber.val(response[0].num_socio)
    }

}

function CustomCellOptionsInventario(cellValue, options, rowdata, action) {
    return '<button type="button" class="btn btn-sm btn-danger" onclick="ShowModalDelete()">' +
        '<img src="../Content/icons/baseline_delete_white_18dp.png" />' +
        '</button>';
}

function CustomCellOptions(cellValue, options, rowdata, action) {
    return '<button type="button" class="btn btn-sm btn-success " onclick="ShowModalUpdate()">' +
        '<img src="../Content/icons/baseline_edit_white_18dp.png" />' +
        '</button>' +
        '<button type="button" class="btn btn-sm btn-danger m-md-1" onclick="ShowModalDelete()">' +
        '<img src="../Content/icons/baseline_delete_white_18dp.png" />' +
        '</button>' +
        '<button type="button" class="btn btn-sm btn-warning" onclick="ShowInventario()">' +
        'Ver Inventario' +
        '</button>';
}

function CreateDataTableInventario(model) {
    DataTableInventario.jqGrid({
        viewrecords: true,
        datatype: "local",
        colModel: model,
        gridview: true,
        height: 'auto',
        width: 500,
        pager: "#DataTablePagerInventario"
    });
}

function updateTableInventario(grid, response) {
    grid.jqGrid('clearGridData');
    grid.jqGrid('setGridParam', { data: response });
    grid[0].grid.endReq();
    grid.trigger('reloadGrid');
}

function ShowInventario() {
    MsgSuccess('info', 'Cargando Información...');
    CreateDataTableInventario(colModelInventario);
    setTimeout(function () {
        var rowId = DataTable.jqGrid('getGridParam', 'selrow');
        var selectedData = DataTable.getRowData(rowId);
        data = selectedData;
        var path = '../Inventario/GetById/';
        ajaxPostCall(path, ReturnJson(data)).done(function (response) {
            console.log(response);
            updateTableInventario(DataTableInventario, response);
            MsgSuccess('success', 'Carga completa');
        });
    }, 100);
    $('#ModalInventario').modal();
}

var $saveNewInventario = $('#saveNewInventario');
$saveNewInventario.click(function () {
    $('#ModalInventarioADD').modal('toggle');
    console.log($('#NewAdd').val());
    var path = '../Inventario/Save/';
    var dataInv= {
        Num_control: $('#NewAdd').val(),
        Id_cat_inventario: data.Id_cat_inventario
    };
    ajaxPostCall(path, ReturnJson(dataInv)).done(function (response) {
        var path = '../Inventario/GetById/';
        ajaxPostCall(path, ReturnJson(data)).done(function (response) {
            console.log(response);
            updateTableInventario(DataTableInventario, response);
        });
    });
});


var $BtnAddInv = $('#BtnAddInv');
$BtnAddInv.click(function () {
    $('#ModalInventarioADD').modal();
});