namespace Trees;

/// <summary>
/// Q3: MaximumDepth
/// Problema: encontrar a profundidade máxima de uma árvore binária usando DFS recursiva,
/// BFS com contagem de níveis e DFS iterativa.
/// </summary>
public class MaximumDepth
{
    private readonly TreeNode? _root;

    public MaximumDepth(TreeNode? root)
    {
        _root = root;
    }

    // Tempo: O(n). Espaço auxiliar: O(h), onde h é a altura da árvore.
    public int FindMaxDepthRecursive()
    {
        return FindMaxDepthRecursive(_root);
    }

    private static int FindMaxDepthRecursive(TreeNode? node)
    {
        if (node is null)
            return 0;

        return 1 + Math.Max(
            FindMaxDepthRecursive(node.Left),
            FindMaxDepthRecursive(node.Right));
    }

    // Tempo: O(n). Espaço auxiliar: O(w), onde w é a largura máxima.
    public int FindMaxDepthBfs()
    {
        if (_root is null)
            return 0;

        Queue<TreeNode> queue = new();
        queue.Enqueue(_root);
        int depth = 0;

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            depth++;

            for (int i = 0; i < levelSize; i++)
            {
                TreeNode current = queue.Dequeue();

                if (current.Left is not null)
                    queue.Enqueue(current.Left);

                if (current.Right is not null)
                    queue.Enqueue(current.Right);
            }
        }

        return depth;
    }

    // Tempo: O(n). Espaço auxiliar: O(h).
    public int FindMaxDepthIterative()
    {
        if (_root is null)
            return 0;

        Stack<(TreeNode Node, int Depth)> stack = new();
        stack.Push((_root, 1));
        int maxDepth = 0;

        while (stack.Count > 0)
        {
            (TreeNode current, int depth) = stack.Pop();
            maxDepth = Math.Max(maxDepth, depth);

            if (current.Right is not null)
                stack.Push((current.Right, depth + 1));

            if (current.Left is not null)
                stack.Push((current.Left, depth + 1));
        }

        return maxDepth;
    }
}
