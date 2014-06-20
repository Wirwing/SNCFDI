using Microsoft.Win32;
using NLog;
using SNCFDI.Model;
using SNCFDI.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;

namespace SNCFDI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ObservableCollection<Empleado> empleados;

        public ObservableCollection<Empleado> Empleados
        {
            get { return empleados; }
            set { empleados = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            empleados = new ObservableCollection<Empleado>();

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

                ExcelReader reader = new ExcelReader(dlg.FileName);

                List<Empleado> empleadosValid;
                List<Empleado> empleadosInvalid;

                reader.ParseEmpleados(out empleadosValid, out empleadosInvalid);

            }

        }

    }
}
