using BolsaTrabajoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BolsaTrabajoWeb.Helpers
{
    public class AuthGuard
    {
        public static SessionUser CurrentUser(Controller c)
            => c.Session["USER"] as SessionUser;

        public static bool IsLogged(Controller c)
            => CurrentUser(c) != null;

        public static bool IsRole(Controller c, string rol)
        {
            var u = CurrentUser(c);
            return u != null && u.Rol == rol;
        }

        public static ActionResult Deny()
        {
            return new RedirectToRouteResult(
                new RouteValueDictionary(new { controller = "Auth", action = "Login" })
            );
        }
    }
}