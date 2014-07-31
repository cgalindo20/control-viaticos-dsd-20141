using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ControlViaticosServices.Dominio
{
    [DataContract]
    public class ViaticoDetalle
    {
        [DataMember]
        public ViaticoDetallePK PK { get; set; }
        [DataMember]
        public Double Ss_MontoSolicitado { get; set; }
        
    }
    

    [DataContract]
    public class ViaticoDetallePK
    {
        [DataMember]
        public int Viatico { get; set; }
        [DataMember]
        public TipoViatico TipoViatico { get; set; }

        public override bool Equals(object obj)
        {
            if (Viatico == ((ViaticoDetallePK)obj).Viatico ||
                TipoViatico == ((ViaticoDetallePK)obj).TipoViatico)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return Viatico;
        }
    }

}