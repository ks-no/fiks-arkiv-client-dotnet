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
    [System.Xml.Serialization.XmlTypeAttribute("presedensMinimum", Namespace="http://www.ks.no/standarder/fiks/arkiv/arkivstruktur/minimum/v1")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PresedensMinimum
    {
        
        /// <summary>
        /// <para>M111</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("presedensDato", DataType="date")]
        public System.DateTime PresedensDato { get; set; }
        
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
        /// <para>M020</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("tittel")]
        public string Tittel { get; set; }
        
        /// <summary>
        /// <para>M021</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("beskrivelse")]
        public string Beskrivelse { get; set; }
        
        /// <summary>
        /// <para>M311</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("presedensHjemmel")]
        public string PresedensHjemmel { get; set; }
        
        /// <summary>
        /// <para>M312</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("rettskildefaktor")]
        public string Rettskildefaktor { get; set; }
        
        /// <summary>
        /// <para>M628</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("presedensGodkjentDato", DataType="dateTime")]
        public System.DateTime PresedensGodkjentDato { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PresedensGodkjentDatoSpecified { get; set; }
        
        /// <summary>
        /// <para>M629</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("presedensGodkjentAv")]
        public string PresedensGodkjentAv { get; set; }
        
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
        
        [System.Xml.Serialization.XmlElementAttribute("presedensStatus")]
        public KS.Fiks.IO.Arkiv.Client.Models.Metadatakatalog.PresedensStatus PresedensStatus { get; set; }
    }
}
