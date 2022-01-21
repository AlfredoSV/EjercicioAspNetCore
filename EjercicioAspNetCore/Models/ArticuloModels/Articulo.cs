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

        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Descripción es requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Precio es requerido")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El campo Imagen es Requerido")]
        public IFormFile Imagen { get; set; }

        [Required(ErrorMessage = "El campo Stock es Requerido")]
        public int Stock { get; set; }
    }
}
