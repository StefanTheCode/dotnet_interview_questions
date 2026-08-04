namespace Lists;

/// <summary>
/// Q6: encontrar os valores distintos presentes em duas listas.
/// </summary>
public sealed class FindCommonElements
{
    private readonly List<int> _list1;
    private readonly List<int> _list2;

    public FindCommonElements(List<int> list1, List<int> list2)
    {
        ArgumentNullException.ThrowIfNull(list1);
        ArgumentNullException.ThrowIfNull(list2);

        _list1 = new List<int>(list1);
        _list2 = new List<int>(list2);
    }

    /// <summary>
    /// Compara cada elemento da primeira lista com todos os elementos da segunda.
    /// Tempo: O(n × m), desconsiderando a verificação dos duplicados no resultado.
    /// Espaço: O(u).
    /// </summary>
    public List<int> FindCommonBruteForce()
    {
        List<int> common = [];
        HashSet<int> added = [];

        foreach (int left in _list1)
        {
            foreach (int right in _list2)
            {
                if (left != right || !added.Add(left))
                    continue;

                common.Add(left);
                break;
            }
        }

        return common;
    }

    /// <summary>
    /// Ordena cópias e usa dois ponteiros.
    /// Tempo: O(n log n + m log m). Espaço: O(n + m).
    /// O resultado é crescente e não contém duplicados.
    /// </summary>
    public List<int> FindCommonTwoPointer()
    {
        List<int> sorted1 = new(_list1);
        List<int> sorted2 = new(_list2);
        sorted1.Sort();
        sorted2.Sort();

        List<int> common = [];
        int i = 0;
        int j = 0;

        while (i < sorted1.Count && j < sorted2.Count)
        {
            if (sorted1[i] == sorted2[j])
            {
                if (common.Count == 0 || common[^1] != sorted1[i])
                    common.Add(sorted1[i]);

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

        return common;
    }

    /// <summary>
    /// Armazena a segunda lista em um conjunto e percorre a primeira.
    /// Tempo médio: O(n + m). Espaço: O(m + u).
    /// Preserva a ordem da primeira ocorrência na primeira lista.
    /// </summary>
    public List<int> FindCommonHashSet()
    {
        HashSet<int> valuesInSecondList = new(_list2);
        HashSet<int> added = [];
        List<int> result = [];

        foreach (int number in _list1)
        {
            if (valuesInSecondList.Contains(number) && added.Add(number))
                result.Add(number);
        }

        return result;
    }
}
