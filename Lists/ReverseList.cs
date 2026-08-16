namespace Lists;

/// <summary>
/// Q3: inverter uma <see cref="List{T}"/> de inteiros.
/// </summary>
public sealed class ReverseList
{
    private readonly List<int> _list;

    public ReverseList(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);
        _list = new List<int>(list);
    }

    /// <summary>
    /// Percorre a lista do fim para o início e cria um novo resultado.
    /// Tempo: O(n). Espaço: O(n).
    /// </summary>
    public List<int> ReverseWithNewList()
    {
        List<int> reversed = new(_list.Count);

        for (int i = _list.Count - 1; i >= 0; i--)
            reversed.Add(_list[i]);

        return reversed;
    }

    /// <summary>
    /// Usa LINQ para produzir uma nova lista invertida.
    /// Tempo: O(n). Espaço: O(n).
    /// </summary>
    public List<int> ReverseWithLinq()
    {
        return _list.AsEnumerable().Reverse().ToList();
    }

    /// <summary>
    /// Troca elementos simétricos na lista interna.
    /// Tempo: O(n). Espaço: O(1).
    /// </summary>
    public void ReverseInPlace()
    {
        int left = 0;
        int right = _list.Count - 1;

        while (left < right)
        {
            (_list[left], _list[right]) = (_list[right], _list[left]);
            left++;
            right--;
        }
    }

    public IReadOnlyList<int> Current => _list;

    public void PrintList()
    {
        Console.WriteLine(string.Join(", ", _list));
    }
}
