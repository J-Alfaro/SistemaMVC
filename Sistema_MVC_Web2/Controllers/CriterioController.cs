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
    public class CriterioController : Controller
    {
        private Criterio objCriterio = new Criterio();
        private Modelo objModelo = new Modelo();
        // GET: Criterio
        public ActionResult Index()
        {
            return View(objCriterio.Listar());
        }

        //Accion visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objCriterio.Obtener(id));
        }

        //Acccion agregar editar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.modelo = objModelo.Listar();
            return View(
                id == 0 ? new Criterio() // Agregar un nuevo objeto
                : objCriterio.Obtener(id)
                );
        }

        //Accion Guardar
        public ActionResult Guardar(Criterio objCriterio)
        {
            if (ModelState.IsValid)
            {

                objCriterio.Guardar();

                return Redirect("~/Criterio");
            }
            else
            {
                return View("~/Views/Criterio/AgregarEditar.cshtml");
            }
        }

        //Accion eleiminar
        public ActionResult Eliminar(int id)
        {
            objCriterio.criterio_id = id;
            objCriterio.Eliminar();
            return Redirect("~/Criterio");
        }
    }
}