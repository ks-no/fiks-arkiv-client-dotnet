//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 2.0.629.0
namespace KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmeldingkvittering
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.629.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("journalpostKvittering", Namespace="http://www.arkivverket.no/standarder/noark5/arkivmeldingkvittering/v2")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class JournalpostKvittering : RegistreringKvittering
    {
        
        /// <summary>
        /// <para>M013</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("journalaar")]
        public string Journalaar { get; set; }
        
        /// <summary>
        /// <para>M014</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("journalsekvensnummer")]
        public string Journalsekvensnummer { get; set; }
        
        /// <summary>
        /// <para>M015</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("journalpostnummer")]
        public string Journalpostnummer { get; set; }
        
        /// <summary>
        /// <para>M082</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("journalposttype")]
        public string Journalposttype { get; set; }
        
        /// <summary>
        /// <para>M053</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("journalstatus")]
        public string Journalstatus { get; set; }
        
        /// <summary>
        /// <para>M101</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("journaldato", DataType="date")]
        public System.DateTime Journaldato { get; set; }
        
        /// <summary>
        /// <para>M109</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("forfallsdato", DataType="date")]
        public System.DateTime Forfallsdato { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForfallsdatoSpecified { get; set; }
    }
}