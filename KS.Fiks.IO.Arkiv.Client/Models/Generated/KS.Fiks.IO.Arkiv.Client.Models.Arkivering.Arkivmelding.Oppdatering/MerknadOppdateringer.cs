//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 2.0.629.0
namespace KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Oppdatering
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.629.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("merknadOppdateringer", Namespace="http://www.arkivverket.no/standarder/noark5/arkivmeldingoppdatering/v2")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MerknadOppdateringer
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<MerknadOppdatering> _oppdatering;
        
        [System.Xml.Serialization.XmlElementAttribute("oppdatering")]
        public System.Collections.ObjectModel.Collection<MerknadOppdatering> Oppdatering
        {
            get
            {
                return this._oppdatering;
            }
            private set
            {
                this._oppdatering = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OppdateringSpecified
        {
            get
            {
                return (this.Oppdatering.Count != 0);
            }
        }
        
        /// <summary>
        /// </summary>
        public MerknadOppdateringer()
        {
            this._oppdatering = new System.Collections.ObjectModel.Collection<MerknadOppdatering>();
            this._slett = new System.Collections.ObjectModel.Collection<MerknadSlett>();
            this._ny = new System.Collections.ObjectModel.Collection<KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Merknad>();
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<MerknadSlett> _slett;
        
        [System.Xml.Serialization.XmlElementAttribute("slett")]
        public System.Collections.ObjectModel.Collection<MerknadSlett> Slett
        {
            get
            {
                return this._slett;
            }
            private set
            {
                this._slett = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SlettSpecified
        {
            get
            {
                return (this.Slett.Count != 0);
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Merknad> _ny;
        
        [System.Xml.Serialization.XmlElementAttribute("ny")]
        public System.Collections.ObjectModel.Collection<KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Merknad> Ny
        {
            get
            {
                return this._ny;
            }
            private set
            {
                this._ny = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NySpecified
        {
            get
            {
                return (this.Ny.Count != 0);
            }
        }
    }
}
