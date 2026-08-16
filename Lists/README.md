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

As **20 questões** foram incorporadas, traduzidas e revisadas.

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
| 11 | Verificar se uma lista é palíndromo | `CheckPalindromeList.cs` | Concluída |
| 12 | Encontrar o primeiro elemento não repetido | `FirstNonRepeatingElement.cs` | Concluída |
| 13 | Agrupar elementos duplicados | `GroupDuplicates.cs` | Concluída |
| 14 | Remover todas as ocorrências de um valor | `RemoveAllOccurrences.cs` | Concluída |
| 15 | Encontrar pares com uma soma específica | `FindPairsWithSum.cs` | Concluída |
| 16 | Dividir uma lista em blocos | `SplitListIntoChunks.cs` | Concluída |
| 17 | Achatar listas aninhadas | `FlattenNestedLists.cs` | Concluída |
| 18 | Encontrar a maior soma contígua | `MaxContiguousSum.cs` | Concluída |
| 19 | Mover zeros para o final | `MoveZerosToEnd.cs` | Concluída |
| 20 | Comparar igualdade entre listas | `CompareListEquality.cs` | Concluída |

## Como estudar as implementações

Para cada problema:

1. comece pela solução mais simples e explique o raciocínio;
2. identifique o custo de buscas, inserções e remoções em `List<T>`;
3. compare soluções que preservam a ordem com soluções baseadas em ordenação;
4. avalie entradas vazias, valores duplicados, números negativos e limites de `int`;
5. identifique se a operação modifica a coleção interna ou retorna uma nova lista.

## Ajustes técnicos aplicados nesta tradução

### Questões 1 a 10

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

### Questões 11 a 20

- cópias defensivas mantidas também nas operações mutáveis;
- pares duplicados eliminados em todas as abordagens;
- somas protegidas contra overflow com promoção para `long`;
- complexidade da abordagem de dois ponteiros corrigida para incluir a cópia ordenada;
- tamanho de bloco validado para impedir zero, valores negativos e laços inválidos;
- listas aninhadas copiadas profundamente e validadas contra elementos nulos;
- complexidade do achatamento expressa em função do total de elementos;
- maior soma contígua passou a rejeitar entrada vazia e retornar `long`;
- versão LINQ da maior soma reescrita com prefixos de soma;
- distinção explícita entre igualdade sensível à ordem e igualdade por conteúdo.

## Execução

A partir da raiz do repositório:

```bash
dotnet build Lists/Lists.csproj
dotnet run --project Lists/Lists.csproj
```

O `Program.cs` contém exemplos dos dois blocos do módulo. A solução completa é validada pelo workflow de GitHub Actions usando o SDK do .NET 10.
