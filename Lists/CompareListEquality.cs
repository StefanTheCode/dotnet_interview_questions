namespace Lists;

/// <summary>
/// Q20: CompareListEquality
/// Tarefa: comparar duas listas considerando ordem e multiplicidade dos elementos.
///
/// Abordagens apresentadas:
/// 1. Comparação manual sensível à ordem: O(n) de tempo.
/// 2. SequenceEqual sensível à ordem: O(n) de tempo.
/// 3. Ordenar cópias para ignorar a ordem: O(n log n) de tempo e O(n) de espaço.
/// 4. Comparar frequências para ignorar a ordem: O(n) de tempo esperado e O(n) de espaço.
/// </summary>
public sealed class CompareListEquality
{
    private readonly List<int> _list1;
    private readonly List<int> _list2;

    public CompareListEquality(List<int> list1, List<int> list2)
    {
        ArgumentNullException.ThrowIfNull(list1);
        ArgumentNullException.ThrowIfNull(list2);

        _list1 = new List<int>(list1);
        _list2 = new List<int>(list2);
    }

    public bool AreEqualManual()
    {
        if (_list1.Count != _list2.Count)
        {
            return false;
        }

        for (int index = 0; index < _list1.Count; index++)
        {
            if (_list1[index] != _list2[index])
            {
                return false;
            }
        }

        return true;
    }

    public bool AreEqualSequence()
    {
        return _list1.SequenceEqual(_list2);
    }

    public bool AreEqualContentWithSorting()
    {
        if (_list1.Count != _list2.Count)
        {
            return false;
        }

        List<int> sorted1 = new(_list1);
        List<int> sorted2 = new(_list2);
        sorted1.Sort();
        sorted2.Sort();

        return sorted1.SequenceEqual(sorted2);
    }

    public bool AreEqualContentWithDictionary()
    {
        if (_list1.Count != _list2.Count)
        {
            return false;
        }

        Dictionary<int, int> frequency = new();

        foreach (int number in _list1)
        {
            frequency[number] = frequency.GetValueOrDefault(number) + 1;
        }

        foreach (int number in _list2)
        {
            if (!frequency.TryGetValue(number, out int count))
            {
                return false;
            }

            if (count == 1)
            {
                frequency.Remove(number);
            }
            else
            {
                frequency[number] = count - 1;
            }
        }

        return frequency.Count == 0;
    }
}
