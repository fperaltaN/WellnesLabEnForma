//Titulo para la exportación de archivos
var FileTitle = 'Cumpleaños';
// si crud true tiene grid si no es solo captura
CRUD = true;
note = false;
//edit
var nameEntity = 'Cumpleanos';
///variable para el nombre del proyecto publicado puesto que cambian las rutas
//dejar en blanco si se trabaja de manera local
var publish = '';//'webdeploy/';
//form //edit
//edit
var colModel = [
    { label: 'id_socio', name: 'id_socio', width: 30, hidden: true },
    { label: 'num_socio', name: 'num_socio', width: 40, align: 'center' }, 
    { label: 'nombre', name: 'nombre', width: 50, align: 'center' },
    { label: 'fecha nacimiento', name: 'fecha_nacimiento', width: 50,  formatter: 'date', formatoptions: { newformat: 'Y/m/d' }, align: 'center', sorttype: "date" },
    { label: 'direccion', name: 'direccion', width: 30, hidden: true, align: 'center' },
    { label: 'mail', name: 'mail', width: 50, align: 'center' },
    { label: 'Enviar', name: 'Enviar', width: 30, formatter: CustomCellOptionsCumple }
];

function CreateObject() {
    data = {
        id_socio: ''
        , num_socio: ''
        , nombre: ''
        , fecha_nacimiento : ''
        , direccion: ''
        , mail: ''
        , Enviar: 1
    };
}

function CustomCellOptionsCumple(cellValue, options, rowdata, action) {
    return '<button type="button" class="btn btn-sm btn-success" onclick="SendMail(&#39;' + rowdata.mail + '&#39;)">' +
        '<img src="../' + publish + 'Content/icons/baseline-assignment_turned_in-white-18/1x/baseline_assignment_turned_in_white_18dp.png" />' +
        '</button>';
}

function SendMail(socioMail) {
    var path = '../' + publish + 'Cumpleanos/sendBirthDayMail/';
    ajaxPostCall(path, ReturnJson(socioMail)).done(function (response) {
        MsgSuccess('info', "El correo de felicitación ha sido enviado.");
    });
}

function UpdateElementCumple(response) {
    //updateTable(DataTableCumple, response);
}

function GetDataCumpleDate() {
    var dataDates = {
        start: $('#start').val(),
        end: $('#end').val()
    };
    var path = '../' + nameEntity + '/GetCumpleByDate/';
    MsgSuccess('info', 'Cargando Información...');
    ajaxPostCall(path, ReturnJson(dataDates)).done(function (response) {
        console.log(response);
        updateTable(DataTable, response);
    });
}
function now() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd;
    }

    if (mm < 10) {
        mm = '0' + mm;
    }

    //today = yyyy +'/' + mm + '/' + dd;
    today = dd + '/' + mm + '/' + yyyy;
    return today;
}

$('#datepicker').datepicker({
    //format: 'yyyy/mm/dd',
    format: 'dd/mm/yyyy',
    clearBtn: true,
    todayHighlight: true,
    language: 'es',
    orientation: 'bottom auto',
    calendarWeeks: true,
    autoclose: true
});

$(document).ready(function () {
    var path1 = '../' + publish + 'Cumpleanos/GetCumple/';
    ajaxPostCall(path1, '').done(function (response) {
        UpdateElementCumple(response);
    });
    $('#start').val(now());
    $('#end').val(now());
    $('#BtnReport').click(function () {
        GetDataCumpleDate();
    });
    $('#BtnAdd').toggle();
});