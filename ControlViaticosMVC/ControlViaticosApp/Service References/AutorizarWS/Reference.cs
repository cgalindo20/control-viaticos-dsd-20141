﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.1008
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlViaticosApp.AutorizarWS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Autorizar", Namespace="http://schemas.datacontract.org/2004/07/AutorizarServices.Dominio")]
    [System.SerializableAttribute()]
    public partial class Autorizar : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CodigoEmpleadoAutorizarField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CodigoSolicitudField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaAutorizarField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaRetornoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaSalidaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaSolicitudField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FlagAutorizarField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SustentoViajeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double TotalSolicitadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ControlViaticosApp.AutorizarWS.Empleado empleadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ControlViaticosApp.AutorizarWS.Ubigeo ubigeoDestinoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ControlViaticosApp.AutorizarWS.Ubigeo ubigeoOrigenField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CodigoEmpleadoAutorizar {
            get {
                return this.CodigoEmpleadoAutorizarField;
            }
            set {
                if ((this.CodigoEmpleadoAutorizarField.Equals(value) != true)) {
                    this.CodigoEmpleadoAutorizarField = value;
                    this.RaisePropertyChanged("CodigoEmpleadoAutorizar");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CodigoSolicitud {
            get {
                return this.CodigoSolicitudField;
            }
            set {
                if ((this.CodigoSolicitudField.Equals(value) != true)) {
                    this.CodigoSolicitudField = value;
                    this.RaisePropertyChanged("CodigoSolicitud");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaAutorizar {
            get {
                return this.FechaAutorizarField;
            }
            set {
                if ((this.FechaAutorizarField.Equals(value) != true)) {
                    this.FechaAutorizarField = value;
                    this.RaisePropertyChanged("FechaAutorizar");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaRetorno {
            get {
                return this.FechaRetornoField;
            }
            set {
                if ((this.FechaRetornoField.Equals(value) != true)) {
                    this.FechaRetornoField = value;
                    this.RaisePropertyChanged("FechaRetorno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaSalida {
            get {
                return this.FechaSalidaField;
            }
            set {
                if ((this.FechaSalidaField.Equals(value) != true)) {
                    this.FechaSalidaField = value;
                    this.RaisePropertyChanged("FechaSalida");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaSolicitud {
            get {
                return this.FechaSolicitudField;
            }
            set {
                if ((this.FechaSolicitudField.Equals(value) != true)) {
                    this.FechaSolicitudField = value;
                    this.RaisePropertyChanged("FechaSolicitud");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FlagAutorizar {
            get {
                return this.FlagAutorizarField;
            }
            set {
                if ((object.ReferenceEquals(this.FlagAutorizarField, value) != true)) {
                    this.FlagAutorizarField = value;
                    this.RaisePropertyChanged("FlagAutorizar");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SustentoViaje {
            get {
                return this.SustentoViajeField;
            }
            set {
                if ((object.ReferenceEquals(this.SustentoViajeField, value) != true)) {
                    this.SustentoViajeField = value;
                    this.RaisePropertyChanged("SustentoViaje");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double TotalSolicitado {
            get {
                return this.TotalSolicitadoField;
            }
            set {
                if ((this.TotalSolicitadoField.Equals(value) != true)) {
                    this.TotalSolicitadoField = value;
                    this.RaisePropertyChanged("TotalSolicitado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ControlViaticosApp.AutorizarWS.Empleado empleado {
            get {
                return this.empleadoField;
            }
            set {
                if ((object.ReferenceEquals(this.empleadoField, value) != true)) {
                    this.empleadoField = value;
                    this.RaisePropertyChanged("empleado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ControlViaticosApp.AutorizarWS.Ubigeo ubigeoDestino {
            get {
                return this.ubigeoDestinoField;
            }
            set {
                if ((object.ReferenceEquals(this.ubigeoDestinoField, value) != true)) {
                    this.ubigeoDestinoField = value;
                    this.RaisePropertyChanged("ubigeoDestino");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ControlViaticosApp.AutorizarWS.Ubigeo ubigeoOrigen {
            get {
                return this.ubigeoOrigenField;
            }
            set {
                if ((object.ReferenceEquals(this.ubigeoOrigenField, value) != true)) {
                    this.ubigeoOrigenField = value;
                    this.RaisePropertyChanged("ubigeoOrigen");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Empleado", Namespace="http://schemas.datacontract.org/2004/07/AutorizarServices.Dominio")]
    [System.SerializableAttribute()]
    public partial class Empleado : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CoEmpleadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TxAp_MaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TxAp_PaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TxPreNombreField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CoEmpleado {
            get {
                return this.CoEmpleadoField;
            }
            set {
                if ((this.CoEmpleadoField.Equals(value) != true)) {
                    this.CoEmpleadoField = value;
                    this.RaisePropertyChanged("CoEmpleado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TxAp_Materno {
            get {
                return this.TxAp_MaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.TxAp_MaternoField, value) != true)) {
                    this.TxAp_MaternoField = value;
                    this.RaisePropertyChanged("TxAp_Materno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TxAp_Paterno {
            get {
                return this.TxAp_PaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.TxAp_PaternoField, value) != true)) {
                    this.TxAp_PaternoField = value;
                    this.RaisePropertyChanged("TxAp_Paterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TxPreNombre {
            get {
                return this.TxPreNombreField;
            }
            set {
                if ((object.ReferenceEquals(this.TxPreNombreField, value) != true)) {
                    this.TxPreNombreField = value;
                    this.RaisePropertyChanged("TxPreNombre");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Ubigeo", Namespace="http://schemas.datacontract.org/2004/07/AutorizarServices.Dominio")]
    [System.SerializableAttribute()]
    public partial class Ubigeo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CodigoUbigeoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NoDescripcionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CodigoUbigeo {
            get {
                return this.CodigoUbigeoField;
            }
            set {
                if ((this.CodigoUbigeoField.Equals(value) != true)) {
                    this.CodigoUbigeoField = value;
                    this.RaisePropertyChanged("CodigoUbigeo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NoDescripcion {
            get {
                return this.NoDescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.NoDescripcionField, value) != true)) {
                    this.NoDescripcionField = value;
                    this.RaisePropertyChanged("NoDescripcion");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AutorizarWS.IAutorizaciones")]
    public interface IAutorizaciones {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAutorizaciones/ObtenerSolicitud", ReplyAction="http://tempuri.org/IAutorizaciones/ObtenerSolicitudResponse")]
        ControlViaticosApp.AutorizarWS.Autorizar ObtenerSolicitud(int codigoSolicitud);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAutorizaciones/ModificarSolicitud", ReplyAction="http://tempuri.org/IAutorizaciones/ModificarSolicitudResponse")]
        ControlViaticosApp.AutorizarWS.Autorizar ModificarSolicitud(int codigoSolicitud, int codigoEmpleadoSolicitante, int codigoUbigeoOrigen, int codigoUbigeoDestino, System.DateTime fechaSolicitud, System.DateTime fechaSalida, System.DateTime fechaRetorno, string sustentoViaje, double totalSolicitado, string flagAutorizar, System.DateTime fechaAutorizar, int codigoEmpleadoAutorizar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAutorizaciones/ListarSolicitudes", ReplyAction="http://tempuri.org/IAutorizaciones/ListarSolicitudesResponse")]
        System.Collections.Generic.List<ControlViaticosApp.AutorizarWS.Autorizar> ListarSolicitudes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAutorizaciones/ListarUbigeos", ReplyAction="http://tempuri.org/IAutorizaciones/ListarUbigeosResponse")]
        System.Collections.Generic.List<ControlViaticosApp.AutorizarWS.Ubigeo> ListarUbigeos();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAutorizacionesChannel : ControlViaticosApp.AutorizarWS.IAutorizaciones, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AutorizacionesClient : System.ServiceModel.ClientBase<ControlViaticosApp.AutorizarWS.IAutorizaciones>, ControlViaticosApp.AutorizarWS.IAutorizaciones {
        
        public AutorizacionesClient() {
        }
        
        public AutorizacionesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AutorizacionesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AutorizacionesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AutorizacionesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ControlViaticosApp.AutorizarWS.Autorizar ObtenerSolicitud(int codigoSolicitud) {
            return base.Channel.ObtenerSolicitud(codigoSolicitud);
        }
        
        public ControlViaticosApp.AutorizarWS.Autorizar ModificarSolicitud(int codigoSolicitud, int codigoEmpleadoSolicitante, int codigoUbigeoOrigen, int codigoUbigeoDestino, System.DateTime fechaSolicitud, System.DateTime fechaSalida, System.DateTime fechaRetorno, string sustentoViaje, double totalSolicitado, string flagAutorizar, System.DateTime fechaAutorizar, int codigoEmpleadoAutorizar) {
            return base.Channel.ModificarSolicitud(codigoSolicitud, codigoEmpleadoSolicitante, codigoUbigeoOrigen, codigoUbigeoDestino, fechaSolicitud, fechaSalida, fechaRetorno, sustentoViaje, totalSolicitado, flagAutorizar, fechaAutorizar, codigoEmpleadoAutorizar);
        }
        
        public System.Collections.Generic.List<ControlViaticosApp.AutorizarWS.Autorizar> ListarSolicitudes() {
            return base.Channel.ListarSolicitudes();
        }
        
        public System.Collections.Generic.List<ControlViaticosApp.AutorizarWS.Ubigeo> ListarUbigeos() {
            return base.Channel.ListarUbigeos();
        }
    }
}
