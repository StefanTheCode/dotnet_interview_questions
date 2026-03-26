namespace Lists;

/// <summary>
/// Q15: FindPairsWithSum
/// Task: Find all unique pairs of elements in a List&lt;int&gt; that add up to a given target sum
/// using multiple approaches:
/// 1. Brute force nested loops (O(n²))
/// 2. HashSet for complement lookup (O(n), optimal)
/// 3. Sorting + Two-pointer technique (O(n log n), O(1) extra space)
/// </summary>
public class FindPairsWithSum
{
    private List<int> _list;

    public FindPairsWithSum(List<int> list)
    {
        _list = list;
    }

    // 1️. Brute Force O(n²)
    // - Check every pair of elements and add to result if they sum to target
    public List<(int, int)> FindPairsBruteForce(int target)
    {
        List<(int, int)> result = new List<(int, int)>();

        for (int i = 0; i < _list.Count; i++)
        {
            for (int j = i + 1; j < _list.Count; j++)
            {
                if (_list[i] + _list[j] == target)
                    result.Add((_list[i], _list[j]));
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

        foreach (int num in _list)
        {
            int complement = target - num;

            if (seen.Contains(complement))
            {
                var pair = num < complement ? (num, complement) : (complement, num);
                uniquePairs.Add(pair);
            }

            seen.Add(num);
        }

        return uniquePairs.ToList();
    }

    // 3️. Sorting + Two-Pointer O(n log n)
    // - Sort list and use left/right pointers to find pairs
    // - Advantage: O(1) extra space, returns sorted pairs
    public List<(int, int)> FindPairsTwoPointer(int target)
    {
        List<int> sorted = new List<int>(_list);
        sorted.Sort();

        int left = 0;
        int right = sorted.Count - 1;
        List<(int, int)> result = new List<(int, int)>();

        while (left < right)
        {
            int sum = sorted[left] + sorted[right];

            if (sum == target)
            {
                result.Add((sorted[left], sorted[right]));
                left++;
                right--;

                while (left < right && sorted[left] == sorted[left - 1]) left++;
                while (left < right && sorted[right] == sorted[right + 1]) right--;
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
