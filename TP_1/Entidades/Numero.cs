using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
     public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Construnctor recibe 1 parametro
        /// </summary>
        /// <param name="num"> double </param>
        public Numero(double num)
        {
            this.numero = num;
        }

        /// <summary>
        /// Construnctor recibe 1 parametro
        /// </summary>
        /// <param name="num"> string </param>
        public Numero(string num)
        {
            this.SetNumero = num;
        }

        /// <summary>
        /// Valida si el string es numerico, si no, devuelve 0
        /// </summary>
        /// <param name="strNumero">string a validar</param>
        /// <returns>numero del string o 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double num = 0;

            double.TryParse(strNumero, out num);

            return num;
        }

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }

        }

        /// <summary>
        /// Sobrecarga operador +. Recibe dos Numero y devuelve double
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>retorna double</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double res;

            res = n1.numero + n2.numero;

            return res;

        }

        /// <summary>
        /// Sobrecarga operador -. Recibe dos Numero y devuelve double
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double res;

            res = n1.numero - n2.numero;

            return res;

        }

        /// <summary>
        /// Sobrecarga operador *. Recibe dos Numero y devuelve double
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double res;

            res = n1.numero * n2.numero;

            return res;

        }

        /// <summary>
        /// Sobrecarga operador /. Recibe dos Numero y devuelve double
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double res = double.MinValue;

            if (n2.numero != 0)
            {
                res = n1.numero / n2.numero;
            }

            return res;

        }

        /// <summary>
        /// Convierte numero string en binario, devuelve string
        /// </summary>
        /// <param name="numero"> string </param>
        /// <returns>string en binario</returns>
        public static string DecimalBinario(string numero)
        {
            string resul = "Valor invalido";
            double num;

            if (double.TryParse(numero, out num)) 
            {
            
            resul = DecimalBinario(num);
            }

            return resul;

        }

        /// <summary>
        /// Convierte numero double en binario, devuelve string
        /// </summary>
        /// <param name="numero"> double </param>
        /// <returns>string en binario</returns>
        public static string DecimalBinario(double numero)
        {
            string resul;
        
            long entero = (long)numero;

            if (entero < 0)
            {
                entero *= -1;
            }

            resul = Convert.ToString(entero, 2);

            return resul;
        }

        /// <summary>
        /// Convierte string de numero binario en string del numero en decimal
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string BinarioADecimal (string numero)
        {
            string resul = "Valor invalido";
            int flag = 0;
            long deci = 0;

            foreach (char item in numero)
            {
                if (item != '0' && item != '1')
                {
                    flag = 1;
                    break;
                }

            }
            if (flag == 0)
            {
                for (int i = 0; i < numero.Length; i++)
                {
                    if (numero[i] == '1')
                    {
                        deci = deci + (long)Math.Pow(2, (numero.Length - (i + 1)));
                    }
                }
                resul = deci.ToString();
            }


            return resul;
        }

        
    }
}
