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

        private Articulos _articulos { get; set; }
        public TiendaController(IConfiguration configuration)
        {
            _tiendas = new Tiendas(configuration.GetConnectionString("bd"));
            _articulos = new Articulos(configuration.GetConnectionString("bd"));

        }
        public IActionResult Index()
        {
            ViewBag.Rol = HttpContext.Session.GetString("Rol").ToString();

            return View();
        }

        [HttpGet]
        public IActionResult ListarTiendas()
        {
            var idUsuario = Guid.Parse(HttpContext.Session.GetString("IdUsuario").ToString());
            var tiendas = _tiendas.ConsultarTiendasPorUsuario(idUsuario).ToList();

            return Json(tiendas);
        }


        [HttpPost]
        public IActionResult CrearTienda([FromForm] Tienda cliente)
        {


            if (ModelState.IsValid)
            {
                var idUsuario = Guid.Parse(HttpContext.Session.GetString("IdUsuario").ToString());
                var dtoTienda = DtoTienda.Create(cliente.Sucursal, cliente.CodigoPostal, cliente.Estado, cliente.DelegacionMunicipio, cliente.CalleNum);
                _tiendas.CrearTienda(idUsuario, dtoTienda);
                return RedirectToAction("Index", "Tienda");

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
                Sucursal = clienteRes.Sucursal,
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
                var idUsuario = Guid.Parse(HttpContext.Session.GetString("IdUsuario").ToString());
                var dtoTienda = DtoTienda.Create(tienda.IdTienda, tienda.Sucursal, tienda.CodigoPostal, tienda.Estado, tienda.DelegacionMunicipio, tienda.CalleNum, idUsuario);
                _tiendas.EditarTienda(dtoTienda);

                ViewBag.Rol = HttpContext.Session.GetString("Rol").ToString();

                return RedirectToAction("Index", "Tienda");

            }
            return View("EditarTienda", tienda);

        }

        [HttpGet]
        public IActionResult Cancelar()
        {

            return RedirectToAction("Index", "Tienda");

        }

        [HttpGet("Tienda/EliminarTienda/{idTienda}")]
        public IActionResult EliminarTienda(Guid idTienda)
        {
            ViewBag.TiendaArticulosAsociados = true;
            var idUsuario = Guid.Parse(HttpContext.Session.GetString("IdUsuario").ToString());
            var articulos = _articulos.ConsultarArticulosPorIdTienda(idTienda);


            if (articulos.Count() <= 0)
            {
                _tiendas.EliminarTienda(idTienda);
                ViewBag.TiendaArticulosAsociados = false;
                return RedirectToAction("Index", "Tienda");
            }

            ViewBag.Rol = HttpContext.Session.GetString("Rol").ToString();

            return View("Index");

        }

        [HttpGet]
        public IActionResult ConsultarDetalleTienda(Guid idTienda)
        {
            return Json(_tiendas.BuscarTiendaPorId(idTienda));
        }


    }
}
