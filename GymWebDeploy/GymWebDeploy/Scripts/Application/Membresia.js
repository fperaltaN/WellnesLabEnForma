//Titulo para la exportación de archivos
var FileTitle = 'Catalogo de Historial Medico';
// si crud true tiene grid si no es solo captura
CRUD = true;
note = false;
//edit
var nameEntity = 'Membresia';
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
    { label: 'Opciones', name: 'Opciones', width: 10, formatter: CustomCellOptions },
    { label: 'Nombre', name: 'nombre', width: 20 },
    { label: 'Costo', name: 'costo', width: 20 },
    { label: 'Descripción', name: 'descripcion', width: 50 },
    { label: 'id_membresia', name: 'id_membresia', width: 0, hidden: true }
];
//edit
function CreateObject() {
    data = {
        id_membresia: "",
        nombre: "",
        descripcion: "",
        costo: "",
        activo: ""
    };
}
//edit
function FillInputs() {
    idDataSource = data.id_socio;
    partnerNumber.val(data.num_socio);;
}
function GetInputs() {
    data.num_socio = partnerNumber.val();
}
function SetDeleteMsg() {
    SetDeleteData(' Socio NÚM: ' + data.num_socio + ' --- NOMBRE: ' + data.nombre + ' ' + data.ap_paterno + ' ' + data.ap_materno);
}
$('#datepicker').datepicker({
    format: 'yyyy/mm/dd',
    clearBtn: true,
    language: 'es',
    orientation: 'bottom auto',
    calendarWeeks: true,
    autoclose: true
});