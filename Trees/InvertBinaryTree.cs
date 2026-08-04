namespace Trees;

/// <summary>
/// Q7: InvertBinaryTree
/// Problema: espelhar uma árvore binária, trocando os filhos esquerdo e direito de todos os nós:
/// 1. DFS recursiva;
/// 2. BFS iterativa;
/// 3. DFS iterativa.
///
/// Todas as abordagens modificam a árvore recebida.
/// </summary>
public class InvertBinaryTree
{
    private readonly TreeNode? _root;

    public InvertBinaryTree(TreeNode? root)
    {
        _root = root;
    }

    public TreeNode? CurrentRoot => _root;

    // Tempo: O(n). Espaço auxiliar: O(h).
    public TreeNode? InvertRecursive()
    {
        return InvertRecursive(_root);
    }

    private static TreeNode? InvertRecursive(TreeNode? node)
    {
        if (node is null)
            return null;

        (node.Left, node.Right) = (node.Right, node.Left);
        InvertRecursive(node.Left);
        InvertRecursive(node.Right);

        return node;
    }

    // Tempo: O(n). Espaço auxiliar: O(w), onde w é a largura máxima.
    public TreeNode? InvertBFS()
    {
        if (_root is null)
            return null;

        Queue<TreeNode> queue = new();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();
            (current.Left, current.Right) = (current.Right, current.Left);

            if (current.Left is not null)
                queue.Enqueue(current.Left);

            if (current.Right is not null)
                queue.Enqueue(current.Right);
        }

        return _root;
    }

    // Tempo: O(n). Espaço auxiliar: O(h).
    public TreeNode? InvertDFS()
    {
        if (_root is null)
            return null;

        Stack<TreeNode> stack = new();
        stack.Push(_root);

        while (stack.Count > 0)
        {
            TreeNode current = stack.Pop();
            (current.Left, current.Right) = (current.Right, current.Left);

            if (current.Right is not null)
                stack.Push(current.Right);

            if (current.Left is not null)
                stack.Push(current.Left);
        }

        return _root;
    }
}
