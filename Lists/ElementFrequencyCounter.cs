namespace Lists;

/// <summary>
/// Q5: ElementFrequencyCounter
/// Task: Count how many times each element appears in a List&lt;int&gt; using multiple approaches:
/// 1. Brute force (O(n²))
/// 2. Dictionary for frequency counting (O(n), optimal)
/// 3. LINQ GroupBy for concise functional solution (O(n), with allocations)
/// </summary>
public class ElementFrequencyCounter
{
    private List<int> _list;

    public ElementFrequencyCounter(List<int> list)
    {
        _list = list;
    }

    // 1️. Brute Force O(n²)
    // - For each element, count its occurrences by scanning the entire list
    // - Skip elements already processed
    public Dictionary<int, int> CountFrequenciesBruteForce()
    {
        Dictionary<int, int> frequencies = new Dictionary<int, int>();
        HashSet<int> processed = new HashSet<int>();

        for (int i = 0; i < _list.Count; i++)
        {
            if (processed.Contains(_list[i]))
                continue;

            int count = 0;
            for (int j = 0; j < _list.Count; j++)
            {
                if (_list[i] == _list[j])
                    count++;
            }

            frequencies[_list[i]] = count;
            processed.Add(_list[i]);
        }

        return frequencies;
    }

    // 2️. Dictionary Frequency Count O(n)
    // - Iterate list once and count occurrences in a dictionary
    public Dictionary<int, int> CountFrequenciesWithDictionary()
    {
        Dictionary<int, int> frequencies = new Dictionary<int, int>();

        foreach (int num in _list)
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
        return _list
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());
    }
}
