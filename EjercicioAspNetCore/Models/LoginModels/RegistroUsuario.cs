using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioAspNetCore.Models.LoginModels
{
    public class RegistroUsuario
    {
        [EmailAddress(ErrorMessage = "Correo no valido")]
        [Required(ErrorMessage = "El Correo es requerido")]
        public string Correo { get; set; }

        [MaxLength(50, ErrorMessage = "Tamaño máximo de campo de 50 caracteres")]
        [Required(ErrorMessage = "La contraseña es requerido")]
        public string Contrasenia { get; set; }

        [MaxLength(30, ErrorMessage = "Tamaño máximo de campo de 30 caracteres")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [MaxLength(5, ErrorMessage = "Tamaño máximo de campo de 5 caracteres")]
        [Required(ErrorMessage = "El código postal es requerido")]
        public string CodigoPostal { get; set; }

        [MaxLength(50, ErrorMessage = "Tamaño máximo de campo de 50 caracteres")]
        [Required(ErrorMessage = "El estado es requerido")]
        public string Estado { get; set; }

        [MaxLength(60, ErrorMessage = "Tamaño máximo de campo de 60 caracteres")]
        [Required(ErrorMessage = "La delegación o municipio es requerida")]
        public string DelegacionMunicipio { get; set; }

        [MaxLength(50, ErrorMessage = "Tamaño máximo de campo de 50 caracteres")]
        [Required(ErrorMessage = "La calle y número es requerida")]
        public string CalleNum { get; set; }

        [Required(ErrorMessage = "El Rol es requerido")]
        public Guid IdRol { get; set; }
    }
}
