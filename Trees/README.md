# Perguntas de entrevista sobre árvores em .NET

Este módulo reúne **20 exercícios sobre árvores** voltados à preparação para entrevistas técnicas com C#.

Os exercícios utilizam o modelo compartilhado [`TreeNode`](./TreeNode.cs) e procuram apresentar:

- explicação do problema;
- abordagens recursivas e iterativas;
- análise de complexidade de tempo e espaço;
- diferenças entre árvore binária e Binary Search Tree;
- tratamento de árvore vazia e árvores degeneradas;
- comentários em português do Brasil.

## Progresso

As questões **1 a 10** já foram incorporadas, traduzidas e revisadas. As questões 11 a 20 serão adicionadas na próxima etapa.

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
| 11 | Encontrar os valores mínimo e máximo de uma BST | `FindMinMaxBST.cs` | Pendente |
| 12 | Encontrar o ancestral comum mais baixo | `LowestCommonAncestor.cs` | Pendente |
| 13 | Calcular o diâmetro da árvore | `DiameterOfBinaryTree.cs` | Pendente |
| 14 | Verificar se a árvore é simétrica | `CheckSymmetricTree.cs` | Pendente |
| 15 | Serializar e desserializar uma árvore | `SerializeDeserializeTree.cs` | Pendente |
| 16 | Verificar soma de caminho da raiz até uma folha | `PathSum.cs` | Pendente |
| 17 | Encontrar todos os caminhos da raiz até as folhas | `RootToLeafPaths.cs` | Pendente |
| 18 | Contar nós totais e folhas | `CountNodes.cs` | Pendente |
| 19 | Encontrar o k-ésimo menor elemento de uma BST | `KthSmallestInBST.cs` | Pendente |
| 20 | Construir uma árvore a partir de relações pai-filho | `BuildTreeFromRelationships.cs` | Pendente |

## Como estudar as implementações

Para cada problema:

1. identifique se o algoritmo depende apenas de uma árvore binária ou exige uma BST;
2. comece pela solução recursiva e determine o caso-base;
3. converta a solução para pilha ou fila quando houver uma versão iterativa;
4. diferencie altura `h`, largura máxima `w` e quantidade total de nós `n`;
5. avalie árvore vazia, nó único, árvore degenerada e árvore completa;
6. verifique se a operação apenas consulta ou modifica a árvore recebida.

## Ajustes técnicos aplicados nesta tradução

Durante a revisão das primeiras dez questões, foram realizados os seguintes ajustes:

- documentação do espaço de BFS em função da largura máxima `w`;
- campos somente de leitura nas classes que apenas consultam a árvore;
- métodos auxiliares transformados em estáticos quando não dependem de estado;
- serialização de comparação reescrita com `StringBuilder`, evitando concatenação quadrática;
- marcadores de nós nulos preservados para comparar também a estrutura;
- política de duplicados de BST documentada explicitamente;
- limites de validação de BST representados com `long`;
- busca em BST documentada com a pré-condição de árvore válida;
- inserção iterativa reescrita sem supressões desnecessárias de nulabilidade;
- efeitos mutáveis da inversão e da inserção documentados.

## Execução

A partir da raiz do repositório:

```bash
dotnet build Trees/Trees.csproj
dotnet run --project Trees/Trees.csproj
```

O `Program.cs` contém exemplos das questões já incorporadas.
