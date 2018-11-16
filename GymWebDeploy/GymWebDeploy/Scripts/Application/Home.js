//Titulo para la exportación de archivos
var FileTitle = 'Catalogo de Socios';
// si crud true tiene grid si no es solo captura
CRUD = true;
note = true
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
    { label: 'activo', name: 'activo', width: 30 }
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

//edit
function GetNotes() {
    data = {
        IdNote: "",
        Note: ""
    };
    var path = '../Note/Get/';
    ajaxPostCall(path, '').done(function (response) {
        console.log(response);
        UpdateElementNote(response);
    });
}

function UpdateElementNote(response) {
    console.log(response);
    var stringCard = '<br />';
    $.each(response, function (responseValue, item) {
        stringCard += ('<div class="card">'+
            '<div class="card-body">' +
            '   <label class= "card-text" >' + item.Note + '</label >' +
            '</div >' +
            '<div class="card-footer">' +
            '   <button type="button" onclick="editNote(' + item.IdNote +' )" class="btn btn-primary btn-sm col-md-5">' +
            '       <img src="../Content/icons/baseline_edit_white_18dp.png">' +
            '   </button>' +
            '   <button type="button" onclick="deleteNote(' + item.IdNote +' )" class="btn btn-primary btn-sm col-md-5">' +
            '       <img src="../Content/icons/baseline_delete_white_18dp.png">' +
            '   </button > ' +
            '</div></div ><br />');
    });
    stringCard += '<br />';
    //console.log(stringCard);
    $("#notes").html(stringCard);
    //$("Note").html("<p>All new content. <em>You bet!</em></p>");
}

function editNote(id) {
    alert("edit:" + id);
}

function deleteNote(id) {
    alert("delte:" + id);
}