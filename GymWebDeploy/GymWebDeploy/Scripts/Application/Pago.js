// si crud true tiene grid si no es solo captura
CRUD = false;
//edit
var nameEntity = 'Pago';
//form //edit
var packageName = $('#packageName');

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
    data.id_paquete = 1;
    GETDataSingle(nameEntity + '/GetPaqueteID/', data);
});