namespace Trees;

/// <summary>
/// Q1: DepthFirstTraversal
/// Problema: percorrer uma árvore binária usando estratégias de busca em profundidade:
/// 1. Pré-ordem, em ordem e pós-ordem recursivas;
/// 2. Pré-ordem iterativa com uma pilha explícita;
/// 3. Em ordem iterativa com uma pilha explícita.
/// </summary>
public class DepthFirstTraversal
{
    private readonly TreeNode? _root;

    public DepthFirstTraversal(TreeNode? root)
    {
        _root = root;
    }

    // Pré-ordem recursiva: raiz → esquerda → direita.
    // Tempo: O(n). Espaço auxiliar: O(h), onde h é a altura da árvore.
    public List<int> PreorderRecursive()
    {
        List<int> result = [];
        PreorderHelper(_root, result);
        return result;
    }

    private static void PreorderHelper(TreeNode? node, List<int> result)
    {
        if (node is null)
            return;

        result.Add(node.Value);
        PreorderHelper(node.Left, result);
        PreorderHelper(node.Right, result);
    }

    // Em ordem recursiva: esquerda → raiz → direita.
    // Em uma BST válida, produz os valores em ordem crescente.
    // Tempo: O(n). Espaço auxiliar: O(h).
    public List<int> InorderRecursive()
    {
        List<int> result = [];
        InorderHelper(_root, result);
        return result;
    }

    private static void InorderHelper(TreeNode? node, List<int> result)
    {
        if (node is null)
            return;

        InorderHelper(node.Left, result);
        result.Add(node.Value);
        InorderHelper(node.Right, result);
    }

    // Pós-ordem recursiva: esquerda → direita → raiz.
    // Tempo: O(n). Espaço auxiliar: O(h).
    public List<int> PostorderRecursive()
    {
        List<int> result = [];
        PostorderHelper(_root, result);
        return result;
    }

    private static void PostorderHelper(TreeNode? node, List<int> result)
    {
        if (node is null)
            return;

        PostorderHelper(node.Left, result);
        PostorderHelper(node.Right, result);
        result.Add(node.Value);
    }

    // Pré-ordem iterativa.
    // A subárvore direita é empilhada antes da esquerda para que a esquerda seja processada primeiro.
    // Tempo: O(n). Espaço auxiliar: O(h).
    public List<int> PreorderIterative()
    {
        List<int> result = [];
        if (_root is null)
            return result;

        Stack<TreeNode> stack = new();
        stack.Push(_root);

        while (stack.Count > 0)
        {
            TreeNode current = stack.Pop();
            result.Add(current.Value);

            if (current.Right is not null)
                stack.Push(current.Right);

            if (current.Left is not null)
                stack.Push(current.Left);
        }

        return result;
    }

    // Em ordem iterativa.
    // Avança até o nó mais à esquerda, visita o nó atual e então percorre sua subárvore direita.
    // Tempo: O(n). Espaço auxiliar: O(h).
    public List<int> InorderIterative()
    {
        List<int> result = [];
        Stack<TreeNode> stack = new();
        TreeNode? current = _root;

        while (current is not null || stack.Count > 0)
        {
            while (current is not null)
            {
                stack.Push(current);
                current = current.Left;
            }

            current = stack.Pop();
            result.Add(current.Value);
            current = current.Right;
        }

        return result;
    }
}
