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
    [System.Xml.Serialization.XmlTypeAttribute("datevalues", Namespace="http://www.ks.no/standarder/fiks/arkiv/sok/v1")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Datevalues
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<System.DateTime> _value;
        
        [System.Xml.Serialization.XmlElementAttribute("value", DataType="dateTime")]
        public System.Collections.ObjectModel.Collection<System.DateTime> Value
        {
            get
            {
                return this._value;
            }
            private set
            {
                this._value = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValueSpecified
        {
            get
            {
                return (this.Value.Count != 0);
            }
        }
        
        /// <summary>
        /// </summary>
        public Datevalues()
        {
            this._value = new System.Collections.ObjectModel.Collection<System.DateTime>();
        }
    }
}
