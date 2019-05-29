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
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        private Estudiante objEstudiante = new Estudiante();

        //Action Listar

        public ActionResult Index()
        {
            return View(objEstudiante.Listar());
        }


        public ActionResult Visualizar(int id)
        {
            return View(objEstudiante.Obtener(id));
        }

        //Action Agregar Editar

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new Estudiante() //agrega un nuevo objeto
                            : objEstudiante.Obtener(id)
                );
        }

        //Action Guardar
        public ActionResult Guardar(Estudiante objEstudiante)
        {
            if (ModelState.IsValid)
            {
                objEstudiante.Guardar();
                return Redirect("~/Estudiante");
            }
            else
            {
                return View("~/Views/Estudiante/AgregarEditar");
            }
        }

        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
            objEstudiante.estudiante_id = id;
            objEstudiante.Eliminar();
            return Redirect("~/Estudiante");
        }
    }
}