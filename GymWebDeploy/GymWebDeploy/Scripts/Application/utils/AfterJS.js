$(document).ready(function () {
    console.log('ready!');
    if (CRUD) {
        CreateDataTable(colModel);
        GETData(nameEntity, '');
    }

    $(document).on('submit', '#DataForm', function (event) {
        event.preventDefault();
        Save();
    });
    $('#BtnDelete').click(function () { Delete(); });
    var timer;
    $("#Search").on("keyup", function () {
        var self = this;
        if (timer) { clearTimeout(timer); }
        timer = setTimeout(function () { DataTable.jqGrid('filterInput', self.value); }, 0);
    });
    $("#SearchInv").on("keyup", function () {
        var self = this;
        if (timer) { clearTimeout(timer); }
        timer = setTimeout(function () { DataTableInventario.jqGrid('filterInput', self.value); }, 0);
    });
});
//0 add | 1update | 2 delete
var mode = -1;
var idDataSource;