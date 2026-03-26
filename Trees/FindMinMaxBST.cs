namespace Trees;

/// <summary>
/// Q11: FindMinMaxBST
/// Task: Find the minimum and maximum values in a Binary Search Tree using multiple approaches:
/// 1. Recursive traversal to leftmost/rightmost node (O(h))
/// 2. Iterative traversal to leftmost/rightmost node (O(h), optimal)
/// </summary>
public class FindMinMaxBST
{
    private TreeNode? _root;

    public FindMinMaxBST(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Recursive: Find Minimum
    // - In a BST, the smallest value is always the leftmost node
    // Time: O(h), Space: O(h)
    public int? FindMinRecursive()
    {
        if (_root == null) return null;
        return FindMinHelper(_root);
    }

    private int FindMinHelper(TreeNode node)
    {
        if (node.Left == null) return node.Value;
        return FindMinHelper(node.Left);
    }

    // 1️. Recursive: Find Maximum
    // - In a BST, the largest value is always the rightmost node
    // Time: O(h), Space: O(h)
    public int? FindMaxRecursive()
    {
        if (_root == null) return null;
        return FindMaxHelper(_root);
    }

    private int FindMaxHelper(TreeNode node)
    {
        if (node.Right == null) return node.Value;
        return FindMaxHelper(node.Right);
    }

    // 2️. Iterative: Find Minimum — Optimal
    // - Simply follow left pointers until we reach a leaf
    // Time: O(h), Space: O(1)
    public int? FindMinIterative()
    {
        if (_root == null) return null;

        TreeNode current = _root;
        while (current.Left != null)
            current = current.Left;

        return current.Value;
    }

    // 2️. Iterative: Find Maximum — Optimal
    // - Simply follow right pointers until we reach a leaf
    // Time: O(h), Space: O(1)
    public int? FindMaxIterative()
    {
        if (_root == null) return null;

        TreeNode current = _root;
        while (current.Right != null)
            current = current.Right;

        return current.Value;
    }
}
