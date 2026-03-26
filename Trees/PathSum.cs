namespace Trees;

/// <summary>
/// Q16: PathSum
/// Task: Determine whether any root-to-leaf path in a binary tree sums to a given target
/// using multiple approaches:
/// 1. Recursive DFS (O(n) time, O(h) space)
/// 2. Iterative DFS with Stack (O(n) time, O(h) space)
/// 3. Find all paths that sum to target (returns the actual paths)
/// </summary>
public class PathSum
{
    private TreeNode? _root;

    public PathSum(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Recursive DFS
    // - Subtract current node value from target
    // - At a leaf, check if remaining target == 0
    // Time: O(n), Space: O(h)
    public bool HasPathSumRecursive(int targetSum)
    {
        return HasPathSumHelper(_root, targetSum);
    }

    private bool HasPathSumHelper(TreeNode? node, int remaining)
    {
        if (node == null) return false;

        remaining -= node.Value;

        // Leaf node: check if path sum matches
        if (node.Left == null && node.Right == null)
            return remaining == 0;

        return HasPathSumHelper(node.Left, remaining)
            || HasPathSumHelper(node.Right, remaining);
    }

    // 2️. Iterative DFS with Stack
    // - Track each node along with the remaining sum to that point
    // Time: O(n), Space: O(h)
    public bool HasPathSumIterative(int targetSum)
    {
        if (_root == null) return false;

        Stack<(TreeNode node, int remaining)> stack = new Stack<(TreeNode, int)>();
        stack.Push((_root, targetSum - _root.Value));

        while (stack.Count > 0)
        {
            var (current, remaining) = stack.Pop();

            // Leaf node: check if path sum matches
            if (current.Left == null && current.Right == null && remaining == 0)
                return true;

            if (current.Right != null)
                stack.Push((current.Right, remaining - current.Right.Value));
            if (current.Left != null)
                stack.Push((current.Left, remaining - current.Left.Value));
        }

        return false;
    }

    // 3️. Find All Paths with Target Sum
    // - Return all root-to-leaf paths that sum to target
    // - Useful when interviewer asks for the actual paths, not just true/false
    // Time: O(n), Space: O(n * h) for storing paths
    public List<List<int>> FindAllPaths(int targetSum)
    {
        List<List<int>> result = new List<List<int>>();
        FindAllPathsHelper(_root, targetSum, new List<int>(), result);
        return result;
    }

    private void FindAllPathsHelper(TreeNode? node, int remaining, List<int> currentPath, List<List<int>> result)
    {
        if (node == null) return;

        currentPath.Add(node.Value);
        remaining -= node.Value;

        if (node.Left == null && node.Right == null && remaining == 0)
        {
            result.Add(new List<int>(currentPath)); // Copy the path
        }
        else
        {
            FindAllPathsHelper(node.Left, remaining, currentPath, result);
            FindAllPathsHelper(node.Right, remaining, currentPath, result);
        }

        currentPath.RemoveAt(currentPath.Count - 1); // Backtrack
    }
}
