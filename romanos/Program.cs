using System;
using Humanizer;
namespace romanos
{
    class Program
    {
        static void Main(string[] args)
        {
            int maximo;
            int.TryParse(args[0], out maximo);
            for (var numero = 1; numero <= maximo; numero++)
            {
               Console.WriteLine($"{numero}: {numero.ToRoman()}");
            }
            Console.ReadKey();

        }
    }
}
