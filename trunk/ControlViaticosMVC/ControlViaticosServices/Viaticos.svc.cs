using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ControlViaticosServices.Dominio;
using ControlViaticosServices.Persistencia;
using System.Messaging;

namespace ControlViaticosServices
{
    public class Viaticos : IViaticos
    {
        private ViaticoDAO viaticoDAO = new ViaticoDAO();
        private TarifarioDAO tarifarioDAO = new TarifarioDAO();
        private TipoViaticoDAO tipoViaticoDAO = new TipoViaticoDAO();
        private ViaticoDetalleDAO viaticoDetalleDAO = new ViaticoDetalleDAO();
        private UbigeoDAO ubigeoDAO = null;
        private UbigeoDAO UbigeoDAO
        {
            get
            {
                if (ubigeoDAO == null)
                    ubigeoDAO = new UbigeoDAO();
                return ubigeoDAO;
            }
        }

        public Viatico CrearSolicitud(  DateTime fechaSolicitud, int codigoEmpleadoSolicitante, int codigoUbigeoOrigen, int codigoUbigeoDestino,
                                        DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje, double totalSolicitado, List<Item> items)
        {
            Ubigeo ubigeoO = UbigeoDAO.Obtener(codigoUbigeoOrigen);
            Ubigeo ubigeoD = UbigeoDAO.Obtener(codigoUbigeoDestino);

            Viatico viatico = new Viatico()

            {
                FechaSolicitud = fechaSolicitud,
                CodigoEmpleadoSolicitante = codigoEmpleadoSolicitante,
                ubigeoOrigen = ubigeoO,
                ubigeoDestino = ubigeoD,
                FechaSalida = fechaSalida,
                FechaRetorno = fechaRetorno,
                SustentoViaje = sustentoViaje,
                TotalSolicitado = totalSolicitado,
                FlagAutorizar = "P",
                FechaAutorizar = fechaSolicitud,
                CodigoEmpleadoAutorizar = codigoEmpleadoSolicitante
   
            };

            viatico = viaticoDAO.Crear(viatico);
            TipoViatico tipoViaticoAux = null;
            ViaticoDetalle viaticoDetalleAux = null;
            foreach (Item item in items)
            {
                tipoViaticoAux = tipoViaticoDAO.Obtener(item.Co_TipoViatico);
                viaticoDetalleAux = new ViaticoDetalle()
                {
                    PK = new ViaticoDetallePK() 
                    {
                        Viatico = viatico.CodigoSolicitud,
                        TipoViatico = tipoViaticoAux
                    },
                    Ss_MontoSolicitado = item.Ss_MontoSolicitado

                };
                viaticoDetalleDAO.Crear(viaticoDetalleAux);
            }
            return viatico;

        }

        public Viatico ObtenerSolicitud(int codigoSolicitud)
        {
            return viaticoDAO.Obtener(codigoSolicitud);
        }

        public Viatico ModificarSolicitud(int codigoSolicitud, int codigoUbigeoOrigen, int codigoUbigeoDestino, DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje)
        {

            Ubigeo ubigeoOrigen = UbigeoDAO.Obtener(codigoUbigeoOrigen);
            Ubigeo ubigeoDestino = UbigeoDAO.Obtener(codigoUbigeoDestino);
            Viatico viaticoOriginal = viaticoDAO.Obtener(codigoSolicitud);

            Viatico viaticoAModificar = new Viatico()
            {
                CodigoSolicitud = codigoSolicitud,
                FechaSolicitud = viaticoOriginal.FechaSolicitud,
                CodigoEmpleadoSolicitante = viaticoOriginal.CodigoEmpleadoSolicitante,
                ubigeoOrigen = ubigeoOrigen,
                ubigeoDestino = ubigeoDestino,
                FechaSalida = fechaSalida,
                FechaRetorno = fechaRetorno,
                SustentoViaje = sustentoViaje,
                TotalSolicitado = viaticoOriginal.TotalSolicitado,
                FlagAutorizar = viaticoOriginal.FlagAutorizar,
            };
            return viaticoDAO.Modificar(viaticoAModificar);
        }

        public Viatico AutorizarSolicitud(int codigoSolicitud, string autorizar, int codigoEmpleadoAutoriza)
        {
            Viatico viaticoOriginal = viaticoDAO.Obtener(codigoSolicitud);

            Viatico viaticoAutorizar = new Viatico()
            {
                CodigoSolicitud = codigoSolicitud,
                FechaSolicitud = viaticoOriginal.FechaSolicitud,
                CodigoEmpleadoSolicitante = viaticoOriginal.CodigoEmpleadoSolicitante,
                ubigeoOrigen = viaticoOriginal.ubigeoOrigen,
                ubigeoDestino = viaticoOriginal.ubigeoDestino,
                FechaSalida = viaticoOriginal.FechaSalida,
                FechaRetorno = viaticoOriginal.FechaRetorno,
                SustentoViaje = viaticoOriginal.SustentoViaje,
                TotalSolicitado = viaticoOriginal.TotalSolicitado,
                //
                FlagAutorizar = autorizar,
                FechaAutorizar = DateTime.Today,
                CodigoEmpleadoAutorizar = codigoEmpleadoAutoriza
                //
            };
            
            //Enviar mensaje para que Finanzas reciba los datos de la Solicitud y lo apruebe o rechace
            string rutaColaIn = @".\private$\indestructiblesIn";
            if (!MessageQueue.Exists(rutaColaIn))
                MessageQueue.Create(rutaColaIn);
            MessageQueue colaIn = new MessageQueue(rutaColaIn);
            Message mensajeIn = new Message();
            mensajeIn.Label = "Solicitud de Viatico por Aprobar";
            mensajeIn.Body = new ViaticoMsg()
            {
                CodigoSolicitud = viaticoAutorizar.CodigoSolicitud,
                FechaSolicitud = viaticoAutorizar.FechaSolicitud,
                CodigoEmpleadoSolicitante = viaticoAutorizar.CodigoEmpleadoSolicitante,
                ubigeoOrigen = viaticoAutorizar.ubigeoOrigen,
                ubigeoDestino = viaticoAutorizar.ubigeoDestino,
                FechaSalida = viaticoAutorizar.FechaSalida,
                FechaRetorno = viaticoAutorizar.FechaRetorno,
                SustentoViaje = viaticoAutorizar.SustentoViaje,
                TotalSolicitado = viaticoAutorizar.TotalSolicitado,
                FlagAutorizar = viaticoAutorizar.FlagAutorizar,
                FechaAutorizar = viaticoAutorizar.FechaAutorizar,
                CodigoEmpleadoAutorizar = viaticoAutorizar.CodigoEmpleadoAutorizar
                
            };
            colaIn.Send(mensajeIn);
            //


            return viaticoDAO.Modificar(viaticoAutorizar);
        }

        public void EliminarSolicitud(int codigoSolicitud)
        {
            
            // Deberia eliminar primero su detalle

            Viatico viaticoExistente = viaticoDAO.Obtener(codigoSolicitud);
            viaticoDAO.Eliminar(viaticoExistente);

        }

        public List<Viatico> ListarSolicitudes()
        {
            //Se añade código para que liste solo los que están pendientes de Autorizar

            //
            List<Viatico> listSolicitudes = new List<Viatico>();
            listSolicitudes = viaticoDAO.ListarTodos().ToList();
            int j = 0;
            for (int i = 0; i < listSolicitudes.Count; i++)
            {
                if (listSolicitudes[i].FlagAutorizar == "P")
                {
                    j = j + 1;
                }
            }
            
            //
            Viatico[] viaticoArr = new Viatico[j];
            j = 0;
            for (int i = 0; i < listSolicitudes.Count; i++)
            {
                if (listSolicitudes[i].FlagAutorizar == "P")
                {
                    Viatico viaticoAdd = new Viatico();
                    viaticoArr[j] = listSolicitudes[i];
                    j = j + 1;
                }
            }

            return viaticoArr.ToList();
        }

        public List<Ubigeo> ListarUbigeos()
        {
            return UbigeoDAO.ListarTodos().ToList();
        }

        public List<Tarifario> ListarTarifarioContingencia()
        {
            return tarifarioDAO.ListarTodos().ToList();
        }
        
    }
}
