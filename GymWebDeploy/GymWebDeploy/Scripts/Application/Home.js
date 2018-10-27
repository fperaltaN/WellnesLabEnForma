//Titulo para la exportación de archivos
var FileTitle = 'Catalogo de Socios';
// si crud true tiene grid si no es solo captura
CRUD = true;
//edit
var nameEntity = 'Home';
//form //edit
//edit
function CreateDataTable(model) {
    DataTable.jqGrid({
        viewrecords: true,
        datatype: "local",
        colModel: model,
        gridview: true,
        height: 400,
        width: 450,
        //rowNum: 7,
        //pager: "#DataTablePager",
        rowattr: CheckActives
    });
}
var colModel = [
    //{ label: 'Opciones', name: 'Opciones', width: 30, formatter: CustomCellOptions },
    { label: 'Nombre', name: 'catnombre', width: 30 },
    { label: '# Control', name: 'num_control', width: 30 },
    { label: 'ID Socio', name: 'id_socio', width: 30 },
    { label: 'Socio', name: 'socioName', width: 50 },
    { label: 'activo', name: 'activo', width: 30}
];
//edit
function CreateObject(getLastNumber) {
    data = {
        Optiones: '',
        id_socio: '',
        num_socio: '',
        nombre: '',
        ap_paterno: '',
        ap_materno: '',
        fecha_nacimiento: '',
        telefono: '',
        mail: '',
        compEstudios: ''
    };
}
function UpdateElement(response) {
    console.log(response);
    //poner id
    if (response[0].num_socio > 0) {
        partnerNumber.val(response[0].num_socio)
    }

}
