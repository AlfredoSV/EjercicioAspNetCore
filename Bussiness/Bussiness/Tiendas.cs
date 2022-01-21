
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
    }
}
