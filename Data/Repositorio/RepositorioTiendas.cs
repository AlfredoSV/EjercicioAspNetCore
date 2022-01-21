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
                        FROM[Tiendas]";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                return db.Query<DtoTienda>(sql);
            }
        }

        public DtoArticulo BuscarTiendaPorId(Guid idCliente)
        {
            var sql = "";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                return db.Query<DtoArticulo>(sql, idCliente).FirstOrDefault();
            }
        }

        public void EliminarTienda(Guid id)
        {
            var sql = "";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, id);
            }
        }

        public void GuardarTienda(DtoTienda dtoTienda)
        {
            var sql = @"";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, dtoTienda);
            }
        }

        public void EditarTienda(DtoTienda dtoTienda)
        {
            var sql = @"";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, dtoTienda);
            }
        }
    }
}
