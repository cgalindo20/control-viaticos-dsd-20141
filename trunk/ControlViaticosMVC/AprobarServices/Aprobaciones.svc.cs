using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AprobarServices.Dominio;
using AprobarServices.Persistencia;

namespace AprobarServices
{    
    public class Aprobaciones : IAprobaciones
    {
        private AprobarDAO aprobarDAO = null;
        private AprobarDAO AprobarDAO
        {
            get
            {
                if (aprobarDAO == null)
                    aprobarDAO = new AprobarDAO();
                return aprobarDAO;
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

        public Aprobar ObtenerSolicitud(int codigoSolicitud)
        {
            return AprobarDAO.Obtener(codigoSolicitud);
        }

        public Aprobar ModificarSolicitud(int codigoSolicitud, int codigoEmpleadoSolicitante, int codigoUbigeoOrigen, int codigoUbigeoDestino, DateTime fechaSolicitud, DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje, double totalSolicitado, string flagAprobado, DateTime feAprobado, int CodigoEmpleadoAprueba)
        {
            Empleado empleadoObt = EmpleadoDAO.Obtener(codigoEmpleadoSolicitante);
            Ubigeo ubigeoO = UbigeoDAO.Obtener(codigoUbigeoOrigen);
            Ubigeo ubigeoD = UbigeoDAO.Obtener(codigoUbigeoDestino);


            Aprobar aprobarAModificar = new Aprobar()
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
                FlagAprobado = flagAprobado,
                FeAprobado = feAprobado,
                CodigoEmpleadoAprueba = CodigoEmpleadoAprueba
            };
            return AprobarDAO.Modificar(aprobarAModificar);
        }

        public List<Aprobar> ListarSolicitudes()
        {
            return AprobarDAO.ListarTodos().ToList();
        }

        public List<Ubigeo> ListarUbigeos()
        {
            return UbigeoDAO.ListarTodos().ToList();
        }
    }
}
