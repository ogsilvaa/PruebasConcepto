using System.Collections.Generic;
using Capa1;
using Capa2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using InterfacesF;
using SimpleInjector;

namespace test
{
    [TestClass]
    public class MockVsDi
    {
        private ClassA _a;
        private Container _container;
        [TestInitialize]
        public void Inicia()
        {
            _container = new Container();
            _container.Register<IOperacion, ClassB>();
            _a = new ClassA();
        }
        [TestMethod]
        public void Substituido()
        {
            //Arrange:mock
            _a.Operador = Substitute.For<IOperacion>();
            _a.Operador.Humaniza(1993).Returns("uno");
            _a.Operador.Humaniza(12652).Returns("dos");
            _a.Operador.Humaniza(1817165).Returns("tres");

            //Act
            var respuesta1 = _a.NumeroLetras(1993);
            var respuesta2 = _a.NumeroLetras(12652);
            var respuesta3 = _a.NumeroLetras(1817165);

            //Assert
            Assert.AreEqual("uno", respuesta1);
            Assert.AreEqual("dos", respuesta2);
            Assert.AreEqual("tres", respuesta3);
        }
        [TestMethod]
        public void SinSubstitucion()
        {
            //Arrange:DI
            _a.Operador = _container.GetInstance<IOperacion>();
            var valores = new Dictionary<int, string>()
            {
                {1993,"mil novecientos noventa y tres" },
                {12652, "doce mil seiscientos cincuenta y dos"},
                {1817165, "un millón ochocientos diecisiete mil ciento sesenta y cinco"}
            };

            //Act
            var respuesta1 = _a.NumeroLetras(1993);
            var respuesta2 = _a.NumeroLetras(12652);
            var respuesta3 = _a.NumeroLetras(1817165);

            //Assert
            Assert.AreEqual(valores[1993], respuesta1);
            Assert.AreEqual(valores[12652], respuesta2);
            Assert.AreEqual(valores[1817165], respuesta3);
        }
    }
}
