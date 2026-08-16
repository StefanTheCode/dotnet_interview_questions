namespace Lists;

/// <summary>
/// Q10: embaralhar os elementos de uma lista.
/// Apresenta seleção aleatória com rejeição e o algoritmo de Fisher–Yates.
/// </summary>
public sealed class ShuffleList
{
    private readonly List<int> _list;
    private readonly Random _random;

    public ShuffleList(List<int> list, Random? random = null)
    {
        ArgumentNullException.ThrowIfNull(list);
        _list = new List<int>(list);
        _random = random ?? Random.Shared;
    }

    /// <summary>
    /// Sorteia índices até selecionar todos sem repetição.
    /// Gera permutações uniformes, mas sofre com colisões à medida que os índices disponíveis diminuem.
    /// Tempo esperado: O(n log n). Espaço: O(n).
    /// </summary>
    public List<int> ShuffleNaive()
    {
        int count = _list.Count;

        if (count == 0)
            return [];

        bool[] used = new bool[count];
        List<int> shuffled = new(count);

        while (shuffled.Count < count)
        {
            int index = _random.Next(count);

            if (used[index])
                continue;

            used[index] = true;
            shuffled.Add(_list[index]);
        }

        return shuffled;
    }

    /// <summary>
    /// Embaralha uma cópia com Fisher–Yates.
    /// Tempo: O(n). Espaço: O(n) pela cópia.
    /// Cada permutação possui a mesma probabilidade quando o gerador é adequado.
    /// </summary>
    public List<int> ShuffleFisherYates()
    {
        List<int> copy = new(_list);

        for (int i = copy.Count - 1; i > 0; i--)
        {
            int randomIndex = _random.Next(i + 1);
            (copy[i], copy[randomIndex]) = (copy[randomIndex], copy[i]);
        }

        return copy;
    }

    /// <summary>
    /// Aplica Fisher–Yates diretamente sobre a lista interna.
    /// Tempo: O(n). Espaço: O(1).
    /// </summary>
    public void ShuffleInPlace()
    {
        for (int i = _list.Count - 1; i > 0; i--)
        {
            int randomIndex = _random.Next(i + 1);
            (_list[i], _list[randomIndex]) = (_list[randomIndex], _list[i]);
        }
    }

    public IReadOnlyList<int> Current => _list;
}
