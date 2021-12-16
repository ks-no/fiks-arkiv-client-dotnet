//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
//This source code was auto-generated by MonoXSD
//
namespace no.ks.fiks.io.arkiv.innsyn.journalpost.hent {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.arkivverket.no/standarder/noark5/journalpost/hent/v2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.arkivverket.no/standarder/noark5/journalpost/hent/v2", IsNullable=false)]
    public partial class journalpostHent {
        
        private systemID systemIDField;
        
        private string journalaarField;
        
        private string journalsekvensnummerField;
        
        private string journalpostnummerField;
        
        private eksternNoekkel referanseEksternNoekkelField;
        
        private string registreringsIDField;
        
        private responsType responsTypeField;
        
        private inkluder inkluderField;
        
        private bool inkluderFieldSpecified;
        
        public journalpostHent() {
            this.responsTypeField = responsType.minimum;
        }
        
        /// <remarks/>
        public systemID systemID {
            get {
                return this.systemIDField;
            }
            set {
                this.systemIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string journalaar {
            get {
                return this.journalaarField;
            }
            set {
                this.journalaarField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string journalsekvensnummer {
            get {
                return this.journalsekvensnummerField;
            }
            set {
                this.journalsekvensnummerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string journalpostnummer {
            get {
                return this.journalpostnummerField;
            }
            set {
                this.journalpostnummerField = value;
            }
        }
        
        /// <remarks/>
        public eksternNoekkel referanseEksternNoekkel {
            get {
                return this.referanseEksternNoekkelField;
            }
            set {
                this.referanseEksternNoekkelField = value;
            }
        }
        
        /// <remarks/>
        public string registreringsID {
            get {
                return this.registreringsIDField;
            }
            set {
                this.registreringsIDField = value;
            }
        }
        
        /// <remarks/>
        public responsType responsType {
            get {
                return this.responsTypeField;
            }
            set {
                this.responsTypeField = value;
            }
        }
        
        /// <remarks/>
        public inkluder inkluder {
            get {
                return this.inkluderField;
            }
            set {
                this.inkluderField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool inkluderSpecified {
            get {
                return this.inkluderFieldSpecified;
            }
            set {
                this.inkluderFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.arkivverket.no/standarder/noark5/metadatakatalog/v2")]
    public partial class systemID {
        
        private string labelField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string label {
            get {
                return this.labelField;
            }
            set {
                this.labelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.arkivverket.no/standarder/noark5/journalpost/hent/v2")]
    public partial class eksternNoekkel {
        
        private string fagsystemField;
        
        private string noekkelField;
        
        /// <remarks/>
        public string fagsystem {
            get {
                return this.fagsystemField;
            }
            set {
                this.fagsystemField = value;
            }
        }
        
        /// <remarks/>
        public string noekkel {
            get {
                return this.noekkelField;
            }
            set {
                this.noekkelField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.arkivverket.no/standarder/noark5/journalpost/hent/v2")]
    public enum responsType {
        
        /// <remarks/>
        noekler,
        
        /// <remarks/>
        minimum,
        
        /// <remarks/>
        utvidet,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.arkivverket.no/standarder/noark5/journalpost/hent/v2")]
    public enum inkluder {
        
        /// <remarks/>
        klasse,
        
        /// <remarks/>
        noekkelord,
        
        /// <remarks/>
        kryssreferanse,
        
        /// <remarks/>
        part,
        
        /// <remarks/>
        merknad,
        
        /// <remarks/>
        presedens,
        
        /// <remarks/>
        moetedeltaker,
        
        /// <remarks/>
        dokumentbeskrivelse,
        
        /// <remarks/>
        korrespondansepart,
        
        /// <remarks/>
        avskrivning,
        
        /// <remarks/>
        dokumentflyt,
        
        /// <remarks/>
        dokumentobjekt,
    }
}