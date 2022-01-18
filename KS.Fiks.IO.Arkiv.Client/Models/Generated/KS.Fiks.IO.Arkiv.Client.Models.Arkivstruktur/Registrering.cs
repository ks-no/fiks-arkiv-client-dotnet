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
    [System.Xml.Serialization.XmlTypeAttribute("registrering", Namespace="http://www.arkivverket.no/standarder/noark5/arkivstruktur")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("registrering", Namespace="http://www.arkivverket.no/standarder/noark5/arkivstruktur")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Arkivnotat))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Journalpost))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Moeteregistrering))]
    public partial class Registrering
    {
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("systemID")]
        public KS.Fiks.IO.Arkiv.Client.Models.Metadatakatalog.SystemID SystemID { get; set; }
        
        /// <summary>
        /// <para>M600</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("opprettetDato", DataType="dateTime")]
        public System.DateTime OpprettetDato { get; set; }
        
        /// <summary>
        /// <para>M601</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("opprettetAv")]
        public string OpprettetAv { get; set; }
        
        /// <summary>
        /// <para>M604</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("arkivertDato", DataType="dateTime")]
        public System.DateTime ArkivertDato { get; set; }
        
        /// <summary>
        /// <para>M605</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("arkivertAv")]
        public string ArkivertAv { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<string> _referanseArkivdel;
        
        /// <summary>
        /// <para>M208</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("referanseArkivdel")]
        public System.Collections.ObjectModel.Collection<string> ReferanseArkivdel
        {
            get
            {
                return this._referanseArkivdel;
            }
            private set
            {
                this._referanseArkivdel = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReferanseArkivdelSpecified
        {
            get
            {
                return (this.ReferanseArkivdel.Count != 0);
            }
        }
        
        /// <summary>
        /// </summary>
        public Registrering()
        {
            this._referanseArkivdel = new System.Collections.ObjectModel.Collection<string>();
            this._part = new System.Collections.ObjectModel.Collection<Part>();
            this._dokumentbeskrivelse = new System.Collections.ObjectModel.Collection<Dokumentbeskrivelse>();
            this._noekkelord = new System.Collections.ObjectModel.Collection<string>();
            this._forfatter = new System.Collections.ObjectModel.Collection<string>();
            this._oppbevaringssted = new System.Collections.ObjectModel.Collection<string>();
            this._merknad = new System.Collections.ObjectModel.Collection<Merknad>();
            this._kryssreferanse = new System.Collections.ObjectModel.Collection<Kryssreferanse>();
            this._korrespondansepart = new System.Collections.ObjectModel.Collection<Korrespondansepart>();
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<Part> _part;
        
        [System.Xml.Serialization.XmlElementAttribute("part")]
        public System.Collections.ObjectModel.Collection<Part> Part
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
        
        [System.Xml.Serialization.XmlElementAttribute("kassasjon")]
        public Kassasjon Kassasjon { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("skjerming")]
        public Skjerming Skjerming { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("gradering")]
        public Gradering Gradering { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<Dokumentbeskrivelse> _dokumentbeskrivelse;
        
        [System.Xml.Serialization.XmlElementAttribute("dokumentbeskrivelse")]
        public System.Collections.ObjectModel.Collection<Dokumentbeskrivelse> Dokumentbeskrivelse
        {
            get
            {
                return this._dokumentbeskrivelse;
            }
            private set
            {
                this._dokumentbeskrivelse = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DokumentbeskrivelseSpecified
        {
            get
            {
                return (this.Dokumentbeskrivelse.Count != 0);
            }
        }
        
        /// <summary>
        /// <para>M004</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("registreringsID")]
        public string RegistreringsID { get; set; }
        
        /// <summary>
        /// <para>M020</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("tittel")]
        public string Tittel { get; set; }
        
        /// <summary>
        /// <para>M025</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("offentligTittel")]
        public string OffentligTittel { get; set; }
        
        /// <summary>
        /// <para>M021</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("beskrivelse")]
        public string Beskrivelse { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<string> _noekkelord;
        
        /// <summary>
        /// <para>M022</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("noekkelord")]
        public System.Collections.ObjectModel.Collection<string> Noekkelord
        {
            get
            {
                return this._noekkelord;
            }
            private set
            {
                this._noekkelord = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NoekkelordSpecified
        {
            get
            {
                return (this.Noekkelord.Count != 0);
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<string> _forfatter;
        
        /// <summary>
        /// <para>M024</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("forfatter")]
        public System.Collections.ObjectModel.Collection<string> Forfatter
        {
            get
            {
                return this._forfatter;
            }
            private set
            {
                this._forfatter = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForfatterSpecified
        {
            get
            {
                return (this.Forfatter.Count != 0);
            }
        }
        
        /// <summary>
        /// <para>M300</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("dokumentmedium")]
        public string Dokumentmedium { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<string> _oppbevaringssted;
        
        /// <summary>
        /// <para>M301</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("oppbevaringssted")]
        public System.Collections.ObjectModel.Collection<string> Oppbevaringssted
        {
            get
            {
                return this._oppbevaringssted;
            }
            private set
            {
                this._oppbevaringssted = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OppbevaringsstedSpecified
        {
            get
            {
                return (this.Oppbevaringssted.Count != 0);
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("virksomhetsspesifikkeMetadata")]
        public object VirksomhetsspesifikkeMetadata { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<Merknad> _merknad;
        
        [System.Xml.Serialization.XmlElementAttribute("merknad")]
        public System.Collections.ObjectModel.Collection<Merknad> Merknad
        {
            get
            {
                return this._merknad;
            }
            private set
            {
                this._merknad = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MerknadSpecified
        {
            get
            {
                return (this.Merknad.Count != 0);
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<Kryssreferanse> _kryssreferanse;
        
        [System.Xml.Serialization.XmlElementAttribute("kryssreferanse")]
        public System.Collections.ObjectModel.Collection<Kryssreferanse> Kryssreferanse
        {
            get
            {
                return this._kryssreferanse;
            }
            private set
            {
                this._kryssreferanse = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KryssreferanseSpecified
        {
            get
            {
                return (this.Kryssreferanse.Count != 0);
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<Korrespondansepart> _korrespondansepart;
        
        [System.Xml.Serialization.XmlElementAttribute("korrespondansepart")]
        public System.Collections.ObjectModel.Collection<Korrespondansepart> Korrespondansepart
        {
            get
            {
                return this._korrespondansepart;
            }
            private set
            {
                this._korrespondansepart = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KorrespondansepartSpecified
        {
            get
            {
                return (this.Korrespondansepart.Count != 0);
            }
        }
    }
}