namespace Trees;

/// <summary>
/// Q11: FindMinMaxBST
/// Problema: encontrar os valores mínimo e máximo de uma Binary Search Tree.
///
/// Em uma BST válida sem duplicados, o menor valor está no nó mais à esquerda
/// e o maior valor está no nó mais à direita.
/// </summary>
public class FindMinMaxBST
{
    private readonly TreeNode? _root;

    public FindMinMaxBST(TreeNode? root)
    {
        _root = root;
    }

    // Tempo: O(h). Espaço auxiliar: O(h), devido à pilha de chamadas.
    public int? FindMinRecursive()
    {
        return _root is null ? null : FindMinRecursive(_root);
    }

    private static int FindMinRecursive(TreeNode node)
    {
        return node.Left is null
            ? node.Value
            : FindMinRecursive(node.Left);
    }

    // Tempo: O(h). Espaço auxiliar: O(h), devido à pilha de chamadas.
    public int? FindMaxRecursive()
    {
        return _root is null ? null : FindMaxRecursive(_root);
    }

    private static int FindMaxRecursive(TreeNode node)
    {
        return node.Right is null
            ? node.Value
            : FindMaxRecursive(node.Right);
    }

    // Tempo: O(h). Espaço auxiliar: O(1).
    public int? FindMinIterative()
    {
        if (_root is null)
            return null;

        TreeNode current = _root;

        while (current.Left is not null)
            current = current.Left;

        return current.Value;
    }

    // Tempo: O(h). Espaço auxiliar: O(1).
    public int? FindMaxIterative()
    {
        if (_root is null)
            return null;

        TreeNode current = _root;

        while (current.Right is not null)
            current = current.Right;

        return current.Value;
    }
}
