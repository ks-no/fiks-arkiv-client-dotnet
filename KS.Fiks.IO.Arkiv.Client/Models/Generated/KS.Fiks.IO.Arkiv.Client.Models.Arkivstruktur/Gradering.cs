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
    [System.Xml.Serialization.XmlTypeAttribute("gradering", Namespace="http://www.arkivverket.no/standarder/noark5/arkivstruktur")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("gradering", Namespace="http://www.arkivverket.no/standarder/noark5/arkivstruktur")]
    public partial class Gradering
    {
        
        /// <summary>
        /// <para>M506</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("grad")]
        public string Grad { get; set; }
        
        /// <summary>
        /// <para>M624</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("graderingsdato", DataType="dateTime")]
        public System.DateTime Graderingsdato { get; set; }
        
        /// <summary>
        /// <para>M625</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("gradertAv")]
        public string GradertAv { get; set; }
        
        /// <summary>
        /// <para>M626</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("nedgraderingsdato", DataType="dateTime")]
        public System.DateTime Nedgraderingsdato { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NedgraderingsdatoSpecified { get; set; }
        
        /// <summary>
        /// <para>M627</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("nedgradertAv")]
        public string NedgradertAv { get; set; }
    }
}
