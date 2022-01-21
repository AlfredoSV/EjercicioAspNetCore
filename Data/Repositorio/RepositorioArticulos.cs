using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Data.Dtos;

namespace Data.Repositorio
{
    public class RepositorioArticulos
    {
        private string _conexion { get; set; }
        public RepositorioArticulos(string conexion)
        {
            _conexion = conexion;

        }

        public IEnumerable<DtoArticulo> ListarArticulos()
        {
            var sql = @"SELECT [codigo]
                         ,[descripcion]
                         ,[precio]
                         ,[imagen]
                         ,[stock]
                         ,[fechaAlta]
                      FROM [Articulos]";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                return db.Query<DtoArticulo>(sql);
            }
        }

        public DtoArticulo BuscarArticuloPorId(Guid idCliente)
        {
            var sql = "";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                return db.Query<DtoArticulo>(sql, idCliente).FirstOrDefault();
            }
        }

        public void EliminarArticulo(Guid id)
        {
            var sql = "";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, id);
            }
        }

        public void GuardarArticulo(DtoArticulo dtoCliente)
        {
            var sql = @"";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, dtoCliente);
            }
        }

        public void EditarArticulo(DtoArticulo dtoCliente)
        {
            var sql = @"";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, dtoCliente);
            }
        }
    }
}
