// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let detalleTiendaModal = new bootstrap.Modal(document.querySelector('#detalleTienda'), {});


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
    }, , {
        dataField: 'idUsuario',
        dataType: 'string',
        caption: 'Id del usuario',
        width: 80
    }, {

        caption: "Comandos",
        alignment: "center",
        cellTemplate(container, options) {

            $('<a class="btn btn-danger">Eliminar</a>')
                .attr('href', "/Tienda/EliminarTienda/" + options.data.idTienda)
                .appendTo(container);
            $('<span> / <span>')
                .appendTo(container);
            $('<a class="btn btn-primary">Editar</a>')
                .attr('href', "/Tienda/EditarTienda/" + options.data.idTienda)
                .appendTo(container);
            $('<span> / <span>')
                .appendTo(container);

            $('<a class="btn btn-info" id="' + options.data.idTienda + '" onclick="detalleTienda(this)"  href="#" >Detalle</a>')
                .appendTo(container);

            console.log(options);
        }
    },],
}).dxDataGrid('instance');



const detalleTienda = (tienda) => {

    let cuerpoModal = document.querySelector("#cuerpoDetalleModal");
    $.ajax({
        method: 'GET',
        url: '/Tienda/ConsultarDetalleTienda',
        data: { idTienda: tienda.id }
    }).done((result) => {


        cuerpoModal.innerHTML =
            `
            Calle y número: ${result.calleNum}<br>
            Codigo Postal: ${result.codigoPostal}<br>
            DelegacionMunicipio: ${result.delegacionMunicipio}<br>
            Estado: ${result.estado}<br>
            id Tienda: ${result.idTienda}<br>
            Sucursal: ${result.sucursal}
            `;


        detalleTiendaModal.show();


    });



}

const cerrarModal = () => {

    detalleTiendaModal.hide();

}


const consultarClientes = (meth, urlSe) => {

    $.ajax({
        method: meth,
        url: urlSe
    }).done((result) => {
        console.log(result)
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