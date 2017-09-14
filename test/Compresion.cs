using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test
{
    [TestClass]
    public class Compresion
    {
        [TestMethod]
        public void CreaCarpeta()
        {
            var path = $"{DateTime.Now.ToString("yyyyMMdd")}";
            var info = Directory.Exists(path) ? new DirectoryInfo(path) : Directory.CreateDirectory(path);
            Assert.IsTrue(info.Exists);
        }

        [TestMethod]
        public void EscribeArchivo()
        {
            var path = $"{DateTime.Now.ToString("yyyyMMdd")}";
            CreaCarpeta();
            new DirectoryInfo(path).GetFiles().ToList().ForEach(x => x.Delete());
            const int cantidad = 10;
            for (var i = 0; i < cantidad; i++)
            {
                //var cantidadArchivos = new DirectoryInfo(path).GetFiles().Count();
                var pathFile = $"{path}/{i + 1}.txt";
                File.WriteAllText(pathFile, new NLipsum.Core.LipsumGenerator().GenerateParagraphs(1)[0]);
            }
            Assert.AreEqual(cantidad, new DirectoryInfo(path).GetFiles().Count());
        }

        [TestMethod]
        public void CreaZip()
        {
            EscribeArchivo();
            var path = $"{DateTime.Now.ToString("yyyyMMdd")}";
            var pathZip = $"{DateTime.Now.ToString("yyyyMMdd")}/Prueba.zip";
            if (File.Exists(pathZip))
            {
                File.Delete(pathZip);
            }
            ZipFile.CreateFromDirectory(path, pathZip);

        }
    }
}
