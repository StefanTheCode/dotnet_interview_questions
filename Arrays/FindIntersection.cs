namespace Arrays;

/// <summary>
/// Questão 6: encontra os valores comuns e únicos entre dois arrays.
/// </summary>
public sealed class FindIntersection
{
    private readonly int[] _array1;
    private readonly int[] _array2;

    public FindIntersection(int[] array1, int[] array2)
    {
        ArgumentNullException.ThrowIfNull(array1);
        ArgumentNullException.ThrowIfNull(array2);
        _array1 = array1;
        _array2 = array2;
    }

    // Tempo: O(n * m). Espaço adicional: O(min(n, m)).
    public int[] FindIntersectionBruteForce()
    {
        List<int> intersection = new();

        for (int i = 0; i < _array1.Length; i++)
        {
            for (int j = 0; j < _array2.Length; j++)
            {
                if (_array1[i] == _array2[j] && !intersection.Contains(_array1[i]))
                {
                    intersection.Add(_array1[i]);
                    break;
                }
            }
        }

        return intersection.ToArray();
    }

    // Tempo: O(n log n + m log m). As cópias evitam modificar as entradas.
    public int[] FindIntersectionTwoPointer()
    {
        int[] sorted1 = (int[])_array1.Clone();
        int[] sorted2 = (int[])_array2.Clone();
        Array.Sort(sorted1);
        Array.Sort(sorted2);

        List<int> intersection = new();
        int i = 0;
        int j = 0;

        while (i < sorted1.Length && j < sorted2.Length)
        {
            if (sorted1[i] == sorted2[j])
            {
                if (intersection.Count == 0 || intersection[^1] != sorted1[i])
                {
                    intersection.Add(sorted1[i]);
                }

                i++;
                j++;
            }
            else if (sorted1[i] < sorted2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        return intersection.ToArray();
    }

    // Tempo médio: O(n + m). Preserva a ordem da primeira ocorrência.
    public int[] FindIntersectionHashSet()
    {
        int[] smaller = _array1.Length <= _array2.Length ? _array1 : _array2;
        int[] larger = _array1.Length <= _array2.Length ? _array2 : _array1;

        HashSet<int> lookup = new(smaller);
        HashSet<int> added = new();
        List<int> result = new();

        foreach (int number in larger)
        {
            if (lookup.Contains(number) && added.Add(number))
            {
                result.Add(number);
            }
        }

        return result.ToArray();
    }
}
