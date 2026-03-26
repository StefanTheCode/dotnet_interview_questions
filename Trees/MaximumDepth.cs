namespace Trees;

/// <summary>
/// Q3: MaximumDepth
/// Task: Find the maximum depth (height) of a binary tree using multiple approaches:
/// 1. Recursive DFS (O(n) time, O(h) space)
/// 2. BFS with level counting (O(n) time, O(n) space)
/// 3. Iterative DFS with explicit stack (O(n) time, O(h) space)
/// </summary>
public class MaximumDepth
{
    private TreeNode? _root;

    public MaximumDepth(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Recursive DFS
    // - Depth of a node = 1 + max(depth of left, depth of right)
    // - Base case: null node has depth 0
    // Time: O(n), Space: O(h)
    public int FindMaxDepthRecursive()
    {
        return MaxDepthHelper(_root);
    }

    private int MaxDepthHelper(TreeNode? node)
    {
        if (node == null) return 0;

        int leftDepth = MaxDepthHelper(node.Left);
        int rightDepth = MaxDepthHelper(node.Right);

        return 1 + Math.Max(leftDepth, rightDepth);
    }

    // 2️. BFS Level Counting
    // - Count the number of levels using level order traversal
    // - Each full level iteration increments depth by 1
    // Time: O(n), Space: O(n)
    public int FindMaxDepthBFS()
    {
        if (_root == null) return 0;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(_root);
        int depth = 0;

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            depth++;

            for (int i = 0; i < levelSize; i++)
            {
                TreeNode current = queue.Dequeue();
                if (current.Left != null) queue.Enqueue(current.Left);
                if (current.Right != null) queue.Enqueue(current.Right);
            }
        }

        return depth;
    }

    // 3️. Iterative DFS with Stack
    // - Track each node with its depth
    // - Keep updating the maximum depth seen
    // Time: O(n), Space: O(h)
    public int FindMaxDepthIterative()
    {
        if (_root == null) return 0;

        Stack<(TreeNode node, int depth)> stack = new Stack<(TreeNode, int)>();
        stack.Push((_root, 1));
        int maxDepth = 0;

        while (stack.Count > 0)
        {
            var (current, depth) = stack.Pop();
            maxDepth = Math.Max(maxDepth, depth);

            if (current.Right != null) stack.Push((current.Right, depth + 1));
            if (current.Left != null) stack.Push((current.Left, depth + 1));
        }

        return maxDepth;
    }
}
