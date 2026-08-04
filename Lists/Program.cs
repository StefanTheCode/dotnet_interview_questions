using Lists;

List<int> values = [4, 2, 4, 1, 3, 2];

Console.WriteLine("Questões de entrevista sobre List<T>:");
Console.WriteLine($"Lista original: {string.Join(", ", values)}");

RemoveDuplicates removeDuplicates = new(values);
Console.WriteLine($"Sem duplicados: {string.Join(", ", removeDuplicates.RemoveDuplicatesWithHashSet())}");

FindSecondLargest secondLargest = new(values);
Console.WriteLine($"Segundo maior distinto: {secondLargest.FindWithSinglePass()?.ToString() ?? "não existe"}");

ReverseList reverseList = new(values);
reverseList.ReverseInPlace();
Console.WriteLine($"Invertida: {string.Join(", ", reverseList.Current)}");

FindCommonElements commonElements = new(values, [2, 3, 8]);
Console.WriteLine($"Elementos comuns: {string.Join(", ", commonElements.FindCommonHashSet())}");

MergeTwoLists mergeTwoLists = new([1, 5, 7], [2, 3, 8]);
Console.WriteLine($"Mescladas e ordenadas: {string.Join(", ", mergeTwoLists.MergeSorted())}");

RotateList rotateList = new(values);
Console.WriteLine($"Rotação à direita por 2: {string.Join(", ", rotateList.RotateWithExtraList(2))}");

ShuffleList shuffleList = new(values, new Random(42));
Console.WriteLine($"Embaralhamento reproduzível: {string.Join(", ", shuffleList.ShuffleFisherYates())}");
