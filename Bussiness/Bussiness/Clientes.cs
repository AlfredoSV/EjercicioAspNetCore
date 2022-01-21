
using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

using Data.Repositorio;
namespace Bussiness.Bussiness
{
    public class Clientes
    {
        RepositorioClientes _repositorioClientes { get; set; }
        public Clientes(string conex)
        {
            _repositorioClientes = new RepositorioClientes(conex);
        }
        public IEnumerable<DtoCliente> ConsultarClientes()
        {
            return _repositorioClientes.ListarClientes();
        }

        public void RegistrarCliente(DtoCliente cliente)
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
        }

    }
}
