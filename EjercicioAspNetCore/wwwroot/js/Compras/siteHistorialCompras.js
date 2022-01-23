// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.






$('#gridHistorialCompras').dxDataGrid({
    dataSource: [],
    showBorders: true,
    remoteOperations: true,
    paging: {
        pageSize: 8,
    },

    noDataText: "Sin datos...",
    loadPanel: {
        enabled: true,
        shading: true,
        showPane: true,
        width: 300,
        height: 100
    },
    pager: {
        showPageSizeSelector: true,
        allowedPageSizes: [8],
    },
    columns: [{
        dataField: 'idCliente',
        dataType: 'string',
        caption: 'Id cliente',
    }, {
        dataField: 'fecha',
        dataType: 'date',
        caption: 'Fecha de compra'

    }, {
        dataField: 'total',
        dataType: 'string',
        caption: 'Total de compra',

    }],
}).dxDataGrid('instance');





const consultarClientes = (meth, urlSe) => {

    $.ajax({
        method: meth,
        url: urlSe
    }).done((result) => {

        let dataGrid = $("#gridHistorialCompras").dxDataGrid({
        }).dxDataGrid("instance");
        let dataSource = dataGrid.getDataSource();

        result.forEach((reg) => {
            dataSource.store().insert(reg).then(function () {
                dataSource.reload();
            })
        })



        console.log(result);


    });

}

consultarClientes("GET", "/Comprar/ConsultarMisCompras");