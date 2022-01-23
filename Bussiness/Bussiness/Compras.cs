using Data.Dtos;
using Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Bussiness
{
    public class Compras
    {
        RepositorioCompras _repositorioCompras { get; set; }
        public Compras(string conex)
        {
            _repositorioCompras = new RepositorioCompras(conex);
        }

        public void GenerarCompra(DtoCompra dtoCompra, Guid idCliente)
        {
            var idCompra = Guid.NewGuid();
            var fechaCompra = DateTime.Now;

            _repositorioCompras.GuardarCompra(dtoCompra, idCompra, idCliente, fechaCompra);

            _repositorioCompras.GuardarArticulosDeCompra(dtoCompra, idCompra, fechaCompra);
        }

        public IEnumerable<DtoCompra> ConsultarComprasPorCliente(Guid idUsuario)
        {
            return _repositorioCompras.ConsultarMisCompras(idUsuario);
        }
    }
}
