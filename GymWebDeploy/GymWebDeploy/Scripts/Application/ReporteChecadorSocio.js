//Titulo para la exportación de archivos
var FileTitle = 'Catalogo de Reporte de Checador de Socios';
// si crud true tiene grid si no es solo captura
CRUD = true;
note = false;
//edit
var nameEntity = 'ReporteChecadorSocio';
var dataDate = {};
//form //edit
//edit
var colModel = [
    //{ label: 'Opciones', name: 'Opciones', width: 30, formatter: CustomCellOptions },
    { label: 'Nombre Socio', name: 'nombre', width: 60 },
    { label: 'Num Socio', name: 'num_socio', width: 70 }  
    { label: 'Registro Entrada', name: 'entrada', width: 35, formatter: 'date', formatoptions: { newformat: 'dd-MM-yy' }, align: 'center', },
    { label: 'Hora Entrada', name: 'entrada', width: 35, formatter: 'date', formatoptions: { newformat: 'HH:mm:ss' }, align: 'center', },
    { label: 'Registro salida', name: 'salida', width: 35, formatter: 'date', formatoptions: { newformat: 'MM/dd/yy' }, align: 'center', },
    { label: 'Hora Entrada', name: 'salida', width: 35, formatter: 'date', formatoptions: { newformat: 'HH:mm:ss' }, align: 'center', },
    { label: 'id_socio', name: 'id_socio', width: 0, hidden: true }
];
//edit
function CreateObject() {
    data = {
        nombre: '',
        num_socio,
        entrada: '',
        salida: '',
        id_socio: ''
    };
}
//edit
function FillInputs() {
    
}
function SetDeleteMsg() {
    //SetDeleteData(' Socio NÚM: ' + data.num_socio + ' --- NOMBRE: ' + data.nombre + ' ' + data.ap_paterno + ' ' + data.ap_materno);
}
$('#datepicker').datepicker({
    //format: 'yyyy/mm/dd',
    format: 'dd/mm/yyyy',
    clearBtn: true,
    language: 'es',
    orientation: 'bottom auto',
    calendarWeeks: true,
    autoclose: true
});

//Esconde el botón del  CRUD
$('#BtnAdd').hide();

function GetDataDate() {
    var dataDates = {
        start: $('#start').val(),
        end: $('#end').val()
    };
    var path = '../' + nameEntity + '/GetByDate/';
    MsgSuccess('info', 'Cargando Información...');
    ajaxPostCall(path, ReturnJson(dataDates)).done(function (response) {
        console.log(response);
        updateTable(DataTable, response);
    });
}

$(document).ready(function () {
    $('#start').val(now());
    $('#end').val(now());
    $('#BtnReport').click(function () {
        GetDataDate();
    });
    GetDataDate();

  
});

function now() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd
    }

    if (mm < 10) {
        mm = '0' + mm
    }

    //today = yyyy +'/' + mm + '/' + dd;
    today = dd + '/' + mm + '/' + yyyy;
    return today;
}