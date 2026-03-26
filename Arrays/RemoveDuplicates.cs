namespace Arrays;

/// <summary>
/// Q4: RemoveDuplicates
/// Task: Remove duplicate elements from an integer array using multiple approaches:
/// 1. Brute force check against result list (O(n²))
/// 2. Sort and remove adjacent duplicates (O(n log n))
/// 3. HashSet to track unique elements (O(n), optimal)
/// </summary>
public class RemoveDuplicates
{
    private int[] _array;

    public RemoveDuplicates(int[] array)
    {
        _array = array;
    }

    // 1️. Worst approach: Brute Force O(n^2)
    // - Compare each element with the result list
    // - Add it only if it's not already present
    // - Very slow for large arrays
    public int[] RemoveDuplicatesBruteForce()
    {
        List<int> result = new List<int>();

        for (int i = 0; i < _array.Length; i++)
        {
            bool exists = false;
            for (int j = 0; j < result.Count; j++)
            {
                if (_array[i] == result[j])
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
                result.Add(_array[i]);
        }

        return result.ToArray();
    }

    // 2️. Better approach: Sorting + Checking Adjacent O(n log n)
    // - Sort the array first
    // - Iterate and add element only if it's different from previous
    public int[] RemoveDuplicatesWithSorting()
    {
        Array.Sort(_array); // O(n log n)
        List<int> result = new List<int>();

        result.Add(_array[0]);
        for (int i = 1; i < _array.Length; i++)
        {
            if (_array[i] != _array[i - 1]) // check adjacent
            {
                result.Add(_array[i]);
            }
        }

        return result.ToArray();
    }

    // 3️. Optimal approach: HashSet O(n)
    // - Use a HashSet to store unique elements
    // - Insertion in HashSet is O(1) average
    // - Maintains order of first appearance
    public int[] RemoveDuplicatesWithHashSet()
    {
        HashSet<int> seen = new HashSet<int>();
        List<int> result = new List<int>();

        foreach (int num in _array)
        {
            if (seen.Add(num)) // Add returns false if already present
            {
                result.Add(num);
            }
        }

        return result.ToArray();
    }
}