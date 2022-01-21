using EjercicioAspNetCore.Models.LoginModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Dtos;
using Microsoft.AspNetCore.Http;
using Bussiness.Bussiness;
using Microsoft.Extensions.Configuration;

namespace EjercicioAspNetCore.Controllers
{
    public class LoginController : Controller
    {
        private Login _login { get; set; }
        public LoginController(IConfiguration configuration)
        {
            _login = new Login(configuration.GetConnectionString("bd"));

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion([FromForm] LoginUsuario loginUsuario)
        {
            var usuarioCorrecto = false;
            ViewBag.UsuarioIncorrecto = false;

            if (ModelState.IsValid)
            {
                var usuario = DtoUsuarioLogin.Create(loginUsuario.Usuario, loginUsuario.Contrasenia);

                usuarioCorrecto = _login.ValidarUsuario(usuario);

                if (usuarioCorrecto)
                {
                    HttpContext.Session.SetString("Usuario", usuario.Correo);
                    return RedirectToAction("Index", "Articulo");
                }
                else
                {
                    ViewBag.UsuarioIncorrecto = true;
                    return View("Index");

                }

            }
            return View("Index");
        }

        public IActionResult CerrarSesion()
        {
            HttpContext.Session.SetString("Usuario", "");
            return View("Index");
        }

        /*public IActionResult Registrarme()
        {
            return View();
        }*/


    }
}
