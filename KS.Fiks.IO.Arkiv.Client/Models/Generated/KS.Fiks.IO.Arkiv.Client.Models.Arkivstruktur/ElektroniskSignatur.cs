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
    [System.Xml.Serialization.XmlTypeAttribute("elektroniskSignatur", Namespace="http://www.arkivverket.no/standarder/noark5/arkivstruktur")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ElektroniskSignatur
    {
        
        /// <summary>
        /// <para>M507</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("elektroniskSignaturSikkerhetsnivaa")]
        public string ElektroniskSignaturSikkerhetsnivaa { get; set; }
        
        /// <summary>
        /// <para>M508</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("elektroniskSignaturVerifisert")]
        public string ElektroniskSignaturVerifisert { get; set; }
        
        /// <summary>
        /// <para>M622</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("verifisertDato", DataType="date")]
        public System.DateTime VerifisertDato { get; set; }
        
        /// <summary>
        /// <para>M623</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("verifisertAv")]
        public string VerifisertAv { get; set; }
    }
}