namespace Trees;

/// <summary>
/// Q4: MinimumDepth
/// Task: Find the minimum depth of a binary tree (shortest path from root to nearest leaf)
/// using multiple approaches:
/// 1. Recursive DFS (O(n) time, O(h) space)
/// 2. BFS — stops at the first leaf found (O(n) time, O(n) space, optimal for min depth)
/// </summary>
public class MinimumDepth
{
    private TreeNode? _root;

    public MinimumDepth(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Recursive DFS
    // - Must handle the case where a node has only one child
    //   (a node with one child is NOT a leaf, so we can't return 1 for it)
    // Time: O(n), Space: O(h)
    public int FindMinDepthRecursive()
    {
        return MinDepthHelper(_root);
    }

    private int MinDepthHelper(TreeNode? node)
    {
        if (node == null) return 0;

        // If only right child exists, go right
        if (node.Left == null)
            return 1 + MinDepthHelper(node.Right);

        // If only left child exists, go left
        if (node.Right == null)
            return 1 + MinDepthHelper(node.Left);

        // Both children exist: take the minimum
        return 1 + Math.Min(MinDepthHelper(node.Left), MinDepthHelper(node.Right));
    }

    // 2️. BFS — Optimal for minimum depth
    // - First leaf encountered is at the minimum depth
    // - No need to visit every node
    // Time: O(n) worst case, Space: O(n)
    public int FindMinDepthBFS()
    {
        if (_root == null) return 0;

        Queue<(TreeNode node, int depth)> queue = new Queue<(TreeNode, int)>();
        queue.Enqueue((_root, 1));

        while (queue.Count > 0)
        {
            var (current, depth) = queue.Dequeue();

            // First leaf found — this is the minimum depth
            if (current.Left == null && current.Right == null)
                return depth;

            if (current.Left != null) queue.Enqueue((current.Left, depth + 1));
            if (current.Right != null) queue.Enqueue((current.Right, depth + 1));
        }

        return 0; // Should never reach here for a valid tree
    }
}
