//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 2.0.629.0
namespace KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.629.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("punkt", Namespace="http://www.arkivverket.no/standarder/noark5/arkivmelding/v2")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Punkt
    {
        
        /// <summary>
        /// <para>M3..</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("koordinatsystem")]
        public string Koordinatsystem { get; set; }
        
        /// <summary>
        /// <para>M3..</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("x")]
        public double X { get; set; }
        
        /// <summary>
        /// <para>M3..</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("y")]
        public double Y { get; set; }
        
        /// <summary>
        /// <para>M3..</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("z")]
        public double Z { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ZSpecified { get; set; }
    }
}
