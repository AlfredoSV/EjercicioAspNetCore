// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$('#gridTiendas').dxDataGrid({
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
        dataField: 'idTienda',
        dataType: 'string',
        caption: 'Id',
    }, {
        dataField: 'sucursal',
        dataType: 'string',
        caption: 'Nombre',
        width: 80
    }, {
        dataField: 'codigoPostal',
        dataType: 'string',
        caption: 'Código postal',
        width: 80
    }, {
        dataField: 'estado',
        dataType: 'string',
        caption: 'Estado',
        width: 80
    }, {
        dataField: 'delegacionMunicipio',
        dataType: 'string',
        caption: 'Delegación o municipio',
        width: 80
    }, {
        dataField: 'calleNum',
        dataType: 'string',
        caption: 'Calle y número',
        width: 80
    }, {

        caption: "Comandos",
        alignment: "center",
        cellTemplate(container, options) {

            $('<a class="btn btn-danger">Eliminar</a>')
                .attr('href', "/Cliente/EliminarCliente/" + options.data.idCliente)
                .appendTo(container);
            $('<span> / <span>')
                .appendTo(container);
            $('<a class="btn btn-primary">Editar</a>')
                .attr('href', "/Cliente/EditarCliente/" + options.data.idCliente)
                .appendTo(container);
            $('<span> / <span>')
                .appendTo(container);

            $('<a class="btn btn-info" onclick="detalleCliente()" href="#' + options.data.idCliente + '" >Detalle</a>')
                .appendTo(container);

            console.log(options);
        }
    },],
}).dxDataGrid('instance');


const detalleCliente = () => {
    alert("Hola");
}



const consultarClientes = (meth, urlSe) => {

    $.ajax({
        method: meth,
        url: urlSe
    }).done((result) => {

        let dataGrid = $("#gridTiendas").dxDataGrid({
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

consultarClientes("GET", "/Tienda/ListarTiendas");