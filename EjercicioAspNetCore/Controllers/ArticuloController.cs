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

namespace EjercicioAspNetCore.Controllers
{
    [TypeFilter(typeof(FiltroAuthSession))]
    public class ArticuloController : Controller
    {
        private Articulos _articulos { get; set; }
        public ArticuloController(IConfiguration configuration)
        {
            _articulos = new Articulos(configuration.GetConnectionString("bd"));

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListarArticulos()
        {
            var articulos = _articulos.ConsultarArticulos();

            return Json(articulos);
        }
    }
}
