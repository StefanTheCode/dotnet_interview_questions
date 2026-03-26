namespace Arrays;

using System;
using System.Linq;

/// <summary>
/// Q2: ReverseArray
/// Task: Given an array, reverse it using multiple approaches:
/// 1. Brute force / LINQ
/// 2. Manual new array
/// 3. In-place two-pointer swap (optimal)
/// </summary>
public class ReverseArray
{
    private readonly int[] _array;

    public ReverseArray(int[] array)
    {
        _array = array;
    }

    // 1. Worst approach: LINQ Reverse (creates new array)
    // Time: O(n), Space: O(n)
    public int[] ReverseWithLinq()
    {
        // Allocates a new reversed array
        return _array.Reverse().ToArray();
    }

    // 2. Intermediate approach: Manual new array
    // Time: O(n), Space: O(n)
    public int[] ReverseWithNewArray()
    {
        int[] reversed = new int[_array.Length];

        for (int i = 0; i < _array.Length; i++)
        {
            reversed[i] = _array[_array.Length - 1 - i];
        }

        return reversed;
    }

    // 3. Best approach: In-place two-pointer swap
    // avoids extra memory allocations(more performant in constrained environments).
    // Time: O(n), Space: O(1)
    public void ReverseInPlace()
    {
        int left = 0, right = _array.Length - 1;

        while (left < right)
        {
            int temp = _array[left];
            _array[left] = _array[right];
            _array[right] = temp;

            left++;
            right--;
        }
    }

    public void PrintArray()
    {
        Console.WriteLine(string.Join(", ", _array));
    }
}