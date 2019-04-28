//Titulo para la exportación de archivos
var FileTitle = 'Catalogo de Socio Membresia';
// si crud true tiene grid si no es solo captura
CRUD = true;
note = false;
//edit
var nameEntity = 'SocioMembresia';
//form //edit
var partnerID = $('#partnerID');
var packageID = $('#packageID');
var partners = [];
var package = [];
//edit
var colModel = [
    { label: 'Opciones', name: 'Opciones', width: 10, formatter: CustomCellOptions },
    { label: 'Num. Socio', name: 'num_socio', width: 15 },
    { label: 'Nombre', name: 'nombre', width: 25 },
    { label: 'Paquete', name: 'paquete', width: 25 },
    { label: 'Descripción', name: 'descripcion', width: 50 },
    { label: 'id_socio_membresia', name: 'id_socio_membresia', width: 0, hidden: true },
    { label: 'id_socio', name: 'id_socio', width: 0, hidden: true },
    { label: 'id_paquete', name: 'id_paquete', width: 0, hidden: true },
    { label: 'activo', name: 'activo', width: 0, hidden: true }
];
//edit
function CreateObject() {
    data = {
        id_socio_membresia: "",
        id_socio: "",
        id_paquete: "",
        num_socio: "",
        nombre: "",
        paquete: "",
        activo: "",
        descripcion:""
    };
    $('#socio').show();
    document.getElementById('packageID').value = 0;
    $('#partnerID').selectpicker('refresh');
}
$(document).ready(function () {
    GETDataSingle(nameEntity + '/GetSocios/ ', '');
    CreateObject();
    partnerID.focus();
    
    var path = '../' + nameEntity + '/GetPaquetes/';
    ajaxPostCall(path, ReturnJson(data)).done(function (response) {
        FillPackage(response)
    });
});

//edit
function FillInputs() {
    idDataSource = data.id_socio_membresia;
    //document.getElementById('partnerID').value=data.id_socio;
    $('#socio').hide();
    document.getElementById('packageID').value =data.id_paquete;
    $('.selectpicker').selectpicker('refresh');
    //partnerID.val(data.num_socio);
    //packageID.val(data.id_paquete);
}
function GetInputs() {
    data.id_socio_membresia = data.id_socio_membresia;
    data.id_socio = partnerID.val();
    data.id_paquete = packageID.val();
}
function SetDeleteMsg() {
    data.activo = 0;
    SetDeleteData(' Socio NÚM: ' + data.num_socio + ' --- paquete: ' + data.paquete + ' ' + data.descripcion );
}
function UpdateElement(response) {
    console.log(response);
    //poner id
    FillPartners(response);
   
}
function FillPartners(response) {
    partners = response;
    $('#partnerID option').remove();
    $.each(response, function (responseValue, item) {
        partnerID.append('<option value=' + item.id_socio + '>' + item.num_socio + '-' + item.nombre_Completo + '</option>');
    });
    //$('.selectpicker').selectpicker();
    $('#partnerID').selectpicker('refresh');
}
function FillPackage(response) {
    package = response;
    $('#packageID option').remove();
    $.each(response, function (responseValue, item) {
        packageID.append('<option value=' +  item.id_paquete + '>' + item.id_paquete + ".-" + item.descripcion  + '</option>');
    });
    //$('.selectpicker').selectpicker();
    $('#packageID').selectpicker('refresh');
}
