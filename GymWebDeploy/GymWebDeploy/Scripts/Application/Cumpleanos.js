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
    { label: 'num_socio', name: 'num_socio', width: 40 },
    { label: 'nombre', name: 'nombre', width: 50 },
    { label: 'direccion', name: 'direccion', width: 30, hidden: true },
    { label: 'mail', name: 'mail', width: 50 },
    { label: 'Enviar', name: 'Enviar', width: 30, formatter: CustomCellOptionsCumple }
];

function CreateObject() {
    data = {
        id_socio: ''
        , num_socio: ''
        , nombre: ''
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

$(document).ready(function () {
    var path1 = '../' + publish + 'Cumpleanos/GetCumple/';
    ajaxPostCall(path1, '').done(function (response) {
        UpdateElementCumple(response);
    });
    $('#BtnAdd').toggle();
});