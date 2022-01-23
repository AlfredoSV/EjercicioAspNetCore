using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EjercicioAspNetCore.Models.LoginModels
{
    public class LoginUsuario
    {
        [EmailAddress(ErrorMessage = "Correo no valido")]
        [Required(ErrorMessage = "El usuario es requerido")]
        public string Usuario { get; set; }

        [MaxLength(50, ErrorMessage = "Tamaño máximo de campo de 50 caracteres")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Contrasenia { get; set; }

    }
}
