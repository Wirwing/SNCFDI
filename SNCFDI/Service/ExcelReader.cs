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

        private IWorkbook workBook;

        public void readFile(String fileName)
        {


            FileStream stream = new FileStream(fileName, FileMode.Open);
            workBook = WorkbookFactory.Create(stream);

            stream.Close();


        }

        private void ParseEmpleados(out List<Empleado> valid, out List<Empleado> invalid)
        {

            valid = new List<Empleado>();
            invalid = new List<Empleado>();

            Empleado empleado;
            IRow currentRow;
            ISheet sheet = workBook.GetSheetAt(0);

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
                empleado = this.ParseEmpleado(currentRow);

                if (empleado.ValidData)
                    valid.Add(empleado);
                else
                    invalid.Add(empleado);


            }

        }

        private void ParsePercepciones(List<Empleado> employees)
        {

            Percepcion percepcion;
            IRow currentRow;
            ISheet sheet = workBook.GetSheetAt(1);

            IEnumerator rowEnumator = sheet.GetRowEnumerator();

            //Ignore headers
            rowEnumator.MoveNext();

            int? numEmpleado;

            Empleado employee;

            while (rowEnumator.MoveNext())
            {

                currentRow = rowEnumator.Current as IRow;
                percepcion = this.ParsePercepcion(currentRow, numEmpleado);

                if (numEmpleado.HasValue)
                {
                    employee = employees.SingleOrDefault(emp => emp.Numero == numEmpleado.Value);
                    if (employee != null) 
                        employee.ParsedPercepciones.Add(percepcion);
                }

            }

        }

        private Empleado ParseEmpleado(IRow row)
        {

            Empleado empleado = new Empleado();
            Nomina nomina = new Nomina();

            String stringValue;
            int? intValue;
            decimal? decimalValue;
            Nullable<DateTime> dateValue;

            ICell cell = row.GetCell(NominaValue.NUM_EMPLEADO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellParser.AsInteger(cell);
            if (intValue.HasValue)
            {
                nomina.NumEmpleado = intValue.Value.ToString();
                empleado.Numero = intValue.Value;
                empleado.ValidData = true;
            }
            else
            {
                empleado.ValidData = false;
                empleado.ParsingError = "Empleado en la fila " + row.RowNum.ToString() + " no cuenta con dato NumEmpleado";
                return empleado;
            }

            cell = row.GetCell(NominaValue.CURP, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellParser.AsString(cell);
            if (stringValue != null) nomina.CURP = stringValue;

            cell = row.GetCell(NominaValue.TIPO_REGIMEN, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellParser.AsInteger(cell);
            if (intValue.HasValue) nomina.TipoRegimen = intValue.Value;

            cell = row.GetCell(NominaValue.FECHA_PAGO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            dateValue = CellParser.AsDateTime(cell);
            if (dateValue.HasValue) nomina.FechaPago = dateValue.Value;

            cell = row.GetCell(NominaValue.FECHA_INICIAL_PAGO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            dateValue = CellParser.AsDateTime(cell);
            if (dateValue.HasValue) nomina.FechaInicialPago = dateValue.Value;

            cell = row.GetCell(NominaValue.FECHA_FINAL_PAGO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            dateValue = CellParser.AsDateTime(cell);
            if (dateValue.HasValue) nomina.FechaFinalPago = dateValue.Value;

            cell = row.GetCell(NominaValue.NUM_DIAS_PAGADOS, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellParser.AsInteger(cell);
            if (intValue.HasValue) nomina.NumDiasPagados = intValue.Value;

            cell = row.GetCell(NominaValue.PERIODICIDAD_PAGO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellParser.AsString(cell);
            if (stringValue != null) nomina.PeriodicidadPago = stringValue;

            //Campos opcionales
            cell = row.GetCell(NominaValue.REGISTRO_PATRONAL, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellParser.AsString(cell);
            if (stringValue != null) nomina.RegistroPatronal = stringValue;

            cell = row.GetCell(NominaValue.NUM_SEGURIDAD_SOCIAL, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellParser.AsString(cell);
            if (stringValue != null) nomina.NumSeguridadSocial = stringValue;

            cell = row.GetCell(NominaValue.DEPARTAMENTO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellParser.AsString(cell);
            if (stringValue != null) nomina.Departamento = stringValue;

            cell = row.GetCell(NominaValue.CLABE, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellParser.AsString(cell);
            if (stringValue != null) nomina.CLABE = stringValue;

            cell = row.GetCell(NominaValue.BANCO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellParser.AsInteger(cell);
            if (intValue.HasValue) nomina.Banco = intValue.Value;

            cell = row.GetCell(NominaValue.FECHA_INICIO_LABORAL, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            dateValue = CellParser.AsDateTime(cell);
            if (dateValue.HasValue) nomina.FechaInicioRelLaboral = dateValue.Value;

            cell = row.GetCell(NominaValue.ANTIGUEDAD, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellParser.AsInteger(cell);
            if (intValue.HasValue) nomina.Antiguedad = intValue.Value;

            cell = row.GetCell(NominaValue.PUESTO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellParser.AsString(cell);
            if (stringValue != null) nomina.Puesto = stringValue;

            cell = row.GetCell(NominaValue.TIPO_CONTRATO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellParser.AsString(cell);
            if (stringValue != null) nomina.TipoContrato = stringValue;

            cell = row.GetCell(NominaValue.TIPO_JORNADA, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellParser.AsString(cell);
            if (stringValue != null) nomina.TipoJornada = stringValue;

            cell = row.GetCell(NominaValue.SALARIO_BASE, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            decimalValue = CellParser.AsDecimal(cell);
            if (decimalValue.HasValue) nomina.SalarioBaseCotApor = decimalValue.Value;

            cell = row.GetCell(NominaValue.RIESGO_PUESTO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellParser.AsInteger(cell);
            if (intValue.HasValue) nomina.RiesgoPuesto = intValue.Value;

            cell = row.GetCell(NominaValue.SALARIO_DIARIO_INTEGRADO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellParser.AsInteger(cell);
            if (intValue.HasValue) nomina.SalarioDiarioIntegrado = intValue.Value;

            empleado.Nomina = nomina;

            return empleado;

        }

        private Percepcion ParsePercepcion(IRow row, out int? numeroEmpleado)
        {

            numeroEmpleado = null;
            Percepcion percepcion = new Percepcion();

            String stringValue;
            int? intValue;
            decimal? decimalValue;
            Nullable<DateTime> dateValue;

            ICell cell = row.GetCell(PercepcionValue.NUM_EMPLEADO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellParser.AsInteger(cell);
            if (intValue.HasValue)
            {
                numeroEmpleado = intValue.Value;
            }

            cell = row.GetCell(PercepcionValue.TIPO_PERCEPCION, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellParser.AsString(cell);
            if (stringValue != null) percepcion.TipoPercepcion = stringValue;

            cell = row.GetCell(PercepcionValue.CLAVE, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellParser.AsString(cell);
            if (stringValue != null) percepcion.Clave = stringValue;

            cell = row.GetCell(PercepcionValue.CONCEPTO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellParser.AsString(cell);
            if (stringValue != null) percepcion.Concepto = stringValue;

            cell = row.GetCell(PercepcionValue.IMPORTE_AGRAVADO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            decimalValue = CellParser.AsDecimal(cell);
            if (decimalValue.HasValue) percepcion.ImporteGravado = decimalValue.Value;

            cell = row.GetCell(PercepcionValue.IMPORTE_EXENTO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            decimalValue = CellParser.AsDecimal(cell);
            if (decimalValue.HasValue) percepcion.ImporteExento = decimalValue.Value;

            return percepcion;

        }

    }
}
