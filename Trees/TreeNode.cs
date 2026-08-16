namespace Trees;

/// <summary>
/// Representa um nó de uma árvore binária.
///
/// O modelo é intencionalmente mínimo para facilitar o uso em exercícios de entrevista.
/// Os algoritmos do módulo pressupõem uma árvore válida e acíclica.
/// </summary>
public class TreeNode
{
    public int Value { get; set; }
    public TreeNode? Left { get; set; }
    public TreeNode? Right { get; set; }

    public TreeNode(int value)
    {
        Value = value;
    }

    public TreeNode(int value, TreeNode? left, TreeNode? right)
    {
        Value = value;
        Left = left;
        Right = right;
    }
}
