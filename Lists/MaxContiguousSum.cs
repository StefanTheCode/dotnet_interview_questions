namespace Lists;

/// <summary>
/// Q18: MaxContiguousSum
/// Tarefa: encontrar a maior soma entre todas as sublistas contíguas não vazias.
///
/// Abordagens apresentadas:
/// 1. Soma incremental de todas as sublistas: O(n²) de tempo e O(1) de espaço.
/// 2. Algoritmo de Kadane: O(n) de tempo e O(1) de espaço.
/// 3. LINQ com prefixos de soma: O(n²) de tempo e O(n) de espaço.
/// </summary>
public sealed class MaxContiguousSum
{
    private readonly List<int> _list;

    public MaxContiguousSum(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);

        if (list.Count == 0)
        {
            throw new ArgumentException(
                "A lista deve conter pelo menos um elemento.",
                nameof(list));
        }

        _list = new List<int>(list);
    }

    public long FindMaxSumBruteForce()
    {
        long maxSum = long.MinValue;

        for (int start = 0; start < _list.Count; start++)
        {
            long currentSum = 0;

            for (int end = start; end < _list.Count; end++)
            {
                currentSum += _list[end];
                maxSum = Math.Max(maxSum, currentSum);
            }
        }

        return maxSum;
    }

    public long FindMaxSumKadane()
    {
        long currentSum = _list[0];
        long maxSum = _list[0];

        for (int index = 1; index < _list.Count; index++)
        {
            currentSum = Math.Max(_list[index], currentSum + _list[index]);
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }

    public long FindMaxSumWithLinq()
    {
        long[] prefixSums = new long[_list.Count + 1];

        for (int index = 0; index < _list.Count; index++)
        {
            prefixSums[index + 1] = prefixSums[index] + _list[index];
        }

        return Enumerable
            .Range(0, _list.Count)
            .SelectMany(start => Enumerable
                .Range(start, _list.Count - start)
                .Select(end => prefixSums[end + 1] - prefixSums[start]))
            .Max();
    }
}
