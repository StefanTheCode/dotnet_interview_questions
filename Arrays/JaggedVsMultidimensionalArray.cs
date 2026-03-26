namespace Arrays;

/// <summary>
/// Q17: JaggedVsMultidimensionalArray
/// Task: Demonstrate the difference between jagged arrays (array of arrays) and multidimensional arrays
/// and provide basic operations for each:
/// 1. Declare and initialize both types
/// 2. Access elements
/// 3. Iterate over elements
/// </summary>
public class JaggedVsMultidimensionalArray
{
    // Jagged array: array of arrays (rows can have different lengths)
    private int[][] _jaggedArray;

    // Multidimensional array: rectangular matrix (all rows same length)
    private int[,] _multiArray;

    public JaggedVsMultidimensionalArray()
    {
        // Initialize a jagged array with 3 rows of different lengths
        _jaggedArray = new int[3][];
        _jaggedArray[0] = new int[] { 1, 2 };
        _jaggedArray[1] = new int[] { 3, 4, 5 };
        _jaggedArray[2] = new int[] { 6 };

        // Initialize a 3x3 multidimensional array
        _multiArray = new int[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
    }

    // 1️. Print jagged array
    // - Iterates through each sub-array and prints elements
    public void PrintJaggedArray()
    {
        Console.WriteLine("Jagged Array:");
        for (int i = 0; i < _jaggedArray.Length; i++)
        {
            Console.Write("Row " + i + ": ");
            for (int j = 0; j < _jaggedArray[i].Length; j++)
            {
                Console.Write(_jaggedArray[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    // 2️. Print multidimensional array
    // - Iterates through rows and columns in a rectangular structure
    public void PrintMultidimensionalArray()
    {
        Console.WriteLine("Multidimensional Array:");
        for (int i = 0; i < _multiArray.GetLength(0); i++)
        {
            for (int j = 0; j < _multiArray.GetLength(1); j++)
            {
                Console.Write(_multiArray[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    // 3️. Example of accessing elements
    public void ShowAccessExample()
    {
        Console.WriteLine($"Jagged first element: {_jaggedArray[0][0]}");
        Console.WriteLine($"Multidimensional first element: {_multiArray[0, 0]}");
    }
}