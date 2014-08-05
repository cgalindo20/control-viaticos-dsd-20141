using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AprobarServices.Dominio;

namespace AprobarServices
{    
    [ServiceContract]
    public interface IAprobaciones
    {

        [OperationContract]
        Aprobar ObtenerSolicitud(int codigoSolicitud);

        [OperationContract]
        Aprobar ModificarSolicitud(int codigoSolicitud, int codigoEmpleadoSolicitante, int codigoUbigeoOrigen, int codigoUbigeoDestino, DateTime fechaSolicitud, DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje, Double totalSolicitado, string flagAprobado, DateTime feAprobado, int CodigoEmpleadoAprueba);

        [OperationContract]
        List<Aprobar> ListarSolicitudes();

        [OperationContract]
        List<Ubigeo> ListarUbigeos();
       
    }
    
}
