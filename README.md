# 🧩 Perguntas de Entrevista .NET — Português do Brasil

> Guia de estudos em português para entrevistas técnicas de desenvolvimento .NET e C#.

Este repositório é uma tradução e adaptação autorizada do projeto [`StefanTheCode/dotnet_interview_questions`](https://github.com/StefanTheCode/dotnet_interview_questions). A atualização acompanha a estrutura do projeto original e reúne **130 conteúdos** sobre .NET, C#, SQL, estruturas de dados e algoritmos.

> **Aviso:** conhecer as respostas não garante aprovação em uma entrevista. Use o material para revisar fundamentos, praticar raciocínio técnico e identificar assuntos que precisam de aprofundamento.

## Conteúdo

| Categoria | Quantidade | Formato | Situação |
|---|---:|---|---|
| Arrays | 20 | Implementações C# e análise de complexidade | Concluído |
| `List<T>` | 20 | Implementações C# e análise de complexidade | Concluído |
| Árvores | 20 | Implementações C# e análise de complexidade | Concluído |
| .NET, C#, frameworks e testes | 50 | Perguntas, respostas e exemplos | Concluído |
| SQL | 20 | Perguntas, respostas e exemplos | Concluído |
| **Total** | **130** |  | **130 disponíveis** |

## Conteúdo disponível

### Arrays

As 20 questões de arrays estão disponíveis em:

- [Exercícios e implementações com arrays](./Arrays/README.md)

O módulo inclui operações fundamentais, inversão, rotação, duplicados, interseção, número ausente, palíndromo, subarrays, busca binária, frequências, Fisher–Yates, redimensionamento, ordenação de objetos e análise de complexidade.

### `List<T>`

As 20 questões de listas estão disponíveis em:

- [Exercícios e implementações com listas](./Lists/README.md)

O módulo inclui duplicados, segundo maior valor, reversão, ordenação, frequências, interseção, mesclagem, número ausente, rotação, embaralhamento, palíndromo, agrupamento, pares, blocos, achatamento, soma contígua, movimentação de zeros e comparação de igualdade.

### Árvores

As 20 questões de árvores estão disponíveis em:

- [Exercícios e implementações com árvores](./Trees/README.md)

O módulo inclui DFS, BFS, profundidade, balanceamento, igualdade, inversão, operações de BST, ancestral comum, diâmetro, simetria, serialização, somas e caminhos, contagem, k-ésimo menor valor e construção de hierarquias a partir de relações pai-filho.

### Perguntas gerais de .NET e C#

As 50 perguntas conceituais preservadas e revisadas estão disponíveis em:

- [Perguntas gerais de .NET e C#](./Interview%20Questions/README.md)

Elas abrangem:

- fundamentos de .NET e CLR;
- orientação a objetos em C#;
- delegates, LINQ, threading e `async`/`await`;
- ASP.NET Core, MVC, Razor Pages, SignalR e Blazor;
- testes, SOLID, CI/CD, segurança e desempenho.

### SQL

As questões 51 a 70 estão disponíveis em:

- [Perguntas de entrevista sobre SQL](./Interview%20Questions/SQL.md)

O módulo aborda:

- junções, chaves, integridade referencial e normalização;
- índices, transações, funções de janela, CTEs e stored procedures;
- SQL injection, `EXISTS`, `IN` e lógica de três valores;
- diagnóstico de consultas e planos de execução;
- agregações, chaves compostas, views materializadas e funções definidas pelo usuário;
- estratégias de banco para aplicações multitenant.

Os exemplos são apresentados principalmente em SQL Server/T-SQL e indicam quando o comportamento varia entre SGBDs.

## Estrutura do repositório

```text
.
├── Arrays/                    # 20 questões concluídas sobre arrays
├── Lists/                     # 20 questões concluídas sobre List<T>
├── Trees/                     # 20 questões concluídas sobre árvores
├── Interview Questions/
│   ├── README.md              # 50 perguntas de .NET e C#
│   └── SQL.md                 # 20 perguntas de SQL
├── InterviewQuestions.sln     # Solução .NET
├── ROADMAP.md                 # Histórico e revisão técnica
└── README.md
```

Os projetos de código utilizam **.NET 10** e foram incorporados com tradução e revisão técnica das implementações originais.

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

Os três projetos contêm exemplos executáveis dos respectivos módulos completos.

## Validação

A solução é validada por GitHub Actions com o SDK do .NET 10. O workflow executa restore e build em modo Release a cada atualização da branch de trabalho e nos pull requests direcionados à `main`.

## Escopo desta tradução

O trabalho inclui:

- documentação em Markdown;
- perguntas e respostas;
- implementações C#;
- comentários e explicações técnicas.

Os arquivos PDF existentes no projeto original não foram incorporados nem traduzidos nesta atualização.

## Acompanhamento

O histórico detalhado da atualização e dos ajustes técnicos está registrado no [`ROADMAP.md`](./ROADMAP.md).

## Créditos

O conteúdo original é de autoria de [StefanTheCode](https://github.com/StefanTheCode). Esta versão em português foi iniciada e é mantida por [Rodrigo Oliveira](https://github.com/rodri-oliveira-dev), com autorização para tradução do material original.
