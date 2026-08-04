namespace Arrays;

/// <summary>
/// Questão 13: localizar um valor em um array ordenado.
///
/// As abordagens apresentadas são:
/// 1. busca linear — O(n) de tempo;
/// 2. busca binária iterativa — O(log n) de tempo;
/// 3. busca binária recursiva — O(log n) de tempo e O(log n) de pilha.
///
/// O array deve estar ordenado em ordem crescente. Quando há valores duplicados,
/// as buscas binárias podem retornar qualquer uma das ocorrências.
/// </summary>
public class BinarySearchArray
{
    private readonly int[] _array;

    public BinarySearchArray(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (!IsSortedAscending(array))
        {
            throw new ArgumentException(
                "O array deve estar ordenado em ordem crescente.",
                nameof(array));
        }

        _array = (int[])array.Clone();
    }

    /// <summary>
    /// Percorre os elementos sequencialmente até encontrar o valor-alvo.
    /// </summary>
    public int LinearSearch(int target)
    {
        for (int i = 0; i < _array.Length; i++)
        {
            if (_array[i] == target)
                return i;
        }

        return -1;
    }

    /// <summary>
    /// Reduz o intervalo de busca pela metade a cada iteração.
    /// </summary>
    public int BinarySearchIterative(int target)
    {
        int left = 0;
        int right = _array.Length - 1;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;

            if (_array[middle] == target)
                return middle;

            if (_array[middle] < target)
                left = middle + 1;
            else
                right = middle - 1;
        }

        return -1;
    }

    /// <summary>
    /// Aplica a mesma divisão de intervalo usando chamadas recursivas.
    /// </summary>
    public int BinarySearchRecursive(int target) =>
        BinarySearchRecursive(target, 0, _array.Length - 1);

    private int BinarySearchRecursive(int target, int left, int right)
    {
        if (left > right)
            return -1;

        int middle = left + (right - left) / 2;

        if (_array[middle] == target)
            return middle;

        return _array[middle] < target
            ? BinarySearchRecursive(target, middle + 1, right)
            : BinarySearchRecursive(target, left, middle - 1);
    }

    private static bool IsSortedAscending(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i - 1])
                return false;
        }

        return true;
    }
}
