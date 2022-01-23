using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dtos
{
    public class DtoCompra
    {
        public Guid IdCliente { get; set; }

        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public IEnumerable<DtoArticulosCompra> Articulos { get; set; }

        public DtoCompra(Guid idCliente, DateTime fecha, decimal total)
        {
            IdCliente = idCliente;
            Fecha = fecha;
            Total = total;
        }

        public DtoCompra(decimal total, IEnumerable<DtoArticulosCompra> articulos)
        {
            Total = total;
            Articulos = articulos;
        }

        public static DtoCompra Create(decimal total, IEnumerable<DtoArticulosCompra> articulos)
        {
            return new DtoCompra(total, articulos);
        }
    }

    public class DtoArticulosCompra
    {

        public string CantidadAr { get; set; }
        public Guid Codigo { get; set; }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Sub { get; set; }

        public DtoArticulosCompra(string cantidadAr, Guid codigo, string id, string nombre, string sub)
        {
            CantidadAr = cantidadAr;
            Codigo = codigo;
            Id = id;
            Nombre = nombre;
            Sub = sub;
        }

        public static DtoArticulosCompra Create(string cantidadAr, Guid codigo, string id, string nombre, string sub)
        {
            return new DtoArticulosCompra(cantidadAr, codigo, id, nombre, sub);
        }
    }



}
