namespace DistanciaEntreCidades
{
    class Exercicio_2
    {
        static void Main(string[] args)
        {
            var caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var caminhoArquivoMatriz = Path.Combine(caminhoDesktop, "matriz.txt");

            if (!File.Exists(caminhoArquivoMatriz))
            {
                Console.WriteLine("Arquivo não encontrado");
                return;
            }

            string[] linhasMatriz = File.ReadAllLines(caminhoArquivoMatriz);
            int[][] dados = new int[linhasMatriz.Length][];

            for (int i = 0; i < linhasMatriz.Length; i++)
            {
                string[] valores = linhasMatriz[i].Split(',');
                int[] linha = new int[valores.Length];

                for (int j = 0; j < valores.Length; j++)
                {
                    linha[j] = int.Parse(valores[j]);
                }

                dados[i] = linha;
            }

            var caminhoArquivoPercurso = Path.Combine(caminhoDesktop, "caminho.txt");

            if (!File.Exists(caminhoArquivoPercurso))
            {
                Console.WriteLine("Arquivo não encontrado");
                return;
            }

            string[] linhasCaminho = File.ReadAllLines(caminhoArquivoPercurso);
            int[] cidades = Array.Empty<int>();

            try
            {
                cidades = linhasCaminho[0].Split(',').Select(int.Parse).ToArray();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Formato inesperado.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro.");
            }

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
