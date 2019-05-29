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
    public class UsuarioController : Controller
    {
        //Instanciar las clases
        private Usuario objUsuario = new Usuario();
        private Docente objDocente = new Docente();

        //Action Listar
        public ActionResult Index()
        {
            return View(objUsuario.Listar());
        }

        //Action Visualizar

        public ActionResult Visualizar(int id)
        {
            return View(objUsuario.Obtener(id));
        }

        //Action Agregar Editar

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.docente = objDocente.Listar();
            return View(
                id == 0 ? new Usuario() // Agregar un nuevo objeto
                : objUsuario.Obtener(id)
                );
        }


        //Action Guardar
        public ActionResult Guardar(Usuario objUsuario, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string archivo = (file.FileName).ToLower();

                    file.SaveAs(Server.MapPath("~/Imagenes/" + file.FileName));

                    objUsuario.avatar = file.FileName;
                }
                objDocente.Guardar();
                return Redirect("~/Usuario");
            }
            else
            {
                return View("~/Views/Usuario/AgregarEditar.cshtml");
            }
        }

        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
            objUsuario.usuario_id = id;
            objUsuario.Eliminar();
            return Redirect("~/Usuario");
        }
    }
}