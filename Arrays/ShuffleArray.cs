namespace Arrays;

/// <summary>
/// Q18: ShuffleArray
/// Task: Randomly shuffle the elements of an array using multiple approaches:
/// 1. Naive approach using Random selection with potential duplicates (not perfectly uniform)
/// 2. Fisher-Yates algorithm iterative (O(n), optimal and uniform)
/// 3. Fisher-Yates using in-place swaps with Random object (O(n), optimal)
/// </summary>
public class ShuffleArray
{
    private int[] _array;
    private Random _random;

    public ShuffleArray(int[] array)
    {
        _array = (int[])array.Clone(); // Clone to avoid modifying original
        _random = new Random();
    }

    // 1️. Naive Shuffle O(n²)
    // - Keep picking random indices and swapping if not already used
    // - Not perfectly uniform and slower
    public int[] ShuffleNaive()
    {
        int n = _array.Length;
        bool[] used = new bool[n];
        int[] shuffled = new int[n];
        int count = 0;

        while (count < n)
        {
            int idx = _random.Next(n);
            if (!used[idx])
            {
                shuffled[count++] = _array[idx];
                used[idx] = true;
            }
        }

        return shuffled;
    }

    // 2️. Fisher-Yates Algorithm O(n)
    // - Swap each element with a random element from remaining unshuffled part
    // - Produces uniform random permutations
    public int[] ShuffleFisherYates()
    {
        int[] arrCopy = (int[])_array.Clone();
        int n = arrCopy.Length;

        for (int i = 0; i < n; i++)
        {
            int j = _random.Next(i, n); // pick a random index from i to n-1
            (arrCopy[i], arrCopy[j]) = (arrCopy[j], arrCopy[i]);
        }

        return arrCopy;
    }

    // 3️. Fisher-Yates In-Place O(n)
    // - Shuffle the array itself without creating a copy
    // - Most memory-efficient approach
    public void ShuffleInPlace()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            int j = _random.Next(i, _array.Length);
            (_array[i], _array[j]) = (_array[j], _array[i]);
        }
    }

    public void PrintArray()
    {
        Console.WriteLine(string.Join(", ", _array));
    }
}