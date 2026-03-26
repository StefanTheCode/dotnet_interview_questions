using System.Collections;

namespace Arrays;

public class Array_ArrayList_List
{
    /// <summary>
    /// Performance:
    /// Array: Fastest access(O(1)), low memory overhead.
    /// ArrayList: Slower for value types due to boxing.
    /// List<T>: Best of both worlds - dynamic and type-safe.
    /// </summary>
    public Array_ArrayList_List()
    {
        // Array
        int[] array = new int[3] { 1, 2, 3 };

        // ArrayList
        ArrayList arrayList = new ArrayList();          
        arrayList.Add(1); 
        arrayList.Add("hello");            // Not type-safe

        // List<T>
        List<int> genericList = new List<int> { 1, 2, 3 };  
    }
}