using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LiquidarServices.Persistencia;
using LiquidarServices.Dominio;
using System.Messaging;
using LiquidarServices.ViaticosWS;

namespace LiquidarServices
{

    public class Liquidaciones : ILiquidaciones
    {
        private SolicitudDAO solicitudDAO = new SolicitudDAO();
        private TipoViaticoDAO tipoViaticoDAO = new TipoViaticoDAO();
        private LiquidarDAO liquidarDAO = new LiquidarDAO();
        private LiquidarDetalleDAO liquidarDetalleDAO = new LiquidarDetalleDAO();
        

        public Liquidar ObtenerLiquidacion(int CoLiquidacion)
        {
            return liquidarDAO.Obtener(CoLiquidacion);
        }

        public Liquidar ModificarLiquidacion(int CoLiquidacion, DateTime FeLiquidacion, int CoSolicitud, double SsTotalAsignado, double SsTotalUtilizado, double SsOtrosGastos)
        {
            Solicitud solicitudExistente = solicitudDAO.Obtener(CoSolicitud);
            Liquidar liquidarModificar = new Liquidar()
            {
                Co_Liquidacion = CoLiquidacion,
                Fe_Liquidacion = FeLiquidacion,
                Ss_TotalAsignado = SsTotalAsignado,
                Ss_TotalUtilizado = SsTotalUtilizado,
                Ss_OtrosGastos = SsOtrosGastos,
                solicitud = solicitudExistente
            };

            return liquidarDAO.Modificar(liquidarModificar);
        }

        public void EliminarLiquidacion(int CoLiquidacion)
        {
            Liquidar liquidarExistente = liquidarDAO.Obtener(CoLiquidacion);
            liquidarDAO.Eliminar(liquidarExistente);
        }

        public List<Liquidar> ListarLiquidaciones()
        {
            ////1. Obtener las Solicitudes de Viaticos Aprobadas
            //string rutaColaIn = @".\private$\indestructiblesOut";
            //if (!MessageQueue.Exists(rutaColaIn))
            //    MessageQueue.Create(rutaColaIn);
            //MessageQueue colaIn = new MessageQueue(rutaColaIn);
            //colaIn.Formatter = new XmlMessageFormatter(new Type[] { typeof(ViaticoMsg) });
            //Message mensajeIn = colaIn.Receive();
            //ViaticoMsg viaticoMsg = (ViaticoMsg)mensajeIn.Body;
            

            ////2. Busca la Solicitud y la actualiza
            //ViaticosWS.ViaticosClient proxy = new ViaticosWS.ViaticosClient();
            //ViaticosWS.Viatico viatico = new ViaticosWS.Viatico();

            //viatico = proxy.ObtenerSolicitud(viaticoMsg.CodigoSolicitud);

            //viatico = proxy.ModificarSolicitud( viatico.CodigoSolicitud,
            //                                    viatico.ubigeoOrigen.CodigoUbigeo,
            //                                    viatico.ubigeoDestino.CodigoUbigeo,
            //                                    viatico.FechaSalida,
            //                                    viatico.FechaRetorno,
            //                                    viatico.SustentoViaje,
            //                                    viaticoMsg.FlagAprobar,
            //                                    viaticoMsg.FechaAprobar,
            //                                    viaticoMsg.CodigoEmpleadoAprobar
            //                                    );


            //3. Mostrar solo los que esten aprobados
            //List<Liquidar> listSolicitudes = new List<Liquidar>();
            //listSolicitudes = liquidarDAO.ListarTodos().ToList();
            //int j = 0;
            //for (int i = 0; i < listSolicitudes.Count; i++)
            //{
            //    if (listSolicitudes[i].FlagAprobar == "A")
            //    {
            //        j = j + 1;
            //    }
            //}

            
            //Liquidar[] liquidarArr = new Liquidar[j];
            //j = 0;
            //for (int i = 0; i < listSolicitudes.Count; i++)
            //{
            //    if (listSolicitudes[i].FlagAprobar == "P")
            //    {
            //        Viatico viaticoAdd = new Viatico();
            //        liquidarArr[j] = listSolicitudes[i];
            //        j = j + 1;
            //    }
            //}

            //return liquidarArr.ToList();
            return liquidarDAO.ListarTodos().ToList();
        }


        public Liquidar CrearLiquidacion(DateTime FeLiquidacion, int CoSolicitud, double SsTotalAsignado, double SsTotalUtilizado, double SsOtrosGastos, List<LiquidarServices.Dominio.Item> items)
        {
            Solicitud solicitudAux = solicitudDAO.Obtener(CoSolicitud);
            if (solicitudAux == null) //solicitud inexistente
                throw new FaultException<LiquidarServices.Persistencia.ValidationException>(
                    new LiquidarServices.Persistencia.ValidationException()
                    {
                        CodigoError = 1,
                        MensajeError = "La Solicitud No Existe."
                    });

            Liquidar liquidar = new Liquidar()
            {
                Fe_Liquidacion = FeLiquidacion,
                solicitud = solicitudAux,
                Ss_TotalAsignado = SsTotalAsignado,
                Ss_TotalUtilizado = SsTotalUtilizado,
                Ss_OtrosGastos = SsOtrosGastos

            };

            liquidar = liquidarDAO.Crear(liquidar);
            LiquidarServices.Dominio.TipoViatico tipoViaticoAux = null;
            LiquidarDetalle liquidarDetalleAux = null;
            foreach (LiquidarServices.Dominio.Item item in items)
            {
                tipoViaticoAux = tipoViaticoDAO.Obtener(item.Co_TipoViatico);
                liquidarDetalleAux = new LiquidarDetalle()
                {
                    PK = new LiquidarDetallePK()
                    {
                        Liquidar = liquidar.Co_Liquidacion,
                        TipoViatico = tipoViaticoAux
                    },
                    Ss_MontoAsignado = item.Ss_MontoUtilizado,
                    Ss_MontoUtilizado = item.Ss_MontoUtilizado

                };
                liquidarDetalleDAO.Crear(liquidarDetalleAux);
            }
            return liquidar;

        }
        
        public class ViaticoMsg
        {
            public int CodigoSolicitud { get; set; }
            public DateTime FechaSolicitud { get; set; }
            public int CodigoEmpleadoSolicitante { get; set; }
            public LiquidarServices.Dominio.Ubigeo ubigeoOrigen { get; set; }
            public LiquidarServices.Dominio.Ubigeo ubigeoDestino { get; set; }
            public DateTime FechaSalida { get; set; }
            public DateTime FechaRetorno { get; set; }
            public String SustentoViaje { get; set; }
            public Double TotalSolicitado { get; set; }
            public String FlagAutorizar { get; set; }
            public DateTime FechaAutorizar { get; set; }
            public int CodigoEmpleadoAutorizar { get; set; }
            public String FlagAprobar { get; set; }
            public DateTime FechaAprobar { get; set; }
            public int CodigoEmpleadoAprobar { get; set; }

        }
    }
}
