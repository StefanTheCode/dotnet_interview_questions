namespace Arrays;

/// <summary>
/// Q11: Flatten2DArray
/// Task: Convert a 2D integer array (matrix) into a 1D array (flatten it) using multiple approaches:
/// 1. Brute force with nested loops (O(n*m) time, O(n*m) space)
/// 2. LINQ SelectMany for concise functional flattening (O(n*m) time, O(n*m) space)
/// 3. Optimized pre-allocation and single pass for maximum efficiency (O(n*m) time, O(n*m) space)
/// </summary>
public class Flatten2DArray
{
    private int[][] _jaggedArray;

    public Flatten2DArray(int[][] jaggedArray)
    {
        _jaggedArray = jaggedArray;
    }

    // 1️. Brute Force: Nested loops to flatten
    // - Iterate row by row and copy elements into a new list
    // - Time: O(n*m)
    // - Space: O(n*m)
    public int[] FlattenWithNestedLoops()
    {
        List<int> result = new List<int>();

        for (int i = 0; i < _jaggedArray.Length; i++)
        {
            for (int j = 0; j < _jaggedArray[i].Length; j++)
            {
                result.Add(_jaggedArray[i][j]);
            }
        }

        return result.ToArray();
    }

    // 2️. LINQ SelectMany
    // - One-liner functional approach
    // - Internally still iterates through all elements
    // - Time: O(n*m), Space: O(n*m)
    public int[] FlattenWithLinq()
    {
        return _jaggedArray.SelectMany(row => row).ToArray();
    }

    // 3️. Optimal Pre-Allocation
    // - Precompute total length to allocate array only once
    // - Fill sequentially for best performance
    public int[] FlattenOptimized()
    {
        int totalLength = 0;

        for (int i = 0; i < _jaggedArray.Length; i++)
            totalLength += _jaggedArray[i].Length;

        int[] flatArray = new int[totalLength];
        int index = 0;

        for (int i = 0; i < _jaggedArray.Length; i++)
        {
            for (int j = 0; j < _jaggedArray[i].Length; j++)
            {
                flatArray[index++] = _jaggedArray[i][j];
            }
        }

        return flatArray;
    }
}