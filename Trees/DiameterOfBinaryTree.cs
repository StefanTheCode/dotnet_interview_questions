namespace Trees;

/// <summary>
/// Q13: DiameterOfBinaryTree
/// Task: Find the diameter of a binary tree (longest path between any two nodes,
/// measured in number of edges) using multiple approaches:
/// 1. Brute force: compute height at each node and track max (O(n²))
/// 2. Optimal: single DFS pass computing height and diameter simultaneously (O(n))
/// </summary>
public class DiameterOfBinaryTree
{
    private TreeNode? _root;

    public DiameterOfBinaryTree(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Brute Force O(n²)
    // - For each node, compute left height + right height
    // - The diameter through that node is leftHeight + rightHeight
    // - Track the global maximum across all nodes
    public int FindDiameterBruteForce()
    {
        int maxDiameter = 0;
        FindDiameterBruteForceHelper(_root, ref maxDiameter);
        return maxDiameter;
    }

    private void FindDiameterBruteForceHelper(TreeNode? node, ref int maxDiameter)
    {
        if (node == null) return;

        int leftHeight = GetHeight(node.Left);
        int rightHeight = GetHeight(node.Right);
        maxDiameter = Math.Max(maxDiameter, leftHeight + rightHeight);

        FindDiameterBruteForceHelper(node.Left, ref maxDiameter);
        FindDiameterBruteForceHelper(node.Right, ref maxDiameter);
    }

    private int GetHeight(TreeNode? node)
    {
        if (node == null) return 0;
        return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
    }

    // 2️. Optimal: Single DFS Pass O(n)
    // - Compute height bottom-up and track diameter at the same time
    // - At each node: diameter through node = leftHeight + rightHeight
    // - Return height to parent, update global max along the way
    // Time: O(n), Space: O(h)
    public int FindDiameterOptimal()
    {
        int maxDiameter = 0;
        HeightAndDiameter(_root, ref maxDiameter);
        return maxDiameter;
    }

    private int HeightAndDiameter(TreeNode? node, ref int maxDiameter)
    {
        if (node == null) return 0;

        int leftHeight = HeightAndDiameter(node.Left, ref maxDiameter);
        int rightHeight = HeightAndDiameter(node.Right, ref maxDiameter);

        // Update diameter at this node
        maxDiameter = Math.Max(maxDiameter, leftHeight + rightHeight);

        // Return height to parent
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
