using System.Globalization;

var input = ("12\n" +
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

processar_ofertas(input);

static void processar_ofertas(string input)
{
    var lista_ofertas = new Dictionary<int, (double, int)>();

    var linhas = input.Split("\n");
    const int inserir = 0;
    const int modificar = 1;
    const int deletar = 2;

    for (var i = 1; i < linhas.Length; i++)
    {
        var splitLine = linhas[i].Split(',');
        var posição = int.Parse(splitLine[0]) - 1;
        var ação = int.Parse(splitLine[1]);
        var valor = double.Parse(splitLine[2], CultureInfo.InvariantCulture);
        var quantidade = int.Parse(splitLine[3]);

        Console.WriteLine($"Pos: {posição}. Ação: {ação}, Valor: {valor.ToString("0.0", CultureInfo.InvariantCulture)}, Quantidade: {quantidade}");

        if (ação == inserir)
        {
            if (posição <= lista_ofertas.Count)
            {
                lista_ofertas[posição] = (valor, quantidade);
            }
            else
            {
                lista_ofertas.Add(posição, (valor, quantidade));
            }
        }
        else if (ação == modificar)
        {
            if (valor > 0)
            {
                var copiaQuantidade = lista_ofertas[posição].Item2;
                lista_ofertas[posição] = (valor, copiaQuantidade);
            }
            else
            {
                var copiaValor = lista_ofertas[posição].Item1;
                lista_ofertas[posição] = (copiaValor, quantidade);
            }
        }
        else if (ação == deletar)
        {
            if (posição < lista_ofertas.Count)
            {
                lista_ofertas.Remove(posição);
            }
            else
            {
                Console.WriteLine($"Erro: Posição {posição} não é válida.");
            }
        }
        else
        {
            Console.WriteLine($"Erro: Ação {ação} não é válida.");
        }
    }

    foreach (var posição in lista_ofertas)
        Console.WriteLine(posição.ToString());
}
