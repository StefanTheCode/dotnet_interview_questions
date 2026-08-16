namespace Arrays;

/// <summary>
/// Questão 18: redimensionar um array preservando os elementos que couberem no novo tamanho.
///
/// Arrays possuem tamanho fixo. Portanto, todas as abordagens criam outra estrutura:
/// 1. cópia manual — O(min(n, m)) de tempo e O(m) de espaço;
/// 2. Array.Resize — O(min(n, m)) de tempo e O(m) de espaço;
/// 3. List&lt;T&gt; como estrutura dinâmica — O(n + m) de tempo e O(m) de espaço.
///
/// n representa o tamanho original e m o novo tamanho.
/// </summary>
public class ResizeArray
{
    private readonly int[] _array;

    public ResizeArray(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);
        _array = (int[])array.Clone();
    }

    /// <summary>
    /// Cria um novo array e copia manualmente a quantidade de elementos que couber.
    /// </summary>
    public int[] ManualResize(int newSize)
    {
        ValidateNewSize(newSize);

        int[] resized = new int[newSize];
        int lengthToCopy = Math.Min(_array.Length, newSize);

        for (int i = 0; i < lengthToCopy; i++)
            resized[i] = _array[i];

        return resized;
    }

    /// <summary>
    /// Usa Array.Resize sobre uma cópia para preservar o estado interno e o array original.
    /// </summary>
    public int[] BuiltInResize(int newSize)
    {
        ValidateNewSize(newSize);

        int[] resized = (int[])_array.Clone();
        Array.Resize(ref resized, newSize);
        return resized;
    }

    /// <summary>
    /// Converte para List&lt;T&gt;, remove ou acrescenta elementos e retorna outro array.
    /// </summary>
    public int[] ResizeWithList(int newSize)
    {
        ValidateNewSize(newSize);

        List<int> values = new(_array);

        if (newSize < values.Count)
        {
            values.RemoveRange(newSize, values.Count - newSize);
        }
        else
        {
            while (values.Count < newSize)
                values.Add(default);
        }

        return values.ToArray();
    }

    private static void ValidateNewSize(int newSize)
    {
        if (newSize < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(newSize),
                newSize,
                "O novo tamanho não pode ser negativo.");
        }
    }
}
