namespace Arrays;

/// <summary>
/// Questão 2: dado um array, inverta sua ordem usando diferentes abordagens:
/// 1. LINQ, criando um novo array;
/// 2. cópia manual para um novo array;
/// 3. troca de elementos com dois ponteiros, no próprio array.
/// </summary>
public sealed class ReverseArray
{
    private readonly int[] _array;

    public ReverseArray(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);
        _array = array;
    }

    // Tempo: O(n). Espaço adicional: O(n).
    public int[] ReverseWithLinq()
    {
        return _array.Reverse().ToArray();
    }

    // Tempo: O(n). Espaço adicional: O(n).
    public int[] ReverseWithNewArray()
    {
        int[] reversed = new int[_array.Length];

        for (int i = 0; i < _array.Length; i++)
        {
            reversed[i] = _array[_array.Length - 1 - i];
        }

        return reversed;
    }

    // Tempo: O(n). Espaço adicional: O(1).
    // Esta abordagem modifica o array recebido no construtor.
    public void ReverseInPlace()
    {
        int left = 0;
        int right = _array.Length - 1;

        while (left < right)
        {
            (_array[left], _array[right]) = (_array[right], _array[left]);
            left++;
            right--;
        }
    }

    public void PrintArray()
    {
        Console.WriteLine(string.Join(", ", _array));
    }
}
