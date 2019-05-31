using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Web2.Models;
using System.IO;

namespace Sistema_MVC_Web2.Controllers
{
    public class EvidenciaActividadController : Controller
    {
        private EvidenciaActividad objEvidenciaActividad = new EvidenciaActividad();
        private Actividad objActividad = new Actividad();

        public ActionResult Index()
        {
            return View(objEvidenciaActividad.Listar());
        }

        //Acction Visualizar

        public ActionResult Visualizar(int id)
        {
            return View(objEvidenciaActividad.Obtener(id));
        }

        //Action Agregar Editar

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Actividad = objActividad.Listar();
            return View(id == 0 ? new EvidenciaActividad() //agrega un nuevo objeto
                            : objEvidenciaActividad.Obtener(id)
                );
        }

        //Action Guardar
        public ActionResult Guardar(EvidenciaActividad objEvidenciaActividad, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string archivo = (file.FileName).ToLower();

                    file.SaveAs(Server.MapPath("~/Imagenes/" + file.FileName));

                    objEvidenciaActividad.archivo = file.FileName;
                    objEvidenciaActividad.tamanio = Convert.ToString(Math.Round((Convert.ToDecimal(file.ContentLength) / (1024 * 1024)), 2)) + " Mb";
                    objEvidenciaActividad.tipo = Path.GetExtension(file.FileName);
                }
                objEvidenciaActividad.Guardar();
                return Redirect("~/Actividad/");
            }
            else
            {
                return View("~/Views/EvidenciaActividad/AgregarEditar.cshtml");
            }
        }

        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
            objEvidenciaActividad.evidenciaactividad_id = id;
            objEvidenciaActividad.Eliminar();
            return Redirect("~/EvidenciaActividad");
        }
    }
}