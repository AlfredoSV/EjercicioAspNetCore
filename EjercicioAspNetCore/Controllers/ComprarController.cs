using EjercicioAspNetCore.Filters;
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
            return View();
        }
    }
}
