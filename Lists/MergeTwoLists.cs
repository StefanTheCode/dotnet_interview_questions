namespace Lists;

/// <summary>
/// Q7: MergeTwoLists
/// Task: Merge two List&lt;int&gt; collections into one using multiple approaches:
/// 1. Simple concatenation with AddRange (O(n+m))
/// 2. Merge two sorted lists into a single sorted list (O(n+m), like merge sort step)
/// 3. LINQ Concat for functional style (O(n+m))
/// </summary>
public class MergeTwoLists
{
    private List<int> _list1;
    private List<int> _list2;

    public MergeTwoLists(List<int> list1, List<int> list2)
    {
        _list1 = list1;
        _list2 = list2;
    }

    // 1️. Simple Concatenation O(n+m)
    // - Use AddRange to append all elements of list2 to a copy of list1
    // - Does not maintain sorted order
    public List<int> MergeWithAddRange()
    {
        List<int> merged = new List<int>(_list1);
        merged.AddRange(_list2);
        return merged;
    }

    // 2️. Merge Sorted Lists O(n+m)
    // - Both lists must be sorted beforehand
    // - Uses two-pointer technique like the merge step in merge sort
    // - Result is a sorted merged list
    public List<int> MergeSorted()
    {
        List<int> sorted1 = new List<int>(_list1);
        List<int> sorted2 = new List<int>(_list2);
        sorted1.Sort();
        sorted2.Sort();

        List<int> merged = new List<int>(sorted1.Count + sorted2.Count);
        int i = 0, j = 0;

        while (i < sorted1.Count && j < sorted2.Count)
        {
            if (sorted1[i] <= sorted2[j])
                merged.Add(sorted1[i++]);
            else
                merged.Add(sorted2[j++]);
        }

        while (i < sorted1.Count) merged.Add(sorted1[i++]);
        while (j < sorted2.Count) merged.Add(sorted2[j++]);

        return merged;
    }

    // 3️. LINQ Concat O(n+m)
    // - Functional one-liner
    // - Creates a new list from both sequences
    public List<int> MergeWithLinq()
    {
        return _list1.Concat(_list2).ToList();
    }
}
