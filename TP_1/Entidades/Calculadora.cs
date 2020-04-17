using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(string oper)
        {

            if (oper != "+" && oper != "-" && oper != "/" && oper != "*")
            {
                oper = "+";
            }

            return oper;

        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            switch (operador)
            {
               // case "+":
                 //   resultado = num1 + num2;
                 //   break;

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
