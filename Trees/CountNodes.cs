namespace Trees;

/// <summary>
/// Q18: CountNodes
/// Problema: contar todos os nós e somente as folhas de uma árvore binária.
/// </summary>
public class CountNodes
{
    private readonly TreeNode? _root;

    public CountNodes(TreeNode? root)
    {
        _root = root;
    }

    // Tempo: O(n). Espaço auxiliar: O(h).
    public int CountAllRecursive()
    {
        return CountAllRecursive(_root);
    }

    private static int CountAllRecursive(TreeNode? node)
    {
        return node is null
            ? 0
            : 1 + CountAllRecursive(node.Left) + CountAllRecursive(node.Right);
    }

    // Tempo: O(n). Espaço auxiliar: O(h).
    public int CountLeaves()
    {
        return CountLeaves(_root);
    }

    private static int CountLeaves(TreeNode? node)
    {
        if (node is null)
            return 0;

        if (node.Left is null && node.Right is null)
            return 1;

        return CountLeaves(node.Left) + CountLeaves(node.Right);
    }

    // Tempo: O(n). Espaço auxiliar: O(w), onde w é a largura máxima.
    public int CountAllBfs()
    {
        if (_root is null)
            return 0;

        int count = 0;
        Queue<TreeNode> queue = new();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();
            count++;

            if (current.Left is not null)
                queue.Enqueue(current.Left);

            if (current.Right is not null)
                queue.Enqueue(current.Right);
        }

        return count;
    }
}
