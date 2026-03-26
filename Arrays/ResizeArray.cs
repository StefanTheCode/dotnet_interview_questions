namespace Arrays;

/// <summary>
/// Q19: ResizeArray
/// Task: Resize an array to a new size using multiple approaches:
/// 1. Manual creation of a new array and copy elements (O(n))
/// 2. Using Array.Copy or Array.Resize built-in methods (O(n))
/// 3. Using dynamic structures like List<T> for easier resizing
/// </summary>
public class ResizeArray
{
    private int[] _array;

    public ResizeArray(int[] array)
    {
        _array = array;
    }

    // 1️. Manual Resize O(n)
    // - Create a new array of desired size
    // - Copy old elements manually
    public int[] ManualResize(int newSize)
    {
        int[] newArray = new int[newSize];
        int lengthToCopy = Math.Min(_array.Length, newSize);

        for (int i = 0; i < lengthToCopy; i++)
            newArray[i] = _array[i];

        return newArray;
    }

    // 2️. Built-in Resize O(n)
    // - Array.Resize handles array reallocation and copying internally
    public int[] BuiltInResize(int newSize)
    {
        int[] copy = (int[])_array.Clone();
        Array.Resize(ref copy, newSize);
        return copy;
    }

    // 3️. Using List<T> as dynamic array O(n)
    // - Convert array to list, resize by Add/Remove
    // - Convert back to array if needed
    public int[] ResizeWithList(int newSize)
    {
        var list = new System.Collections.Generic.List<int>(_array);

        if (newSize < list.Count)
        {
            // Remove extra elements
            list.RemoveRange(newSize, list.Count - newSize);
        }
        else
        {
            // Add default zeros to extend
            while (list.Count < newSize)
                list.Add(0);
        }

        return list.ToArray();
    }
}