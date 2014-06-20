using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SNCFDI.Model
{

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina")]
    public partial class Deducciones
    {
        [System.Xml.Serialization.XmlElementAttribute("Deduccion")]
        public Deduccion[] Deduccion { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalGravado { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalExento { get; set; }
    }


    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina")]
    public partial class Deduccion
    {
        [XmlIgnore]
        public int? NumEmpleado { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TipoDeduccion { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Clave { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Concepto { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImporteGravado { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImporteExento { get; set; }

    }

}
