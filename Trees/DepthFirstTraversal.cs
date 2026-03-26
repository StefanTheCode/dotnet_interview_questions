namespace Trees;

/// <summary>
/// Q1: DepthFirstTraversal
/// Task: Traverse a binary tree using depth-first strategies:
/// 1. Recursive Preorder, Inorder, and Postorder traversals
/// 2. Iterative Preorder using an explicit stack
/// 3. Iterative Inorder using an explicit stack
/// </summary>
public class DepthFirstTraversal
{
    private TreeNode? _root;

    public DepthFirstTraversal(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Recursive Preorder: Root → Left → Right
    // Time: O(n), Space: O(h) where h is tree height (call stack)
    public List<int> PreorderRecursive()
    {
        List<int> result = new List<int>();
        PreorderHelper(_root, result);
        return result;
    }

    private void PreorderHelper(TreeNode? node, List<int> result)
    {
        if (node == null) return;

        result.Add(node.Value);       // Visit root
        PreorderHelper(node.Left, result);  // Traverse left
        PreorderHelper(node.Right, result); // Traverse right
    }

    // 1️. Recursive Inorder: Left → Root → Right
    // Time: O(n), Space: O(h)
    public List<int> InorderRecursive()
    {
        List<int> result = new List<int>();
        InorderHelper(_root, result);
        return result;
    }

    private void InorderHelper(TreeNode? node, List<int> result)
    {
        if (node == null) return;

        InorderHelper(node.Left, result);   // Traverse left
        result.Add(node.Value);        // Visit root
        InorderHelper(node.Right, result);  // Traverse right
    }

    // 1️. Recursive Postorder: Left → Right → Root
    // Time: O(n), Space: O(h)
    public List<int> PostorderRecursive()
    {
        List<int> result = new List<int>();
        PostorderHelper(_root, result);
        return result;
    }

    private void PostorderHelper(TreeNode? node, List<int> result)
    {
        if (node == null) return;

        PostorderHelper(node.Left, result);  // Traverse left
        PostorderHelper(node.Right, result); // Traverse right
        result.Add(node.Value);         // Visit root
    }

    // 2️. Iterative Preorder using Stack
    // - Push root, then loop: pop, visit, push right then left
    // Time: O(n), Space: O(h)
    public List<int> PreorderIterative()
    {
        List<int> result = new List<int>();
        if (_root == null) return result;

        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(_root);

        while (stack.Count > 0)
        {
            TreeNode current = stack.Pop();
            result.Add(current.Value);

            // Push right first so left is processed first
            if (current.Right != null) stack.Push(current.Right);
            if (current.Left != null) stack.Push(current.Left);
        }

        return result;
    }

    // 3️. Iterative Inorder using Stack
    // - Go left as far as possible, then pop, visit, go right
    // Time: O(n), Space: O(h)
    public List<int> InorderIterative()
    {
        List<int> result = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode? current = _root;

        while (current != null || stack.Count > 0)
        {
            // Go to the leftmost node
            while (current != null)
            {
                stack.Push(current);
                current = current.Left;
            }

            current = stack.Pop();
            result.Add(current.Value);
            current = current.Right;
        }

        return result;
    }
}
