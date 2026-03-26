namespace Lists;

/// <summary>
/// Q18: MaxContiguousSum
/// Task: Find the contiguous sublist with the largest sum using multiple approaches:
/// 1. Brute force with nested loops (O(n²))
/// 2. Kadane's Algorithm for optimal O(n) solution
/// 3. LINQ variation (concise but not optimal for very large lists)
/// </summary>
public class MaxContiguousSum
{
    private List<int> _list;

    public MaxContiguousSum(List<int> list)
    {
        _list = list;
    }

    // 1️. Brute Force O(n²)
    // - Compute sum of all sublists and track the maximum
    // - Very slow for large lists
    public int FindMaxSumBruteForce()
    {
        int maxSum = int.MinValue;

        for (int i = 0; i < _list.Count; i++)
        {
            int currentSum = 0;
            for (int j = i; j < _list.Count; j++)
            {
                currentSum += _list[j];
                if (currentSum > maxSum)
                    maxSum = currentSum;
            }
        }

        return maxSum;
    }

    // 2️. Kadane's Algorithm O(n)
    // - Keep track of current sum and reset if it becomes negative
    // - Optimal approach with O(1) space
    public int FindMaxSumKadane()
    {
        int maxSum = _list[0];
        int currentSum = _list[0];

        for (int i = 1; i < _list.Count; i++)
        {
            currentSum = Math.Max(_list[i], currentSum + _list[i]);
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }

    // 3️. LINQ One-Liner (for demonstration)
    // - Compute all sublist sums using SelectMany (inefficient for large lists)
    // - Time: O(n²), Space: O(n²)
    public int FindMaxSumWithLinq()
    {
        return Enumerable.Range(0, _list.Count)
                         .SelectMany(i => Enumerable.Range(i, _list.Count - i)
                                                    .Select(j => _list.GetRange(i, j - i + 1).Sum()))
                         .Max();
    }
}
