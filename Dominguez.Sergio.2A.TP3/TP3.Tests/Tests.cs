using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;
using EntidadesAbstractas;
using System.Security.Cryptography;
using Archivos;

namespace TP3.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void VerificarNacionalidadInvalidaException_Falla()
        {
            string dniArg = "10111222";
            string dniEx = "91111222";
            Persona.ENacionalidad nacEx = Persona.ENacionalidad.Extranjero;
            Persona.ENacionalidad nacArg = Persona.ENacionalidad.Argentino;

            Alumno a1 = new Alumno(1, "a", "b", dniArg, nacEx, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(1, "c", "d", dniEx, nacArg, Universidad.EClases.Laboratorio);

        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void VerificarDniInvalidoException_Falla()
        {
            string dniNeg = "-10";
            string dniTxt = "dni";
            string dniMax = "100000005";


            Profesor p1 = new Profesor(1, "a", "b", dniNeg, Persona.ENacionalidad.Argentino);
            Profesor p2 = new Profesor(2, "c", "d", dniTxt, Persona.ENacionalidad.Extranjero);
            Profesor p3 = new Profesor(3, "e", "f", dniMax, Persona.ENacionalidad.Argentino);

        }
        [TestMethod]
        public void VerificarAtributoCollection()
        {
            Universidad u1 = new Universidad();


            Assert.IsNotNull(u1.Instructores);
            Assert.IsNotNull(u1.Alumnos);
            Assert.IsNotNull(u1.Jornadas);

        }

        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void VerificarSerializacionXml_Falla()
        {
            Universidad u1 = new Universidad();

            Xml<Universidad> guardado = new Xml<Universidad>();
            guardado.Guardar("Z:\falso.eee", u1);

        }
    }
}
