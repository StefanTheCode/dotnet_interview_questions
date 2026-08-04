namespace Lists;

/// <summary>
/// Q8: encontrar o único número ausente em uma sequência de 1 até N.
/// A entrada deve conter valores distintos dentro desse intervalo.
/// </summary>
public sealed class FindMissingNumbers
{
    private readonly List<int> _list;

    public FindMissingNumbers(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);
        _list = new List<int>(list);
        ValidateInput();
    }

    /// <summary>
    /// Procura cada valor esperado dentro da lista.
    /// Tempo: O(n²). Espaço: O(1), além da validação feita na construção.
    /// </summary>
    public int FindMissingBruteForce()
    {
        int n = _list.Count + 1;

        for (int expected = 1; expected <= n; expected++)
        {
            bool found = false;

            foreach (int number in _list)
            {
                if (number != expected)
                    continue;

                found = true;
                break;
            }

            if (!found)
                return expected;
        }

        throw new InvalidOperationException("A entrada não contém exatamente um número ausente.");
    }

    /// <summary>
    /// Subtrai a soma real da soma esperada de 1 até N.
    /// Tempo: O(n). Espaço: O(1).
    /// Usa <see cref="long"/> nos cálculos intermediários para reduzir risco de overflow.
    /// </summary>
    public int FindMissingUsingSum()
    {
        long n = _list.Count + 1L;
        long expectedSum = n * (n + 1) / 2;
        long actualSum = 0;

        foreach (int number in _list)
            actualSum += number;

        return checked((int)(expectedSum - actualSum));
    }

    /// <summary>
    /// Aplica XOR aos valores esperados e aos valores recebidos.
    /// Tempo: O(n). Espaço: O(1).
    /// </summary>
    public int FindMissingUsingXor()
    {
        int n = _list.Count + 1;
        int xorAll = 0;
        int xorList = 0;

        for (int number = 1; number <= n; number++)
            xorAll ^= number;

        foreach (int number in _list)
            xorList ^= number;

        return xorAll ^ xorList;
    }

    private void ValidateInput()
    {
        int n = _list.Count + 1;
        HashSet<int> seen = [];

        foreach (int number in _list)
        {
            if (number < 1 || number > n)
                throw new ArgumentException($"Todos os valores devem estar entre 1 e {n}.", nameof(_list));

            if (!seen.Add(number))
                throw new ArgumentException("A lista não pode conter valores duplicados.", nameof(_list));
        }
    }
}
