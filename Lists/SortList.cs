namespace Lists;

/// <summary>
/// Q4: ordenar uma <see cref="List{T}"/> de inteiros.
/// Apresenta bubble sort, <see cref="List{T}.Sort()"/> e LINQ.
/// </summary>
public sealed class SortList
{
    private readonly List<int> _list;

    public SortList(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);
        _list = new List<int>(list);
    }

    /// <summary>
    /// Ordena uma cópia com bubble sort e interrupção antecipada.
    /// Tempo: O(n²) no pior caso e O(n) no melhor caso. Espaço: O(n) pela cópia.
    /// </summary>
    public List<int> SortBubble()
    {
        List<int> copy = new(_list);

        for (int i = 0; i < copy.Count - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < copy.Count - 1 - i; j++)
            {
                if (copy[j] <= copy[j + 1])
                    continue;

                (copy[j], copy[j + 1]) = (copy[j + 1], copy[j]);
                swapped = true;
            }

            if (!swapped)
                break;
        }

        return copy;
    }

    /// <summary>
    /// Usa a ordenação nativa sobre uma cópia da lista.
    /// Tempo típico: O(n log n). Espaço adicional: depende da implementação interna.
    /// </summary>
    public List<int> SortBuiltIn()
    {
        List<int> copy = new(_list);
        copy.Sort();
        return copy;
    }

    /// <summary>
    /// Usa LINQ para criar uma nova lista ordenada.
    /// Tempo: O(n log n). Espaço: O(n).
    /// </summary>
    public List<int> SortWithLinq()
    {
        return _list.OrderBy(number => number).ToList();
    }
}
