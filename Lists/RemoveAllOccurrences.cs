namespace Lists;

/// <summary>
/// Q14: RemoveAllOccurrences
/// Tarefa: remover todas as ocorrências de um valor específico de uma lista.
///
/// Abordagens apresentadas:
/// 1. Construir uma nova lista manualmente: O(n) de tempo e O(n) de espaço.
/// 2. Usar List&lt;T&gt;.RemoveAll: O(n) de tempo e modificação da lista interna.
/// 3. Filtrar com LINQ Where: O(n) de tempo e O(n) de espaço.
/// </summary>
public sealed class RemoveAllOccurrences
{
    private readonly List<int> _list;

    public RemoveAllOccurrences(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);
        _list = new List<int>(list);
    }

    public List<int> RemoveManual(int value)
    {
        List<int> result = new(_list.Count);

        foreach (int number in _list)
        {
            if (number != value)
            {
                result.Add(number);
            }
        }

        return result;
    }

    /// <summary>
    /// Modifica a cópia interna mantida pela classe e retorna a quantidade removida.
    /// A lista recebida no construtor não é alterada.
    /// </summary>
    public int RemoveWithRemoveAll(int value)
    {
        return _list.RemoveAll(number => number == value);
    }

    public List<int> RemoveWithLinq(int value)
    {
        return _list.Where(number => number != value).ToList();
    }

    public IReadOnlyList<int> GetCurrentList()
    {
        return _list.AsReadOnly();
    }
}
