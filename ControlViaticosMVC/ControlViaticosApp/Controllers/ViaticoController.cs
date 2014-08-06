using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlViaticosApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel;

namespace ControlViaticosApp.Controllers
{
    public class ViaticoController : Controller
    {
        private ViaticoWS.ViaticosClient proxy = new ViaticoWS.ViaticosClient();

        public ActionResult Index()
        {            
            List<ViaticoWS.Viatico> viaticos = proxy.ListarSolicitudes();                      

            return View(viaticos);
        }


        public ActionResult Details(int id)
        {
            ViaticoWS.Viatico viaticoObtenido = proxy.ObtenerSolicitud(id);            

            return View(viaticoObtenido);
        }

        public ActionResult Create()
        {

            //Llenar los combobox de Ubigeos
            List<ViaticoWS.Ubigeo> listaUbi = proxy.ListarUbigeos();
            var listUbigeos = new SelectList(listaUbi, "CodigoUbigeo", "NoDescripcion");
            ViewData["ubigeos"] = listUbigeos;

            //Si está caido el Servico de Tarifario en la Nube, se levanta el de contingencia(Tarifas no necesarimente actualizadas).
            List<ViaticoWS.Tarifario> listTarifasContingencia = proxy.ListarTarifarioContingencia();
            ViewData["tarifas"] = listTarifasContingencia;

            return View();
        } 

      
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int v_CodigoEmpleadoSolicitante = 1;//obtener de la sesion de login;
                List<ViaticoWS.Tarifario> listTarifasContingencia = proxy.ListarTarifarioContingencia();

                ViaticoWS.Item[] item = new ViaticoWS.Item[listTarifasContingencia.Count];
                for (int i = 0; i < listTarifasContingencia.Count; i++) 
                {
                    ViaticoWS.Item itemY = new ViaticoWS.Item();
                    itemY.Co_TipoViatico = listTarifasContingencia[i].Co_TipoViatico.Co_TipoViatico;
                    itemY.Ss_MontoSolicitado = (Double)listTarifasContingencia[i].Ss_Costo;
                    if (listTarifasContingencia[i].Co_Ubigeo.CodigoUbigeo == int.Parse(collection["ubigeoDestino.CodigoUbigeo"]))
                    {
                        item[i] = itemY;
                    }
                    
                }

                proxy.CrearSolicitud(   DateTime.Today,
                                        v_CodigoEmpleadoSolicitante,
                                        int.Parse(collection["ubigeoOrigen.CodigoUbigeo"]),
                                        int.Parse(collection["ubigeoDestino.CodigoUbigeo"]),
                                        DateTime.Parse(collection["FechaSalida"]),
                                        DateTime.Parse(collection["FechaRetorno"]),
                                        collection["SustentoViaje"],
                                        Double.Parse(collection["TotalSolicitado"]),
                                        item.ToList()
                                     );                   

                return RedirectToAction("Index");
            }
            catch (FaultException<ValidationException> ex)
            {

                TempData["alertMessage"] = ex.Detail.ValidationResult;               
                return View();
            }


        }
        
 
        public ActionResult Edit(int id)
        {
            ViaticoWS.Viatico viaticoEditar = proxy.ObtenerSolicitud(id);

            //Llenar los combobox de Ubigeos
            List<ViaticoWS.Ubigeo> listaUbi = proxy.ListarUbigeos();
            var listUbigeos = new SelectList(listaUbi, "CodigoUbigeo", "NoDescripcion");
            ViewData["ubigeos"] = listUbigeos;

            return View(viaticoEditar);
        }


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

 
        public ActionResult Delete(int id)
        {
            ViaticoWS.Viatico viaticoEliminar = proxy.ObtenerSolicitud(id);
            return View(viaticoEliminar);
        }


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

        public List<SelectListItem> ViewBag { get; set; }
    }
}
