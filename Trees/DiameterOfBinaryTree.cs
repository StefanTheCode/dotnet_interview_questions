namespace Trees;

/// <summary>
/// Q13: DiameterOfBinaryTree
/// Problema: encontrar o diâmetro de uma árvore binária, medido pela quantidade
/// de arestas do maior caminho entre quaisquer dois nós.
/// </summary>
public class DiameterOfBinaryTree
{
    private readonly TreeNode? _root;

    public DiameterOfBinaryTree(TreeNode? root)
    {
        _root = root;
    }

    // Pior caso: tempo O(n²). Espaço auxiliar: O(h).
    public int FindDiameterBruteForce()
    {
        int maxDiameter = 0;
        FindDiameterBruteForce(_root, ref maxDiameter);
        return maxDiameter;
    }

    private static void FindDiameterBruteForce(TreeNode? node, ref int maxDiameter)
    {
        if (node is null)
            return;

        int leftHeight = GetHeight(node.Left);
        int rightHeight = GetHeight(node.Right);
        maxDiameter = Math.Max(maxDiameter, leftHeight + rightHeight);

        FindDiameterBruteForce(node.Left, ref maxDiameter);
        FindDiameterBruteForce(node.Right, ref maxDiameter);
    }

    private static int GetHeight(TreeNode? node)
    {
        return node is null
            ? 0
            : 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
    }

    // Tempo: O(n). Espaço auxiliar: O(h).
    public int FindDiameterOptimal()
    {
        int maxDiameter = 0;
        ComputeHeightAndDiameter(_root, ref maxDiameter);
        return maxDiameter;
    }

    private static int ComputeHeightAndDiameter(TreeNode? node, ref int maxDiameter)
    {
        if (node is null)
            return 0;

        int leftHeight = ComputeHeightAndDiameter(node.Left, ref maxDiameter);
        int rightHeight = ComputeHeightAndDiameter(node.Right, ref maxDiameter);

        maxDiameter = Math.Max(maxDiameter, leftHeight + rightHeight);

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
