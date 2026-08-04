namespace Arrays;

/// <summary>
/// Questão 17: embaralhar os elementos de um array.
///
/// As abordagens apresentadas são:
/// 1. seleção aleatória com rejeição de índices repetidos — custo esperado O(n log n);
/// 2. Fisher–Yates sobre uma cópia — O(n) de tempo e O(n) de espaço;
/// 3. Fisher–Yates in-place sobre o estado interno — O(n) de tempo e O(1) de espaço extra.
///
/// A primeira abordagem também produz uma permutação uniforme, mas fica progressivamente
/// mais lenta à medida que restam poucos índices ainda não selecionados.
/// </summary>
public class ShuffleArray
{
    private readonly int[] _array;
    private readonly Random _random;

    public ShuffleArray(int[] array, Random? random = null)
    {
        ArgumentNullException.ThrowIfNull(array);
        _array = (int[])array.Clone();
        _random = random ?? Random.Shared;
    }

    /// <summary>
    /// Sorteia índices até preencher todas as posições, rejeitando índices já utilizados.
    /// O pior caso não possui limite determinístico de tentativas.
    /// </summary>
    public int[] ShuffleNaive()
    {
        bool[] used = new bool[_array.Length];
        int[] shuffled = new int[_array.Length];
        int count = 0;

        while (count < _array.Length)
        {
            int index = _random.Next(_array.Length);

            if (used[index])
                continue;

            shuffled[count++] = _array[index];
            used[index] = true;
        }

        return shuffled;
    }

    /// <summary>
    /// Embaralha uma cópia usando a forma clássica do algoritmo de Fisher–Yates.
    /// </summary>
    public int[] ShuffleFisherYates()
    {
        int[] shuffled = (int[])_array.Clone();

        for (int i = shuffled.Length - 1; i > 0; i--)
        {
            int randomIndex = _random.Next(i + 1);
            (shuffled[i], shuffled[randomIndex]) = (shuffled[randomIndex], shuffled[i]);
        }

        return shuffled;
    }

    /// <summary>
    /// Embaralha diretamente o array interno da instância.
    /// O array fornecido ao construtor permanece inalterado porque foi clonado.
    /// </summary>
    public void ShuffleInPlace()
    {
        for (int i = _array.Length - 1; i > 0; i--)
        {
            int randomIndex = _random.Next(i + 1);
            (_array[i], _array[randomIndex]) = (_array[randomIndex], _array[i]);
        }
    }

    public int[] ToArray() => (int[])_array.Clone();

    public void PrintArray() => Console.WriteLine(string.Join(", ", _array));
}
