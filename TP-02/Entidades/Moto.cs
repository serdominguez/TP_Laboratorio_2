using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        /// <summary>
        /// Constructor de la moto
        /// </summary>
        /// <param name="marca">Es la marca de la moto</param>
        /// <param name="codigo">Es la patente de la moto</param>
        /// <param name="color">Es el color de la moto</param>
        public Moto(EMarca marca, string codigo, ConsoleColor color)
            :base(codigo, marca, color)
        {
        }

        /// <summary>
        /// Las motos son chicas
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Muestra los datos de una moto
        /// </summary>
        /// <returns>devuelve un string</returns>
        public override string Mostrar() 
        {
            StringBuilder sb = new StringBuilder();

            
            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
