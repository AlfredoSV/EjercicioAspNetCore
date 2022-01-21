using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dtos
{
    public class DtoUsuarioLogin
    {
        public Guid IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }

        public string Rol { get; set; }

        public DtoUsuarioLogin(Guid idUsuario, string correo, string contrasenia, string rol)
        {
            IdUsuario = idUsuario;
            Correo = correo;
            Contrasenia = contrasenia;
            Rol = rol;
        }

        public DtoUsuarioLogin(string correo, string contrasenia)
        {
            Correo = correo;
            Contrasenia = contrasenia;
        }

        public static DtoUsuarioLogin Create(Guid IdUsuario, string usuario, string contrasenia, string rol)
        {
            return new DtoUsuarioLogin(IdUsuario, usuario, contrasenia, rol);
        }

        public static DtoUsuarioLogin Create(string usuario, string contrasenia)
        {
            return new DtoUsuarioLogin(usuario, contrasenia);
        }
    }
}
