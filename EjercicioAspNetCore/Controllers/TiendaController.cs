using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositorio;
using Data.Dtos;
using Microsoft.Extensions.Configuration;
using EjercicioAspNetCore.Models;
using Bussiness.Bussiness;
using EjercicioAspNetCore.Filters;
using Microsoft.AspNetCore.Http;


namespace EjercicioAspNetCore.Controllers
{
    [TypeFilter(typeof(FiltroAuthSession))]
    public class TiendaController : Controller
    {
        private Tiendas _tiendas { get; set; }
        public TiendaController(IConfiguration configuration)
        {
            _tiendas = new Tiendas(configuration.GetConnectionString("bd"));

        }
        public IActionResult Index()
        {
            ViewBag.Rol = HttpContext.Session.GetString("Rol").ToString();
            return View();
        }

        [HttpGet]
        public IActionResult ListarTiendas()
        {
            var tiendas = _tiendas.ConsultarTiendas();

            return Json(tiendas);
        }


        [HttpPost]
        public IActionResult CrearTienda([FromForm] Tienda cliente)
        {


            if (ModelState.IsValid)
            {
                var dtoTienda = DtoTienda.Create(cliente.Sucursal, cliente.CodigoPostal, cliente.Estado, cliente.DelegacionMunicipio, cliente.CalleNum);
                _tiendas.CrearTienda(dtoTienda);
                return RedirectToAction("Index", "Cliente");

            }
            return View("Index");

        }


        [HttpGet("Tienda/EditarTienda/{idTienda}")]
        public IActionResult EditarTienda(Guid idTienda)
        {

            ViewBag.ErrorBusquedaCliente = false;
            var clienteRes = _tiendas.BuscarTiendaPorId(idTienda);

            if (clienteRes == null)
            {
                ViewBag.ErrorBusquedaCliente = true;
                return RedirectToAction("Index", "Tienda");
            }

            Tienda tiendaModel = new Tienda()
            {
                IdTienda = clienteRes.IdTienda,
                Sucursal = clienteRes.sucursal,
                CodigoPostal = clienteRes.CodigoPostal,
                Estado = clienteRes.Estado,
                DelegacionMunicipio = clienteRes.DelegacionMunicipio,
                CalleNum = clienteRes.CalleNum
            };
            ViewBag.Rol = HttpContext.Session.GetString("Rol").ToString();
            return View("EditarTienda", tiendaModel);

        }
        [HttpPost]
        public IActionResult GuardarTiendaEditada([FromForm] Tienda tienda)
        {

            if (ModelState.IsValid)
            {
                var dtoTienda = DtoTienda.Create(tienda.IdTienda, tienda.Sucursal, tienda.CodigoPostal, tienda.Estado, tienda.DelegacionMunicipio, tienda.CalleNum);
                _tiendas.EditarTienda(dtoTienda);
                return RedirectToAction("Index", "Cliente");

            }
            return View("EditarCliente", tienda);

        }

        [HttpGet]
        public IActionResult Cancelar()
        {

            return RedirectToAction("Index", "Tienda");

        }

        [HttpGet("Tienda/EliminarTienda/{idTienda}")]
        public IActionResult EliminarCliente(Guid idTienda)
        {

            ViewBag.TiendaEliminada = true;
            _tiendas.EliminarTienda(idTienda);

            return RedirectToAction("Index", "Tienda");

        }

    }
}
