using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioAspNetCore.Models.ModelsCompra
{
    public class Compra
    {
        public decimal Total { get; set; }

        public IEnumerable<ArticulosCompra> Articulos { get; set; }

    }

    public class ArticulosCompra
    {

        public string CantidadAr { get; set; }
        public Guid Codigo { get; set; }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Sub { get; set; }

    }
}
