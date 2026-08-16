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

FindMinMaxBST minMax = new(root);
Console.WriteLine($"Mínimo e máximo da BST: {minMax.FindMinIterative()} e {minMax.FindMaxIterative()}");

LowestCommonAncestor lowestCommonAncestor = new(root);
Console.WriteLine($"LCA de 1 e 3: {lowestCommonAncestor.FindLcaInBstIterative(1, 3)?.Value}");

DiameterOfBinaryTree diameter = new(root);
Console.WriteLine($"Diâmetro em arestas: {diameter.FindDiameterOptimal()}");

TreeNode symmetricRoot = new(
    1,
    new TreeNode(2, new TreeNode(3), new TreeNode(4)),
    new TreeNode(2, new TreeNode(4), new TreeNode(3)));
Console.WriteLine($"Árvore simétrica: {new CheckSymmetricTree(symmetricRoot).IsSymmetricIterative()}");

SerializeDeserializeTree serializer = new();
string serialized = serializer.SerializePreorder(root);
TreeNode? restored = serializer.DeserializePreorder(serialized);
Console.WriteLine($"Serialização em pré-ordem: {serialized}");
Console.WriteLine($"Árvore restaurada válida: {new ValidateBST(restored).IsValidRecursive()}");

PathSum pathSum = new(root);
Console.WriteLine($"Existe caminho com soma 7: {pathSum.HasPathSumRecursive(7)}");

RootToLeafPaths rootToLeafPaths = new(root);
Console.WriteLine($"Caminhos: {string.Join(" | ", rootToLeafPaths.FindAllPathsAsStrings())}");

CountNodes countNodes = new(root);
Console.WriteLine($"Nós totais: {countNodes.CountAllBfs()}; folhas: {countNodes.CountLeaves()}");

KthSmallestInBST kthSmallest = new(root);
Console.WriteLine($"4º menor valor: {kthSmallest.FindKthSmallestIterative(4)}");

BuildTreeFromRelationships hierarchy = new();
hierarchy.BuildTree(
    new List<BuildTreeFromRelationships.Relationship>
    {
        new(1, null, "Diretoria"),
        new(2, 1, "Engenharia"),
        new(3, 1, "Produto"),
        new(4, 2, "Backend"),
        new(5, 2, "Frontend")
    });

Console.WriteLine("Hierarquia:");
foreach (string line in hierarchy.PrintHierarchy())
    Console.WriteLine(line);

Console.WriteLine($"Altura da hierarquia: {hierarchy.ComputeHeight()}");
Console.WriteLine($"Gestor comum de Backend e Frontend: {hierarchy.FindLowestCommonManager(4, 5)?.Name}");
