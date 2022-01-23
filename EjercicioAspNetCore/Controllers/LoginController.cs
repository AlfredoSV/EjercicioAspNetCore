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

            ViewBag.UsuarioIncorrecto = false;

            if (ModelState.IsValid)
            {
                var usuario = DtoUsuarioLogin.Create(loginUsuario.Usuario, loginUsuario.Contrasenia);

                var usuarioRes = _login.ObtenerUsuario(usuario);

                if (usuarioRes != null)
                {
                    HttpContext.Session.SetString("Usuario", usuarioRes.Correo);
                    HttpContext.Session.SetString("Rol", usuarioRes.Rol);
                    HttpContext.Session.SetString("IdUsuario", usuarioRes.IdUsuario.ToString());
                    if (usuarioRes.Rol.Equals("Admin"))
                        return RedirectToAction("Index", "Articulo");
                    else if (usuarioRes.Rol.Equals("Cliente"))
                        return RedirectToAction("Index", "Comprar");

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
            HttpContext.Session.SetString("Rol", "");
            return View("Index");
        }

        /*public IActionResult Registrarme()
        {
            return View();
        }*/


    }
}
