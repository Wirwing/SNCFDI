using NPOI.SS.UserModel;
using SNCFDI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNCFDI.Service
{
    class CellDataParser
    {

        public static String AsString(ICell cell)
        {
            String value = null;

            if (cell != null && cell.CellType.CompareTo(CellType.String) == 0)
            {
                value = cell.StringCellValue;
            }

            return value;

        }

        public static Nullable<DateTime> AsDateTime(ICell cell)
        {
            Nullable<DateTime> value = null;

            if (cell != null)
            {
                value = cell.DateCellValue;
            }

            return value;

        }


        public static int? AsInteger(ICell cell)
        {
            int? value = null;

            if (cell != null && cell.CellType.CompareTo(CellType.Numeric) == 0)
            {
                value = (int)cell.NumericCellValue;
            }

            return value;

        }

        public static double? AsNumeric(ICell cell)
        {
            double? value = null;

            if (cell != null && cell.CellType.CompareTo(CellType.Numeric) == 0)
            {
                value = cell.NumericCellValue;
            }

            return value;

        }

        public static decimal? AsDecimal(ICell cell)
        {
            decimal? value = null;

            if (cell != null && cell.CellType.CompareTo(CellType.Numeric) == 0)
            {
                value = Convert.ToDecimal(cell.NumericCellValue);
            }

            return value;

        }

        public static Nullable<TipoHorasExtra> AsTipoHoraExtra(ICell cell)
        {
            Nullable<TipoHorasExtra> value = null;

            try
            {
                if (cell != null && cell.CellType.CompareTo(CellType.String) == 0)
                    value = (TipoHorasExtra)Enum.Parse(typeof(TipoHorasExtra), cell.StringCellValue);
            }
            catch (Exception) { }

            return value;

        }


    }
}
