# 🧩 Perguntas de Entrevista .NET – Guia Completo de Estudos

> **Uma coleção abrangente de 130 perguntas de entrevista para desenvolvedores .NET**  
> Abrangendo **Arrays**, **Listas**, **Árvores** e **.NET / C# / SQL** — com implementações claras em C#, diferentes soluções por problema e análise completa de complexidade.

Este repositório é uma tradução e adaptação autorizada do projeto StefanTheCode/dotnet_interview_questions. A atualização acompanha a estrutura do projeto original e reúne 130 conteúdos sobre .NET, C#, SQL, estruturas de dados e algoritmos.

---

## 📖 Sumário

- [Visão geral](#-visão-geral)
- [O que está incluído](#-o-que-está-incluído)
- [Categorias de perguntas](#-categorias-de-perguntas)
- [Tipos de perguntas de entrevista](#-tipos-de-perguntas-de-entrevista)
- [Arrays — 20 questões](#-arrays--20-questões)
- [Listas — 20 questões](#-listt--20-questões)
- [Árvores — 20 questões](#-árvores--20-questões)
- [.NET / C# / SQL — 70 questões](#-net--c--sql--70-questões)
- [Estrutura do repositório](#-estrutura-do-repositório)
- [Como utilizar](#-como-utilizar)
- [Probabilidade de aparecer em entrevistas](#-probabilidade-de-aparecer-em-entrevistas)
- [Comparação entre estruturas de dados](#-comparação-entre-estruturas-de-dados)
- [Padrões comuns de algoritmos](#-padrões-comuns-de-algoritmos)
- [Resumo de complexidade Big O](#-resumo-de-complexidade-big-o)
- [Dicas e estratégia para entrevistas](#-dicas-e-estratégia-para-entrevistas)
- [Cobertura e preparação](#-cobertura-e-preparação)
- [Notas do autor](#-notas-do-autor)

---

## 🔎 Visão geral

Este repositório foi criado para a **preparação de entrevistas .NET** e contém:

| Categoria | Questões | Formato | Foco |
|---|---:|---|---|
| **Arrays** | 20 | Implementações em classes C# | Algoritmos, manipulação, busca e ordenação |
| **`List<T>`** | 20 | Implementações em classes C# | Coleções, LINQ e dados dinâmicos |
| **Árvores** | 20 | Implementações em classes C# | Recursão, BST, travessias e propriedades de árvores |
| **.NET geral** | 70 | Perguntas e respostas com exemplos | Fundamentos da linguagem, frameworks, SQL e boas práticas |

**Total: 130 questões de entrevista**, cobrindo os assuntos mais comuns em entrevistas técnicas .NET — do nível júnior ao intermediário/sênior.

---

## 📦 O que está incluído

Cada questão prática de código, nos módulos de Arrays, Listas e Árvores, inclui:

- ✅ **Explicação do problema** na documentação da classe;
- ✅ **Duas ou três soluções** por problema, evoluindo da força bruta para abordagens mais eficientes;
- ✅ Análise de **complexidade de tempo e espaço** para cada abordagem;
- ✅ **Código C# claro e comentado**, pronto para execução;
- ✅ Discussão de **casos extremos**, como entradas vazias, valores nulos, duplicados e números negativos.

A seção geral de .NET oferece:

- ✅ **Respostas detalhadas** para questões conceituais e de frameworks;
- ✅ **Exemplos de código** demonstrando os principais conceitos;
- ✅ Cobertura progressiva: Básico → Intermediário → Avançado → Frameworks → Testes e boas práticas → SQL.

---

## 🗂 Categorias de perguntas

```text
Perguntas de entrevista
│
├── 📁 Arrays (20 questões)
│   ├── Inversão, rotação e busca
│   ├── Contagem de frequência e duplicados
│   ├── Problemas de subarray — Kadane e maior produto
│   ├── Busca binária, ordenação e embaralhamento
│   └── Conceitos — arrays jagged, multidimensionais e redimensionamento
│
├── 📁 Listas (20 questões)
│   ├── Duplicados, ordenação e inversão
│   ├── Mesclagem, divisão e achatamento
│   ├── Busca e contagem de frequência
│   ├── Somas contíguas e movimentação de zeros
│   └── Comparação de igualdade e divisão em blocos
│
├── 📁 Árvores (20 questões)
│   ├── Travessias DFS e BFS
│   ├── Profundidade, balanceamento e simetria
│   ├── Operações de BST — inserção, busca e validação
│   ├── Soma de caminhos, diâmetro e ancestral comum
│   └── Serialização, desserialização e construção a partir de dados
│
└── 📁 .NET / C# / SQL (70 questões)
    ├── Básico (Q1–Q10): CLR, tipos, GC e namespaces
    ├── Intermediário (Q11–Q20): polimorfismo, LINQ e async/await
    ├── Avançado (Q21–Q30): reflection, DI e middleware
    ├── Frameworks (Q31–Q40): MVC, Blazor, SignalR e cache
    ├── Testes (Q41–Q50): testes unitários, SOLID e CI/CD
    └── SQL (Q51–Q70): joins, índices, normalização e segurança
```

---

## 🎯 Tipos de perguntas de entrevista

Conhecer os **tipos de perguntas** ajuda a organizar a preparação de forma estratégica.

### 1. 🧠 Estruturas de dados e algoritmos

> *“Escreva uma função que...”*

Essas questões exigem a implementação de uma solução durante a entrevista. Elas avaliam:

- decomposição de problemas;
- projeto de algoritmos, da força bruta à otimização;
- análise de complexidade Big O;
- tratamento de casos extremos.

**Conteúdo relacionado:** Arrays, Listas e Árvores.

### 2. 💬 Questões conceituais e teóricas

> *“Explique a diferença entre...”*

Essas questões avaliam o conhecimento dos fundamentos da linguagem e da plataforma:

- tipos de valor e tipos de referência;
- classe abstrata e interface;
- código gerenciado e não gerenciado;
- funcionamento do garbage collector.

**Conteúdo relacionado:** .NET geral, questões 1 a 30.

### 3. 🏗 Questões de frameworks e arquitetura

> *“Como você implementaria...”*

Essas questões avaliam o conhecimento prático do ecossistema .NET:

- pipeline de middleware do ASP.NET Core;
- Entity Framework e padrões de ORM;
- injeção de dependência;
- SignalR, Blazor e versionamento de Web APIs.

**Conteúdo relacionado:** .NET geral, questões 31 a 40.

### 4. ✅ Testes e boas práticas

> *“Como você garante a qualidade do código...”*

Essas questões avaliam a maturidade de engenharia:

- testes unitários e mocks;
- princípios SOLID;
- padrão Repository;
- pipelines de CI/CD.

**Conteúdo relacionado:** .NET geral, questões 41 a 50.

### 5. 🗄 SQL e bancos de dados

> *“Qual é a diferença entre...”*

Essas questões avaliam o conhecimento da camada de dados:

- joins, índices e normalização;
- transações e propriedades ACID;
- otimização de consultas;
- prevenção de SQL injection.

**Conteúdo relacionado:** SQL, questões 51 a 70.

---

## 📚 Arrays — 20 questões

Arrays estão entre os primeiros assuntos abordados em entrevistas de programação porque avaliam resolução de problemas, laços, condições e índices, além de servirem como base para hashing, ordenação e projeto de algoritmos.

| # | Questão | Conceitos principais | Arquivo |
|---:|---|---|---|
| 1 | Comparar `Array`, `ArrayList` e `List<T>` | Segurança de tipos, genéricos e desempenho | `Array_ArrayList_List.cs` |
| 2 | Inverter um array | Dois ponteiros e alteração in-place | `ReverseArray.cs` |
| 3 | Encontrar o maior produto de um subarray | Programação dinâmica e controle de mínimo/máximo | `MaxProductSubarray.cs` |
| 4 | Remover duplicados de um array | `HashSet` e ordenação | `RemoveDuplicates.cs` |
| 5 | Encontrar o número ausente de 1 até N | Fórmula da soma e XOR | `FindMissingNumber.cs` |
| 6 | Encontrar a interseção entre dois arrays | `HashSet` e dois ponteiros | `FindIntersection.cs` |
| 7 | Encontrar o primeiro elemento não repetido | `Dictionary` e contagem de frequência | `FirstNonRepeatingElement.cs` |
| 8 | Rotacionar um array em K posições | Algoritmo de inversão e aritmética modular | `RotateArray.cs` |
| 9 | Verificar se um array é palíndromo | Dois ponteiros | `CheckPalindromeArray.cs` |
| 10 | Achatar um array bidimensional | Iteração aninhada e LINQ | `Flatten2DArray.cs` |
| 11 | Encontrar o elemento majoritário | Algoritmo de votação de Boyer–Moore | `MajorityElementFinder.cs` |
| 12 | Encontrar todos os pares com uma soma específica | `HashSet` e dois ponteiros | `FindPairsWithSum.cs` |
| 13 | Implementar busca binária | Abordagens iterativa e recursiva | `BinarySearchArray.cs` |
| 14 | Encontrar a maior soma de subarray | Algoritmo de Kadane | `MaxSubarraySum.cs` |
| 15 | Contar a frequência dos elementos | `Dictionary` e `GroupBy` | `ElementFrequencyCounter.cs` |
| 16 | Comparar arrays jagged e multidimensionais | Layout de memória e desempenho | `JaggedVsMultidimensionalArray.cs` |
| 17 | Embaralhar um array com Fisher–Yates | Aleatoriedade e alteração in-place | `ShuffleArray.cs` |
| 18 | Redimensionar um array em C# | `Array.Resize` e cópia | `ResizeArray.cs` |
| 19 | Ordenar objetos personalizados | `IComparer` e `OrderBy` | `SortCustomObjects.cs` |
| 20 | Analisar a complexidade das operações com arrays | Acesso O(1) e busca O(n) | `ArrayOperationsComplexity.md` |

---

## 📚 `List<T>` — 20 questões

`List<T>` é uma das coleções mais utilizadas no .NET. Ela oferece redimensionamento dinâmico, segurança de tipos com genéricos e integração com LINQ.

| # | Questão | Conceitos principais | Arquivo |
|---:|---|---|---|
| 1 | Remover duplicados | `HashSet` e `Distinct` | `RemoveDuplicates.cs` |
| 2 | Encontrar o segundo maior elemento | Percurso único e ordenação | `FindSecondLargest.cs` |
| 3 | Inverter uma lista | Alteração in-place e LINQ | `ReverseList.cs` |
| 4 | Ordenar uma lista com diferentes abordagens | `IComparer`, LINQ e algoritmo próprio | `SortList.cs` |
| 5 | Contar a frequência dos elementos | `Dictionary` e `GroupBy` | `ElementFrequencyCounter.cs` |
| 6 | Encontrar elementos comuns | `HashSet` e `Intersect` | `FindCommonElements.cs` |
| 7 | Mesclar duas listas ordenadas | Mesclagem com dois ponteiros | `MergeTwoLists.cs` |
| 8 | Encontrar números ausentes em um intervalo | `HashSet` e verificação sequencial | `FindMissingNumbers.cs` |
| 9 | Rotacionar uma lista em K posições | Fatias, concatenação e inversão | `RotateList.cs` |
| 10 | Embaralhar uma lista com Fisher–Yates | Aleatoriedade | `ShuffleList.cs` |
| 11 | Verificar se uma lista é palíndromo | Dois ponteiros | `CheckPalindromeList.cs` |
| 12 | Encontrar o primeiro elemento não repetido | `Dictionary` e percurso ordenado | `FirstNonRepeatingElement.cs` |
| 13 | Agrupar elementos duplicados | `Dictionary` e `GroupBy` | `GroupDuplicates.cs` |
| 14 | Remover todas as ocorrências de um valor | `RemoveAll` e LINQ | `RemoveAllOccurrences.cs` |
| 15 | Encontrar todos os pares com uma soma específica | `HashSet` e força bruta | `FindPairsWithSum.cs` |
| 16 | Dividir uma lista em blocos | `Chunk` e divisão manual | `SplitListIntoChunks.cs` |
| 17 | Achatar listas aninhadas | Iteração e `SelectMany` | `FlattenNestedLists.cs` |
| 18 | Encontrar a maior soma contígua | Algoritmo de Kadane | `MaxContiguousSum.cs` |
| 19 | Mover todos os zeros para o final | Dois ponteiros e particionamento | `MoveZerosToEnd.cs` |
| 20 | Comparar a igualdade entre listas | `SequenceEqual` e comparação por conteúdo | `CompareListEquality.cs` |

---

## 📚 Árvores — 20 questões

Árvores avaliam raciocínio recursivo e divisão e conquista. Elas também aparecem em aplicações reais, como sistemas de arquivos, organogramas e árvores DOM.

### 🌳 Modelo do nó da árvore

Os problemas de árvores binárias compartilham uma classe mínima `TreeNode`:

```csharp
public class TreeNode
{
    public int Value { get; set; }
    public TreeNode? Left { get; set; }
    public TreeNode? Right { get; set; }

    public TreeNode(int value) { Value = value; }
}
```

| # | Questão | Conceitos principais | Arquivo |
|---:|---|---|---|
| 1 | Percorrer em profundidade — pré-ordem, em ordem e pós-ordem | Recursão e pilha iterativa | `DepthFirstTraversal.cs` |
| 2 | Percorrer em largura ou por níveis | Fila e BFS | `BreadthFirstTraversal.cs` |
| 3 | Encontrar a profundidade máxima | Recursão e DFS | `MaximumDepth.cs` |
| 4 | Encontrar a profundidade mínima | BFS e recursão | `MinimumDepth.cs` |
| 5 | Verificar se a árvore está balanceada | Comparação de alturas e DFS | `CheckBalancedTree.cs` |
| 6 | Verificar se duas árvores são idênticas | Comparação recursiva | `CheckIdenticalTrees.cs` |
| 7 | Inverter ou espelhar uma árvore binária | Troca recursiva e BFS | `InvertBinaryTree.cs` |
| 8 | Validar uma BST | Percurso em ordem e limites mínimo/máximo | `ValidateBST.cs` |
| 9 | Buscar em uma BST | Abordagens recursiva e iterativa | `SearchBST.cs` |
| 10 | Inserir em uma BST | Abordagens recursiva e iterativa | `InsertIntoBST.cs` |
| 11 | Encontrar mínimo e máximo em uma BST | Nós mais à esquerda e à direita | `FindMinMaxBST.cs` |
| 12 | Encontrar o ancestral comum mais baixo | Propriedade da BST e árvore geral | `LowestCommonAncestor.cs` |
| 13 | Calcular o diâmetro da árvore | DFS e controle de altura | `DiameterOfBinaryTree.cs` |
| 14 | Verificar se a árvore é simétrica | Comparação espelhada | `CheckSymmetricTree.cs` |
| 15 | Serializar e desserializar uma árvore | Pré-ordem e representação textual | `SerializeDeserializeTree.cs` |
| 16 | Verificar a soma de um caminho da raiz até uma folha | DFS e backtracking | `PathSum.cs` |
| 17 | Encontrar todos os caminhos da raiz até as folhas | DFS e construção de caminhos | `RootToLeafPaths.cs` |
| 18 | Contar nós totais e folhas | Recursão e BFS | `CountNodes.cs` |
| 19 | Encontrar o k-ésimo menor valor em uma BST | Percurso em ordem | `KthSmallestInBST.cs` |
| 20 | Construir uma árvore a partir de relações | Árvore N-ária e organograma | `BuildTreeFromRelationships.cs` |

---

## 📚 .NET / C# / SQL — 70 questões

Estas questões conceituais abordam a **plataforma .NET, a linguagem C#, o ASP.NET Core, testes e SQL**, sendo importantes para a parte não prática das entrevistas.

### Básico — Q1 a Q10

| # | Questão |
|---:|---|
| 1 | O que é .NET? |
| 2 | O que é o Common Language Runtime — CLR? |
| 3 | Qual é a diferença entre código gerenciado e não gerenciado? |
| 4 | Qual é a estrutura básica de um programa C#? |
| 5 | O que são tipos de valor e tipos de referência? |
| 6 | O que é garbage collection no .NET? |
| 7 | Como funciona o tratamento de exceções em C#? |
| 8 | Quais são os diferentes tipos de classes em C#? |
| 9 | O que é um namespace e como ele é utilizado? |
| 10 | O que é encapsulamento? |

### Intermediário — Q11 a Q20

| # | Questão |
|---:|---|
| 11 | O que é polimorfismo e quais são seus tipos em C#? |
| 12 | O que são delegates e como são utilizados? |
| 13 | O que é LINQ? |
| 14 | Qual é a diferença entre classe abstrata e interface? |
| 15 | Como gerenciar memória em aplicações .NET? |
| 16 | Como funciona o threading no .NET? |
| 17 | O que são `async` e `await` e como funcionam? |
| 18 | O que é Entity Framework Core e quais são suas vantagens? |
| 19 | O que são extension methods? |
| 20 | Como tratar exceções em um método que retorna `Task`? |

### Avançado — Q21 a Q30

| # | Questão |
|---:|---|
| 21 | O que é reflection no .NET? |
| 22 | O que é middleware no ASP.NET Core? |
| 23 | Como funciona a injeção de dependência no .NET? |
| 24 | Qual é o propósito do .NET Standard? |
| 25 | Quais são as diferenças entre .NET, .NET Framework e Xamarin? |
| 26 | Como o garbage collector funciona e como reduzir a pressão de memória? |
| 27 | O que são atributos em C#? |
| 28 | Como funciona o processo de compilação no .NET? |
| 29 | O que é o Global Assembly Cache — GAC? |
| 30 | Como proteger uma aplicação web ASP.NET Core? |

### Frameworks — Q31 a Q40

| # | Questão |
|---:|---|
| 31 | O que é MVC? |
| 32 | Qual é a diferença entre Razor Pages e MVC? |
| 33 | Como realizar validações no ASP.NET Core? |
| 34 | O que é SignalR e quais são seus casos de uso? |
| 35 | Quais são os benefícios e trade-offs do Blazor? |
| 36 | Como implementar versionamento de Web APIs? |
| 37 | Qual é o papel de `IApplicationBuilder` e do modelo moderno de hospedagem? |
| 38 | O que são Areas no ASP.NET Core? |
| 39 | Como gerenciar sessões no ASP.NET Core? |
| 40 | Como implementar cache no ASP.NET Core? |

### Testes e boas práticas — Q41 a Q50

| # | Questão |
|---:|---|
| 41 | O que é um teste unitário em .NET? |
| 42 | Como simular dependências em testes unitários? |
| 43 | Quais são os princípios SOLID? |
| 44 | O que é CI/CD e como se aplica ao .NET? |
| 45 | Como garantir a segurança do código C#? |
| 46 | Quais são os problemas comuns de desempenho em aplicações .NET? |
| 47 | O que é o padrão Repository e quais são seus trade-offs? |
| 48 | Como trabalhar com migrations no Entity Framework Core? |
| 49 | Quais ferramentas podem ser usadas para depuração e profiling? |
| 50 | Como se manter atualizado sobre tecnologias .NET? |

### SQL — Q51 a Q70

| # | Questão |
|---:|---|
| 51 | Qual é a diferença entre `INNER JOIN`, `LEFT JOIN`, `RIGHT JOIN` e `FULL OUTER JOIN`? |
| 52 | Qual é a diferença entre chave primária e restrição `UNIQUE`? |
| 53 | O que são chaves estrangeiras e integridade referencial? |
| 54 | O que é normalização e quais são as formas normais? |
| 55 | Qual é a diferença entre índice clustered e nonclustered? |
| 56 | O que são transações e propriedades ACID? |
| 57 | Qual é a diferença entre `DELETE`, `TRUNCATE TABLE` e `DROP TABLE`? |
| 58 | O que são funções de janela? |
| 59 | Qual é a diferença entre CTE e subconsulta? |
| 60 | Quais são as vantagens e desvantagens de stored procedures? |
| 61 | Como detectar e prevenir SQL injection? |
| 62 | Qual é a diferença entre `EXISTS` e `IN`? |
| 63 | Como índices funcionam e como identificar consultas lentas? |
| 64 | Para que servem planos de execução? |
| 65 | Como funcionam agregações, `GROUP BY`, `WHERE` e `HAVING`? |
| 66 | O que é uma chave composta? |
| 67 | Qual é a diferença entre view materializada e view comum? |
| 68 | Como tratar valores `NULL`? |
| 69 | Qual é a diferença entre funções escalares e table-valued functions? |
| 70 | Como projetar o banco de uma aplicação multitenant? |

---

## 📂 Estrutura do repositório

```text
InterviewQuestions/
│
├── InterviewQuestions.sln                 # Solução .NET
├── Directory.Build.props                  # Configurações comuns de compilação
├── README.md                              # 📌 Documentação principal
├── ROADMAP.md                             # Histórico da tradução e revisão
│
├── Arrays/                                # 20 questões sobre arrays
│   ├── Program.cs
│   ├── Arrays.csproj
│   ├── ReverseArray.cs
│   ├── RotateArray.cs
│   ├── FindMissingNumber.cs
│   ├── MaxSubarraySum.cs
│   ├── ...
│   └── README.md                          # Guia específico de arrays
│
├── Lists/                                 # 20 questões sobre List<T>
│   ├── Program.cs
│   ├── Lists.csproj
│   ├── RemoveDuplicates.cs
│   ├── MergeTwoLists.cs
│   ├── ...
│   └── README.md                          # Guia específico de listas
│
├── Trees/                                 # 20 questões sobre árvores
│   ├── Program.cs
│   ├── Trees.csproj
│   ├── TreeNode.cs                        # Modelo de nó compartilhado
│   ├── DepthFirstTraversal.cs
│   ├── ValidateBST.cs
│   ├── ...
│   └── README.md                          # Guia específico de árvores
│
└── Interview Questions/
    ├── README.md                          # 50 questões de .NET e C#
    └── SQL.md                             # 20 questões de SQL
```

Cada arquivo de questão prática contém uma **classe independente** que:

- explica o problema na documentação da classe;
- apresenta diferentes soluções, da força bruta a abordagens mais eficientes;
- documenta a complexidade de tempo e espaço;
- descreve premissas e casos extremos relevantes.

---

## ⚡ Como utilizar

### Pré-requisitos

- **SDK do .NET 10**;
- **Visual Studio 2022**, **Rider** ou **VS Code com C# Dev Kit**.

### Primeiros passos

1. **Clone o repositório** e abra `InterviewQuestions.sln`.
2. Escolha uma pasta: `Arrays/`, `Lists/` ou `Trees/`.
3. Abra um arquivo de questão e leia a documentação da classe.
4. Estude as soluções em ordem, comparando suas vantagens e complexidades.
5. Execute os exemplos em `Program.cs` ou crie casos próprios.
6. Para questões conceituais, consulte `Interview Questions/README.md` e `Interview Questions/SQL.md`.

### Ordem de estudo recomendada

```text
1. Arrays — fundamentos
2. Listas — coleções dinâmicas e LINQ
3. Árvores — raciocínio recursivo
4. .NET básico → intermediário → avançado
5. Frameworks, testes, boas práticas e SQL
```

### Execução

```bash
dotnet restore InterviewQuestions.sln
dotnet build InterviewQuestions.sln --configuration Release

dotnet run --project Arrays/Arrays.csproj --configuration Release
dotnet run --project Lists/Lists.csproj --configuration Release
dotnet run --project Trees/Trees.csproj --configuration Release
```

---

## 📊 Probabilidade de aparecer em entrevistas

As porcentagens abaixo são apenas estimativas orientativas. A frequência real varia conforme empresa, senioridade, vaga e formato da entrevista.

### Questões práticas — Arrays, Listas e Árvores

| Prioridade | Probabilidade | Assuntos |
|---|---:|---|
| 🔴 **Alta** | **70–80%** | Inversão, rotação, número ausente, remoção de duplicados, primeiro não repetido, palíndromo, maior soma de subarray, pares com soma, frequências, DFS/BFS, profundidade máxima, validação de BST, inversão de árvore, LCA e balanceamento |
| 🟡 **Média** | **40–50%** | Maior produto de subarray, achatamento, mesclagem de listas, elemento majoritário, movimentação de zeros, busca binária, diâmetro, serialização, k-ésimo menor e divisão em blocos |
| 🟢 **Baixa** | **20–30%** | Arrays jagged e multidimensionais, redimensionamento, ordenação de objetos, embaralhamento, agrupamento de duplicados e construção de árvores a partir de relações |

### Questões conceituais

| Prioridade | Probabilidade | Assuntos |
|---|---:|---|
| 🔴 **Alta** | **80–90%** | Tipos de valor e referência, `async`/`await`, SOLID, classe abstrata e interface, DI, GC e tratamento de exceções |
| 🟡 **Média** | **50–60%** | LINQ, delegates, EF Core, threading, middleware, MVC e testes unitários |
| 🟢 **Baixa** | **30–40%** | Reflection, GAC, .NET Standard, Blazor, Areas e SignalR |

💡 **Dica:** quando o tempo de preparação for limitado, comece pelas questões de prioridade alta.

---

## ⚖ Comparação entre estruturas de dados

| Característica | Array | `List<T>` | Árvore binária | BST |
|---|---:|---:|---:|---:|
| **Acesso por índice** | O(1) | O(1) | O(n) | O(n) |
| **Busca** | O(n) | O(n) | O(n) | O(log n)* |
| **Inserção no final** | O(n)† | O(1)‡ | O(n) | O(log n)* |
| **Remoção** | O(n) | O(n) | O(n) | O(log n)* |
| **Memória** | Contígua | Contígua | Nós e referências | Nós e referências |
| **Redimensionável** | Não | Sim | Sim | Sim |
| **Ordenação** | Por índice | Por índice | Pela estrutura | Pelo valor |

\* Caso médio de uma BST balanceada; o pior caso é O(n) em uma árvore degenerada.  
† Exige a criação de um novo array.  
‡ O(1) amortizado; O(n) quando o array interno precisa ser redimensionado.

---

## 🔄 Padrões comuns de algoritmos

Esses padrões aparecem repetidamente nas diferentes categorias:

| Padrão | Descrição | Exemplos de uso |
|---|---|---|
| **Dois ponteiros** | Ponteiros no início e no final se aproximam | Inversão, palíndromo, pares com soma e remoção de duplicados |
| **Janela deslizante** | Janela fixa ou variável sobre uma sequência | Somas e produtos de subarrays |
| **Hash map ou set** | Consultas rápidas de frequência e existência | Frequências, número ausente, interseção e pares |
| **Ordenação e percurso** | Ordenar antes de realizar uma passagem linear | Duplicados, elementos comuns e mesclagem |
| **Algoritmo de Kadane** | Manter a melhor soma contígua durante o percurso | Maior soma de subarray e soma contígua |
| **Votação de Boyer–Moore** | Encontrar o elemento majoritário em O(n) e O(1) | Elemento majoritário |
| **Recursão ou DFS** | Explorar todos os ramos em profundidade | Árvores e caminhos |
| **BFS ou percurso por níveis** | Explorar um nível por vez | Travessia em largura, profundidade mínima e simetria |
| **Busca binária** | Dividir o espaço de busca pela metade | Arrays ordenados e busca em BST |
| **Divisão e conquista** | Dividir, resolver as partes e combinar | Subarrays e profundidade de árvores |
| **Backtracking** | Explorar uma escolha e desfazê-la ao retornar | Soma de caminhos e caminhos raiz-folha |

---

## 📈 Resumo de complexidade Big O

| Complexidade | Nome | Exemplo |
|---|---|---|
| **O(1)** | Constante | Acesso a array por índice e consulta em hash |
| **O(log n)** | Logarítmica | Busca binária e operações em BST balanceada |
| **O(n)** | Linear | Percurso único de array/lista e DFS/BFS |
| **O(n log n)** | Linearítmica | Algoritmos eficientes de ordenação e `OrderBy` |
| **O(n²)** | Quadrática | Laços aninhados, pares por força bruta e bubble sort |
| **O(2ⁿ)** | Exponencial | Geração recursiva de subconjuntos |

A **complexidade de espaço** também deve ser considerada:

- **O(1):** algoritmo in-place, como troca com dois ponteiros;
- **O(n):** array auxiliar, `HashSet`, dicionário ou fila;
- **O(h):** pilha de recursão de uma árvore, em que `h` representa a altura;
- **O(w):** fila de uma travessia BFS, em que `w` representa a largura máxima.

---

## 💡 Dicas e estratégia para entrevistas

### Antes da entrevista

- ✅ Domine primeiro as questões de prioridade alta.
- ✅ Conheça pelo menos duas abordagens para os problemas principais.
- ✅ Pratique explicar o raciocínio em voz alta.
- ✅ Revise a análise de complexidade Big O.
- ✅ Prepare exemplos que demonstrem experiência prática com .NET.

### Durante a entrevista

1. **Esclareça o problema:** pergunte sobre restrições, tamanho das entradas e casos extremos.
2. **Comece por uma solução simples:** demonstre o raciocínio antes de otimizar.
3. **Explique enquanto implementa:** apresente decisões e trade-offs.
4. **Teste com exemplos:** percorra manualmente entradas representativas.
5. **Discuta alternativas:** compare tempo, memória, legibilidade e manutenção.

### Casos extremos que devem ser considerados

| Estrutura | Casos extremos |
|---|---|
| **Arrays e listas** | Entrada vazia, único elemento, todos duplicados, números negativos e sequência já ordenada |
| **Árvores** | Raiz nula, único nó, árvore degenerada e árvore muito profunda |
| **Geral** | Entradas nulas ou vazias, overflow, concorrência, cancelamento e falhas parciais |

### Progressão comum de otimização

```text
Força bruta — O(n²)
    → Ordenação e percurso — O(n log n)
        → Hash map — O(n) de tempo e O(n) de espaço
            → Dois ponteiros ou solução in-place — O(n) de tempo e O(1) de espaço
```

Essa progressão é uma referência, não uma regra universal. A melhor solução depende das restrições e das propriedades do problema.

---

## 📊 Cobertura e preparação

| Ao dominar... | Você terá... |
|---|---|
| As 20 questões de arrays | Uma base ampla para entrevistas envolvendo arrays |
| As 20 questões de listas | Uma base ampla para problemas com `List<T>` e coleções |
| As 20 questões de árvores | Uma base ampla para travessias, BST e problemas recursivos |
| As 70 questões de .NET, C# e SQL | Uma base consistente para rodadas conceituais |
| **Todo o conteúdo** | **Preparação abrangente para entrevistas .NET de nível júnior a intermediário/sênior** |

Os problemas práticos também são úteis como preparação para exercícios de nível fácil e intermediário em plataformas como LeetCode.

---

## ✅ Notas do autor

Esta coleção foi preparada para o estudo de entrevistas .NET:

- utiliza projetos em **.NET 10**;
- mantém nomes de classes, métodos, variáveis e APIs em inglês;
- segue práticas de código claro e documentação em português do Brasil;
- apresenta otimização progressiva, da força bruta a abordagens mais eficientes;
- trata warnings de compilação como erros;
- executa exemplos dos três módulos como smoke tests no GitHub Actions;
- mantém cada questão em um arquivo focado no respectivo problema.

**Praticar as questões e compreender as decisões, complexidades e limitações de cada solução oferece uma base sólida para entrevistas técnicas .NET.**