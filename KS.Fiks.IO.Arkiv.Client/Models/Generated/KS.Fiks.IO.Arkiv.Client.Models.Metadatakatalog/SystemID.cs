//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 2.0.629.0
namespace KS.Fiks.IO.Arkiv.Client.Models.Metadatakatalog
{
    
    
    /// <summary>
    /// <para>M001</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.629.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("systemID", Namespace="http://www.arkivverket.no/standarder/noark5/metadatakatalog/v2")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SystemID
    {
        
        /// <summary>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RegularExpressionAttribute("[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}")]
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("label")]
        public string Label { get; set; }
    }
}
