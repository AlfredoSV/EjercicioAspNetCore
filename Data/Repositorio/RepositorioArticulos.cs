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

        public DtoArticulo BuscarArticuloPorId(Guid idArticulo)
        {
            var sql = @"SELECT [codigo]
                         ,[descripcion]
                         ,[precio]
                         ,[imagen]
                         ,[stock]
                         ,[fechaAlta]
                      FROM [Articulos] where codigo = @idArticulo";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                return db.Query<DtoArticulo>(sql, new { idArticulo }).FirstOrDefault();
            }
        }



        public void EliminarArticulo(Guid idArticulo)
        {
            var sql = "DELETE FROM [dbo].[Articulos] WHERE codigo = @idArticulo";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, new { idArticulo });
            }
        }

        public void EliminarArticuloTienda(Guid idArticulo)
        {
            var sql = "DELETE FROM [dbo].[ArticulosTiendas] WHERE codigo = @idArticulo";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, new { idArticulo });
            }
        }

        public void GuardarArticulo(DtoArticulo dtoArticulo)
        {

            var sql = @"INSERT INTO [dbo].[Articulos]
           ([codigo]
           ,[descripcion]
           ,[precio]
           ,[imagen]
           ,[stock]
           ,[fechaAlta])
            VALUES
           (@codigo
           ,@descripcion
           ,@precio
           ,@imagen
           ,@stock
           ,GETDATE())";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Execute(sql, dtoArticulo);

            }
        }

        public void GuardarArticuloTienda(DtoArticulo dtoArticulo)
        {

            var sql = @"INSERT INTO [dbo].[ArticulosTiendas]
           ([idArticuloTienda]
           ,[codigo]
           ,[idTienda]
           ,[fecha])
            VALUES
           (NEWID()
           ,@codigo,
            @idTienda,
            GETDATE())";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Execute(sql, new { dtoArticulo.Codigo, dtoArticulo.IdTienda });

            }
        }

        public void EditarArticulo(DtoArticulo articulo)
        {
            var sql = @"UPDATE [dbo].[Articulos]
   SET [descripcion] = @descripcion
      ,[precio] =  @precio
      ,[imagen] = @imagen
      ,[stock] = @stock
 WHERE codigo = @codigo";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();
                db.Query(sql, articulo);
            }
        }
    }
}
