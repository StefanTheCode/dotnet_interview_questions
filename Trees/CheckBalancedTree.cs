namespace Trees;

/// <summary>
/// Q5: CheckBalancedTree
/// Problema: determinar se, em todos os nós, a diferença entre as alturas das subárvores
/// esquerda e direita é de no máximo 1:
/// 1. Força bruta com recálculo de alturas;
/// 2. Percurso bottom-up com encerramento antecipado.
/// </summary>
public class CheckBalancedTree
{
    private readonly TreeNode? _root;

    public CheckBalancedTree(TreeNode? root)
    {
        _root = root;
    }

    // Recalcula alturas para vários nós.
    // Tempo: O(n²) no pior caso. Espaço auxiliar: O(h).
    public bool IsBalancedBruteForce()
    {
        return IsBalancedBruteForce(_root);
    }

    private static bool IsBalancedBruteForce(TreeNode? node)
    {
        if (node is null)
            return true;

        int leftHeight = GetHeight(node.Left);
        int rightHeight = GetHeight(node.Right);

        return Math.Abs(leftHeight - rightHeight) <= 1
            && IsBalancedBruteForce(node.Left)
            && IsBalancedBruteForce(node.Right);
    }

    private static int GetHeight(TreeNode? node)
    {
        if (node is null)
            return 0;

        return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
    }

    // Calcula altura e balanceamento em uma única passagem.
    // O sentinela -1 informa imediatamente que uma subárvore está desbalanceada.
    // Tempo: O(n). Espaço auxiliar: O(h).
    public bool IsBalancedOptimal()
    {
        return CheckHeight(_root) >= 0;
    }

    private static int CheckHeight(TreeNode? node)
    {
        if (node is null)
            return 0;

        int leftHeight = CheckHeight(node.Left);
        if (leftHeight < 0)
            return -1;

        int rightHeight = CheckHeight(node.Right);
        if (rightHeight < 0)
            return -1;

        if (Math.Abs(leftHeight - rightHeight) > 1)
            return -1;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
