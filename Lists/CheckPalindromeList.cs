namespace Lists;

/// <summary>
/// Q11: CheckPalindromeList
/// Tarefa: determinar se uma <see cref="List{T}"/> de inteiros é um palíndromo,
/// isto é, se possui a mesma sequência quando lida do início para o fim e vice-versa.
///
/// Abordagens apresentadas:
/// 1. Criar uma cópia invertida: O(n) de tempo e O(n) de espaço.
/// 2. Usar LINQ com Reverse e SequenceEqual: O(n) de tempo e O(n) de espaço auxiliar.
/// 3. Comparar pelas extremidades com dois ponteiros: O(n) de tempo e O(1) de espaço.
/// </summary>
public sealed class CheckPalindromeList
{
    private readonly List<int> _list;

    public CheckPalindromeList(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);
        _list = new List<int>(list);
    }

    /// <summary>
    /// Cria uma nova lista invertida e compara cada posição.
    /// </summary>
    public bool IsPalindromeWithCopy()
    {
        List<int> reversed = new(_list.Count);

        for (int i = _list.Count - 1; i >= 0; i--)
        {
            reversed.Add(_list[i]);
        }

        for (int i = 0; i < _list.Count; i++)
        {
            if (_list[i] != reversed[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Compara a sequência original com sua enumeração invertida.
    /// </summary>
    public bool IsPalindromeWithLinq()
    {
        return _list.SequenceEqual(_list.AsEnumerable().Reverse());
    }

    /// <summary>
    /// Compara pares de elementos das extremidades em direção ao centro.
    /// </summary>
    public bool IsPalindromeTwoPointer()
    {
        int left = 0;
        int right = _list.Count - 1;

        while (left < right)
        {
            if (_list[left] != _list[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }
}
