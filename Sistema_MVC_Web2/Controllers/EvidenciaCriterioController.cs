using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Web2.Models;
using System.IO;
using Sistema_MVC_Web2.Filters;

namespace Sistema_MVC_Web2.Controllers
{
    [Autenticado]
    public class EvidenciaCriterioController : Controller
    {
        //Instanciar las clases
        private EvidenciaCriterio objEvidenciaCriterio = new EvidenciaCriterio();
        private Criterio objCriterio = new Criterio();

        //Action Listar
        public ActionResult Index()
        {
            return View(objEvidenciaCriterio.Listar());
        }

        //Action Visualizar

        public ActionResult Visualizar(int id)
        {
            return View(objEvidenciaCriterio.Obtener(id));
        }

        //Action Agregar Editar

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Criterio = objCriterio.Listar();
            return View(
                id == 0 ? new EvidenciaCriterio() // Agregar un nuevo objeto
                : objEvidenciaCriterio.Obtener(id)
                );
        }


        //Action Guardar
        public ActionResult Guardar(EvidenciaCriterio objEvidenciaCriterio, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string archivo = (file.FileName).ToLower();

                    file.SaveAs(Server.MapPath("~/Imagenes/" + file.FileName));

                    objEvidenciaCriterio.archivo= file.FileName;
                    objEvidenciaCriterio.tamanio = "12";
                    objEvidenciaCriterio.tipo = "aas";
                    objEvidenciaCriterio.descripcion = "asdas";
                }
                objCriterio.Guardar();
                return Redirect("~/EvidenciaCriterio");
            }
            else
            {
                return View("~/Views/EvidenciaCriterio/AgregarEditar.cshtml");
            }
        }

        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
            objEvidenciaCriterio.evidencia_id = id;
            objEvidenciaCriterio.Eliminar();
            return Redirect("~/Usuario");
        }
    }
}