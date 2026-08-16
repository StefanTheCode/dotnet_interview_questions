namespace Trees;

/// <summary>
/// Q17: RootToLeafPaths
/// Problema: encontrar todos os caminhos da raiz até as folhas de uma árvore binária.
/// </summary>
public class RootToLeafPaths
{
    private readonly TreeNode? _root;

    public RootToLeafPaths(TreeNode? root)
    {
        _root = root;
    }

    // Tempo: O(n + s), onde s é o total de valores copiados para o resultado.
    // Espaço: O(h + s), incluindo o resultado.
    public List<List<int>> FindAllPathsRecursive()
    {
        List<List<int>> result = [];
        FindPaths(_root, [], result);
        return result;
    }

    private static void FindPaths(
        TreeNode? node,
        List<int> currentPath,
        List<List<int>> result)
    {
        if (node is null)
            return;

        currentPath.Add(node.Value);

        if (node.Left is null && node.Right is null)
        {
            result.Add([.. currentPath]);
        }
        else
        {
            FindPaths(node.Left, currentPath, result);
            FindPaths(node.Right, currentPath, result);
        }

        currentPath.RemoveAt(currentPath.Count - 1);
    }

    // As cópias de caminho tornam o pior caso O(n * h) em tempo e espaço.
    public List<List<int>> FindAllPathsIterative()
    {
        List<List<int>> result = [];

        if (_root is null)
            return result;

        Stack<(TreeNode Node, List<int> Path)> stack = new();
        stack.Push((_root, [_root.Value]));

        while (stack.Count > 0)
        {
            (TreeNode current, List<int> path) = stack.Pop();

            if (current.Left is null && current.Right is null)
            {
                result.Add(path);
                continue;
            }

            if (current.Right is not null)
                stack.Push((current.Right, [.. path, current.Right.Value]));

            if (current.Left is not null)
                stack.Push((current.Left, [.. path, current.Left.Value]));
        }

        return result;
    }

    // Tempo e espaço são proporcionais ao tamanho total das strings produzidas.
    public List<string> FindAllPathsAsStrings()
    {
        List<string> result = [];
        FindPathStrings(_root, [], result);
        return result;
    }

    private static void FindPathStrings(
        TreeNode? node,
        List<int> currentPath,
        List<string> result)
    {
        if (node is null)
            return;

        currentPath.Add(node.Value);

        if (node.Left is null && node.Right is null)
        {
            result.Add(string.Join("->", currentPath));
        }
        else
        {
            FindPathStrings(node.Left, currentPath, result);
            FindPathStrings(node.Right, currentPath, result);
        }

        currentPath.RemoveAt(currentPath.Count - 1);
    }
}
