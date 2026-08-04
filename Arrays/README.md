# Perguntas de entrevista sobre arrays em .NET

Este módulo reúne **20 exercícios sobre arrays** voltados à preparação para entrevistas técnicas com C#.

Cada questão procura apresentar:

- explicação do problema;
- mais de uma estratégia de solução;
- evolução de uma abordagem simples para outra mais eficiente;
- análise de complexidade de tempo e espaço;
- tratamento dos casos extremos mais relevantes;
- código C# comentado em português do Brasil.

## Progresso

As questões **1 a 10** já foram incorporadas, traduzidas e revisadas. As questões 11 a 20 serão adicionadas na próxima etapa.

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
| 11 | Encontrar o elemento majoritário | `MajorityElementFinder.cs` | Pendente |
| 12 | Encontrar pares com uma soma específica | `FindPairsWithSum.cs` | Pendente |
| 13 | Implementar busca binária | `BinarySearchArray.cs` | Pendente |
| 14 | Encontrar a maior soma de subarray | `MaxSubarraySum.cs` | Pendente |
| 15 | Contar a frequência dos elementos | `ElementFrequencyCounter.cs` | Pendente |
| 16 | Comparar arrays jagged e multidimensionais | `JaggedVsMultidimensionalArray.cs` | Pendente |
| 17 | Embaralhar um array com Fisher–Yates | `ShuffleArray.cs` | Pendente |
| 18 | Redimensionar um array | `ResizeArray.cs` | Pendente |
| 19 | Ordenar objetos personalizados | `SortCustomObjects.cs` | Pendente |
| 20 | Complexidade das operações com arrays | Conteúdo conceitual | Pendente |

## Como estudar as implementações

Para cada problema:

1. comece pela abordagem mais simples e explique seu funcionamento;
2. identifique os gargalos de tempo e memória;
3. avance para a próxima solução e compare as complexidades;
4. teste entradas vazias, um único elemento, valores negativos e duplicidades quando forem aplicáveis;
5. explique quando uma solução modifica o array original.

## Ajustes técnicos aplicados nesta tradução

Durante a revisão das primeiras dez questões, foram feitos alguns ajustes em relação ao código original:

- validação de argumentos nulos;
- tratamento de arrays vazios nas operações que antes causavam divisão por zero ou acesso inválido;
- cópia dos arrays antes da ordenação, evitando mutação inesperada das entradas;
- suporte a valores negativos de `k` na rotação;
- uso de `long` nos cálculos intermediários da fórmula da soma;
- preservação de uma ordem determinística na interseção baseada em `HashSet`;
- correção da numeração das questões para acompanhar o índice do README principal;
- distinção explícita entre array jagged e array multidimensional.

## Execução

A partir da raiz do repositório:

```bash
dotnet build Arrays/Arrays.csproj
dotnet run --project Arrays/Arrays.csproj
```

O `Program.cs` ainda possui apenas um ponto de entrada mínimo. Exemplos executáveis serão acrescentados depois que o conjunto das 20 questões estiver completo.
