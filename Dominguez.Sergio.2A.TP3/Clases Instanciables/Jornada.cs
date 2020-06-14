using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        /// <summary>
        /// Inicializa una nueva instancia de la clase Jornada
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Jornada
        /// </summary>
        /// <param name="clase">EClase clase</param>
        /// <param name="instructor">Profesor instructor</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
           
            this.clase = clase;
            this.instructor = instructor;

        }

        public List<Alumno> Alumnos 
        {
            get 
            {
                return this.alumnos;
            } 
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Compara objeto Jornada con objeto Alumno
        /// </summary>
        /// <param name="j">Objeto Jornada</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>TRUE si el atributo claseQueToma de Alumno es igual al eclase de la Jornada</returns>
        public static bool operator == (Jornada j, Alumno a)
        {
            bool rta = false;
            
            if (a == j.clase)
            {
            rta = true;
            }
            
            return rta;
        }

        /// <summary>
        /// Compara objeto Jornada con objeto Alumno
        /// </summary>
        /// <param name="j">Objeto Jornada</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>FALSE si el atributo claseQueToma de Alumno es igual al eclase de la Jornada</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega objeto Alumno a la lista alumnos del objeto Jornada
        /// </summary>
        /// <param name="j">Objeto Jornada</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool flag = false;
            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                {
                    flag = true;
                }

            }
            if (flag == false && a == j.Clase)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Devuelve los atributos del obejeto como un string con un formato fijo
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            StringBuilder st = new StringBuilder();

            st.AppendLine("JORNADA: ");
            st.AppendFormat("CLASE DE {0} POR {1}\n\n", this.clase.ToString(), this.instructor.ToString());

            st.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
            {
                st.AppendLine(item.ToString());
            }
            st.AppendLine("<-------------------------------------------->");

            return st.ToString();
        }

        /// <summary>
        /// Guarda en un archivo TXT los atributos del obejeto como un string con un formato fijo
        /// </summary>
        /// <param name="jornada">Jornada jornada a guardar</param>
        /// <returns>TRUE si pudo guardar el archivo</returns>
        public static bool Guardar (Jornada jornada)
        {
            bool rta = false;
            Texto temp = new Texto();

            temp.Guardar("Jornada.txt", jornada.ToString() );

            return rta;
        }

        /// <summary>
        /// Lee un archivo TXT y lo devuelve como string
        /// </summary>
        /// <returns>String</returns>
        public static string Leer ()
        {
            string res;
            Texto temp = new Texto();

            temp.Leer("Jornada.txt", out res);

            return res;
        }
    }
}

