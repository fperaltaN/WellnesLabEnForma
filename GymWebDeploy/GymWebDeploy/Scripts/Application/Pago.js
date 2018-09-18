CRUD = false;
//edit
var nameEntity = 'Pago';
var partners = [];
//form //edit
var partnerID = $('#partnerID');
var partnerNum = $('#partnerNum');
var partnerName = $('#partnerName');
var partnerPhone = $('#partnerPhone');

var packageName = $('#packageName');
var packageDescription = $('#packageDescription');
var packageCost = $('#packageCost');
var payType = $('#payType');
var userPay = $('#userPay');

function CreateObject() {
    data = {
        nombre: '',
        diaspaquetes: '',
        costo: '',
        descripcion: '',
        id_paquete: '',
        activo: '',
        ID_USUARIO: ''
    };
}

$(document).ready(function () {
    GETDataSingle(nameEntity + '/GetSocios/', '');
    CreateObject();
    partnerID.focus();
    partnerID.change(function () {
        var id_partner = 0;
        $.each(partners, function (partnersData, item) {
            if (item.id_socio == partnerID.val()) {
                partnerNum.val(item.num_socio);
                partnerName.val(item.nombre + " " + item.ap_paterno + " " + item.ap_materno);
                partnerPhone.val(item.telefono);
                id_partner = partnerID.val();
            }
        });
        data.id_paquete = id_partner ;
        GETDataSingle(nameEntity + '/GetPaqueteID/', data);
    });
});

function UpdateElement(response) {
    FillPartners(response);
}

function FillPartners(response) {
    partners = response;
    $('#partnerID option').remove();
    partnerID.append('<option value=0>Selecciona un socio...</option>');
    $.each(response, function (responseValue, item) {
        partnerID.append('<option value=' + item.id_socio + '>' + item.num_socio + " " + item.nombre + " " + item.ap_paterno + " " + item.ap_materno + '</option>');
    });
}