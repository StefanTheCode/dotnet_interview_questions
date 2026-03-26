namespace Trees;

/// <summary>
/// Q12: LowestCommonAncestor
/// Task: Find the Lowest Common Ancestor (LCA) of two nodes in a binary tree
/// using multiple approaches:
/// 1. Recursive LCA for a general binary tree (O(n) time, O(h) space)
/// 2. Optimized LCA for a BST using BST property (O(h) time, O(1) space)
/// 3. Iterative BST LCA (O(h) time, O(1) space, optimal for BST)
/// </summary>
public class LowestCommonAncestor
{
    private TreeNode? _root;

    public LowestCommonAncestor(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Recursive LCA for General Binary Tree
    // - If current node is p or q, it's the LCA candidate
    // - If p and q are found in different subtrees, current node is the LCA
    // - If both are in the same subtree, the LCA is in that subtree
    // Time: O(n), Space: O(h)
    public TreeNode? FindLCA(int p, int q)
    {
        return FindLCAHelper(_root, p, q);
    }

    private TreeNode? FindLCAHelper(TreeNode? node, int p, int q)
    {
        if (node == null) return null;

        // If current node matches either value, this is a candidate
        if (node.Value == p || node.Value == q)
            return node;

        TreeNode? left = FindLCAHelper(node.Left, p, q);
        TreeNode? right = FindLCAHelper(node.Right, p, q);

        // If both sides returned non-null, current node is the LCA
        if (left != null && right != null)
            return node;

        // Otherwise, return whichever side found something
        return left ?? right;
    }

    // 2️. Recursive LCA for BST
    // - Exploit BST ordering to narrow the search
    // - If both values < current, go left
    // - If both values > current, go right
    // - Otherwise, current node is the LCA
    // Time: O(h), Space: O(h)
    public TreeNode? FindLCAInBST(int p, int q)
    {
        return FindLCAInBSTHelper(_root, p, q);
    }

    private TreeNode? FindLCAInBSTHelper(TreeNode? node, int p, int q)
    {
        if (node == null) return null;

        if (p < node.Value && q < node.Value)
            return FindLCAInBSTHelper(node.Left, p, q);

        if (p > node.Value && q > node.Value)
            return FindLCAInBSTHelper(node.Right, p, q);

        return node; // Split point — this is the LCA
    }

    // 3️. Iterative LCA for BST — Optimal
    // - Same logic as recursive BST approach, but without call stack
    // Time: O(h), Space: O(1)
    public TreeNode? FindLCAInBSTIterative(int p, int q)
    {
        TreeNode? current = _root;

        while (current != null)
        {
            if (p < current.Value && q < current.Value)
                current = current.Left;
            else if (p > current.Value && q > current.Value)
                current = current.Right;
            else
                return current; // Split point
        }

        return null;
    }
}
