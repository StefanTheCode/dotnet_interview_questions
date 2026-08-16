namespace Trees;

/// <summary>
/// Q19: KthSmallestInBST
/// Problema: encontrar o k-ésimo menor valor de uma Binary Search Tree.
///
/// A travessia em ordem de uma BST válida sem duplicados produz os valores
/// em ordem crescente. Valores de k menores ou iguais a zero são inválidos;
/// quando k excede a quantidade de nós, o resultado é <see langword="null"/>.
/// </summary>
public class KthSmallestInBST
{
    private readonly TreeNode? _root;

    public KthSmallestInBST(TreeNode? root)
    {
        _root = root;
    }

    // Tempo: O(n). Espaço: O(n).
    public int? FindKthSmallestWithList(int k)
    {
        ValidateK(k);

        List<int> sorted = [];
        CollectInorder(_root, sorted);

        return k <= sorted.Count ? sorted[k - 1] : null;
    }

    private static void CollectInorder(TreeNode? node, List<int> result)
    {
        if (node is null)
            return;

        CollectInorder(node.Left, result);
        result.Add(node.Value);
        CollectInorder(node.Right, result);
    }

    // Tempo: O(h + k), no melhor uso da interrupção antecipada; pior caso O(n).
    // Espaço auxiliar: O(h).
    public int? FindKthSmallestRecursive(int k)
    {
        ValidateK(k);

        int visited = 0;
        int? result = null;
        FindKthSmallestRecursive(_root, k, ref visited, ref result);
        return result;
    }

    private static void FindKthSmallestRecursive(
        TreeNode? node,
        int k,
        ref int visited,
        ref int? result)
    {
        if (node is null || result.HasValue)
            return;

        FindKthSmallestRecursive(node.Left, k, ref visited, ref result);

        if (result.HasValue)
            return;

        visited++;

        if (visited == k)
        {
            result = node.Value;
            return;
        }

        FindKthSmallestRecursive(node.Right, k, ref visited, ref result);
    }

    // Tempo: O(h + k), com pior caso O(n). Espaço auxiliar: O(h).
    public int? FindKthSmallestIterative(int k)
    {
        ValidateK(k);

        Stack<TreeNode> stack = new();
        TreeNode? current = _root;
        int visited = 0;

        while (current is not null || stack.Count > 0)
        {
            while (current is not null)
            {
                stack.Push(current);
                current = current.Left;
            }

            current = stack.Pop();
            visited++;

            if (visited == k)
                return current.Value;

            current = current.Right;
        }

        return null;
    }

    private static void ValidateK(int k)
    {
        if (k <= 0)
            throw new ArgumentOutOfRangeException(nameof(k), "k deve ser maior que zero.");
    }
}
