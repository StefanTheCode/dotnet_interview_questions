# 🧩 Perguntas de Entrevista .NET — Português do Brasil

> Guia de estudos em português para entrevistas técnicas de desenvolvimento .NET e C#.

Este repositório é uma tradução e adaptação autorizada do projeto [`StefanTheCode/dotnet_interview_questions`](https://github.com/StefanTheCode/dotnet_interview_questions). O objetivo desta atualização é acompanhar a estrutura atual do projeto original, reunindo **130 perguntas** sobre .NET, C#, SQL, estruturas de dados e algoritmos.

> **Aviso:** conhecer as respostas não garante aprovação em uma entrevista. Use o material para revisar fundamentos, praticar raciocínio técnico e identificar assuntos que precisam de aprofundamento.

## Conteúdo planejado

| Categoria | Quantidade | Formato | Situação |
|---|---:|---|---|
| Arrays | 20 | Implementações C# e análise de complexidade | 10 disponíveis |
| `List<T>` | 20 | Implementações C# e análise de complexidade | Em preparação |
| Árvores | 20 | Implementações C# e análise de complexidade | Em preparação |
| .NET, C#, frameworks, testes e SQL | 70 | Perguntas, respostas e exemplos | 50 disponíveis |
| **Total** | **130** |  | **60 disponíveis** |

## Conteúdo disponível

### Arrays

As primeiras dez questões práticas de arrays estão disponíveis em:

- [Exercícios e implementações com arrays](./Arrays/README.md)

O módulo já inclui inversão, rotação, remoção de duplicados, interseção, número ausente, palíndromo, maior produto de subarray e achatamento de array jagged.

### Perguntas gerais de .NET e C#

As 50 perguntas conceituais já traduzidas estão disponíveis em:

- [Perguntas gerais de .NET e C#](./Interview%20Questions/README.md)

Elas abrangem:

- fundamentos de .NET e CLR;
- orientação a objetos em C#;
- delegates, LINQ, threading e `async`/`await`;
- ASP.NET Core, MVC, Razor Pages, SignalR e Blazor;
- testes, SOLID, CI/CD, segurança e desempenho.

## Estrutura do repositório

```text
.
├── Arrays/                    # 20 exercícios e implementações com arrays
├── Lists/                     # 20 exercícios e implementações com List<T>
├── Trees/                     # 20 exercícios e implementações com árvores
├── Interview Questions/       # Perguntas conceituais de .NET, C# e SQL
├── InterviewQuestions.sln     # Solução .NET
├── ROADMAP.md                 # Progresso da atualização
└── README.md
```

Os projetos de código utilizam **.NET 10** e estão sendo incorporados gradualmente conforme cada módulo é traduzido e revisado.

## Abordagem dos exercícios práticos

Cada exercício de arrays, listas e árvores procura apresentar:

- explicação do problema;
- mais de uma abordagem quando aplicável;
- implementação em C#;
- complexidade de tempo e espaço;
- observações sobre casos extremos;
- comentários em português do Brasil.

Os nomes de classes, métodos, variáveis e APIs permanecem em inglês para preservar as convenções do ecossistema .NET e facilitar a pesquisa na documentação oficial.

## Como executar

Com o SDK do .NET 10 instalado:

```bash
dotnet restore InterviewQuestions.sln
dotnet build InterviewQuestions.sln
```

Para executar um dos projetos:

```bash
dotnet run --project Arrays/Arrays.csproj
dotnet run --project Lists/Lists.csproj
dotnet run --project Trees/Trees.csproj
```

Os pontos de entrada ainda são mínimos. Eles serão atualizados conforme os exercícios forem adicionados.

## Escopo desta tradução

Nesta fase, o trabalho inclui:

- documentação em Markdown;
- perguntas e respostas;
- implementações C#;
- comentários e explicações técnicas.

Os arquivos PDF existentes no projeto original **não serão incorporados nem traduzidos por enquanto**.

## Acompanhamento

O progresso detalhado está registrado no [`ROADMAP.md`](./ROADMAP.md).

## Créditos

O conteúdo original é de autoria de [StefanTheCode](https://github.com/StefanTheCode). Esta versão em português foi iniciada e é mantida por [Rodrigo Oliveira](https://github.com/rodri-oliveira-dev), com autorização para tradução do material original.
