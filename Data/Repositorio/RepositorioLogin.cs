using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Data.Dtos;

namespace Data.Repositorio
{
    public class RepositorioLogin
    {
        private string _conexion { get; set; }
        public RepositorioLogin(string conexion)
        {
            _conexion = conexion;

        }

        public DtoUsuarioLogin BuscarUsuarioLoginPorUsuario(string usuario, string contrasenia)
        {
            var sql = @"SELECT [IdUsuario]
                      ,[correo]
                      ,[contrasenia]
                     FROM[Usuarios] where correo = @usuario and contrasenia = @contrasenia ";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                return db.Query<DtoUsuarioLogin>(sql, new { usuario, contrasenia }).FirstOrDefault();
            }
        }

    }
}
