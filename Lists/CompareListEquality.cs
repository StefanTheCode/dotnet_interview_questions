namespace Lists;

/// <summary>
/// Q20: CompareListEquality
/// Task: Compare two List&lt;int&gt; collections for equality (same elements, same order or same content)
/// using multiple approaches:
/// 1. Manual element-by-element comparison (O(n))
/// 2. SequenceEqual for order-sensitive equality (O(n))
/// 3. Sort and compare for order-insensitive content equality (O(n log n))
/// </summary>
public class CompareListEquality
{
    private List<int> _list1;
    private List<int> _list2;

    public CompareListEquality(List<int> list1, List<int> list2)
    {
        _list1 = list1;
        _list2 = list2;
    }

    // 1️. Manual Comparison O(n)
    // - Check lengths first, then compare element by element
    // - Order-sensitive: [1,2,3] != [3,2,1]
    public bool AreEqualManual()
    {
        if (_list1.Count != _list2.Count)
            return false;

        for (int i = 0; i < _list1.Count; i++)
        {
            if (_list1[i] != _list2[i])
                return false;
        }

        return true;
    }

    // 2️. SequenceEqual O(n)
    // - Built-in LINQ method for order-sensitive comparison
    // - Concise and idiomatic
    public bool AreEqualSequence()
    {
        return _list1.SequenceEqual(_list2);
    }

    // 3️. Content Equality (Order-Insensitive) O(n log n)
    // - Sort both lists and compare sequentially
    // - [1,2,3] == [3,2,1] returns true
    public bool AreEqualContentWithSorting()
    {
        if (_list1.Count != _list2.Count)
            return false;

        List<int> sorted1 = new List<int>(_list1);
        List<int> sorted2 = new List<int>(_list2);
        sorted1.Sort();
        sorted2.Sort();

        return sorted1.SequenceEqual(sorted2);
    }

    // 4️. Content Equality with Dictionary O(n)
    // - Count element frequencies in both lists and compare
    // - Most efficient for order-insensitive comparison
    public bool AreEqualContentWithDictionary()
    {
        if (_list1.Count != _list2.Count)
            return false;

        Dictionary<int, int> frequency = new Dictionary<int, int>();

        foreach (int num in _list1)
            frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;

        foreach (int num in _list2)
        {
            if (!frequency.ContainsKey(num))
                return false;

            frequency[num]--;
            if (frequency[num] == 0)
                frequency.Remove(num);
        }

        return frequency.Count == 0;
    }
}
