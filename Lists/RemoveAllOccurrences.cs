namespace Lists;

/// <summary>
/// Q14: RemoveAllOccurrences
/// Task: Remove all occurrences of a specific value from a List&lt;int&gt; using multiple approaches:
/// 1. Brute force: create new list excluding target value (O(n))
/// 2. In-place removal using RemoveAll (O(n))
/// 3. LINQ Where filter for functional style (O(n))
/// </summary>
public class RemoveAllOccurrences
{
    private List<int> _list;

    public RemoveAllOccurrences(List<int> list)
    {
        _list = list;
    }

    // 1️. Manual Approach: Build new list O(n)
    // - Iterate and add only elements that don't match the target value
    public List<int> RemoveManual(int value)
    {
        List<int> result = new List<int>();

        foreach (int num in _list)
        {
            if (num != value)
                result.Add(num);
        }

        return result;
    }

    // 2️. Built-in RemoveAll O(n)
    // - Uses List<T>.RemoveAll with a predicate
    // - Modifies the list in-place
    // - Returns the number of removed elements
    public int RemoveWithRemoveAll(int value)
    {
        return _list.RemoveAll(x => x == value);
    }

    // 3️. LINQ Where Filter O(n)
    // - Functional approach that creates a new filtered list
    // - Does not modify the original list
    public List<int> RemoveWithLinq(int value)
    {
        return _list.Where(x => x != value).ToList();
    }
}
