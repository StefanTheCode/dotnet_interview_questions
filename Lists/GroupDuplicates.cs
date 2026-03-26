namespace Lists;

/// <summary>
/// Q13: GroupDuplicates
/// Task: Group duplicate elements in a List&lt;int&gt; so that identical values appear together
/// using multiple approaches:
/// 1. Brute force: build groups manually (O(n²))
/// 2. Dictionary to collect groups (O(n))
/// 3. LINQ GroupBy for concise functional grouping (O(n))
/// </summary>
public class GroupDuplicates
{
    private List<int> _list;

    public GroupDuplicates(List<int> list)
    {
        _list = list;
    }

    // 1️. Brute Force O(n²)
    // - For each element, scan the list and collect all occurrences
    // - Skip elements already grouped
    public List<List<int>> GroupBruteForce()
    {
        List<List<int>> groups = new List<List<int>>();
        HashSet<int> processed = new HashSet<int>();

        for (int i = 0; i < _list.Count; i++)
        {
            if (processed.Contains(_list[i]))
                continue;

            List<int> group = new List<int>();
            for (int j = 0; j < _list.Count; j++)
            {
                if (_list[j] == _list[i])
                    group.Add(_list[j]);
            }

            groups.Add(group);
            processed.Add(_list[i]);
        }

        return groups;
    }

    // 2️. Dictionary Grouping O(n)
    // - Use a dictionary to map each value to its list of occurrences
    // - Single pass through the list
    public Dictionary<int, List<int>> GroupWithDictionary()
    {
        Dictionary<int, List<int>> groups = new Dictionary<int, List<int>>();

        foreach (int num in _list)
        {
            if (!groups.ContainsKey(num))
                groups[num] = new List<int>();

            groups[num].Add(num);
        }

        return groups;
    }

    // 3️. LINQ GroupBy O(n)
    // - Functional approach that groups by element value
    // - Returns a dictionary of grouped elements
    public Dictionary<int, List<int>> GroupWithLinq()
    {
        return _list
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
}
