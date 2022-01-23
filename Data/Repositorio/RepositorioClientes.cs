using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Drapper;

using Dapper;
using System.Linq;
using Data.Dtos;

namespace Data.Repositorio
{
    public class RepositorioClientes
    {
        private string _conexion { get; set; }
        public RepositorioClientes(string conexion)
        {
            _conexion = conexion;

        }
        public IEnumerable<DtoCliente> ListarClientes()
        {
            var sql = @"select usu.[idUsuario] as idCliente,usu.[nombre],[codigoPostal],[estado],[delegacionMunicipio],[calleNum] from Usuarios usu
                        inner join UsuarioRol usuro on usuro.idUsuario = usu.idUsuario inner join
                        Rol ro on ro.IdRol = usuro.idRol where ro.nombre = 'Cliente' and estaActivo = 1";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                return db.Query<DtoCliente>(sql);
            }
        }

        public DtoCliente BuscarClientePorId(Guid idCliente)
        {
            var sql = "select [idUsuario] as idCliente,[nombre],[codigoPostal],[estado],[delegacionMunicipio],[calleNum] from Usuarios where [idUsuario] = @idCliente";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                return db.Query<DtoCliente>(sql, new { idCliente }).FirstOrDefault();
            }
        }

        public void EliminarCliente(Guid idCliente)
        {
            var sql = " UPDATE Usuarios SET estaActivo = 0 where idUsuario = @idCliente";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, new { idCliente });
            }
        }

        public void GuardarCliente(DtoCliente dtoCliente)
        {
            var sql = @"INSERT INTO [dbo].[Clientes]
           ([idCliente]
           ,[nombre]
           ,[codigoPostal]
           ,[estado]
           ,[delegacionMunicipio]
           ,[calleNum])
            VALUES
           (NEWID()
           ,@nombre
           ,@codigoPostal
           ,@estado
           ,@delegacionMunicipio
           ,@calleNum)";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, dtoCliente);
            }
        }

        public void EditarCliente(DtoCliente dtoCliente)
        {
            var sql = @"UPDATE [dbo].[Usuarios]
            SET 
             [nombre] = @nombre
            ,[codigoPostal] = @codigoPostal
            ,[estado] = @estado
            ,[delegacionMunicipio] = @delegacionMunicipio
            ,[calleNum] = @calleNum
            WHERE [idUsuario] = @idCliente";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, dtoCliente);
            }
        }
    }
}
