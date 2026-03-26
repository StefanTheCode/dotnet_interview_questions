namespace Arrays;

/// <summary>
/// Q10: CheckPalindromeArray
/// Task: Determine whether a given integer array is a palindrome (reads the same forwards and backwards)
/// using multiple approaches:
/// 1. Compare by reversing into a new array (O(n) time, O(n) space)
/// 2. LINQ Reverse with SequenceEqual (O(n) time, O(n) space)
/// 3. In-place two-pointer comparison (O(n) time, O(1) space, optimal)
/// </summary>
public class CheckPalindromeArray
{
    private int[] _array;

    public CheckPalindromeArray(int[] array)
    {
        _array = array;
    }

    // 1️. Simple Approach: Create a reversed copy and compare
    // - Time: O(n)
    // - Space: O(n) for the reversed array
    public bool IsPalindromeWithCopy()
    {
        int[] reversed = new int[_array.Length];

        for (int i = 0; i < _array.Length; i++)
            reversed[i] = _array[_array.Length - 1 - i];

        for (int i = 0; i < _array.Length; i++)
            if (_array[i] != reversed[i])
                return false;

        return true;
    }

    // 2️. LINQ Approach: SequenceEqual with Reverse
    // - Time: O(n)
    // - Space: O(n) for the reversed IEnumerable
    public bool IsPalindromeWithLinq()
    {
        return _array.SequenceEqual(_array.Reverse());
    }

    // 3️. Optimal Approach: Two-Pointer In-Place Comparison
    // - Time: O(n)
    // - Space: O(1)
    // - Compares first and last elements moving towards the center
    public bool IsPalindromeTwoPointer()
    {
        int left = 0;
        int right = _array.Length - 1;

        while (left < right)
        {
            if (_array[left] != _array[right])
                return false;

            left++;
            right--;
        }

        return true;
    }
}
