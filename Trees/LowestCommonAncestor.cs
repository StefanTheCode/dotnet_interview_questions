namespace Trees;

/// <summary>
/// Q12: LowestCommonAncestor
/// Problema: encontrar o ancestral comum mais baixo (Lowest Common Ancestor — LCA)
/// de dois valores em uma árvore binária geral e em uma BST.
///
/// As implementações pressupõem valores únicos. Caso um dos valores não exista,
/// o resultado é <see langword="null"/>.
/// </summary>
public class LowestCommonAncestor
{
    private readonly TreeNode? _root;

    public LowestCommonAncestor(TreeNode? root)
    {
        _root = root;
    }

    // Árvore binária geral. Tempo: O(n). Espaço auxiliar: O(h).
    public TreeNode? FindLca(int firstValue, int secondValue)
    {
        if (firstValue == secondValue)
            return FindNode(_root, firstValue);

        if (!Contains(_root, firstValue) || !Contains(_root, secondValue))
            return null;

        return FindLcaCore(_root, firstValue, secondValue);
    }

    private static TreeNode? FindLcaCore(TreeNode? node, int firstValue, int secondValue)
    {
        if (node is null || node.Value == firstValue || node.Value == secondValue)
            return node;

        TreeNode? left = FindLcaCore(node.Left, firstValue, secondValue);
        TreeNode? right = FindLcaCore(node.Right, firstValue, secondValue);

        if (left is not null && right is not null)
            return node;

        return left ?? right;
    }

    // BST recursiva. Tempo: O(h). Espaço auxiliar: O(h).
    public TreeNode? FindLcaInBst(int firstValue, int secondValue)
    {
        if (!ContainsInBst(firstValue) || !ContainsInBst(secondValue))
            return null;

        return FindLcaInBstCore(_root, firstValue, secondValue);
    }

    private static TreeNode? FindLcaInBstCore(
        TreeNode? node,
        int firstValue,
        int secondValue)
    {
        if (node is null)
            return null;

        if (firstValue < node.Value && secondValue < node.Value)
            return FindLcaInBstCore(node.Left, firstValue, secondValue);

        if (firstValue > node.Value && secondValue > node.Value)
            return FindLcaInBstCore(node.Right, firstValue, secondValue);

        return node;
    }

    // BST iterativa. Tempo: O(h). Espaço auxiliar: O(1).
    public TreeNode? FindLcaInBstIterative(int firstValue, int secondValue)
    {
        if (!ContainsInBst(firstValue) || !ContainsInBst(secondValue))
            return null;

        TreeNode? current = _root;

        while (current is not null)
        {
            if (firstValue < current.Value && secondValue < current.Value)
            {
                current = current.Left;
            }
            else if (firstValue > current.Value && secondValue > current.Value)
            {
                current = current.Right;
            }
            else
            {
                return current;
            }
        }

        return null;
    }

    private bool ContainsInBst(int value)
    {
        TreeNode? current = _root;

        while (current is not null)
        {
            if (value == current.Value)
                return true;

            current = value < current.Value ? current.Left : current.Right;
        }

        return false;
    }

    private static bool Contains(TreeNode? node, int value)
    {
        return FindNode(node, value) is not null;
    }

    private static TreeNode? FindNode(TreeNode? node, int value)
    {
        if (node is null || node.Value == value)
            return node;

        return FindNode(node.Left, value) ?? FindNode(node.Right, value);
    }
}
