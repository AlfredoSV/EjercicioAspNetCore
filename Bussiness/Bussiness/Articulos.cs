
using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


using Data.Repositorio;
namespace Bussiness.Bussiness
{
    public class Articulos
    {
        private RepositorioArticulos _repositorioArticulos { get; set; }
        public Articulos(string conex)
        {
            _repositorioArticulos = new RepositorioArticulos(conex);
        }
        public IEnumerable<DtoArticulo> ConsultarArticulos()
        {
            return _repositorioArticulos.ListarArticulos();
        }

        public IEnumerable<DtoArticulo> ConsultarArticulosPorIdTienda(Guid idTienda)
        {
            return _repositorioArticulos.ListarArticulosPorTienda(idTienda);
        }


        public void GuardarArticulo(DtoArticulo articulo)
        {
            _repositorioArticulos.GuardarArticulo(articulo);
            _repositorioArticulos.GuardarArticuloTienda(articulo);
        }

        public DtoArticulo BuscarArticuloPorId(Guid idArticulo)
        {
            return _repositorioArticulos.BuscarArticuloPorId(idArticulo);
        }

        public void GuardarArticuloEditado(DtoArticulo articulo)
        {
            _repositorioArticulos.EditarArticulo(articulo);
        }

        public void EliminarArticulo(Guid idArticulo)
        {
            _repositorioArticulos.EliminarArticuloTienda(idArticulo);
            _repositorioArticulos.EliminarArticulo(idArticulo);

        }

    }
}
