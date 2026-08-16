namespace Trees;

/// <summary>
/// Q4: MinimumDepth
/// Problema: encontrar o caminho mais curto da raiz até uma folha:
/// 1. DFS recursiva;
/// 2. BFS que termina na primeira folha encontrada.
/// </summary>
public class MinimumDepth
{
    private readonly TreeNode? _root;

    public MinimumDepth(TreeNode? root)
    {
        _root = root;
    }

    // Um nó com somente um filho não é folha; nesse caso, a busca deve seguir pelo filho existente.
    // Tempo: O(n). Espaço auxiliar: O(h).
    public int FindMinDepthRecursive()
    {
        return FindMinDepthRecursive(_root);
    }

    private static int FindMinDepthRecursive(TreeNode? node)
    {
        if (node is null)
            return 0;

        if (node.Left is null)
            return 1 + FindMinDepthRecursive(node.Right);

        if (node.Right is null)
            return 1 + FindMinDepthRecursive(node.Left);

        return 1 + Math.Min(
            FindMinDepthRecursive(node.Left),
            FindMinDepthRecursive(node.Right));
    }

    // A primeira folha removida da fila está necessariamente na menor profundidade.
    // Tempo: O(n) no pior caso. Espaço auxiliar: O(w).
    public int FindMinDepthBFS()
    {
        if (_root is null)
            return 0;

        Queue<(TreeNode Node, int Depth)> queue = new();
        queue.Enqueue((_root, 1));

        while (queue.Count > 0)
        {
            (TreeNode current, int depth) = queue.Dequeue();

            if (current.Left is null && current.Right is null)
                return depth;

            if (current.Left is not null)
                queue.Enqueue((current.Left, depth + 1));

            if (current.Right is not null)
                queue.Enqueue((current.Right, depth + 1));
        }

        throw new InvalidOperationException("A árvore contém uma estrutura inválida.");
    }
}
