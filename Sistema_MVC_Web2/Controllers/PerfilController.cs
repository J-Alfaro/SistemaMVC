using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Web2.Models;
using Sistema_MVC_Web2.Filters;

namespace Sistema_MVC_Web2.Controllers
{
    [Autenticado]
    public class PerfilController : Controller
    {
        private Usuario usuario = new Usuario();
        // GET: Perfil
        public ActionResult Index()
        {
            return View(usuario.Obtener(SessionHelper.GetUser()));
        }

        public JsonResult Actualizar(Usuario model, HttpPostedFileBase Foto)
        {
            var rm = new ResponseModel();

            ModelState.Remove("usuario_id");
            ModelState.Remove("docente_id");
            ModelState.Remove("clave");
            ModelState.Remove("nivel");
            ModelState.Remove("estado");

            if (ModelState.IsValid)
            {
                rm = model.GuardarPerfil(Foto);
            }
            rm.href = Url.Content("/Home/Index");
            return Json(rm);

        }
    }
}