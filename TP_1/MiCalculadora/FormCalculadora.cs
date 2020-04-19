using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;


namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Limpiar() {

            lblResultado.Text = "0";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "+";

        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double rta;

            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            rta = Calculadora.Operar(n1, n2, operador);

            return rta;

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double res;

            res = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

            lblResultado.Text = res.ToString();
        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            
            string resul = lblResultado.Text;
            
            resul = Numero.DecimalBinario(resul);

            lblResultado.Text = resul;

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numero = lblResultado.Text;

            numero = Numero.BinarioADecimal(numero);

            lblResultado.Text = numero;
  

        }
    }
}
