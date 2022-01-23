using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioAspNetCore.Models
{
    public class Tienda
    {
        public Guid IdTienda { get; set; }

        [MaxLength(40, ErrorMessage = "Tamaño máximo de campo de 40 caracteres")]
        [Required(ErrorMessage = "El campo Sucursal es requerido")]
        public string Sucursal { get; set; }

        [MaxLength(5, ErrorMessage = "Tamaño máximo de campo de 5 caracteres")]

        [Required(ErrorMessage = "El campo CodigoPostal es requerido")]
        public string CodigoPostal { get; set; }

        [MaxLength(50, ErrorMessage = "Tamaño máximo de campo de 50 caracteres")]

        [Required(ErrorMessage = "El campo Estado es requerido")]
        public string Estado { get; set; }

        [MaxLength(60, ErrorMessage = "Tamaño máximo de campo de 60 caracteres")]

        [Required(ErrorMessage = "El campo DelegacionMunicipio es Requerido")]
        public string DelegacionMunicipio { get; set; }

        [MaxLength(50, ErrorMessage = "Tamaño máximo de campo de 50 caracteres")]

        [Required(ErrorMessage = "El campo CalleNum es Requerido")]
        public string CalleNum { get; set; }
    }
}
