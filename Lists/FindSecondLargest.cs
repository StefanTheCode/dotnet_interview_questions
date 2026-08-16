namespace Lists;

/// <summary>
/// Q2: encontrar o segundo maior valor distinto de uma lista de inteiros.
/// </summary>
public sealed class FindSecondLargest
{
    private readonly List<int> _list;

    public FindSecondLargest(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);
        _list = new List<int>(list);
    }

    /// <summary>
    /// Ordena uma cópia em ordem decrescente e encontra o segundo valor distinto.
    /// Tempo: O(n log n). Espaço: O(n).
    /// </summary>
    public int? FindWithSorting()
    {
        if (_list.Count < 2)
            return null;

        List<int> sorted = new(_list);
        sorted.Sort((left, right) => right.CompareTo(left));

        for (int i = 1; i < sorted.Count; i++)
        {
            if (sorted[i] != sorted[0])
                return sorted[i];
        }

        return null;
    }

    /// <summary>
    /// Primeiro encontra o maior valor; depois procura o maior valor diferente dele.
    /// Tempo: O(n). Espaço: O(1).
    /// </summary>
    public int? FindWithTwoPass()
    {
        if (_list.Count < 2)
            return null;

        int maximum = _list[0];
        foreach (int number in _list)
            maximum = Math.Max(maximum, number);

        int? secondLargest = null;
        foreach (int number in _list)
        {
            if (number == maximum)
                continue;

            if (secondLargest is null || number > secondLargest.Value)
                secondLargest = number;
        }

        return secondLargest;
    }

    /// <summary>
    /// Mantém os dois maiores valores distintos em uma única passagem.
    /// Tempo: O(n). Espaço: O(1).
    /// </summary>
    public int? FindWithSinglePass()
    {
        int? largest = null;
        int? secondLargest = null;

        foreach (int number in _list)
        {
            if (largest is null || number > largest.Value)
            {
                if (largest != number)
                    secondLargest = largest;

                largest = number;
            }
            else if (number < largest.Value &&
                     (secondLargest is null || number > secondLargest.Value))
            {
                secondLargest = number;
            }
        }

        return secondLargest;
    }
}
