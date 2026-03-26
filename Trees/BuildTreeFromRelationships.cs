namespace Trees;

/// <summary>
/// Q20: BuildTreeFromRelationships
/// Task: Build a tree from a flat list of parent-child relationships (a common hidden-tree
/// interview problem found in org charts, category trees, folder structures, etc.)
/// using multiple approaches:
/// 1. Dictionary-based construction from (id, parentId, name) records (O(n))
/// 2. Print the hierarchy with indentation (O(n))
/// 3. Compute height and find lowest common manager (O(n))
/// </summary>
public class BuildTreeFromRelationships
{
    public class OrgNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<OrgNode> Children { get; set; } = new List<OrgNode>();

        public OrgNode(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public record Relationship(int Id, int? ParentId, string Name);

    private OrgNode? _root;

    // 1️. Build Tree from Flat Relationships O(n)
    // - Create all nodes first, then attach children to parents
    // - The node with ParentId == null is the root
    // Time: O(n), Space: O(n)
    public OrgNode? BuildTree(List<Relationship> relationships)
    {
        Dictionary<int, OrgNode> nodeMap = new Dictionary<int, OrgNode>();

        // Create all nodes
        foreach (var rel in relationships)
        {
            nodeMap[rel.Id] = new OrgNode(rel.Id, rel.Name);
        }

        // Attach children to parents
        OrgNode? root = null;
        foreach (var rel in relationships)
        {
            if (rel.ParentId == null)
            {
                root = nodeMap[rel.Id];
            }
            else if (nodeMap.ContainsKey(rel.ParentId.Value))
            {
                nodeMap[rel.ParentId.Value].Children.Add(nodeMap[rel.Id]);
            }
        }

        _root = root;
        return root;
    }

    // 2️. Print Hierarchy with Indentation
    // - Recursively print each node with increasing indentation per level
    // - Common interview ask: "display an org chart" or "print folder tree"
    // Time: O(n)
    public List<string> PrintHierarchy()
    {
        List<string> lines = new List<string>();
        PrintHierarchyHelper(_root, 0, lines);
        return lines;
    }

    private void PrintHierarchyHelper(OrgNode? node, int depth, List<string> lines)
    {
        if (node == null) return;

        string indent = new string(' ', depth * 2);
        lines.Add($"{indent}{node.Name}");

        foreach (var child in node.Children)
        {
            PrintHierarchyHelper(child, depth + 1, lines);
        }
    }

    // 3️. Compute Height of the Hierarchy
    // - Maximum depth from root to any leaf in the N-ary tree
    // Time: O(n), Space: O(h)
    public int ComputeHeight()
    {
        return ComputeHeightHelper(_root);
    }

    private int ComputeHeightHelper(OrgNode? node)
    {
        if (node == null) return 0;

        int maxChildHeight = 0;
        foreach (var child in node.Children)
        {
            int childHeight = ComputeHeightHelper(child);
            maxChildHeight = Math.Max(maxChildHeight, childHeight);
        }

        return 1 + maxChildHeight;
    }

    // 4️. Find Lowest Common Manager
    // - Given two employee IDs, find their lowest common ancestor in the org tree
    // - Interview variant of LCA applied to N-ary trees / org charts
    // Time: O(n), Space: O(h)
    public OrgNode? FindLowestCommonManager(int id1, int id2)
    {
        return FindLCMHelper(_root, id1, id2);
    }

    private OrgNode? FindLCMHelper(OrgNode? node, int id1, int id2)
    {
        if (node == null) return null;

        if (node.Id == id1 || node.Id == id2)
            return node;

        List<OrgNode?> found = new List<OrgNode?>();
        foreach (var child in node.Children)
        {
            OrgNode? result = FindLCMHelper(child, id1, id2);
            if (result != null) found.Add(result);
        }

        // If both targets found in different subtrees, current node is the LCM
        if (found.Count >= 2) return node;

        // If one found, pass it up
        return found.Count == 1 ? found[0] : null;
    }
}
