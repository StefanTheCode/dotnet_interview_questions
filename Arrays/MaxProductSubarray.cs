namespace Arrays;

/// <summary>
/// Q3: MaxProductSubarray
/// Task: Find the contiguous subarray within a one-dimensional array of numbers
/// which has the largest product. Implement multiple approaches:
/// 1. Brute force with 3 loops (O(n³))
/// 2. Double loop with running product (O(n²))
/// 3. Kadane's variation tracking max & min product (O(n), optimal)
/// </summary>
public class MaxProductSubarray
{
    private int[] _array;

    public MaxProductSubarray(int[] array)
    {
        _array = array;
    }

    // 1. Worst approach: Brute Force (O(n^3))
    // Check product of every subarray using 3 loops
    public int MaxProductBruteForce()
    {
        int maxProduct = int.MinValue;
        for (int i = 0; i < _array.Length; i++)
        {
            for (int j = i; j < _array.Length; j++)
            {
                int product = 1;
                for (int k = i; k <= j; k++)
                    product *= _array[k];

                maxProduct = Math.Max(maxProduct, product);
            }
        }
        return maxProduct;
    }

    // 2. Better approach: O(n^2) using 2 loops (still bad)
    // Compute running product instead of recalculating every time
    public int MaxProductDoubleLoop()
    {
        int maxProduct = int.MinValue;
        for (int i = 0; i < _array.Length; i++)
        {
            int product = 1;
            for (int j = i; j < _array.Length; j++)
            {
                product *= _array[j];
                maxProduct = Math.Max(maxProduct, product);
            }
        }
        return maxProduct;
    }

    // 3️. Optimal approach: Kadane's variation (O(n))
    // Track current max and min to handle negative numbers
    public int MaxProductKadane()
    {
        int maxSoFar = _array[0];
        int minSoFar = _array[0];
        int result = _array[0];

        for (int i = 1; i < _array.Length; i++)
        {
            int current = _array[i];
            if (current < 0)
            {
                // Swap because negative flips max/min
                int temp = maxSoFar;
                maxSoFar = minSoFar;
                minSoFar = temp;
            }

            maxSoFar = Math.Max(current, maxSoFar * current);
            minSoFar = Math.Min(current, minSoFar * current);

            result = Math.Max(result, maxSoFar);
        }

        return result;
    }
}