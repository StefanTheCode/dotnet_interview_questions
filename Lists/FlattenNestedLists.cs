namespace Lists;

/// <summary>
/// Q17: FlattenNestedLists
/// Tarefa: transformar uma lista de listas em uma única lista linear,
/// preservando a ordem dos elementos.
///
/// Seja N a quantidade total de elementos em todas as listas internas.
/// As três abordagens executam em O(N) de tempo e produzem O(N) de saída.
/// </summary>
public sealed class FlattenNestedLists
{
    private readonly List<List<int>> _nestedList;

    public FlattenNestedLists(List<List<int>> nestedList)
    {
        ArgumentNullException.ThrowIfNull(nestedList);
        _nestedList = new List<List<int>>(nestedList.Count);

        for (int index = 0; index < nestedList.Count; index++)
        {
            List<int>? innerList = nestedList[index];

            if (innerList is null)
            {
                throw new ArgumentException(
                    $"A lista interna na posição {index} não pode ser nula.",
                    nameof(nestedList));
            }

            _nestedList.Add(new List<int>(innerList));
        }
    }

    public List<int> FlattenWithNestedLoops()
    {
        List<int> result = new(CalculateTotalCount());

        for (int i = 0; i < _nestedList.Count; i++)
        {
            for (int j = 0; j < _nestedList[i].Count; j++)
            {
                result.Add(_nestedList[i][j]);
            }
        }

        return result;
    }

    public List<int> FlattenWithLinq()
    {
        return _nestedList.SelectMany(innerList => innerList).ToList();
    }

    public List<int> FlattenWithAddRange()
    {
        List<int> result = new(CalculateTotalCount());

        foreach (List<int> innerList in _nestedList)
        {
            result.AddRange(innerList);
        }

        return result;
    }

    private int CalculateTotalCount()
    {
        int totalCount = 0;

        foreach (List<int> innerList in _nestedList)
        {
            totalCount = checked(totalCount + innerList.Count);
        }

        return totalCount;
    }
}
