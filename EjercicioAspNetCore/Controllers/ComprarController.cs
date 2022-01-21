using EjercicioAspNetCore.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioAspNetCore.Controllers
{
    [TypeFilter(typeof(FiltroAuthSession))]
    public class ComprarController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Rol = HttpContext.Session.GetString("Rol").ToString();
            return View();
        }

        public IActionResult HistorialDeCompras()
        {
            ViewBag.Rol = HttpContext.Session.GetString("Rol").ToString();
            return View();
        }
    }
}
