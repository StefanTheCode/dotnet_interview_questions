using Trees;

TreeNode root = new(
    4,
    new TreeNode(2, new TreeNode(1), new TreeNode(3)),
    new TreeNode(7, new TreeNode(6), new TreeNode(9)));

Console.WriteLine("Questões de entrevista sobre árvores:");

DepthFirstTraversal depthFirst = new(root);
Console.WriteLine($"Pré-ordem: {string.Join(", ", depthFirst.PreorderRecursive())}");
Console.WriteLine($"Em ordem: {string.Join(", ", depthFirst.InorderIterative())}");
Console.WriteLine($"Pós-ordem: {string.Join(", ", depthFirst.PostorderRecursive())}");

BreadthFirstTraversal breadthFirst = new(root);
Console.WriteLine($"BFS: {string.Join(", ", breadthFirst.LevelOrderFlat())}");
Console.WriteLine("BFS agrupada: " + string.Join(" | ", breadthFirst.LevelOrderGrouped().Select(level => string.Join(", ", level))));
Console.WriteLine("Zigue-zague: " + string.Join(" | ", breadthFirst.ZigzagLevelOrder().Select(level => string.Join(", ", level))));

MaximumDepth maximumDepth = new(root);
MinimumDepth minimumDepth = new(root);
Console.WriteLine($"Profundidade máxima: {maximumDepth.FindMaxDepthRecursive()}");
Console.WriteLine($"Profundidade mínima: {minimumDepth.FindMinDepthBFS()}");

CheckBalancedTree balancedTree = new(root);
Console.WriteLine($"Está balanceada: {balancedTree.IsBalancedOptimal()}");

TreeNode equivalentRoot = new(
    4,
    new TreeNode(2, new TreeNode(1), new TreeNode(3)),
    new TreeNode(7, new TreeNode(6), new TreeNode(9)));

CheckIdenticalTrees identicalTrees = new(root, equivalentRoot);
Console.WriteLine($"Árvores idênticas: {identicalTrees.AreIdenticalIterative()}");

ValidateBST validateBst = new(root);
SearchBST searchBst = new(root);
Console.WriteLine($"BST válida: {validateBst.IsValidRecursive()}");
Console.WriteLine($"Valor 6 encontrado: {searchBst.SearchIterative(6) is not null}");

InsertIntoBST insertIntoBst = new(root);
insertIntoBst.InsertIterative(5);
Console.WriteLine($"Após inserir 5: {string.Join(", ", new DepthFirstTraversal(insertIntoBst.CurrentRoot).InorderRecursive())}");

TreeNode treeToInvert = new(1, new TreeNode(2), new TreeNode(3));
InvertBinaryTree invertBinaryTree = new(treeToInvert);
invertBinaryTree.InvertBFS();
Console.WriteLine($"Árvore invertida em BFS: {string.Join(", ", new BreadthFirstTraversal(invertBinaryTree.CurrentRoot).LevelOrderFlat())}");
