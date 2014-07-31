using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlViaticosApp.Models;
using ControlViaticosApp.LiquidacionesWS;

namespace ControlViaticosApp.Controllers
{
    public class LiquidarController : Controller
    {

        //Instanciar LiquidarServices
        private LiquidacionesWS.LiquidacionesClient proxy = new LiquidacionesWS.LiquidacionesClient();
        private ViaticoWS.ViaticosClient proxy2 = new ViaticoWS.ViaticosClient();

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

        [HttpPost]
        public ActionResult ConsultarSolicitud(FormCollection form)
        {
            ViaticoWS.Viatico viaticoObtenido = new ViaticoWS.Viatico();            
            LiquidacionesWS.Liquidar liquidacionObtenida = new LiquidacionesWS.Liquidar();
            LiquidacionesWS.Solicitud solicitudObtenida = new LiquidacionesWS.Solicitud();
            LiquidacionesWS.Ubigeo ubigeoOri = new LiquidacionesWS.Ubigeo();
            LiquidacionesWS.Ubigeo ubigeoDest = new LiquidacionesWS.Ubigeo();

            viaticoObtenido = proxy2.ObtenerSolicitud(int.Parse(form["nuSolicitud"]));
            solicitudObtenida.Co_Solicitud = viaticoObtenido.CodigoSolicitud;
            solicitudObtenida.Fe_Solicitud = viaticoObtenido.FechaSolicitud;
            solicitudObtenida.Co_EmpSolicitante = viaticoObtenido.CodigoEmpleadoSolicitante;
            
            ubigeoOri.CodigoUbigeo = viaticoObtenido.ubigeoOrigen.CodigoUbigeo;
            ubigeoOri.NoDescripcion = viaticoObtenido.ubigeoOrigen.NoDescripcion;
            solicitudObtenida.ubigeoOrigen = ubigeoOri;

            ubigeoDest.CodigoUbigeo = viaticoObtenido.ubigeoDestino.CodigoUbigeo;
            ubigeoDest.NoDescripcion = viaticoObtenido.ubigeoDestino.NoDescripcion;
            solicitudObtenida.ubigeoDestino = ubigeoDest;

            solicitudObtenida.Fe_Salida = viaticoObtenido.FechaSalida;
            solicitudObtenida.Fe_Retorno = viaticoObtenido.FechaRetorno;
            solicitudObtenida.Tx_Sustento = viaticoObtenido.SustentoViaje;
                            
            liquidacionObtenida.solicitud = solicitudObtenida;
            return View("LiquidarCreate", liquidacionObtenida);
        }

        public ActionResult BuscaSolicitud()
        {
            return View();
        }

        public ActionResult LiquidarCreate(LiquidacionesWS.Liquidar liquidacionObtenida)
        {
            return View(liquidacionObtenida);
        } 

        [HttpPost]
        public ActionResult LiquidarCreate(FormCollection collection)
        {
            try
            {
                
                LiquidacionesWS.Item[] itemX = new LiquidacionesWS.Item[1];
                LiquidacionesWS.Item itemY = new LiquidacionesWS.Item();
                itemY.Co_TipoViatico = 1;
                itemY.Ss_MontoUtilizado = 550;

                itemX[0]=itemY;
                
                //List<Item>
                proxy.CrearLiquidacion( DateTime.Today,
                                        int.Parse(collection["solicitud.Co_Solicitud"]),                    
                                        Double.Parse(collection["Ss_TotalAsignado"]),
                                        Double.Parse(collection["Ss_TotalUtilizado"]),
                                        Double.Parse(collection["Ss_OtrosGastos"]),
                                        itemX
                                        );

                return RedirectToAction("Index");           
            }catch (Exception e){
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
