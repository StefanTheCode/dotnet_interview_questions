namespace Trees;

/// <summary>
/// Q7: InvertBinaryTree
/// Task: Invert (mirror) a binary tree so that left and right children are swapped at every level
/// using multiple approaches:
/// 1. Recursive DFS inversion (O(n) time, O(h) space)
/// 2. Iterative BFS inversion with Queue (O(n) time, O(n) space)
/// 3. Iterative DFS inversion with Stack (O(n) time, O(h) space)
/// </summary>
public class InvertBinaryTree
{
    private TreeNode? _root;

    public InvertBinaryTree(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Recursive DFS Inversion
    // - Swap left and right children of current node
    // - Recursively invert left and right subtrees
    // Time: O(n), Space: O(h)
    public TreeNode? InvertRecursive()
    {
        return InvertHelper(_root);
    }

    private TreeNode? InvertHelper(TreeNode? node)
    {
        if (node == null) return null;

        // Swap left and right
        TreeNode? temp = node.Left;
        node.Left = node.Right;
        node.Right = temp;

        // Recurse on both subtrees
        InvertHelper(node.Left);
        InvertHelper(node.Right);

        return node;
    }

    // 2️. Iterative BFS with Queue
    // - Process each node level by level, swapping children at each node
    // Time: O(n), Space: O(n)
    public TreeNode? InvertBFS()
    {
        if (_root == null) return null;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();

            // Swap children
            (current.Left, current.Right) = (current.Right, current.Left);

            if (current.Left != null) queue.Enqueue(current.Left);
            if (current.Right != null) queue.Enqueue(current.Right);
        }

        return _root;
    }

    // 3️. Iterative DFS with Stack
    // - Same idea as BFS but uses a stack (depth-first order)
    // Time: O(n), Space: O(h)
    public TreeNode? InvertDFS()
    {
        if (_root == null) return null;

        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(_root);

        while (stack.Count > 0)
        {
            TreeNode current = stack.Pop();

            // Swap children
            (current.Left, current.Right) = (current.Right, current.Left);

            if (current.Left != null) stack.Push(current.Left);
            if (current.Right != null) stack.Push(current.Right);
        }

        return _root;
    }
}
