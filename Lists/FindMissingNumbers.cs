namespace Lists;

/// <summary>
/// Q8: FindMissingNumbers
/// Task: Given a List&lt;int&gt; containing numbers from 1 to N with one number missing,
/// find the missing number using multiple approaches:
/// 1. Brute force search (O(n²))
/// 2. Sum formula difference (O(n))
/// 3. XOR method without overflow (O(n), optimal)
/// </summary>
public class FindMissingNumbers
{
    private List<int> _list;

    public FindMissingNumbers(List<int> list)
    {
        _list = list;
    }

    // 1️. Brute Force O(n²)
    // - For every number from 1..N check if it exists in the list
    // - Extremely slow for large lists
    public int FindMissingBruteForce()
    {
        int n = _list.Count + 1; // Because one number is missing

        for (int num = 1; num <= n; num++)
        {
            bool found = false;
            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i] == num)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
                return num;
        }

        return -1; // Should never reach here if input is valid
    }

    // 2️. Optimal O(n) using Sum Formula
    // - Sum of 1..N = N*(N+1)/2
    // - Subtract the sum of elements to find the missing one
    public int FindMissingUsingSum()
    {
        int n = _list.Count + 1;
        int expectedSum = n * (n + 1) / 2;

        int actualSum = 0;
        foreach (int num in _list)
            actualSum += num;

        return expectedSum - actualSum;
    }

    // 3️. Optimal O(n) using XOR (No risk of overflow)
    // - XOR all numbers from 1..N and XOR all numbers in list
    // - The remaining value is the missing number
    public int FindMissingUsingXor()
    {
        int n = _list.Count + 1;
        int xorAll = 0;
        int xorList = 0;

        for (int i = 1; i <= n; i++)
            xorAll ^= i;

        foreach (int num in _list)
            xorList ^= num;

        return xorAll ^ xorList;
    }
}
