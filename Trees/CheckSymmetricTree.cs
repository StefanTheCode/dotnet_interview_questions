namespace Trees;

/// <summary>
/// Q14: CheckSymmetricTree
/// Problema: verificar se uma árvore binária é simétrica em relação ao nó raiz.
/// </summary>
public class CheckSymmetricTree
{
    private readonly TreeNode? _root;

    public CheckSymmetricTree(TreeNode? root)
    {
        _root = root;
    }

    // Tempo: O(n). Espaço auxiliar: O(h).
    public bool IsSymmetricRecursive()
    {
        return _root is null || IsMirror(_root.Left, _root.Right);
    }

    private static bool IsMirror(TreeNode? left, TreeNode? right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return false;

        return left.Value == right.Value
            && IsMirror(left.Left, right.Right)
            && IsMirror(left.Right, right.Left);
    }

    // Tempo: O(n). Espaço auxiliar: O(w), onde w é a largura máxima.
    public bool IsSymmetricIterative()
    {
        if (_root is null)
            return true;

        Queue<(TreeNode? Left, TreeNode? Right)> queue = new();
        queue.Enqueue((_root.Left, _root.Right));

        while (queue.Count > 0)
        {
            (TreeNode? left, TreeNode? right) = queue.Dequeue();

            if (left is null && right is null)
                continue;

            if (left is null || right is null || left.Value != right.Value)
                return false;

            queue.Enqueue((left.Left, right.Right));
            queue.Enqueue((left.Right, right.Left));
        }

        return true;
    }
}
