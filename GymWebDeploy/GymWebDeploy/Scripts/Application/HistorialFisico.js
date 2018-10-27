//Titulo para la exportación de archivos
var FileTitle = 'Catalogo de Historial Medico';
// si crud true tiene grid si no es solo captura
CRUD = true;
//edit
var nameEntity = 'HistorialFisico';
//form //edit
var actividad_Fisica = $('#ActividadFisica');
var tiempo_Actividad_Fisica = $('#TiempoActividadFisica');
var tipo_Actividad_Fisica = $('#TipoActividadFisica');
var fuma = $('#Fuma');
var toma = $('#Toma');
var lesiones = $('#Lesiones');
var fatigado_Ejercicio = $('#FatigadoEjercicio');
var SocioId = $('#SocioId');
//edit
var colModel = [
    { label: 'Opciones', name: 'Opciones', width: 20, formatter: CustomCellOptions },
    { label: 'Número', name: 'num_socio', width: 15 },
    { label: 'Nombre Completo', name: 'nombre_Completo', width: 35 },
    { label: 'ActividadFisica', name: 'actividad_Fisica', width: 30 },
    { label: 'TiempoActividadFisica', name: 'tiempo_Actividad_Fisica', width: 30, hidden: true },
    { label: 'TipoActividadFisica', name: 'tipo_Actividad_Fisica', width: 30, hidden: true},
    { label: 'Fuma', name: 'fuma', width: 30 },
    { label: 'Toma', name: 'toma', width: 30 },
    { label: 'Lesiones', name: 'lesiones', width: 30 },
    { label: 'Fatigado Ejercicio', name: 'fatigado_ejercicio', width: 30, hidden: true},
    { label: 'id_historial_fisico', name: 'id_historial_fisico', width: 30, hidden: true },
    { label: 'id_socio', name: 'id_socio', width: 30, hidden: true },
    { label: 'Activo', name: 'activo', width: 30, hidden: true },
];
//edit
function CreateObject(getLastNumber) {
    data = {
        id_historial_fisico: "",
        id_socio: "",
        descripcion: "",
        num_socio: "",
        nombre_Completo: "",
        actividad_Fisica: "",
        tiempo_Actividad_Fisica: "",
        tipo_Actividad_Fisica: "",
        fuma: "",
        toma: "",
        lesiones: "",
        fatigado_ejercicio: "",
        activo: ""
    };
    /*if (getLastNumber) {
        GETDataSingle(nameEntity + '/GetEmpleadoLastNum/', '');        
    }*/
    GETDataSingle(nameEntity + '/GetSocios/', '');

}
//edit
function FillInputs() {
    idDataSource = data.id_socio;
    actividad_Fisica.val(data.actividad_Fisica);
    tiempo_Actividad_Fisica.val(data.tiempo_Actividad_Fisica);
    tipo_Actividad_Fisica.val(data.tipo_Actividad_Fisica);
    fuma.val(data.fuma);
    toma.val(data.toma);
    lesiones.val(data.lesiones);
    fatigado_Ejercicio.val(data.fatigado_ejercicio);
}
function GetInputs() {
    data.id_socio = SocioId.val();
    data.actividad_Fisica = actividad_Fisica.val();
    data.tiempo_Actividad_Fisica = tiempo_Actividad_Fisica.val();
    data.tipo_Actividad_Fisica = tipo_Actividad_Fisica.val();
    data.fuma = fuma.val();
    data.toma = toma.val();
    data.lesiones = lesiones.val();
    data.fatigado_ejercicio = fatigado_Ejercicio.val();
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