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
    [System.Xml.Serialization.XmlTypeAttribute("kryssreferanseMinimum", Namespace="http://www.ks.no/standarder/fiks/arkiv/arkivstruktur/minimum/v1")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class KryssreferanseMinimum
    {
        
        /// <summary>
        /// <para>M219</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("referanseTilKlasse")]
        public string ReferanseTilKlasse { get; set; }
        
        /// <summary>
        /// <para>M210</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("referanseTilMappe")]
        public string ReferanseTilMappe { get; set; }
        
        /// <summary>
        /// <para>M212</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("referanseTilRegistrering")]
        public string ReferanseTilRegistrering { get; set; }
    }
}
