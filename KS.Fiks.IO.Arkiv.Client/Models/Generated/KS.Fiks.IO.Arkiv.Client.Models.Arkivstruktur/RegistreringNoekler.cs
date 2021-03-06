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
    [System.Xml.Serialization.XmlTypeAttribute("registreringNoekler", Namespace="http://www.ks.no/standarder/fiks/arkiv/arkivstruktur/noekler/v1")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(JournalpostNoekler))]
    public partial class RegistreringNoekler
    {
        
        [System.Xml.Serialization.XmlElementAttribute("systemID")]
        public KS.Fiks.IO.Arkiv.Client.Models.Metadatakatalog.SystemID SystemID { get; set; }
        
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
        /// <para>M604</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("arkivertDato", DataType="dateTime")]
        public System.DateTime ArkivertDato { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ArkivertDatoSpecified { get; set; }
        
        /// <summary>
        /// <para>M605</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("arkivertAv")]
        public string ArkivertAv { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("referanseForelderMappe")]
        public KS.Fiks.IO.Arkiv.Client.Models.Metadatakatalog.SystemID ReferanseForelderMappe { get; set; }
        
        /// <summary>
        /// <para>M208</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("referanseArkivdel")]
        public string ReferanseArkivdel { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<DokumentbeskrivelseNoekler> _dokumentbeskrivelse;
        
        [System.Xml.Serialization.XmlElementAttribute("dokumentbeskrivelse")]
        public System.Collections.ObjectModel.Collection<DokumentbeskrivelseNoekler> Dokumentbeskrivelse
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
        /// </summary>
        public RegistreringNoekler()
        {
            this._dokumentbeskrivelse = new System.Collections.ObjectModel.Collection<DokumentbeskrivelseNoekler>();
        }
        
        /// <summary>
        /// <para>M004</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("registreringsID")]
        public string RegistreringsID { get; set; }
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("referanseEksternNoekkel")]
        public EksternNoekkel ReferanseEksternNoekkel { get; set; }
    }
}
