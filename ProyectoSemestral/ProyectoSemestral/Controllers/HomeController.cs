using BolsaTrabajoWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolsaTrabajoWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Ofertas");
            //return View();
        }
        public ActionResult TestDB()
        {
            var dt = DbHelper.ExecuteDataTable("sp_Reporte_TopOfertas", null);
            return Content("Conectado. Filas devueltas: " + dt.Rows.Count);
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
    }
}