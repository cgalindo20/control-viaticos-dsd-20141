using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LiquidarServices.Dominio;

namespace LiquidarServices
{
    [ServiceContract]
    public interface ILiquidaciones
    {
        [OperationContract]
        Liquidar CrearLiquidacion(DateTime FeLiquidacion, int CoSolicitud, Double SsTotalAsignado, Double SsTotalUtilizado, Double SsOtrosGastos);
        [OperationContract]
        Liquidar ObtenerLiquidacion(int CoLiquidacion);
        [OperationContract]
        Liquidar ModificarLiquidacion(int CoLiquidacion, DateTime FeLiquidacion, int CoSolicitud, Double SsTotalAsignado, Double SsTotalUtilizado, Double SsOtrosGastos);
        [OperationContract]
        void EliminarLiquidacion(int CoLiquidacion);
        [OperationContract]
        List<Liquidar> ListarLiquidaciones();
    }
}
