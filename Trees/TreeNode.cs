namespace Trees;

/// <summary>
/// Shared tree node models used across all tree interview questions.
/// These are minimal and interview-friendly — no unnecessary abstractions.
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
