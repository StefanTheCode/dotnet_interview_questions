# Perguntas de entrevista sobre `List<T>` em .NET

Este módulo reúne **20 exercícios sobre `List<T>`** voltados à preparação para entrevistas técnicas com C#.

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
| 1 | Remover elementos duplicados | `RemoveDuplicates.cs` | Concluída |
| 2 | Encontrar o segundo maior valor distinto | `FindSecondLargest.cs` | Concluída |
| 3 | Inverter uma lista | `ReverseList.cs` | Concluída |
| 4 | Ordenar uma lista | `SortList.cs` | Concluída |
| 5 | Contar a frequência dos elementos | `ElementFrequencyCounter.cs` | Concluída |
| 6 | Encontrar elementos comuns entre duas listas | `FindCommonElements.cs` | Concluída |
| 7 | Combinar duas listas | `MergeTwoLists.cs` | Concluída |
| 8 | Encontrar o número ausente de 1 até N | `FindMissingNumbers.cs` | Concluída |
| 9 | Rotacionar uma lista em K posições | `RotateList.cs` | Concluída |
| 10 | Embaralhar uma lista com Fisher–Yates | `ShuffleList.cs` | Concluída |
| 11 | Verificar se uma lista é palíndromo | `CheckPalindromeList.cs` | Pendente |
| 12 | Encontrar o primeiro elemento não repetido | `FirstNonRepeatingElement.cs` | Pendente |
| 13 | Agrupar elementos duplicados | `GroupDuplicates.cs` | Pendente |
| 14 | Remover todas as ocorrências de um valor | `RemoveAllOccurrences.cs` | Pendente |
| 15 | Encontrar pares com uma soma específica | `FindPairsWithSum.cs` | Pendente |
| 16 | Dividir uma lista em blocos | `SplitListIntoChunks.cs` | Pendente |
| 17 | Achatar listas aninhadas | `FlattenNestedLists.cs` | Pendente |
| 18 | Encontrar a maior soma contígua | `MaxContiguousSum.cs` | Pendente |
| 19 | Mover zeros para o final | `MoveZerosToEnd.cs` | Pendente |
| 20 | Comparar igualdade entre listas | `CompareListEquality.cs` | Pendente |

## Como estudar as implementações

Para cada problema:

1. comece pela solução mais simples e explique o raciocínio;
2. identifique o custo de buscas, inserções e remoções em `List<T>`;
3. compare soluções que preservam a ordem com soluções baseadas em ordenação;
4. avalie entradas vazias, valores duplicados, números negativos e limites de `int`;
5. identifique se a operação modifica a coleção original ou trabalha sobre uma cópia.

## Ajustes técnicos aplicados nesta tradução

Durante a revisão das primeiras dez questões, foram feitos os seguintes ajustes em relação ao código original:

- validação de argumentos nulos em todos os construtores;
- cópia defensiva das listas recebidas;
- tratamento de lista vazia na remoção de duplicados e na rotação;
- correção do segundo maior quando o valor válido é `int.MinValue`;
- documentação da complexidade real da mesclagem que ordena as entradas;
- resultados determinísticos nas abordagens com `HashSet`;
- validação da sequência usada para encontrar o número ausente;
- cálculos intermediários promovidos para `long` quando necessário;
- suporte a valores negativos de `k` na rotação;
- complexidade da seleção aleatória com rejeição corrigida para O(n log n) esperado;
- possibilidade de injetar `Random` para testes reproduzíveis.

## Execução

A partir da raiz do repositório:

```bash
dotnet build Lists/Lists.csproj
dotnet run --project Lists/Lists.csproj
```

O `Program.cs` contém exemplos das questões já incorporadas.
