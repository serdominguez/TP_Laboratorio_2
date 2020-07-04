using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        /// <summary>
        /// Constructor por defecto, inicializa las listas
        /// </summary>
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Lista de objetos Paquete
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        /// <summary>
        /// Devuelve string con los datos de los objetos Paquete de la lista
        /// </summary>
        /// <param name="elemento">interfase del tipo IMostrar</param>
        /// <returns></returns>
        string IMostrar<List<Paquete>>.MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < ((Correo)elemento).paquetes.Count; i++)
            {
                Paquete p = ((Correo)elemento).paquetes[i];
                str.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
            }

            return str.ToString();
        }

        /// <summary>
        /// Sobrecarga operador +, Agrega un objeto Paquete a la lista paquetes del objeto Correo
        /// Ejecuta un thread para el metodo MockCicloDeVida del objeto paquete
        /// </summary>
        /// <param name="c">Objeto Correo</param>
        /// <param name="p">Objeto Paquete</param>
        /// <returns>DEvuelve Objeto Correo con el paquete agregado si no esta repetido</returns>
        public static Correo operator +(Correo c, Paquete p)
        {

            bool ok = true;
            foreach (Paquete item in c.paquetes)
            {
                if (item == p)
                {
                    ok = false;
                    break;
                }

            }
            if (ok == true)
            {
                c.paquetes.Add(p);
            }
            else
            {
                throw new TrackingIdRepetidoException("Tracking ID repetido");
            }

            
            ThreadStart ts = new ThreadStart(p.MockCicloDeVida);
            Thread h = new Thread(ts);

            c.mockPaquetes.Add(h);
            h.Start();
 
            return c;
        }

        /// <summary>
        /// Cierra todos los Thread de la lista mockPaquetes
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in mockPaquetes)
            {
                if (item.ThreadState != ThreadState.Aborted)
                {
                    item.Abort();
                }
            }
        }

    }
}
