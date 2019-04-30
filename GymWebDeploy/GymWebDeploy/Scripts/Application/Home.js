//Titulo para la exportación de archivos
var FileTitle = '';
// si crud true tiene grid si no es solo captura
CRUD = true;
note = true;
//edit
var nameEntity = 'Home';
///variable para el nombre del proyecto publicado puesto que cambian las rutas
//dejar en blanco si se trabaja de manera local
var publish = '';//'webdeploy/';
//form //edit
//edit

var DataTableCumple = $('#DataTableCumple');
function CreateDataTableCumple(modelCumple) {
    DataTableCumple.jqGrid({
        viewrecords: true,
        datatype: "local",
        colModel: modelCumple,
        gridview: true,
        height: 400,
        width: 600,
        //rowNum: 7,
        //pager: "#DataTablePager",
        rowattr: CheckActives
    });
}
var modelCumple = [
    { label: 'id_socio', name: 'id_socio', width: 30, hidden: true },
    { label: 'num_socio', name: 'num_socio', width: 40 },
    { label: 'nombre', name: 'nombre', width: 50 },
    { label: 'direccion', name: 'direccion', width: 30, hidden: true },
    { label: 'mail', name: 'mail', width: 50 },
    { label: 'Enviar', name: 'Enviar', width: 30, formatter: CustomCellOptionsCumple }
];
function CustomCellOptionsCumple(cellValue, options, rowdata, action) {
    return '<button type="button" class="btn btn-sm btn-success" onclick="SendMail(&#39;' + rowdata.mail + '&#39;)">' +
        '<img src="../' + publish +'Content/icons/baseline-assignment_turned_in-white-18/1x/baseline_assignment_turned_in_white_18dp.png" />' +
        '</button>';
}
//edit
function CreateObject(getLastNumber) {
    data = {
        Optiones: '',
        id_socio: '',
        num_socio: '',
        nombre: '',
        ap_paterno: '',
        ap_materno: '',
        fecha_nacimiento: '',
        telefono: '',
        mail: '',
        compEstudios: ''
    };
}
var colModel = [
    //{ label: 'Opciones', name: 'Opciones', width: 30, formatter: CustomCellOptions },
    { label: 'Id_inventario', name: 'Id_inventario', width: 30, hidden: true },
    { label: 'Nombre', name: 'catnombre', width: 30 },
    { label: '# Control', name: 'num_control', width: 30 },
    { label: 'ID Socio', name: 'id_socio', width: 30 },
    { label: 'Socio', name: 'socioName', width: 80 },
    { label: 'Entregar', name: 'Entregar', width: 30, formatter: CustomCellOptions }
];


function UpdateElementCumple(response) {
    updateTable(DataTableCumple, response);
}


var partnerID = $('#partnerID');
var inventario = $('#inventario');



partnerID.change(function () {
    inventarioData.Id_socio = partnerID.val();
});

function SendMail(socioMail) {
    var path = '../' + publish + 'Home/sendBirthDayMail/';
    ajaxPostCall(path, ReturnJson(socioMail)).done(function (response) {
        MsgSuccess('info', "El correo de felicitación ha sido enviado.");
    });
}