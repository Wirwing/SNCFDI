using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNCFDI.Model
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina")]
    public partial class Incapacidad
    {

        private decimal diasIncapacidadField;

        private int tipoIncapacidadField;

        private decimal descuentoField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal DiasIncapacidad
        {
            get
            {
                return this.diasIncapacidadField;
            }
            set
            {
                this.diasIncapacidadField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TipoIncapacidad
        {
            get
            {
                return this.tipoIncapacidadField;
            }
            set
            {
                this.tipoIncapacidadField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Descuento
        {
            get
            {
                return this.descuentoField;
            }
            set
            {
                this.descuentoField = value;
            }
        }
    }
}
