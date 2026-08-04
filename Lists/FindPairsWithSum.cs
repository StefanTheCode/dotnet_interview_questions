namespace Lists;

/// <summary>
/// Q15: FindPairsWithSum
/// Tarefa: encontrar todos os pares distintos de valores cuja soma seja igual ao alvo.
///
/// Abordagens apresentadas:
/// 1. Comparar todos os pares: O(n²) de tempo.
/// 2. Consultar complementos em HashSet: O(n) de tempo esperado e O(n) de espaço.
/// 3. Ordenar uma cópia e usar dois ponteiros: O(n log n) de tempo e O(n) de espaço.
/// </summary>
public sealed class FindPairsWithSum
{
    private readonly List<int> _list;

    public FindPairsWithSum(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);
        _list = new List<int>(list);
    }

    public List<(int First, int Second)> FindPairsBruteForce(int target)
    {
        HashSet<(int First, int Second)> uniquePairs = new();

        for (int i = 0; i < _list.Count; i++)
        {
            for (int j = i + 1; j < _list.Count; j++)
            {
                long sum = (long)_list[i] + _list[j];

                if (sum == target)
                {
                    uniquePairs.Add(NormalizePair(_list[i], _list[j]));
                }
            }
        }

        return OrderPairs(uniquePairs);
    }

    public List<(int First, int Second)> FindPairsWithHashSet(int target)
    {
        HashSet<int> seen = new();
        HashSet<(int First, int Second)> uniquePairs = new();

        foreach (int number in _list)
        {
            long complementValue = (long)target - number;

            if (complementValue is >= int.MinValue and <= int.MaxValue)
            {
                int complement = (int)complementValue;

                if (seen.Contains(complement))
                {
                    uniquePairs.Add(NormalizePair(number, complement));
                }
            }

            seen.Add(number);
        }

        return OrderPairs(uniquePairs);
    }

    public List<(int First, int Second)> FindPairsTwoPointer(int target)
    {
        List<int> sorted = new(_list);
        sorted.Sort();

        List<(int First, int Second)> result = new();
        int left = 0;
        int right = sorted.Count - 1;

        while (left < right)
        {
            long sum = (long)sorted[left] + sorted[right];

            if (sum == target)
            {
                result.Add((sorted[left], sorted[right]));

                int leftValue = sorted[left];
                int rightValue = sorted[right];

                while (left < right && sorted[left] == leftValue)
                {
                    left++;
                }

                while (left < right && sorted[right] == rightValue)
                {
                    right--;
                }
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

    private static (int First, int Second) NormalizePair(int first, int second)
    {
        return first <= second ? (first, second) : (second, first);
    }

    private static List<(int First, int Second)> OrderPairs(
        IEnumerable<(int First, int Second)> pairs)
    {
        return pairs
            .OrderBy(pair => pair.First)
            .ThenBy(pair => pair.Second)
            .ToList();
    }
}
