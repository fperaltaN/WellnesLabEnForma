//Titulo para la exportación de archivos
var FileTitle = '';
// si crud true tiene grid si no es solo captura
CRUD = true;
note = true
//edit
var nameEntity = 'Home';
//form //edit
//edit

var DataTableCumple = $('#DataTableCumple');
function CreateDataTableCumple(modelCumple) {
    DataTableCumple.jqGrid({
        viewrecords: true,
        datatype: "local",
        colModel: modelCumple,
        gridview: true,
        height: 400,
        width: 450,
        //rowNum: 7,
        //pager: "#DataTablePager",
        rowattr: CheckActives
    });
}
var modelCumple = [
    { label: 'id_socio', name: 'id_socio', width: 30 },
    { label: 'num_socio', name: 'num_socio', width: 30 },
    { label: 'nombre', name: 'nombre', width: 30 },
    { label: 'direccion', name: 'direccion', width: 30 },
    { label: 'mail', name: 'mail', width: 50 },
    { label: 'Enviar', name: 'Enviar', width: 30, formatter: CustomCellOptionsCumple }
];
function CustomCellOptionsCumple(cellValue, options, rowdata, action) {
    return '<button type="button" class="btn btn-sm btn-success" onclick="SendMail(' + rowdata.id_socio + ')">' +
        '<img src="../Content/icons/baseline-assignment_turned_in-white-18/1x/baseline_assignment_turned_in_white_18dp.png" />' +
        '</button>';
}
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
    { label: 'Id_inventario', name: 'Id_inventario', width: 30 , hidden:true},
    { label: 'Nombre', name: 'catnombre', width: 30 },
    { label: '# Control', name: 'num_control', width: 30 },
    { label: 'ID Socio', name: 'id_socio', width: 30 },
    { label: 'Socio', name: 'socioName', width: 50 },
    { label: 'Entregar', name: 'Entregar', width: 30, formatter: CustomCellOptions }
];
function CustomCellOptions(cellValue, options, rowdata, action) {
    return '<button type="button" class="btn btn-sm btn-success" onclick="updateInventario(' + rowdata.Id_inventario+')">' +
        '<img src="../Content/icons/baseline-assignment_turned_in-white-18/1x/baseline_assignment_turned_in_white_18dp.png" />' +
        '</button>';
}
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
    CreateDataTableCumple(modelCumple);
    var path1 = '../Note/GetCumple/';
    ajaxPostCall(path1, '').done(function (response) {
        UpdateElementCumple(response);
    });

    var path = '../Note/Get/';
    ajaxPostCall(path, '').done(function (response) {
        UpdateElementNote(response);
        CreateDataTableCumple(modelCumple);
        var path1 = '../Note/GetCumple/';
        ajaxPostCall(path1, '').done(function (response) {
            UpdateElementCumple(response);
        });
    });

    
}

function UpdateElementCumple(response) {
    updateTable(DataTableCumple, response);
}

function UpdateElementNote(response) {
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
    Id_inventario: ''
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
            inventario.append('<option data-tokens="' + item.Id_inventario + '" value=' + item.Id_inventario + ' data-numControl=' + item.num_control +'>' + item.nombre + " --- " + item.num_control + '</option>');
        });
        $('#inventario').selectpicker();
        $('#inventario').selectpicker('refresh');
    });
});

partnerID.change(function () {
    inventarioData.Id_socio = partnerID.val();
});
inventario.on("change", function () {
    inventarioData.Id_inventario = inventario.val();
    var dataname = $("option[value=" + $(this).val() + "]", this).attr('data-numcontrol');
    inventarioData.Num_control = dataname ;
});

$('#btnUpdateInventario').click(function () {
  
    var path = '../Inventario/SaveAsignado/';
    console.log(inventarioData);
    ajaxPostCall(path, ReturnJson(inventarioData)).done(function (response) {
        console.log(response);
        $('#editInventario').modal("toggle");
        GETData(nameEntity, '');
    });
});

function updateInventario(id_inventario) {
    var path = '../Inventario/UpdateInventario/';
    inventarioData.Id_inventario = id_inventario;
    console.log(inventarioData);
    ajaxPostCall(path, ReturnJson(inventarioData)).done(function (response) {
        GETData(nameEntity, '');
    });
}

function SendMail(id_socio) {
    console.log(id_socio);
}