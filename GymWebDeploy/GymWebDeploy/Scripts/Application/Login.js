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
        pass: passText.val()
    }
}

function login() {
    GetInputs();
    //ajaxPostCall(path, ReturnJson(data)).done(function (response) {
        ajaxPostCallAction(nameEntity, 'ValidateUser', ReturnJson(data)).done(function (response) {
        console.log(response);
        if (response.Success) {
            MsgSuccess('success', response.Message);
            var url = response.TargetURL ;
            window.location.href = url;
        }
        else {
            MsgSuccess('warning', response.Message);
        }
    });
}

//clean
function clean() {
   // $('#form')[0].reset();
}