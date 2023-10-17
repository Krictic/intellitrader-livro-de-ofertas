using System.Globalization;

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

ProcessarOfertas(input);

static void ProcessarOfertas(string input)
{
    var listaOfertas = new Dictionary<int, (double, int)>();

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

        // Console.WriteLine($"Pos: {posição}. Ação: {ação}, Valor: {valor.ToString("0.0", CultureInfo.InvariantCulture)}, Quantidade: {quantidade}");

        if (ação == inserir)
        {
            if (posição <= listaOfertas.Count)
            {
                listaOfertas[posição] = (valor, quantidade);
            }
            else
            {
                listaOfertas.Add(posição, (valor, quantidade));
            }
        }
        else if (ação == modificar)
        {
            if (valor > 0)
            {
                var copiaQuantidade = listaOfertas[posição].Item2;
                listaOfertas[posição] = (valor, copiaQuantidade);
            }
            else
            {
                var copiaValor = listaOfertas[posição].Item1;
                listaOfertas[posição] = (copiaValor, quantidade);
            }
        }
        else if (ação == deletar)
        {
            if (posição < listaOfertas.Count)
            {
                listaOfertas.Remove(posição);
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

    foreach (var posição in listaOfertas)
        Console.WriteLine(posição.ToString());
}
