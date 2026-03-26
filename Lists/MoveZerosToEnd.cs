namespace Lists;

/// <summary>
/// Q19: MoveZerosToEnd
/// Task: Move all zeros in a List&lt;int&gt; to the end while maintaining the relative order
/// of non-zero elements using multiple approaches:
/// 1. Brute force: create new list with non-zeros first, then zeros (O(n) time, O(n) space)
/// 2. In-place with write pointer (O(n) time, O(1) space, optimal)
/// 3. LINQ OrderBy for concise approach (O(n log n), not optimal)
/// </summary>
public class MoveZerosToEnd
{
    private List<int> _list;

    public MoveZerosToEnd(List<int> list)
    {
        _list = list;
    }

    // 1️. Simple Approach: New list O(n) time, O(n) space
    // - Collect all non-zero elements first, then append zeros
    public List<int> MoveWithNewList()
    {
        List<int> result = new List<int>();
        int zeroCount = 0;

        foreach (int num in _list)
        {
            if (num != 0)
                result.Add(num);
            else
                zeroCount++;
        }

        for (int i = 0; i < zeroCount; i++)
            result.Add(0);

        return result;
    }

    // 2️. Optimal: In-Place Write Pointer O(n) time, O(1) space
    // - Use a write pointer to place non-zero elements at the front
    // - Fill remaining positions with zeros
    public void MoveInPlace()
    {
        int writeIndex = 0;

        // Move all non-zero elements to the front
        for (int i = 0; i < _list.Count; i++)
        {
            if (_list[i] != 0)
            {
                _list[writeIndex] = _list[i];
                writeIndex++;
            }
        }

        // Fill the remaining positions with zeros
        while (writeIndex < _list.Count)
        {
            _list[writeIndex] = 0;
            writeIndex++;
        }
    }

    // 3️. LINQ Approach O(n log n)
    // - Order by whether element is zero (false sorts before true)
    // - Concise but uses sorting which is overkill
    public List<int> MoveWithLinq()
    {
        return _list.OrderBy(x => x == 0 ? 1 : 0).ToList();
    }

    public void PrintList()
    {
        Console.WriteLine(string.Join(", ", _list));
    }
}
