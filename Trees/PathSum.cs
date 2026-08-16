namespace Trees;

/// <summary>
/// Q16: PathSum
/// Problema: verificar se existe um caminho da raiz até uma folha cuja soma seja
/// igual ao alvo e, opcionalmente, retornar todos os caminhos correspondentes.
/// </summary>
public class PathSum
{
    private readonly TreeNode? _root;

    public PathSum(TreeNode? root)
    {
        _root = root;
    }

    // Tempo: O(n). Espaço auxiliar: O(h).
    public bool HasPathSumRecursive(long targetSum)
    {
        return HasPathSumRecursive(_root, targetSum);
    }

    private static bool HasPathSumRecursive(TreeNode? node, long remaining)
    {
        if (node is null)
            return false;

        remaining -= node.Value;

        if (node.Left is null && node.Right is null)
            return remaining == 0;

        return HasPathSumRecursive(node.Left, remaining)
            || HasPathSumRecursive(node.Right, remaining);
    }

    // Tempo: O(n). Espaço auxiliar: O(h).
    public bool HasPathSumIterative(long targetSum)
    {
        if (_root is null)
            return false;

        Stack<(TreeNode Node, long Remaining)> stack = new();
        stack.Push((_root, targetSum - _root.Value));

        while (stack.Count > 0)
        {
            (TreeNode current, long remaining) = stack.Pop();

            if (current.Left is null && current.Right is null && remaining == 0)
                return true;

            if (current.Right is not null)
                stack.Push((current.Right, remaining - current.Right.Value));

            if (current.Left is not null)
                stack.Push((current.Left, remaining - current.Left.Value));
        }

        return false;
    }

    // Tempo: O(n + p * h), onde p é a quantidade de caminhos retornados.
    // Espaço: O(h + p * h), incluindo o resultado.
    public List<List<int>> FindAllPaths(long targetSum)
    {
        List<List<int>> result = [];
        FindAllPaths(_root, targetSum, [], result);
        return result;
    }

    private static void FindAllPaths(
        TreeNode? node,
        long remaining,
        List<int> currentPath,
        List<List<int>> result)
    {
        if (node is null)
            return;

        currentPath.Add(node.Value);
        remaining -= node.Value;

        if (node.Left is null && node.Right is null)
        {
            if (remaining == 0)
                result.Add([.. currentPath]);
        }
        else
        {
            FindAllPaths(node.Left, remaining, currentPath, result);
            FindAllPaths(node.Right, remaining, currentPath, result);
        }

        currentPath.RemoveAt(currentPath.Count - 1);
    }
}
