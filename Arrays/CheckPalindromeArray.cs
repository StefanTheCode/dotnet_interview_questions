namespace Arrays;

/// <summary>
/// Questão 9: determine se um array de inteiros é um palíndromo,
/// isto é, se possui a mesma sequência quando lido do início para o fim e no sentido inverso.
/// </summary>
public sealed class CheckPalindromeArray
{
    private readonly int[] _array;

    public CheckPalindromeArray(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);
        _array = array;
    }

    // Tempo: O(n). Espaço adicional: O(n).
    public bool IsPalindromeWithCopy()
    {
        int[] reversed = new int[_array.Length];

        for (int i = 0; i < _array.Length; i++)
        {
            reversed[i] = _array[_array.Length - 1 - i];
        }

        for (int i = 0; i < _array.Length; i++)
        {
            if (_array[i] != reversed[i])
            {
                return false;
            }
        }

        return true;
    }

    // Tempo: O(n). Espaço adicional: O(n), devido à sequência invertida.
    public bool IsPalindromeWithLinq()
    {
        return _array.SequenceEqual(_array.Reverse());
    }

    // Tempo: O(n). Espaço adicional: O(1).
    public bool IsPalindromeTwoPointer()
    {
        int left = 0;
        int right = _array.Length - 1;

        while (left < right)
        {
            if (_array[left] != _array[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }
}
