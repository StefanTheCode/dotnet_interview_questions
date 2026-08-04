namespace Trees;

/// <summary>
/// Q2: BreadthFirstTraversal
/// Problema: percorrer uma árvore binária nível por nível:
/// 1. BFS simples, retornando uma lista linear;
/// 2. BFS agrupada por nível;
/// 3. BFS em zigue-zague, alternando a direção de cada nível.
/// </summary>
public class BreadthFirstTraversal
{
    private readonly TreeNode? _root;

    public BreadthFirstTraversal(TreeNode? root)
    {
        _root = root;
    }

    // Percorre os nós em ordem de nível usando uma fila FIFO.
    // Tempo: O(n). Espaço auxiliar: O(w), onde w é a largura máxima da árvore.
    public List<int> LevelOrderFlat()
    {
        List<int> result = [];
        if (_root is null)
            return result;

        Queue<TreeNode> queue = new();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();
            result.Add(current.Value);

            if (current.Left is not null)
                queue.Enqueue(current.Left);

            if (current.Right is not null)
                queue.Enqueue(current.Right);
        }

        return result;
    }

    // Separa os valores em uma lista para cada nível.
    // Tempo: O(n). Espaço auxiliar: O(w), além do resultado retornado.
    public List<List<int>> LevelOrderGrouped()
    {
        List<List<int>> result = [];
        if (_root is null)
            return result;

        Queue<TreeNode> queue = new();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            List<int> currentLevel = new(levelSize);

            for (int i = 0; i < levelSize; i++)
            {
                TreeNode current = queue.Dequeue();
                currentLevel.Add(current.Value);

                if (current.Left is not null)
                    queue.Enqueue(current.Left);

                if (current.Right is not null)
                    queue.Enqueue(current.Right);
            }

            result.Add(currentLevel);
        }

        return result;
    }

    // Alterna a posição de gravação dos valores sem alterar a ordem de enfileiramento dos nós.
    // Tempo: O(n). Espaço auxiliar: O(w), além do resultado retornado.
    public List<List<int>> ZigzagLevelOrder()
    {
        List<List<int>> result = [];
        if (_root is null)
            return result;

        Queue<TreeNode> queue = new();
        queue.Enqueue(_root);
        bool leftToRight = true;

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            int[] levelValues = new int[levelSize];

            for (int i = 0; i < levelSize; i++)
            {
                TreeNode current = queue.Dequeue();
                int targetIndex = leftToRight ? i : levelSize - 1 - i;
                levelValues[targetIndex] = current.Value;

                if (current.Left is not null)
                    queue.Enqueue(current.Left);

                if (current.Right is not null)
                    queue.Enqueue(current.Right);
            }

            result.Add([.. levelValues]);
            leftToRight = !leftToRight;
        }

        return result;
    }
}
