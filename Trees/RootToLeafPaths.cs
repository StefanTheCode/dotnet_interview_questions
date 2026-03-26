namespace Trees;

/// <summary>
/// Q17: RootToLeafPaths
/// Task: Find all root-to-leaf paths in a binary tree using multiple approaches:
/// 1. Recursive DFS with path tracking (O(n) time, O(n * h) space)
/// 2. Iterative DFS with Stack and path tracking (O(n) time, O(n * h) space)
/// 3. Return paths as formatted strings (common interview request)
/// </summary>
public class RootToLeafPaths
{
    private TreeNode? _root;

    public RootToLeafPaths(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Recursive DFS with Path Tracking
    // - Build the path as we recurse, copy it when a leaf is reached
    // Time: O(n), Space: O(n * h)
    public List<List<int>> FindAllPathsRecursive()
    {
        List<List<int>> result = new List<List<int>>();
        FindPathsHelper(_root, new List<int>(), result);
        return result;
    }

    private void FindPathsHelper(TreeNode? node, List<int> currentPath, List<List<int>> result)
    {
        if (node == null) return;

        currentPath.Add(node.Value);

        // Leaf node: save a copy of the current path
        if (node.Left == null && node.Right == null)
        {
            result.Add(new List<int>(currentPath));
        }
        else
        {
            FindPathsHelper(node.Left, currentPath, result);
            FindPathsHelper(node.Right, currentPath, result);
        }

        currentPath.RemoveAt(currentPath.Count - 1); // Backtrack
    }

    // 2️. Iterative DFS with Stack
    // - Track each node along with its path from root
    // Time: O(n), Space: O(n * h)
    public List<List<int>> FindAllPathsIterative()
    {
        List<List<int>> result = new List<List<int>>();
        if (_root == null) return result;

        Stack<(TreeNode node, List<int> path)> stack = new Stack<(TreeNode, List<int>)>();
        stack.Push((_root, new List<int> { _root.Value }));

        while (stack.Count > 0)
        {
            var (current, path) = stack.Pop();

            if (current.Left == null && current.Right == null)
            {
                result.Add(path);
                continue;
            }

            if (current.Right != null)
            {
                List<int> rightPath = new List<int>(path) { current.Right.Value };
                stack.Push((current.Right, rightPath));
            }

            if (current.Left != null)
            {
                List<int> leftPath = new List<int>(path) { current.Left.Value };
                stack.Push((current.Left, leftPath));
            }
        }

        return result;
    }

    // 3️. Paths as Formatted Strings
    // - Common interview variant: return paths as "1->2->3" strings
    // Time: O(n), Space: O(n * h)
    public List<string> FindAllPathsAsStrings()
    {
        List<string> result = new List<string>();
        FindPathStringsHelper(_root, "", result);
        return result;
    }

    private void FindPathStringsHelper(TreeNode? node, string currentPath, List<string> result)
    {
        if (node == null) return;

        string path = string.IsNullOrEmpty(currentPath)
            ? node.Value.ToString()
            : $"{currentPath}->{node.Value}";

        if (node.Left == null && node.Right == null)
        {
            result.Add(path);
            return;
        }

        FindPathStringsHelper(node.Left, path, result);
        FindPathStringsHelper(node.Right, path, result);
    }
}
