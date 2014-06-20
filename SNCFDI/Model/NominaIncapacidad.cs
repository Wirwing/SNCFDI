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
    public partial class Incapacidad
    {
        [XmlIgnore]
        public int? NumEmpleado { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal DiasIncapacidad { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TipoIncapacidad { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Descuento { get; set; }

    }
}
