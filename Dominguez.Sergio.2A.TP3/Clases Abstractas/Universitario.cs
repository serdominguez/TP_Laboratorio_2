using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    
    public abstract class Universitario : Persona
    {
        int legajo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase Universitario
        /// </summary>
        public Universitario() : base()
        {
            this.legajo = -1;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Universitario
        /// </summary>
        /// <param name="legajo">int legajo</param>
        /// <param name="nombre">string Nombre</param>
        /// <param name="apellido">string Apellido</param>
        /// <param name="dni">string DNI</param>
        /// <param name="nacionalidad">ENacionalidad nacionalidad</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base (nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Muestra los datos de la clase como string
        /// </summary>
        /// <returns>string</returns>
        protected virtual string MostrarDatos ()
        {
            StringBuilder st = new StringBuilder();

            st.Append(base.ToString());
            st.AppendFormat("LEGAJO NÚMERO: {0}", this.legajo);

            return st.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Sobrecarga operador, compara dos objetos de clase universitario por su tipo, legajo y DNI
        /// </summary>
        /// <param name="pg1">Objeto tipo universitario a compara</param>
        /// <param name="pg2">Objeto tipo universitario a compara</param>
        /// <returns>TRUE si son iguales, FALSE si no</returns>
        public static bool operator == (Universitario pg1, Universitario pg2)
        {
            bool res = false;

            if (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
            {
                res = true;
            }

            return res;
        }

        /// <summary>
        /// Sobrecarga operador, compara dos objetos de clase universitario por su tipo, legajo y DNI
        /// </summary>
        /// <param name="pg1">Objeto tipo universitario a compara</param>
        /// <param name="pg2">Objeto tipo universitario a compara</param>
        /// <returns>TRUE si son distintos, FALSE si no</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public override bool Equals(object obj)
        {
            bool res = false;

            if (obj is Universitario)
            {
                if ((Universitario)obj == this)
                {
                    res = true;
                }
            }

            return res;
        }

    }
}
