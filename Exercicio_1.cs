using System;
using System.Linq;

namespace DistanciaEntreCidades
{
    class Exercicio_1
    {
        static void Main(string[] args)
        {

            int[][] dados = new int[][]
            {
                new int[] { 0, 15, 30, 5, 12 },
                new int[] { 15, 0, 10, 17, 28 },
                new int[] { 30, 10, 0, 3, 11 },
                new int[] { 5, 17, 3, 0, 80 },
                new int[] { 12, 28, 11, 80, 0 }
            };

            Console.Write("Digite o percurso: ");
            string percurso = Console.ReadLine();

            int[] cidades = new int[0];
            int distancia = 0;

            try
            {

                cidades = percurso.Split(',').Select(int.Parse).ToArray();

            }
            catch (FormatException e)
            {
                Console.WriteLine("Formato inesperado.");

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro.");
            }

            for (int i = 0; i < cidades.Length - 1; i++)
            {
                if (cidades[i] == cidades[i + 1])
                {
                    distancia += 0;
                    continue;
                }

                //verifica se já forneceu a distancia com 2 casas de sucessão
                if (i > 0 && i + 2 <= cidades.Length - 1)
                {
                    if (cidades[i] == cidades[i + 2])
                    {
                        int distanciaMomentanea = dados[cidades[i] - 1][cidades[i + 1] - 1];
                        distancia += distanciaMomentanea * 2;
                        i += 1;
                        continue;
                    }
                }

                int d = dados[cidades[i] - 1][cidades[i + 1] - 1];
                distancia += d;
            }

            Console.WriteLine($"Distância percorrida: {distancia}km");
        }
    }
}
