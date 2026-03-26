namespace Lists;

/// <summary>
/// Q17: FlattenNestedLists
/// Task: Convert a List of List&lt;int&gt; (nested lists) into a single flat List&lt;int&gt;
/// using multiple approaches:
/// 1. Brute force with nested loops (O(n*m) time, O(n*m) space)
/// 2. LINQ SelectMany for concise functional flattening (O(n*m) time, O(n*m) space)
/// 3. AddRange-based flattening for maximum clarity (O(n*m) time, O(n*m) space)
/// </summary>
public class FlattenNestedLists
{
    private List<List<int>> _nestedList;

    public FlattenNestedLists(List<List<int>> nestedList)
    {
        _nestedList = nestedList;
    }

    // 1️. Brute Force: Nested loops to flatten
    // - Iterate each inner list and copy elements into a new flat list
    // - Time: O(n*m)
    // - Space: O(n*m)
    public List<int> FlattenWithNestedLoops()
    {
        List<int> result = new List<int>();

        for (int i = 0; i < _nestedList.Count; i++)
        {
            for (int j = 0; j < _nestedList[i].Count; j++)
            {
                result.Add(_nestedList[i][j]);
            }
        }

        return result;
    }

    // 2️. LINQ SelectMany
    // - One-liner functional approach
    // - Internally still iterates through all elements
    // - Time: O(n*m), Space: O(n*m)
    public List<int> FlattenWithLinq()
    {
        return _nestedList.SelectMany(inner => inner).ToList();
    }

    // 3️. AddRange-based Flattening
    // - Iterate outer list and use AddRange for each inner list
    // - Clear and idiomatic C# approach
    public List<int> FlattenWithAddRange()
    {
        List<int> result = new List<int>();

        foreach (var inner in _nestedList)
        {
            result.AddRange(inner);
        }

        return result;
    }
}
