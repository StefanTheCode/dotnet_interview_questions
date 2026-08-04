namespace Lists;

/// <summary>
/// Q7: combinar duas listas de inteiros.
/// </summary>
public sealed class MergeTwoLists
{
    private readonly List<int> _list1;
    private readonly List<int> _list2;

    public MergeTwoLists(List<int> list1, List<int> list2)
    {
        ArgumentNullException.ThrowIfNull(list1);
        ArgumentNullException.ThrowIfNull(list2);

        _list1 = new List<int>(list1);
        _list2 = new List<int>(list2);
    }

    /// <summary>
    /// Concatena as listas com <see cref="List{T}.AddRange(IEnumerable{T})"/>.
    /// Tempo: O(n + m). Espaço: O(n + m).
    /// Não ordena o resultado.
    /// </summary>
    public List<int> MergeWithAddRange()
    {
        List<int> merged = new(_list1.Count + _list2.Count);
        merged.AddRange(_list1);
        merged.AddRange(_list2);
        return merged;
    }

    /// <summary>
    /// Ordena cópias das entradas e depois realiza a etapa de intercalação do merge sort.
    /// Tempo: O(n log n + m log m). Espaço: O(n + m).
    /// Se as entradas já estivessem ordenadas, apenas a intercalação seria O(n + m).
    /// </summary>
    public List<int> MergeSorted()
    {
        List<int> sorted1 = new(_list1);
        List<int> sorted2 = new(_list2);
        sorted1.Sort();
        sorted2.Sort();

        List<int> merged = new(sorted1.Count + sorted2.Count);
        int i = 0;
        int j = 0;

        while (i < sorted1.Count && j < sorted2.Count)
        {
            if (sorted1[i] <= sorted2[j])
                merged.Add(sorted1[i++]);
            else
                merged.Add(sorted2[j++]);
        }

        while (i < sorted1.Count)
            merged.Add(sorted1[i++]);

        while (j < sorted2.Count)
            merged.Add(sorted2[j++]);

        return merged;
    }

    /// <summary>
    /// Concatena as sequências com LINQ e materializa uma nova lista.
    /// Tempo: O(n + m). Espaço: O(n + m).
    /// </summary>
    public List<int> MergeWithLinq()
    {
        return _list1.Concat(_list2).ToList();
    }
}
