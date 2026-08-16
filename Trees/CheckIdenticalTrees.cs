using System.Text;

namespace Trees;

/// <summary>
/// Q6: CheckIdenticalTrees
/// Problema: determinar se duas árvores binárias possuem a mesma estrutura e os mesmos valores:
/// 1. Comparação recursiva;
/// 2. Comparação iterativa em largura;
/// 3. Comparação das serializações estruturais.
/// </summary>
public class CheckIdenticalTrees
{
    private readonly TreeNode? _root1;
    private readonly TreeNode? _root2;

    public CheckIdenticalTrees(TreeNode? root1, TreeNode? root2)
    {
        _root1 = root1;
        _root2 = root2;
    }

    // Tempo: O(n). Espaço auxiliar: O(h).
    public bool AreIdenticalRecursive()
    {
        return AreIdentical(_root1, _root2);
    }

    private static bool AreIdentical(TreeNode? node1, TreeNode? node2)
    {
        if (node1 is null && node2 is null)
            return true;

        if (node1 is null || node2 is null)
            return false;

        return node1.Value == node2.Value
            && AreIdentical(node1.Left, node2.Left)
            && AreIdentical(node1.Right, node2.Right);
    }

    // Percorre as duas árvores em paralelo e também compara posições nulas.
    // Tempo: O(n). Espaço auxiliar: O(w).
    public bool AreIdenticalIterative()
    {
        Queue<(TreeNode? First, TreeNode? Second)> queue = new();
        queue.Enqueue((_root1, _root2));

        while (queue.Count > 0)
        {
            (TreeNode? node1, TreeNode? node2) = queue.Dequeue();

            if (node1 is null && node2 is null)
                continue;

            if (node1 is null || node2 is null || node1.Value != node2.Value)
                return false;

            queue.Enqueue((node1.Left, node2.Left));
            queue.Enqueue((node1.Right, node2.Right));
        }

        return true;
    }

    // Marcadores de nós nulos preservam a estrutura, e StringBuilder evita concatenações quadráticas.
    // Tempo: O(n). Espaço auxiliar: O(n).
    public bool AreIdenticalSerialized()
    {
        return Serialize(_root1) == Serialize(_root2);
    }

    private static string Serialize(TreeNode? root)
    {
        StringBuilder builder = new();
        Serialize(root, builder);
        return builder.ToString();
    }

    private static void Serialize(TreeNode? node, StringBuilder builder)
    {
        if (node is null)
        {
            builder.Append("#,");
            return;
        }

        builder.Append(node.Value).Append(',');
        Serialize(node.Left, builder);
        Serialize(node.Right, builder);
    }
}
