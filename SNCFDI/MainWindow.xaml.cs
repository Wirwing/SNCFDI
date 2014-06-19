using Microsoft.Win32;
using NLog;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SNCFDI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box 
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".xlsx"; // Default file extension 
            dlg.Filter = "Excel (.xlsx)|*.xlsx"; // Filter files by extension 

            // Show open file dialog box 
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result.HasValue && result.Value)
            {
                List<string> lines = getData(dlg.FileName);

                foreach (string line in lines)
                {
                    logger.Info(line);
                }

            }

        }

        private List<string> getData(string fileName)
        {

            FileStream stream = new FileStream(fileName, FileMode.Open);
            IWorkbook workBook = WorkbookFactory.Create(stream);

            stream.Close();

            ISheet sheet = workBook.GetSheetAt(0);

            IEnumerator rowEnumator = sheet.GetRowEnumerator();
            IEnumerator cellEnumator;

            List<string> lines = new List<string>();
            IRow currentRow;
            ICell currentCell;
            StringBuilder builder = new StringBuilder();

            while (rowEnumator.MoveNext())
            {

                currentRow = rowEnumator.Current as IRow;

                //todo: validate row's cell count
                int cellSize = currentRow.Cells.Count;
                cellEnumator = currentRow.Cells.GetEnumerator();

                builder.Clear();

                //Extract worker data
                while (cellEnumator.MoveNext())
                {

                    currentCell = cellEnumator.Current as ICell;

                    switch (currentCell.CellType)
                    {
                        case CellType.String:
                            builder.Append(currentCell.StringCellValue).Append(' ');
                            break;
                        case CellType.Numeric:
                            builder.Append(currentCell.NumericCellValue.ToString()).Append(' ');
                            break;
                        default:
                            break;
                    }

                }

                lines.Add(builder.ToString());

            }

            return lines;

        }

    }
}
