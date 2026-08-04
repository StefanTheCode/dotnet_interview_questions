namespace Lists;

/// <summary>
/// Q19: MoveZerosToEnd
/// Tarefa: mover todos os zeros para o final da lista, preservando a ordem relativa
/// dos elementos diferentes de zero.
///
/// Abordagens apresentadas:
/// 1. Criar uma nova lista: O(n) de tempo e O(n) de espaço.
/// 2. Usar um índice de escrita sobre a lista interna: O(n) de tempo e O(1) de espaço.
/// 3. Usar OrderBy estável: O(n log n) de tempo e O(n) de espaço.
/// </summary>
public sealed class MoveZerosToEnd
{
    private readonly List<int> _list;

    public MoveZerosToEnd(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);
        _list = new List<int>(list);
    }

    public List<int> MoveWithNewList()
    {
        List<int> result = new(_list.Count);
        int zeroCount = 0;

        foreach (int number in _list)
        {
            if (number == 0)
            {
                zeroCount++;
            }
            else
            {
                result.Add(number);
            }
        }

        for (int index = 0; index < zeroCount; index++)
        {
            result.Add(0);
        }

        return result;
    }

    /// <summary>
    /// Modifica somente a cópia interna da lista recebida no construtor.
    /// </summary>
    public void MoveInPlace()
    {
        int writeIndex = 0;

        for (int readIndex = 0; readIndex < _list.Count; readIndex++)
        {
            if (_list[readIndex] != 0)
            {
                _list[writeIndex] = _list[readIndex];
                writeIndex++;
            }
        }

        while (writeIndex < _list.Count)
        {
            _list[writeIndex] = 0;
            writeIndex++;
        }
    }

    public List<int> MoveWithLinq()
    {
        return _list.OrderBy(number => number == 0).ToList();
    }

    public IReadOnlyList<int> GetCurrentList()
    {
        return _list.AsReadOnly();
    }
}
