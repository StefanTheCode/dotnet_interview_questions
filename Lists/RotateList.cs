namespace Lists;

/// <summary>
/// Q9: RotateList
/// Task: Given a List&lt;int&gt;, rotate the list to the right by K steps using multiple approaches:
/// 1. Brute force rotation by shifting elements one step at a time (O(n*k), worst)
/// 2. Extra list to copy rotated values (O(n) time, O(n) space)
/// 3. In-place reversal method using three reversals (O(n) time, O(1) space, optimal)
/// </summary>
public class RotateList
{
    private List<int> _list;

    public RotateList(List<int> list)
    {
        _list = list;
    }

    // 1️. Brute Force O(n*k)
    // - Shift elements to the right one step at a time, repeat k times
    // - Very slow for large k
    public List<int> RotateBruteForce(int k)
    {
        int n = _list.Count;
        k %= n;

        List<int> copy = new List<int>(_list);

        for (int step = 0; step < k; step++)
        {
            int last = copy[n - 1];
            for (int i = n - 1; i > 0; i--)
                copy[i] = copy[i - 1];
            copy[0] = last;
        }

        return copy;
    }

    // 2️. Better Approach: Extra List O(n) time, O(n) space
    // - Compute new position for each element directly
    public List<int> RotateWithExtraList(int k)
    {
        int n = _list.Count;
        k %= n;

        List<int> result = new List<int>(new int[n]);

        for (int i = 0; i < n; i++)
        {
            int newIndex = (i + k) % n;
            result[newIndex] = _list[i];
        }

        return result;
    }

    // 3️. Optimal Approach: In-Place Reversal O(n) time, O(1) space
    // - Reverse the whole list
    // - Reverse first k elements
    // - Reverse remaining n-k elements
    public void RotateInPlace(int k)
    {
        int n = _list.Count;
        k %= n;

        Reverse(0, n - 1);
        Reverse(0, k - 1);
        Reverse(k, n - 1);
    }

    // Helper to reverse a segment of the list in-place
    private void Reverse(int start, int end)
    {
        while (start < end)
        {
            int temp = _list[start];
            _list[start] = _list[end];
            _list[end] = temp;
            start++;
            end--;
        }
    }

    public void PrintList()
    {
        Console.WriteLine(string.Join(", ", _list));
    }
}
