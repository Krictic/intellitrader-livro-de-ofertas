// ReSharper disable HeapView.BoxingAllocation
using System.Globalization;

namespace livro_de_ofertas
{
    internal static class Program
    {
        public static void Main()
        {
            const string input = ("12\n" +
                                  "1,0,15.4,50\n" +
                                  "2,0,15.5,50\n" +
                                  "2,2,0,0\n" +
                                  "2,0,15.4,10\n" +
                                  "3,0,15.9,30\n" +
                                  "3,1,0,20\n" +
                                  "4,0,16.50,200\n" +
                                  "5,0,17.00,100\n" +
                                  "5,0,16.59,20\n" +
                                  "6,2,0,0\n" +
                                  "1,2,0,0\n" +
                                  "2,1,15.6,0");
            var input2 = "1,0,15.4,50";
            var input3 = "1,1,16.2,100";
            var input4 = "1,2,0,0";
            var input5 = ("5\n" +
                         "1,0,15.4,50\n" +
                         "2,0,15.4,30\n" +
                         "3,0,15.4,20\n" +
                         "4,0,15.4,10\n" +
                         "5,0,15.4,5");
            var input6 = ("3\n" +
                         "1,0,-10.5,50\n" +
                         "2,0,15.5,-30\n" +
                         "3,0,-5.2,-20");
            var input7 = ("3\n" +
                         "1,0,15.4,50\n" +
                         "2,0,15.5,30\n" +
                         "3,0,16.2,20.5");
            Console.WriteLine("-------------1-------------");
            ProcessarOfertas(input);
            Console.WriteLine("-------------2-------------");
            ProcessarOfertas(input2);
            Console.WriteLine("-------------3-------------");
            ProcessarOfertas(input3);
            Console.WriteLine("-------------4-------------");
            ProcessarOfertas(input4);
            Console.WriteLine("-------------5-------------");
            ProcessarOfertas(input5);
            Console.WriteLine("-------------6-------------");
            ProcessarOfertas(input6);
            Console.WriteLine("-------------7-------------");
            ProcessarOfertas(input7);
        }

        static void ProcessarOfertas(string input)
        {
            if (input.Length == 0)
            {
                Console.WriteLine("Erro: Input não pode ser vazio.");
                return;
            }
            var listaOfertas = new List<Dictionary<string, object>>();
            const int inserir = 0;
            const int modificar = 1;
            const int deletar = 2;

            var linhas = input.Split("\n");

            for (var i = 1; i < linhas.Length; i++)
            {
                var splitLine = linhas[i].Split(',');
                var posição = int.Parse(splitLine[0]) - 1;
                var ação = int.Parse(splitLine[1]);
                var valor = double.Parse(splitLine[2], CultureInfo.InvariantCulture);
                var quantidade = int.Parse(splitLine[3]);

                Console.WriteLine($"Pos: {posição + 1}. Ação: {ação}, Valor: {valor.ToString("0.00", CultureInfo.InvariantCulture)}, Quantidade: {quantidade}");

                switch (ação)
                {
                    case inserir:
                        InserirOferta(listaOfertas, posição, valor, quantidade);
                        break;
                    case modificar:
                        ModificarOferta(listaOfertas, posição, valor, quantidade);
                        break;
                    case deletar:
                        DeletarOferta(listaOfertas, posição);
                        break;
                    default:
                        Console.WriteLine($"Erro: {ação} não existe.");
                        break;
                }
            }

            listaOfertas.Sort((x, y) => ((double)x["valor"]).CompareTo((double)y["valor"]));

            for (var i = 0; i < listaOfertas.Count; i++)
            {
                var ofertas = listaOfertas[i];
                var valor = (double)ofertas["valor"];
                var quantidade = (int)ofertas["quantidade"];
                Console.WriteLine($"{i + 1}, {valor}, {quantidade}");
            }
        }

        static void InserirOferta(List<Dictionary<string, object>> listaOfertas, int posição, double valor, int quantidade)
        {
            if (posição <= listaOfertas.Count)
            {
                var oferta = new Dictionary<string, object>();
                oferta.Add("valor", valor);
                oferta.Add("quantidade", quantidade);
                listaOfertas.Insert(posição, oferta);
            }
            else
            {
                var oferta = new Dictionary<string, object>();
                oferta.Add("valor", valor);
                oferta.Add("quantidade", quantidade);
                listaOfertas.Add(oferta);
            }
        }

        static void ModificarOferta(List<Dictionary<string, object>> listaOfertas, int posição, double valor, int quantidade)
        {
            if (posição > listaOfertas.Count)
            {
                Console.WriteLine($"Erro: modificar em posição {posição} não é válida.");
            }
            else
            {
                if (valor > 0)
                {
                    listaOfertas[posição]["valor"] = valor;
                }

                if (quantidade > 0)
                {
                    listaOfertas[posição]["quantidade"] = quantidade;
                }
            }
        }

        static void DeletarOferta(List<Dictionary<string, object>> listaOfertas, int posição)
        {
            if (posição > listaOfertas.Count)
            {
                Console.WriteLine($"Erro: deletar em posição {posição} não é válida.");
            }
            listaOfertas.RemoveAt(posição);
        }
    }
}
