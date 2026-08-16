namespace Trees;

/// <summary>
/// Q20: BuildTreeFromRelationships
/// Problema: construir uma árvore N-ária a partir de relacionamentos planos,
/// como organogramas, categorias e estruturas de diretórios.
/// </summary>
public class BuildTreeFromRelationships
{
    public sealed class OrgNode
    {
        private readonly List<OrgNode> _children = [];

        public OrgNode(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public IReadOnlyList<OrgNode> Children => _children;

        internal void AddChild(OrgNode child)
        {
            _children.Add(child);
        }
    }

    public sealed record Relationship(int Id, int? ParentId, string Name);

    private OrgNode? _root;
    private Dictionary<int, OrgNode> _nodesById = [];

    /// <summary>
    /// Constrói a hierarquia em O(n) de tempo e O(n) de espaço.
    /// Uma entrada não vazia deve possuir exatamente uma raiz, IDs únicos,
    /// pais existentes e nenhuma relação cíclica.
    /// </summary>
    public OrgNode? BuildTree(IEnumerable<Relationship> relationships)
    {
        ArgumentNullException.ThrowIfNull(relationships);

        _root = null;
        _nodesById = [];

        List<Relationship> items = relationships.ToList();

        if (items.Count == 0)
            return null;

        Dictionary<int, OrgNode> nodesById = [];

        foreach (Relationship relationship in items)
        {
            if (string.IsNullOrWhiteSpace(relationship.Name))
            {
                throw new ArgumentException(
                    $"O nome do nó {relationship.Id} não pode ser vazio.",
                    nameof(relationships));
            }

            if (!nodesById.TryAdd(
                    relationship.Id,
                    new OrgNode(relationship.Id, relationship.Name.Trim())))
            {
                throw new ArgumentException(
                    $"O ID {relationship.Id} está duplicado.",
                    nameof(relationships));
            }
        }

        List<Relationship> roots = items
            .Where(relationship => relationship.ParentId is null)
            .ToList();

        if (roots.Count != 1)
        {
            throw new ArgumentException(
                "Uma hierarquia não vazia deve possuir exatamente uma raiz.",
                nameof(relationships));
        }

        foreach (Relationship relationship in items)
        {
            if (relationship.ParentId is null)
                continue;

            if (relationship.ParentId.Value == relationship.Id)
            {
                throw new ArgumentException(
                    $"O nó {relationship.Id} não pode ser pai de si mesmo.",
                    nameof(relationships));
            }

            if (!nodesById.TryGetValue(relationship.ParentId.Value, out OrgNode? parent))
            {
                throw new ArgumentException(
                    $"O pai {relationship.ParentId.Value} do nó {relationship.Id} não existe.",
                    nameof(relationships));
            }

            parent.AddChild(nodesById[relationship.Id]);
        }

        EnsureAcyclic(nodesById.Values);

        OrgNode root = nodesById[roots[0].Id];
        HashSet<int> reachableIds = [];
        CollectReachableIds(root, reachableIds);

        if (reachableIds.Count != nodesById.Count)
        {
            throw new ArgumentException(
                "A hierarquia contém nós desconectados da raiz.",
                nameof(relationships));
        }

        _root = root;
        _nodesById = nodesById;
        return root;
    }

    // Tempo: O(n). Espaço: O(h), além das linhas retornadas.
    public List<string> PrintHierarchy()
    {
        List<string> lines = [];
        PrintHierarchy(_root, 0, lines);
        return lines;
    }

    private static void PrintHierarchy(OrgNode? node, int depth, List<string> lines)
    {
        if (node is null)
            return;

        lines.Add($"{new string(' ', depth * 2)}{node.Name}");

        foreach (OrgNode child in node.Children)
            PrintHierarchy(child, depth + 1, lines);
    }

    // Tempo: O(n). Espaço auxiliar: O(h).
    public int ComputeHeight()
    {
        return ComputeHeight(_root);
    }

    private static int ComputeHeight(OrgNode? node)
    {
        if (node is null)
            return 0;

        int maxChildHeight = 0;

        foreach (OrgNode child in node.Children)
            maxChildHeight = Math.Max(maxChildHeight, ComputeHeight(child));

        return 1 + maxChildHeight;
    }

    // Tempo: O(n). Espaço auxiliar: O(h).
    public OrgNode? FindLowestCommonManager(int firstId, int secondId)
    {
        if (!_nodesById.ContainsKey(firstId) || !_nodesById.ContainsKey(secondId))
            return null;

        if (firstId == secondId)
            return _nodesById[firstId];

        return FindLowestCommonManager(_root, firstId, secondId);
    }

    private static OrgNode? FindLowestCommonManager(
        OrgNode? node,
        int firstId,
        int secondId)
    {
        if (node is null || node.Id == firstId || node.Id == secondId)
            return node;

        OrgNode? match = null;

        foreach (OrgNode child in node.Children)
        {
            OrgNode? childMatch = FindLowestCommonManager(child, firstId, secondId);

            if (childMatch is null)
                continue;

            if (match is not null)
                return node;

            match = childMatch;
        }

        return match;
    }

    private static void EnsureAcyclic(IEnumerable<OrgNode> nodes)
    {
        Dictionary<int, VisitState> states = [];

        foreach (OrgNode node in nodes)
            Visit(node, states);
    }

    private static void Visit(OrgNode node, Dictionary<int, VisitState> states)
    {
        if (states.TryGetValue(node.Id, out VisitState state))
        {
            if (state == VisitState.Visiting)
                throw new ArgumentException("A hierarquia contém um ciclo.");

            return;
        }

        states[node.Id] = VisitState.Visiting;

        foreach (OrgNode child in node.Children)
            Visit(child, states);

        states[node.Id] = VisitState.Visited;
    }

    private static void CollectReachableIds(OrgNode node, HashSet<int> reachableIds)
    {
        if (!reachableIds.Add(node.Id))
            return;

        foreach (OrgNode child in node.Children)
            CollectReachableIds(child, reachableIds);
    }

    private enum VisitState
    {
        Visiting,
        Visited
    }
}
