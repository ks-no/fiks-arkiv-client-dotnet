//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 2.0.629.0
namespace KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.629.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("journalpost", Namespace="http://www.arkivverket.no/standarder/noark5/arkivmelding/v2")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("journalpost", Namespace="http://www.arkivverket.no/standarder/noark5/arkivmelding/v2")]
    public partial class Journalpost : Registrering
    {
        
        /// <summary>
        /// <para>M013</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("journalaar")]
        public string Journalaar { get; set; }
        
        /// <summary>
        /// <para>M014</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("journalsekvensnummer")]
        public string Journalsekvensnummer { get; set; }
        
        /// <summary>
        /// <para>M015</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("journalpostnummer")]
        public string Journalpostnummer { get; set; }
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("journalposttype")]
        public KS.Fiks.IO.Arkiv.Client.Models.Metadatakatalog.Journalposttype Journalposttype { get; set; }
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("journalstatus")]
        public KS.Fiks.IO.Arkiv.Client.Models.Metadatakatalog.Journalstatus Journalstatus { get; set; }
        
        /// <summary>
        /// <para>M101</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("journaldato", DataType="date")]
        public System.DateTime Journaldato { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool JournaldatoSpecified { get; set; }
        
        /// <summary>
        /// <para>M103</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("dokumentetsDato", DataType="date")]
        public System.DateTime DokumentetsDato { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DokumentetsDatoSpecified { get; set; }
        
        /// <summary>
        /// <para>M104</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("mottattDato", DataType="dateTime")]
        public System.DateTime MottattDato { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MottattDatoSpecified { get; set; }
        
        /// <summary>
        /// <para>M105</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("sendtDato", DataType="dateTime")]
        public System.DateTime SendtDato { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SendtDatoSpecified { get; set; }
        
        /// <summary>
        /// <para>M109</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("forfallsdato", DataType="date")]
        public System.DateTime Forfallsdato { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForfallsdatoSpecified { get; set; }
        
        /// <summary>
        /// <para>M110</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("offentlighetsvurdertDato", DataType="date")]
        public System.DateTime OffentlighetsvurdertDato { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OffentlighetsvurdertDatoSpecified { get; set; }
        
        /// <summary>
        /// <para>M304</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("antallVedlegg")]
        public string AntallVedlegg { get; set; }
        
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
        
        /// <summary>
        /// <para>M308</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("journalenhet")]
        public string Journalenhet { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<Avskrivning> _avskrivning;
        
        [System.Xml.Serialization.XmlElementAttribute("avskrivning")]
        public System.Collections.ObjectModel.Collection<Avskrivning> Avskrivning
        {
            get
            {
                return this._avskrivning;
            }
            private set
            {
                this._avskrivning = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AvskrivningSpecified
        {
            get
            {
                return (this.Avskrivning.Count != 0);
            }
        }
        
        /// <summary>
        /// </summary>
        public Journalpost()
        {
            this._avskrivning = new System.Collections.ObjectModel.Collection<Avskrivning>();
            this._dokumentflyt = new System.Collections.ObjectModel.Collection<Dokumentflyt>();
            this._presedens = new System.Collections.ObjectModel.Collection<Presedens>();
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<Dokumentflyt> _dokumentflyt;
        
        [System.Xml.Serialization.XmlElementAttribute("dokumentflyt")]
        public System.Collections.ObjectModel.Collection<Dokumentflyt> Dokumentflyt
        {
            get
            {
                return this._dokumentflyt;
            }
            private set
            {
                this._dokumentflyt = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DokumentflytSpecified
        {
            get
            {
                return (this.Dokumentflyt.Count != 0);
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<Presedens> _presedens;
        
        [System.Xml.Serialization.XmlElementAttribute("presedens")]
        public System.Collections.ObjectModel.Collection<Presedens> Presedens
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
