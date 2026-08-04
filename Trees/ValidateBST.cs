namespace Trees;

/// <summary>
/// Q8: ValidateBST
/// Problema: determinar se uma árvore binária é uma Binary Search Tree válida:
/// 1. Travessia em ordem armazenada em lista;
/// 2. Validação recursiva com limites mínimo e máximo;
/// 3. Travessia em ordem iterativa com comparação do valor anterior.
///
/// Esta implementação considera valores duplicados inválidos em uma BST.
/// </summary>
public class ValidateBST
{
    private readonly TreeNode? _root;

    public ValidateBST(TreeNode? root)
    {
        _root = root;
    }

    // Uma BST válida produz uma sequência estritamente crescente em ordem.
    // Tempo: O(n). Espaço auxiliar: O(n).
    public bool IsValidWithInorderList()
    {
        List<int> values = [];
        CollectInorder(_root, values);

        for (int i = 1; i < values.Count; i++)
        {
            if (values[i] <= values[i - 1])
                return false;
        }

        return true;
    }

    private static void CollectInorder(TreeNode? node, List<int> values)
    {
        if (node is null)
            return;

        CollectInorder(node.Left, values);
        values.Add(node.Value);
        CollectInorder(node.Right, values);
    }

    // Cada nó precisa permanecer dentro do intervalo imposto por seus ancestrais.
    // long evita colisões com int.MinValue e int.MaxValue nos limites iniciais.
    // Tempo: O(n). Espaço auxiliar: O(h).
    public bool IsValidRecursive()
    {
        return IsValid(_root, long.MinValue, long.MaxValue);
    }

    private static bool IsValid(TreeNode? node, long minimum, long maximum)
    {
        if (node is null)
            return true;

        if (node.Value <= minimum || node.Value >= maximum)
            return false;

        return IsValid(node.Left, minimum, node.Value)
            && IsValid(node.Right, node.Value, maximum);
    }

    // Compara cada valor visitado com o anterior sem materializar toda a sequência.
    // Tempo: O(n). Espaço auxiliar: O(h).
    public bool IsValidIterative()
    {
        Stack<TreeNode> stack = new();
        TreeNode? current = _root;
        long previous = long.MinValue;

        while (current is not null || stack.Count > 0)
        {
            while (current is not null)
            {
                stack.Push(current);
                current = current.Left;
            }

            current = stack.Pop();

            if (current.Value <= previous)
                return false;

            previous = current.Value;
            current = current.Right;
        }

        return true;
    }
}
