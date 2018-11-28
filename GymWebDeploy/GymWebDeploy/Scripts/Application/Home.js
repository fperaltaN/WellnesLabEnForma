//Titulo para la exportación de archivos
var FileTitle = '';
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
    var path = '../Note/Get/';
    ajaxPostCall(path, '').done(function (response) {
        console.log(response);
        UpdateElementNote(response);
    });
}

function UpdateElementNote(response) {
    console.log(response);
    var stringCard = '<div class="card-columns"><br />';
    $.each(response, function (responseValue, item) {
        stringCard += ('<div class="card mb-2 mr-md-2"><br />' +
            '<div class="card-body"><br />' +
            '   <label class= "card-text" >' + item.Note + '</label ><br />' +
            '</div ><br />' +
            '<div class="card-footer"><br />' +
            '   <button type="button" onclick="editNote(' + item.IdNote + ' )" class="btn btn-warning btn-xs"><br />' +
            '       <img src="../Content/icons/baseline_edit_white_18dp.png"><br />' +
            '   </button><br />' +
            '   <button type="button" onclick="deleteNote(' + item.IdNote + ' )" class="btn btn-danger btn-xs"><br />' +
            '       <img src="../Content/icons/baseline_delete_white_18dp.png"><br />' +
            '   </button > <br />' +
            '</div></div ><br />');
    });
    stringCard += '</div><br />';
    $("#notes").html(stringCard);
}
var noteData = {
    IdNote: "",
    Note: ""
};

function editNote(id) {
    $('#editNote').modal("toggle");
    noteData = {
        IdNote: id,
        Note: ""
    };
}

$('#btnUpdateNote').click(function () {
    console.log(noteData);
    var path = '../Note/Update/';
    noteData.Note = $('#noteStr').val();
    ajaxPostCall(path, ReturnJson(noteData)).done(function (response) {
        console.log(response);
        GetNotes();
        $('#editNote').modal("toggle");
    });
});

function deleteNote(id) {
    noteData = {
        IdNote: id,
        Note: ""
    };
    var path = '../Note/Delete/';
    ajaxPostCall(path, ReturnJson(noteData)).done(function (response) {
        console.log(response);
        GetNotes();
    });
}
var partnerID = $('#partnerID');
var inventario = $('#inventario');
var BtnAddInventario = $('#BtnAddInventario');
var inventarioData = {
    Id_cat_inventario: ''
    , Num_control: ''
    , Id_socio: ''
    , Activo: 1
};

BtnAddInventario.click(function () {
    var path = '../Pago/GetSocios/';
    ajaxPostCall(path, ReturnJson('')).done(function (response) {
        $('#partnerID option').remove();
        $.each(response, function (responseValue, item) {
            partnerID.append('<option data-tokens="' + item.id_socio + '" value=' + item.id_socio + '>' + item.num_socio + " " + item.nombre + " " + item.ap_paterno + " " + item.ap_materno + '</option>');
        });
        $('#partnerID').selectpicker();
        $('#partnerID').selectpicker('refresh');
    });
    var path = '../Inventario/GetInventarioAsignado/';
    ajaxPostCall(path, ReturnJson('')).done(function (response) {
        $('#inventario option').remove();
        $.each(response, function (responseValue, item) {
            inventario.append('<option data-tokens="' + item.id_inventario + '" value=' + item.id_inventario + ' data-numControl=' + item.num_control +'>' + item.nombre + " --- " + item.num_control + '</option>');
        });
        $('#inventario').selectpicker();
        $('#inventario').selectpicker('refresh');
    });
});

partnerID.change(function () {
    inventarioData.Id_socio = partnerID.val();
});
inventario.chage(function () {
    inventarioData.Id_cat_inventario = inventario.val();
    inventarioData.Num_control = inventario.numControl();
});




$('#btnUpdateInventario').click(function () {
  
    var path = '../Inventario/SaveAsignado/';


    ajaxPostCall(path, ReturnJson(inventarioData)).done(function (response) {
        $('#inventario option').remove();
        $.each(response, function (responseValue, item) {
            inventario.append('<option data-tokens="' + item.id_inventario + '" value=' + item.id_inventario + '>' + item.nombre + " --- " + item.num_control + '</option>');
        });
        $('.selectpicker').selectpicker();
        $('#inventario').selectpicker('refresh');
    });
});