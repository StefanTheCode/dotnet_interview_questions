namespace Arrays;

/// <summary>
/// Questão 16: demonstrar as diferenças entre arrays jagged e multidimensionais.
///
/// Um array jagged é um array cujos elementos são outros arrays e, portanto,
/// cada linha pode ter um tamanho diferente. Um array multidimensional retangular
/// possui uma única estrutura, com o mesmo número de colunas em todas as linhas.
/// </summary>
public class JaggedVsMultidimensionalArray
{
    private readonly int[][] _jaggedArray;
    private readonly int[,] _multidimensionalArray;

    public JaggedVsMultidimensionalArray()
    {
        _jaggedArray = new int[3][];
        _jaggedArray[0] = new[] { 1, 2 };
        _jaggedArray[1] = new[] { 3, 4, 5 };
        _jaggedArray[2] = new[] { 6 };

        _multidimensionalArray = new[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
    }

    /// <summary>
    /// Percorre cada array interno, respeitando o tamanho individual de suas linhas.
    /// </summary>
    public void PrintJaggedArray()
    {
        Console.WriteLine("Array jagged:");

        for (int row = 0; row < _jaggedArray.Length; row++)
        {
            Console.Write($"Linha {row}: ");

            for (int column = 0; column < _jaggedArray[row].Length; column++)
                Console.Write($"{_jaggedArray[row][column]} ");

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Percorre as dimensões da matriz retangular com GetLength.
    /// </summary>
    public void PrintMultidimensionalArray()
    {
        Console.WriteLine("Array multidimensional:");

        for (int row = 0; row < _multidimensionalArray.GetLength(0); row++)
        {
            for (int column = 0; column < _multidimensionalArray.GetLength(1); column++)
                Console.Write($"{_multidimensionalArray[row, column]} ");

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Mostra a diferença de sintaxe para acessar um elemento em cada estrutura.
    /// </summary>
    public void ShowAccessExample()
    {
        Console.WriteLine($"Primeiro elemento do array jagged: {_jaggedArray[0][0]}");
        Console.WriteLine(
            $"Primeiro elemento do array multidimensional: {_multidimensionalArray[0, 0]}");
    }
}
