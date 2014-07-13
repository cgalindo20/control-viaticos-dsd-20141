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
                int codigoEmpleadoSolicitante = int.Parse(collection["CodigoEmpleadoSolicitante"]);
                int codigoUbigeoOrigen = int.Parse(collection["CodigoUbigeoOrigen"]);
                int codigoUbigeoDestino = int.Parse(collection["CodigoUbigeoDestino"]);
                DateTime fechaSalida = DateTime.Parse(collection["FechaSalida"]);
                DateTime fechaRetorno = DateTime.Parse(collection["FechaRetorno"]);
                string sustentoViaje = collection["SustentoViaje"];
                Double totalSolicitado = Double.Parse(collection["TotalSolicitado"]);

                proxy.CrearSolicitud(codigoEmpleadoSolicitante, codigoUbigeoOrigen, codigoUbigeoDestino, fechaSalida, fechaRetorno, sustentoViaje, totalSolicitado);                

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
                int codigoEmpleadoSolicitante = int.Parse(collection["CodigoEmpleadoSolicitante"]);
                int codigoUbigeoOrigen = int.Parse(collection["CodigoUbigeoOrigen"]);
                int codigoUbigeoDestino = int.Parse(collection["CodigoUbigeoDestino"]);
                DateTime fechaSalida = DateTime.Parse(collection["FechaSalida"]);
                DateTime fechaRetorno = DateTime.Parse(collection["FechaRetorno"]);
                string sustentoViaje = collection["SustentoViaje"];
                Double totalSolicitado = Double.Parse(collection["TotalSolicitado"]);

                proxy.ModificarSolicitud(id, codigoEmpleadoSolicitante, codigoUbigeoOrigen, codigoUbigeoDestino, fechaSalida, fechaRetorno, sustentoViaje, totalSolicitado);
 
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
