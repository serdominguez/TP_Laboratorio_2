using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Recibe un string y lo valida por uno de los operadores: + - / *
        /// En caso contrario devuelve +
        /// </summary>
        /// <param name="oper"></param>
        /// <returns></returns>
        private static string ValidarOperador(string oper)
        {

            if (oper != "+" && oper != "-" && oper != "/" && oper != "*")
            {
                oper = "+";
            }

            return oper;

        }

        /// <summary>
        /// Realiza la operacion recibida entre los dos numeros, toma + por defecto
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            switch (ValidarOperador(operador))
            {
                case "-":
                    resultado = num1 - num2;
                    break;

                case "/":
                    resultado = num1 / num2;
                    break;

                case "*":
                    resultado = num1 * num2;
                    break;

                default:
                    resultado = num1 + num2;
                    break;
            }

            return resultado;
        }
    }
}
