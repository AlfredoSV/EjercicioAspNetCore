using Dapper;
using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data.Repositorio
{
    public class RepositorioCompras
    {
        private string _conexion { get; set; }
        public RepositorioCompras(string conexion)
        {
            _conexion = conexion;

        }

        public IEnumerable<DtoCompra> ConsultarMisCompras(Guid idUsuario)
        {
            var sql = @"SELECT
      [idUsuario] as idCliente
      ,[fecha]
      ,[total]
  FROM [EjercicioAspNetCore].[dbo].[ClientesArticulosCompra] where idUsuario = @idUsuario";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();


                return db.Query<DtoCompra>(sql, new
                {
                    idUsuario
                });


            }
        }
        public void GuardarArticulosDeCompra(DtoCompra dtoCompra, Guid idCompra, DateTime fechaCompra)
        {
            var sql = @"
            INSERT INTO [dbo].[DetalleArticulosCompra]
           ([idDetalleCompra],[codigo]
           ,[idCompra]
           ,[precio]
           ,[cantidad]
           ,[fechaCompra])
             VALUES
           (newid(),@codigo
           ,@idCompra
           ,@precio
           ,@cantidad
           ,@fechaCompra)";

            var sqlActualizarStock = @"UPDATE Articulos SET stock = (select stock from Articulos where codigo = @codigo) - @cantidadAr
            where codigo = @codigo";
            using (var db = new SqlConnection(_conexion))
            {
                db.Open();

                foreach (var articulo in dtoCompra.Articulos)
                {
                    db.Query(sqlActualizarStock, new { articulo.Codigo, articulo.CantidadAr });
                    db.Query(sql, new
                    {
                        articulo.Codigo,
                        idCompra,
                        Precio = Convert.ToDecimal(articulo.Sub),
                        Cantidad = articulo.CantidadAr,
                        fechaCompra
                    });
                }

            }
        }

        public void GuardarCompra(DtoCompra dtoCompra, Guid idCompra, Guid idUsuario, DateTime fechaCompra)
        {
            var sql = @"INSERT INTO [dbo].[ClientesArticulosCompra]
           ([idCompra]
           ,[idUsuario]
           ,[fecha]
           ,[total])
     VALUES
           (@idCompra
           ,@idUsuario
           ,@fecha
           ,@total)";

            using (var db = new SqlConnection(_conexion))
            {
                db.Open();


                db.Query(sql, new
                {

                    idCompra,
                    idUsuario,
                    Fecha = fechaCompra,
                    dtoCompra.Total

                });

            }
        }



    }
}
