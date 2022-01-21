
using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

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

        /*public void RegistrarCliente(DtoCliente cliente)
        {

            _repositorioClientes.GuardarCliente(cliente);
        }

        public DtoCliente BuscarClientePorId(Guid idCliente)
        {
            return _repositorioClientes.BuscarClientePorId(idCliente);
        }

        public void GuardarClienteEditado(DtoCliente cliente)
        {
            _repositorioClientes.EditarCliente(cliente);
        }

        public void EliminarCliente(Guid idCliente)
        {
            _repositorioClientes.EliminarCliente(idCliente);
        }*/

    }
}
