using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sistema_MVC_Web2.Models;

namespace Sistema_MVC_Web2.Controllers
{
    public class ControlController : Controller
    {
        private Semestre objSemestre = new Semestre();
        private Control objControl = new Control();
        private ControlAsignacion objDetalleControl = new ControlAsignacion();


        // GET: Control
        public ActionResult Index()
        {
            return View(objControl.Listar());
        }

        //Accion visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objControl.Obtener(id));
        }

        //Acccion agregar editar
        public ActionResult AgregarEditar(int id = 0)
        {

            ViewBag.Semestre = objSemestre.Listar();

            return View(
                id == 0 ? new Control() // Agregar un nuevo objeto
                : objControl.Obtener(id)
                );
        }

        //Accion Guardar
        public ActionResult Guardar(Control objControl)
        {
            if (ModelState.IsValid)
            {

                objControl.Guardar();

                return Redirect("~/Control");
            }
            else
            {
                return View("~/Views/Control/AgregarEditar.cshtml");
            }
        }

        //accion eleiminar
        public ActionResult Eliminar(int id)
        {
            objControl.control_id = id;
            objControl.Eliminar();
            return Redirect("~/Control");
        }

        public ActionResult DetalleControl(int id)
        {
            ViewBag.id = id;
            return View(objDetalleControl.Listar());
        }
    }
}