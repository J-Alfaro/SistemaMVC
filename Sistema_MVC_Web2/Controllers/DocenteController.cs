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
    public class DocenteController : Controller
    {
        // GET: Docente
        //Instanciar la clase Docente
        private Docente objDocente = new Docente();

        public ActionResult Index()
        {
            return View(objDocente.Listar());
        }

        //Acction Visualizar

        public ActionResult Visualizar(int id)
        {
            return View(objDocente.Obtener(id));
        }

        //Action Agregar Editar

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new Docente() //agrega un nuevo objeto
                            : objDocente.Obtener(id)
                );
        }

        //Action Guardar
        public ActionResult Guardar(Docente objDocente, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string archivo = (file.FileName).ToLower();

                    file.SaveAs(Server.MapPath("~/Imagenes/" + file.FileName));

                    objDocente.foto = file.FileName;
                }
                objDocente.Guardar();
                return Redirect("~/Docente");
            }
            else
            {
                return View("~/Views/Docente/AgregarEditar.cshtml");
            }
        }

        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
            objDocente.docente_id = id;
            objDocente.Eliminar();
            return Redirect("~/Docente");
        }
    }
}