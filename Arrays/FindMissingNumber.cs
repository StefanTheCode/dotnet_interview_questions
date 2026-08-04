namespace Arrays;

/// <summary>
/// Questão 5: dado um array contendo números de 1 até N, com exatamente um número ausente,
/// encontre o valor faltante usando força bruta, fórmula da soma ou XOR.
/// </summary>
public sealed class FindMissingNumber
{
    private readonly int[] _array;

    public FindMissingNumber(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);
        _array = array;
    }

    // Tempo: O(n²). Espaço adicional: O(1).
    public int FindMissingBruteForce()
    {
        int n = checked(_array.Length + 1);

        for (int number = 1; number <= n; number++)
        {
            bool found = false;

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == number)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                return number;
            }
        }

        throw new InvalidOperationException("O array não atende à regra de conter exatamente um número ausente.");
    }

    // Tempo: O(n). Espaço adicional: O(1).
    // Usa long nos cálculos intermediários para evitar overflow da soma de 1 até N.
    public int FindMissingUsingSum()
    {
        long n = _array.LongLength + 1;
        long expectedSum = n * (n + 1) / 2;
        long actualSum = 0;

        foreach (int number in _array)
        {
            actualSum += number;
        }

        return checked((int)(expectedSum - actualSum));
    }

    // Tempo: O(n). Espaço adicional: O(1).
    // XOR evita o risco de overflow presente na fórmula da soma.
    public int FindMissingUsingXor()
    {
        int n = checked(_array.Length + 1);
        int xorAll = 0;
        int xorArray = 0;

        for (int number = 1; number <= n; number++)
        {
            xorAll ^= number;
        }

        foreach (int number in _array)
        {
            xorArray ^= number;
        }

        return xorAll ^ xorArray;
    }
}
