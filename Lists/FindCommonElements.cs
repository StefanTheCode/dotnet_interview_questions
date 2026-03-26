namespace Lists;

/// <summary>
/// Q6: FindCommonElements
/// Task: Find common elements between two List&lt;int&gt; collections using multiple approaches:
/// 1. Brute force nested loops (O(n*m))
/// 2. Sort both lists and use two-pointer method (O(n log n + m log m))
/// 3. HashSet lookup for O(n+m) optimal solution
/// </summary>
public class FindCommonElements
{
    private List<int> _list1;
    private List<int> _list2;

    public FindCommonElements(List<int> list1, List<int> list2)
    {
        _list1 = list1;
        _list2 = list2;
    }

    // 1️. Brute Force O(n*m)
    // - Compare each element of list1 with each element of list2
    // - Add to result if a match is found and it's not already added
    public List<int> FindCommonBruteForce()
    {
        List<int> common = new List<int>();

        for (int i = 0; i < _list1.Count; i++)
        {
            for (int j = 0; j < _list2.Count; j++)
            {
                if (_list1[i] == _list2[j] && !common.Contains(_list1[i]))
                {
                    common.Add(_list1[i]);
                    break;
                }
            }
        }

        return common;
    }

    // 2️. Better Approach: Sorting + Two-Pointer O(n log n + m log m)
    // - Sort both lists
    // - Move two pointers to find matching elements
    public List<int> FindCommonTwoPointer()
    {
        List<int> sorted1 = new List<int>(_list1);
        List<int> sorted2 = new List<int>(_list2);
        sorted1.Sort();
        sorted2.Sort();

        List<int> common = new List<int>();
        int i = 0, j = 0;

        while (i < sorted1.Count && j < sorted2.Count)
        {
            if (sorted1[i] == sorted2[j])
            {
                if (common.Count == 0 || common[^1] != sorted1[i])
                    common.Add(sorted1[i]);

                i++;
                j++;
            }
            else if (sorted1[i] < sorted2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        return common;
    }

    // 3️. Optimal Approach: HashSet O(n + m)
    // - Store elements of smaller list in a HashSet for O(1) lookup
    // - Iterate over the other list and add common elements
    public List<int> FindCommonHashSet()
    {
        List<int> small = _list1.Count < _list2.Count ? _list1 : _list2;
        List<int> large = _list1.Count < _list2.Count ? _list2 : _list1;

        HashSet<int> set = new HashSet<int>(small);
        HashSet<int> resultSet = new HashSet<int>();

        foreach (int num in large)
        {
            if (set.Contains(num))
                resultSet.Add(num);
        }

        return resultSet.ToList();
    }
}
