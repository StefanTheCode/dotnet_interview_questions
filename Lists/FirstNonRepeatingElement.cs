namespace Lists;

/// <summary>
/// Q12: FirstNonRepeatingElement
/// Tarefa: encontrar o primeiro elemento da lista que aparece exatamente uma vez.
///
/// Abordagens apresentadas:
/// 1. Comparar cada elemento com toda a lista: O(n²) de tempo e O(1) de espaço.
/// 2. Contar frequências com Dictionary: O(n) de tempo e O(n) de espaço.
/// 3. Agrupar com LINQ: O(n) de tempo esperado e O(n) de espaço.
/// </summary>
public sealed class FirstNonRepeatingElement
{
    private readonly List<int> _list;

    public FirstNonRepeatingElement(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);
        _list = new List<int>(list);
    }

    public int? FindBruteForce()
    {
        for (int i = 0; i < _list.Count; i++)
        {
            bool isUnique = true;

            for (int j = 0; j < _list.Count; j++)
            {
                if (i != j && _list[i] == _list[j])
                {
                    isUnique = false;
                    break;
                }
            }

            if (isUnique)
            {
                return _list[i];
            }
        }

        return null;
    }

    public int? FindWithDictionary()
    {
        Dictionary<int, int> frequency = new();

        foreach (int number in _list)
        {
            frequency[number] = frequency.GetValueOrDefault(number) + 1;
        }

        foreach (int number in _list)
        {
            if (frequency[number] == 1)
            {
                return number;
            }
        }

        return null;
    }

    public int? FindWithLinq()
    {
        return _list
            .GroupBy(number => number)
            .FirstOrDefault(group => group.Count() == 1)?
            .Key;
    }
}
