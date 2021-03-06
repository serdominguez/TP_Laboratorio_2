﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        public enum ETipo { Monovolumen, Sedan }
        ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca">Es la marca del auto</param>
        /// <param name="chasis">Es la patente del auto</param>
        /// <param name="color">Es el color del auto</param>
        public Automovil(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
            tipo = ETipo.Monovolumen;
        }

        /// <summary>
        /// Constructor que recibe tipo
        /// </summary>
        /// <param name="marca">Es la marca del auto</param>
        /// <param name="chasis">Es la patente del auto</param>
        /// <param name="color">Es el color del auto</param>
        /// <param name="tipo">Es el tipo del auto</param>
        public Automovil(EMarca marca, string codigo, ConsoleColor color, ETipo tipo) 
            :this (marca, codigo, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Muestra los datos de un auto
        /// </summary>
        /// <returns>Devuelve string</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio.ToString());
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
