namespace Trees;

/// <summary>
/// Q15: SerializeDeserializeTree
/// Task: Serialize a binary tree to a string and deserialize it back to a tree
/// using multiple approaches:
/// 1. Preorder with null markers using recursion (O(n))
/// 2. BFS level order serialization (O(n))
/// </summary>
public class SerializeDeserializeTree
{
    // 1️. Preorder Serialization with Null Markers
    // - Visit root, then left, then right
    // - Use "#" for null nodes as placeholders
    // Time: O(n), Space: O(n)
    public string SerializePreorder(TreeNode? root)
    {
        List<string> parts = new List<string>();
        SerializePreorderHelper(root, parts);
        return string.Join(",", parts);
    }

    private void SerializePreorderHelper(TreeNode? node, List<string> parts)
    {
        if (node == null)
        {
            parts.Add("#");
            return;
        }

        parts.Add(node.Value.ToString());
        SerializePreorderHelper(node.Left, parts);
        SerializePreorderHelper(node.Right, parts);
    }

    public TreeNode? DeserializePreorder(string data)
    {
        if (string.IsNullOrEmpty(data)) return null;

        Queue<string> tokens = new Queue<string>(data.Split(','));
        return DeserializePreorderHelper(tokens);
    }

    private TreeNode? DeserializePreorderHelper(Queue<string> tokens)
    {
        if (tokens.Count == 0) return null;

        string value = tokens.Dequeue();
        if (value == "#") return null;

        TreeNode node = new TreeNode(int.Parse(value));
        node.Left = DeserializePreorderHelper(tokens);
        node.Right = DeserializePreorderHelper(tokens);

        return node;
    }

    // 2️. BFS Level Order Serialization
    // - Serialize level by level, using "#" for null children
    // Time: O(n), Space: O(n)
    public string SerializeBFS(TreeNode? root)
    {
        if (root == null) return "";

        List<string> parts = new List<string>();
        Queue<TreeNode?> queue = new Queue<TreeNode?>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode? current = queue.Dequeue();

            if (current == null)
            {
                parts.Add("#");
                continue;
            }

            parts.Add(current.Value.ToString());
            queue.Enqueue(current.Left);
            queue.Enqueue(current.Right);
        }

        return string.Join(",", parts);
    }

    public TreeNode? DeserializeBFS(string data)
    {
        if (string.IsNullOrEmpty(data)) return null;

        string[] tokens = data.Split(',');
        if (tokens[0] == "#") return null;

        TreeNode root = new TreeNode(int.Parse(tokens[0]));
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int index = 1;

        while (queue.Count > 0 && index < tokens.Length)
        {
            TreeNode parent = queue.Dequeue();

            // Left child
            if (index < tokens.Length && tokens[index] != "#")
            {
                parent.Left = new TreeNode(int.Parse(tokens[index]));
                queue.Enqueue(parent.Left);
            }
            index++;

            // Right child
            if (index < tokens.Length && tokens[index] != "#")
            {
                parent.Right = new TreeNode(int.Parse(tokens[index]));
                queue.Enqueue(parent.Right);
            }
            index++;
        }

        return root;
    }
}
