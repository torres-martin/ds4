using BolsaTrabajoWeb.Data;
using BolsaTrabajoWeb.Helpers;
using BolsaTrabajoWeb.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;

namespace BolsaTrabajoWeb.Controllers
{
    public class PerfilController : Controller
    {
        [HttpGet]
        public ActionResult Empleado()
        {
            if (!AuthGuard.IsRole(this, "Empleado")) return AuthGuard.Deny();

            var user = AuthGuard.CurrentUser(this);
            var dt = DbHelper.ExecuteDataTable("sp_PerfilEmpleado_Obtener", new[]
            {
                new SqlParameter("@UsuarioId", user.UsuarioId)
            });

            var model = new PerfilEmpleadoVM();

            if (dt.Rows.Count > 0)
            {
                var r = dt.Rows[0];
                model.NombreCompleto = r["NombreCompleto"].ToString();
                model.Telefono = r["Telefono"] == DBNull.Value ? "" : r["Telefono"].ToString();
                model.Ubicacion = r["Ubicacion"] == DBNull.Value ? "" : r["Ubicacion"].ToString();
                model.Resumen = r["Resumen"] == DBNull.Value ? "" : r["Resumen"].ToString();
                model.CvUrl = r["CvUrl"] == DBNull.Value ? "" : r["CvUrl"].ToString();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Empleado(PerfilEmpleadoVM model, HttpPostedFileBase cvFile)
        {
            if (!AuthGuard.IsRole(this, "Empleado")) return AuthGuard.Deny();
            if (!ModelState.IsValid) return View(model);
            // Subida simple de CV (en la carpeta de Uploads)
            if (cvFile != null && cvFile.ContentLength > 0)
            {
                var fileName = System.IO.Path.GetFileName(cvFile.FileName);
                System.IO.Directory.CreateDirectory(Server.MapPath("~/Uploads/"));
                var path = Server.MapPath("~/Uploads/" + fileName);
                cvFile.SaveAs(path);
                model.CvUrl = "/Uploads/" + fileName;
            }

            var user = AuthGuard.CurrentUser(this);

            DbHelper.ExecuteNonQuery("sp_PerfilEmpleado_Guardar", new[]
            {
                new SqlParameter("@UsuarioId", user.UsuarioId),
                new SqlParameter("@NombreCompleto", model.NombreCompleto),
                new SqlParameter("@Telefono", (object)model.Telefono ?? DBNull.Value),
                new SqlParameter("@Ubicacion", (object)model.Ubicacion ?? DBNull.Value),
                new SqlParameter("@Resumen", (object)model.Resumen ?? DBNull.Value),
                new SqlParameter("@CvUrl", (object)model.CvUrl ?? DBNull.Value),
            });
            ViewBag.Ok = "Perfil guardado / actualizado.";
            return View(model);
        }

        [HttpGet]
        public ActionResult Empleador()
        {
            if (!AuthGuard.IsRole(this, "Empleador")) return AuthGuard.Deny();

            var user = AuthGuard.CurrentUser(this);
            var dt = DbHelper.ExecuteDataTable("sp_PerfilEmpleador_Obtener", new[]
            {
                new SqlParameter("@UsuarioId", user.UsuarioId)
            });
            var model = new PerfilEmpleadorVM();

            if (dt.Rows.Count > 0)
            {
                var r = dt.Rows[0];
                model.Empresa = r["Empresa"].ToString();
                model.SitioWeb = r["SitioWeb"] == DBNull.Value ? "" : r["SitioWeb"].ToString();
                model.Descripcion = r["Descripcion"] == DBNull.Value ? "" : r["Descripcion"].ToString();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Empleador(PerfilEmpleadorVM model)
        {
            if (!AuthGuard.IsRole(this, "Empleador")) return AuthGuard.Deny();
            if (!ModelState.IsValid) return View(model);

            var user = AuthGuard.CurrentUser(this);

            DbHelper.ExecuteNonQuery("sp_PerfilEmpleador_Guardar", new[]
            {
                new SqlParameter("@UsuarioId", user.UsuarioId),
                new SqlParameter("@Empresa", model.Empresa),
                new SqlParameter("@SitioWeb", (object)model.SitioWeb ?? DBNull.Value),
                new SqlParameter("@Descripcion", (object)model.Descripcion ?? DBNull.Value),
            });
            ViewBag.Ok = "Perfil guardado / actualizado.";
            return View(model);
        }
    }
}
