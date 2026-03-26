namespace Trees;

/// <summary>
/// Q8: ValidateBST
/// Task: Determine whether a given binary tree is a valid Binary Search Tree (BST)
/// using multiple approaches:
/// 1. Inorder traversal should produce a sorted sequence (O(n) time, O(n) space)
/// 2. Recursive validation with min/max bounds (O(n) time, O(h) space, optimal)
/// 3. Iterative inorder traversal with previous value check (O(n) time, O(h) space)
/// </summary>
public class ValidateBST
{
    private TreeNode? _root;

    public ValidateBST(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Inorder Traversal + Check Sorted
    // - Perform full inorder traversal, store results
    // - Verify the resulting list is strictly ascending
    // Time: O(n), Space: O(n)
    public bool IsValidWithInorderList()
    {
        List<int> values = new List<int>();
        InorderCollect(_root, values);

        for (int i = 1; i < values.Count; i++)
        {
            if (values[i] <= values[i - 1])
                return false;
        }

        return true;
    }

    private void InorderCollect(TreeNode? node, List<int> values)
    {
        if (node == null) return;
        InorderCollect(node.Left, values);
        values.Add(node.Value);
        InorderCollect(node.Right, values);
    }

    // 2️. Recursive with Min/Max Bounds (Optimal)
    // - Each node must be within a valid range
    // - Left child: upper bound is parent value
    // - Right child: lower bound is parent value
    // Time: O(n), Space: O(h)
    public bool IsValidRecursive()
    {
        return IsValidHelper(_root, long.MinValue, long.MaxValue);
    }

    private bool IsValidHelper(TreeNode? node, long min, long max)
    {
        if (node == null) return true;

        if (node.Value <= min || node.Value >= max)
            return false;

        return IsValidHelper(node.Left, min, node.Value)
            && IsValidHelper(node.Right, node.Value, max);
    }

    // 3️. Iterative Inorder with Previous Value
    // - Perform inorder traversal iteratively
    // - Check that each value is greater than the previous one
    // Time: O(n), Space: O(h)
    public bool IsValidIterative()
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode? current = _root;
        long previous = long.MinValue;

        while (current != null || stack.Count > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.Left;
            }

            current = stack.Pop();

            if (current.Value <= previous)
                return false;

            previous = current.Value;
            current = current.Right;
        }

        return true;
    }
}
