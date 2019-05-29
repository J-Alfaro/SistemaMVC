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
    public class ControlAsignacionController : Controller
    {
        private ControlAsignacion objControlAsignacion = new ControlAsignacion();
        private Docente objDocente = new Docente();
        private DetalleAsignacion objDetalleAsignacion = new DetalleAsignacion();
        private Criterio objCriterio = new Criterio();

        // GET: ControlAsignacion
        public ActionResult Index()
        {
            return View(objControlAsignacion.Listar());
        }

        //Accion visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objControlAsignacion.Obtener(id));
        }

        //Acccion agregar editar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.docente = objDocente.Listar();
            ViewBag.criterio = objCriterio.Listar();
            ViewBag.detalleasignacion = objDetalleAsignacion.Listar();
            return View(
                id == 0 ? new ControlAsignacion() // Agregar un nuevo objeto
                : objControlAsignacion.Obtener(id)
                );
        }

        //Accion Guardar
        public ActionResult Guardar(ControlAsignacion objControlAsignacion)
        {
            if (ModelState.IsValid)
            {

                objControlAsignacion.Guardar();

                return Redirect("~/ControlAsignacion");
            }
            else
            {
                return View("~/Views/ControlAsignacion/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            objControlAsignacion.controlasignacion_id = id;
            objControlAsignacion.Eliminar();
            return Redirect("~/ControlAsignacion");
        }
    }
}