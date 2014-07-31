using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace LiquidarServices.Dominio
{
    [DataContract]
    public class SolicitudDetalle
    {
        [DataMember]
        public SolicitudDetallePK PK { get; set; }
        [DataMember]
        public Double Ss_MontoSolicitado { get; set; }
        
    }
    

    [DataContract]
    public class SolicitudDetallePK
    {
        [DataMember]
        public int Solicitud { get; set; }
        [DataMember]
        public TipoViatico TipoViatico { get; set; }

        public override bool Equals(object obj)
        {
            if (Solicitud == ((SolicitudDetallePK)obj).Solicitud ||
                TipoViatico == ((SolicitudDetallePK)obj).TipoViatico)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return Solicitud;
        }
    }

}