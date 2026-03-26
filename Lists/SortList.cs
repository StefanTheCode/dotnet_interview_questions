namespace Lists;

/// <summary>
/// Q4: SortList
/// Task: Sort a List&lt;int&gt; using multiple approaches:
/// 1. Bubble sort manual implementation (O(n²))
/// 2. Built-in List.Sort (O(n log n))
/// 3. LINQ OrderBy for functional style sorting (O(n log n))
/// </summary>
public class SortList
{
    private List<int> _list;

    public SortList(List<int> list)
    {
        _list = list;
    }

    // 1️. Worst approach: Bubble Sort O(n²)
    // - Compare adjacent elements and swap if out of order
    // - Repeat until no swaps are needed
    public List<int> SortBubble()
    {
        List<int> copy = new List<int>(_list);

        for (int i = 0; i < copy.Count - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < copy.Count - 1 - i; j++)
            {
                if (copy[j] > copy[j + 1])
                {
                    (copy[j], copy[j + 1]) = (copy[j + 1], copy[j]);
                    swapped = true;
                }
            }
            if (!swapped) break; // Already sorted
        }

        return copy;
    }

    // 2️. Built-in Sort O(n log n)
    // - Uses IntroSort internally (hybrid of quicksort, heapsort, insertion sort)
    // - In-place sorting on a copy
    public List<int> SortBuiltIn()
    {
        List<int> copy = new List<int>(_list);
        copy.Sort();
        return copy;
    }

    // 3️. LINQ OrderBy O(n log n)
    // - Functional approach that returns a new sorted list
    // - Concise but creates intermediate allocations
    public List<int> SortWithLinq()
    {
        return _list.OrderBy(x => x).ToList();
    }
}
