namespace Arrays;

/// <summary>
/// Questão 14: encontrar a maior soma entre todos os subarrays contíguos.
///
/// As abordagens apresentadas são:
/// 1. força bruta com soma incremental — O(n²) de tempo e O(1) de espaço;
/// 2. algoritmo de Kadane — O(n) de tempo e O(1) de espaço;
/// 3. prefixos de soma combinados com LINQ — O(n²) de tempo e O(n) de espaço.
///
/// Os resultados usam long para reduzir o risco de overflow durante a soma de valores int.
/// </summary>
public class MaxSubarraySum
{
    private readonly int[] _array;

    public MaxSubarraySum(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (array.Length == 0)
            throw new ArgumentException("O array não pode estar vazio.", nameof(array));

        _array = (int[])array.Clone();
    }

    /// <summary>
    /// Inicia um subarray em cada posição e amplia seu final progressivamente.
    /// </summary>
    public long FindMaxSumBruteForce()
    {
        long maxSum = long.MinValue;

        for (int start = 0; start < _array.Length; start++)
        {
            long currentSum = 0;

            for (int end = start; end < _array.Length; end++)
            {
                currentSum += _array[end];
                maxSum = Math.Max(maxSum, currentSum);
            }
        }

        return maxSum;
    }

    /// <summary>
    /// Decide, para cada posição, entre ampliar o subarray atual ou iniciar um novo.
    /// </summary>
    public long FindMaxSumKadane()
    {
        long currentSum = _array[0];
        long maxSum = _array[0];

        for (int i = 1; i < _array.Length; i++)
        {
            currentSum = Math.Max(_array[i], currentSum + _array[i]);
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }

    /// <summary>
    /// Usa um array de prefixos para calcular cada soma em O(1), depois enumera
    /// todas as combinações de início e fim com LINQ.
    /// </summary>
    public long FindMaxSumWithLinq()
    {
        long[] prefixSums = new long[_array.Length + 1];

        for (int i = 0; i < _array.Length; i++)
            prefixSums[i + 1] = prefixSums[i] + _array[i];

        return Enumerable.Range(0, _array.Length)
            .SelectMany(start =>
                Enumerable.Range(start + 1, _array.Length - start)
                    .Select(end => prefixSums[end] - prefixSums[start]))
            .Max();
    }
}
