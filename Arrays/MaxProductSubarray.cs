namespace Arrays;

/// <summary>
/// Questão 3: encontre o subarray contíguo com o maior produto.
/// A classe apresenta força bruta O(n³), produto acumulado O(n²)
/// e uma variação do algoritmo de Kadane O(n).
/// </summary>
public sealed class MaxProductSubarray
{
    private readonly int[] _array;

    public MaxProductSubarray(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (array.Length == 0)
        {
            throw new ArgumentException("O array deve conter pelo menos um elemento.", nameof(array));
        }

        _array = array;
    }

    // Tempo: O(n³). Espaço adicional: O(1).
    public int MaxProductBruteForce()
    {
        int maxProduct = int.MinValue;

        for (int i = 0; i < _array.Length; i++)
        {
            for (int j = i; j < _array.Length; j++)
            {
                int product = 1;

                for (int k = i; k <= j; k++)
                {
                    product *= _array[k];
                }

                maxProduct = Math.Max(maxProduct, product);
            }
        }

        return maxProduct;
    }

    // Tempo: O(n²). Espaço adicional: O(1).
    // O produto é reaproveitado ao ampliar o subarray, evitando o terceiro laço.
    public int MaxProductDoubleLoop()
    {
        int maxProduct = int.MinValue;

        for (int i = 0; i < _array.Length; i++)
        {
            int product = 1;

            for (int j = i; j < _array.Length; j++)
            {
                product *= _array[j];
                maxProduct = Math.Max(maxProduct, product);
            }
        }

        return maxProduct;
    }

    // Tempo: O(n). Espaço adicional: O(1).
    // O menor produto também é rastreado porque um número negativo pode transformá-lo no maior.
    public int MaxProductKadane()
    {
        int maxSoFar = _array[0];
        int minSoFar = _array[0];
        int result = _array[0];

        for (int i = 1; i < _array.Length; i++)
        {
            int current = _array[i];

            if (current < 0)
            {
                (maxSoFar, minSoFar) = (minSoFar, maxSoFar);
            }

            maxSoFar = Math.Max(current, maxSoFar * current);
            minSoFar = Math.Min(current, minSoFar * current);
            result = Math.Max(result, maxSoFar);
        }

        return result;
    }
}
