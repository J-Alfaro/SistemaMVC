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
    public class AsignacionController : Controller
    {
        private Asignacion objAsignacion = new Asignacion();
        private Semestre objSemestre = new Semestre();
        //private DetalleAsignacion objDetalleAsignacion = new DetalleAsignacion();
        // GET: Asignacion
        public ActionResult Index()
        {
            return View(objAsignacion.Listar());
        }

        //Accion visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objAsignacion.Obtener(id));
        }

        //Acccion agregar editar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Semestre = objSemestre.Listar();
            return View(
                id == 0 ? new Asignacion() // Agregar un nuevo objeto
                : objAsignacion.Obtener(id)
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
            objAsignacion.asignacion_id = id;
            objAsignacion.Eliminar();
            return Redirect("~/Asignacion");
        }
    }
}