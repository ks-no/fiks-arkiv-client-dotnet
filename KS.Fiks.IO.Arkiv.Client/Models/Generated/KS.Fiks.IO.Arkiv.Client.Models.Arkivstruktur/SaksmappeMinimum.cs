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
    [System.Xml.Serialization.XmlTypeAttribute("saksmappeMinimum", Namespace="http://www.ks.no/standarder/fiks/arkiv/arkivstruktur/minimum/v1")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SaksmappeMinimum : MappeMinimum
    {
        
        /// <summary>
        /// <para>M011</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("saksaar")]
        public string Saksaar { get; set; }
        
        /// <summary>
        /// <para>M012</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("sakssekvensnummer")]
        public string Sakssekvensnummer { get; set; }
        
        /// <summary>
        /// <para>M100</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("saksdato", DataType="date")]
        public System.DateTime Saksdato { get; set; }
        
        /// <summary>
        /// <para>M305</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("administrativEnhet")]
        public string AdministrativEnhet { get; set; }
        
        /// <summary>
        /// <para>M306</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("saksansvarlig")]
        public string Saksansvarlig { get; set; }
        
        /// <summary>
        /// <para>M308</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("journalenhet")]
        public string Journalenhet { get; set; }
        
        /// <summary>
        /// <para>M052</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("saksstatus")]
        public string Saksstatus { get; set; }
        
        /// <summary>
        /// <para>M106</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("utlaantDato", DataType="date")]
        public System.DateTime UtlaantDato { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UtlaantDatoSpecified { get; set; }
        
        /// <summary>
        /// <para>M309</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("utlaantTil")]
        public string UtlaantTil { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<string> _referanseSekundaerKlassifikasjon;
        
        /// <summary>
        /// <para>M209</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("referanseSekundaerKlassifikasjon")]
        public System.Collections.ObjectModel.Collection<string> ReferanseSekundaerKlassifikasjon
        {
            get
            {
                return this._referanseSekundaerKlassifikasjon;
            }
            private set
            {
                this._referanseSekundaerKlassifikasjon = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReferanseSekundaerKlassifikasjonSpecified
        {
            get
            {
                return (this.ReferanseSekundaerKlassifikasjon.Count != 0);
            }
        }
        
        /// <summary>
        /// </summary>
        public SaksmappeMinimum()
        {
            this._referanseSekundaerKlassifikasjon = new System.Collections.ObjectModel.Collection<string>();
            this._presedens = new System.Collections.ObjectModel.Collection<PresedensMinimum>();
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<PresedensMinimum> _presedens;
        
        [System.Xml.Serialization.XmlElementAttribute("presedens")]
        public System.Collections.ObjectModel.Collection<PresedensMinimum> Presedens
        {
            get
            {
                return this._presedens;
            }
            private set
            {
                this._presedens = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PresedensSpecified
        {
            get
            {
                return (this.Presedens.Count != 0);
            }
        }
    }
}