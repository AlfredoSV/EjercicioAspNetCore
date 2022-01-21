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
            return View();
        }

        [HttpGet]
        public IActionResult ListarTiendas()
        {
            var clientes = _tiendas.ConsultarTiendas();

            return Json(clientes);
        }
    }
}
