CRUD = false;
//edit
var nameEntity = 'Login';
//form //edit
var userText = $('#partnerID');
var passText = $('#partnerNum');
var path = '../' + nameEntity + '/ValidateUser/';
var btnLogin = $('#btnPay');
//
function CreateObject() {
    data = {
        user: '',
        pass: ''
    };
}

$(document).ready(function () {
    CreateObject();
    btnPay.click(function () {
        MsgSuccess('info', 'Ingresando al sistema\n espere...');
        mode = 0;
        login();
        clean();
    });
});

function GetInputs() {
    data = {
        user: userText.val(),
        id_socio: passText.val()
    }
}

function login() {
    GetInputs();
    ajaxPostCall(path, ReturnJson(data)).done(function (response) {
        console.log(response);
        if (response.Success) {
            window.location.href = response.TargetURL;
        }
    });
}

//clean
function clean() {
    $('#form')[0].reset();
}