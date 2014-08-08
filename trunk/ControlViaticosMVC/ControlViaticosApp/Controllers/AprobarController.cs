using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Messaging;

namespace ControlViaticosApp.Controllers
{
    public class AprobarController : Controller
    {
        //Instanciar AutorizarService
        private AprobarWS.AprobacionesClient proxy = new AprobarWS.AprobacionesClient();

        public ActionResult Edit()
        {
            //1. Pasamos valores al Modelo del servicio
            List<AprobarWS.Aprobar> viaticos = proxy.ListarSolicitudes();
            AprobarWS.Aprobar viaticoEditar = new AprobarWS.Aprobar();

            viaticoEditar.CodigoSolicitud = viaticos[0].CodigoSolicitud;
            viaticoEditar.FechaSolicitud = viaticos[0].FechaSolicitud;
            viaticoEditar.ubigeoOrigen = viaticos[0].ubigeoOrigen;
            viaticoEditar.ubigeoDestino = viaticos[0].ubigeoDestino;
            viaticoEditar.FechaSalida = viaticos[0].FechaSalida;
            viaticoEditar.FechaRetorno = viaticos[0].FechaRetorno;
            viaticoEditar.SustentoViaje = viaticos[0].SustentoViaje;
            viaticoEditar.TotalSolicitado = viaticos[0].TotalSolicitado;
            

            //3. Llenar combobox de Estado
            var list = new[] {   
                new Estado { Id = "P", Name = "Pendiente" }, 
                new Estado { Id = "A", Name = "Aprobado" }
            };
            var listEstados = new SelectList(list, "Id", "Name");
            ViewData["estados"] = listEstados;

            return View(viaticoEditar);
        }              

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            int CodigoEmpleadoAprobar = 3;//obtener de la sesion de login;
            try
            {

                proxy.AprobarSolicitud( int.Parse(collection["CodigoSolicitud"]),
                                        0,
                                        0,
                                        DateTime.Parse(collection["FechaSolicitud"]),
                                        DateTime.Parse(collection["FechaSalida"]),
                                        DateTime.Parse(collection["FechaRetorno"]),
                                        collection["SustentoViaje"],
                                        Double.Parse(collection["TotalSolicitado"]),
                                        collection["FlagAprobado"],
                                        DateTime.Today,
                                        CodigoEmpleadoAprobar);

                //return RedirectToAction("Edit");
                return RedirectToAction("MsgOK");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        public ActionResult MsgOk()
        {
            return View();
        }             

        public class Estado
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public class ViaticoMsg
        {
            public int CodigoSolicitud { get; set; }
            public DateTime FechaSolicitud { get; set; }
            public int CodigoEmpleadoSolicitante { get; set; }
            public DateTime FechaSalida { get; set; }
            public DateTime FechaRetorno { get; set; }
            public String SustentoViaje { get; set; }
            public Double TotalSolicitado { get; set; }
            public String FlagAutorizar { get; set; }
            public DateTime FechaAutorizar { get; set; }
            public int CodigoEmpleadoAutorizar { get; set; }

        }
    }
}
