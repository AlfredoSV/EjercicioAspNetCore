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

            var vl1 = context.HttpContext.Session.GetString("Usuario");

            if (vl1 == null || vl1.Equals(""))
            {
                var controller = (ControllerBase)context.Controller;
                context.Result = controller.RedirectToAction("Index", "Login");
            }


        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
