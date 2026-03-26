namespace Trees;

/// <summary>
/// Q9: SearchBST
/// Task: Search for a target value in a Binary Search Tree using multiple approaches:
/// 1. Recursive search exploiting BST property (O(h))
/// 2. Iterative search with no recursion overhead (O(h), optimal)
/// </summary>
public class SearchBST
{
    private TreeNode? _root;

    public SearchBST(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Recursive Search O(h)
    // - If current value matches, return the node
    // - If target < current, search left subtree
    // - If target > current, search right subtree
    // Time: O(h), Space: O(h) due to call stack
    public TreeNode? SearchRecursive(int target)
    {
        return SearchHelper(_root, target);
    }

    private TreeNode? SearchHelper(TreeNode? node, int target)
    {
        if (node == null) return null;

        if (target == node.Value)
            return node;
        else if (target < node.Value)
            return SearchHelper(node.Left, target);
        else
            return SearchHelper(node.Right, target);
    }

    // 2️. Iterative Search O(h) — Optimal
    // - Follow left or right pointer without recursion
    // - No call stack overhead
    // Time: O(h), Space: O(1)
    public TreeNode? SearchIterative(int target)
    {
        TreeNode? current = _root;

        while (current != null)
        {
            if (target == current.Value)
                return current;
            else if (target < current.Value)
                current = current.Left;
            else
                current = current.Right;
        }

        return null; // Not found
    }
}
