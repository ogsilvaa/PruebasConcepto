using System;
using Capa2;
using InterfacesF;

namespace Capa1
{
    public class ClassA
    {

        public IOperacion Operador { get; set; }

        public string NumeroLetras(int numero)
        {
            return Operador.Humaniza(numero);
        }

    }
}
