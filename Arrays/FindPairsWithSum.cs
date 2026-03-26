namespace Arrays;

/// <summary>
/// Q13: FindPairsWithSum
/// Task: Find all unique pairs of elements in an array that add up to a given target sum using multiple approaches:
/// 1. Brute force nested loops (O(n²))
/// 2. HashSet for complement lookup (O(n), optimal)
/// 3. Sorting + Two-pointer technique (O(n log n), O(1) extra space)
/// </summary>
public class FindPairsWithSum
{
    private int[] _array;

    public FindPairsWithSum(int[] array)
    {
        _array = array;
    }

    // 1️. Brute Force O(n²)
    // - Check every pair of elements and add to result if they sum to target
    public List<(int, int)> FindPairsBruteForce(int target)
    {
        List<(int, int)> result = new List<(int, int)>();

        for (int i = 0; i < _array.Length; i++)
        {
            for (int j = i + 1; j < _array.Length; j++)
            {
                if (_array[i] + _array[j] == target)
                    result.Add((_array[i], _array[j]));
            }
        }

        return result;
    }

    // 2️. HashSet O(n) time, O(n) space
    // - Store seen numbers
    // - Check if target - current number exists in the set
    public List<(int, int)> FindPairsWithHashSet(int target)
    {
        HashSet<int> seen = new HashSet<int>();
        HashSet<(int, int)> uniquePairs = new HashSet<(int, int)>();

        foreach (int num in _array)
        {
            int complement = target - num;

            if (seen.Contains(complement))
            {
                // Sort the tuple to avoid duplicate pairs like (2,3) and (3,2)
                var pair = num < complement ? (num, complement) : (complement, num);
                uniquePairs.Add(pair);
            }

            seen.Add(num);
        }

        return uniquePairs.ToList();
    }

    // 3️. Sorting + Two-Pointer O(n log n)
    // - Sort array and use left/right pointers to find pairs
    // - Advantage: O(1) extra space, returns sorted pairs
    public List<(int, int)> FindPairsTwoPointer(int target)
    {
        int[] sortedArray = (int[])_array.Clone();
        Array.Sort(sortedArray);

        int left = 0;
        int right = sortedArray.Length - 1;
        List<(int, int)> result = new List<(int, int)>();

        while (left < right)
        {
            int sum = sortedArray[left] + sortedArray[right];

            if (sum == target)
            {
                result.Add((sortedArray[left], sortedArray[right]));
                left++;
                right--;

                // Skip duplicates
                while (left < right && sortedArray[left] == sortedArray[left - 1]) left++;
                while (left < right && sortedArray[right] == sortedArray[right + 1]) right--;
            }
            else if (sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return result;
    }
}