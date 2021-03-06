﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException() : base("Ha ocurrido un error") { }

        public DniInvalidoException(string mensaje) : base(mensaje) { }

        public DniInvalidoException(Exception e) : base(e.Message) { }

        public DniInvalidoException(string mensaje, Exception e): base(mensaje + e.Message) { }
        
    }
}
