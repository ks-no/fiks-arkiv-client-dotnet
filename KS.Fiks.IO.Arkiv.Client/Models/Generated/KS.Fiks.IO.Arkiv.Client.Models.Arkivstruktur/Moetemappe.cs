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
    [System.Xml.Serialization.XmlTypeAttribute("moetemappe", Namespace="http://www.arkivverket.no/standarder/noark5/arkivstruktur")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Moetemappe : Mappe
    {
        
        /// <summary>
        /// <para>M008</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("moetenummer")]
        public string Moetenummer { get; set; }
        
        /// <summary>
        /// <para>M370</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("utvalg")]
        public string Utvalg { get; set; }
        
        /// <summary>
        /// <para>M102</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("moetedato", DataType="date")]
        public System.DateTime Moetedato { get; set; }
        
        /// <summary>
        /// <para>M371</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.Xml.Serialization.XmlElementAttribute("moetested")]
        public string Moetested { get; set; }
        
        /// <summary>
        /// <para>M221</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("referanseForrigeMoete")]
        public string ReferanseForrigeMoete { get; set; }
        
        /// <summary>
        /// <para>M222</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("referanseNesteMoete")]
        public string ReferanseNesteMoete { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<Moetedeltaker> _moetedeltaker;
        
        [System.Xml.Serialization.XmlElementAttribute("moetedeltaker")]
        public System.Collections.ObjectModel.Collection<Moetedeltaker> Moetedeltaker
        {
            get
            {
                return this._moetedeltaker;
            }
            private set
            {
                this._moetedeltaker = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MoetedeltakerSpecified
        {
            get
            {
                return (this.Moetedeltaker.Count != 0);
            }
        }
        
        /// <summary>
        /// </summary>
        public Moetemappe()
        {
            this._moetedeltaker = new System.Collections.ObjectModel.Collection<Moetedeltaker>();
        }
    }
}