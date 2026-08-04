namespace Arrays;

/// <summary>
/// Questão 8: rotacione um array de inteiros para a direita em K posições.
/// São apresentadas abordagens por deslocamentos sucessivos, array auxiliar e reversões no próprio array.
/// </summary>
public sealed class RotateArray
{
    private readonly int[] _array;

    public RotateArray(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);
        _array = array;
    }

    // Tempo: O(n * k). Espaço adicional: O(n), pois o array original é preservado.
    public int[] RotateBruteForce(int k)
    {
        int length = _array.Length;

        if (length == 0)
        {
            return Array.Empty<int>();
        }

        int steps = NormalizeSteps(k, length);
        int[] copy = (int[])_array.Clone();

        for (int step = 0; step < steps; step++)
        {
            int last = copy[length - 1];

            for (int i = length - 1; i > 0; i--)
            {
                copy[i] = copy[i - 1];
            }

            copy[0] = last;
        }

        return copy;
    }

    // Tempo: O(n). Espaço adicional: O(n).
    public int[] RotateWithExtraArray(int k)
    {
        int length = _array.Length;

        if (length == 0)
        {
            return Array.Empty<int>();
        }

        int steps = NormalizeSteps(k, length);
        int[] result = new int[length];

        for (int i = 0; i < length; i++)
        {
            int newIndex = (i + steps) % length;
            result[newIndex] = _array[i];
        }

        return result;
    }

    // Tempo: O(n). Espaço adicional: O(1).
    // Modifica o array recebido no construtor.
    public void RotateInPlace(int k)
    {
        int length = _array.Length;

        if (length <= 1)
        {
            return;
        }

        int steps = NormalizeSteps(k, length);

        if (steps == 0)
        {
            return;
        }

        Reverse(0, length - 1);
        Reverse(0, steps - 1);
        Reverse(steps, length - 1);
    }

    private static int NormalizeSteps(int k, int length)
    {
        int steps = k % length;
        return steps < 0 ? steps + length : steps;
    }

    private void Reverse(int start, int end)
    {
        while (start < end)
        {
            (_array[start], _array[end]) = (_array[end], _array[start]);
            start++;
            end--;
        }
    }

    public void PrintArray()
    {
        Console.WriteLine(string.Join(", ", _array));
    }
}
