using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ControlViaticosServices.Dominio;

namespace ControlViaticosServices
{
    [ServiceContract]
    public interface IViaticos
    {
        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        Viatico CrearSolicitud(DateTime fechaSolicitud, int codigoEmpleadoSolicitante, int codigoUbigeoOrigen, int codigoUbigeoDestino, DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje, double totalSolicitado);

        [OperationContract]
        Viatico ObtenerSolicitud(int codigoSolicitud);

        [OperationContract]
        Viatico ModificarSolicitud(int codigoSolicitud, DateTime fechaSolicitud, int codigoEmpleadoSolicitante, int codigoUbigeoOrigen, int codigoUbigeoDestino, DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje, double totalSolicitado);
        
        [OperationContract]
        void EliminarSolicitud(int codigoSolicitud);

        [OperationContract]
        List<Viatico> ListarSolicitudes();

        [OperationContract]
        List<Ubigeo> ListarUbigeos();

    }

}
