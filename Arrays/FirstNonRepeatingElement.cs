namespace Arrays;

/// <summary>
/// Questão 7: encontra o primeiro elemento do array que aparece apenas uma vez.
/// </summary>
public sealed class FirstNonRepeatingElement
{
    private readonly int[] _array;

    public FirstNonRepeatingElement(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);
        _array = array;
    }

    // Tempo: O(n²). Espaço adicional: O(1).
    public int? FindBruteForce()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            bool isUnique = true;

            for (int j = 0; j < _array.Length; j++)
            {
                if (i != j && _array[i] == _array[j])
                {
                    isUnique = false;
                    break;
                }
            }

            if (isUnique)
            {
                return _array[i];
            }
        }

        return null;
    }

    // Tempo: O(n). Espaço adicional: O(n).
    public int? FindWithDictionary()
    {
        Dictionary<int, int> frequency = new();

        foreach (int number in _array)
        {
            frequency[number] = frequency.GetValueOrDefault(number, 0) + 1;
        }

        foreach (int number in _array)
        {
            if (frequency[number] == 1)
            {
                return number;
            }
        }

        return null;
    }

    // Tempo: O(n). Espaço adicional: O(n), com alocações dos agrupamentos do LINQ.
    public int? FindWithLinq()
    {
        return _array
            .GroupBy(number => number)
            .FirstOrDefault(group => group.Count() == 1)?
            .Key;
    }
}
