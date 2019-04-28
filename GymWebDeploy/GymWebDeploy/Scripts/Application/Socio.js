//Titulo para la exportación de archivos
var FileTitle = 'Catalogo de Socios';
// si crud true tiene grid si no es solo captura
CRUD = true;
note = false;
//edit
var nameEntity = 'Socio';
//form //edit
var partnerNumber = $('#partnerNumber');
var partnerName = $('#partnerName');
var partnerLast = $('#partnerLast');
var partnerLastM = $('#partnerLastM');
var partnerAddress = $('#partnerAddress');
var partnerPhone = $('#partnerPhone');
var partnerBorn = $('#partnerBorn');
var partnerEmail = $('#partnerEmail');
var partnerComp = $('#partnerComp');
//edit
var colModel = [
    { label: 'Opciones', name: 'Opciones', width: 30, formatter: CustomCellOptions },
    { label: 'Número', name: 'num_socio', width: 20 },
    { label: 'Nombre', name: 'nombre', width: 30 },
    { label: 'Ap. Paterno', name: 'ap_paterno', width: 30 },
    { label: 'Ap. Materno', name: 'ap_materno', width: 30 },
    { label: 'Domicilio', name: 'direccion', width: 50 },
    { label: 'Teléfono', name: 'telefono', width: 50 },
    { label: 'Fecha Nacimiento', name: 'fecha_nacimiento', width: 50, formatter: 'date', formatoptions: { newformat: 'Y/m/d' } },
    { label: 'Email', name: 'mail', width: 60 },
    { label: 'CompEstudios', name: 'compEstudios', width: 60 },
    { label: 'id_socio', name: 'id_socio', width: 0, hidden: true },
    { label: 'activo', name: 'activo', width: 0, hidden: true }
];
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

    if (getLastNumber) {
        GETDataSingle(nameEntity + '/GetSocioLastNum/', '');
    }
}
//edit
function FillInputs() {
    idDataSource = data.id_socio;
    partnerNumber.val(data.num_socio);
    partnerName.val(data.nombre);
    partnerLast.val(data.ap_paterno);
    partnerLastM.val(data.ap_materno);
    partnerAddress.val(data.direccion);
    partnerBorn.val(data.fecha_nacimiento);
    partnerPhone.val(data.telefono);
    partnerEmail.val(data.mail);
    partnerComp.val(data.compEstudios);
}
function GetInputs() {
    data.num_socio = partnerNumber.val();
    data.nombre = partnerName.val();
    data.ap_paterno = partnerLast.val();
    data.ap_materno = partnerLastM.val();
    data.direccion = partnerAddress.val();
    data.fecha_nacimiento = partnerBorn.val();
    data.telefono = partnerPhone.val();
    data.mail = partnerEmail.val();
    data.compEstudios = partnerComp.val();
}
function SetDeleteMsg() {
    SetDeleteData(' Socio NÚM: ' + data.num_socio + ' --- NOMBRE: ' + data.nombre + ' ' + data.ap_paterno + ' ' + data.ap_materno);
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

function UpdateElement(response) {
    //console.log(response);
    //poner id
    if (response[0].num_socio > 0) {
        partnerNumber.val(response[0].num_socio);
    }

}