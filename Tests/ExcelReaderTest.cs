using Microsoft.VisualStudio.TestTools.UnitTesting;
using SNCFDI.Model;
using SNCFDI.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class ExcelReaderTest
    {
        private const String filename = "Fixtures/Excel/Empleado.xlsx";

        [TestMethod]
        public void TestEmpleadoParse()
        {

            ExcelReader reader = new ExcelReader(filename);

            List<Empleado> validos;
            List<Empleado> invalidos;

            reader.ParseEmpleados(out validos, out invalidos);

            Assert.AreEqual(1, validos.Count);

            Empleado empleado = validos[0];

            Assert.AreEqual(1, empleado.Numero);
            Nomina nomina = empleado.Nomina;

            Assert.AreEqual("001", nomina.NumEmpleado);
            Assert.AreEqual("JUAN680116MAZBCÑ90", nomina.CURP);
            Assert.AreEqual(1, nomina.TipoRegimen);
            Assert.AreEqual(new DateTime(2014, 05, 15), nomina.FechaPago);
            Assert.AreEqual(new DateTime(2014, 05, 01), nomina.FechaInicialPago);
            Assert.AreEqual(new DateTime(2014, 05, 15), nomina.FechaFinalPago);
            Assert.AreEqual(new Decimal(12), nomina.NumDiasPagados);
            Assert.AreEqual("QUINCENAL", nomina.PeriodicidadPago);
            Assert.AreEqual("N4515588991", nomina.RegistroPatronal);
            Assert.AreEqual("13099903896", nomina.NumSeguridadSocial);
            Assert.AreEqual("ADMINISTRACION", nomina.Departamento);
            Assert.AreEqual("230230302302302309", nomina.CLABE);
            Assert.AreEqual("123", nomina.Banco);
            Assert.AreEqual(new DateTime(2014, 03, 15), nomina.FechaInicioRelLaboral);
            Assert.AreEqual(8, nomina.Antiguedad);
            Assert.AreEqual("Programador", nomina.Puesto);
            Assert.AreEqual("Base", nomina.TipoContrato);
            Assert.AreEqual("Mixta", nomina.TipoJornada);
            Assert.AreEqual(new Decimal(200.1), nomina.SalarioBaseCotApor);
            Assert.AreEqual(0, nomina.RiesgoPuesto);
            Assert.AreEqual(new Decimal(209.04), nomina.SalarioDiarioIntegrado);


        }

        [TestMethod]
        public void TestPercepcionParse()
        {

            ExcelReader reader = new ExcelReader(filename);

            List<Empleado> validos;
            List<Empleado> invalidos;

            reader.ParseEmpleados(out validos, out invalidos);
            reader.ParsePercepciones(validos);

            Assert.AreEqual(1, validos.Count);

            Empleado empleado = validos[0];

            Assert.AreEqual(1, empleado.ParsedPercepciones.Count);

            Percepcion percepcion = empleado.ParsedPercepciones[0];

            Assert.AreEqual("001", percepcion.TipoPercepcion);
            Assert.AreEqual("100", percepcion.Clave);
            Assert.AreEqual("Sueldo", percepcion.Concepto);
            Assert.AreEqual(new Decimal(1300.50), percepcion.ImporteGravado);
            Assert.AreEqual(new Decimal(0.04), percepcion.ImporteExento);


        }


        [TestMethod]
        public void TestDeduccionParse()
        {

            ExcelReader reader = new ExcelReader(filename);

            List<Empleado> validos;
            List<Empleado> invalidos;

            reader.ParseEmpleados(out validos, out invalidos);
            reader.ParseDeducciones(validos);

            Assert.AreEqual(1, validos.Count);

            Empleado empleado = validos[0];

            Assert.AreEqual(1, empleado.ParsedDeducciones.Count);

            Deduccion deduccion = empleado.ParsedDeducciones[0];

            Assert.AreEqual("002", deduccion.TipoDeduccion);
            Assert.AreEqual("050", deduccion.Clave);
            Assert.AreEqual("Falta injustificada", deduccion.Concepto);
            Assert.AreEqual(new Decimal(416.55), deduccion.ImporteGravado);
            Assert.AreEqual(new Decimal(0.00), deduccion.ImporteExento);


        }

        [TestMethod]
        public void TestIncapacidadParse()
        {

            ExcelReader reader = new ExcelReader(filename);

            List<Empleado> validos;
            List<Empleado> invalidos;

            reader.ParseEmpleados(out validos, out invalidos);
            reader.ParseIncapacidades(validos);

            Assert.AreEqual(1, validos.Count);

            Empleado empleado = validos[0];

            Assert.AreEqual(1, empleado.ParsedIncapacidades.Count);

            Incapacidad incapacidad = empleado.ParsedIncapacidades[0];

            Assert.AreEqual(2, incapacidad.DiasIncapacidad);
            Assert.AreEqual(3, incapacidad.TipoIncapacidad);
            Assert.AreEqual(new Decimal(833.33), incapacidad.Descuento);

        }


        [TestMethod]
        public void TestHorasExtraParse()
        {

            ExcelReader reader = new ExcelReader(filename);

            List<Empleado> validos;
            List<Empleado> invalidos;

            reader.ParseEmpleados(out validos, out invalidos);
            reader.ParseHorasExtras(validos);

            Assert.AreEqual(1, validos.Count);

            Empleado empleado = validos[0];

            Assert.AreEqual(1, empleado.ParsedHorasExtra.Count);

            NominaHorasExtra horaExtra = empleado.ParsedHorasExtra[0];

            Assert.AreEqual(2, horaExtra.Dias);
            Assert.AreEqual(TipoHorasExtra.Dobles, horaExtra.TipoHoras);
            Assert.AreEqual(6, horaExtra.HorasExtra);
            Assert.AreEqual(new Decimal(625.31), horaExtra.ImportePagado);


        }


    }
}
