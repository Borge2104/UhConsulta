using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppUHConsultas.Models;

namespace WebAppUHConsultas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: Tarjetas/Create
        [HttpGet]
        public ViewResult agregar_usuario()
        {
            return View();

        }

        // POST: Tarjetas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult agregar_usuario(Create_Usuario us)
        {
            if (ModelState.IsValid)
            {
                us.ingreso();
                return View();
            }
            else
            {
                // there is a validation error
                return View();
            }



        }
    }
}