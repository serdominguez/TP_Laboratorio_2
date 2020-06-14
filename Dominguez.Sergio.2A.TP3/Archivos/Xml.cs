using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml <T> : IArchivo<T>
    {
        
        /// <summary>
        /// Serializa el objeto en un archivo XML
        /// </summary>
        /// <param name="archivo">Path para guardar el archivo</param>
        /// <param name="datos">Objeto que se va a guardar</param>
        /// <returns>True si pudo guardar el archivo</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool ok = true;
            try 
            { 
                using (XmlTextWriter writer = new XmlTextWriter(archivo, System.Text.Encoding.UTF8)  )
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    ser.Serialize(writer, datos);
                }

            }
            catch (Exception e)
            {
                ok = false;
                throw new ArchivosException(e);
            }

            return ok;
     
        }

        /// <summary>
        /// Lee datos de un archivo XML y los guarda en un objeto
        /// </summary>
        /// <param name="archivo">Path donde se leera el archivo</param>
        /// <param name="datos">objeto de salida</param>
        /// <returns>true si pudo leer el archivo</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool ok = true;
            datos = default(T);
            try
            {
                using (XmlTextReader read = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    datos = (T)ser.Deserialize(read);
                    ok = true;
                }

            }
            catch (Exception e)
            {
                ok = false;
                Console.WriteLine(e.Message);
            }
            
            return ok;
        }
    }
}
