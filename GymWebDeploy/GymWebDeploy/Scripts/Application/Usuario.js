//Titulo para la exportación de archivos
var FileTitle = 'Catalogo de Usuarios';
// si crud true tiene grid si no es solo captura
CRUD = true;
note = false;
//edit
var nameEntity = 'Usuario';
//form //edit
//form //edit
var userName = $('#userName');
var userLast = $('#userLast');
var userLastM = $('#userLastM');
var userUser = $('#userUser');
var userPassword = $('#userPassword');
//var userPerfil = $('#userPerfil');
var userType = $('#userType');
//edit
var colModel = [
    { label: 'Opciones', name: 'Opciones', width: 20, formatter: CustomCellOptions },
    { label: 'Nombre', name: 'NOMBRE', width: 30 },
    { label: 'Ap. Paterno', name: 'APELLIDO_PAT', width: 30 },
    { label: 'Ap. Materno', name: 'APELLIDO_MAT', width: 30 },
    { label: 'Usuario', name: 'USUARIO', width: 30 },
    { label: 'Password', name: 'PASSWORD', width: 30, hidden: true  },
    { label: 'Perfil', name: 'PERFIL', width: 30 },
    { label: 'id_perfil', name: 'ID_PERFIL', width: 0, hidden: true },
    { label: 'id_area', name: 'ID_AREA', width: 0, hidden: true },
    { label: 'id_usuario', name: 'ID_USUARIO', width: 0, hidden: true },
    { label: 'activo', name: 'ACTIVO', width: 0, hidden: true}
];
//edit
function CreateObject(getLastNumber) {
    data = {
        ID_USUARIO: "",
        NOMBRE: "",
        APELLIDO_PAT: "",
        APELLIDO_MAT: "",
        ID_AREA: "",
        USUARIO: "",
        PASSWORD: "",
        ID_PERFIL: "",
        PERFIL: "",
        //ACTIVO: "",
        CREADOPOR: "",
        ACTUALIZADOPOR: ""
    };
    GETDataSingle(nameEntity + '/GetPerfiles/', '');

}
//edit
function FillInputs() {
    idDataSource = data.ID_USUARIO;
    userName.val(data.NOMBRE);
    userLast.val(data.APELLIDO_PAT);
    userLastM.val(data.APELLIDO_MAT);
    userUser.val(data.USUARIO);
    userPassword.val(data.PASSWORD);
    //userPerfil.val(data.PERFIL);
    userType.val(data.ID_PERFIL);
}
function GetInputs() {
    data.NOMBRE = userName.val();
    data.APELLIDO_PAT = userLast.val();
    data.APELLIDO_MAT = userLastM.val();
    data.USUARIO = userUser.val();
    data.PASSWORD= userPassword.val();
    //data.PERFIL = userPerfil.val();
    data.ID_PERFIL = userType.val();
}
function SetDeleteMsg() {
    SetDeleteData(' Usuario  --- NOMBRE: ' + data.nombre + ' ' + data.ap_paterno + ' ' + data.ap_materno);
}

function UpdateElement(response) {
    console.log(response);
    //poner id
    if (response[0].num_empleado > 0) {
        userNumber.val(response[0].num_empleado)
    }
    else if (response[0].ID_PERFIL > 0) {
        $('#userType option').remove();
        $.each(response, function (responseValue, item) {
            userType.append('<option value=' + item.ID_PERFIL + '>' + item.PERFIL + '</option>');
        });
    }

}