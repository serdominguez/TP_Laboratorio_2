using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        private Paquete paquete;

        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();

        }

        /// <summary>
        /// Actualiza el estado de los paquetes de la lista y los muestra en el listBox correspondiente
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();

            foreach (Paquete item in correo.Paquetes)
            {
                if (item.Estado == Paquete.EEstado.Ingresado)
                {
                    this.lstEstadoIngresado.Items.Add(item);
                }
                else if (item.Estado == Paquete.EEstado.EnViaje)
                {
                    this.lstEstadoEnViaje.Items.Add(item);
                }
                else if(item.Estado == Paquete.EEstado.Entregado)
                {
                    this.lstEstadoEntregado.Items.Add(item);
                }
            }

        }

        /// <summary>
        /// genera un nuevo objeto paquete con los datos cargados en mtxtTrackingID y txtDireccion
        /// lo agrega a la lista y ejecuta ActualizarEstados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string tempId = this.mtxtTrackingID.Text;
            string tempDireccion = this.txtDireccion.Text;

            this.paquete = new Paquete(tempDireccion, tempId);
            paquete.InformaEstado += paq_InformaEstado;
            paquete.LanzaExcepcion += paq_LanzaExcepcion;

            try
            {

                this.correo += this.paquete;

            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            } 

            ActualizarEstados();
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            { // Llamar al método }
                this.ActualizarEstados();
            }
        }

        private void paq_LanzaExcepcion(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                MessageBox.Show("Ha ocurrido el siguiente error:\n" + ((Exception)sender).Message );
            }

        }

        /// <summary>
        /// Cierra todos los threads generados cuando se agregan paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        /// <summary>
        /// Llama al metod MostrarInformacion para mostrar en el RichTextBox la informacion de los paquetes de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Imprime en el RichTextBox la informacion de los paquetes de la lista y los guarda en un TXT en el escritorio
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
            }

            rtbMostrar.Text.Guardar("salida.txt");
        }

        /// <summary>
        /// muestra contextMenuStrip al dar boton derecho a un elemento de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstEstadoEntregado_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.csmListas.Show(MousePosition.X, MousePosition.Y);

            }
        }

        /// <summary>
        /// Muestra en el RichTextBox la informacion del paquete seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
