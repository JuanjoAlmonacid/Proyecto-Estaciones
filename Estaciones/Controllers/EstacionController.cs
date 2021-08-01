using Estaciones.Dato;
using Estaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estaciones.Controllers
{
    public class EstacionController : Controller
    {
        EstacionAdmin admin = new EstacionAdmin();
        // GET: Estacion
        public ActionResult Index()
        {
            IEnumerable<estacion> lista = admin.Consultar();
            ViewBag.mensaje = "";
            return View(lista);
        }
        public ActionResult Guardar() {
            ViewBag.mensaje = "";
            return View();
        }

        public ActionResult Nuevo(estacion modelo) {
            admin.Guardar(modelo);
            ViewBag.mensaje = "Estacion Guardada";
            return View("Guardar",modelo);
        }

        public ActionResult Detalle(int id) {
            estacion modelo = admin.Consultar(id);
            ViewBag.mensaje = "";
            return View(modelo);
        }
        public ActionResult Modificar(int id = 0) {
            estacion modelo = admin.Consultar(id);
            return View(modelo);
        }
        public ActionResult Actualizar(estacion modelo) {
            admin.Modificar(modelo);
            ViewBag.mensaje = "Estacion Modificado";
            return View("Modificar", modelo);
        }
        public ActionResult Eliminar(int id = 0) {
            estacion modelo = new estacion()
            {
                Id = id
            };
            admin.Eliminar(modelo);
            IEnumerable<estacion> lista = admin.Consultar();
            ViewBag.mensaje = "Estacion Eliminada";
            return View("Index", lista);
        }
    }
}