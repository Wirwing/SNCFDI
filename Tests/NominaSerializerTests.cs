using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using SNCFDI.Model;
using SNCFDI.Service;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.Diagnostics;
using System.Xml.Schema;


namespace Tests
{
    [TestClass]
    public class NominaSerializerTests
    {

        [TestMethod]
        public void TestNominaNodeSerializationAndValidation()
        {

            Nomina nomina = new Nomina();

            nomina.RegistroPatronal = "123456789ABCDEFGDTU";
            nomina.NumEmpleado = "43437";
            nomina.CURP = "XXXX850505HDFLNS09";
            nomina.TipoRegimen = 1;
            nomina.FechaPago = DateTime.Now;
            nomina.FechaInicialPago = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 16);
            nomina.FechaFinalPago = nomina.FechaInicialPago.AddDays(14);
            nomina.NumDiasPagados = 7;
            nomina.Departamento = "Sistemas";
            nomina.CLABE = "123456789123456789";
            nomina.Banco = 1;
            nomina.FechaInicioRelLaboral = new DateTime(2011, 10, 01);
            nomina.Antiguedad = 10;
            nomina.Puesto = "Lider de proyecto";
            nomina.TipoContrato = "Base";
            nomina.TipoJornada = "mixta";
            nomina.PeriodicidadPago = "Semanal";
            nomina.SalarioBaseCotApor = new Decimal(100.0);
            nomina.RiesgoPuesto = 1;
            nomina.SalarioDiarioIntegrado = new Decimal(261.3);

            //Percepciones

            Percepciones percepcionData = new Percepciones();

            percepcionData.TotalExento = new Decimal(0.3);
            percepcionData.TotalGravado = new Decimal(1750.0);

            Percepcion percepcion = new Percepcion();
            percepcion.TipoPercepcion = 1.ToString("000");
            percepcion.Clave = "100";
            percepcion.Concepto = "Sueldo";
            percepcion.ImporteGravado = new Decimal(1300);
            percepcion.ImporteExento = new decimal(0.0);

            List<Percepcion> percepciones = new List<Percepcion>();
            percepciones.Add(percepcion);

            percepcionData.Percepcion = percepciones.ToArray();

            nomina.Percepciones = percepcionData;

            //String fileName = "output.xml";

            //using (Stream stream = File.Open(fileName, FileMode.Create))
            //{

            //    XmlSerializer serializer = new XmlSerializer(typeof(Nomina));
            //    serializer.Serialize(stream, nomina);
            //    stream.Flush();
            //}

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("nomina", "http://www.sat.gob.mx/nomina");

            XmlDocument document = new XmlDocument();

            using (Stream stream = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Nomina));
                serializer.Serialize(stream, nomina, ns);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                document.Load(stream);
            }

            XmlSchemaSet schemaSet = new XmlSchemaSet();
            XmlSchema schema;

            //Read in the schema document
            using (XmlReader schemaReader = XmlReader.Create("Fixtures/nomina11.xsd"))
            {

                schema = XmlSchema.Read(schemaReader, new ValidationHandler().Log);
                schemaSet.Add(schema);

            }

            document.Schemas = schemaSet;

            bool error = false;

            document.Validate(new ValidationEventHandler(
                delegate(Object sender, ValidationEventArgs e)
                {
                    Debug.WriteLine("Validation Error: {0}", e.Message);
                    error = true;
                }
            ));

            Assert.AreEqual(false, error, "Problemas en la validación");


        }

        //[TestMethod]
        public void TestSerialization()
        {

            // Create a new instance of the test class
            TestClass TestObj = new TestClass();

            // Set some dummy values
            TestObj.SomeString = "foo";

            XmlDocument document = new XmlDocument();

            using (Stream stream = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TestClass));
                serializer.Serialize(stream, TestObj);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                document.Load(stream);
            }

            Debug.Write(document.OuterXml);


            XmlSchemaSet schemaSet = new XmlSchemaSet();
            XmlSchema schema;

            //Read in the schema document
            using (XmlReader schemaReader = XmlReader.Create("schema.xsd"))
            {

                schema = XmlSchema.Read(schemaReader, new ValidationHandler().Log);
                schemaSet.Add(schema);

            }

            document.Schemas = schemaSet;

            bool error = false;

            document.Validate(new ValidationEventHandler(
                delegate(Object sender, ValidationEventArgs e)
                {
                    Debug.WriteLine("Validation Error: {0}", e.Message);
                    error = true;
                }
            ));

            Assert.AreEqual(false, error, "Problemas en al validación");

        }

        //[TestMethod]
        public void TestSchemaReading()
        {
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            XmlSchema schema;

            //Read in the schema document
            using (XmlReader schemaReader = XmlReader.Create("schema.xsd"))
            {
                
                schema = XmlSchema.Read(schemaReader, new ValidationHandler().Log);
                schemaSet.Add(schema);

            }

            Debug.Write(schema.ToString());

        }

    }

    // This is the test class we want to 
    // serialize:
    [Serializable()]
    public class TestClass
    {
        private string someString;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SomeString
        {
            get { return someString; }
            set { someString = value; }
        }

        // These will be ignored
        [NonSerialized()]
        private int willBeIgnored1 = 1;
        private int willBeIgnored2 = 1;

    }


}
