using BolsaTrabajoWeb.Data;
using BolsaTrabajoWeb.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolsaTrabajoWeb.Controllers
{
    public class AplicacionesController : Controller
    {
        [HttpPost]
        public ActionResult Aplicar(int ofertaId)
        {
            if (!AuthGuard.IsRole(this, "Empleado")) return AuthGuard.Deny();

            var user = AuthGuard.CurrentUser(this);

            try
            {
                DbHelper.ExecuteScalar("sp_Aplicacion_Crear", new[]
                {
                    new SqlParameter("@OfertaId", ofertaId),
                    new SqlParameter("@EmpleadoId", user.UsuarioId)
                });

                // Email (opcional): aquí puedes notificar al empleador.
                // Para no romper tu demo si SMTP no está listo, lo dejo comentado.
                // En el punto 4 te pongo cómo dejar SMTP en web.config.

                TempData["Ok"] = "Aplicación enviada.";
            }
            catch (SqlException ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("Details", "Ofertas", new { id = ofertaId });
        }

        [HttpGet]
        public ActionResult MisAplicaciones()
        {
            if (!AuthGuard.IsRole(this, "Empleado")) return AuthGuard.Deny();

            var user = AuthGuard.CurrentUser(this);
            var dt = DbHelper.ExecuteDataTable("sp_Aplicaciones_MisAplicaciones", new[]
            {
                new SqlParameter("@EmpleadoId", user.UsuarioId)
            });

            ViewBag.Data = dt;
            return View();
        }

        [HttpGet]
        public ActionResult Recibidas(int ofertaId)
        {
            if (!AuthGuard.IsRole(this, "Empleador")) return AuthGuard.Deny();

            var user = AuthGuard.CurrentUser(this);
            var dt = DbHelper.ExecuteDataTable("sp_Aplicaciones_Recibidas", new[]
            {
                new SqlParameter("@EmpleadorId", user.UsuarioId),
                new SqlParameter("@OfertaId", ofertaId),
            });

            ViewBag.OfertaId = ofertaId;
            ViewBag.Data = dt;
            return View();
        }

        [HttpPost]
        public ActionResult CambiarEstado(int ofertaId, int aplicacionId, string nuevoEstado, string comentario)
        {
            if (!AuthGuard.IsRole(this, "Empleador")) return AuthGuard.Deny();

            var user = AuthGuard.CurrentUser(this);

            try
            {
                DbHelper.ExecuteNonQuery("sp_Aplicacion_CambiarEstado", new[]
                {
                    new SqlParameter("@EmpleadorId", user.UsuarioId),
                    new SqlParameter("@AplicacionId", aplicacionId),
                    new SqlParameter("@NuevoEstado", nuevoEstado),
                    new SqlParameter("@Comentario", (object)comentario ?? DBNull.Value),
                });

                TempData["Ok"] = "Estado actualizado.";
            }
            catch (SqlException ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("Recibidas", new { ofertaId });
        }
    }
}