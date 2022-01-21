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
            var sql = "select [idCliente],[nombre],[codigoPostal],[estado],[delegacionMunicipio],[calleNum] from Clientes";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                return db.Query<DtoCliente>(sql);
            }
        }

        public DtoCliente BuscarClientePorId(Guid idCliente)
        {
            var sql = "select [idCliente],[nombre],[codigoPostal],[estado],[delegacionMunicipio],[calleNum] from Clientes where [idCliente] = @idCliente";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                return db.Query<DtoCliente>(sql, new { idCliente }).FirstOrDefault();
            }
        }

        public void EliminarCliente(Guid idCliente)
        {
            var sql = "Delete from Clientes where idCliente = @idCliente";

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
            var sql = @"UPDATE [dbo].[Clientes]
            SET [idCliente] = @idCliente
            ,[nombre] = @nombre
            ,[codigoPostal] = @codigoPostal
            ,[estado] = @estado
            ,[delegacionMunicipio] = @delegacionMunicipio
            ,[calleNum] = @calleNum
            WHERE [idCliente] = @idCliente";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, dtoCliente);
            }
        }
    }
}
