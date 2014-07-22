using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LiquidarServices.Dominio;
using LiquidarServices.Persistencia;

namespace LiquidarServices
{
    [ServiceContract]
    public interface ILiquidaciones
    {

        //[FaultContract(typeof(ValidationException))]
        //[OperationContract]
        //Liquidar CrearLiquidacion(DateTime FeLiquidacion, int CoSolicitud, Double SsTotalAsignado, Double SsTotalUtilizado, Double SsOtrosGastos);

        [OperationContract]
        Liquidar ObtenerLiquidacion(int CoLiquidacion);

        [OperationContract]
        Liquidar ModificarLiquidacion(int CoLiquidacion, DateTime FeLiquidacion, int CoSolicitud, Double SsTotalAsignado, Double SsTotalUtilizado, Double SsOtrosGastos);

        [OperationContract]
        void EliminarLiquidacion(int CoLiquidacion);

        [OperationContract]
        [FaultContract(typeof(ValidationException))]
        Liquidar CrearLiquidacion(DateTime FeLiquidacion, int CoSolicitud, Double SsTotalAsignado, Double SsTotalUtilizado, Double SsOtrosGastos, List<Item> items);

        [OperationContract]
        List<Liquidar> ListarLiquidaciones();
    }
}
