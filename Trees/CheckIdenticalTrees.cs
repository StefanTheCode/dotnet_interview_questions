namespace Trees;

/// <summary>
/// Q6: CheckIdenticalTrees
/// Task: Determine whether two binary trees are structurally identical and have the same values
/// using multiple approaches:
/// 1. Recursive comparison (O(n) time, O(h) space)
/// 2. Iterative BFS comparison with Queue (O(n) time, O(n) space)
/// 3. Serialization comparison (O(n) time, O(n) space)
/// </summary>
public class CheckIdenticalTrees
{
    private TreeNode? _root1;
    private TreeNode? _root2;

    public CheckIdenticalTrees(TreeNode? root1, TreeNode? root2)
    {
        _root1 = root1;
        _root2 = root2;
    }

    // 1️. Recursive Comparison
    // - Compare current values, then recursively compare left and right subtrees
    // Time: O(n), Space: O(h)
    public bool AreIdenticalRecursive()
    {
        return AreIdenticalHelper(_root1, _root2);
    }

    private bool AreIdenticalHelper(TreeNode? node1, TreeNode? node2)
    {
        // Both null — identical at this point
        if (node1 == null && node2 == null) return true;

        // One is null, the other is not — not identical
        if (node1 == null || node2 == null) return false;

        // Values must match, and both subtrees must be identical
        return node1.Value == node2.Value
            && AreIdenticalHelper(node1.Left, node2.Left)
            && AreIdenticalHelper(node1.Right, node2.Right);
    }

    // 2️. Iterative BFS with Queue
    // - Traverse both trees level by level in parallel
    // - Compare each pair of nodes
    // Time: O(n), Space: O(n)
    public bool AreIdenticalIterative()
    {
        Queue<TreeNode?> queue = new Queue<TreeNode?>();
        queue.Enqueue(_root1);
        queue.Enqueue(_root2);

        while (queue.Count > 0)
        {
            TreeNode? node1 = queue.Dequeue();
            TreeNode? node2 = queue.Dequeue();

            if (node1 == null && node2 == null) continue;
            if (node1 == null || node2 == null) return false;
            if (node1.Value != node2.Value) return false;

            queue.Enqueue(node1.Left);
            queue.Enqueue(node2.Left);
            queue.Enqueue(node1.Right);
            queue.Enqueue(node2.Right);
        }

        return true;
    }

    // 3️. Serialization Comparison
    // - Serialize both trees to strings and compare
    // - Simple but uses extra memory for string construction
    // Time: O(n), Space: O(n)
    public bool AreIdenticalSerialized()
    {
        return Serialize(_root1) == Serialize(_root2);
    }

    private string Serialize(TreeNode? node)
    {
        if (node == null) return "#";
        return $"{node.Value},{Serialize(node.Left)},{Serialize(node.Right)}";
    }
}
