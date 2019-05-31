using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Web2.Models;
using Sistema_MVC_Web2.Filters;
using System.IO;


namespace Sistema_MVC_Web2.Controllers
{
    [Autenticado]
    public class EvidenciaCriterioController : Controller
    {
        // GET: EvidenciaCriterio
        //Instanciar la clase EvidenciaCriterio
        private EvidenciaCriterio objEvidenciaCriterio = new EvidenciaCriterio();
        private Criterio objCriterio = new Criterio();

        public ActionResult Index()
        {
            return View(objEvidenciaCriterio.Listar());
        }

        //Acction Visualizar

        public ActionResult Visualizar(int id)
        {
            return View(objEvidenciaCriterio.Obtener(id));
        }

        //Action Agregar Editar

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Criterio = objCriterio.Listar();
            return View(id == 0 ? new EvidenciaCriterio() //agrega un nuevo objeto
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

                    int size = 1024 * 1024 * 5;
                    var filtroextencion = new[] { ".jpg", ".jpge", ".png", ".gif" };
                    var extenciones = Path.GetExtension(file.FileName);
                    if (filtroextencion.Contains(extenciones) && (file.ContentLength <= size))
                    {

                        file.SaveAs(Server.MapPath("~/Imagenes/" + file.FileName));

                        objEvidenciaCriterio.archivo = file.FileName;
                    }
                }

               

                objEvidenciaCriterio.Guardar();

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
            return Redirect("~/EvidenciaCriterio");
        }

    }
}