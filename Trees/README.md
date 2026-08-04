# Perguntas de entrevista sobre árvores em .NET

Este módulo reúne **20 exercícios sobre árvores** voltados à preparação para entrevistas técnicas com C#.

Os exercícios utilizam o modelo compartilhado [`TreeNode`](./TreeNode.cs) e procuram apresentar:

- explicação do problema;
- abordagens recursivas e iterativas;
- análise de complexidade de tempo e espaço;
- diferenças entre árvore binária, Binary Search Tree e árvore N-ária;
- tratamento de árvore vazia, árvores degeneradas e entradas inválidas;
- comentários em português do Brasil.

## Progresso

As **20 questões** foram incorporadas, traduzidas e revisadas tecnicamente.

| # | Questão | Arquivo | Situação |
|---:|---|---|---|
| 1 | Travessias em profundidade: pré-ordem, em ordem e pós-ordem | `DepthFirstTraversal.cs` | Concluída |
| 2 | Travessia em largura, agrupada e em zigue-zague | `BreadthFirstTraversal.cs` | Concluída |
| 3 | Encontrar a profundidade máxima | `MaximumDepth.cs` | Concluída |
| 4 | Encontrar a profundidade mínima | `MinimumDepth.cs` | Concluída |
| 5 | Verificar se a árvore está balanceada | `CheckBalancedTree.cs` | Concluída |
| 6 | Verificar se duas árvores são idênticas | `CheckIdenticalTrees.cs` | Concluída |
| 7 | Inverter uma árvore binária | `InvertBinaryTree.cs` | Concluída |
| 8 | Validar uma Binary Search Tree | `ValidateBST.cs` | Concluída |
| 9 | Procurar um valor em uma BST | `SearchBST.cs` | Concluída |
| 10 | Inserir um valor em uma BST | `InsertIntoBST.cs` | Concluída |
| 11 | Encontrar os valores mínimo e máximo de uma BST | `FindMinMaxBST.cs` | Concluída |
| 12 | Encontrar o ancestral comum mais baixo | `LowestCommonAncestor.cs` | Concluída |
| 13 | Calcular o diâmetro da árvore | `DiameterOfBinaryTree.cs` | Concluída |
| 14 | Verificar se a árvore é simétrica | `CheckSymmetricTree.cs` | Concluída |
| 15 | Serializar e desserializar uma árvore | `SerializeDeserializeTree.cs` | Concluída |
| 16 | Verificar soma de caminho da raiz até uma folha | `PathSum.cs` | Concluída |
| 17 | Encontrar todos os caminhos da raiz até as folhas | `RootToLeafPaths.cs` | Concluída |
| 18 | Contar nós totais e folhas | `CountNodes.cs` | Concluída |
| 19 | Encontrar o k-ésimo menor elemento de uma BST | `KthSmallestInBST.cs` | Concluída |
| 20 | Construir uma árvore a partir de relações pai-filho | `BuildTreeFromRelationships.cs` | Concluída |

## Como estudar as implementações

Para cada problema:

1. identifique se o algoritmo depende apenas de uma árvore binária ou exige uma BST;
2. comece pela solução recursiva e determine o caso-base;
3. converta a solução para pilha ou fila quando houver uma versão iterativa;
4. diferencie altura `h`, largura máxima `w` e quantidade total de nós `n`;
5. avalie árvore vazia, nó único, árvore degenerada e árvore completa;
6. verifique se a operação apenas consulta ou modifica a árvore recebida;
7. considere se a complexidade depende também do tamanho da saída produzida.

## Ajustes técnicos aplicados nesta tradução

### Questões 1 a 10

- documentação do espaço de BFS em função da largura máxima `w`;
- campos somente de leitura nas classes que apenas consultam a árvore;
- métodos auxiliares transformados em estáticos quando não dependem de estado;
- serialização de comparação reescrita com `StringBuilder`;
- marcadores de nós nulos preservados para comparar também a estrutura;
- política de duplicados de BST documentada explicitamente;
- limites de validação de BST representados com `long`;
- busca em BST documentada com a pré-condição de árvore válida;
- inserção iterativa reescrita sem supressões desnecessárias de nulabilidade;
- efeitos mutáveis da inversão e da inserção documentados.

### Questões 11 a 20

- LCA retorna `null` quando um dos valores não pertence à árvore;
- serialização e desserialização usam formato determinístico e validação estrita;
- payloads truncados, inválidos ou com tokens excedentes são rejeitados;
- somas de caminhos utilizam `long` para evitar overflow intermediário;
- complexidades de caminhos são expressas em função do tamanho da saída;
- BFS de contagem e simetria usa espaço O(w);
- `k <= 0` é rejeitado antes da busca pelo k-ésimo menor;
- construção por relacionamentos valida IDs duplicados, nomes vazios, pais ausentes e múltiplas raízes;
- ciclos e nós desconectados são detectados antes de expor a hierarquia;
- filhos de `OrgNode` são expostos como coleção somente leitura.

## Execução

A partir da raiz do repositório:

```bash
dotnet build Trees/Trees.csproj
dotnet run --project Trees/Trees.csproj
```

O `Program.cs` contém exemplos representativos das 20 questões. A solução completa também é validada automaticamente pelo GitHub Actions com o SDK do .NET 10.
