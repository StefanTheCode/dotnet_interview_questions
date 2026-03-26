namespace Trees;

/// <summary>
/// Q19: KthSmallestInBST
/// Task: Find the Kth smallest element in a Binary Search Tree using multiple approaches:
/// 1. Inorder traversal into a list, then index (O(n) time, O(n) space)
/// 2. Inorder traversal with early stop counter (O(n) worst case, O(k) average, O(h) space)
/// 3. Iterative inorder with early stop (O(k) time, O(h) space, optimal)
/// </summary>
public class KthSmallestInBST
{
    private TreeNode? _root;

    public KthSmallestInBST(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Inorder to List, Then Index
    // - Full inorder traversal produces sorted order in a BST
    // - Return element at index k-1
    // Time: O(n), Space: O(n)
    public int? FindKthSmallestWithList(int k)
    {
        List<int> sorted = new List<int>();
        InorderCollect(_root, sorted);

        if (k < 1 || k > sorted.Count) return null;
        return sorted[k - 1];
    }

    private void InorderCollect(TreeNode? node, List<int> result)
    {
        if (node == null) return;
        InorderCollect(node.Left, result);
        result.Add(node.Value);
        InorderCollect(node.Right, result);
    }

    // 2️. Recursive Inorder with Early Stop
    // - Count visited nodes during inorder traversal
    // - Stop as soon as we reach the kth element
    // Time: O(k) average, Space: O(h)
    public int? FindKthSmallestRecursive(int k)
    {
        int count = 0;
        int? result = null;
        InorderWithCounter(_root, k, ref count, ref result);
        return result;
    }

    private void InorderWithCounter(TreeNode? node, int k, ref int count, ref int? result)
    {
        if (node == null || result != null) return;

        InorderWithCounter(node.Left, k, ref count, ref result);

        count++;
        if (count == k)
        {
            result = node.Value;
            return;
        }

        InorderWithCounter(node.Right, k, ref count, ref result);
    }

    // 3️. Iterative Inorder with Early Stop — Optimal
    // - Use explicit stack for inorder traversal
    // - Stop at the kth element without visiting remaining nodes
    // Time: O(h + k), Space: O(h)
    public int? FindKthSmallestIterative(int k)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode? current = _root;
        int count = 0;

        while (current != null || stack.Count > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.Left;
            }

            current = stack.Pop();
            count++;

            if (count == k)
                return current.Value;

            current = current.Right;
        }

        return null; // k is out of range
    }
}
