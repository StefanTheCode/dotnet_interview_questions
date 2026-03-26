namespace Arrays;

/// <summary>
/// Q6: FindMissingNumber
/// Task: Given an array containing numbers from 1 to N with one number missing,
/// find the missing number using multiple approaches:
/// 1. Brute force search (O(n²))
/// 2. Sum formula difference (O(n))
/// 3. XOR method without overflow (O(n), optimal)
/// </summary>
public class FindMissingNumber
{
    private int[] _array;

    public FindMissingNumber(int[] array)
    {
        _array = array;
    }

    // 1️. Brute Force O(n^2)
    // - For every number from 1..N check if it exists in the array
    // - Extremely slow for large arrays
    public int FindMissingBruteForce()
    {
        int n = _array.Length + 1; // Because one number is missing

        for (int num = 1; num <= n; num++)
        {
            bool found = false;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == num)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
                return num; // This is the missing number
        }

        return -1; // Should never reach here if input is valid
    }

    // 2️. Optimal O(n) using Sum Formula
    // - Sum of 1..N = N*(N+1)/2
    // - Subtract the sum of elements to find the missing one
    public int FindMissingUsingSum()
    {
        int n = _array.Length + 1;

        // Expected sum of 1..N
        int expectedSum = n * (n + 1) / 2;

        // Actual sum of array
        int actualSum = 0;
        for (int i = 0; i < _array.Length; i++)
            actualSum += _array[i];

        return expectedSum - actualSum;
    }

    // 3️. Optimal O(n) using XOR (No risk of overflow)
    // - XOR all numbers from 1..N and XOR all numbers in array
    // - The remaining value is the missing number
    public int FindMissingUsingXor()
    {
        int n = _array.Length + 1;
        int xorAll = 0;
        int xorArr = 0;

        // XOR all numbers 1..N
        for (int i = 1; i <= n; i++)
            xorAll ^= i;

        // XOR all numbers in array
        for (int i = 0; i < _array.Length; i++)
            xorArr ^= _array[i];

        // Missing number is the XOR difference
        return xorAll ^ xorArr;
    }
}