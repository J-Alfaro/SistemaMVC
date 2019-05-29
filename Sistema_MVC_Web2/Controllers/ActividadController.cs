using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Web2.Models;
using Sistema_MVC_Web2.Filters;

namespace Sistema_MVC_Web2.Controllers
{
    public class ActividadController : Controller
    {
        // GET: Actividad
        private Actividad objActividad = new Actividad();
        private Criterio objCriterio = new Criterio();
        private Semestre objSemestre = new Semestre();

        //private DetalleAsignacion objDetalleAsignacion = new DetalleAsignacion();
        // GET: Asignacion
        public ActionResult Index()
        {
            return View(objActividad.Listar());
        }

        //Accion visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objActividad.Obtener(id));
        }

        //Acccion agregar editar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Semestre = objCriterio.Listar();
            ViewBag.Semestre = objSemestre.Listar();
            return View(
                id == 0 ? new Actividad() // Agregar un nuevo objeto
                : objActividad.Obtener(id)
                );
        }

        //Accion Guardar
        public ActionResult Guardar(Asignacion objAsignacion)
        {
            if (ModelState.IsValid)
            {

                objAsignacion.Guardar();

                return Redirect("~/Asignacion");
            }
            else
            {
                return View("~/Views/Asignacion/AgregarEditar.cshtml");
            }
        }

        //accion eleiminar
        public ActionResult Eliminar(int id)
        {
            objActividad.actividad_id = id;
            objActividad.Eliminar();
            return Redirect("~/Asignacion");
        }
    }
}