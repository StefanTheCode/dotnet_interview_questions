namespace Trees;

/// <summary>
/// Q10: InsertIntoBST
/// Task: Insert a new value into a Binary Search Tree maintaining BST property
/// using multiple approaches:
/// 1. Recursive insertion (O(h) time, O(h) space)
/// 2. Iterative insertion (O(h) time, O(1) space, optimal)
/// </summary>
public class InsertIntoBST
{
    private TreeNode? _root;

    public InsertIntoBST(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Recursive Insertion
    // - Navigate the tree recursively
    // - Insert as a new leaf in the correct position
    // Time: O(h), Space: O(h) due to call stack
    public TreeNode InsertRecursive(int value)
    {
        _root = InsertHelper(_root, value);
        return _root;
    }

    private TreeNode InsertHelper(TreeNode? node, int value)
    {
        if (node == null)
            return new TreeNode(value);

        if (value < node.Value)
            node.Left = InsertHelper(node.Left, value);
        else if (value > node.Value)
            node.Right = InsertHelper(node.Right, value);

        // If value == node.Value, ignore duplicates (standard BST behavior)
        return node;
    }

    // 2️. Iterative Insertion — Optimal
    // - Find the correct parent node, then attach the new leaf
    // - No recursion overhead
    // Time: O(h), Space: O(1)
    public TreeNode InsertIterative(int value)
    {
        TreeNode newNode = new TreeNode(value);
        if (_root == null)
        {
            _root = newNode;
            return _root;
        }

        TreeNode current = _root;
        TreeNode? parent = null;

        while (current != null)
        {
            parent = current;
            if (value < current.Value)
                current = current.Left!;
            else if (value > current.Value)
                current = current.Right!;
            else
                return _root; // Duplicate, do not insert
        }

        // Attach the new node to the correct parent
        if (value < parent!.Value)
            parent.Left = newNode;
        else
            parent.Right = newNode;

        return _root;
    }

    public TreeNode? GetRoot() => _root;
}
