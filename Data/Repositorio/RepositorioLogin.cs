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
            var sql = @"SELECT usu.[idUsuario],usu.[correo]
                        ,usu.[contrasenia], ro.nombre as rol
                        FROM [Usuarios] usu inner join[UsuarioRol] usurol on usu.idUsuario= usurol.idUsuario inner join [Rol] ro
                        on ro.IdRol = usurol.idRol where correo = @usuario and contrasenia = @contrasenia ";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                return db.Query<DtoUsuarioLogin>(sql, new { usuario, contrasenia }).FirstOrDefault();
            }
        }

        public IEnumerable<DtoRol> ConsultarRoles()
        {
            var sql = @"SELECT [IdRol],[nombre] FROM [Rol]";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                return db.Query<DtoRol>(sql);
            }
        }

        public void RegistrarUsuario(DtoUsuarioLogin usuario)
        {
            var sql = @"INSERT INTO [dbo].[Usuarios]
           ([idUsuario]
           ,[correo]
           ,[contrasenia]
           ,[nombre]
           ,[codigoPostal]
           ,[estado]
           ,[delegacionMunicipio]
           ,[calleNum])
     VALUES
           (@idUsuario
           ,@correo
           ,@contrasenia
           ,@nombre
           ,@codigoPostal
           ,@estado
           ,@delegacionMunicipio
           ,@calleNum)";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, usuario);
            }
        }

        public void RegistrarUsuarioRol(DtoUsuarioLogin usuario)
        {
            var sql = @"INSERT INTO [dbo].[UsuarioRol]
            ([idRolUsuario]
           ,[idRol]
           ,[idUsuario])
             VALUES
           (newid()
           ,@idRol
           ,@idUsuario)";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, usuario);
            }
        }

    }
}
