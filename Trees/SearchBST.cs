namespace Trees;

/// <summary>
/// Q9: SearchBST
/// Problema: procurar um valor em uma Binary Search Tree:
/// 1. Busca recursiva;
/// 2. Busca iterativa sem custo de pilha de chamadas.
///
/// As abordagens pressupõem que a árvore recebida seja uma BST válida.
/// </summary>
public class SearchBST
{
    private readonly TreeNode? _root;

    public SearchBST(TreeNode? root)
    {
        _root = root;
    }

    // Tempo: O(h). Espaço auxiliar: O(h).
    public TreeNode? SearchRecursive(int target)
    {
        return SearchRecursive(_root, target);
    }

    private static TreeNode? SearchRecursive(TreeNode? node, int target)
    {
        if (node is null || node.Value == target)
            return node;

        return target < node.Value
            ? SearchRecursive(node.Left, target)
            : SearchRecursive(node.Right, target);
    }

    // Tempo: O(h). Espaço auxiliar: O(1).
    public TreeNode? SearchIterative(int target)
    {
        TreeNode? current = _root;

        while (current is not null)
        {
            if (current.Value == target)
                return current;

            current = target < current.Value
                ? current.Left
                : current.Right;
        }

        return null;
    }
}
