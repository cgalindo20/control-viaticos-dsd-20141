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
        Viatico CrearSolicitud(DateTime fechaSolicitud, int codigoEmpleadoSolicitante, int codigoUbigeoOrigen, int codigoUbigeoDestino, DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje, double totalSolicitado, List<Item> items);

        [OperationContract]
        Viatico ObtenerSolicitud(int codigoSolicitud);

        [OperationContract]
        Viatico ModificarSolicitud(int codigoSolicitud, int codigoUbigeoOrigen, int codigoUbigeoDestino, DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje);

        [OperationContract]
        Viatico AutorizarSolicitud(int codigoSolicitud, string autorizar, int codigoEmpleadoAutoriza);
        
        [OperationContract]
        void EliminarSolicitud(int codigoSolicitud);

        [OperationContract]
        List<Viatico> ListarSolicitudes();

        [OperationContract]
        List<Ubigeo> ListarUbigeos();

        [OperationContract]
        List<Tarifario> ListarTarifarioContingencia();
    }

}
