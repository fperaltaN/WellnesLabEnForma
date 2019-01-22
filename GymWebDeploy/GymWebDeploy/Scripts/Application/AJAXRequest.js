﻿var responseGet = {};
function ajaxPostCall(url, data) {
    return $.ajax({
        cache: false,
        type: "POST",
        url: url,
        data: data,
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + throwError);
        },
        dataType: "json"
    });
}
function ajaxPostCallAction(controller, action, data) {
    //url = '@Url.Action("'+ action + '", "' + controller + '")'
    return $.ajax({
        cache: false,
        type: "POST",
        url: '/' + nameEntity + '/ValidateUser/',
        data: data,
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + throwError);
        },
        dataType: "json"
    });
}
function GETData(entity, parameters) {
    var path = '../' + entity + '/Get/';
    MsgSuccess('info', 'Cargando Información...');
    ajaxPostCall(path, ReturnJson(parameters)).done(function (response) {
        console.log(response);
        if (CRUD) {
            updateTable(DataTable, response);
        }
    });
}
function ADDData(entity, parameters) {
    var path = '../' + entity + '/Save/';
    ajaxPostCall(path, ReturnJson(parameters)).done(function (response) {
        CheckExecution(response);
    });
}
function UPDATEData(entity, parameters) {
    var path = '../' + entity + '/Update/';
    ajaxPostCall(path, ReturnJson(parameters)).done(function (response) {
        CheckExecution(response);
    });
}
function GETDataSingle(entity, parameters) {
    var path = '../' + entity;
    ajaxPostCall(path, ReturnJson(parameters)).done(function (response) {
        console.log(response);
        UpdateElement(response);
    });
}
function CheckExecution(response) {
    console.log(response);
    if (response) {
        GETData(nameEntity, '');
        if (mode === 0 || mode === 1) {
            ModalData.modal('toggle');
        } else {
            ModalDelete.modal('toggle');
        }
        MsgSuccess('success', nameEntity + ' Actualizado.');
    } else {
        MsgSuccess('error', 'Ocurrio un error al intentar actualizar ' + nameEntity + '\nPor favor contacte al Administrador');
    }
}
function ReturnJson(parameters) {
    var json = { data: parameters };
    return JSON.stringify(json);
}