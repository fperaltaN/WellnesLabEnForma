//Modal 
var note = true
//Add elementts
var ModalData = $('#ModalData');
var ModalTitle = $('#ModalTitle');
function SetModalTitleAdd(title) { ModalTitle.text('Datos de nuevo ' + title); }
function ShowModalAdd() {
    mode = 0;
    CreateObject(true);
    ModalData.modal();
    document.getElementById("DataForm").reset();
    SetModalTitleAdd('Agregar ' + FileTitle);
}
//modal
//update
function ShowModalUpdate() {
    mode = 1;
    CreateObject();
    ModalData.modal();
    document.getElementById('DataForm').reset();
    SetModalTitleAdd('Actualizar ' + nameEntity);
    setTimeout(function () {
        var rowId = DataTable.jqGrid('getGridParam', 'selrow');
        var selectedData = DataTable.getRowData(rowId);
        data = selectedData;
        FillInputs(data);
    }, 100);
}
//modal
//delete elements
var ModalDelete = $('#ModalDelete');
var DeleteTitle = $('#DeleteTitle');
function SetDeleteTitle(title) { DeleteTitle.text(title); }
var DeleteDataMsg = $('#DeleteData');
function SetDeleteData(title) { DeleteDataMsg.text(title); }
//delete
function ShowModalDelete() {
    setTimeout(function () {
        var rowId = DataTable.jqGrid('getGridParam', 'selrow');
        var selectedData = DataTable.getRowData(rowId);
        data = selectedData;
        SetDeleteMsg();
        FillInputs(data);
    }, 100);
    ModalDelete.modal();
}
//datatable
//data
var DataTable = $('#DataTable');
var DataTableInventario = $('#DataTableInventario');
var CardTitle = $('#CardTitle');
function SetCardTitle(title) { CardTitle.text('Administración de '+title); }
//add
var BtnAdd = $('#BtnAdd');
function SetBtnAddTitle(title) { BtnAdd.text('Agregar '+title); }
BtnAdd.click(function () { ShowModalAdd(); });
//export buttons
var ExportExcel = $('#ExportExcel');
ExportExcel.click(function () {
    DataTable.jqGrid("exportToExcel", {
        includeLabels: true,
        includeGroupHeader: true,
        includeFooter: true,
        fileName: FileTitle + ".xlsx",
        maxlength: 40 // maxlength for visible string data 
    });
});
var ExportPDF = $('#ExportPDF');
ExportPDF.on("click", function () {
    DataTable.jqGrid("exportToPdf", {
        title: 'Empleados',
        orientation: 'portrait',
        pageSize: 'A4',
        description: 'Datos en sistema',
        customSettings: null,
        download: 'download',
        includeLabels: true,
        includeGroupHeader: true,
        includeFooter: true,
        fileName: FileTitle + ".pdf"
    });
});
var ExportCSV = $('#ExportCSV');
ExportCSV.on("click", function () {
    DataTable.jqGrid("exportToCsv", {
        separator: ",",
        separatorReplace: "", // in order to interpret numbers
        quote: '"',
        escquote: '"',
        newLine: "\r\n", // navigator.userAgent.match(/Windows/) ?	'\r\n' : '\n';
        replaceNewLine: " ",
        includeCaption: true,
        includeLabels: true,
        includeGroupHeader: true,
        includeFooter: true,
        fileName: FileTitle + ".csv",
        returnAsString: false
    });
});
var PrintData = $('#PrintData');
PrintData.on("click", function () {
    DataTable.jqGrid("exportToHtml", {
        includeLabels: true,
        includeGroupHeader: true,
        includeFooter: true,
        autoPrint: true
    });
});
//add
function Save() {
    GetInputs();
    if (!data.hasOwnProperty('ACTIVO')) {
        data.activo = 'true';
    }
    if (mode === 0) {
        ADDData(nameEntity, data);
    } else {
        data.id_socio = idDataSource;
        UPDATEData(nameEntity, data);
    }
}
//delete
function Delete() {
    mode = 2;
    GetInputs();
    if (!data.hasOwnProperty('ACTIVO')) {
        data.activo = 'false';
    }
    UPDATEData(nameEntity, data);
}