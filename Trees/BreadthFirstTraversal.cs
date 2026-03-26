namespace Trees;

/// <summary>
/// Q2: BreadthFirstTraversal
/// Task: Traverse a binary tree level by level (breadth-first / level order) using multiple approaches:
/// 1. Simple BFS with Queue returning a flat list (O(n))
/// 2. Level-by-level BFS returning a list of lists (O(n))
/// 3. Zigzag level order traversal (O(n))
/// </summary>
public class BreadthFirstTraversal
{
    private TreeNode? _root;

    public BreadthFirstTraversal(TreeNode? root)
    {
        _root = root;
    }

    // 1️. Simple BFS: Flat list of all values level by level
    // - Use a Queue to process nodes in FIFO order
    // Time: O(n), Space: O(n)
    public List<int> LevelOrderFlat()
    {
        List<int> result = new List<int>();
        if (_root == null) return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();
            result.Add(current.Value);

            if (current.Left != null) queue.Enqueue(current.Left);
            if (current.Right != null) queue.Enqueue(current.Right);
        }

        return result;
    }

    // 2️. Level-by-Level BFS: Returns list of lists (one per level)
    // - Process all nodes at current level before moving to next
    // Time: O(n), Space: O(n)
    public List<List<int>> LevelOrderGrouped()
    {
        List<List<int>> result = new List<List<int>>();
        if (_root == null) return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            List<int> currentLevel = new List<int>();

            for (int i = 0; i < levelSize; i++)
            {
                TreeNode current = queue.Dequeue();
                currentLevel.Add(current.Value);

                if (current.Left != null) queue.Enqueue(current.Left);
                if (current.Right != null) queue.Enqueue(current.Right);
            }

            result.Add(currentLevel);
        }

        return result;
    }

    // 3️. Zigzag Level Order Traversal
    // - Alternate between left-to-right and right-to-left at each level
    // - Common interview variant of level order traversal
    // Time: O(n), Space: O(n)
    public List<List<int>> ZigzagLevelOrder()
    {
        List<List<int>> result = new List<List<int>>();
        if (_root == null) return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(_root);
        bool leftToRight = true;

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            List<int> currentLevel = new List<int>(new int[levelSize]);

            for (int i = 0; i < levelSize; i++)
            {
                TreeNode current = queue.Dequeue();

                // Place element at correct position based on direction
                int index = leftToRight ? i : levelSize - 1 - i;
                currentLevel[index] = current.Value;

                if (current.Left != null) queue.Enqueue(current.Left);
                if (current.Right != null) queue.Enqueue(current.Right);
            }

            result.Add(currentLevel);
            leftToRight = !leftToRight;
        }

        return result;
    }
}
