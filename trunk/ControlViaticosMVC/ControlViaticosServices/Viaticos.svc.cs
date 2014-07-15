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

        public Viatico CrearSolicitud(int codigoEmpleadoSolicitante, int codigoUbigeoOrigen, int codigoUbigeoDestino, DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje, double totalSolicitado)
        {
            DateTime Hoy = DateTime.Today;
            string fechaSolicitud = Hoy.ToString("dd-MM-yyyy");

            Ubigeo ubigeoO = UbigeoDAO.Obtener(codigoUbigeoOrigen);
            Ubigeo ubigeoD = UbigeoDAO.Obtener(codigoUbigeoDestino);

            Viatico viaticoACRear = new Viatico()

            {
                FechaSolicitud = fechaSalida,
                CodigoEmpleadoSolicitante = codigoEmpleadoSolicitante,
                CodigoUbigeoOrigen = codigoUbigeoOrigen,
                CodigoUbigeoDestino = codigoUbigeoDestino,
                FechaSalida = fechaSalida,
                FechaRetorno = fechaRetorno,
                SustentoViaje = sustentoViaje,
                TotalSolicitado = totalSolicitado
            };

        }

        public Viatico ObtenerSolicitud(int codigoSolicitud)
        {
            return ViaticoDAO.Obtener(codigoSolicitud);
        }

        public Viatico ModificarSolicitud(int codigoSolicitud, int codigoEmpleadoSolicitante, int codigoUbigeoOrigen, int codigoUbigeoDestino, DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje, double totalSolicitado)
        {
            DateTime Hoy = DateTime.Today;
            string fechaSolicitud = Hoy.ToString("dd-MM-yyyy");

            Ubigeo ubigeoOrigen = UbigeoDAO.Obtener(codigoUbigeoOrigen);
            Ubigeo ubigeoDestino = UbigeoDAO.Obtener(codigoUbigeoDestino);

            Viatico viaticoAModificar = new Viatico()
            {
                CodigoSolicitud = codigoSolicitud,
                CodigoEmpleadoSolicitante = codigoEmpleadoSolicitante,
                CodigoUbigeoOrigen = codigoUbigeoOrigen,
                CodigoUbigeoDestino = codigoUbigeoDestino,
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
    }
}
