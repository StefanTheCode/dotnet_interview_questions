namespace Lists;

/// <summary>
/// Q5: contar quantas vezes cada elemento aparece em uma lista.
/// </summary>
public sealed class ElementFrequencyCounter
{
    private readonly List<int> _list;

    public ElementFrequencyCounter(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);
        _list = new List<int>(list);
    }

    /// <summary>
    /// Conta cada valor percorrendo novamente toda a lista.
    /// Tempo: O(n²). Espaço: O(u), em que u é a quantidade de valores distintos.
    /// </summary>
    public Dictionary<int, int> CountFrequenciesBruteForce()
    {
        Dictionary<int, int> frequencies = [];
        HashSet<int> processed = [];

        foreach (int number in _list)
        {
            if (!processed.Add(number))
                continue;

            int count = 0;
            foreach (int candidate in _list)
            {
                if (candidate == number)
                    count++;
            }

            frequencies[number] = count;
        }

        return frequencies;
    }

    /// <summary>
    /// Atualiza um dicionário em uma única passagem.
    /// Tempo médio: O(n). Espaço: O(u).
    /// </summary>
    public Dictionary<int, int> CountFrequenciesWithDictionary()
    {
        Dictionary<int, int> frequencies = [];

        foreach (int number in _list)
            frequencies[number] = frequencies.GetValueOrDefault(number) + 1;

        return frequencies;
    }

    /// <summary>
    /// Agrupa os valores com LINQ e converte os grupos em dicionário.
    /// Tempo: O(n). Espaço: O(n), considerando os agrupamentos intermediários.
    /// </summary>
    public Dictionary<int, int> CountFrequenciesWithLinq()
    {
        return _list
            .GroupBy(number => number)
            .ToDictionary(group => group.Key, group => group.Count());
    }
}
