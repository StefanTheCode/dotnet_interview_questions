namespace Lists;

/// <summary>
/// Q2: FindSecondLargest
/// Task: Find the second largest element in a List&lt;int&gt; using multiple approaches:
/// 1. Sort descending and pick second element (O(n log n))
/// 2. Two-pass scan: find max, then find max excluding it (O(n))
/// 3. Single-pass tracking top two values (O(n), optimal)
/// </summary>
public class FindSecondLargest
{
    private List<int> _list;

    public FindSecondLargest(List<int> list)
    {
        _list = list;
    }

    // 1️. Simple approach: Sort and pick second O(n log n)
    // - Sort descending and return second distinct element
    // - Extra space for sorted copy
    public int? FindWithSorting()
    {
        List<int> sorted = new List<int>(_list);
        sorted.Sort();
        sorted.Reverse();

        // Find second distinct value
        for (int i = 1; i < sorted.Count; i++)
        {
            if (sorted[i] != sorted[0])
                return sorted[i];
        }

        return null; // All elements are the same
    }

    // 2️. Two-pass scan O(n)
    // - First pass: find the maximum
    // - Second pass: find the largest element that is not equal to the maximum
    public int? FindWithTwoPass()
    {
        int max = int.MinValue;
        foreach (int num in _list)
        {
            if (num > max)
                max = num;
        }

        int secondMax = int.MinValue;
        bool found = false;
        foreach (int num in _list)
        {
            if (num != max && num > secondMax)
            {
                secondMax = num;
                found = true;
            }
        }

        return found ? secondMax : null;
    }

    // 3️. Optimal: Single-pass tracking two values O(n)
    // - Track first and second largest in one iteration
    // - Most efficient approach
    public int? FindWithSinglePass()
    {
        if (_list.Count < 2) return null;

        int first = int.MinValue;
        int second = int.MinValue;

        foreach (int num in _list)
        {
            if (num > first)
            {
                second = first;
                first = num;
            }
            else if (num > second && num != first)
            {
                second = num;
            }
        }

        return second == int.MinValue ? null : second;
    }
}
