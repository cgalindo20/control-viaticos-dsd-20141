using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LiquidarServices.Persistencia;
using LiquidarServices.Dominio;

namespace LiquidarServices
{
    
    public class Liquidaciones : ILiquidaciones
    {
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

        public Liquidar CrearLiquidacion(DateTime FeLiquidacion, int CoSolicitud, double SsTotalAsignado, double SsTotalUtilizado, double SsOtrosGastos)
        {
            Solicitud solicitudExistente = SolicitudDAO.Obtener(CoSolicitud);
            Liquidar liquidarCrear = new Liquidar()
            {
                Fe_Liquidacion = FeLiquidacion,
                Ss_TotalAsignado = SsTotalAsignado,
                Ss_TotalUtilizado = SsTotalUtilizado,
                Ss_OtrosGastos = SsOtrosGastos,
                solicitud = solicitudExistente
            };

            return LiquidarDAO.Crear(liquidarCrear);
        }

        public Liquidar ObtenerLiquidacion(int CoLiquidacion)
        {
            return LiquidarDAO.Obtener(CoLiquidacion);
        }

        public Liquidar ModificarLiquidacion(int CoLiquidacion, DateTime FeLiquidacion, int CoSolicitud, double SsTotalAsignado, double SsTotalUtilizado, double SsOtrosGastos)
        {
            Solicitud solicitudExistente = SolicitudDAO.Obtener(CoSolicitud);
            Liquidar liquidarModificar = new Liquidar()
            {
                Co_Liquidacion = CoLiquidacion,
                Fe_Liquidacion = FeLiquidacion,
                Ss_TotalAsignado = SsTotalAsignado,
                Ss_TotalUtilizado = SsTotalUtilizado,
                Ss_OtrosGastos = SsOtrosGastos,
                solicitud = solicitudExistente
            };

            return LiquidarDAO.Modificar(liquidarModificar);
        }

        public void EliminarLiquidacion(int CoLiquidacion)
        {
            Liquidar liquidarExistente = LiquidarDAO.Obtener(CoLiquidacion);
            LiquidarDAO.Eliminar(liquidarExistente);
        }

        public List<Liquidar> ListarLiquidaciones()
        {
            return LiquidarDAO.ListarTodos().ToList();
        }
    }
}
