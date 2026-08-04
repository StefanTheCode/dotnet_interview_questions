namespace Arrays;

/// <summary>
/// Questão 15: contar quantas vezes cada elemento aparece em um array.
///
/// As abordagens apresentadas são:
/// 1. força bruta — O(n²) de tempo e O(u) de espaço;
/// 2. dicionário de frequências — O(n) de tempo médio e O(u) de espaço;
/// 3. agrupamento com LINQ — O(n) de tempo médio e O(u) de espaço.
///
/// A variável u representa a quantidade de valores distintos.
/// </summary>
public class ElementFrequencyCounter
{
    private readonly int[] _array;

    public ElementFrequencyCounter(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);
        _array = (int[])array.Clone();
    }

    /// <summary>
    /// Conta cada valor percorrendo o array inteiro e evita repetir valores processados.
    /// </summary>
    public Dictionary<int, int> CountFrequenciesBruteForce()
    {
        Dictionary<int, int> frequencies = new();
        HashSet<int> processed = new();

        foreach (int candidate in _array)
        {
            if (!processed.Add(candidate))
                continue;

            int count = 0;

            foreach (int number in _array)
            {
                if (number == candidate)
                    count++;
            }

            frequencies[candidate] = count;
        }

        return frequencies;
    }

    /// <summary>
    /// Atualiza a contagem de cada valor em uma única passagem.
    /// </summary>
    public Dictionary<int, int> CountFrequenciesWithDictionary()
    {
        Dictionary<int, int> frequencies = new();

        foreach (int number in _array)
            frequencies[number] = frequencies.GetValueOrDefault(number) + 1;

        return frequencies;
    }

    /// <summary>
    /// Agrupa valores iguais e converte cada agrupamento em uma entrada do dicionário.
    /// </summary>
    public Dictionary<int, int> CountFrequenciesWithLinq() =>
        _array.GroupBy(number => number)
              .ToDictionary(group => group.Key, group => group.Count());
}
