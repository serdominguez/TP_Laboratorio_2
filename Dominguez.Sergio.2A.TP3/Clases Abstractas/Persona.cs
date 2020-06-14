using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    [XmlInclude(typeof(Universitario))]


    public abstract class Persona
    {
        
        public enum ENacionalidad { Argentino, Extranjero }
        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        string nombre;

        /// <summary>
        /// Inicializa una nueva instancia de la clase Persona
        /// </summary>
        public Persona()
        {
            this.apellido = "";
            this.dni = -1;
            this.nacionalidad = ENacionalidad.Argentino;
            this.nombre = "";
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = ValidarNombreApellido(nombre);
            this.apellido = ValidarNombreApellido(apellido);
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Persona
        /// </summary>
        /// <param name="nombre">Nombre en formato string</param>
        /// <param name="apellido">Apellido  en formato string</param>
        /// <param name="dni">DNI en formato INT</param>
        /// <param name="nacionalidad">Enum ENacionalidad</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this (nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Persona
        /// </summary>
        /// <param name="nombre">Nombre en formato string</param>
        /// <param name="apellido">Apellido  en formato string</param>
        /// <param name="dni">DNI en formato string</param>
        /// <param name="nacionalidad">Enum ENacionalidad</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Get: devuelve DNI
        /// Set: Valida coherencia de nacionalidad y DNI y si este ultimo tiene formato correcto
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
               

                    int dato = ValidarDni(this.nacionalidad, value);
                    if (dato > 0)
                    {
                        this.dni = value;
                    } 

            }
        }

        /// <summary>
        /// Set: Recibe un DNI como string, convierte a numero, valida y carga
        /// </summary>
        public string StringToDNI { 
            set 
            {
                int dato = ValidarDni(this.nacionalidad, value);
                this.dni = dato;

            } 
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Valida que el DNI sea coherente con la nacionalidad y tenga el formato correco
        /// </summary>
        /// <param name="nacionalidad">Enum ENacionalidad</param>
        /// <param name="dato">Numero de DNI como int</param>
        /// <returns>DNI como int, -1 si excede el rango, -2 si no corresponde a la nacionalidad</returns>
        int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int res;

            if (nacionalidad == ENacionalidad.Argentino &&
                dato > 1 && dato < 89999999)
            {
                res = dato;
            }else if (this.nacionalidad == ENacionalidad.Extranjero &&
                dato > 90000000 && dato <= 99999999)
            {
                res = dato;
            } 
            else if (dato > 100000000 || dato < 1)
            {
                
                throw new DniInvalidoException("Dni con formato erroneo");
            } else
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                
            }
            return res;
        }

        /// <summary>
        /// Valida que el DNI sea coherente con la nacionalidad y tenga el formato correco
        /// </summary>
        /// <param name="nacionalidad">Enum ENacionalidad</param>
        /// <param name="dato">Numero de DNI como string</param>
        /// <returns>DNI como int, -1 si el formato es incorrecto</returns>
        int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int datoint;
            int res;
            bool ok;

            ok = Int32.TryParse(dato, out datoint);

            if (ok) { 
                res = ValidarDni(nacionalidad, datoint);
            } else
            {
                throw new DniInvalidoException("Dni con formato erroneo");
 
            }
            return res;
        }

        /// <summary>
        /// Valida que el dato ingresado no contenga caracteres invalidos
        /// </summary>
        /// <param name="dato">nombre/apellido como string</param>
        /// <returns>dato como string si es correcto, cadena vacia si no</returns>
        string ValidarNombreApellido(string dato)
        {
            bool ok = true;

            for (int i = 0; i < dato.Length; i++)
            {
                if (char.IsLetter(dato, i) == false)
                {
                    ok = false;
                    break;
                }
            }
            if (ok == false)
            {
                dato = "";
            }

            return dato;
            
        }

        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>String con nombnre, apellido y nacionalidad</returns>
        public override string ToString()
        {
            StringBuilder st = new StringBuilder();

            st.AppendFormat("NOMBRE COMPLETO: {0}, {1}\nNACIONALIDAD: {2}\n", this.apellido, this.nombre, this.nacionalidad);


            return st.ToString();
        }

    }

}