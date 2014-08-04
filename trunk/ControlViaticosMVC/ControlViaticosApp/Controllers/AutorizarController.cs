using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlViaticosApp.Controllers
{
    public class AutorizarController : Controller
    {
        //Instanciar AutorizarService
        private AutorizarWS.AutorizacionesClient proxy = new AutorizarWS.AutorizacionesClient();

        public ActionResult Index()
        {
            List<AutorizarWS.Autorizar> viaticos = proxy.ListarSolicitudes();

            return View(viaticos);
        }

        //
        // GET: /Aprobar/Details/5

        public ActionResult Details(int id)
        {
            AutorizarWS.Autorizar viaticoObtenido = proxy.ObtenerSolicitud(id);

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
            AutorizarWS.Autorizar viaticoEditar = proxy.ObtenerSolicitud(id);

            return View(viaticoEditar);
        }

        //
        // POST: /Aprobar/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                proxy.ModificarSolicitud(int.Parse(collection["CodigoSolicitud"]),
                                            collection["FlagAutorizar"],
                                            DateTime.Parse(collection["FechaAutorizar"]),
                                            1);

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
    }
}
