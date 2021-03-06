﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNCFDI.Service.Util
{
    class NominaValue
    {

        public const int NUM_EMPLEADO = 0;
        public const int CURP = 1;
        public const int TIPO_REGIMEN = 2;
        public const int FECHA_PAGO = 3;
        public const int FECHA_INICIAL_PAGO = 4;
        public const int FECHA_FINAL_PAGO = 5;
        public const int NUM_DIAS_PAGADOS = 6;
        public const int PERIODICIDAD_PAGO = 7;
        public const int REGISTRO_PATRONAL = 8;
        public const int NUM_SEGURIDAD_SOCIAL = 9;
        public const int DEPARTAMENTO = 10;
        public const int CLABE = 11;

        public const int BANCO = 12;
        public const int FECHA_INICIO_LABORAL = 13;
        public const int ANTIGUEDAD = 14;
        public const int PUESTO = 15;
        public const int TIPO_CONTRATO = 16;
        public const int TIPO_JORNADA = 17;
        public const int SALARIO_BASE = 18;
        public const int RIESGO_PUESTO = 19;
        public const int SALARIO_DIARIO_INTEGRADO = 20;

    }

    class PercepcionValue
    {

        public const int NUM_EMPLEADO = 0;
        public const int TIPO_PERCEPCION = 1;
        public const int CLAVE = 2;
        public const int CONCEPTO = 3;
        public const int IMPORTE_AGRAVADO = 4;
        public const int IMPORTE_EXENTO = 5;

    }

    class DeduccionValue
    {

        public const int NUM_EMPLEADO = 0;
        public const int TIPO_DEDUCCION = 1;
        public const int CLAVE = 2;
        public const int CONCEPTO = 3;
        public const int IMPORTE_AGRAVADO = 4;
        public const int IMPORTE_EXENTO = 5;

    }

    class HoraExtraValue
    {

        public const int NUM_EMPLEADO = 0;
        public const int DIAS = 1;
        public const int TIPO_HORAS = 2;
        public const int HORAS_EXTRA = 3;
        public const int IMPORTE_PAGADO = 4;

    }

    class IncapacidadValue
    {
        public const int NUM_EMPLEADO = 0;
        public const int DIAS_INCAPACIDAD = 1;
        public const int TIPO_INCAPACIDAD = 2;
        public const int DESCUENTO = 3;

    }


}
