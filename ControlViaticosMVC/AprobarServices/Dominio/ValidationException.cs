using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace AprobarServices.Dominio
{
    public class ValidationException
    {
        public string CodigoError { get; set; }
        public string MensajeError { get; set; }
    }
}