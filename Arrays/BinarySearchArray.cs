namespace Arrays;

/// <summary>
/// Q14: BinarySearchArray
/// Task: Search for a target element in a sorted array using multiple approaches:
/// 1. Linear search (O(n))
/// 2. Iterative binary search (O(log n), optimal)
/// 3. Recursive binary search (O(log n), optimal)
/// </summary>
public class BinarySearchArray
{
    private int[] _array;

    public BinarySearchArray(int[] array)
    {
        _array = array;
    }

    // 1️. Linear Search O(n)
    // - Check each element sequentially
    // - Worst approach for large arrays
    public int LinearSearch(int target)
    {
        for (int i = 0; i < _array.Length; i++)
        {
            if (_array[i] == target)
                return i;
        }
        return -1; // Not found
    }

    // 2️. Iterative Binary Search O(log n)
    // - Works only on sorted arrays
    // - Reduces search space by half each iteration
    public int BinarySearchIterative(int target)
    {
        int left = 0;
        int right = _array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (_array[mid] == target)
                return mid;
            else if (_array[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1; // Not found
    }

    // 3️. Recursive Binary Search O(log n)
    // - Same logic as iterative, but using recursion
    public int BinarySearchRecursive(int target)
    {
        return BinarySearchRecursiveHelper(target, 0, _array.Length - 1);
    }

    private int BinarySearchRecursiveHelper(int target, int left, int right)
    {
        if (left > right)
            return -1;

        int mid = left + (right - left) / 2;

        if (_array[mid] == target)
            return mid;
        else if (_array[mid] < target)
            return BinarySearchRecursiveHelper(target, mid + 1, right);
        else
            return BinarySearchRecursiveHelper(target, left, mid - 1);
    }
}