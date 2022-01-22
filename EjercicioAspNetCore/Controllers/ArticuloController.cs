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
using Microsoft.AspNetCore.Http;
using Bussiness.Servicios;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EjercicioAspNetCore.Controllers
{
    [TypeFilter(typeof(FiltroAuthSession))]
    public class ArticuloController : Controller
    {
        private Articulos _articulos { get; set; }
        private Tiendas _tiendas { get; set; }
        public ArticuloController(IConfiguration configuration)
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

        [HttpGet]
        public IActionResult ListarArticulos()
        {
            var articulos = _articulos.ConsultarArticulos();

            return Json(articulos);
        }

        [HttpPost]
        public IActionResult CrearArticulo([FromForm] Articulo articulo)
        {
            var imagen = string.Empty;
            if (ModelState.IsValid)
            {
                if (articulo.Imagen != null)
                {
                    imagen = ServicioImagenToBase64.ConvertToBase64(articulo.Imagen.OpenReadStream());
                }

                var dtoArticulo = DtoArticulo.Create(articulo.Descripcion, articulo.Precio, imagen, articulo.Stock, articulo.IdTienda);
                _articulos.GuardarArticulo(dtoArticulo);
                return RedirectToAction("Index", "Articulo");

            }
            ViewBag.Rol = HttpContext.Session.GetString("Rol").ToString();
            return View("Index");

        }

        [HttpGet("Articulo/EditarArticulo/{idArticulo}")]
        public IActionResult EditarCliente(Guid idArticulo)
        {

            ViewBag.ErrorBusquedaCliente = false;
            var articuloRes = _articulos.BuscarArticuloPorId(idArticulo);

            if (articuloRes == null)
            {
                ViewBag.ErrorBusquedaArticulo = true;
                return RedirectToAction("Index", "Articulo");
            }

            Articulo articuloModel = new Articulo()
            {
                Codigo = articuloRes.Codigo,
                Descripcion = articuloRes.Descripcion,
                ImgBase64 = articuloRes.Imagen,
                Precio = articuloRes.Precio,
                Stock = articuloRes.Stock
            };
            ViewBag.Rol = HttpContext.Session.GetString("Rol").ToString();
            return View("EditarArticulo", articuloModel);

        }

        [HttpPost]
        public IActionResult GuardarArticuloEditado([FromForm] Articulo articulo)
        {
            var imagen = string.Empty;
            if (ModelState.IsValid)
            {
                if (articulo.Imagen == null)
                {

                    imagen = "";
                }
                else
                {
                    imagen = ServicioImagenToBase64.ConvertToBase64(articulo.Imagen.OpenReadStream());
                }

                var dtoArticulo = DtoArticulo.Create(articulo.Codigo, articulo.Descripcion, articulo.Precio, imagen, articulo.Stock);
                _articulos.GuardarArticuloEditado(dtoArticulo);
                return RedirectToAction("Index", "Articulo");

            }
            return View("EditarArticulo", articulo);

        }

        [HttpGet]
        public IActionResult Cancelar()
        {

            return RedirectToAction("Index", "Articulo");

        }


        [HttpGet("Articulo/EliminarArticulo/{idArticulo}")]
        public IActionResult EliminarCliente(Guid idArticulo)
        {

            ViewBag.idArticuloEliminado = true;
            _articulos.EliminarArticulo(idArticulo);
            return RedirectToAction("Index", "Articulo");

        }
    }
}
