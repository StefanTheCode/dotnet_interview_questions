namespace Arrays;

/// <summary>
/// Questão 19: ordenar um array de objetos personalizados.
///
/// As abordagens apresentadas são:
/// 1. implementação de IComparable&lt;T&gt; no próprio tipo;
/// 2. Comparison&lt;T&gt; fornecido diretamente ao Array.Sort;
/// 3. OrderBy e ThenBy com LINQ.
///
/// As três abordagens possuem custo típico O(n log n). As implementações ordenam
/// cópias para não modificar o array recebido pelo construtor.
/// </summary>
public class SortCustomObjects
{
    public sealed class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            if (age < 0)
                throw new ArgumentOutOfRangeException(nameof(age), "A idade não pode ser negativa.");

            Name = name;
            Age = age;
        }

        public string Name { get; }

        public int Age { get; }

        /// <summary>
        /// Define idade como critério padrão e nome como desempate determinístico.
        /// </summary>
        public int CompareTo(Person? other)
        {
            if (other is null)
                return 1;

            int ageComparison = Age.CompareTo(other.Age);

            return ageComparison != 0
                ? ageComparison
                : StringComparer.OrdinalIgnoreCase.Compare(Name, other.Name);
        }

        public override string ToString() => $"{Name} ({Age})";
    }

    private readonly Person[] _people;

    public SortCustomObjects(Person[] people)
    {
        ArgumentNullException.ThrowIfNull(people);

        if (people.Any(person => person is null))
            throw new ArgumentException("O array não pode conter pessoas nulas.", nameof(people));

        _people = (Person[])people.Clone();
    }

    /// <summary>
    /// Usa a ordenação padrão definida por Person.CompareTo.
    /// </summary>
    public Person[] SortWithIComparable()
    {
        Person[] sorted = (Person[])_people.Clone();
        Array.Sort(sorted);
        return sorted;
    }

    /// <summary>
    /// Usa um delegate para ordenar pelo nome sem alterar a implementação de Person.
    /// </summary>
    public Person[] SortWithCustomComparer()
    {
        Person[] sorted = (Person[])_people.Clone();

        Array.Sort(
            sorted,
            (first, second) =>
                StringComparer.OrdinalIgnoreCase.Compare(first.Name, second.Name));

        return sorted;
    }

    /// <summary>
    /// Usa LINQ para ordenar por idade e, em caso de empate, por nome.
    /// </summary>
    public Person[] SortWithLinq() =>
        _people.OrderBy(person => person.Age)
               .ThenBy(person => person.Name, StringComparer.OrdinalIgnoreCase)
               .ToArray();
}
