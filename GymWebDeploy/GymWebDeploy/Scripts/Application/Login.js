//Titulo para la exportación de archivos
var FileTitle = 'Catalogo de Login';
// si crud true tiene grid si no es solo captura
CRUD = false;
note = false;
//edit
var nameEntity = 'Login';
//form //edit
var userText = $('#userText');
var passText = $('#passText');
var path = '../' + nameEntity + '/ValidateUser/';
var btnLogin = $('#btnLogin');
//
function CreateObject() {
    data = {
        user: '',
        pass: ''
    };
}

$(document).ready(function () {
    CreateObject();
    btnLogin.click(function () {
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