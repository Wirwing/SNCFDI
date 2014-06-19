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
    public partial class NominaHorasExtra
    {

        private int diasField;

        private NominaHorasExtraTipoHoras tipoHorasField;

        private int horasExtraField;

        private decimal importePagadoField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Dias
        {
            get
            {
                return this.diasField;
            }
            set
            {
                this.diasField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public NominaHorasExtraTipoHoras TipoHoras
        {
            get
            {
                return this.tipoHorasField;
            }
            set
            {
                this.tipoHorasField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int HorasExtra
        {
            get
            {
                return this.horasExtraField;
            }
            set
            {
                this.horasExtraField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImportePagado
        {
            get
            {
                return this.importePagadoField;
            }
            set
            {
                this.importePagadoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina")]
    public enum NominaHorasExtraTipoHoras
    {

        /// <comentarios/>
        Dobles,

        /// <comentarios/>
        Triples,
    }

}
