using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlViaticosApp.Controllers
{
    public class AprobarController : Controller
    {
        //Instanciar AutorizarService
        private AprobarWS.AprobacionesClient proxy = new AprobarWS.AprobacionesClient();

        public ActionResult Index()
        {
            List<AprobarWS.Aprobar> viaticos = proxy.ListarSolicitudes();

            return View(viaticos);
        }

        //
        // GET: /Aprobar/Details/5

        public ActionResult Details(int id)
        {
            AprobarWS.Aprobar viaticoObtenido = proxy.ObtenerSolicitud(id);

            return View(viaticoObtenido);
        }

        //
        // GET: /Aprobar/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Aprobar/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Aprobar/Edit/5
 
        public ActionResult Edit(int id)
        {
            AprobarWS.Aprobar viaticoEditar = proxy.ObtenerSolicitud(id);

            //Llenar los combobox de Ubigeos
            List<AprobarWS.Ubigeo> listaUbi = proxy.ListarUbigeos();
            var listUbigeos = new SelectList(listaUbi, "CodigoUbigeo", "NoDescripcion");
            ViewData["ubigeos"] = listUbigeos;

            //Llenar combobox de Estado
            var list = new[] {   
                new Estado { Id = "P", Name = "Pendiente" }, 
                new Estado { Id = "A", Name = "Aprobado" }
            };
            var listEstados = new SelectList(list, "Id", "Name");
            ViewData["estados"] = listEstados;

            return View(viaticoEditar);
        }

        //
        // POST: /Aprobar/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            int CodigoEmpleadoAprobar = 3;//obtener de la sesion de login;
            try
            {
                proxy.AprobarSolicitud(int.Parse(collection["CodigoSolicitud"]),
                                        int.Parse(collection["empleado.CoEmpleado"]),
                                        int.Parse(collection["ubigeoOrigen.CodigoUbigeo"]),
                                        int.Parse(collection["ubigeoDestino.CodigoUbigeo"]),
                                        DateTime.Parse(collection["FechaSolicitud"]),
                                        DateTime.Parse(collection["FechaSalida"]),
                                        DateTime.Parse(collection["FechaRetorno"]),
                                        collection["SustentoViaje"],
                                        Double.Parse(collection["TotalSolicitado"]),
                                        collection["FlagAprobado"],
                                        DateTime.Today,
                                        CodigoEmpleadoAprobar);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Aprobar/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Aprobar/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public class Estado
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}
