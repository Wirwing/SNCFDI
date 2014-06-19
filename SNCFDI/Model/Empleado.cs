using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNCFDI.Model
{
    public class Empleado
    {
        
        public const int MINIMUM_EMPLOYEE_DATA_ROWS = 2;

        private int numero;
        private Nomina nomina;
        private Boolean validData;
        private String parsingError;
        private List<Percepcion> percepcionesList;

        public Empleado()
        {
            this.validData = false;
            this.percepcionesList = new List<Percepcion>();
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
            set {  nomina = value; }
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

    }
}
