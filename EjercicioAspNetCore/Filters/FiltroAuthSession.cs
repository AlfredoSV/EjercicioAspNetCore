using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjercicioAspNetCore.Controllers;


namespace EjercicioAspNetCore.Filters
{
    public class FiltroAuthSession : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

            var usuario = context.HttpContext.Session.GetString("Usuario");
            var rol = context.HttpContext.Session.GetString("Rol"); ;

            if ((usuario == null || usuario.Equals("")) || (rol == null || rol.Equals("")))
            {
                var controller = (ControllerBase)context.Controller;
                context.Result = controller.RedirectToAction("Index", "Login");
            }


        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var usuario = context.HttpContext.Session.GetString("Usuario");
            var rol = context.HttpContext.Session.GetString("Rol"); ;

            if ((usuario == null || usuario.Equals("")) || (rol == null || rol.Equals("")))
            {
                var controller = (ControllerBase)context.Controller;
                context.Result = controller.RedirectToAction("Index", "Login");
            }

        }
    }
}
