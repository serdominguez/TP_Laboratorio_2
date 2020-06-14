using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

        /// <summary>
        /// Inicializa una nueva instancia de la clase Universidad
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        public List<Alumno> Alumnos {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public List<Profesor> Instructores { 
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        public List<Jornada> Jornadas { 
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        public Jornada this[int i] {
            get { return jornada[i]; } 
            set { jornada[i] = value;  }
        }

        /// <summary>
        /// Compara un objeto Universidad con un objeto Alumno
        /// </summary>
        /// <param name="g">Objeto Universidad</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>TRUE si el objeto Alumno pertenece a la lista alumnos del objeto Universidad</returns>
        public static bool operator == (Universidad g, Alumno a)
        {
            bool rta = false;

            foreach (Alumno item in g.alumnos)
            {
                if (a == item)
                {
                    rta = true;
                    break;
                }
            }
            return rta;
        }

        /// <summary>
        /// Compara un objeto Universidad con un objeto Alumno
        /// </summary>
        /// <param name="g">Objeto Universidad</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>FALSE si el objeto Alumno pertenece a la lista alumnos del objeto Universidad</returns>
        public static bool operator != (Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Compara un objeto Universidad con un objeto Profesor
        /// </summary>
        /// <param name="g">Objeto Universidad</param>
        /// <param name="i">Objeto Profesor</param>
        /// <returns>TRUE si el objeto AluProfesormno pertenece a la lista alumnos del objeto Universidad</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool rta = false;

            foreach (Profesor item in g.profesores)
            {
                if (i == item)
                {
                    rta = true;
                    break;
                }
            }
            return rta;
        }


        /// <summary>
        /// Compara un objeto Universidad con un objeto Profesor
        /// </summary>
        /// <param name="g">Objeto Universidad</param>
        /// <param name="i">Objeto Profesor</param>
        /// <returns>TRUE si el objeto AluProfesormno pertenece a la lista alumnos del objeto Universidad</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Compara un objeto Universidad con un Enum EClase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Devuelve el primer objeto Profesor de la lista profesores con la EClase clase
        /// en su atributo clasesDelDia, si no hay Proofesor lanza SinProfesorException </returns>
        public static Profesor operator == (Universidad u, EClases clase)
        {
            Profesor prof = null;

            foreach (Profesor item in u.profesores)
            {
                if (item == clase)
                {
                    prof = item;
                    break;
                } 
            }
            if (prof is null)
            {
                
                throw new SinProfesorException("No hay profesor para la clase");
                
            }
            return prof;
        }

        /// <summary>
        /// Compara un objeto Universidad con un Enum EClase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Devuelve el primer objeto Profesor de la lista profesores que no tenga el EClase clase
        /// en su atributo clasesDelDia, si no hay Proofesor lanza SinProfesorException</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor prof = null;

            foreach (Jornada item in u.jornada)
            {
                if (item.Clase != clase)
                {
                    prof = item.Instructor;
                    break;
                }

            }
            if (prof is null)
            {

                throw new SinProfesorException("Todos los profesores pueden dar la clase");

            }
            return prof;
        }

        /// <summary>
        /// Agrega un objeto Alumno a la lista alumnos del objeto Universidad
        /// </summary>
        /// <param name="u">Objeto Universidad</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>Devuelve el objeto Universidad con el Alumno agregado a la lista si no esta repetido</returns>
        public static Universidad operator + (Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            } else
            {
                throw new AlumnoRepetidoException("Alumno Repetido");
            }
            return u;
        }

        /// <summary>
        /// Agrega un objeto Profesor a la lista alumnos del objeto Universidad
        /// </summary>
        /// <param name="u">Objeto Universidad</param>
        /// <param name="i">Objeto Alumno</param>
        /// <returns>Devuelve el objeto Universidad con el Profesor agregado a la lista si no esta repetido</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }

            return u;
        }

        /// <summary>
        /// Genera un nuevo objeto Jornada en la lista jornadas del objeto Universidad con la EClase provista, 
        /// su atributo instructor sera un objeto Profesor de la lista y los objetos Alumnos seran los que tengan
        /// esa EClase en la lista alumnos del objeto Universidad
        /// </summary>
        /// <param name="g">Objeto Universidad</param>
        /// <param name="clase">Eclase clase</param>
        /// <returns>Devuelve el objeto Universidad con un nuevo objeto Jornada en su lista conteniendo la EClase provista</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor prof = (g == clase);
            Jornada jor = new Jornada(clase, prof);

            foreach (Alumno item in g.alumnos)
            {
                 
                jor = jor + item;
                
            }

            g.jornada.Add(jor);
            return g;
        }

        /// <summary>
        /// Retorna un string con los atributos de los objetos de la lista jornadas
        /// </summary>
        /// <param name="uni">Objeto Universidad</param>
        /// <returns>String </returns>
        private string MostrarDatos (Universidad uni)
        {
            StringBuilder st = new StringBuilder();

            foreach (Jornada item in uni.jornada)
            {
                st.AppendLine(item.ToString());
            }

            return st.ToString();
        }

        /// <summary>
        /// Retorna un string con los atributos de los objetos de la lista jornadas
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Serializa en formato XML los atributos del objeto universidad
        /// </summary>
        /// <param name="uni">Objeto Universidad</param>
        /// <returns>TRUE si pudo serializar el objeto</returns>
        public static bool Guardar(Universidad uni)
        {
            bool ok;

            Xml<Universidad> temp = new Xml<Universidad>();
            ok = temp.Guardar("Universidad.xml", uni);

            return ok;
        }

        /// <summary>
        /// Lee archivo XML y lo graba en un objeto Universidad
        /// </summary>
        /// <returns>Objeto Universidad</returns>
        public static Universidad Leer ()
        {
            Xml<Universidad> temp = new Xml<Universidad>();
            Universidad uTemp;
            try
            {
                temp.Leer("Universidad.xml", out uTemp);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e.InnerException);
            }
            return uTemp;
        }
        
    }
}
