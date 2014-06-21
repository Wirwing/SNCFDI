using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SNCFDI.Model
{
    public class Empleado
    {

        public const int MINIMUM_EMPLOYEE_DATA_ROWS = 1;

        private int numero;
        private Nomina nomina;
        private Boolean validData;
        private List<string> parsingError;
        private List<Percepcion> percepcionesList;
        private List<Deduccion> deduccionesList;
        private List<Incapacidad> incapacidadesList;
        private List<NominaHorasExtra> horasExtraList;
        private XmlDocument document;

        public Empleado()
        {
            this.validData = false;
            this.percepcionesList = new List<Percepcion>();
            this.deduccionesList = new List<Deduccion>();
            this.incapacidadesList = new List<Incapacidad>();
            this.horasExtraList = new List<NominaHorasExtra>();
            parsingError = new List<string>();

        }

        #region properties

        public XmlDocument XML
        {
            get { return document; }
            set { document = value; }
        }

        public List<string> ParsingError
        {
            get { return parsingError; }
            set { parsingError = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public Nomina Nomina
        {
            get { return nomina; }
            set { nomina = value; }
        }

        public Boolean ValidData
        {
            get { return validData; }
            set { validData = value; }
        }

        public List<Percepcion> ParsedPercepciones
        {
            get { return percepcionesList; }
            set { percepcionesList = value; }
        }

        public List<Deduccion> ParsedDeducciones
        {
            get { return deduccionesList; }
            set { deduccionesList = value; }
        }

        public List<Incapacidad> ParsedIncapacidades
        {
            get { return incapacidadesList; }
            set { incapacidadesList = value; }
        }

        public List<NominaHorasExtra> ParsedHorasExtra
        {
            get { return horasExtraList; }
            set { horasExtraList = value; }
        }

        #endregion

        public void GenerateNomina()
        {

            if (percepcionesList.Count > 0)
            {

                decimal totalExento = 0;
                decimal totalGravado = 0;

                bool exentoNull = false;
                bool gravadoNull = false;

                percepcionesList.ForEach(percepcion =>
                {

                    if (percepcion.ImporteExento.HasValue)
                        totalExento += percepcion.ImporteExento.Value;
                    else
                    {
                        exentoNull = true;
                        return;
                    }

                    if (percepcion.ImporteGravado.HasValue)
                        totalGravado += percepcion.ImporteGravado.Value;
                    else
                    {
                        gravadoNull = true;
                        return;
                    }

                });

                if (!exentoNull && !gravadoNull)
                {
                    Percepciones percepciones = new Percepciones();
                    percepciones.Percepcion = percepcionesList.ToArray();
                    nomina.Percepciones = percepciones;
                }

            }

            if (deduccionesList.Count > 0)
            {

                decimal totalExento = 0;
                decimal totalGravado = 0;

                bool exentoNull = false;
                bool gravadoNull = false;

                deduccionesList.ForEach(deduccion =>
                {

                    if (deduccion.ImporteExento.HasValue)
                        totalExento += deduccion.ImporteExento.Value;
                    else
                    {
                        exentoNull = true;
                        return;
                    }

                    if (deduccion.ImporteGravado.HasValue)
                        totalGravado += deduccion.ImporteGravado.Value;
                    else
                    {
                        gravadoNull = true;
                        return;
                    }

                });

                if (!exentoNull && !gravadoNull)
                {
                    Deducciones deducciones = new Deducciones();
                    deducciones.Deduccion = deduccionesList.ToArray();
                    nomina.Deducciones = deducciones;
                }

            }

            if (incapacidadesList.Count > 0)
                nomina.Incapacidades = incapacidadesList.ToArray();

            if (horasExtraList.Count > 0)
                nomina.HorasExtras = horasExtraList.ToArray();

        }

        public void SerializeXml(XmlSchemaSet schemaSet)
        {

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("nomina", "http://www.sat.gob.mx/nomina");

            this.document = new XmlDocument();

            try
            {
                using (Stream stream = new MemoryStream())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Nomina));
                    serializer.Serialize(stream, nomina, ns);
                    stream.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    document.Load(stream);
                }
            }
            catch (Exception)
            {
                validData = false;
                parsingError.Add("Problema al transformar este empleado a XML");
            }

            document.Schemas = schemaSet;

            document.Validate(new ValidationEventHandler(
                (sender, e) =>
                {
                    parsingError.Add(e.Message);
                    validData = false;
                }
            ));


        }
    }
}
