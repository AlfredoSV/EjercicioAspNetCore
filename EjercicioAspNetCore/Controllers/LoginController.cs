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
using Microsoft.AspNetCore.Mvc.Rendering;

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
                    if (usuarioRes.Rol.Equals("Vendedor"))
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

        [HttpGet]
        public IActionResult RegistroUsuario()
        {
            this.CargarRoles();
            return View();
        }

        [HttpPost]
        public IActionResult GuardarRegistro(RegistroUsuario registro)
        {
            if (ModelState.IsValid)
            {
                var nuevoUsuario = DtoUsuarioLogin.Create(registro.Correo, registro.Contrasenia, registro.Nombre,
                    registro.CodigoPostal, registro.Estado, registro.DelegacionMunicipio, registro.CalleNum,
                    registro.IdRol);

                _login.RegistrarUsuario(nuevoUsuario);

                return View("Index");
            }

            this.CargarRoles();

            return View("RegistroUsuario");
        }

        #region Métodos privados

        private void CargarRoles()
        {
            var roles = new List<SelectListItem>();
            _login.ObtenerRoles().ToList().ForEach(x =>
            {
                roles.Add(new SelectListItem(x.Nombre, x.IdRol.ToString()));
            });
            ViewBag.Roles = roles;
        }

        #endregion
    }
}
