namespace Lists;

/// <summary>
/// Q10: ShuffleList
/// Task: Randomly shuffle the elements of a List&lt;int&gt; using multiple approaches:
/// 1. Naive approach using Random selection with potential duplicates (not perfectly uniform)
/// 2. Fisher-Yates algorithm iterative (O(n), optimal and uniform)
/// 3. Fisher-Yates using in-place swaps with Random object (O(n), optimal)
/// </summary>
public class ShuffleList
{
    private List<int> _list;
    private Random _random;

    public ShuffleList(List<int> list)
    {
        _list = new List<int>(list); // Clone to avoid modifying original
        _random = new Random();
    }

    // 1️. Naive Shuffle O(n²)
    // - Keep picking random indices and swapping if not already used
    // - Not perfectly uniform and slower
    public List<int> ShuffleNaive()
    {
        int n = _list.Count;
        bool[] used = new bool[n];
        List<int> shuffled = new List<int>(new int[n]);
        int count = 0;

        while (count < n)
        {
            int idx = _random.Next(n);
            if (!used[idx])
            {
                shuffled[count++] = _list[idx];
                used[idx] = true;
            }
        }

        return shuffled;
    }

    // 2️. Fisher-Yates Algorithm O(n)
    // - Swap each element with a random element from remaining unshuffled part
    // - Produces uniform random permutations
    public List<int> ShuffleFisherYates()
    {
        List<int> copy = new List<int>(_list);
        int n = copy.Count;

        for (int i = 0; i < n; i++)
        {
            int j = _random.Next(i, n);
            (copy[i], copy[j]) = (copy[j], copy[i]);
        }

        return copy;
    }

    // 3️. Fisher-Yates In-Place O(n)
    // - Shuffle the list itself without creating a copy
    // - Most memory-efficient approach
    public void ShuffleInPlace()
    {
        for (int i = 0; i < _list.Count; i++)
        {
            int j = _random.Next(i, _list.Count);
            (_list[i], _list[j]) = (_list[j], _list[i]);
        }
    }

    public void PrintList()
    {
        Console.WriteLine(string.Join(", ", _list));
    }
}
