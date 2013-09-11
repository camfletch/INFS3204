﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace infs3204_prac3.ManagementServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ManagementService.Job", Namespace="http://schemas.datacontract.org/2004/07/infs3204_prac3.Services")]
    [System.SerializableAttribute()]
    public partial class ManagementServiceJob : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CompanyNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PositionDescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PositionNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PositionTitleField;
        
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
        public string CompanyName {
            get {
                return this.CompanyNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CompanyNameField, value) != true)) {
                    this.CompanyNameField = value;
                    this.RaisePropertyChanged("CompanyName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PositionDescription {
            get {
                return this.PositionDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.PositionDescriptionField, value) != true)) {
                    this.PositionDescriptionField = value;
                    this.RaisePropertyChanged("PositionDescription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PositionNumber {
            get {
                return this.PositionNumberField;
            }
            set {
                if ((this.PositionNumberField.Equals(value) != true)) {
                    this.PositionNumberField = value;
                    this.RaisePropertyChanged("PositionNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PositionTitle {
            get {
                return this.PositionTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.PositionTitleField, value) != true)) {
                    this.PositionTitleField = value;
                    this.RaisePropertyChanged("PositionTitle");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ManagementServiceReference.IManagementService")]
    public interface IManagementService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagementService/SaveInfo", ReplyAction="http://tempuri.org/IManagementService/SaveInfoResponse")]
        bool SaveInfo(string firstName, string lastName, System.DateTime dateOfBirth, string email, string streetAddress, string suburb, string state, int postcode, infs3204_prac3.ManagementServiceReference.ManagementServiceJob job);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IManagementServiceChannel : infs3204_prac3.ManagementServiceReference.IManagementService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ManagementServiceClient : System.ServiceModel.ClientBase<infs3204_prac3.ManagementServiceReference.IManagementService>, infs3204_prac3.ManagementServiceReference.IManagementService {
        
        public ManagementServiceClient() {
        }
        
        public ManagementServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ManagementServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManagementServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManagementServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool SaveInfo(string firstName, string lastName, System.DateTime dateOfBirth, string email, string streetAddress, string suburb, string state, int postcode, infs3204_prac3.ManagementServiceReference.ManagementServiceJob job) {
            return base.Channel.SaveInfo(firstName, lastName, dateOfBirth, email, streetAddress, suburb, state, postcode, job);
        }
    }
}