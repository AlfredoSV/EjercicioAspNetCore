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

        public DtoArticulo(Guid codigo, string descripcion, decimal precio, string imagen, int stock, DateTime fechaAlta)
        {
            Codigo = codigo;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Imagen = imagen;
            this.Stock = stock;
            this.FechaAlta = fechaAlta;
        }
    }
}
