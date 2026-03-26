namespace Lists;

/// <summary>
/// Q11: CheckPalindromeList
/// Task: Determine whether a given List&lt;int&gt; is a palindrome (reads the same forwards and backwards)
/// using multiple approaches:
/// 1. Compare by reversing into a new list (O(n) time, O(n) space)
/// 2. LINQ Reverse with SequenceEqual (O(n) time, O(n) space)
/// 3. In-place two-pointer comparison (O(n) time, O(1) space, optimal)
/// </summary>
public class CheckPalindromeList
{
    private List<int> _list;

    public CheckPalindromeList(List<int> list)
    {
        _list = list;
    }

    // 1️. Simple Approach: Create a reversed copy and compare
    // - Time: O(n)
    // - Space: O(n) for the reversed list
    public bool IsPalindromeWithCopy()
    {
        List<int> reversed = new List<int>(_list.Count);

        for (int i = _list.Count - 1; i >= 0; i--)
            reversed.Add(_list[i]);

        for (int i = 0; i < _list.Count; i++)
            if (_list[i] != reversed[i])
                return false;

        return true;
    }

    // 2️. LINQ Approach: SequenceEqual with Reverse
    // - Time: O(n)
    // - Space: O(n) for the reversed IEnumerable
    public bool IsPalindromeWithLinq()
    {
        return _list.SequenceEqual(Enumerable.Reverse(_list));
    }

    // 3️. Optimal Approach: Two-Pointer In-Place Comparison
    // - Time: O(n)
    // - Space: O(1)
    // - Compares first and last elements moving towards the center
    public bool IsPalindromeTwoPointer()
    {
        int left = 0;
        int right = _list.Count - 1;

        while (left < right)
        {
            if (_list[left] != _list[right])
                return false;

            left++;
            right--;
        }

        return true;
    }
}
