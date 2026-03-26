namespace Arrays;

/// <summary>
/// Q15: MaxSubarraySum
/// Task: Find the contiguous subarray with the largest sum using multiple approaches:
/// 1. Brute force with nested loops (O(n²))
/// 2. Kadane's Algorithm for optimal O(n) solution
/// 3. Optional LINQ variation (concise but not optimal for very large arrays)
/// </summary>
public class MaxSubarraySum
{
    private int[] _array;

    public MaxSubarraySum(int[] array)
    {
        _array = array;
    }

    // 1️. Brute Force O(n²)
    // - Compute sum of all subarrays and track the maximum
    // - Very slow for large arrays
    public int FindMaxSumBruteForce()
    {
        int maxSum = int.MinValue;

        for (int i = 0; i < _array.Length; i++)
        {
            int currentSum = 0;
            for (int j = i; j < _array.Length; j++)
            {
                currentSum += _array[j];
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
        int maxSum = _array[0];
        int currentSum = _array[0];

        for (int i = 1; i < _array.Length; i++)
        {
            // Either extend current subarray or start new from current element
            currentSum = Math.Max(_array[i], currentSum + _array[i]);
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }

    // 3️. LINQ One-Liner (for demonstration)
    // - Compute all subarray sums using SelectMany (inefficient for large arrays)
    // - Time: O(n²), Space: O(n²)
    public int FindMaxSumWithLinq()
    {
        return Enumerable.Range(0, _array.Length)
                         .SelectMany(i => Enumerable.Range(i, _array.Length - i)
                                                    .Select(j => _array[i..(j + 1)].Sum()))
                         .Max();
    }
}