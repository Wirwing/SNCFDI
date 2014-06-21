using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SNCFDI.Model;
using SNCFDI.Service;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Schema;


namespace Tests.Service
{
    [TestClass]
    public class EmployeeValidationTests
    {

        private XmlSchemaSet schemaSet;

        [TestInitialize]
        public void LoadData()
        {
            schemaSet = new XmlSchemaSet();
            XmlSchema schema = SchemaValidatorReader.Read(FixtureLocation.NominaSchemaFile);
            schemaSet.Add(schema);
        }

        [TestMethod]
        public void TestEmployeeValidation()
        {

            ExcelReader reader = new ExcelReader(FixtureLocation.SingleEmployeeFile);

            List<Empleado> validos;
            List<Empleado> invalidos;

            reader.ParseEmpleados(out validos, out invalidos);

            reader.ParsePercepciones(validos);
            reader.ParseDeducciones(validos);
            reader.ParseIncapacidades(validos);
            reader.ParseHorasExtras(validos);

            Assert.AreEqual(1, validos.Count);

            Empleado empleado = validos[0];

            Assert.AreEqual(true, empleado.ValidData);

            empleado.GenerateNomina();
            empleado.SerializeXml(schemaSet);

            empleado.ParsingError.ForEach(error => Debug.Write(error));

            Assert.AreEqual(true, empleado.ValidData);

            Debug.Write(empleado.XML.OuterXml);

        }


        [TestMethod]
        public void TestEmployeeMissingRequiredDataValidation()
        {

            ExcelReader reader = new ExcelReader(FixtureLocation.MissingEmployeeDataFile);

            List<Empleado> validos;
            List<Empleado> invalidos;

            reader.ParseEmpleados(out validos, out invalidos);

            reader.ParsePercepciones(validos);
            reader.ParseDeducciones(validos);
            reader.ParseIncapacidades(validos);
            reader.ParseHorasExtras(validos);

            Assert.AreEqual(1, validos.Count);

            Empleado empleado = validos[0];

            Assert.AreEqual(true, empleado.ValidData);

            empleado.GenerateNomina();
            empleado.SerializeXml(schemaSet);

            empleado.ParsingError.ForEach(error => Debug.Write(error));

            Assert.AreEqual(false, empleado.ValidData);

        }

        [TestMethod]
        public void TestEmployeesValidation()
        {

            ExcelReader reader = new ExcelReader(FixtureLocation.MultipleEmployeesFile);

            List<Empleado> validos;
            List<Empleado> invalidos;

            reader.ParseEmpleados(out validos, out invalidos);

            reader.ParsePercepciones(validos);
            reader.ParseDeducciones(validos);
            reader.ParseIncapacidades(validos);
            reader.ParseHorasExtras(validos);

            Assert.AreEqual(2, validos.Count);
                      

            validos.ForEach(empleado =>
            {

                Assert.AreEqual(true, empleado.ValidData);

                empleado.GenerateNomina();
                empleado.SerializeXml(schemaSet);

                empleado.ParsingError.ForEach(error => Debug.Write(error));
                Assert.AreEqual(true, empleado.ValidData);
                //Debug.Write(empleado.XML.OuterXml);

            });

        }

    }
}
