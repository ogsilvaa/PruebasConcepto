using Humanizer;
using InterfacesF;

namespace Capa2
{
    public class ClassB : IOperacion
    {
        public string Humaniza(int numero)
        {
            return numero.ToWords();
        }

    }
}
