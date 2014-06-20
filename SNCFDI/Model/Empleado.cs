using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNCFDI.Model
{
    public class Empleado
    {

        public const int MINIMUM_EMPLOYEE_DATA_ROWS = 1;

        private int numero;
        private Nomina nomina;
        private Boolean validData;
        private String parsingError;
        private List<Percepcion> percepcionesList;
        private List<Deduccion> deduccionesList;
        private List<Incapacidad> incapacidadesList;
        private List<NominaHorasExtra> horasExtraList;

        public Empleado()
        {
            this.validData = false;
            this.percepcionesList = new List<Percepcion>();
            this.deduccionesList = new List<Deduccion>();
            this.incapacidadesList = new List<Incapacidad>();
            this.horasExtraList = new List<NominaHorasExtra>();

        }

        public String ParsingError
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
    }
}
