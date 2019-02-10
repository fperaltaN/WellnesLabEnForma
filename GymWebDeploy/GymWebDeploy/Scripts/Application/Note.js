//Titulo para la exportación de archivos
var FileTitle = 'Notes';
// si crud true tiene grid si no es solo captura
CRUD = true;
note = true;
//edit
var nameEntity = 'Note';
///variable para el nombre del proyecto publicado puesto que cambian las rutas
//dejar en blanco si se trabaja de manera local
var publish = 'webdeploy/';
//form //edit
//edit

function GetNotes() {
    CreateDataTableCumple(modelCumple);
    var path1 = '../' + publish +'Note/GetCumple/';
    ajaxPostCall(path1, '').done(function (response) {
        UpdateElementCumple(response);
    });

    var path = '../' + publish +'Note/Get/';
    ajaxPostCall(path, '').done(function (response) {
        UpdateElementNote(response);
        CreateDataTableCumple(modelCumple);
        var path1 = '../' + publish +'Note/GetCumple/';
        ajaxPostCall(path1, '').done(function (response) {
            UpdateElementCumple(response);
        });
    });
    
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
            '       <img src="../' + publish +'Content/icons/baseline_edit_white_18dp.png"><br />' +
            '   </button>&nbsp' +
            '   <button type="button" onclick="deleteNote(' + item.IdNote + ' )" class="btn btn-danger btn-xs"><br />' +
            '       <img src="../' + publish +'Content/icons/baseline_delete_white_18dp.png"><br />' +
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
    $('#btnUpdateNote').show();
    $('#btnInsertNote').hide();
    $('#editNote').modal("toggle");
    noteData = {
        IdNote: id,
        Note: ""
    };
}

$('#btnUpdateNote').click(function () {
    console.log(noteData);
    var path = '../' + publish +'Note/Update/';
    noteData.Note = $('#noteStr').val();
    ajaxPostCall(path, ReturnJson(noteData)).done(function (response) {
        console.log(response);
        GetNotes();
        $('#editNote').modal("toggle");
    });
});
$('#btnInsertNote').click(function () {
    console.log(noteData);
    var path = '../' + publish +'Note/Save/';
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
    var path = '../' + publish +'Note/Delete/';
    ajaxPostCall(path, ReturnJson(noteData)).done(function (response) {
        console.log(response);
        GetNotes();
    });
}