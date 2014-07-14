using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlViaticosApp.Models;

namespace ControlViaticosApp.Controllers
{
    public class LiquidarController : Controller
    {

        //Instanciar LiquidarServices
        private  LiquidacionesWS.LiquidacionesClient proxy = new LiquidacionesWS.LiquidacionesClient();

        public ActionResult Index()
        {
            List<LiquidacionesWS.Liquidar> liquidaciones = proxy.ListarLiquidaciones();
            return View(liquidaciones);
        }

        public ActionResult LiquidarDetails(int id)
        {
            LiquidacionesWS.Liquidar liquidacionObtenida = proxy.ObtenerLiquidacion(id);
            return View(liquidacionObtenida);
        }

        public ActionResult LiquidarCreate()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult LiquidarCreate(FormCollection collection)
        {
            try
            {
                proxy.CrearLiquidacion( DateTime.Parse(collection["Fe_Liquidacion"]),
                                        int.Parse(collection["solicitud.Co_Solicitud"]),                    
                                        Double.Parse(collection["Ss_TotalAsignado"]),
                                        Double.Parse(collection["Ss_TotalUtilizado"]),
                                        Double.Parse(collection["Ss_OtrosGastos"])
                                        );

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult LiquidarEdit(int id)
        {
            LiquidacionesWS.Liquidar liquidacionEditar = proxy.ObtenerLiquidacion(id);
            return View(liquidacionEditar);
        }

        [HttpPost]
        public ActionResult LiquidarEdit(int id, FormCollection collection)
        {
            try
            {
                proxy.ModificarLiquidacion(  id,
                                             DateTime.Parse(collection["Fe_Liquidacion"]),
                                             int.Parse(collection["Viatico.CodigoSolicitud"]),
                                             Double.Parse(collection["Ss_TotalAsignado"]),
                                             Double.Parse(collection["Ss_TotalUtilizado"]),
                                             Double.Parse(collection["Ss_OtrosGastos"])
                                             );

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult LiquidarDelete(int id)
        {

            LiquidacionesWS.Liquidar liquidacionEliminar = proxy.ObtenerLiquidacion(id);
            return View(liquidacionEliminar);

        }

        [HttpPost]
        public ActionResult LiquidarDelete(int id, FormCollection collection)
        {
            try
            {
                proxy.EliminarLiquidacion(id);
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
