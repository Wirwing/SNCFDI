using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using SNCFDI.Exceptions;
using SNCFDI.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNCFDI.Service
{
    public class ExcelReader
    {

        private const int EmployeeSheet = 0;
        private const int PercepcionesSheet = 1;
        private const int DeduccionesSheet = 2;
        private const int IncapacidadesSheet = 3;
        private const int HorasExtraSheet = 4;

        private IWorkbook workBook;
        private EntityParser<Empleado> empleadoParser;
        private EntityParser<Percepcion> percepcionParser;
        private EntityParser<Deduccion> deduccionParser;
        private EntityParser<Incapacidad> incapacidadParser;
        private EntityParser<NominaHorasExtra> horasExtraParser;

        public ExcelReader(String fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open);
            workBook = WorkbookFactory.Create(stream);

            stream.Close();

            empleadoParser = new EmployeeParser();
            percepcionParser = new PercepcionParser();
            deduccionParser = new DeduccionParser();
            incapacidadParser = new IncapacidadParser();
            horasExtraParser = new HorasExtraParser();

        }

        public void readFile()
        {
            List<Empleado> valid;
            List<Empleado> invalid;

            ParseEmpleados(out valid, out invalid);
            ParsePercepciones(valid);
            ParseDeducciones(valid);
            ParseIncapacidades(valid);
            ParseHorasExtras(valid);

        }

        public void ParseEmpleados(out List<Empleado> valid, out List<Empleado> invalid)
        {

            valid = new List<Empleado>();
            invalid = new List<Empleado>();

            Empleado empleado;
            IRow currentRow;
            ISheet sheet = workBook.GetSheetAt(ExcelReader.EmployeeSheet);

            int rowCount = sheet.LastRowNum;

            if (rowCount < Empleado.MINIMUM_EMPLOYEE_DATA_ROWS)
            {
                throw new EmptyEmployeeDataException();
            }

            IEnumerator rowEnumator = sheet.GetRowEnumerator();

            //Ignore headers
            rowEnumator.MoveNext();

            while (rowEnumator.MoveNext())
            {

                currentRow = rowEnumator.Current as IRow;
                empleado = empleadoParser.Parse(currentRow);

                if (empleado.ValidData)
                    valid.Add(empleado);
                else
                    invalid.Add(empleado);

            }

        }

        public void ParsePercepciones(List<Empleado> employees)
        {

            Percepcion percepcion;
            IRow currentRow;
            ISheet sheet = workBook.GetSheetAt(ExcelReader.PercepcionesSheet);

            IEnumerator rowEnumator = sheet.GetRowEnumerator();

            //Ignore headers
            rowEnumator.MoveNext();

            Empleado employee;

            while (rowEnumator.MoveNext())
            {

                currentRow = rowEnumator.Current as IRow;
                percepcion = percepcionParser.Parse(currentRow);

                if (percepcion.NumEmpleado.HasValue)
                {
                    employee = employees.SingleOrDefault(emp => emp.Numero == percepcion.NumEmpleado.Value);
                    if (employee != null)
                        employee.ParsedPercepciones.Add(percepcion);
                }

            }

        }

        public void ParseDeducciones(List<Empleado> employees)
        {
            Deduccion deduccion;
            IRow currentRow;
            ISheet sheet = workBook.GetSheetAt(ExcelReader.DeduccionesSheet);

            IEnumerator rowEnumator = sheet.GetRowEnumerator();

            //Ignore headers
            rowEnumator.MoveNext();

            Empleado employee;

            while (rowEnumator.MoveNext())
            {

                currentRow = rowEnumator.Current as IRow;
                deduccion = deduccionParser.Parse(currentRow);

                if (deduccion.NumEmpleado.HasValue)
                {
                    employee = employees.SingleOrDefault(emp => emp.Numero == deduccion.NumEmpleado.Value);
                    if (employee != null)
                        employee.ParsedDeducciones.Add(deduccion);
                }

            }
        }

        public void ParseIncapacidades(List<Empleado> employees)
        {
            Incapacidad incapacidad;
            IRow currentRow;
            ISheet sheet = workBook.GetSheetAt(ExcelReader.IncapacidadesSheet);

            IEnumerator rowEnumator = sheet.GetRowEnumerator();

            //Ignore headers
            rowEnumator.MoveNext();

            Empleado employee;

            while (rowEnumator.MoveNext())
            {

                currentRow = rowEnumator.Current as IRow;
                incapacidad = incapacidadParser.Parse(currentRow);

                if (incapacidad.NumEmpleado.HasValue)
                {
                    employee = employees.SingleOrDefault(emp => emp.Numero == incapacidad.NumEmpleado.Value);
                    if (employee != null)
                        employee.ParsedIncapacidades.Add(incapacidad);
                }

            }
        }

        public void ParseHorasExtras(List<Empleado> employees)
        {
            NominaHorasExtra horaExtra;
            IRow currentRow;
            ISheet sheet = workBook.GetSheetAt(ExcelReader.HorasExtraSheet);

            IEnumerator rowEnumator = sheet.GetRowEnumerator();

            //Ignore headers
            rowEnumator.MoveNext();

            Empleado employee;

            while (rowEnumator.MoveNext())
            {

                currentRow = rowEnumator.Current as IRow;
                horaExtra = horasExtraParser.Parse(currentRow);

                if (horaExtra.NumEmpleado.HasValue)
                {
                    employee = employees.SingleOrDefault(emp => emp.Numero == horaExtra.NumEmpleado.Value);
                    if (employee != null)
                        employee.ParsedHorasExtra.Add(horaExtra);
                }

            }
        }


    }
}
