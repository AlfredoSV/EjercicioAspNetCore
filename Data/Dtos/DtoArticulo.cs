using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dtos
{
    public class DtoArticulo
    {
        public Guid Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
        public DateTime FechaAlta { get; set; }
        public Guid IdTienda { get; set; }

        public Guid IdUsuario { get; set; }
        public DtoArticulo(Guid codigo, string descripcion, decimal precio, string imagen, int stock, DateTime fechaAlta)
        {
            Codigo = codigo;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Imagen = imagen;
            this.Stock = stock;
            this.FechaAlta = fechaAlta;
        }

        public DtoArticulo(Guid codigo, string descripcion, decimal precio, string imagen, int stock, DateTime fechaAlta, Guid idTienda)
        {
            Codigo = codigo;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Imagen = imagen;
            this.Stock = stock;
            this.FechaAlta = fechaAlta;
            IdTienda = idTienda;
        }


        public DtoArticulo(string descripcion, decimal precio, string imagen, int stock, Guid idTienda, Guid idUsuario)
        {
            IdUsuario = idUsuario;
            Codigo = Guid.NewGuid();
            Descripcion = descripcion;
            Precio = precio;
            Imagen = imagen;
            Stock = stock;
            IdTienda = idTienda;
        }

        public DtoArticulo(Guid codigo, string descripcion, decimal precio, string imagen, int stock)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Precio = precio;
            Imagen = imagen;
            Stock = stock;
        }
        public static DtoArticulo Create(Guid codigo, string descripcion, decimal precio, string imagen, int stock)
        {
            return new DtoArticulo(codigo, descripcion, precio, imagen, stock);
        }
        public static DtoArticulo Create(string descripcion, decimal precio, string imagen, int stock, Guid idTienda, Guid idUsuario)
        {
            return new DtoArticulo(descripcion, precio, imagen, stock, idTienda, idUsuario);
        }
    }
}
