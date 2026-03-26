namespace Arrays;

/// <summary>
/// Q8: FirstNonRepeatingElement
/// Task: Find the first element in the array that does not repeat using multiple approaches:
/// 1. Brute force comparison for each element (O(n²))
/// 2. Dictionary frequency counting (O(n))
/// 3. LINQ GroupBy for a concise solution (O(n), less control)
/// </summary>
public class FirstNonRepeatingElement
{
    private int[] _array;

    public FirstNonRepeatingElement(int[] array)
    {
        _array = array;
    }

    // 1️⃣ Brute Force O(n^2)
    // - For each element, check the entire array to see if it repeats
    // - Returns the first element that has no duplicates
    public int? FindBruteForce()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            bool isUnique = true;
            for (int j = 0; j < _array.Length; j++)
            {
                if (i != j && _array[i] == _array[j])
                {
                    isUnique = false;
                    break;
                }
            }

            if (isUnique)
                return _array[i];
        }

        return null; // No unique element
    }

    // 2️⃣ Better Approach: Dictionary for Frequencies O(n)
    // - Count occurrences of each element
    // - Iterate again to find the first with count == 1
    public int? FindWithDictionary()
    {
        Dictionary<int, int> frequency = new Dictionary<int, int>();

        // Count frequencies
        foreach (int num in _array)
        {
            frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;
        }

        // Find first with count == 1
        foreach (int num in _array)
        {
            if (frequency[num] == 1)
                return num;
        }

        return null;
    }

    // 3️⃣ LINQ Compact Solution O(n) (less flexible)
    // - Groups by element and selects the first group with only 1 element
    public int? FindWithLinq()
    {
        return _array
            .GroupBy(x => x)
            .FirstOrDefault(g => g.Count() == 1)?
            .Key;
    }
}