using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioAspNetCore.Models
{
    public class Articulo
    {
        public Guid Codigo { get; set; }

        [Required(ErrorMessage = "El campo Descripción es requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Precio es requerido")]
        public decimal Precio { get; set; }


        public IFormFile Imagen { get; set; }

        [Required(ErrorMessage = "El campo Stock es Requerido")]
        public int Stock { get; set; }

        public string ImgBase64 { get; set; }

        public Guid IdTienda { get; set; }
    }
}
