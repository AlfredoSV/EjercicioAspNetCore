using System;
using System.Collections.Generic;
using System.Text;
using Data.Dtos;
using Data.Repositorio;

namespace Bussiness.Bussiness
{
    public class Login
    {
        RepositorioLogin _repositorioLogin { get; set; }
        public Login(string conex)
        {
            _repositorioLogin = new RepositorioLogin(conex);
        }
        public bool ValidarUsuario(DtoUsuarioLogin dtoUsuarioLogin)
        {
            var usuario = _repositorioLogin.BuscarUsuarioLoginPorUsuario(dtoUsuarioLogin.Correo, dtoUsuarioLogin.Contrasenia);

            return usuario != null;

        }
    }
}
