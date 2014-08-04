using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AutorizarServices.Dominio;

namespace AutorizarServices
{    
    [ServiceContract]
    public interface IAutorizaciones
    {

        [OperationContract]
        Autorizar ObtenerSolicitud(int codigoSolicitud);
        
        [OperationContract]
        Autorizar ModificarSolicitud(int codigoSolicitud, int codigoEmpleadoSolicitante, int codigoUbigeoOrigen, int codigoUbigeoDestino, DateTime fechaSolicitud, DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje, Double totalSolicitado, string flagAutorizar, DateTime fechaAutorizar, int codigoEmpleadoAutorizar);

        [OperationContract]
        List<Autorizar> ListarSolicitudes();

        [OperationContract]
        List<Ubigeo> ListarUbigeos();
    }
 
}
