//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 2.0.629.0
namespace KS.Fiks.IO.Arkiv.Client.Models.Innsyn.Sok
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.629.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("sortering", Namespace="http://www.ks.no/standarder/fiks/arkiv/sok/v1")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Sortering
    {
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("felt")]
        public SorteringFelt Felt { get; set; }
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("type")]
        public SorteringType Type { get; set; }
    }
}
