using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AutorizarServices.Dominio;
using AutorizarServices.Persistencia;

namespace AutorizarServices
{
    
    public class Autorizaciones : IAutorizaciones
    {
        private AutorizarDAO autorizarDAO = null;
        private AutorizarDAO AutorizarDAO
        {
            get
            {
                if (autorizarDAO == null)
                    autorizarDAO = new AutorizarDAO();
                return autorizarDAO;
            }
        }

        private EmpleadoDAO empleadoDAO = null;
        private EmpleadoDAO EmpleadoDAO
        {
            get
            {
                if (empleadoDAO == null)
                    empleadoDAO = new EmpleadoDAO();
                return empleadoDAO;
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

        public Autorizar ObtenerSolicitud(int codigoSolicitud)
        {
            return AutorizarDAO.Obtener(codigoSolicitud);
        }

        public Autorizar ModificarSolicitud(int codigoSolicitud, int codigoEmpleadoSolicitante, int codigoUbigeoOrigen, int codigoUbigeoDestino, DateTime fechaSolicitud, DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje, Double totalSolicitado, string flagAutorizar, DateTime fechaAutorizar, int codigoEmpleadoAutorizar)
           
        {

            Empleado empleadoObt = EmpleadoDAO.Obtener(codigoEmpleadoSolicitante);
            Ubigeo ubigeoO = UbigeoDAO.Obtener(codigoUbigeoOrigen);
            Ubigeo ubigeoD = UbigeoDAO.Obtener(codigoUbigeoDestino);         


            Autorizar autorizarAModificar = new Autorizar()
            {
               CodigoSolicitud = codigoSolicitud,               
               FechaSolicitud = fechaSolicitud,
               empleado = empleadoObt,
               ubigeoOrigen = ubigeoO,
               ubigeoDestino = ubigeoD,
               FechaSalida = fechaSalida,
               FechaRetorno = fechaRetorno,
               SustentoViaje = sustentoViaje,
               TotalSolicitado = totalSolicitado,
               FlagAutorizar = flagAutorizar,
               FechaAutorizar = fechaAutorizar,
               CodigoEmpleadoAutorizar = codigoEmpleadoAutorizar
            };
            return AutorizarDAO.Modificar(autorizarAModificar);
        }

        public List<Autorizar> ListarSolicitudes()
        {
            return AutorizarDAO.ListarTodos().ToList();
        }

        public List<Ubigeo> ListarUbigeos()
        {
            return UbigeoDAO.ListarTodos().ToList();
        }
    }
}
