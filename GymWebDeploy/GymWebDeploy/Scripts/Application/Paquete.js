//Titulo para la exportación de archivos
var FileTitle = 'Catalogo de Paquetes';
// si crud true tiene grid si no es solo captura
CRUD = true;
note = false;
//edit
var nameEntity = 'Paquete';
//form //edit
var packageName = $('#packageName');
var packageDays = $('#packageDays');
var PackageCost = $('#packageCost');
var packageDescription = $('#packageDescription');
//edit
var colModel = [
    { label: 'Opciones', name: 'Opciones', width: 30, formatter: CustomCellOptions },
    { label: 'Nombre', name: 'nombre', width: 50 },
    { label: 'Días', name: 'diaspaquetes', width: 50 },
    { label: 'Costo', name: 'costo', width: 50 },
    { label: 'Descripción', name: 'descripcion', width: 200 },
    { label: 'id_paquete', name: 'id_paquete', width: 0, hidden: true },
    { label: 'ID_USUARIO', name: 'ID_USUARIO', width: 0, hidden: true },
    { label: 'activo', name: 'activo', width: 0, hidden: true }
];
//edit
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
//edit
function FillInputs() {
    idDataSource = data.id_paquete;
    packageName.val(data.nombre);
    packageDays.val(data.diaspaquetes);
    PackageCost.val(data.costo);
    packageDescription.val(data.descripcion);
}
function GetInputs() {
    data.id_paquete = idDataSource;
    data.nombre = packageName.val();
    data.diaspaquetes = packageDays.val();
    data.costo = PackageCost.val();
    data.descripcion = packageDescription.val();
    data.ID_USUARIO = 1;
}
function SetDeleteMsg() {
    SetDeleteData(' Paquete NÚM: ' + data.id_paquete + ' --- NOMBRE: ' + data.nombre);
}