namespace Arrays;

/// <summary>
/// Questão 11: encontrar o elemento majoritário de um array.
///
/// Um elemento é majoritário quando aparece mais de n / 2 vezes.
/// As abordagens apresentadas são:
/// 1. força bruta, contando cada elemento — O(n²) de tempo e O(1) de espaço;
/// 2. dicionário de frequências — O(n) de tempo e O(n) de espaço;
/// 3. algoritmo de votação de Boyer–Moore — O(n) de tempo e O(1) de espaço.
/// </summary>
public class MajorityElementFinder
{
    private readonly int[] _array;

    public MajorityElementFinder(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);
        _array = (int[])array.Clone();
    }

    /// <summary>
    /// Conta a ocorrência de cada candidato percorrendo todo o array.
    /// </summary>
    public int? FindMajorityBruteForce()
    {
        int threshold = _array.Length / 2;

        for (int i = 0; i < _array.Length; i++)
        {
            int count = 0;

            for (int j = 0; j < _array.Length; j++)
            {
                if (_array[i] == _array[j])
                    count++;
            }

            if (count > threshold)
                return _array[i];
        }

        return null;
    }

    /// <summary>
    /// Registra a frequência dos valores em um dicionário.
    /// </summary>
    public int? FindMajorityWithDictionary()
    {
        int threshold = _array.Length / 2;
        Dictionary<int, int> frequencies = new();

        foreach (int number in _array)
        {
            int frequency = frequencies.GetValueOrDefault(number) + 1;
            frequencies[number] = frequency;

            if (frequency > threshold)
                return number;
        }

        return null;
    }

    /// <summary>
    /// Seleciona um candidato pelo algoritmo de Boyer–Moore e depois confirma
    /// se ele realmente aparece mais de n / 2 vezes.
    /// </summary>
    public int? FindMajorityBoyerMoore()
    {
        if (_array.Length == 0)
            return null;

        int candidate = 0;
        int count = 0;

        foreach (int number in _array)
        {
            if (count == 0)
                candidate = number;

            count += number == candidate ? 1 : -1;
        }

        int occurrences = 0;

        foreach (int number in _array)
        {
            if (number == candidate)
                occurrences++;
        }

        return occurrences > _array.Length / 2 ? candidate : null;
    }
}
