//Titulo para la exportación de archivos
var FileTitle = 'Catalogo de Reporte de Pago';
// si crud true tiene grid si no es solo captura
CRUD = true;
note = false;
//edit
var nameEntity = 'ReportePago';
var dataDate = {};
//form //edit
//edit
datePick = function (elem) {
    jQuery(elem).datepicker({
        dateFormat: "yy-mm-dd"
    });
}
var colModel = [
    //{ label: 'Opciones', name: 'Opciones', width: 30, formatter: CustomCellOptions },
    { label: 'Nombre Socio', name: 'nombre', width: 60, search: true },
    { label: 'Paquete', name: 'paquete', width: 40, search: true },
    { label: 'Fecha Pago', name: 'fecha_pago', width: 35, formatter: 'date', formatoptions: { newformat: 'Y/m/d' }, align: 'center', sorttype: "date"},
    {
        label: 'Fecha Vence', name: 'fecha_pago_vence', width: 35, hidden: true, formatter: 'date', formatoptions: { newformat: 'Y/m/d' }, align: 'center', sorttype: "date",
        searchoptions: {
            dataInit: datePick,
            title: 'Select Date'
        }
    },
    { label: 'Meses pagados', name: 'meses', width: 35  },
    { label: 'Empleado Registro', name: 'empleado', width: 70 },
    {
        label: '$ Recibido', name: 'importe', width: 40, formatter: 'number',
        formatoptions: { decimalSeparator: ".", thousandsSeparator: " ", decimalPlaces: 2, defaultValue: '0.00' },
        align: 'center',},
    {
        label: '$ Pendiente', name: 'pendiente', width: 40, formatter: 'number',
        formatoptions: {  decimalSeparator: ".", thousandsSeparator: " ", decimalPlaces: 2, defaultValue: '0.00' },
        align: 'center', },    
    { label: 'id_pago', name: 'id_pago', width: 0, hidden: true },
    { label: 'id_socio', name: 'id_socio', width: 0, hidden: true },
    { label: 'id_paquete', name: 'id_paquete', width: 0, hidden: true },
    { label: 'activo', name: 'activo', width: 0, hidden: true }
];
//edit
function CreateObject() {
    data = {
        //Optiones: '',
        id_pago: '',
        id_paquete: '',
        id_socio: '',
        ID_USUARIO: '',
        nombre: '',
        paquete: '',
        fecha_pago: '',
        fecha_pago_vence: '',
        meses: '',
        empleado: '',
        pendiente: '',
        activo: ''
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
    todayHighlight: true,
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