namespace Arrays;

/// <summary>
/// Questão 12: encontrar todos os pares únicos cuja soma seja igual ao valor-alvo.
///
/// As abordagens apresentadas são:
/// 1. força bruta com dois laços — O(n²) de tempo;
/// 2. busca do complemento com HashSet — O(n) de tempo médio e O(n) de espaço;
/// 3. ordenação e dois ponteiros — O(n log n) de tempo e O(n) de espaço,
///    pois uma cópia é ordenada para preservar o array recebido.
/// </summary>
public class FindPairsWithSum
{
    private readonly int[] _array;

    public FindPairsWithSum(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);
        _array = (int[])array.Clone();
    }

    /// <summary>
    /// Verifica todas as combinações de índices e elimina pares duplicados.
    /// </summary>
    public List<(int First, int Second)> FindPairsBruteForce(int target)
    {
        HashSet<(int First, int Second)> uniquePairs = new();

        for (int i = 0; i < _array.Length; i++)
        {
            for (int j = i + 1; j < _array.Length; j++)
            {
                long sum = (long)_array[i] + _array[j];

                if (sum != target)
                    continue;

                uniquePairs.Add(NormalizePair(_array[i], _array[j]));
            }
        }

        return OrderPairs(uniquePairs);
    }

    /// <summary>
    /// Armazena os valores já visitados e procura o complemento do valor atual.
    /// </summary>
    public List<(int First, int Second)> FindPairsWithHashSet(int target)
    {
        HashSet<int> seen = new();
        HashSet<(int First, int Second)> uniquePairs = new();

        foreach (int number in _array)
        {
            long complementValue = (long)target - number;

            if (complementValue is >= int.MinValue and <= int.MaxValue)
            {
                int complement = (int)complementValue;

                if (seen.Contains(complement))
                    uniquePairs.Add(NormalizePair(number, complement));
            }

            seen.Add(number);
        }

        return OrderPairs(uniquePairs);
    }

    /// <summary>
    /// Ordena uma cópia do array e aproxima dois ponteiros conforme a soma encontrada.
    /// </summary>
    public List<(int First, int Second)> FindPairsTwoPointer(int target)
    {
        int[] sortedArray = (int[])_array.Clone();
        Array.Sort(sortedArray);

        List<(int First, int Second)> result = new();
        int left = 0;
        int right = sortedArray.Length - 1;

        while (left < right)
        {
            long sum = (long)sortedArray[left] + sortedArray[right];

            if (sum == target)
            {
                result.Add((sortedArray[left], sortedArray[right]));
                int leftValue = sortedArray[left];
                int rightValue = sortedArray[right];

                while (left < right && sortedArray[left] == leftValue)
                    left++;

                while (left < right && sortedArray[right] == rightValue)
                    right--;
            }
            else if (sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return result;
    }

    private static (int First, int Second) NormalizePair(int first, int second) =>
        first <= second ? (first, second) : (second, first);

    private static List<(int First, int Second)> OrderPairs(
        IEnumerable<(int First, int Second)> pairs) =>
        pairs.OrderBy(pair => pair.First)
             .ThenBy(pair => pair.Second)
             .ToList();
}
