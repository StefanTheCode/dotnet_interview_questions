namespace Lists;

/// <summary>
/// Q3: ReverseList
/// Task: Reverse a List&lt;int&gt; using multiple approaches:
/// 1. Create a new reversed list manually (O(n) time, O(n) space)
/// 2. LINQ Reverse (O(n) time, O(n) space)
/// 3. In-place two-pointer swap (O(n) time, O(1) space, optimal)
/// </summary>
public class ReverseList
{
    private List<int> _list;

    public ReverseList(List<int> list)
    {
        _list = list;
    }

    // 1️. Simple approach: Manual new list
    // Time: O(n), Space: O(n)
    public List<int> ReverseWithNewList()
    {
        List<int> reversed = new List<int>(_list.Count);

        for (int i = _list.Count - 1; i >= 0; i--)
            reversed.Add(_list[i]);

        return reversed;
    }

    // 2️. LINQ approach: Reverse and ToList
    // Time: O(n), Space: O(n)
    public List<int> ReverseWithLinq()
    {
        return Enumerable.Reverse(_list).ToList();
    }

    // 3️. Optimal approach: In-place two-pointer swap
    // Time: O(n), Space: O(1)
    public void ReverseInPlace()
    {
        int left = 0, right = _list.Count - 1;

        while (left < right)
        {
            int temp = _list[left];
            _list[left] = _list[right];
            _list[right] = temp;

            left++;
            right--;
        }
    }

    public void PrintList()
    {
        Console.WriteLine(string.Join(", ", _list));
    }
}
