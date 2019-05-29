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
    public class ModeloController : Controller
    {
        // GET: Modelo
        private Modelo objModelo = new Modelo();

        public ActionResult Index()
        {
            return View(objModelo.Listar());
        }


        public ActionResult Visualizar(int id)
        {
            return View(objModelo.Obtener(id));
        }

        //Action Agregar Editar

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new Modelo() //agrega un nuevo objeto
                            : objModelo.Obtener(id)
                );
        }

        //Action Guardar
        public ActionResult Guardar(Modelo objModelo)
        {
            if (ModelState.IsValid)
            {
                objModelo.Guardar();
                return Redirect("~/Modelo");
            }
            else
            {
                return View("~/Views/Modelo/AgregarEditar");
            }
        }

        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
            objModelo.modelo_id = id;
            objModelo.Eliminar();
            return Redirect("~/Modelo");
        }

    }
}