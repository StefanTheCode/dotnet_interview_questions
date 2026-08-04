namespace Lists;

/// <summary>
/// Q9: rotacionar uma lista para a direita em K posições.
/// Valores negativos de K representam rotação para a esquerda.
/// </summary>
public sealed class RotateList
{
    private readonly List<int> _list;

    public RotateList(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);
        _list = new List<int>(list);
    }

    /// <summary>
    /// Move os elementos uma posição por vez.
    /// Tempo: O(n × k). Espaço: O(n) pela cópia.
    /// </summary>
    public List<int> RotateBruteForce(int k)
    {
        if (_list.Count == 0)
            return [];

        int normalizedK = NormalizeRotation(k, _list.Count);
        List<int> copy = new(_list);

        for (int step = 0; step < normalizedK; step++)
        {
            int last = copy[^1];

            for (int i = copy.Count - 1; i > 0; i--)
                copy[i] = copy[i - 1];

            copy[0] = last;
        }

        return copy;
    }

    /// <summary>
    /// Calcula diretamente a nova posição de cada elemento.
    /// Tempo: O(n). Espaço: O(n).
    /// </summary>
    public List<int> RotateWithExtraList(int k)
    {
        if (_list.Count == 0)
            return [];

        int n = _list.Count;
        int normalizedK = NormalizeRotation(k, n);
        int[] result = new int[n];

        for (int i = 0; i < n; i++)
            result[(i + normalizedK) % n] = _list[i];

        return [.. result];
    }

    /// <summary>
    /// Aplica três reversões sobre a lista interna.
    /// Tempo: O(n). Espaço: O(1).
    /// </summary>
    public void RotateInPlace(int k)
    {
        if (_list.Count == 0)
            return;

        int n = _list.Count;
        int normalizedK = NormalizeRotation(k, n);

        if (normalizedK == 0)
            return;

        Reverse(0, n - 1);
        Reverse(0, normalizedK - 1);
        Reverse(normalizedK, n - 1);
    }

    public IReadOnlyList<int> Current => _list;

    private static int NormalizeRotation(int k, int count)
    {
        return ((k % count) + count) % count;
    }

    private void Reverse(int start, int end)
    {
        while (start < end)
        {
            (_list[start], _list[end]) = (_list[end], _list[start]);
            start++;
            end--;
        }
    }
}
