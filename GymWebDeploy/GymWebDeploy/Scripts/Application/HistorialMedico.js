//Titulo para la exportación de archivos
var FileTitle = 'Catalogo de Historial Medico';
// si crud true tiene grid si no es solo captura
CRUD = true;
//edit
var nameEntity = 'HistorialMedico';
//form //edit
var id_socio = $('#id_socio');
var Problema_Cardiaco = $('#ProblemaCardiaco');
var Dolor_Pecho = $('#DolorPecho');
var Asma = $('#Asma');
var Presion_Alta = $('#PresionAlta');
var Medicamento = $('#Medicamento');
var Neurologicos = $('#Neurologicos');
var Riesgo_Cardiovascular = $('#RiesgoCardiovascular');
var Dolencias = $('#Dolencias');
var Enfermedad = $('#Enfermedad');
//edit
var colModel = [
    { label: 'Opciones', name: 'Opciones', width: 20, formatter: CustomCellOptions },
    { label: 'Número', name: 'num_Socio', width: 20 },
    { label: 'Nombre Completo', name: 'nombre_Completo', width: 30 },
    { label: 'Problema Cardiaco', name: 'problema_Cardiaco', width: 30 },
    { label: 'Dolor Pecho', name: 'dolor_Pecho', width: 30 },
    { label: 'Asma', name: 'Asma', width: 30 },
    { label: 'Presion Alta', name: 'presionAlta', width: 30 },
    { label: 'Medicamento', name: 'medicamento', width: 50 },
    { label: 'Neurologicos', name: 'neurologicos', width: 30 },
    { label: 'Riesgo Cardiovascular', name: 'riesgoCardiovascular', width: 30 },
    { label: 'Dolencias', name: 'dolencias', width: 30 },
    { label: 'Enfermedad', name: 'enfermedad', width: 30 },
    { label: 'id_historial_medico', name: 'id_historial_medico', width: 30, hidden: true },
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
    num_socio.val(data.num_socio);
    nombre_Completo.val(data.nombre_Completo);
    problema_Cardiaco.val(data.problema_Cardiaco);
    dolor_Pecho.val(data.dolor_Pecho);
    asma.val(data.asma);
    presion_Alta.val(data.presion_Alta);
    medicamento.val(data.medicamento);
    neurologicos.val(data.neurologicos);
    riesgo_Cardiovascular.val(data.riesgo_Cardiovascular);
    dolencias.val(data.dolencias);
    enfermedad.val(data.enfermedad);
}
function GetInputs() {
    data.num_socio = num_socio.val();
    data.nombre_Completo = nombre_Completo.val();
    data.problemaCardiaco = problema_Cardiaco.val();
    data.dolorPecho = dolor_Pecho.val();
    data.asma = asma.val();
    presion_Alta.val(data.presion_Alta);
    data.medicamento = medicamento.val();
    data.neurologicos = neurologicos.val();
    data.riesgo_Cardiovascular = riesgo_Cardiovascular.val();
    data.dolencias = dolencias.val();
    data.enfermedad = enfermedad.val();
}
function SetDeleteMsg() {
    SetDeleteData(' Socio NÚM: ' + data.num_socio + ' --- NOMBRE: ' + nombre_Completo);
}

function UpdateElement(response) {
    console.log(response);
    //poner id
    if (response[0].num_socio > 0) {
        employeeNumber.val(response[0].num_socio)
    }
    else if (response[0].id_socio > 0) {
        $('#EmployeeType option').remove();
        $.each(response, function (responseValue, item) {
            employeeType.append('<option value=' + item.id_socio + '>' + item.num_socio + ' ' + item.nombre_Completo + '</option>');
        });
    }

}