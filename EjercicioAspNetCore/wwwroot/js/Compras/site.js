// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


localStorage.removeItem("miCompra");
localStorage.removeItem("totalCompra");



const cancelarCompra = () => {

    location.reload();

}


const eliminarDeCarrito = (articulo) => {

    let total = document.querySelector("#total");
    let miCarrito = JSON.parse(localStorage.getItem("miCompra"));


    //Quitar los elementos de la tabla y del local storage
    let tablaCompra = document.querySelector("#cuerpoTablaCompra");

    let artCargados = JSON.parse(localStorage.getItem("miCompra")).filter(function (value, index, arr) {
        return value.id != articulo.id;
    });

    let articuloARestar = JSON.parse(localStorage.getItem("miCompra")).filter(function (value, index, arr) {
        return value.id == articulo.id;
    });

    localStorage.setItem("miCompra", JSON.stringify(artCargados));
    tablaCompra.innerHTML = '';

    artCargados.forEach((x) => {
        tablaCompra.innerHTML += `
        <tr>

            <td>${x.nombre}</td>
            <td>${x.cantidadAr}</td>
            <td>$${parseFloat(x.sub).toFixed(2)}</td >
            <td><a href="#" id='${x.id}' onclick="eliminarDeCarrito(this)">Eliminar</a></td>
        </tr>`;
    });

    //Restar al total y actualizar en el html

    let totalCompra = parseFloat(parseFloat(localStorage.getItem("totalCompra")).toFixed(2));

    totalCompra -= parseFloat(parseFloat(articuloARestar[0].sub).toFixed(2));
    total.innerText = parseFloat(totalCompra).toFixed(2);
    localStorage.setItem("totalCompra", totalCompra)

    if (totalCompra <= 0) {

        btnAgregar.disabled = true;
        btnComprar.disabled = true;


    }


}

const finalizarCompra = () => {

    let miCarrito = JSON.parse(localStorage.getItem("miCompra"));

    if (miCarrito == null || miCarrito.length == 0) {

        alert("Debes seleccionar al menos un articulos para finalizar la compra");

    } else {

        let compra = {
            articulos: JSON.parse(localStorage.getItem("miCompra")),
            total: parseFloat(parseFloat(localStorage.getItem("totalCompra")).toFixed(2))

        }

        $.ajax({
            method: 'POST',
            data: compra,
            url: '/Comprar/GenerarCompra'
        }).done((result) => {

            alert("Se guardo correctamente la compra");
            location.reload();

        });
    }

}

const cargarDetalleArticulo = () => {

    let articulo = document.querySelector("#articulo");
    let articulosLocalStorage = JSON.parse(localStorage.getItem("articulos"));
    let cantidad = document.querySelector("#cantidad");
    let precio = document.querySelector("#precio");
    let stock = document.querySelector("#stock");
    let btnAgregar = document.querySelector("#btnAgregar");
    let btnComprar = document.querySelector("#btnComprar");

    let miCarrito = JSON.parse(localStorage.getItem("miCompra"));

    btnAgregar.disabled = false;
    btnComprar.disabled = false;


    let resArticulo = articulosLocalStorage.find((x) => {

        return x.codigo == articulo.value;

    });

    if (resArticulo.stock == 0 || stock == 0) {
        cantidad.max = 0;
        btnAgregar.disabled = true;
        btnComprar.disabled = true;

    }

    if (miCarrito != null) {
        if (miCarrito.length != 0) {
            btnAgregar.disabled = false;
            btnComprar.disabled = false;
        }

    }


    precio.value = resArticulo.precio;
    stock.value = resArticulo.stock;
    cantidad.value = '';
    cantidad.max = resArticulo.stock;

}

const agregarAcarrito = () => {

    let articulo = document.querySelector("#articulo");

    let total = document.querySelector("#total");

    let idTienda = document.querySelector("#tienda").value;
    console.log(idTienda);

    let cantidad = document.querySelector("#cantidad").value;
    console.log(cantidad);

    let precio = document.querySelector("#precio").value;
    console.log(precio);

    let stock = document.querySelector("#stock").value;
    console.log(stock);

    let articuloNombre = articulo.options[articulo.selectedIndex].text;


    let tablaCompra = document.querySelector("#cuerpoTablaCompra");

    if (cantidad != '') {

        alert(cantidad);

        let idArticuloCarrito = articulo.value + (new Date().getMilliseconds() + new Date().getTime());

        let nuevoArticulo = {

            id: idArticuloCarrito,
            codigo: articulo.value,
            cantidadAr: cantidad,
            sub: parseFloat((precio * cantidad)).toFixed(2),
            nombre: articuloNombre

        }

        tablaCompra.innerHTML += `
        <tr>

            <td>${articuloNombre}</td>
            <td>${cantidad}</td>
            <td>$${parseFloat((precio * cantidad)).toFixed(2)}</td >
            <td><a href="#" id='${idArticuloCarrito}' onclick="eliminarDeCarrito(this)">Eliminar</a></td>
        </tr>`;

        let artCargados = new Array();

        if (JSON.parse(localStorage.getItem("miCompra")) == undefined) {

            artCargados.push(nuevoArticulo);
            localStorage.setItem("miCompra", JSON.stringify(artCargados));

        } else {

            JSON.parse(localStorage.getItem("miCompra")).forEach((x) => {
                artCargados.push(x);
            })

            artCargados.push(nuevoArticulo);

            localStorage.setItem("miCompra", JSON.stringify(artCargados));

        }
    } else {
        alert("No puede agregar 0 articulos")
    }

    let totalCompra = 0.0;

    if (localStorage.getItem("totalCompra") == undefined) {

        totalCompra = parseFloat((precio * cantidad)).toFixed(2);;

    } else {

        totalCompra = parseFloat(parseFloat(localStorage.getItem("totalCompra")).toFixed(2));

        totalCompra += parseFloat(parseFloat((precio * cantidad)).toFixed(2));
    }

    total.innerText = parseFloat(totalCompra).toFixed(2);
    localStorage.setItem("totalCompra", totalCompra)




}


const cargarArticulos = () => {

    let idTienda = document.querySelector("#tienda").value;
    let articuloSelect = document.querySelector("#articulo");

    let precio = document.querySelector("#precio");
    let stock = document.querySelector("#stock");
    let cantidad = document.querySelector("#cantidad");

    let btnAgregar = document.querySelector("#btnAgregar");
    let btnComprar = document.querySelector("#btnComprar");



    articuloSelect.innerHTML = '';
    cantidad.value = '';

    precio.value = '';
    stock.value = '';
    btnAgregar.disabled = false;
    btnComprar.disabled = false;

    $.ajax({
        method: 'GET',
        data: { idTienda },
        url: '/Comprar/ArticulosPoTienda'
    }).done((result) => {



        if (result.length == 0) {
            alert("Esta tienda no tiene ningun articulo asociado");

            btnAgregar.disabled = true;
            btnComprar.disabled = true;

        } else {
            result.forEach((x) => {
                articuloSelect.innerHTML += '<option value="' + x.codigo + '">' + x.descripcion + '</option>'
            });



            precio.value = result[0].precio;
            stock.value = result[0].stock;
            cantidad.max = result[0].stock;

            if (result[0].stock == 0) {
                cantidad.min = 0;
                btnAgregar.disabled = true;
                btnComprar.disabled = true;
            }

            localStorage.setItem("articulos", JSON.stringify(result));

        }


    });
}


cargarArticulos();



/*

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


            $('<a class="btn btn-info"  href="#' + options.data.idTienda + '" >Detalle</a>')
                .appendTo(container);

            console.log(options);
        }
    },],
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

consultarClientes("GET", "/Tienda/ListarTiendas");*/