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

        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo CodigoPostal es requerido")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "El campo Estado es requerido")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El campo DelegacionMunicipio es Requerido")]
        public string DelegacionMunicipio { get; set; }

        [Required(ErrorMessage = "El campo CalleNum es Requerido")]
        public string CalleNum { get; set; }


    }
}
