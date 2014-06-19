using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Tests
{
    class ValidationHandler
    {

        public void Log(object sender, ValidationEventArgs e)
        {
            Debug.WriteLine("Validation Error: {0}", e.Message);
        }

    }
}
