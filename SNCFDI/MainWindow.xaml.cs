using Microsoft.Win32;
using NLog;
using SNCFDI.Model;
using SNCFDI.Service;
using SNCFDI.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using System.Xml.Schema;

namespace SNCFDI
{
    public partial class MainWindow : Window
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ObservableCollection<Empleado> empleados;
        private XmlSchemaSet schemaSet;

        private MainWindowProperties properties;

        public MainWindowProperties Properties
        {
            get { return properties; }
            set { properties = value; }
        }

        public ObservableCollection<Empleado> Empleados
        {
            get { return empleados; }
            set { empleados = value; }
        }

        public MainWindow()
        {

            properties = new MainWindowProperties();
            schemaSet = new XmlSchemaSet();
            empleados = new ObservableCollection<Empleado>();
            
            InitializeComponent();

        }

        private void Load_Schema_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".xsd";
            dlg.Filter = "XML Schema Definition (.xsd )|*.xsd";

            bool? result = dlg.ShowDialog();

            if (result.HasValue && result.Value)
            {
                XmlSchema schema = SchemaValidatorReader.Read(dlg.FileName);
                if (!schemaSet.Contains(schema))
                {
                    schemaSet.Add(schema);
                    Properties.CanLoadData = true;
                    logger.Info("Schema added to set");
                    Properties.SchemasCount = schemaSet.Count;
                }
            }

        }

        private void Load_DataSource_Click(object sender, RoutedEventArgs e)
        {

            // Configure open file dialog box 
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".xlsx"; // Default file extension 
            dlg.Filter = "Excel (.xlsx)|*.xlsx"; // Filter files by extension 

            // Show open file dialog box 
            bool? result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result.HasValue && result.Value)
            {

                ExcelReader reader = new ExcelReader(dlg.FileName);

                List<Empleado> empleadosValid;
                List<Empleado> empleadosInvalid;

                reader.ParseEmpleados(out empleadosValid, out empleadosInvalid);

                empleados.Clear();
                empleadosValid.ForEach(empl => {
                    empl.GenerateNomina();
                    empl.SerializeXml(schemaSet);
                    empleados.Add(empl);
                });

                properties.CurrentFile = dlg.FileName;

            }

        }

    }
}
