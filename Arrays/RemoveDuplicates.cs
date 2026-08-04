namespace Arrays;

/// <summary>
/// Questão 4: remova elementos duplicados de um array de inteiros usando:
/// 1. comparação com a lista de resultados, O(n²);
/// 2. ordenação e comparação de elementos adjacentes, O(n log n);
/// 3. HashSet para rastrear valores já encontrados, O(n) em média.
/// </summary>
public sealed class RemoveDuplicates
{
    private readonly int[] _array;

    public RemoveDuplicates(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);
        _array = array;
    }

    // Mantém a ordem da primeira ocorrência.
    // Tempo: O(n²). Espaço adicional: O(n).
    public int[] RemoveDuplicatesBruteForce()
    {
        List<int> result = new();

        for (int i = 0; i < _array.Length; i++)
        {
            bool exists = false;

            for (int j = 0; j < result.Count; j++)
            {
                if (_array[i] == result[j])
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                result.Add(_array[i]);
            }
        }

        return result.ToArray();
    }

    // Retorna os valores em ordem crescente.
    // Tempo: O(n log n). Espaço adicional: O(n), pois uma cópia é ordenada
    // para evitar modificar inesperadamente o array recebido.
    public int[] RemoveDuplicatesWithSorting()
    {
        if (_array.Length == 0)
        {
            return Array.Empty<int>();
        }

        int[] sorted = (int[])_array.Clone();
        Array.Sort(sorted);

        List<int> result = new() { sorted[0] };

        for (int i = 1; i < sorted.Length; i++)
        {
            if (sorted[i] != sorted[i - 1])
            {
                result.Add(sorted[i]);
            }
        }

        return result.ToArray();
    }

    // Mantém a ordem da primeira ocorrência.
    // Tempo médio: O(n). Espaço adicional: O(n).
    public int[] RemoveDuplicatesWithHashSet()
    {
        HashSet<int> seen = new();
        List<int> result = new();

        foreach (int number in _array)
        {
            if (seen.Add(number))
            {
                result.Add(number);
            }
        }

        return result.ToArray();
    }
}
