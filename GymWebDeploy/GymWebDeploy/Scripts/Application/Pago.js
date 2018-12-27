//Titulo para la exportación de archivos
var FileTitle = 'Catalogo de Pago';
// si crud true tiene grid si no es solo captura
CRUD = false;
note = false;
//edit
var nameEntity = 'Pago';
var FileTitle = "Pago";
var partners = [];
var data = {
    nombre: '',
    diaspaquetes: '',
    costo: '',
    descripcion: '',
    id_paquete: '',
    activo: '',
    ID_USUARIO: '',
    fecha_pago_vence: '',
    pendiente: '',
    refTicketVenta: '',
    importe: ''
};
//form //edit
var partnerID = $('#partnerID');
var partnerNum = $('#partnerNum');
var partnerName = $('#partnerName');
var partnerPhone = $('#partnerPhone');

var packageName = $('#packageName');
var packageDescription = $('#packageDescription');

var packageCost = $('#packageCost');
var userTotal = $('#userTotal');
var userPay = $('#userPay');


var payMonths = $('#payMonths');
var userPending = $('#userPending');
var payType = $('#payType');

var userRecargo = $('#userRecargo');
var userPayDate = $('#userPayDate');
var userPayGet = $('#pay');
var refTicketVenta = $('#refTicketVenta');

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
        refTicketVenta : '',
        importe: ''
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
                id_partner = item.id_socio;
                return false;
            }
        });
        data.id_socio = id_partner;


        var path = '../' + nameEntity + '/GetPaqueteID/';
        ajaxPostCall(path, ReturnJson(data)).done(function (response) {
            packageName.val(response[0].nombre);
            packageDescription.val(response[0].descripcion);
            packageCost.val(response[0].costo);
            data.id_paquete = response[0].id_paquete;

            var path = '../' + nameEntity + '/GetPendiente/';
            var date = new Date().getMonth();
            ajaxPostCall(path, ReturnJson(data)).done(function (response) {
                console.log(response);
                userPending.val(0);
                if (response.length > 0) {
                    userPending.val(response[0].pendiente == undefined ? 0 : response[0].pendiente);
                    date = new Date(response[0].fecha_pago_vence.match(/\d+/)[0] * 1);
                }
                console.log(date);
                var d = new Date().getMonth();
                var n = new Date(date).getMonth();
                var lastdd = new Date(date).getDate();
                var lastmm = new Date(date).getMonth();
                var lastyyyy = new Date(date).getFullYear();
                data.fecha_pago_vence = addMonth(lastyyyy, lastmm, lastdd);
                //ponemos las fechas del pago
                getDateNextPay(date);
                $('#userTotal').val(parseInt(packageCost.val()) + parseInt(userPending.val()));
                if ((parseInt(userPending.val()) > 0) && (d === n)) {
                    $('#userTotal').val(parseInt(packageCost.val()) + parseInt(userPending.val()));
                } else if (d === (n + 3)) {
                    userRecargo.val(30);
                    $('#userTotal').val(parseInt(packageCost.val()) + 30);
                } else if (d == (n + 6)) {
                    userRecargo.text(100);
                    $('#userTotal').val(parseInt(packageCost.val()) + 100);
                }
                userPay.val($('#userTotal').val());
                userPay.focus();
            });
            return false;
        });
    });
    //Calculo de total
    $('#userPending').change(function () {
        updateCost();
    });

    $('#userRecargo').change(function () {
        updateCost();
    });

    btnPay.click(function () {
        MsgSuccess('info', 'Registrando Pago\n espere...');
        mode = 0;
        Save();
        SavePendiente();
        payType.val(1)
        ticketRef();
    });

    payType.change(function () {
        ticketRef();
    });
    ticketRef();
});

function UpdateElement(response) {
    FillPartners(response);
}
function GetInputs() {
    id_paquete = data.id_paquete;
    vence = data.fecha_pago_vence,
    data = {
        id_paquete: id_paquete,
        id_socio: partnerID.val(),
        ID_USUARIO: 1,
        fecha_pago_vence: vence,
        pendiente: (parseInt(userTotal.val()) - parseInt(userPay.val())),
        refTicketVenta: refTicketVenta.val(),
        importe: userPay.val()
    }
    data.pendiente = (parseInt(userTotal.val()) - parseInt(userPay.val())).toString();
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

/*
 *  Realiza los cálculos automaticamente, obtieniendo los valores bajados.
 */
function updateCost() {
    var total = 0;
    total = parseInt($('#packageCost').val()) + (parseInt($('#userPending').val()) + parseInt($('#userRecargo').val()));
    $('#userTotal').val(total);
}
/*
* Guarda la información de los pagos
*/
function getDateNextPay(date) {
    switch (payMonths.val()) {
        case "1":
            date = now(date,1);
            break;
        case "3":
            date = now(date,3);
            break;
        case "6":
            date = now(date,6);
            break;
        case "9":
            date = now(date,9);
            break;
        case "12":
            date = now(date,12);
            break;
        default:
            date = date + 1;
    }
    userPayDate.val(data.fecha_pago_vence + ' - ' + date);
    data.fecha_pago_vence = date;/*
    data.importe = $('#userPay').val();
    data.pendiente = $('#userPending').val();*/
    data.refTicketVenta = refTicketVenta.val();
    
}

// Actual Date
function now(date, monthAdd) {  
    var today = new Date(date);
    var dd = today.getDate();
    var mm = today.getMonth();
    var yyyy = today.getFullYear();


    var dateEnd = new Date(yyyy, mm, dd);
    //Agregamos los nuevos meses
    dateEnd.setMonth(dateEnd.getMonth() + monthAdd);

    //Formamos la fecha 
    dd = dateEnd.getDate();
    mm = dateEnd.getMonth() + 1; //January is 0!
    yyyy = dateEnd.getFullYear();


    if (dd < 10) {
        dd = '0' + dd
    }

    if (mm < 10) {
        mm = '0' + mm
    }

    return dd + '/' + mm + '/' + yyyy ;
}

// Actual Date
function addMonth(yyyy, mm, dd) {
   
    var dateEnd = new Date(yyyy, mm, dd);
    //Agregamos los nuevos meses
    dateEnd.setMonth(dateEnd.getMonth());

    //Formamos la fecha 
    dd = dateEnd.getDate();
    mm = dateEnd.getMonth() + 1; //January is 0!
    yyyy = dateEnd.getFullYear();

    if (dd < 10) {
        dd = '0' + dd
    }

    if (mm < 10) {
        mm = '0' + mm
    }

    return dd + '/' + mm + '/' + yyyy;
}
//clean
function clean() {
    $('#form')[0].reset();
    $('#partnerID').val('');
    $('#partnerNum').val('');
    $('#partnerName').val('');
    $('#partnerPhone').val('');

    $('#packageName').val('');
    $('#packageDescription').val('');
    $('#packageCost').val(0);

    $('#userPending').val(0);
    $('#userTotal').val(0);
    $('#userRecargo').val(0);
}

function SavePendiente() {
    var dataRecargo = {
        id_socio: '',
        id_paquete: '',
        importe: ''
    };
    dataRecargo.id_socio = partnerID.val();
    dataRecargo.id_paquete = data.id_paquete;
    dataRecargo.importe = data.importe;

    ADDData('Recargo', dataRecargo);
    ADDData('PagoRecargo', '');

    clean();
}

//habilita la referencia del pago
function ticketRef() {
    if (payType.val() == 1) {
        refTicketVenta.prop('disabled', true);
        refTicketVenta.css("background-color", "#e2e3e5");
    } else if (payType.val() == 2){
        refTicketVenta.prop('disabled', false); 
        refTicketVenta.css("background-color", "white");
    }
    
}

//change de los meses a pagar
$('#payMonths').on('change', function () {
    var path = '../' + nameEntity + '/GetPendiente/';
    var date = new Date().getMonth();
    ajaxPostCall(path, ReturnJson(data)).done(function (response) {
        console.log(response);
        userPending.val(0);
        if (response.length > 0) {
            userPending.val(response[0].pendiente == undefined ? 0 : response[0].pendiente);
            date = new Date(response[0].fecha_pago_vence.match(/\d+/)[0] * 1);
        }
        console.log(date);
        var d = new Date().getMonth();
        var n = new Date(date).getMonth();
        var lastdd = new Date(date).getDate();
        var lastmm = new Date(date).getMonth();
        var lastyyyy = new Date(date).getFullYear();
        data.fecha_pago_vence = addMonth(lastyyyy, lastmm, lastdd);
        //ponemos las fechas del pago
        getDateNextPay(date);
    });
    return false;
});