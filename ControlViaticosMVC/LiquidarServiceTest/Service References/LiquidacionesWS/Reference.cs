﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.1008
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiquidarServiceTest.LiquidacionesWS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Liquidar", Namespace="http://schemas.datacontract.org/2004/07/LiquidarServices.Dominio")]
    [System.SerializableAttribute()]
    public partial class Liquidar : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Co_LiquidacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime Fe_LiquidacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double Ss_OtrosGastosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double Ss_TotalAsignadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double Ss_TotalUtilizadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LiquidarServiceTest.LiquidacionesWS.Solicitud solicitudField;
        
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
        public int Co_Liquidacion {
            get {
                return this.Co_LiquidacionField;
            }
            set {
                if ((this.Co_LiquidacionField.Equals(value) != true)) {
                    this.Co_LiquidacionField = value;
                    this.RaisePropertyChanged("Co_Liquidacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Fe_Liquidacion {
            get {
                return this.Fe_LiquidacionField;
            }
            set {
                if ((this.Fe_LiquidacionField.Equals(value) != true)) {
                    this.Fe_LiquidacionField = value;
                    this.RaisePropertyChanged("Fe_Liquidacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Ss_OtrosGastos {
            get {
                return this.Ss_OtrosGastosField;
            }
            set {
                if ((this.Ss_OtrosGastosField.Equals(value) != true)) {
                    this.Ss_OtrosGastosField = value;
                    this.RaisePropertyChanged("Ss_OtrosGastos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Ss_TotalAsignado {
            get {
                return this.Ss_TotalAsignadoField;
            }
            set {
                if ((this.Ss_TotalAsignadoField.Equals(value) != true)) {
                    this.Ss_TotalAsignadoField = value;
                    this.RaisePropertyChanged("Ss_TotalAsignado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Ss_TotalUtilizado {
            get {
                return this.Ss_TotalUtilizadoField;
            }
            set {
                if ((this.Ss_TotalUtilizadoField.Equals(value) != true)) {
                    this.Ss_TotalUtilizadoField = value;
                    this.RaisePropertyChanged("Ss_TotalUtilizado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public LiquidarServiceTest.LiquidacionesWS.Solicitud solicitud {
            get {
                return this.solicitudField;
            }
            set {
                if ((object.ReferenceEquals(this.solicitudField, value) != true)) {
                    this.solicitudField = value;
                    this.RaisePropertyChanged("solicitud");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Solicitud", Namespace="http://schemas.datacontract.org/2004/07/LiquidarServices.Dominio")]
    [System.SerializableAttribute()]
    public partial class Solicitud : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Co_SolicitudField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime Fe_SolicitudField;
        
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
        public int Co_Solicitud {
            get {
                return this.Co_SolicitudField;
            }
            set {
                if ((this.Co_SolicitudField.Equals(value) != true)) {
                    this.Co_SolicitudField = value;
                    this.RaisePropertyChanged("Co_Solicitud");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Fe_Solicitud {
            get {
                return this.Fe_SolicitudField;
            }
            set {
                if ((this.Fe_SolicitudField.Equals(value) != true)) {
                    this.Fe_SolicitudField = value;
                    this.RaisePropertyChanged("Fe_Solicitud");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ValidationException", Namespace="http://schemas.datacontract.org/2004/07/LiquidarServices.Persistencia")]
    [System.SerializableAttribute()]
    public partial class ValidationException : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValidationErrorField;
        
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
        public string ValidationError {
            get {
                return this.ValidationErrorField;
            }
            set {
                if ((object.ReferenceEquals(this.ValidationErrorField, value) != true)) {
                    this.ValidationErrorField = value;
                    this.RaisePropertyChanged("ValidationError");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LiquidacionesWS.ILiquidaciones")]
    public interface ILiquidaciones {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILiquidaciones/CrearLiquidacion", ReplyAction="http://tempuri.org/ILiquidaciones/CrearLiquidacionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(LiquidarServiceTest.LiquidacionesWS.ValidationException), Action="http://tempuri.org/ILiquidaciones/CrearLiquidacionValidationExceptionFault", Name="ValidationException", Namespace="http://schemas.datacontract.org/2004/07/LiquidarServices.Persistencia")]
        LiquidarServiceTest.LiquidacionesWS.Liquidar CrearLiquidacion(System.DateTime FeLiquidacion, int CoSolicitud, double SsTotalAsignado, double SsTotalUtilizado, double SsOtrosGastos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILiquidaciones/ObtenerLiquidacion", ReplyAction="http://tempuri.org/ILiquidaciones/ObtenerLiquidacionResponse")]
        LiquidarServiceTest.LiquidacionesWS.Liquidar ObtenerLiquidacion(int CoLiquidacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILiquidaciones/ModificarLiquidacion", ReplyAction="http://tempuri.org/ILiquidaciones/ModificarLiquidacionResponse")]
        LiquidarServiceTest.LiquidacionesWS.Liquidar ModificarLiquidacion(int CoLiquidacion, System.DateTime FeLiquidacion, int CoSolicitud, double SsTotalAsignado, double SsTotalUtilizado, double SsOtrosGastos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILiquidaciones/EliminarLiquidacion", ReplyAction="http://tempuri.org/ILiquidaciones/EliminarLiquidacionResponse")]
        void EliminarLiquidacion(int CoLiquidacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILiquidaciones/ListarLiquidaciones", ReplyAction="http://tempuri.org/ILiquidaciones/ListarLiquidacionesResponse")]
        LiquidarServiceTest.LiquidacionesWS.Liquidar[] ListarLiquidaciones();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILiquidacionesChannel : LiquidarServiceTest.LiquidacionesWS.ILiquidaciones, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LiquidacionesClient : System.ServiceModel.ClientBase<LiquidarServiceTest.LiquidacionesWS.ILiquidaciones>, LiquidarServiceTest.LiquidacionesWS.ILiquidaciones {
        
        public LiquidacionesClient() {
        }
        
        public LiquidacionesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LiquidacionesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LiquidacionesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LiquidacionesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public LiquidarServiceTest.LiquidacionesWS.Liquidar CrearLiquidacion(System.DateTime FeLiquidacion, int CoSolicitud, double SsTotalAsignado, double SsTotalUtilizado, double SsOtrosGastos) {
            return base.Channel.CrearLiquidacion(FeLiquidacion, CoSolicitud, SsTotalAsignado, SsTotalUtilizado, SsOtrosGastos);
        }
        
        public LiquidarServiceTest.LiquidacionesWS.Liquidar ObtenerLiquidacion(int CoLiquidacion) {
            return base.Channel.ObtenerLiquidacion(CoLiquidacion);
        }
        
        public LiquidarServiceTest.LiquidacionesWS.Liquidar ModificarLiquidacion(int CoLiquidacion, System.DateTime FeLiquidacion, int CoSolicitud, double SsTotalAsignado, double SsTotalUtilizado, double SsOtrosGastos) {
            return base.Channel.ModificarLiquidacion(CoLiquidacion, FeLiquidacion, CoSolicitud, SsTotalAsignado, SsTotalUtilizado, SsOtrosGastos);
        }
        
        public void EliminarLiquidacion(int CoLiquidacion) {
            base.Channel.EliminarLiquidacion(CoLiquidacion);
        }
        
        public LiquidarServiceTest.LiquidacionesWS.Liquidar[] ListarLiquidaciones() {
            return base.Channel.ListarLiquidaciones();
        }
    }
}
