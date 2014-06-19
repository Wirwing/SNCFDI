using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Diagnostics;
using System.Xml.Schema;

namespace Tests
{
    [TestClass]
    public class CfdfiSchemeValidationTests
    {

        //[TestMethod]
        public void validateCfdi()
        {
            XmlDocument document = new XmlDocument();
            document.Load("Fixtures/cfdi_nomina.xml");

            //Debug.Write(document.OuterXml);

            XmlSchemaSet schemaSet = new XmlSchemaSet();
            XmlSchema schema;

            ////Read in the schema document
            using (XmlReader schemaReader = XmlReader.Create("Fixtures/cfdv32.xsd"))
            {

                schema = XmlSchema.Read(schemaReader, new ValidationHandler().Log);
                schemaSet.Add(schema);

            }

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
        public void validateComplementoNominaNode()
        {

            XmlDocument document = new XmlDocument();
            document.Load("Fixtures/nomina_node.xml");

            //Debug.Write(document.OuterXml);

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
       
    }
}
