using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        /// <summary>
        /// Constructor de la camionesta
        /// </summary>
        /// <param name="marca">Es la marca de la camioneta</param>
        /// <param name="codigo">Es la patente de la camioneta</param>
        /// <param name="color">Es el color de la camioneta</param>
        public Camioneta(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
        }
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        /// <summary>
        /// Muestra los datos de una camioneta
        /// </summary>
        /// <returns>Devuelve un string</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
