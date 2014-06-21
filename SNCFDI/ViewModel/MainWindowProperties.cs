using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNCFDI.ViewModel
{
    public class MainWindowProperties : INotifyPropertyChanged
    {

        // Declare the event 
        public event PropertyChangedEventHandler PropertyChanged;

        private int schemasCount;
        private Boolean canLoadData;
        private string currentFile;

        public string CurrentFile
        {
            get { return currentFile; }
            set { 
                currentFile = value;
                OnPropertyChanged("CurrentFile");
            }
        }


        public MainWindowProperties()
        {
            schemasCount = 0;
            canLoadData = false;
            currentFile = "";
        }


        public int SchemasCount
        {
            get { return schemasCount; }
            set
            {
                schemasCount = value;
                OnPropertyChanged("SchemasCount");
            }
        }

        public Boolean CanLoadData
        {
            get { return canLoadData; }
            set
            {
                canLoadData = value;
                OnPropertyChanged("CanLoadData");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
