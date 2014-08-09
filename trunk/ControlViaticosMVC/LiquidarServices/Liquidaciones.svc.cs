using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LiquidarServices.Persistencia;
using LiquidarServices.Dominio;
using System.Messaging;

namespace LiquidarServices
{

    public class Liquidaciones : ILiquidaciones
    {
        private SolicitudDAO solicitudDAO = new SolicitudDAO();
        private TipoViaticoDAO tipoViaticoDAO = new TipoViaticoDAO();
        private LiquidarDAO liquidarDAO = new LiquidarDAO();
        private LiquidarDetalleDAO liquidarDetalleDAO = new LiquidarDetalleDAO();
        /*
        private LiquidarDAO liquidarDAO = null;
        private LiquidarDAO LiquidarDAO
        {
            get
            {
                if (liquidarDAO == null)
                    liquidarDAO = new LiquidarDAO();
                return liquidarDAO;
            }
        }
        private SolicitudDAO solicitudDAO = null;
        private SolicitudDAO SolicitudDAO
        {
            get
            {
                if (solicitudDAO == null)
                    solicitudDAO = new SolicitudDAO();
                return solicitudDAO;
            }
        }
        */
        //public Liquidar CrearLiquidacion(DateTime FeLiquidacion, int CoSolicitud, double SsTotalAsignado, double SsTotalUtilizado, double SsOtrosGastos)
        //{
        //    if (SsOtrosGastos > 0.2 * (SsTotalUtilizado))
        //    {
        //        ValidationException validationException = new ValidationException { ValidationError = "Otros Gastos no puede ser mayor al 20% del monto utilizado." };
        //        throw new FaultException<ValidationException>(validationException);
        //    }
        //        Solicitud solicitudExistente = SolicitudDAO.Obtener(CoSolicitud);
        //        Liquidar liquidarCrear = new Liquidar()
        //        {
        //            Fe_Liquidacion = FeLiquidacion,
        //            Ss_TotalAsignado = SsTotalAsignado,
        //            Ss_TotalUtilizado = SsTotalUtilizado,
        //            Ss_OtrosGastos = SsOtrosGastos,
        //            solicitud = solicitudExistente
        //        };

        //        return LiquidarDAO.Crear(liquidarCrear);

        //}



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
            //1. Obtener las Solicitudes de Viaticos Aprobadas
            string rutaColaIn = @".\private$\indestructiblesOut";
            if (!MessageQueue.Exists(rutaColaIn))
                MessageQueue.Create(rutaColaIn);
            MessageQueue colaIn = new MessageQueue(rutaColaIn);
            colaIn.Formatter = new XmlMessageFormatter(new Type[] { typeof(ViaticoMsg) });
            Message mensajeIn = colaIn.Receive();
            ViaticoMsg viaticoMsg = (ViaticoMsg)mensajeIn.Body;
            Console.WriteLine("Asunto Recibido: " + mensajeIn.Label);
            Console.WriteLine("Viatico Recibido: " + viaticoMsg.CodigoSolicitud + ", Total Solicitado: " + viaticoMsg.TotalSolicitado);
            Console.ReadLine();

            //


            return liquidarDAO.ListarTodos().ToList();
        }


        public Liquidar CrearLiquidacion(DateTime FeLiquidacion, int CoSolicitud, double SsTotalAsignado, double SsTotalUtilizado, double SsOtrosGastos, List<Item> items)
        {
            Solicitud solicitudAux = solicitudDAO.Obtener(CoSolicitud);
            if (solicitudAux == null) //solicitud inexistente
                throw new FaultException<ValidationException>(
                    new ValidationException()
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
            TipoViatico tipoViaticoAux = null;
            LiquidarDetalle liquidarDetalleAux = null;
            foreach (Item item in items)
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


        //public ICollection<Liquidar> ListarLiquidaciones()
        //{
        //    return liquidarDAO.ListarTodos();
        //}

        public class ViaticoMsg
        {
            public int CodigoSolicitud { get; set; }
            public DateTime FechaSolicitud { get; set; }
            public int CodigoEmpleadoSolicitante { get; set; }
            public Ubigeo ubigeoOrigen { get; set; }
            public Ubigeo ubigeoDestino { get; set; }
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
