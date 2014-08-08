using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlViaticosApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel;
using System.Net;

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

        public ActionResult IndexAutorizar()
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
                //La fecha de salida debe ser mayor a 10 dias de la fecha de la solicitud
                DateTime d1 =  DateTime.Today;
                DateTime d2 = DateTime.Parse(collection["FechaSalida"]);
                // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                TimeSpan ts = d2 - d1;
                // Diferencia en días.
                int NumDias = ts.Days;

                
                int j = 0;
                int v_CodigoEmpleadoSolicitante = 1;//obtener de la sesion de login;
                Double v_TotalSolicitado = 0;

                List<ViaticoWS.Tarifario> listTarifasContingencia = proxy.ListarTarifarioContingencia();
                for (int i = 0; i < listTarifasContingencia.Count; i++) {
                    if (listTarifasContingencia[i].Co_Ubigeo.CodigoUbigeo == int.Parse(collection["ubigeoDestino.CodigoUbigeo"]))
                    {
                        j = j + 1;
                    }
                }

                //Obteniendo el numero de días de viaje
                TimeSpan difFechas = DateTime.Parse(collection["FechaRetorno"]) - DateTime.Parse(collection["FechaSalida"]) ;
                int dias = difFechas.Days; 
                //

                ViaticoWS.Item[] item = new ViaticoWS.Item[j];
                
                j = 0;

                for (int i = 0; i < listTarifasContingencia.Count; i++) 
                {
                    if (listTarifasContingencia[i].Co_Ubigeo.CodigoUbigeo == int.Parse(collection["ubigeoDestino.CodigoUbigeo"]))
                    {
                        ViaticoWS.Item itemY = new ViaticoWS.Item();
                        itemY.Co_TipoViatico = listTarifasContingencia[i].Co_TipoViatico.Co_TipoViatico;
                        itemY.Ss_MontoSolicitado = (Double)listTarifasContingencia[i].Ss_Costo * dias;
                        item[j] = itemY;
                        v_TotalSolicitado = v_TotalSolicitado + (Double)listTarifasContingencia[i].Ss_Costo * dias;
                        j = j + 1;
                    }
                    
                }

                proxy.CrearSolicitud(   DateTime.Today,
                                        v_CodigoEmpleadoSolicitante,
                                        int.Parse(collection["ubigeoOrigen.CodigoUbigeo"]),
                                        int.Parse(collection["ubigeoDestino.CodigoUbigeo"]),
                                        DateTime.Parse(collection["FechaSalida"]),
                                        DateTime.Parse(collection["FechaRetorno"]),
                                        collection["SustentoViaje"],
                                        v_TotalSolicitado,
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
                //Falta codigo para Editar, NO es necesario
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult EditAutorizar(int id)
        {
            //Llenar combobox de Estado
            var list = new[] {   
                new Estado { Id = "P", Name = "Pendiente" }, 
                new Estado { Id = "A", Name = "Autorizado" }
            };
            var listEstados = new SelectList(list, "Id", "Name");
            ViewData["estados"] = listEstados;

            ViaticoWS.Viatico viaticoAutorizar = proxy.ObtenerSolicitud(id);
            return View(viaticoAutorizar);
        }   

        [HttpPost]
        public ActionResult EditAutorizar(int id, FormCollection collection)
        {
            try
            {
                int v_CodigoEmpleadoAutoriza = 2;//obtener de la sesion de login;

                proxy.AutorizarSolicitud(   int.Parse(collection["CodigoSolicitud"]),
                                            collection["FlagAutorizar"],
                                            v_CodigoEmpleadoAutoriza
                                         );

                return RedirectToAction("IndexAutorizar");
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

        public class Estado
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

    }
}
