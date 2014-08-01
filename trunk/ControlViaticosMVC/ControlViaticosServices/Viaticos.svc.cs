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
        private ViaticoDAO viaticoDAO = null;
        private ViaticoDAO ViaticoDAO
        {
            get
            {
                if (viaticoDAO == null)
                    viaticoDAO = new ViaticoDAO();
                return viaticoDAO;
            }
        }

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
                                        DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje, double totalSolicitado)
        {
            //La fecha de salida debe ser mayor a 10 dias de la fecha de la solicitud
            DateTime d1 = fechaSolicitud;
            DateTime d2 = fechaSalida;
            // Creamos una variable TimeSpan para almacenar el intervalo de tiempo
            TimeSpan ts = d2 - d1;
            // Diferencia en días.
            int NumDias = ts.Days;


            if (NumDias < 10)
            {
                throw new FaultException<ValidationException>(
                    new ValidationException()
                    {
                        CodigoError = 6510,
                        MensajeError = "La Solicitud de viático debe ser mayor a 10 días de la fecha de salida."
                    });
            };

            Ubigeo ubigeoO = UbigeoDAO.Obtener(codigoUbigeoOrigen);
            Ubigeo ubigeoD = UbigeoDAO.Obtener(codigoUbigeoDestino);          

            Viatico viaticoACRear = new Viatico()

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
            return ViaticoDAO.Crear(viaticoACRear);
        }

        public Viatico ObtenerSolicitud(int codigoSolicitud)
        {
            return ViaticoDAO.Obtener(codigoSolicitud);
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
            return ViaticoDAO.Modificar(viaticoAModificar);
        }

        public void EliminarSolicitud(int codigoSolicitud)
        {
            Viatico viaticoExistente = ViaticoDAO.Obtener(codigoSolicitud);
            ViaticoDAO.Eliminar(viaticoExistente);
        }

        public List<Viatico> ListarSolicitudes()
        {
            return ViaticoDAO.ListarTodos().ToList();
        }

        public List<Ubigeo> ListarUbigeos()
        {
            return UbigeoDAO.ListarTodos().ToList();
        }
    }
}
