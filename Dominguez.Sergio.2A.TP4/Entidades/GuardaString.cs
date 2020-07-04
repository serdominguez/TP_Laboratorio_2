using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo de estension para String, guarda en el escritorio el contenido del string, si existe, agrega informacion
        /// </summary>
        /// <param name="texto">string a guardar</param>
        /// <param name="archivo">nombre del archivo que se guardara</param>
        /// <returns>true si se genero el archivo, false si no</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool rta = false;

            string escritorio = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            archivo = escritorio + @"\" + archivo;

            if (!File.Exists(archivo))
            {

                try
                {
                    using (StreamWriter F = new StreamWriter(archivo, false))
                    {

                        F.WriteLine(texto);

                    }
                }
                catch (Exception e)
                {
                    rta = false;
                    throw e;

                }

            } else
            {
                try
                {
                    using (StreamWriter F = new StreamWriter(archivo, true))
                    {

                        F.WriteLine(texto);

                    }
                }
                catch (Exception e)
                {
                    rta = false;
                    throw e;

                }
            }

            return rta;
        }
    }
}
