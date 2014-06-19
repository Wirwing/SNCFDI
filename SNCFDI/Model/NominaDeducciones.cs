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
    public partial class Deducciones
    {

        private NominaDeduccionesDeduccion[] deduccionField;

        private decimal totalGravadoField;

        private decimal totalExentoField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("Deduccion")]
        public NominaDeduccionesDeduccion[] Deduccion
        {
            get
            {
                return this.deduccionField;
            }
            set
            {
                this.deduccionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalGravado
        {
            get
            {
                return this.totalGravadoField;
            }
            set
            {
                this.totalGravadoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalExento
        {
            get
            {
                return this.totalExentoField;
            }
            set
            {
                this.totalExentoField = value;
            }
        }
    }


    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina")]
    public partial class NominaDeduccionesDeduccion
    {

        private int tipoDeduccionField;

        private string claveField;

        private string conceptoField;

        private decimal importeGravadoField;

        private decimal importeExentoField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TipoDeduccion
        {
            get
            {
                return this.tipoDeduccionField;
            }
            set
            {
                this.tipoDeduccionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Clave
        {
            get
            {
                return this.claveField;
            }
            set
            {
                this.claveField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Concepto
        {
            get
            {
                return this.conceptoField;
            }
            set
            {
                this.conceptoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImporteGravado
        {
            get
            {
                return this.importeGravadoField;
            }
            set
            {
                this.importeGravadoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImporteExento
        {
            get
            {
                return this.importeExentoField;
            }
            set
            {
                this.importeExentoField = value;
            }
        }
    }

}
