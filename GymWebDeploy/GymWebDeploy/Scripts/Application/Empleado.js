//Titulo para la exportación de archivos
var FileTitle = 'Catalogo de Empleados';
// si crud true tiene grid si no es solo captura
CRUD = true;
//edit
var nameEntity = 'Empleado';
//form //edit
var employeeNumber = $('#EmployeeNumber');
var employeeName = $('#EmployeeName');
var employeeLast = $('#EmployeeLast');
var employeeLastM = $('#EmployeeLastM');
var employeePhone = $('#EmployeePhone');
var employeeAddress = $('#EmployeeAddress');
var employeeType = $('#EmployeeType');
//edit
var colModel = [
    { label: 'Opciones', name: 'Opciones', width: 20, formatter: CustomCellOptions },
    { label: 'Número', name: 'num_empleado', width: 20 },
    { label: 'Nombre', name: 'nombre', width: 30 },
    { label: 'Ap. Paterno', name: 'ap_paterno', width: 30 },
    { label: 'Ap. Materno', name: 'ap_materno', width: 30 },
    { label: 'Domicilio', name: 'direccion', width: 50 },
    { label: 'Teléfono', name: 'telefono', width: 30 },
    { label: 'id_empleado', name: 'id_empleado', width: 0, hidden: true },
    { label: 'id_perfil', name: 'id_perfil', width: 0, hidden: true },
    { label: 'activo', name: 'activo', width: 0, hidden: true }
];
//edit
function CreateObject(getLastNumber) {
    data = {
        id_empleado: "",
        num_empleado: "",
        nombre: "",
        ap_paterno: "",
        ap_materno: "",
        telefono: "",
        direccion: "",
        fecha_baja: "",
        id_perfil: ""
    };
    if (getLastNumber) {
        GETDataSingle(nameEntity + '/GetEmpleadoLastNum/', '');        
    }
    GETDataSingle(nameEntity + '/GetPerfiles/', '');

}
//edit
function FillInputs() {
    idDataSource = data.id_empleado;
    employeeNumber.val(data.num_empleado);
    employeeName.val(data.nombre);
    employeeLast.val(data.ap_paterno);
    employeeLastM.val(data.ap_materno);
    employeePhone.val(data.telefono);
    employeeAddress.val(data.direccion);
    employeeType.val(data.id_perfil);
}
function GetInputs() {
    data.num_empleado = employeeNumber.val();
    data.nombre=employeeName.val();
    data.ap_paterno=employeeLast.val();
    data.ap_materno=employeeLastM.val();
    data.telefono=employeePhone.val();
    data.direccion=employeeAddress.val();
    data.id_perfil=employeeType.val();
}
function SetDeleteMsg() {
    SetDeleteData(' Empleado NÚM: ' + data.num_empleado + ' --- NOMBRE: ' + data.nombre + ' ' + data.ap_paterno + ' ' + data.ap_materno);
}

function UpdateElement(response) {
    console.log(response);
    //poner id
    if (response[0].num_empleado > 0) {
        employeeNumber.val(response[0].num_empleado)
    }
    else if (response[0].ID_PERFIL > 0){
        $('#EmployeeType option').remove();
         $.each(response, function (responseValue, item) {
            employeeType.append('<option value=' + item.ID_PERFIL + '>' + item.PERFIL + '</option>');
        });
    } 

}

