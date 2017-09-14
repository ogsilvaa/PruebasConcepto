using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test
{
    /// <summary>
    /// Descripción resumida de Flags
    /// </summary>
    [TestClass]
    public class Flags
    {
        public Flags()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            var cosa = new Cosa
            {
                Permisos = Permisos.Lectura | Permisos.Escritura
            };

            Assert.IsTrue(cosa.Permisos.HasFlag(Permisos.Lectura));
            Assert.IsTrue(cosa.Permisos.HasFlag(Permisos.Escritura));
        }
        [TestMethod]
        public void TestMethod2()
        {
            const double valor = 3.00;
            var cosa = new Cosa
            {
                Permisos = (Permisos)valor
            };

            Assert.IsTrue(cosa.Permisos.HasFlag(Permisos.Lectura));
            Assert.IsTrue(cosa.Permisos.HasFlag(Permisos.Escritura));
        }
        [Flags]
        public enum Permisos
        {
            None = 0,
            Lectura = 1 << 0,
            Escritura = 1 << 1,
            Borrar = 1 << 2,
            Crear = 1 << 3,
            Editor = Lectura | Escritura
        }

        public class Cosa
        {
            public Permisos Permisos { get; set; }
        }
    }
}
