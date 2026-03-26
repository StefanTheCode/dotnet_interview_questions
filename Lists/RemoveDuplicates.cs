namespace Lists;

/// <summary>
/// Q1: RemoveDuplicates
/// Task: Remove duplicate elements from a List&lt;int&gt; using multiple approaches:
/// 1. Brute force check against result list (O(n²))
/// 2. Sort and remove adjacent duplicates (O(n log n))
/// 3. HashSet to track unique elements (O(n), optimal)
/// </summary>
public class RemoveDuplicates
{
    private List<int> _list;

    public RemoveDuplicates(List<int> list)
    {
        _list = list;
    }

    // 1️. Worst approach: Brute Force O(n²)
    // - Compare each element with the result list
    // - Add it only if it's not already present
    // - Very slow for large lists
    public List<int> RemoveDuplicatesBruteForce()
    {
        List<int> result = new List<int>();

        for (int i = 0; i < _list.Count; i++)
        {
            bool exists = false;
            for (int j = 0; j < result.Count; j++)
            {
                if (_list[i] == result[j])
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
                result.Add(_list[i]);
        }

        return result;
    }

    // 2️. Better approach: Sorting + Checking Adjacent O(n log n)
    // - Sort the list first
    // - Iterate and add element only if it's different from previous
    public List<int> RemoveDuplicatesWithSorting()
    {
        List<int> sorted = new List<int>(_list);
        sorted.Sort(); // O(n log n)

        List<int> result = new List<int> { sorted[0] };
        for (int i = 1; i < sorted.Count; i++)
        {
            if (sorted[i] != sorted[i - 1])
                result.Add(sorted[i]);
        }

        return result;
    }

    // 3️. Optimal approach: HashSet O(n)
    // - Use a HashSet to store unique elements
    // - Insertion in HashSet is O(1) average
    // - Maintains order of first appearance
    public List<int> RemoveDuplicatesWithHashSet()
    {
        HashSet<int> seen = new HashSet<int>();
        List<int> result = new List<int>();

        foreach (int num in _list)
        {
            if (seen.Add(num)) // Add returns false if already present
                result.Add(num);
        }

        return result;
    }
}
