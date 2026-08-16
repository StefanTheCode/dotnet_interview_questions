namespace Trees;

/// <summary>
/// Q10: InsertIntoBST
/// Insere um valor em uma Binary Search Tree por recursão ou iteração.
/// Valores duplicados são ignorados e a árvore recebida é modificada.
/// </summary>
public class InsertIntoBST
{
    private TreeNode? _root;

    public InsertIntoBST(TreeNode? root)
    {
        _root = root;
    }

    public TreeNode? CurrentRoot => _root;

    // Tempo: O(h). Espaço auxiliar: O(h).
    public TreeNode InsertRecursive(int value)
    {
        _root = InsertNodeRecursive(_root, value);
        return _root;
    }

    private static TreeNode InsertNodeRecursive(TreeNode? node, int value)
    {
        if (node is null)
            return new TreeNode(value);

        if (value < node.Value)
            node.Left = InsertNodeRecursive(node.Left, value);
        else if (value > node.Value)
            node.Right = InsertNodeRecursive(node.Right, value);

        return node;
    }

    // Tempo: O(h). Espaço auxiliar: O(1).
    public TreeNode InsertIterative(int value)
    {
        if (_root is null)
        {
            _root = new TreeNode(value);
            return _root;
        }

        TreeNode current = _root;

        while (true)
        {
            if (value == current.Value)
                return _root;

            if (value < current.Value)
            {
                if (current.Left is null)
                {
                    current.Left = new TreeNode(value);
                    return _root;
                }

                current = current.Left;
            }
            else
            {
                if (current.Right is null)
                {
                    current.Right = new TreeNode(value);
                    return _root;
                }

                current = current.Right;
            }
        }
    }

    public TreeNode? GetRoot() => _root;
}
