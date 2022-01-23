using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EjercicioAspNetCore.Models
{
    public class Cliente
    {
        public Guid IdCliente { get; set; }

        [MaxLength(30, ErrorMessage = "Tamaño máximo de campo de 30 caracteres")]
        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Nombre { get; set; }

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
