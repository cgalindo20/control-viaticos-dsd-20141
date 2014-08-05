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
            //List<LiquidacionesWS.Liquidar> liquidaciones = proxy.ListarLiquidaciones();
            //return View(liquidaciones);

            List<ViaticoWS.Viatico> viaticos = proxy2.ListarSolicitudes();
            return View(viaticos);


        }

        public ActionResult LiquidarDetails(int id)
        {
            LiquidacionesWS.Liquidar liquidacionObtenida = proxy.ObtenerLiquidacion(id);
            return View(liquidacionObtenida);
        }

        public ActionResult LiquidarCreate(int ID)
        {
            ViaticoWS.Viatico viaticoObtenido = new ViaticoWS.Viatico();
            LiquidacionesWS.Liquidar liquidacionObtenida = new LiquidacionesWS.Liquidar();
            LiquidacionesWS.Solicitud solicitudObtenida = new LiquidacionesWS.Solicitud();
            LiquidacionesWS.SolicitudDetalle solicitudDetalleObtenida = new LiquidacionesWS.SolicitudDetalle();
            LiquidacionesWS.SolicitudDetallePK solicitudDetallePKObtenida = new LiquidacionesWS.SolicitudDetallePK();
            LiquidacionesWS.TipoViatico tipoViaticoObtenida = new LiquidacionesWS.TipoViatico();
            LiquidacionesWS.Ubigeo ubigeoOri = new LiquidacionesWS.Ubigeo();
            LiquidacionesWS.Ubigeo ubigeoDest = new LiquidacionesWS.Ubigeo();

            viaticoObtenido = proxy2.ObtenerSolicitud(ID);

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
            solicitudObtenida.Ss_TotalSolicitado = viaticoObtenido.TotalSolicitado;

            LiquidacionesWS.SolicitudDetalle[] item = new LiquidacionesWS.SolicitudDetalle[viaticoObtenido.Detalles.Count];
            //LiquidacionesWS.LiquidarDetalle[] item = new LiquidacionesWS.LiquidarDetalle[viaticoObtenido.Detalles.Count];

            for (int i = 0; i < viaticoObtenido.Detalles.Count; i++)
            {
                item[i] = new SolicitudDetalle();
                //item[i] = new LiquidarDetalle();
                item[i].PK = new SolicitudDetallePK();
                //item[i].PK = new LiquidarDetallePK();
                item[i].PK.TipoViatico = new TipoViatico();

                item[i].PK.TipoViatico.Co_TipoViatico = viaticoObtenido.Detalles[i].PK.TipoViatico.Co_TipoViatico;
                item[i].PK.TipoViatico.No_Descripcion = viaticoObtenido.Detalles[i].PK.TipoViatico.No_Descripcion;
                item[i].PK.Solicitud = viaticoObtenido.Detalles[i].PK.Viatico;
                item[i].Ss_MontoSolicitado = viaticoObtenido.Detalles[i].Ss_MontoSolicitado;
            }

            solicitudObtenida.Detalles = item;

            liquidacionObtenida.solicitud = solicitudObtenida;

            return View(liquidacionObtenida);
        } 

        [HttpPost]
        public ActionResult LiquidarCreate(FormCollection collection)
        {
            try
            {
                ViaticoWS.Viatico viaticoObtenido = new ViaticoWS.Viatico();
                LiquidacionesWS.Liquidar liquidacionObtenida = new LiquidacionesWS.Liquidar();
                LiquidacionesWS.Solicitud solicitudObtenida = new LiquidacionesWS.Solicitud();
                LiquidacionesWS.SolicitudDetalle solicitudDetalleObtenida = new LiquidacionesWS.SolicitudDetalle();
                LiquidacionesWS.SolicitudDetallePK solicitudDetallePKObtenida = new LiquidacionesWS.SolicitudDetallePK();
                LiquidacionesWS.TipoViatico tipoViaticoObtenida = new LiquidacionesWS.TipoViatico();
                LiquidacionesWS.Ubigeo ubigeoOri = new LiquidacionesWS.Ubigeo();
                LiquidacionesWS.Ubigeo ubigeoDest = new LiquidacionesWS.Ubigeo();
                
                viaticoObtenido = proxy2.ObtenerSolicitud(int.Parse(collection["solicitud.Co_Solicitud"]));

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
                solicitudObtenida.Ss_TotalSolicitado = viaticoObtenido.TotalSolicitado;

                LiquidacionesWS.Item[] item = new LiquidacionesWS.Item[viaticoObtenido.Detalles.Count];
                for (int i = 0; i < viaticoObtenido.Detalles.Count; i++)
                {
                    LiquidacionesWS.Item itemY = new LiquidacionesWS.Item();
                    itemY.Co_TipoViatico = viaticoObtenido.Detalles[i].PK.TipoViatico.Co_TipoViatico;
                    itemY.Ss_MontoUtilizado = viaticoObtenido.Detalles[i].Ss_MontoSolicitado;
                    item[i] = itemY;
                }

                proxy.CrearLiquidacion( DateTime.Today,
                                        solicitudObtenida.Co_Solicitud,
                                        solicitudObtenida.Ss_TotalSolicitado,
                                        solicitudObtenida.Ss_TotalSolicitado,
                                        Double.Parse(collection["Ss_OtrosGastos"]),
                                        item
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
