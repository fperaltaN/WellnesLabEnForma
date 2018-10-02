function CreateDataTable(model) {
    DataTable.jqGrid({
        viewrecords: true,
        datatype: "local",
        colModel: model,
        gridview: true,
        height: 'auto',
        width: 1180,
        rowNum: 7,
        pager: "#DataTablePager",
        rowattr: CheckActives
    });
}
function updateTable(grid, response) {
    grid.jqGrid('clearGridData');
    grid.jqGrid('setGridParam', { data: response });
    grid[0].grid.endReq();
    grid.trigger('reloadGrid');
}
//local datatable funcions
function CustomCellOptions(cellValue, options, rowdata, action) {
    return '<button type="button" class="btn btn-sm btn-success" onclick="ShowModalUpdate()">' +
        '<img src="../Content/icons/baseline_edit_white_18dp.png" />' +
        '</button>' +
        '<button type="button" class="btn btn-sm btn-danger" onclick="ShowModalDelete()">' +
        '<img src="../Content/icons/baseline_delete_white_18dp.png" />' +
        '</button>';
}
function CheckActives(rd) {
    if (rd.activo === false) {
        return { "class": "table-danger" };
    }
}