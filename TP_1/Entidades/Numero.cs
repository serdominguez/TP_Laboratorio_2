using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
     public class Numero
    {
        private double numero;

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double num)
        {
            this.numero = num;
        }

        public Numero(string num)
        {
            this.SetNumero = num;
        }

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

        public static double operator +(Numero n1, Numero n2)
        {
            double res;

            res = n1.numero + n2.numero;

            return res;

        }

        public static double operator -(Numero n1, Numero n2)
        {
            double res;

            res = n1.numero - n2.numero;

            return res;

        }

        public static double operator *(Numero n1, Numero n2)
        {
            double res;

            res = n1.numero * n2.numero;

            return res;

        }

        public static double operator /(Numero n1, Numero n2)
        {
            double res = double.MinValue;

            if (n2.numero != 0)
            {
                res = n1.numero / n2.numero;
            }

            return res;

        }
    }
}
