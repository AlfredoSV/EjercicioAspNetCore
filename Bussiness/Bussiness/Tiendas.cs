
using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Repositorio;
using System.Linq;

namespace Bussiness.Bussiness
{
    public class Tiendas
    {
        RepositorioTiendas _repositorioTiendas { get; set; }
        public Tiendas(string conex)
        {
            _repositorioTiendas = new RepositorioTiendas(conex);
        }
        public IEnumerable<DtoTienda> ConsultarTiendasPorUsuario(Guid idUsuario)
        {
            return _repositorioTiendas.ListarTiendas().ToList().Where((x) => x.IdUsuario == idUsuario);
        }
        public IEnumerable<DtoTienda> ConsultarTiendasCompra()
        {
            return _repositorioTiendas.ListarTiendas();
        }
        public void CrearTienda(Guid idUsuario, DtoTienda dtoTienda)
        {
            _repositorioTiendas.GuardarTienda(idUsuario, dtoTienda);
        }
        public void EditarTienda(DtoTienda dtoTienda)
        {
            _repositorioTiendas.EditarTienda(dtoTienda);
        }

        public DtoTienda BuscarTiendaPorId(Guid idTienda)
        {
            return _repositorioTiendas.BuscarTiendaPorId(idTienda);
        }

        public void EliminarTienda(Guid idTienda)
        {
            _repositorioTiendas.EliminarTienda(idTienda);
        }
    }
}
