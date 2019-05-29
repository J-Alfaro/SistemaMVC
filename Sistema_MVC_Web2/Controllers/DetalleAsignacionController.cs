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
    public class DetalleAsignacionController : Controller
    {
        private DetalleAsignacion objDetalleAsignacion = new DetalleAsignacion();
        private Docente objDocente = new Docente();
        private Asignacion objAsignacion = new Asignacion();
        private Criterio objCriterio = new Criterio();

        // GET: DetalleAsignacion
        public ActionResult Index()
        {
            return View(objDetalleAsignacion.Listar());
        }

        //Accion visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objDetalleAsignacion.Obtener(id));
        }

        //Acccion agregar editar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.docente = objDocente.Listar();
            ViewBag.criterio = objCriterio.Listar();
            ViewBag.asignacion = objAsignacion.Listar();
            return View(
                id == 0 ? new DetalleAsignacion() // Agregar un nuevo objeto
                : objDetalleAsignacion.Obtener(id)
                );
        }

        //Accion Guardar
        public ActionResult Guardar(DetalleAsignacion objDetalleAsignacion)
        {
            if (ModelState.IsValid)
            {

                objDetalleAsignacion.Guardar();

                return Redirect("~/DetalleAsignacion");
            }
            else
            {
                return View("~/Views/DetalleAsignacion/AgregarEditar.cshtml");
            }
        }

        //Accion eleiminar
        public ActionResult Eliminar(int id)
        {
            objDetalleAsignacion.detalleasignacion_id = id;
            objDetalleAsignacion.Eliminar();
            return Redirect("~/DetalleAsignacion");
        }

    }
}