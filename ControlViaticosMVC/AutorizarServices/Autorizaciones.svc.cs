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

        public Autorizar ObtenerSolicitud(int codigoSolicitud)
        {
            return AutorizarDAO.Obtener(codigoSolicitud);
        }

        public Autorizar ModificarSolicitud(int codigoSolicitud, string flagAutorizar, DateTime fechaAutorizar, int codigoEmpleadoAutorizar)
        {
            Autorizar autorizarAModificar = new Autorizar()
            {
                CodigoSolicitud = codigoSolicitud,
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
    }
}
