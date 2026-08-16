namespace Lists;

/// <summary>
/// Q1: remover elementos duplicados de uma <see cref="List{T}"/> de inteiros.
/// Apresenta força bruta, ordenação e <see cref="HashSet{T}"/>.
/// </summary>
public sealed class RemoveDuplicates
{
    private readonly List<int> _list;

    public RemoveDuplicates(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);
        _list = new List<int>(list);
    }

    /// <summary>
    /// Compara cada elemento com o resultado já construído.
    /// Tempo: O(n²). Espaço: O(n).
    /// Preserva a ordem da primeira ocorrência.
    /// </summary>
    public List<int> RemoveDuplicatesBruteForce()
    {
        List<int> result = [];

        foreach (int number in _list)
        {
            bool exists = false;

            foreach (int existing in result)
            {
                if (number != existing)
                    continue;

                exists = true;
                break;
            }

            if (!exists)
                result.Add(number);
        }

        return result;
    }

    /// <summary>
    /// Ordena uma cópia e elimina valores adjacentes repetidos.
    /// Tempo: O(n log n). Espaço: O(n).
    /// A ordem original não é preservada.
    /// </summary>
    public List<int> RemoveDuplicatesWithSorting()
    {
        if (_list.Count == 0)
            return [];

        List<int> sorted = new(_list);
        sorted.Sort();

        List<int> result = [sorted[0]];

        for (int i = 1; i < sorted.Count; i++)
        {
            if (sorted[i] != sorted[i - 1])
                result.Add(sorted[i]);
        }

        return result;
    }

    /// <summary>
    /// Usa um conjunto para identificar valores já encontrados.
    /// Tempo médio: O(n). Espaço: O(n).
    /// Preserva a ordem da primeira ocorrência.
    /// </summary>
    public List<int> RemoveDuplicatesWithHashSet()
    {
        HashSet<int> seen = [];
        List<int> result = [];

        foreach (int number in _list)
        {
            if (seen.Add(number))
                result.Add(number);
        }

        return result;
    }
}
