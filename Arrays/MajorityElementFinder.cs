namespace Arrays;

/// <summary>
/// Q12: MajorityElementFinder
/// Task: Find the element that appears more than n/2 times in an array (majority element) using multiple approaches:
/// 1. Brute force count for each element (O(n²))
/// 2. Dictionary frequency count (O(n) time, O(n) space)
/// 3. Boyer-Moore Voting Algorithm (O(n) time, O(1) space, optimal)
/// </summary>
public class MajorityElementFinder
{
    private int[] _array;

    public MajorityElementFinder(int[] array)
    {
        _array = array;
    }

    // 1️. Brute Force O(n²)
    // - For each element, count how many times it appears in the array
    // - Return the one that appears > n/2 times
    public int? FindMajorityBruteForce()
    {
        int n = _array.Length;

        for (int i = 0; i < n; i++)
        {
            int count = 0;
            for (int j = 0; j < n; j++)
            {
                if (_array[i] == _array[j])
                    count++;
            }

            if (count > n / 2)
                return _array[i];
        }

        return null; // No majority element
    }

    // 2️. Dictionary Frequency Count O(n)
    // - Count frequencies of each element
    // - Check which has count > n/2
    public int? FindMajorityWithDictionary()
    {
        Dictionary<int, int> frequency = new Dictionary<int, int>();

        foreach (int num in _array)
        {
            frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;
        }

        int threshold = _array.Length / 2;
        foreach (var kvp in frequency)
        {
            if (kvp.Value > threshold)
                return kvp.Key;
        }

        return null;
    }

    // 3️. Boyer-Moore Voting Algorithm O(n), O(1) space
    // - Candidate selection and verification
    // - Step 1: Find a candidate
    // - Step 2: Verify if it appears > n/2 times
    public int? FindMajorityBoyerMoore()
    {
        // Step 1: Find candidate
        int candidate = 0;
        int count = 0;

        foreach (int num in _array)
        {
            if (count == 0)
            {
                candidate = num;
                count = 1;
            }
            else if (num == candidate)
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        // Step 2: Verify candidate
        int occurrences = 0;
        foreach (int num in _array)
        {
            if (num == candidate)
                occurrences++;
        }

        return occurrences > _array.Length / 2 ? candidate : (int?)null;
    }
}