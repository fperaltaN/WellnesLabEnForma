function CreateDataTable(model) {


    DataTable.jqGrid({
        viewrecords: true,
        datatype: "local",
        colModel: model,
        gridview: true,
        height: 'auto',
        width: 1180,
        rowNum: 7,
        rownumbers: true,
        pager: "#DataTablePager",
        rowattr: CheckActives,
        footerrow: true,
        gridComplete: function () {
            var $grid = DataTable;
            
            //$grid.jqGrid('footerData', 'set', {'importe': colSu });
        },
        loadComplete: function () {
            var $grid = DataTable;
            var i = 0, item;
            localData = $grid.jqGrid("getGridParam", "data"),
                itemCount = localData.length,
                totalCredit = 0,
                i,
                item;

            for (i = 0; i < itemCount; i++) {
                item = localData[i];
                totalCredit += parseFloat(item.importe);
                console.log(totalCredit)
            }
            var colSum = $grid.jqGrid('getCol', 'importe', false, 'sum');
            var dataShow = 'Total: $' + totalCredit;// + ' (en página:) $';
            $grid.jqGrid('footerData', 'set', { 'empleado': dataShow, 'importe': colSum });
            
            //$grid.jqGrid('footerData', 'set', { 'pendiente': 'TOTAL en página','pendiente': colSum });

        }

    });
}
function updateTable(grid, response) {
    if (CRUD) {
        grid.jqGrid('clearGridData');
        grid.jqGrid('setGridParam', { data: response });
        grid[0].grid.endReq();
        grid.trigger('reloadGrid');
        MsgSuccess('info', 'Carga completa');
    }
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