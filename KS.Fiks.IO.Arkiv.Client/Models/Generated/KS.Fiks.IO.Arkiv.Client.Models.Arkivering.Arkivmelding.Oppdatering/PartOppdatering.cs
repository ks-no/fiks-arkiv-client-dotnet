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
    [System.Xml.Serialization.XmlTypeAttribute("partOppdatering", Namespace="http://www.arkivverket.no/standarder/noark5/arkivmeldingoppdatering/v2")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PartOppdatering
    {
        
        /// <summary>
        /// <para>M010</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("partID")]
        public string PartID { get; set; }
        
        /// <summary>
        /// <para>M302</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("partNavn")]
        public string PartNavn { get; set; }
        
        /// <summary>
        /// <para>M303</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("partRolle")]
        public string PartRolle { get; set; }
        
        /// <summary>
        /// <para>M4..</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("organisasjonid")]
        public string Organisasjonid { get; set; }
        
        /// <summary>
        /// <para>M4..</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("personid")]
        public string Personid { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<string> _postadresse;
        
        /// <summary>
        /// <para>M406</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("postadresse")]
        public System.Collections.ObjectModel.Collection<string> Postadresse
        {
            get
            {
                return this._postadresse;
            }
            private set
            {
                this._postadresse = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PostadresseSpecified
        {
            get
            {
                return (this.Postadresse.Count != 0);
            }
        }
        
        /// <summary>
        /// </summary>
        public PartOppdatering()
        {
            this._postadresse = new System.Collections.ObjectModel.Collection<string>();
            this._telefonnummer = new System.Collections.ObjectModel.Collection<string>();
        }
        
        /// <summary>
        /// <para>M407</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("postnummer")]
        public string Postnummer { get; set; }
        
        /// <summary>
        /// <para>M408</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("poststed")]
        public string Poststed { get; set; }
        
        /// <summary>
        /// <para>M409</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("land")]
        public string Land { get; set; }
        
        /// <summary>
        /// <para>M410</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("epostadresse")]
        public string Epostadresse { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<string> _telefonnummer;
        
        /// <summary>
        /// <para>M411</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("telefonnummer")]
        public System.Collections.ObjectModel.Collection<string> Telefonnummer
        {
            get
            {
                return this._telefonnummer;
            }
            private set
            {
                this._telefonnummer = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TelefonnummerSpecified
        {
            get
            {
                return (this.Telefonnummer.Count != 0);
            }
        }
        
        /// <summary>
        /// <para>M412</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("kontaktperson")]
        public string Kontaktperson { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("virksomhetsspesifikkeMetadata")]
        public object VirksomhetsspesifikkeMetadata { get; set; }
        
        /// <summary>
        /// <para>M5..</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("skjermetObjekt")]
        public string SkjermetObjekt { get; set; }
        
        /// <summary>
        /// <para>M5..</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("personnavn")]
        public string Personnavn { get; set; }
    }
}
