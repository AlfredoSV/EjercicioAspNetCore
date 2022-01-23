using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Data.Dtos;

namespace Data.Repositorio
{
    public class RepositorioTiendas
    {
        private string _conexion { get; set; }
        public RepositorioTiendas(string conexion)
        {
            _conexion = conexion;

        }

        public IEnumerable<DtoTienda> ListarTiendas()
        {
            var sql = @"SELECT [idTienda]
                        ,[sucursal]
                        ,[codigoPostal]
                        ,[estado]
                        ,[delegacionMunicipio]
                        ,[calleNum]
                        ,[idUsuario]
                        FROM [Tiendas]";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                return db.Query<DtoTienda>(sql);
            }
        }

        public DtoTienda BuscarTiendaPorId(Guid idTienda)
        {
            var sql = @"SELECT [idTienda]
                        ,[sucursal]
                        ,[codigoPostal]
                        ,[estado]
                        ,[delegacionMunicipio]
                        ,[calleNum]
                        FROM [Tiendas] WHERE idTienda = @idTienda";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                return db.Query<DtoTienda>(sql, new { idTienda }).FirstOrDefault();
            }
        }

        public void EliminarTienda(Guid idTienda)
        {
            var sql = "DELETE FROM TIENDAS WHERE idTienda = @idTienda";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, new { idTienda });
            }
        }

        public void GuardarTienda(Guid idUsuario, DtoTienda dtoTienda)
        {
            var sql = @"INSERT INTO [dbo].[Tiendas]
           ([idTienda]
           ,[sucursal]
           ,[codigoPostal]
           ,[estado]
           ,[idUsuario]
           ,[delegacionMunicipio]
           ,[calleNum])
     VALUES
           (NEWID()
           ,@sucursal
           ,@codigoPostal
           ,@estado
           ,@idUsuario
           ,@delegacionMunicipio
           ,@calleNum)";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, new { dtoTienda.Sucursal, dtoTienda.CodigoPostal, dtoTienda.Estado, idUsuario, dtoTienda.DelegacionMunicipio, dtoTienda.CalleNum });
            }
        }

        public void EditarTienda(DtoTienda dtoTienda)
        {
            var sql = @"UPDATE [dbo].[Tiendas] SET 
                      [sucursal] = @sucursal
                     ,[codigoPostal] = @codigoPostal
                     ,[estado] = @estado
                     ,[delegacionMunicipio] = @delegacionMunicipio
                     ,[calleNum] = @calleNum
                     WHERE [idTienda] = @idTienda";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, dtoTienda);
            }
        }
    }
}
