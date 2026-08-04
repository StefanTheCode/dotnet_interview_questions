using Arrays;

Console.WriteLine("Perguntas de entrevista sobre arrays em .NET");
Console.WriteLine(new string('-', 50));

int[] majorityValues = { 2, 2, 1, 1, 1, 2, 2 };
int? majority = new MajorityElementFinder(majorityValues).FindMajorityBoyerMoore();
Console.WriteLine($"Elemento majoritário: {majority?.ToString() ?? "não encontrado"}");

int[] pairValues = { 1, 2, 3, 4, 5, 6 };
List<(int First, int Second)> pairs =
    new FindPairsWithSum(pairValues).FindPairsWithHashSet(target: 7);
Console.WriteLine($"Pares cuja soma é 7: {string.Join(", ", pairs)}");

int[] sortedValues = { 1, 3, 5, 7, 9 };
int index = new BinarySearchArray(sortedValues).BinarySearchIterative(target: 7);
Console.WriteLine($"Índice do valor 7: {index}");

int[] sumValues = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
long maxSum = new MaxSubarraySum(sumValues).FindMaxSumKadane();
Console.WriteLine($"Maior soma de subarray: {maxSum}");

int[] shuffleValues = { 1, 2, 3, 4, 5 };
int[] shuffled = new ShuffleArray(shuffleValues, new Random(42)).ShuffleFisherYates();
Console.WriteLine($"Exemplo de Fisher–Yates: {string.Join(", ", shuffled)}");

Console.WriteLine();
Console.WriteLine("Consulte Arrays/README.md para acessar as 20 questões do módulo.");
