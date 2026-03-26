namespace Trees;

/// <summary>
/// Q18: CountNodes
/// Task: Count nodes in a binary tree using multiple approaches:
/// 1. Count all nodes recursively (O(n))
/// 2. Count leaf nodes only (O(n))
/// 3. Count all nodes iteratively with BFS (O(n))
/// </summary>
public class CountNodes
{
    private TreeNode? _root;

    public CountNodes(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Count All Nodes Recursively
    // - Total = 1 (current) + count(left) + count(right)
    // Time: O(n), Space: O(h)
    public int CountAllRecursive()
    {
        return CountAllHelper(_root);
    }

    private int CountAllHelper(TreeNode? node)
    {
        if (node == null) return 0;
        return 1 + CountAllHelper(node.Left) + CountAllHelper(node.Right);
    }

    // 2️. Count Leaf Nodes
    // - A leaf node has no children (left == null && right == null)
    // Time: O(n), Space: O(h)
    public int CountLeaves()
    {
        return CountLeavesHelper(_root);
    }

    private int CountLeavesHelper(TreeNode? node)
    {
        if (node == null) return 0;
        if (node.Left == null && node.Right == null) return 1;
        return CountLeavesHelper(node.Left) + CountLeavesHelper(node.Right);
    }

    // 3️. Count All Nodes Iteratively with BFS
    // - Traverse every node with a queue and count
    // Time: O(n), Space: O(n)
    public int CountAllBFS()
    {
        if (_root == null) return 0;

        int count = 0;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();
            count++;

            if (current.Left != null) queue.Enqueue(current.Left);
            if (current.Right != null) queue.Enqueue(current.Right);
        }

        return count;
    }
}
