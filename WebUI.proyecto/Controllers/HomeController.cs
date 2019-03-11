using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.proyecto.App_Code;

namespace WebUI.proyecto.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.usuario = Constantes.USUARIO;
            return View();
        }

        Action<Exception> ManejaError = ex =>
        {

        };
    }
}