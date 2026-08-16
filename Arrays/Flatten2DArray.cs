namespace Arrays;

/// <summary>
/// Questão 10: converta um array jagged de inteiros em um único array linear.
/// São apresentadas abordagens com laços aninhados, LINQ e pré-alocação.
/// </summary>
public sealed class Flatten2DArray
{
    private readonly int[][] _jaggedArray;

    public Flatten2DArray(int[][] jaggedArray)
    {
        ArgumentNullException.ThrowIfNull(jaggedArray);

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            if (jaggedArray[i] is null)
            {
                throw new ArgumentException("O array jagged não pode conter linhas nulas.", nameof(jaggedArray));
            }
        }

        _jaggedArray = jaggedArray;
    }

    // Tempo: O(e), em que e é o total de elementos. Espaço adicional: O(e).
    public int[] FlattenWithNestedLoops()
    {
        List<int> result = new();

        for (int i = 0; i < _jaggedArray.Length; i++)
        {
            for (int j = 0; j < _jaggedArray[i].Length; j++)
            {
                result.Add(_jaggedArray[i][j]);
            }
        }

        return result.ToArray();
    }

    // Tempo: O(e). Espaço adicional: O(e), incluindo as alocações realizadas pelo LINQ.
    public int[] FlattenWithLinq()
    {
        return _jaggedArray.SelectMany(row => row).ToArray();
    }

    // Tempo: O(e). Espaço adicional: O(e) para o resultado.
    // A pré-alocação evita os redimensionamentos internos de List<T>.
    public int[] FlattenOptimized()
    {
        int totalLength = 0;

        foreach (int[] row in _jaggedArray)
        {
            totalLength = checked(totalLength + row.Length);
        }

        int[] flattened = new int[totalLength];
        int index = 0;

        foreach (int[] row in _jaggedArray)
        {
            for (int i = 0; i < row.Length; i++)
            {
                flattened[index++] = row[i];
            }
        }

        return flattened;
    }
}
