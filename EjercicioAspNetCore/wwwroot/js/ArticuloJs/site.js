// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let detalleArticuloModal = new bootstrap.Modal(document.querySelector('#detalleArticulo'), {});


$('#gridArticulos').dxDataGrid({
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
        dataField: 'codigo',
        dataType: 'string',
        caption: 'Código',
        width: 260
    }, {
        dataField: 'descripcion',
        dataType: 'string',
        caption: 'Descripcion',
        width: 140
    }, {
        dataField: 'precio',
        dataType: 'string',
        caption: 'Precio',
        width: 140
    }, {
        dataField: 'stock',
        dataType: 'string',
        caption: 'Stock',
        width: 80
    }, {
        dataField: 'fechaAlta',
        dataType: 'date',
        caption: 'Fecha Alta',
        width: 80
    }, {

        caption: "Comandos",
        alignment: "center",
        cellTemplate(container, options) {

            $('<a class="btn btn-danger">Eliminar</a>')
                .attr('href', "/Articulo/EliminarArticulo/" + options.data.codigo)
                .appendTo(container);
            $('<span> / <span>')
                .appendTo(container);
            $('<a class="btn btn-primary">Editar</a>')
                .attr('href', "/Articulo/EditarArticulo/" + options.data.codigo)
                .appendTo(container);
            $('<span> / <span>')
                .appendTo(container);

            $('<a class="btn btn-info" id="' + options.data.codigo + '" onclick="detalleArticulo(this)" href="#" >Detalle</a>')
                .appendTo(container);

            console.log(options);
        }
    },],
}).dxDataGrid('instance');


const detalleArticulo = (articulo) => {

    let cuerpoModal = document.querySelector("#cuerpoDetalleModal");
    $.ajax({
        method: 'GET',
        url: '/Articulo/ConsultarDetalleArticulo',
        data: { idArticulo: articulo.id }
    }).done((result) => {
        cuerpoModal.innerHTML = '';
        if (result.imagen != "") {
            cuerpoModal.innerHTML =
                `<img src="${result.imagen}"><img>`;
        }
        cuerpoModal.innerHTML +=
            `<br>
             Código:${result.codigo}
             <br>
             Descripcion:${result.descripcion}
             <br>
             Fecha alta: ${result.fechaAlta}
             <br>
             Precio:${result.precio}
            <br>
             Stcok:${result.stock}
            `;



        detalleArticuloModal.show();


    });



}

const cerrarModal = () => {

    detalleArticuloModal.hide();

}



const consultarClientes = (meth, urlSe) => {

    $.ajax({
        method: meth,
        url: urlSe
    }).done((result) => {

        let dataGrid = $("#gridArticulos").dxDataGrid({
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

consultarClientes("GET", "/Articulo/ListarArticulos");