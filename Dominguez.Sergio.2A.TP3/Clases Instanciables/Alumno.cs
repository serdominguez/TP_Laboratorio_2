using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    
    
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta { AlDia, Deudor, Becado }
        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Inicializa una nueva instancia de la clase Alumno
        /// </summary>
        public Alumno() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="id">int ID</param>
        /// <param name="nombre">string Nombre</param>
        /// <param name="apellido">string Apellido</param>
        /// <param name="dni">string DNI</param>
        /// <param name="nacionalidad">Enacionalidad nacionalidad</param>
        /// <param name="claseQueToma">EClase clase que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base (id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="id">int ID</param>
        /// <param name="nombre">string Nombre</param>
        /// <param name="apellido">string Apellido</param>
        /// <param name="dni">string DNI</param>
        /// <param name="nacionalidad">Enacionalidad nacionalidad</param>
        /// <param name="claseQueToma">EClase clase que toma el alumno</param>
        /// <param name="estadoCuenta">EEstadoCuenta estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, 
            EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
           
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Retorna un string con los atributos del objeto con un formato fijo
        /// </summary>
        /// <returns>string</returns>
        protected override string MostrarDatos()
        {
            StringBuilder st = new StringBuilder();

            st.AppendLine(base.MostrarDatos());
            st.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta);
            st.AppendLine(ParticiparEnClase());
            
            return st.ToString();
        }

        /// <summary>
        /// Muestra el atributo privado clasesQueToma
        /// </summary>
        /// <returns>string</returns>
        protected override string ParticiparEnClase()
        {
            return ("TOMA CLASES DE: " + this.claseQueToma);
        }

        /// <summary>
        /// Retorna los atributos del obejeto como un string con un formato fijo
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {

            return this.MostrarDatos();
        }

        /// <summary>
        /// Compara objeto Alumno con Eclase
        /// </summary>
        /// <param name="a">Alumno a</param>
        /// <param name="clase">Eclase clase</param>
        /// <returns>TRUE si el atributo estadoCuenta no es deudor y el atributo claseQueToma es clase</returns>
        public static bool operator == (Alumno a, Universidad.EClases clase)
        {
            bool res = false;

            if (a.estadoCuenta != EEstadoCuenta.Deudor && a.claseQueToma == clase)
            {
                res = true;
            }

            return res;
        }

        /// <summary>
        /// Compara objeto Alumno con Eclase
        /// </summary>
        /// <param name="a">Alumno a</param>
        /// <param name="clase">Eclase clase</param>
        /// <returns>TRUE si el atributo claseQueToma es distinto a clase</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool res = false;

            if (a.claseQueToma != clase)
            {
                res = true;
            }

            return res;
        }

    }
}
