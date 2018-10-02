﻿CRUD = false;
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

var userPay = $('#userPay');
var userPending = $('#userPending');
var payType = $('#payType');
var userTotal = $('#userTotal');
var userPayGet = $('#pay');

var btnPay = $('#btnPay');

function CreateObject() {
    data = {
        nombre: '',
        diaspaquetes: '',
        costo: '',
        descripcion: '',
        id_paquete: '',
        activo: '',
        ID_USUARIO: '',
        fecha_pago_vence: '',
        pendiente: '',
        importe:''
    };
}
$(document).ready(function () {
    GETDataSingle(nameEntity + '/GetSocios/ ', '');
    CreateObject();
    partnerID.focus();
    partnerID.change(function () {
        var id_partner = 0;
        $.each(partners, function (partnersData, item) {
            if (item.id_socio == partnerID.val()) {
                console.log(item);
                partnerNum.val(item.num_socio);
                partnerName.val(item.nombre + " " + item.ap_paterno + " " + item.ap_materno);
                partnerPhone.val(item.telefono);
<<<<<<< HEAD
                id_partner = item.id_socio;
=======
                id_partner = partnerID.val();
                return false;
>>>>>>> 110056c103263769268c2a96e4c7e2a7cbbe8379
            }
        });
        data.id_socio = id_partner;
        var path = '../'+ nameEntity + '/GetPaqueteID/';
        ajaxPostCall(path, ReturnJson(data)).done(function (response) {
            packageName.val(response[0].nombre);
            packageDescription.val(response[0].descripcion);
            packageCost.val(response[0].costo);
            userPay.val(response[0].costo);
<<<<<<< HEAD
=======
            userPayGet.focus();
            return false;
>>>>>>> 110056c103263769268c2a96e4c7e2a7cbbe8379
        });

        var path = '../' + nameEntity + '/GetPendiente/';
        ajaxPostCall(path, ReturnJson(data)).done(function (response) {
            userPending.val(response[0].pendiente);
            userTotal.val(parseInt(packageCost.val()) + parseInt(userPending.val()));
        });
        userPayGet.focus();
    });

    btnPay.click(function () {
        MsgSuccess('info', 'Registrando Pago\n espere...');
        mode = 0;
        Save();
    });
});

function UpdateElement(response) {
    FillPartners(response);
}
function GetInputs() {
    id_paquete = data.id_paquete;
    data = {
        id_paquete: id_paquete ,
        id_socio: partnerID.val() ,
        ID_USUARIO: 1,
        fecha_pago_vence: 1,
        pendiente:0.00,
        importe: userPayGet.val()
    }
}
function FillPartners(response) {
    partners = response;
    $('#partnerID option').remove();
    $.each(response, function (responseValue, item) {
        partnerID.append('<option data-tokens="' + item.id_socio + '" value=' + item.id_socio + '>' + item.num_socio + " " + item.nombre + " " + item.ap_paterno + " " + item.ap_materno + '</option>');
    });
    $('.selectpicker').selectpicker();
    $('#partnerID').selectpicker('refresh');
}