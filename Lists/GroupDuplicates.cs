namespace Lists;

/// <summary>
/// Q13: GroupDuplicates
/// Tarefa: agrupar valores iguais para que cada grupo contenha todas as ocorrências
/// de um elemento da lista.
///
/// Abordagens apresentadas:
/// 1. Construir os grupos manualmente: O(n²) de tempo.
/// 2. Usar Dictionary em uma única passagem: O(n) de tempo esperado.
/// 3. Usar LINQ GroupBy: O(n) de tempo esperado.
/// </summary>
public sealed class GroupDuplicates
{
    private readonly List<int> _list;

    public GroupDuplicates(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);
        _list = new List<int>(list);
    }

    /// <summary>
    /// Mantém a ordem da primeira ocorrência de cada valor.
    /// </summary>
    public List<List<int>> GroupBruteForce()
    {
        List<List<int>> groups = new();
        HashSet<int> processed = new();

        for (int i = 0; i < _list.Count; i++)
        {
            int current = _list[i];

            if (!processed.Add(current))
            {
                continue;
            }

            List<int> group = new();

            for (int j = 0; j < _list.Count; j++)
            {
                if (_list[j] == current)
                {
                    group.Add(current);
                }
            }

            groups.Add(group);
        }

        return groups;
    }

    public Dictionary<int, List<int>> GroupWithDictionary()
    {
        Dictionary<int, List<int>> groups = new();

        foreach (int number in _list)
        {
            if (!groups.TryGetValue(number, out List<int>? group))
            {
                group = new List<int>();
                groups[number] = group;
            }

            group.Add(number);
        }

        return groups;
    }

    public Dictionary<int, List<int>> GroupWithLinq()
    {
        return _list
            .GroupBy(number => number)
            .ToDictionary(group => group.Key, group => group.ToList());
    }
}
