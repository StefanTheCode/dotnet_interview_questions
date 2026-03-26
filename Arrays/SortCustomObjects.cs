namespace Arrays;

/// <summary>
/// Q20: SortCustomObjects
/// Task: Sort an array of custom objects (e.g., Person) using multiple approaches:
/// 1. IComparable implementation on the class (O(n log n))
/// 2. Array.Sort with a Comparison delegate or IComparer (O(n log n))
/// 3. LINQ OrderBy for functional style sorting (O(n log n))
/// </summary>
public class SortCustomObjects
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // Implement IComparable to sort by Age by default
        public int CompareTo(Person other)
        {
            if (other == null) return 1;
            return this.Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return $"{Name} ({Age})";
        }
    }

    private Person[] _people;

    public SortCustomObjects(Person[] people)
    {
        _people = people;
    }

    // 1️. Sort using IComparable (default sort)
    // - Requires the class to implement IComparable<T>
    // - Sorts in-place
    public Person[] SortWithIComparable()
    {
        Person[] copy = (Person[])_people.Clone();
        Array.Sort(copy);
        return copy;
    }

    // 2️. Sort using Array.Sort with a Comparison delegate
    // - Allows custom sorting without changing the class definition
    public Person[] SortWithCustomComparer()
    {
        Person[] copy = (Person[])_people.Clone();

        // Example: sort by Name ascending
        Array.Sort(copy, (a, b) => a.Name.CompareTo(b.Name));

        return copy;
    }

    // 3️. LINQ OrderBy
    // - Functional and concise but creates a new sequence
    // - Flexible for multiple sort keys
    public Person[] SortWithLinq()
    {
        return _people
            .OrderBy(p => p.Age)     // Sort by Age
            .ThenBy(p => p.Name)     // Then by Name
            .ToArray();
    }
}