using System.Formats.Asn1;
using System;
using System.Linq;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using System.Text;

namespace DistanciaEntreCidades
{
    class Exercicio_3
    { 
        static void Main(string[] args)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            var caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var caminhoArquivoMatriz = Path.Combine(caminhoDesktop, "matriz.txt");

            if (!File.Exists(caminhoArquivoMatriz))
            {
                Console.WriteLine("Arquivo não encontrado");
                return;
            }

            using StreamReader reader = new StreamReader(caminhoArquivoMatriz);
            using var csv = new CsvParser(reader, config);

            if (!csv.Read() && csv.Record.Length != null)
                return;

            var numColunas = csv.Record.Length;
            var dados = new int[numColunas, numColunas];

            for (int i = 0; i < numColunas; i++)
            {
                var linha = csv.Record;

                for (int j = 0; j < numColunas; j++)
                {
                    dados[i, j] = int.Parse(linha[j]);
                }

                csv.Read();
            }

            var caminhoArquivoCaminho = Path.Combine(caminhoDesktop, "caminho.txt");
            string[] linhasCaminho = File.ReadAllLines(caminhoArquivoCaminho);

            int[] cidades = linhasCaminho[0].Split(',').Select(int.Parse).ToArray();
            int distancia = 0;

            for (int i = 0; i < cidades.Length - 1; i++)
            {
                if (cidades[i] == cidades[i + 1])
                {
                    distancia += 0;
                    continue;
                }

                if (i > 0 && i + 2 <= cidades.Length - 1)
                {
                    if (cidades[i] == cidades[i + 2])
                    {
                        int distanciaMomentanea = dados[cidades[i] - 1, cidades[i + 1] - 1];
                        distancia += distanciaMomentanea * 2;
                        i += 1;
                        continue;
                    }
                }
                int d = dados[cidades[i] - 1, cidades[i + 1] - 1];
                distancia += d;
            }
            Console.WriteLine($"Distância percorrida: {distancia}km");
        }

    }
}

