
using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Repositorio;
namespace Bussiness.Bussiness
{
    public class Tiendas
    {
        RepositorioTiendas _repositorioTiendas { get; set; }
        public Tiendas(string conex)
        {
            _repositorioTiendas = new RepositorioTiendas(conex);
        }
        public IEnumerable<DtoTienda> ConsultarTiendas()
        {
            return _repositorioTiendas.ListarTiendas();
        }
        public void CrearTienda(DtoTienda dtoTienda)
        {
            _repositorioTiendas.GuardarTienda(dtoTienda);
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
