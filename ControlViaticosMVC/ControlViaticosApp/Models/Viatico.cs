﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ControlViaticosApp.Models
{
    public class Viatico
    {
       
        public int CodigoSolicitud { get; set; }       
        public DateTime FechaSolicitud { get; set; }
        public int CodigoEmpleadoSolicitante { get; set; }        
        public Ubigeo ubigeoOrigen { get; set; }      
        public Ubigeo ubigeoDestino { get; set; }
        [Required(ErrorMessage = "La Fecha de Salida es requerido")]
        public DateTime FechaSalida { get; set; }
        [Required(ErrorMessage = "La Fecha de Retorno es requerido")]
        public DateTime FechaRetorno { get; set; }
        [Required(ErrorMessage = "El Sustento de Viaje es requerido")]
        public String SustentoViaje { get; set; }
        public Double TotalSolicitado { get; set; }

    }
}