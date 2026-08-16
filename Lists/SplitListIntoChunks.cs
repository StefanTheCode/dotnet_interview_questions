namespace Lists;

/// <summary>
/// Q16: SplitListIntoChunks
/// Tarefa: dividir uma lista em blocos menores de tamanho máximo definido.
/// O último bloco pode conter menos elementos.
///
/// Abordagens apresentadas:
/// 1. Laços e controle manual de índices: O(n) de tempo.
/// 2. List&lt;T&gt;.GetRange: O(n) de tempo.
/// 3. Enumerable.Chunk: O(n) de tempo.
/// Todas as abordagens alocam O(n) de espaço para os blocos resultantes.
/// </summary>
public sealed class SplitListIntoChunks
{
    private readonly List<int> _list;

    public SplitListIntoChunks(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);
        _list = new List<int>(list);
    }

    public List<List<int>> SplitManual(int chunkSize)
    {
        ValidateChunkSize(chunkSize);
        List<List<int>> chunks = new();

        for (int start = 0; start < _list.Count; start += chunkSize)
        {
            List<int> chunk = new(Math.Min(chunkSize, _list.Count - start));

            for (int index = start;
                 index < start + chunkSize && index < _list.Count;
                 index++)
            {
                chunk.Add(_list[index]);
            }

            chunks.Add(chunk);
        }

        return chunks;
    }

    public List<List<int>> SplitWithGetRange(int chunkSize)
    {
        ValidateChunkSize(chunkSize);
        List<List<int>> chunks = new();

        for (int start = 0; start < _list.Count; start += chunkSize)
        {
            int currentSize = Math.Min(chunkSize, _list.Count - start);
            chunks.Add(_list.GetRange(start, currentSize));
        }

        return chunks;
    }

    public List<List<int>> SplitWithLinq(int chunkSize)
    {
        ValidateChunkSize(chunkSize);

        return _list
            .Chunk(chunkSize)
            .Select(chunk => chunk.ToList())
            .ToList();
    }

    private static void ValidateChunkSize(int chunkSize)
    {
        if (chunkSize <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(chunkSize),
                chunkSize,
                "O tamanho do bloco deve ser maior que zero.");
        }
    }
}
