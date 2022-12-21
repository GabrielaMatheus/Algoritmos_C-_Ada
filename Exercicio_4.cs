using System;
using System.Linq;

namespace QuantidadePOV
{
    class Exercicio_4
    {
        public static int funcaoRetornaQuantidadePOV(decimal porcentagem, int totalNegociado)
        {
            return (int) Math.Round(((porcentagem + 1) * totalNegociado) * porcentagem);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Exercicio_4.funcaoRetornaQuantidadePOV(0.1m, 90));
            Console.WriteLine(Exercicio_4.funcaoRetornaQuantidadePOV(0.1m, 100));
            Console.WriteLine(Exercicio_4.funcaoRetornaQuantidadePOV(0.2m, 70));
        }
    }
}
