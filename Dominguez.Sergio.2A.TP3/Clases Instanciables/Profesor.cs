using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        Queue<Universidad.EClases> claseDelDia;
        static Random random;


        /// <summary>
        /// Inicializa los atributos estaticos de la clase Profesor
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Profesor
        /// </summary>
        public Profesor()
        {
            claseDelDia = new Queue<Universidad.EClases>();

            _randomClases();
            _randomClases();

        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Profesor
        /// </summary>
        /// <param name="id">INT ID</param>
        /// <param name="nombre">String Nombre</param>
        /// <param name="apellido">String Apellido</param>
        /// <param name="dni">String DNI</param>
        /// <param name="nacionalidad">Enacionalidad Nacionalidad</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base (id, nombre, apellido, dni, nacionalidad)
        {
            Profesor temp = new Profesor();
            this.claseDelDia = temp.claseDelDia;

        }
        /// <summary>
        /// Asigna una Eclase aleatoria a la lista claseDelDia
        /// </summary>
        private void _randomClases()
        {
            this.claseDelDia.Enqueue((Universidad.EClases)Enum.Parse(typeof(Universidad.EClases), random.Next(0, 4).ToString()));
        }

        /// <summary>
        /// Retorna un string con los atributos del objeto con un formato fijo
        /// </summary>
        /// <returns>string </returns>
        protected override string MostrarDatos()
        {
            StringBuilder st = new StringBuilder();

            st.AppendLine(base.MostrarDatos());
            st.Append(this.ParticiparEnClase());

            return st.ToString(); 
        }

        /// <summary>
        /// Retorna un string con los datos de la lista clasesDelDia
        /// </summary>
        /// <returns>String</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder st = new StringBuilder();
            st.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases item in claseDelDia)
            {
                st.AppendLine(item.ToString());
            }

            return st.ToString();  
        }

        /// <summary>
        /// Retorna los atributos del obejeto como un string con un formato fijo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Compara objeto profesor con un enum Eclase
        /// </summary>
        /// <param name="i">Objeto Profesor</param>
        /// <param name="clase">Eclase clase</param>
        /// <returns>TRUE si la clase pertenece a la lista claseDelDia del objeto Profesor</returns>
        public static bool operator == (Profesor i, Universidad.EClases clase)
        {
            bool rta = false;

            foreach (Universidad.EClases item in i.claseDelDia)
            {
                if (item == clase)
                {
                    rta = true;
                    break;
                }
            }

            return rta;
        }

        /// <summary>
        /// Compara objeto profesor con un enum Eclase
        /// </summary>
        /// <param name="i">Objeto Profesor</param>
        /// <param name="clase">Eclase clase</param>
        /// <returns>FALSE si la clase pertenece a la lista claseDelDia del objeto Profesor</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

    }
}
