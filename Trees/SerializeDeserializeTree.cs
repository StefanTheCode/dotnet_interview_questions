using System.Globalization;

namespace Trees;

/// <summary>
/// Q15: SerializeDeserializeTree
/// Problema: serializar uma árvore binária para texto e reconstruí-la posteriormente.
///
/// O marcador "#" representa nós nulos e é necessário para preservar a estrutura.
/// Payloads vazios, incompletos ou com tokens excedentes são rejeitados.
/// </summary>
public class SerializeDeserializeTree
{
    // Pré-ordem. Tempo: O(n). Espaço: O(n), incluindo a saída.
    public string SerializePreorder(TreeNode? root)
    {
        List<string> tokens = [];
        SerializePreorder(root, tokens);
        return string.Join(',', tokens);
    }

    private static void SerializePreorder(TreeNode? node, List<string> tokens)
    {
        if (node is null)
        {
            tokens.Add("#");
            return;
        }

        tokens.Add(node.Value.ToString(CultureInfo.InvariantCulture));
        SerializePreorder(node.Left, tokens);
        SerializePreorder(node.Right, tokens);
    }

    // Tempo: O(n). Espaço auxiliar: O(h), além dos tokens da entrada.
    public TreeNode? DeserializePreorder(string data)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(data);

        string[] tokens = data.Split(',', StringSplitOptions.TrimEntries);
        int index = 0;
        TreeNode? root = DeserializePreorder(tokens, ref index);

        if (index != tokens.Length)
            throw new FormatException("O payload contém tokens excedentes.");

        return root;
    }

    private static TreeNode? DeserializePreorder(string[] tokens, ref int index)
    {
        if (index >= tokens.Length)
            throw new FormatException("O payload terminou antes de completar a árvore.");

        string token = tokens[index++];

        if (token == "#")
            return null;

        TreeNode node = new(ParseValue(token));
        node.Left = DeserializePreorder(tokens, ref index);
        node.Right = DeserializePreorder(tokens, ref index);
        return node;
    }

    // BFS. Tempo: O(n). Espaço: O(n), incluindo fila e saída.
    public string SerializeBfs(TreeNode? root)
    {
        if (root is null)
            return "#";

        List<string> tokens = [];
        Queue<TreeNode?> queue = new();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode? current = queue.Dequeue();

            if (current is null)
            {
                tokens.Add("#");
                continue;
            }

            tokens.Add(current.Value.ToString(CultureInfo.InvariantCulture));
            queue.Enqueue(current.Left);
            queue.Enqueue(current.Right);
        }

        return string.Join(',', tokens);
    }

    // Tempo: O(n). Espaço auxiliar: O(w), além dos tokens da entrada.
    public TreeNode? DeserializeBfs(string data)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(data);

        string[] tokens = data.Split(',', StringSplitOptions.TrimEntries);

        if (tokens[0] == "#")
        {
            if (tokens.Length != 1)
                throw new FormatException("Uma árvore nula não pode conter tokens adicionais.");

            return null;
        }

        TreeNode root = new(ParseValue(tokens[0]));
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        int index = 1;

        while (queue.Count > 0)
        {
            if (index + 1 >= tokens.Length)
                throw new FormatException("O payload terminou antes de completar a árvore.");

            TreeNode parent = queue.Dequeue();

            parent.Left = ParseOptionalNode(tokens[index++]);
            if (parent.Left is not null)
                queue.Enqueue(parent.Left);

            parent.Right = ParseOptionalNode(tokens[index++]);
            if (parent.Right is not null)
                queue.Enqueue(parent.Right);
        }

        if (index != tokens.Length)
            throw new FormatException("O payload contém tokens excedentes.");

        return root;
    }

    private static TreeNode? ParseOptionalNode(string token)
    {
        return token == "#" ? null : new TreeNode(ParseValue(token));
    }

    private static int ParseValue(string token)
    {
        if (!int.TryParse(
                token,
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out int value))
        {
            throw new FormatException($"O token '{token}' não representa um inteiro válido.");
        }

        return value;
    }
}
