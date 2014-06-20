using NPOI.SS.UserModel;
using SNCFDI.Model;
using SNCFDI.Service.Util;
using System;

namespace SNCFDI.Service
{
    public interface EntityParser<T>
    {

        T Parse(IRow row);

    }

    class EmployeeParser : EntityParser<Empleado>
    {

        public Empleado Parse(IRow row)
        {

            Empleado empleado = new Empleado();
            Nomina nomina = new Nomina();

            String stringValue;
            int? intValue;
            decimal? decimalValue;
            Nullable<DateTime> dateValue;

            ICell cell = row.GetCell(NominaValue.NUM_EMPLEADO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue)
            {
                nomina.NumEmpleado = intValue.Value.ToString("000");
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
            stringValue = CellDataParser.AsString(cell);
            if (stringValue != null) nomina.CURP = stringValue;

            cell = row.GetCell(NominaValue.TIPO_REGIMEN, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue) nomina.TipoRegimen = intValue.Value;

            cell = row.GetCell(NominaValue.FECHA_PAGO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            dateValue = CellDataParser.AsDateTime(cell);
            if (dateValue.HasValue) nomina.FechaPago = dateValue.Value;

            cell = row.GetCell(NominaValue.FECHA_INICIAL_PAGO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            dateValue = CellDataParser.AsDateTime(cell);
            if (dateValue.HasValue) nomina.FechaInicialPago = dateValue.Value;

            cell = row.GetCell(NominaValue.FECHA_FINAL_PAGO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            dateValue = CellDataParser.AsDateTime(cell);
            if (dateValue.HasValue) nomina.FechaFinalPago = dateValue.Value;

            cell = row.GetCell(NominaValue.NUM_DIAS_PAGADOS, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue) nomina.NumDiasPagados = intValue.Value;

            cell = row.GetCell(NominaValue.PERIODICIDAD_PAGO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellDataParser.AsString(cell);
            if (stringValue != null) nomina.PeriodicidadPago = stringValue;

            //Campos opcionales
            cell = row.GetCell(NominaValue.REGISTRO_PATRONAL, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellDataParser.AsString(cell);
            if (stringValue != null) nomina.RegistroPatronal = stringValue;

            cell = row.GetCell(NominaValue.NUM_SEGURIDAD_SOCIAL, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            decimalValue = CellDataParser.AsDecimal(cell);
            if (decimalValue.HasValue) nomina.NumSeguridadSocial = decimalValue.Value.ToString();
            
            cell = row.GetCell(NominaValue.DEPARTAMENTO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellDataParser.AsString(cell);
            if (stringValue != null) nomina.Departamento = stringValue;

            cell = row.GetCell(NominaValue.CLABE, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellDataParser.AsString(cell);
            if (stringValue != null) nomina.CLABE = stringValue;

            cell = row.GetCell(NominaValue.BANCO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue) nomina.Banco = intValue.Value.ToString("000");
            
            cell = row.GetCell(NominaValue.FECHA_INICIO_LABORAL, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            dateValue = CellDataParser.AsDateTime(cell);
            if (dateValue.HasValue) nomina.FechaInicioRelLaboral = dateValue.Value;

            cell = row.GetCell(NominaValue.ANTIGUEDAD, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue) nomina.Antiguedad = intValue.Value;

            cell = row.GetCell(NominaValue.PUESTO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellDataParser.AsString(cell);
            if (stringValue != null) nomina.Puesto = stringValue;

            cell = row.GetCell(NominaValue.TIPO_CONTRATO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellDataParser.AsString(cell);
            if (stringValue != null) nomina.TipoContrato = stringValue;

            cell = row.GetCell(NominaValue.TIPO_JORNADA, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellDataParser.AsString(cell);
            if (stringValue != null) nomina.TipoJornada = stringValue;

            cell = row.GetCell(NominaValue.SALARIO_BASE, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            decimalValue = CellDataParser.AsDecimal(cell);
            if (decimalValue.HasValue) nomina.SalarioBaseCotApor = decimalValue.Value;

            cell = row.GetCell(NominaValue.RIESGO_PUESTO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue) nomina.RiesgoPuesto = intValue.Value;

            cell = row.GetCell(NominaValue.SALARIO_DIARIO_INTEGRADO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            decimalValue = CellDataParser.AsDecimal(cell);
            if (decimalValue.HasValue) nomina.SalarioDiarioIntegrado = decimalValue.Value;

            empleado.Nomina = nomina;

            return empleado;

        }

    }

    class PercepcionParser : EntityParser<Percepcion>
    {
        public Percepcion Parse(IRow row)
        {
            Percepcion percepcion = new Percepcion();

            String stringValue;
            int? intValue;
            decimal? decimalValue;

            ICell cell = row.GetCell(PercepcionValue.NUM_EMPLEADO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue) percepcion.NumEmpleado = intValue.Value;

            cell = row.GetCell(PercepcionValue.TIPO_PERCEPCION, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue) percepcion.TipoPercepcion = intValue.Value.ToString("000");

            cell = row.GetCell(PercepcionValue.CLAVE, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellDataParser.AsString(cell);
            if (stringValue != null) percepcion.Clave = stringValue;

            cell = row.GetCell(PercepcionValue.CONCEPTO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellDataParser.AsString(cell);
            if (stringValue != null) percepcion.Concepto = stringValue;

            cell = row.GetCell(PercepcionValue.IMPORTE_AGRAVADO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            decimalValue = CellDataParser.AsDecimal(cell);
            if (decimalValue.HasValue) percepcion.ImporteGravado = decimalValue.Value;

            cell = row.GetCell(PercepcionValue.IMPORTE_EXENTO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            decimalValue = CellDataParser.AsDecimal(cell);
            if (decimalValue.HasValue) percepcion.ImporteExento = decimalValue.Value;

            return percepcion;

        }


    }

    class DeduccionParser : EntityParser<Deduccion>
    {
        public Deduccion Parse(IRow row)
        {
            Deduccion deduccion = new Deduccion();

            String stringValue;
            int? intValue;
            decimal? decimalValue;

            ICell cell = row.GetCell(DeduccionValue.NUM_EMPLEADO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue) deduccion.NumEmpleado = intValue.Value;

            cell = row.GetCell(DeduccionValue.TIPO_DEDUCCION, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue) deduccion.TipoDeduccion = intValue.Value.ToString("000");
            
            cell = row.GetCell(DeduccionValue.CLAVE, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellDataParser.AsString(cell);
            if (stringValue != null) deduccion.Clave = stringValue;

            cell = row.GetCell(DeduccionValue.CONCEPTO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            stringValue = CellDataParser.AsString(cell);
            if (stringValue != null) deduccion.Concepto = stringValue;

            cell = row.GetCell(DeduccionValue.IMPORTE_AGRAVADO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            decimalValue = CellDataParser.AsDecimal(cell);
            if (decimalValue.HasValue) deduccion.ImporteGravado = decimalValue.Value;

            cell = row.GetCell(DeduccionValue.IMPORTE_EXENTO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            decimalValue = CellDataParser.AsDecimal(cell);
            if (decimalValue.HasValue) deduccion.ImporteExento = decimalValue.Value;

            return deduccion;

        }


    }

    class IncapacidadParser : EntityParser<Incapacidad>
    {
        public Incapacidad Parse(IRow row)
        {
            Incapacidad incapacidad = new Incapacidad();

            int? intValue;
            decimal? decimalValue;

            ICell cell = row.GetCell(IncapacidadValue.NUM_EMPLEADO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue) incapacidad.NumEmpleado = intValue.Value;

            cell = row.GetCell(IncapacidadValue.DIAS_INCAPACIDAD, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue) incapacidad.DiasIncapacidad = intValue.Value;

            cell = row.GetCell(IncapacidadValue.TIPO_INCAPACIDAD, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue) incapacidad.TipoIncapacidad = intValue.Value;

            cell = row.GetCell(IncapacidadValue.DESCUENTO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            decimalValue = CellDataParser.AsDecimal(cell);
            if (decimalValue.HasValue) incapacidad.Descuento = decimalValue.Value;

            return incapacidad;

        }


    }

    class HorasExtraParser : EntityParser<NominaHorasExtra>
    {
        public NominaHorasExtra Parse(IRow row)
        {
            NominaHorasExtra horaExtra = new NominaHorasExtra();

            int? intValue;
            decimal? decimalValue;
            Nullable<TipoHorasExtra> tipoExtra;

            ICell cell = row.GetCell(HoraExtraValue.NUM_EMPLEADO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue) horaExtra.NumEmpleado = intValue.Value;

            cell = row.GetCell(HoraExtraValue.DIAS, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue) horaExtra.Dias = intValue.Value;

            cell = row.GetCell(HoraExtraValue.TIPO_HORAS, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            tipoExtra = CellDataParser.AsTipoHoraExtra(cell);
            if (tipoExtra.HasValue) horaExtra.TipoHoras = tipoExtra.Value;

            cell = row.GetCell(HoraExtraValue.HORAS_EXTRA, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            intValue = CellDataParser.AsInteger(cell);
            if (intValue.HasValue) horaExtra.HorasExtra = intValue.Value;
            
            cell = row.GetCell(HoraExtraValue.IMPORTE_PAGADO, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            decimalValue = CellDataParser.AsDecimal(cell);
            if (decimalValue.HasValue) horaExtra.ImportePagado = decimalValue.Value;

            return horaExtra;

        }

    }


}
