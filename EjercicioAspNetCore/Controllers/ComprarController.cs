using Bussiness.Bussiness;
using EjercicioAspNetCore.Filters;
using EjercicioAspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjercicioAspNetCore.Models.ModelsCompra;

namespace EjercicioAspNetCore.Controllers
{
    [TypeFilter(typeof(FiltroAuthSession))]
    public class ComprarController : Controller
    {
        private Articulos _articulos { get; set; }
        private Tiendas _tiendas { get; set; }
        public ComprarController(IConfiguration configuration)
        {
            _articulos = new Articulos(configuration.GetConnectionString("bd"));
            _tiendas = new Tiendas(configuration.GetConnectionString("bd"));

        }
        public IActionResult Index()
        {
            ViewBag.Rol = HttpContext.Session.GetString("Rol").ToString();

            var tiendas = new List<SelectListItem>();
            _tiendas.ConsultarTiendas().ToList().ForEach(x =>
            {
                tiendas.Add(new SelectListItem(x.sucursal, x.IdTienda.ToString()));
            });
            ViewBag.Tiendas = tiendas;

            return View();
        }

        public IActionResult HistorialDeCompras()
        {
            ViewBag.Rol = HttpContext.Session.GetString("Rol").ToString();
            return View();
        }

        [HttpGet]
        public IActionResult ArticulosPoTienda(Guid idTienda)
        {

            return Json(_articulos.ConsultarArticulosPorIdTienda(idTienda));
        }


        [HttpPost]
        public IActionResult GenerarCompra(Compra compra)
        {

            return RedirectToAction("Index", "CompraR");
        }
    }
}
