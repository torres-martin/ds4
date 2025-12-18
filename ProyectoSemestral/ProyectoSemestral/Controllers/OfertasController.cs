using BolsaTrabajoWeb.Data;
using BolsaTrabajoWeb.Helpers;
using BolsaTrabajoWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolsaTrabajoWeb.Controllers
{
    public class OfertasController : Controller
    {
        [HttpGet]
        public ActionResult Index(OfertaSearchVM filtros)
        {
            var dt = DbHelper.ExecuteDataTable("sp_Ofertas_Buscar", new[]
            {
                new SqlParameter("@Texto", (object)filtros.Texto ?? DBNull.Value),
                new SqlParameter("@Ubicacion", (object)filtros.Ubicacion ?? DBNull.Value),
                new SqlParameter("@Tipo", (object)filtros.Tipo ?? DBNull.Value),
            });

            ViewBag.Data = dt;
            return View(filtros);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var dt = DbHelper.ExecuteDataTable("sp_Oferta_Detalle", new[]
            {
                new SqlParameter("@OfertaId", id)
            });

            if (dt.Rows.Count == 0) return HttpNotFound();

            ViewBag.Row = dt.Rows[0];
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (!AuthGuard.IsRole(this, "Empleador")) return AuthGuard.Deny();
            return View(new OfertaCreateVM());
        }

        [HttpPost]
        public ActionResult Create(OfertaCreateVM model)
        {
            if (!AuthGuard.IsRole(this, "Empleador")) return AuthGuard.Deny();
            if (!ModelState.IsValid) return View(model);

            var user = AuthGuard.CurrentUser(this);

            var idObj = DbHelper.ExecuteScalar("sp_Oferta_Crear", new[]
            {
                new SqlParameter("@EmpleadorId", user.UsuarioId),
                new SqlParameter("@Titulo", model.Titulo),
                new SqlParameter("@Descripcion", model.Descripcion),
                new SqlParameter("@Ubicacion", (object)model.Ubicacion ?? DBNull.Value),
                new SqlParameter("@Tipo", (object)model.Tipo ?? DBNull.Value),
                new SqlParameter("@Salario", (object)model.Salario ?? DBNull.Value),
            });

            int ofertaId = Convert.ToInt32(idObj);
            return RedirectToAction("Details", new { id = ofertaId });
        }

        [HttpGet]
        public ActionResult MisPublicaciones()
        {
            if (!AuthGuard.IsRole(this, "Empleador")) return AuthGuard.Deny();

            var user = AuthGuard.CurrentUser(this);
            var dt = DbHelper.ExecuteDataTable("sp_Ofertas_MisPublicaciones", new[]
            {
                new SqlParameter("@EmpleadorId", user.UsuarioId)
            });

            ViewBag.Data = dt;
            return View();
        }
    }
}