using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Web2.Models;
using Sistema_MVC_Web2.Filters;

namespace Sistema_MVC_Web2.Controllers
{
    public class LoginController : Controller
    {
        private Usuario usuario = new Usuario();

        // GET: Login
        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Validar(string Usuario, string Password,Usuario user)
        {
            var rm = usuario.ValidarLogin(Usuario, Password);
            if (rm.response)
            {
                rm.href = Url.Content("/Home");
            }

            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Login");
        }
    }
}