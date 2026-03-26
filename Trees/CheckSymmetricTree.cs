namespace Trees;

/// <summary>
/// Q14: CheckSymmetricTree
/// Task: Determine whether a binary tree is symmetric (a mirror image of itself)
/// using multiple approaches:
/// 1. Recursive mirror check (O(n) time, O(h) space)
/// 2. Iterative check with Queue (O(n) time, O(n) space)
/// </summary>
public class CheckSymmetricTree
{
    private TreeNode? _root;

    public CheckSymmetricTree(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Recursive Mirror Check
    // - A tree is symmetric if the left subtree is a mirror of the right subtree
    // - Compare outer pairs (left.left vs right.right) and inner pairs (left.right vs right.left)
    // Time: O(n), Space: O(h)
    public bool IsSymmetricRecursive()
    {
        if (_root == null) return true;
        return IsMirror(_root.Left, _root.Right);
    }

    private bool IsMirror(TreeNode? left, TreeNode? right)
    {
        if (left == null && right == null) return true;
        if (left == null || right == null) return false;

        return left.Value == right.Value
            && IsMirror(left.Left, right.Right)   // outer pair
            && IsMirror(left.Right, right.Left);  // inner pair
    }

    // 2️. Iterative with Queue
    // - Enqueue pairs of nodes that should be mirrors
    // - Compare each pair
    // Time: O(n), Space: O(n)
    public bool IsSymmetricIterative()
    {
        if (_root == null) return true;

        Queue<TreeNode?> queue = new Queue<TreeNode?>();
        queue.Enqueue(_root.Left);
        queue.Enqueue(_root.Right);

        while (queue.Count > 0)
        {
            TreeNode? left = queue.Dequeue();
            TreeNode? right = queue.Dequeue();

            if (left == null && right == null) continue;
            if (left == null || right == null) return false;
            if (left.Value != right.Value) return false;

            // Enqueue mirror pairs
            queue.Enqueue(left.Left);
            queue.Enqueue(right.Right);
            queue.Enqueue(left.Right);
            queue.Enqueue(right.Left);
        }

        return true;
    }
}
