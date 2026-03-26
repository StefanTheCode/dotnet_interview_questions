namespace Lists;

/// <summary>
/// Q12: FirstNonRepeatingElement
/// Task: Find the first element in the list that does not repeat using multiple approaches:
/// 1. Brute force comparison for each element (O(n²))
/// 2. Dictionary frequency counting (O(n))
/// 3. LINQ GroupBy for a concise solution (O(n), less control)
/// </summary>
public class FirstNonRepeatingElement
{
    private List<int> _list;

    public FirstNonRepeatingElement(List<int> list)
    {
        _list = list;
    }

    // 1️. Brute Force O(n²)
    // - For each element, check the entire list to see if it repeats
    // - Returns the first element that has no duplicates
    public int? FindBruteForce()
    {
        for (int i = 0; i < _list.Count; i++)
        {
            bool isUnique = true;
            for (int j = 0; j < _list.Count; j++)
            {
                if (i != j && _list[i] == _list[j])
                {
                    isUnique = false;
                    break;
                }
            }

            if (isUnique)
                return _list[i];
        }

        return null; // No unique element
    }

    // 2️. Better Approach: Dictionary for Frequencies O(n)
    // - Count occurrences of each element
    // - Iterate again to find the first with count == 1
    public int? FindWithDictionary()
    {
        Dictionary<int, int> frequency = new Dictionary<int, int>();

        foreach (int num in _list)
        {
            frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;
        }

        foreach (int num in _list)
        {
            if (frequency[num] == 1)
                return num;
        }

        return null;
    }

    // 3️. LINQ Compact Solution O(n) (less flexible)
    // - Groups by element and selects the first group with only 1 element
    public int? FindWithLinq()
    {
        return _list
            .GroupBy(x => x)
            .FirstOrDefault(g => g.Count() == 1)?
            .Key;
    }
}
