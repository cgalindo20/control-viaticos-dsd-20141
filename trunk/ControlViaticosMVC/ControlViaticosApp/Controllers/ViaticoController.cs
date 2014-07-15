using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlViaticosApp.Models;

namespace ControlViaticosApp.Controllers
{
    public class ViaticoController : Controller
    {

        //Instanciar ControlViaticosService
        private ViaticoWS.ViaticosClient proxy = new ViaticoWS.ViaticosClient();

        public ActionResult Index()
        {            
            List<ViaticoWS.Viatico> viaticos = proxy.ListarSolicitudes(); 
            return View(viaticos);
        }


        //
        // GET: /Viaticos/Details/5

        public ActionResult Details(int id)
        {
            ViaticoWS.Viatico viaticoObtenido = proxy.ObtenerSolicitud(id);            

            return View(viaticoObtenido);
        }

        //
        // GET: /Viaticos/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Viaticos/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int CodigoEmpleadoSolicitante = 1;//obtener de la sesion de login;

                proxy.CrearSolicitud(   DateTime.Parse(collection["FechaSolicitud"]),   
                                        CodigoEmpleadoSolicitante,
                                        int.Parse(collection["ubigeoOrigen.CodigoUbigeo"]),
                                        int.Parse(collection["ubigeoDestino.CodigoUbigeo"]),
                                        DateTime.Parse(collection["FechaSalida"]),
                                        DateTime.Parse(collection["FechaRetorno"]),
                                        collection["SustentoViaje"],
                                        Double.Parse(collection["TotalSolicitado"])
                                     );                   

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Viaticos/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViaticoWS.Viatico viaticoEditar = proxy.ObtenerSolicitud(id);
            return View(viaticoEditar);
        }

        //
        // POST: /Viaticos/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                proxy.ModificarSolicitud(   int.Parse(collection["CodigoSolicitud"]),
                                            DateTime.Parse(collection["FechaSalida"]),
                                            1,
                                            int.Parse(collection["ubigeoOrigen.CodigoUbigeo"]),
                                            int.Parse(collection["ubigeoDestino.CodigoUbigeo"]),
                                            DateTime.Parse(collection["FechaSalida"]),
                                            DateTime.Parse(collection["FechaRetorno"]),
                                            collection["SustentoViaje"],
                                            Double.Parse(collection["TotalSolicitado"])
                                         );                
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Viaticos/Delete/5
 
        public ActionResult Delete(int id)
        {
            ViaticoWS.Viatico viaticoEliminar = proxy.ObtenerSolicitud(id);
            return View(viaticoEliminar);
        }

        //
        // POST: /Viaticos/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                proxy.EliminarSolicitud(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, "Error: " + e.Message);
                return View();
            }
        }
    }
}
