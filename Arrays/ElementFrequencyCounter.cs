namespace Arrays;

/// <summary>
/// Q16: ElementFrequencyCounter
/// Task: Count how many times each element appears in an array using multiple approaches:
/// 1. Brute force (O(n²))
/// 2. Dictionary for frequency counting (O(n), optimal)
/// 3. LINQ GroupBy for concise functional solution (O(n), with allocations)
/// </summary>
public class ElementFrequencyCounter
{
    private int[] _array;

    public ElementFrequencyCounter(int[] array)
    {
        _array = array;
    }

    // 1️. Brute Force O(n²)
    // - For each element, count its occurrences by scanning the entire array
    // - Skip elements already processed
    public Dictionary<int, int> CountFrequenciesBruteForce()
    {
        Dictionary<int, int> frequencies = new Dictionary<int, int>();
        HashSet<int> processed = new HashSet<int>();

        for (int i = 0; i < _array.Length; i++)
        {
            if (processed.Contains(_array[i]))
                continue; // Skip if already counted

            int count = 0;
            for (int j = 0; j < _array.Length; j++)
            {
                if (_array[i] == _array[j])
                    count++;
            }

            frequencies[_array[i]] = count;
            processed.Add(_array[i]);
        }

        return frequencies;
    }

    // 2️. Dictionary Frequency Count O(n)
    // - Iterate array once and count occurrences in a dictionary
    public Dictionary<int, int> CountFrequenciesWithDictionary()
    {
        Dictionary<int, int> frequencies = new Dictionary<int, int>();

        foreach (int num in _array)
        {
            frequencies[num] = frequencies.GetValueOrDefault(num, 0) + 1;
        }

        return frequencies;
    }

    // 3️. LINQ GroupBy O(n)
    // - Groups elements and returns counts
    // - Concise, but allocates groupings internally
    public Dictionary<int, int> CountFrequenciesWithLinq()
    {
        return _array
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());
    }
}