using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace SNCFDI.Service
{
    public class SchemaValidatorReader
    {

        public static XmlSchema Read(String fileName)
        {
            XmlSchema schema;

            //Read in the schema document
            using (XmlReader schemaReader = XmlReader.Create(fileName))
            {

                schema = XmlSchema.Read(schemaReader, delegate(object sender, ValidationEventArgs e)
                {
                    throw new SchemaReadingException();
                });

            }

            return schema;

        }

    }

    public class SchemaReadingException : Exception
    {
        public SchemaReadingException()
        {
        }

        public SchemaReadingException(string message)
            : base(message)
        {
        }

        public SchemaReadingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
