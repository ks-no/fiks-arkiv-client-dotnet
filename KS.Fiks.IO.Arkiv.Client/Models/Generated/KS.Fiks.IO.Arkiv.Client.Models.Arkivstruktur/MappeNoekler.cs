//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 2.0.629.0
namespace KS.Fiks.IO.Arkiv.Client.Models.Arkivstruktur
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.629.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("mappeNoekler", Namespace="http://www.ks.no/standarder/fiks/arkiv/arkivstruktur/noekler/v1")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SaksmappeNoekler))]
    public partial class MappeNoekler
    {
        
        [System.Xml.Serialization.XmlElementAttribute("systemID")]
        public KS.Fiks.IO.Arkiv.Client.Models.Metadatakatalog.SystemID SystemID { get; set; }
        
        /// <summary>
        /// <para>M003</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("mappeID")]
        public string MappeID { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("ReferanseForeldermappe")]
        public KS.Fiks.IO.Arkiv.Client.Models.Metadatakatalog.SystemID ReferanseForeldermappe { get; set; }
        
        /// <summary>
        /// <para>M600</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("opprettetDato", DataType="dateTime")]
        public System.DateTime OpprettetDato { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OpprettetDatoSpecified { get; set; }
        
        /// <summary>
        /// <para>M601</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("opprettetAv")]
        public string OpprettetAv { get; set; }
        
        /// <summary>
        /// <para>M602</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("avsluttetDato", DataType="dateTime")]
        public System.DateTime AvsluttetDato { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AvsluttetDatoSpecified { get; set; }
        
        /// <summary>
        /// <para>M603</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("avsluttetAv")]
        public string AvsluttetAv { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<PartNoekler> _part;
        
        [System.Xml.Serialization.XmlElementAttribute("part")]
        public System.Collections.ObjectModel.Collection<PartNoekler> Part
        {
            get
            {
                return this._part;
            }
            private set
            {
                this._part = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PartSpecified
        {
            get
            {
                return (this.Part.Count != 0);
            }
        }
        
        /// <summary>
        /// </summary>
        public MappeNoekler()
        {
            this._part = new System.Collections.ObjectModel.Collection<PartNoekler>();
            this._mappe = new System.Collections.ObjectModel.Collection<MappeNoekler>();
            this._registrering = new System.Collections.ObjectModel.Collection<RegistreringNoekler>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("referanseEksternNoekkel")]
        public EksternNoekkel ReferanseEksternNoekkel { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<MappeNoekler> _mappe;
        
        [System.Xml.Serialization.XmlElementAttribute("mappe")]
        public System.Collections.ObjectModel.Collection<MappeNoekler> Mappe
        {
            get
            {
                return this._mappe;
            }
            private set
            {
                this._mappe = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MappeSpecified
        {
            get
            {
                return (this.Mappe.Count != 0);
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<RegistreringNoekler> _registrering;
        
        [System.Xml.Serialization.XmlElementAttribute("registrering")]
        public System.Collections.ObjectModel.Collection<RegistreringNoekler> Registrering
        {
            get
            {
                return this._registrering;
            }
            private set
            {
                this._registrering = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RegistreringSpecified
        {
            get
            {
                return (this.Registrering.Count != 0);
            }
        }
    }
}