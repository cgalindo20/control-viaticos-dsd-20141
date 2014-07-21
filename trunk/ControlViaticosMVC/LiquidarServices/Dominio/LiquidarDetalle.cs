using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace LiquidarServices.Dominio
{
    [DataContract]
    public class LiquidarDetalle
    {
        [DataMember]
        public LiquidarDetallePK PK { get; set; }
        [DataMember]
        public Double Ss_MontoAsignado { get; set; }
        [DataMember]
        public Double Ss_MontoUtilizado { get; set; }
    }


    [DataContract]
    public class LiquidarDetallePK
    {
        [DataMember]
        public int Liquidar { get; set; }
        [DataMember]
        public TipoViatico TipoViatico { get; set; }

        public override bool Equals(object obj)
        {
            if (Liquidar == ((LiquidarDetallePK)obj).Liquidar ||
                TipoViatico == ((LiquidarDetallePK)obj).TipoViatico)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return Liquidar;
        }
    }

}