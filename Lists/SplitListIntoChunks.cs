namespace Lists;

/// <summary>
/// Q16: SplitListIntoChunks
/// Task: Split a List&lt;int&gt; into smaller chunks of a given size using multiple approaches:
/// 1. Manual loop with index tracking (O(n))
/// 2. GetRange-based slicing (O(n))
/// 3. LINQ Chunk (O(n), available in .NET 6+)
/// </summary>
public class SplitListIntoChunks
{
    private List<int> _list;

    public SplitListIntoChunks(List<int> list)
    {
        _list = list;
    }

    // 1️. Manual Loop O(n)
    // - Track current index and create sub-lists of the given size
    // - Last chunk may be smaller if elements don't divide evenly
    public List<List<int>> SplitManual(int chunkSize)
    {
        List<List<int>> chunks = new List<List<int>>();

        for (int i = 0; i < _list.Count; i += chunkSize)
        {
            List<int> chunk = new List<int>();
            for (int j = i; j < i + chunkSize && j < _list.Count; j++)
            {
                chunk.Add(_list[j]);
            }
            chunks.Add(chunk);
        }

        return chunks;
    }

    // 2️. GetRange-based Slicing O(n)
    // - Use List<T>.GetRange to extract sub-lists
    // - Cleaner than manual index tracking
    public List<List<int>> SplitWithGetRange(int chunkSize)
    {
        List<List<int>> chunks = new List<List<int>>();

        for (int i = 0; i < _list.Count; i += chunkSize)
        {
            int size = Math.Min(chunkSize, _list.Count - i);
            chunks.Add(_list.GetRange(i, size));
        }

        return chunks;
    }

    // 3️. LINQ Chunk O(n) (.NET 6+)
    // - Built-in Chunk method splits into arrays of given size
    // - Most concise approach
    public List<List<int>> SplitWithLinq(int chunkSize)
    {
        return _list
            .Chunk(chunkSize)
            .Select(chunk => chunk.ToList())
            .ToList();
    }
}
