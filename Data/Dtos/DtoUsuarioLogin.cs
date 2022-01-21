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

        public DtoUsuarioLogin(Guid idUsuario, string correo, string contrasenia)
        {
            IdUsuario = idUsuario;
            Correo = correo;
            Contrasenia = contrasenia;
        }

        public DtoUsuarioLogin(string correo, string contrasenia)
        {
            Correo = correo;
            Contrasenia = contrasenia;
        }

        public static DtoUsuarioLogin Create(Guid IdUsuario, string usuario, string contrasenia)
        {
            return new DtoUsuarioLogin(IdUsuario, usuario, contrasenia);
        }

        public static DtoUsuarioLogin Create(string usuario, string contrasenia)
        {
            return new DtoUsuarioLogin(usuario, contrasenia);
        }
    }
}
