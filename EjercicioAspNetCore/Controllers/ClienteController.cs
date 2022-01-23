using Bussiness.Bussiness;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositorio;
using Data.Dtos;
using Microsoft.Extensions.Configuration;
using EjercicioAspNetCore.Models;
using EjercicioAspNetCore.Filters;
using Microsoft.AspNetCore.Http;

namespace EjercicioAspNetCore.Controllers
{
    [TypeFilter(typeof(FiltroAuthSession))]
    public class ClienteController : Controller
    {
        private Clientes _clientes { get; set; }
        public ClienteController(IConfiguration configuration)
        {
            _clientes = new Clientes(configuration.GetConnectionString("bd"));

        }
        public IActionResult Index()
        {
            ViewBag.Rol = HttpContext.Session.GetString("Rol").ToString();
            return View();
        }

        [HttpGet]
        public IActionResult ListarClientes()
        {
            var clientes = _clientes.ConsultarClientes();

            return Json(clientes);
        }

        [HttpGet("Cliente/EditarCliente/{idCliente}")]
        public IActionResult EditarCliente(Guid idCliente)
        {

            ViewBag.ErrorBusquedaCliente = false;
            var clienteRes = _clientes.BuscarClientePorId(idCliente);

            if (clienteRes == null)
            {
                ViewBag.ErrorBusquedaCliente = true;
                return RedirectToAction("Index", "Cliente");
            }

            Cliente clienteModel = new Cliente()
            {
                IdCliente = clienteRes.IdCliente,
                Nombre = clienteRes.Nombre,
                CodigoPostal = clienteRes.CodigoPostal,
                Estado = clienteRes.Estado,
                DelegacionMunicipio = clienteRes.DelegacionMunicipio,
                CalleNum = clienteRes.CalleNum
            };
            ViewBag.Rol = HttpContext.Session.GetString("Rol").ToString();
            return View("EditarCliente", clienteModel);

        }
        [HttpPost]
        public IActionResult GuardarClienteEditado([FromForm] Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                var dtoCliente = DtoCliente.Create(cliente.IdCliente, cliente.Nombre, cliente.CodigoPostal, cliente.Estado, cliente.DelegacionMunicipio, cliente.CalleNum);
                _clientes.GuardarClienteEditado(dtoCliente);
                return RedirectToAction("Index", "Cliente");

            }
            return View("EditarCliente", cliente);

        }

        [HttpGet]
        public IActionResult Cancelar()
        {

            return RedirectToAction("Index", "Cliente");

        }

        [HttpGet("Cliente/EliminarCliente/{idCliente}")]
        public IActionResult EliminarCliente(Guid idCliente)
        {

            ViewBag.ClienteEliminado = true;
            _clientes.EliminarCliente(idCliente);

            return RedirectToAction("Index", "Cliente");

        }

        [HttpGet]
        public IActionResult DetalleCliente(Guid idCliente)
        {
            return Json(_clientes.BuscarClientePorId(idCliente));
        }

    }
}
