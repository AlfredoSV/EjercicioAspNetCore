﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioAspNetCore.Models
{
    public class Tienda
    {
        public Guid IdTienda { get; set; }

        [Required(ErrorMessage = "El campo Sucursal es requerido")]
        public string Sucursal { get; set; }

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