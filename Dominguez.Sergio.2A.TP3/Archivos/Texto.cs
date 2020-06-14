using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda el dato en un archivo TXT
        /// </summary>
        /// <param name="archivo">Path para guardar el archivo</param>
        /// <param name="dato">Informacion que se guardara</param>
        /// <returns>True si lo pudo grabar</returns>
        public bool Guardar(string archivo, string dato)
        {
            bool ok = true;
            
            try {
                using (StreamWriter F = new StreamWriter(archivo, false)) { 

                    F.WriteLine(dato);
           
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
        /// Lee archivo TXT y lo guarda en la variable
        /// </summary>
        /// <param name="archivo">Path del archivo a leer</param>
        /// <param name="datos">Variable donde se guardara</param>
        /// <returns>True si pudo leer el archivo y guardar la variable</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool ok = true;
            try {
                using (StreamReader F = new StreamReader(archivo)) { 
                    datos = F.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                
                ok = false;
                throw new ArchivosException(e);
            }
            return ok;
        }
    }
}
