using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ControlViaticosServices.Dominio;
using ControlViaticosServices.Persistencia;

namespace ControlViaticosServices
{
    public class Viaticos : IViaticos
    {
        private ViaticoDAO viaticoDAO = new ViaticoDAO();
        private TarifarioDAO tarifarioDAO = new TarifarioDAO();
        private TipoViaticoDAO tipoViaticoDAO = new TipoViaticoDAO();
        private ViaticoDetalleDAO viaticoDetalleDAO = new ViaticoDetalleDAO();

        //private ViaticoDAO viaticoDAO = null;
        //private ViaticoDAO ViaticoDAO
        //{
        //    get
        //    {
        //        if (viaticoDAO == null)
        //            viaticoDAO = new ViaticoDAO();
        //        return viaticoDAO;
        //    }
        //}

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
            
                ////La fecha de salida debe ser mayor a 10 dias de la fecha de la solicitud
                //DateTime d1 = fechaSolicitud;
                //DateTime d2 = fechaSalida;
                //// Creamos una variable TimeSpan para almacenar el intervalo de tiempo
                //TimeSpan ts = d2 - d1;
                //// Diferencia en días.
                //int NumDias = ts.Days;


                //if (NumDias < 10)
                //{
                //    throw new FaultException<ValidationException>(
                //        new ValidationException()
                //        {
                //            CodigoError = 6510,
                //            MensajeError = "La Solicitud de viático debe ser mayor a 10 días de la fecha de salida."
                //        });
                //};

                //Ubigeo ubigeoO = UbigeoDAO.Obtener(codigoUbigeoOrigen);
                //Ubigeo ubigeoD = UbigeoDAO.Obtener(codigoUbigeoDestino);          

                //Viatico viaticoACRear = new Viatico()

                //{
                //    FechaSolicitud = fechaSolicitud,
                //    CodigoEmpleadoSolicitante = codigoEmpleadoSolicitante,
                //    ubigeoOrigen = ubigeoO,
                //    ubigeoDestino = ubigeoD,
                //    FechaSalida = fechaSalida,
                //    FechaRetorno = fechaRetorno,
                //    SustentoViaje = sustentoViaje,
                //    TotalSolicitado = totalSolicitado
                //};
                //return ViaticoDAO.Crear(viaticoACRear);
                /////////////////////////////
            

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
                TotalSolicitado = totalSolicitado
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

        public Viatico ModificarSolicitud(int codigoSolicitud, DateTime fechaSolicitud, int codigoEmpleadoSolicitante, int codigoUbigeoOrigen, int codigoUbigeoDestino, DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje, double totalSolicitado)
        {

            Ubigeo ubigeoOrigen = UbigeoDAO.Obtener(codigoUbigeoOrigen);
            Ubigeo ubigeoDestino = UbigeoDAO.Obtener(codigoUbigeoDestino);

            Viatico viaticoAModificar = new Viatico()
            {
                CodigoSolicitud = codigoSolicitud,
                FechaSolicitud = fechaSolicitud,
                CodigoEmpleadoSolicitante = codigoEmpleadoSolicitante,
                ubigeoOrigen = ubigeoOrigen,
                ubigeoDestino = ubigeoDestino,
                FechaSalida = fechaSalida,
                FechaRetorno = fechaRetorno,
                SustentoViaje = sustentoViaje,
                TotalSolicitado = totalSolicitado
            };
            return viaticoDAO.Modificar(viaticoAModificar);
        }

        public void EliminarSolicitud(int codigoSolicitud)
        {
            Viatico viaticoExistente = viaticoDAO.Obtener(codigoSolicitud);
            viaticoDAO.Eliminar(viaticoExistente);
        }

        public List<Viatico> ListarSolicitudes()
        {
            return viaticoDAO.ListarTodos().ToList();
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
