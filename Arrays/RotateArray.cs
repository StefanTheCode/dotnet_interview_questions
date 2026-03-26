namespace Arrays;

/// <summary>
/// Q9: RotateArray
/// Task: Given an integer array, rotate the array to the right by K steps using multiple approaches:
/// 1. Brute force rotation by shifting elements one step at a time (O(n*k), worst)
/// 2. Extra array to copy rotated values (O(n) time, O(n) space)
/// 3. In-place reversal method using three reversals (O(n) time, O(1) space, optimal)
/// </summary>
public class RotateArray
{
    private int[] _array;

    public RotateArray(int[] array)
    {
        _array = array;
    }

    // 1️. Brute Force O(n*k)
    // - Shift elements to the right one step at a time, repeat k times
    // - Very slow for large k
    public int[] RotateBruteForce(int k)
    {
        int n = _array.Length;
        k %= n; // Ensure k is within range

        int[] arrCopy = (int[])_array.Clone();

        for (int step = 0; step < k; step++)
        {
            // Take last element
            int last = arrCopy[n - 1];

            // Shift all elements to the right
            for (int i = n - 1; i > 0; i--)
                arrCopy[i] = arrCopy[i - 1];

            // Place last element at the start
            arrCopy[0] = last;
        }

        return arrCopy;
    }

    // 2️. Better Approach: Extra Array O(n) time, O(n) space
    // - Compute new position for each element directly
    public int[] RotateWithExtraArray(int k)
    {
        int n = _array.Length;
        k %= n;

        int[] result = new int[n];

        for (int i = 0; i < n; i++)
        {
            int newIndex = (i + k) % n;
            result[newIndex] = _array[i];
        }

        return result;
    }

    // 3️. Optimal Approach: In-Place Reversal O(n) time, O(1) space
    // - Reverse the whole array
    // - Reverse first k elements
    // - Reverse remaining n-k elements
    public void RotateInPlace(int k)
    {
        int n = _array.Length;
        k %= n;

        Reverse(0, n - 1);
        Reverse(0, k - 1);
        Reverse(k, n - 1);
    }

    // Helper to reverse a segment of the array in-place
    private void Reverse(int start, int end)
    {
        while (start < end)
        {
            int temp = _array[start];
            _array[start] = _array[end];
            _array[end] = temp;
            start++;
            end--;
        }
    }

    public void PrintArray()
    {
        Console.WriteLine(string.Join(", ", _array));
    }
}