using BolsaTrabajoWeb.Data;
using BolsaTrabajoWeb.Helpers;
using BolsaTrabajoWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace BolsaTrabajoWeb.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Login() => View(new LoginVM());

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var dt = DbHelper.ExecuteDataTable("sp_Usuario_Login", new[]
            {
                new SqlParameter("@Email", model.Email)
            });

            if (dt.Rows.Count == 0)
            {
                ViewBag.Error = "Usuario no encontrado.";
                return View(model);
            }

            var row = dt.Rows[0];
            bool activo = Convert.ToBoolean(row["Activo"]);
            if (!activo)
            {
                ViewBag.Error = "Usuario inactivo.";
                return View(model);
            }

            string storedHash = row["PasswordHash"].ToString();
            string inputHash = PasswordHasher.Sha256(model.Password);

            if (!string.Equals(storedHash, inputHash, StringComparison.OrdinalIgnoreCase))
            {
                ViewBag.Error = "Contraseña incorrecta.";
                return View(model);
            }

            var user = new SessionUser
            {
                UsuarioId = Convert.ToInt32(row["UsuarioId"]),
                Email = row["Email"].ToString(),
                Rol = row["Rol"].ToString()
            };

            Session["USER"] = user;

            // Redirección por rol
            if (user.Rol == "Empleador") return RedirectToAction("MisPublicaciones", "Ofertas");
            if (user.Rol == "Empleado") return RedirectToAction("Index", "Ofertas");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Roles = new[] { "Empleado", "Empleador" };
            return View(new RegisterVM());
        }

        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            ViewBag.Roles = new[] { "Empleado", "Empleador" };
            if (!ModelState.IsValid) return View(model);

            string hash = PasswordHasher.Sha256(model.Password);

            try
            {
                var idObj = DbHelper.ExecuteScalar("sp_Usuario_Registrar", new[]
                {
                    new SqlParameter("@Email", model.Email),
                    new SqlParameter("@PasswordHash", hash),
                    new SqlParameter("@RolNombre", model.Rol)
                });

                int newId = Convert.ToInt32(idObj);

                // Auto-login
                Session["USER"] = new SessionUser { UsuarioId = newId, Email = model.Email, Rol = model.Rol };

                // primer paso recomendado: completar perfil
                if (model.Rol == "Empleado") return RedirectToAction("Empleado", "Perfil");
                return RedirectToAction("Empleador", "Perfil");
            }
            catch (SqlException ex)
            {
                ViewBag.Error = ex.Message;
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}