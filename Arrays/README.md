# Perguntas de entrevista sobre arrays em .NET

Este módulo reúne **20 questões sobre arrays** voltadas à preparação para entrevistas técnicas com C#.

Cada questão procura apresentar:

- explicação do problema;
- mais de uma estratégia de solução quando aplicável;
- evolução de uma abordagem simples para outra mais eficiente;
- análise de complexidade de tempo e espaço;
- tratamento dos casos extremos mais relevantes;
- código C# comentado em português do Brasil.

## Progresso

As **20 questões** foram incorporadas, traduzidas e revisadas tecnicamente.

| # | Questão | Arquivo | Situação |
|---:|---|---|---|
| 1 | Diferenças entre `Array`, `ArrayList` e `List<T>` | `Array_ArrayList_List.cs` | Concluída |
| 2 | Inverter um array | `ReverseArray.cs` | Concluída |
| 3 | Maior produto de um subarray contíguo | `MaxProductSubarray.cs` | Concluída |
| 4 | Remover elementos duplicados | `RemoveDuplicates.cs` | Concluída |
| 5 | Encontrar o número ausente de 1 até N | `FindMissingNumber.cs` | Concluída |
| 6 | Encontrar a interseção entre dois arrays | `FindIntersection.cs` | Concluída |
| 7 | Encontrar o primeiro elemento não repetido | `FirstNonRepeatingElement.cs` | Concluída |
| 8 | Rotacionar um array em K posições | `RotateArray.cs` | Concluída |
| 9 | Verificar se um array é palíndromo | `CheckPalindromeArray.cs` | Concluída |
| 10 | Transformar um array jagged em um array linear | `Flatten2DArray.cs` | Concluída |
| 11 | Encontrar o elemento majoritário | `MajorityElementFinder.cs` | Concluída |
| 12 | Encontrar pares com uma soma específica | `FindPairsWithSum.cs` | Concluída |
| 13 | Implementar busca binária | `BinarySearchArray.cs` | Concluída |
| 14 | Encontrar a maior soma de subarray | `MaxSubarraySum.cs` | Concluída |
| 15 | Contar a frequência dos elementos | `ElementFrequencyCounter.cs` | Concluída |
| 16 | Comparar arrays jagged e multidimensionais | `JaggedVsMultidimensionalArray.cs` | Concluída |
| 17 | Embaralhar um array com Fisher–Yates | `ShuffleArray.cs` | Concluída |
| 18 | Redimensionar um array | `ResizeArray.cs` | Concluída |
| 19 | Ordenar objetos personalizados | `SortCustomObjects.cs` | Concluída |
| 20 | Complexidade das operações com arrays | `ArrayOperationsComplexity.md` | Concluída |

## Como estudar as implementações

Para cada problema:

1. comece pela abordagem mais simples e explique seu funcionamento;
2. identifique os gargalos de tempo e memória;
3. avance para a próxima solução e compare as complexidades;
4. teste entradas vazias, um único elemento, valores negativos e duplicidades quando forem aplicáveis;
5. explique quando uma solução modifica o array original;
6. descreva as premissas do algoritmo, como a exigência de ordenação para busca binária.

## Ajustes técnicos aplicados nesta tradução

Durante a revisão das questões, foram realizados ajustes em relação ao código original:

- numeração alinhada ao índice do README principal;
- validação de argumentos nulos, arrays vazios e tamanhos inválidos;
- ordenação realizada sobre cópias para evitar mutações inesperadas;
- rotação corrigida para arrays vazios e valores negativos de `k`;
- cálculos intermediários promovidos para `long` quando a soma poderia exceder `int`;
- resultados baseados em `HashSet` ordenados para manter saída determinística;
- pares duplicados eliminados também na abordagem de força bruta;
- busca binária protegida por validação da ordenação crescente;
- versão LINQ da maior soma reescrita com prefixos de soma e complexidade corrigida;
- descrição da abordagem ingênua de embaralhamento corrigida para custo esperado O(n log n);
- `Random` injetável para permitir exemplos e testes reproduzíveis;
- nulabilidade corrigida na implementação de objetos personalizados;
- distinção explícita entre array jagged e array multidimensional;
- questão conceitual de complexidade adicionada como documento próprio.

## Execução

A partir da raiz do repositório:

```bash
dotnet build Arrays/Arrays.csproj
dotnet run --project Arrays/Arrays.csproj
```

O `Program.cs` contém exemplos representativos de elemento majoritário, pares com soma, busca binária, algoritmo de Kadane e Fisher–Yates.
