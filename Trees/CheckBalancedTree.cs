namespace Trees;

/// <summary>
/// Q5: CheckBalancedTree
/// Task: Determine whether a binary tree is height-balanced (for every node, the depth of
/// the left and right subtrees differs by at most 1) using multiple approaches:
/// 1. Brute force: check height at each node, recurse (O(n²))
/// 2. Bottom-up with early termination (O(n), optimal)
/// </summary>
public class CheckBalancedTree
{
    private TreeNode? _root;

    public CheckBalancedTree(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Brute Force O(n²)
    // - For each node, compute height of left and right subtrees
    // - Check difference <= 1, then recurse on both children
    // - Recomputes heights repeatedly — very slow on large trees
    public bool IsBalancedBruteForce()
    {
        return IsBalancedBruteForceHelper(_root);
    }

    private bool IsBalancedBruteForceHelper(TreeNode? node)
    {
        if (node == null) return true;

        int leftHeight = GetHeight(node.Left);
        int rightHeight = GetHeight(node.Right);

        if (Math.Abs(leftHeight - rightHeight) > 1)
            return false;

        return IsBalancedBruteForceHelper(node.Left) && IsBalancedBruteForceHelper(node.Right);
    }

    private int GetHeight(TreeNode? node)
    {
        if (node == null) return 0;
        return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
    }

    // 2️. Optimal: Bottom-Up O(n)
    // - Compute height and check balance in one pass
    // - Return -1 immediately if any subtree is unbalanced
    // - Avoids redundant height calculations
    // Time: O(n), Space: O(h)
    public bool IsBalancedOptimal()
    {
        return CheckHeight(_root) != -1;
    }

    private int CheckHeight(TreeNode? node)
    {
        if (node == null) return 0;

        int leftHeight = CheckHeight(node.Left);
        if (leftHeight == -1) return -1; // Left subtree is unbalanced

        int rightHeight = CheckHeight(node.Right);
        if (rightHeight == -1) return -1; // Right subtree is unbalanced

        if (Math.Abs(leftHeight - rightHeight) > 1)
            return -1; // Current node is unbalanced

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
