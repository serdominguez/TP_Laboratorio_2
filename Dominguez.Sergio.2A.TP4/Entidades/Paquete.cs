using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;


namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado { Ingresado, EnViaje, Entregado }
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;
        public event DelegadoEstado LanzaExcepcion;

        string direccionEntrega;
        EEstado estado;
        string trackingID;

        /// <summary>
        /// Constructor. Inicializa atributos del Paquete
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;


        }

        /// <summary>
        /// Direccion de entrega
        /// </summary>
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        /// <summary>
        /// Estado del paquete
        /// </summary>
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        /// <summary>
        /// Tracking ID
        /// </summary>
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        /// <summary>
        /// sobrecarga operador ==, compara los atributos TrackingId de dos objetos Paquete
        /// </summary>
        /// <param name="p1">Objeto Paqeute</param>
        /// <param name="p2">Objeto Paqeute</param>
        /// <returns>True si los trackingID son iguales</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool rta = false;

            if (p1.trackingID == p2.trackingID)
            {
                rta = true;
            }


            return rta;
        }

        /// <summary>
        /// sobrecarga operador !=, compara los atributos TrackingId de dos objetos Paquete
        /// </summary>
        /// <param name="p1">Objeto Paqeute</param>
        /// <param name="p2">Objeto Paqeute</param>
        /// <returns>False si los trackingID son iguales</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Devuelve string con los datos de un objeto Paquete
        /// </summary>
        /// <param name="elemento">Interfase del tipo IMostrar</param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = new Paquete(((Paquete)elemento).DireccionEntrega, ((Paquete)elemento).TrackingID);

            return String.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }

        /// <summary>
        /// Sobrecarga metodo toString
        /// </summary>
        /// <returns>Devuelve los atributos del objeto</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Cambia el valor del atributo estado cada 4 segundos, invocando el delegado InformaEstado, que actualiza el estado en el form
        /// Cuando el estado es Entregado, guarda los datos en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {

            this.InformaEstado.Invoke(this, System.EventArgs.Empty);
            Thread.Sleep(4000);

            this.estado = EEstado.EnViaje;
            this.InformaEstado.Invoke(this, System.EventArgs.Empty);
            Thread.Sleep(4000);

            this.estado = EEstado.Entregado;
            this.InformaEstado.Invoke(this, System.EventArgs.Empty);

            try
            {
                PaqueteDAO.insertar(this);
            }
            catch (Exception ex)
            {
                this.LanzaExcepcion.Invoke(ex, System.EventArgs.Empty);

            }
        }


    }
}
