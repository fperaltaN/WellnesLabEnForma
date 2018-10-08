//Titulo para la exportación de archivos
var FileTitle = 'Catalogo de Historial Medico';
// si crud true tiene grid si no es solo captura
CRUD = true;
//edit
var nameEntity = 'HistorialMedico';
//form //edit
var Problema_Cardiaco = $('#ProblemaCardiaco');
var Dolor_Pecho = $('#DolorPecho');
var Asma = $('#Asma');
var Presion_Alta = $('#PresionAlta');
var Medicamento = $('#Medicamento');
var Neurologicos = $('#Neurologicos');
var Riesgo_Cardiovascular = $('#RiesgoCardiovascular');
var Dolencias = $('#Dolencias');
var Enfermedad = $('#Enfermedad');
var SocioId = $('#SocioId');
//edit
var colModel = [
    { label: 'Opciones', name: 'Opciones', width: 20, formatter: CustomCellOptions },
    { label: 'Número', name: 'num_socio', width: 15 },
    { label: 'Nombre Completo', name: 'nombre_Completo', width: 50 },
    { label: 'Problema Cardiaco', name: 'problema_Cardiaco', width: 35 },
    { label: 'Dolor Pecho', name: 'dolor_Pecho', width: 30, hidden: true },
    { label: 'Asma', name: 'asma', width: 20 },
    { label: 'Presion Alta', name: 'presion_Alta', width: 30 },
    { label: 'Medicamento', name: 'medicamento', width: 50 },
    { label: 'Neurologicos', name: 'neurologicos', width: 30, hidden: true },
    { label: 'Riesgo Cardiovascular', name: 'riesgo_Cardiovascular', width: 30, hidden: true },
    { label: 'Dolencias', name: 'dolencias', width: 30 },
    { label: 'Enfermedad', name: 'enfermedad', width: 30 },
    { label: 'id_historial_medico', name: 'id_historial_medico', width: 30, hidden: true },
    { label: 'id_socio', name: 'id_socio', width: 30, hidden: true },
    { label: 'Activo', name: 'activo', width: 30, hidden: true },
];
//edit
function CreateObject(getLastNumber) {
    data = {
        id_historial_medico: "",
        id_socio: "",
        num_Socio: "",
        nombre_Completo: "",
        problema_Cardiaco: "",
        dolor_Pecho: "",
        asma: "",
        presion_Alta: "",
        medicamento: "",
        neurologicos: "",
        riesgo_Cardiovascular: "",
        dolencias: "",
        enfermedad: ""
    };
    /*if (getLastNumber) {
        GETDataSingle(nameEntity + '/GetEmpleadoLastNum/', '');        
    }*/
    GETDataSingle(nameEntity + '/GetSocios/', '');

}
//edit
function FillInputs() {
    idDataSource = data.id_socio;
    Problema_Cardiaco.val(data.problema_Cardiaco);
    Dolor_Pecho.val(data.dolor_Pecho);
    Asma.val(data.asma);
    Presion_Alta.val(data.presion_Alta);
    Medicamento.val(data.medicamento);
    Neurologicos.val(data.neurologicos);
    Riesgo_Cardiovascular.val(data.riesgo_Cardiovascular);
    Dolencias.val(data.dolencias);
    Enfermedad.val(data.enfermedad);
}
function GetInputs() {
    data.id_socio = SocioId.val();
    data.problema_Cardiaco = Problema_Cardiaco.val();
    data.dolor_Pecho = Dolor_Pecho.val();
    data.asma = Asma.val();
    data.presion_Alta = Presion_Alta.val();
    data.medicamento = Medicamento.val();
    data.neurologicos = Neurologicos.val();
    data.riesgo_Cardiovascular = Riesgo_Cardiovascular.val();
    data.dolencias = Dolencias.val();
    data.enfermedad = Enfermedad.val();
}
function SetDeleteMsg() {
    SetDeleteData(' Socio NÚM: ' + data.num_socio + ' --- NOMBRE: ' + nombre_Completo);
}

function UpdateElement(response) {
    console.log(response);
    //poner id
    /*if (response[0].num_socio > 0) {
        employeeNumber.val(response[0].num_socio)
    }
    else*/
    if (response[0].id_socio > 0) {
        $('#SocioId option').remove();
        $.each(response, function (responseValue, item) {
            SocioId.append('<option value=' + item.id_socio + '>' + item.num_socio + '-' + item.nombre_Completo + '</option>');
        });
    }

}