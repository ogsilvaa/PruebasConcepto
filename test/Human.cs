//compile-unsafe

using System.Diagnostics;
using Humanizer;
using Humanizer.Inflections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test
{
    [TestClass]
    public class Human
    {
        [TestMethod]
        public void Plurales()
        {
            Debug.WriteLine("bus".Pluralize());
            Vocabularies.Default.AddIrregular("bus", "buses");
            Debug.WriteLine("bus".Pluralize());
        }

        [TestMethod]
        public void CambiaObjeto()
        {
            var clase = new clase {Propiedad1 = "valor1"};
            cambialo(clase);
            Assert.AreEqual("valor cambiado",clase.Propiedad1);
        }
        [TestMethod]
        public void CambiaNumero() {
            var numero = 5;
            cambialo(ref numero);
            Assert.AreEqual(10, numero);
        }
        
        [TestMethod]
        public void CambiaTexto()
        {

            var texto = "un valor";
            cambialo(texto);
            Assert.AreEqual("otro valor", texto);
        }
        public void cambialo(clase otraclase)
        {
            otraclase.Propiedad1 = "valor cambiado";
        }

        public void cambialo(ref int otronumero)
        {
            otronumero = 10;
        }

       
        public void cambialo(string otracadena)
        {
            otracadena = "otro valor";
        }
        public class clase
        {
            public string Propiedad1 { get; set; }
        }
    }
}
