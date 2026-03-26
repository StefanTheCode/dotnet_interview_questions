namespace Arrays;

/// <summary>
/// Q7: FindIntersection
/// Task: Find the intersection of two integer arrays (unique common elements) using multiple approaches:
/// 1. Brute force nested loops (O(n*m))
/// 2. Sort both arrays and use two-pointer method (O(n log n + m log m))
/// 3. HashSet lookup for O(n+m) optimal solution
/// </summary>
public class FindIntersection
{
    private int[] _array1;
    private int[] _array2;

    public FindIntersection(int[] array1, int[] array2)
    {
        _array1 = array1;
        _array2 = array2;
    }

    // 1️. Brute Force O(n*m)
    // - Compare each element of array1 with each element of array2
    // - Add to result if a match is found and it's not already added
    public int[] FindIntersectionBruteForce()
    {
        List<int> intersection = new List<int>();

        for (int i = 0; i < _array1.Length; i++)
        {
            for (int j = 0; j < _array2.Length; j++)
            {
                if (_array1[i] == _array2[j] && !intersection.Contains(_array1[i]))
                {
                    intersection.Add(_array1[i]);
                    break; // Move to next element of array1
                }
            }
        }

        return intersection.ToArray();
    }

    // 2️. Better Approach: Sorting + Two-Pointer O(n log n + m log m)
    // - Sort both arrays
    // - Move two pointers to find matching elements
    public int[] FindIntersectionTwoPointer()
    {
        Array.Sort(_array1);
        Array.Sort(_array2);

        List<int> intersection = new List<int>();
        int i = 0, j = 0;

        while (i < _array1.Length && j < _array2.Length)
        {
            if (_array1[i] == _array2[j])
            {
                // Avoid duplicates
                if (intersection.Count == 0 || intersection[^1] != _array1[i])
                    intersection.Add(_array1[i]);

                i++;
                j++;
            }
            else if (_array1[i] < _array2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        return intersection.ToArray();
    }

    // 3️. Optimal Approach: HashSet O(n + m)
    // - Store elements of smaller array in a HashSet for O(1) lookup
    // - Iterate over the other array and add common elements
    public int[] FindIntersectionHashSet()
    {
        // Choose smaller array for HashSet to save memory
        int[] small = _array1.Length < _array2.Length ? _array1 : _array2;
        int[] large = _array1.Length < _array2.Length ? _array2 : _array1;

        HashSet<int> set = new HashSet<int>(small);
        HashSet<int> resultSet = new HashSet<int>();

        foreach (int num in large)
        {
            if (set.Contains(num))
                resultSet.Add(num);
        }

        return resultSet.ToArray();
    }
}