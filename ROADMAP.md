# Roteiro de atualização

Este documento acompanha a atualização da tradução brasileira com base no repositório original [`StefanTheCode/dotnet_interview_questions`](https://github.com/StefanTheCode/dotnet_interview_questions).

## Escopo

- Incorporar os 130 conteúdos presentes no projeto original.
- Traduzir documentação, enunciados, explicações e comentários para português do Brasil.
- Manter nomes de classes, métodos, variáveis e APIs em inglês, seguindo as convenções do ecossistema .NET.
- Preservar e revisar as 50 perguntas já traduzidas.
- Não incorporar nem traduzir os arquivos PDF da pasta `Docs` nesta fase.
- Manter este repositório como uma iniciativa independente; não há previsão de envio das alterações ao repositório original neste momento.

## Etapas

- [x] Criar a solução e os projetos `Arrays`, `Lists` e `Trees` em .NET 10.
- [x] Adicionar configuração de arquivos ignorados pelo Git.
- [x] Adicionar validação automática da solução com GitHub Actions.
- [x] Reorganizar as 50 perguntas existentes em `Interview Questions/README.md`.
- [x] Traduzir e adaptar o novo README principal.
- [x] Incorporar e revisar as 20 questões de arrays.
  - [x] Questões 1 a 10.
  - [x] Questões 11 a 20.
- [x] Incorporar e revisar as 20 questões de listas.
  - [x] Questões 1 a 10.
  - [x] Questões 11 a 20.
- [x] Incorporar e revisar as 20 questões de árvores.
  - [x] Questões 1 a 10.
  - [x] Questões 11 a 20.
- [x] Incorporar e revisar as questões gerais de SQL, do número 51 ao 70.
  - [x] Questões 51 a 60.
  - [x] Questões 61 a 70.
- [ ] Executar revisão técnica, ortográfica e de consistência terminológica final.
- [x] Validar a compilação da solução no estado atual.

## Ajustes técnicos realizados no módulo de arrays

### Questões 1 a 10

- Numeração alinhada ao índice do README principal.
- Validação de argumentos nulos e de entradas vazias quando necessário.
- Ordenação realizada sobre cópias para não modificar silenciosamente os arrays recebidos.
- Rotação corrigida para arrays vazios e valores negativos de `k`.
- Cálculos intermediários da fórmula da soma promovidos para `long`.
- Interseção com `HashSet` ajustada para produzir uma ordem determinística.
- Documentação corrigida para diferenciar array jagged de array multidimensional.

### Questões 11 a 20

- Pares duplicados removidos e somas protegidas contra overflow.
- Busca binária passou a validar a ordenação crescente exigida pelo algoritmo.
- Maior soma de subarray passou a usar `long` e prefixos de soma na versão LINQ.
- Complexidade da seleção aleatória com rejeição corrigida para O(n log n) esperado.
- `Random` tornou-se injetável para testes reproduzíveis.
- Redimensionamento passou a rejeitar tamanhos negativos.
- Nulabilidade e critérios de desempate corrigidos na ordenação de objetos.
- Questão conceitual de complexidade criada como documento independente.

## Ajustes técnicos realizados no módulo de listas

### Questões 1 a 10

- Todos os construtores passaram a validar argumentos nulos e usar cópias defensivas.
- Remoção de duplicados por ordenação passou a tratar listas vazias.
- Segundo maior valor passou a aceitar `int.MinValue` como resultado válido.
- Bubble sort documentado com melhor caso O(n) devido à interrupção antecipada.
- Interseções com `HashSet` passaram a preservar uma ordem determinística.
- Complexidade da mesclagem com ordenação corrigida para O(n log n + m log m).
- Sequência de número ausente passou a validar intervalo e duplicidades.
- Soma esperada passou a usar `long` nos cálculos intermediários.
- Rotação passou a tratar listas vazias e valores negativos de `k`.
- Embaralhamento ingênuo corrigido para O(n log n) esperado e `Random` tornou-se injetável.

### Questões 11 a 20

- Operações mutáveis trabalham sobre cópias internas e documentam seus efeitos.
- Pares duplicados foram eliminados e os resultados tornados determinísticos.
- Somas utilizam `long` para evitar overflow intermediário.
- Abordagem de dois ponteiros documentada com O(n) de espaço devido à cópia ordenada.
- Tamanho dos blocos é validado antes da divisão da lista.
- Listas aninhadas são copiadas profundamente e validadas contra elementos nulos.
- Complexidade do achatamento usa N como o total de elementos internos.
- Maior soma contígua rejeita entrada vazia e usa prefixos na abordagem LINQ.
- Igualdade sensível à ordem e igualdade por conteúdo foram diferenciadas explicitamente.

## Ajustes técnicos realizados no módulo de árvores

### Questões 1 a 10

- Modelo compartilhado `TreeNode` documentado como estrutura mínima e acíclica.
- Espaço de algoritmos BFS expresso em função da largura máxima `w`.
- Classes exclusivamente consultivas usam campos somente de leitura.
- Métodos auxiliares sem dependência de estado foram transformados em estáticos.
- Serialização usada na comparação de árvores foi reescrita com `StringBuilder`.
- Marcadores de nós nulos preservam a estrutura durante a serialização.
- Validação de BST usa limites `long` e rejeita valores duplicados explicitamente.
- Busca em BST documenta a pré-condição de árvore válida.
- Inserção iterativa foi reescrita sem supressões desnecessárias de nulabilidade.
- Inversão e inserção documentam que modificam a árvore recebida.

### Questões 11 a 20

- Busca de mínimo e máximo documenta a pré-condição de BST válida.
- LCA verifica a existência dos dois valores antes de retornar um ancestral.
- Diâmetro é medido explicitamente pela quantidade de arestas.
- Espaço da verificação iterativa de simetria é expresso em função de `w`.
- Serialização e desserialização rejeitam payloads vazios, truncados ou excedentes.
- Marcadores de nós nulos e cultura invariável tornam o formato determinístico.
- Somas de caminhos usam `long` para evitar overflow intermediário.
- Complexidades de caminhos consideram o tamanho efetivo da saída.
- Busca pelo k-ésimo menor rejeita valores de `k` não positivos.
- Construção de hierarquias valida IDs duplicados, pais ausentes, raízes múltiplas, ciclos e componentes desconectados.
- Filhos de `OrgNode` são expostos como coleção somente leitura.
- `Trees/Program.cs` contém exemplos representativos do módulo completo.

## Ajustes técnicos realizados no bloco SQL

### Questões 51 a 60

- O bloco foi separado em `Interview Questions/SQL.md` para preservar o documento original com as 50 perguntas .NET/C#.
- A numeração duplicada das perguntas 57 e 58 no upstream foi corrigida.
- Os exemplos foram contextualizados principalmente para SQL Server/T-SQL.
- Diferenças de comportamento entre SGBDs foram indicadas quando relevantes.
- Chave primária foi separada da decisão física de usar índice clustered.
- Tratamento de `NULL` em restrições `UNIQUE` foi documentado como dependente do SGBD.
- Chaves estrangeiras passaram a discutir ações referenciais e a ausência de criação automática de índice na coluna filha no SQL Server.
- Normalização passou a incluir BCNF, 4FN, 5FN e o uso deliberado de desnormalização.
- Índices clustered e nonclustered foram explicados pelos níveis folha e localizadores de linha.
- Transações receberam exemplo com `TRY`, `CATCH`, `XACT_STATE` e `XACT_ABORT`.
- `DELETE`, `TRUNCATE TABLE` e `DROP TABLE` foram comparados sem afirmações universais incorretas sobre rollback.
- Funções de janela passaram a explicar partição, ordenação, frame e desempates determinísticos.
- CTEs foram documentadas como não materializadas automaticamente no SQL Server.
- Stored procedures deixaram de ser apresentadas como automaticamente mais rápidas ou simplesmente pré-compiladas.

### Questões 61 a 70

- Prevenção de SQL injection passou a priorizar parametrização, privilégio mínimo e tipos explícitos, sem apresentar ORM ou stored procedure como proteção automática.
- `EXISTS` e `IN` foram explicados semanticamente, sem regra absoluta de desempenho; o risco de `NOT IN` com `NULL` foi destacado.
- Diagnóstico de consultas passou a incluir Query Store, leituras lógicas, CPU, waits, estatísticas, cardinalidade e regressões de plano.
- Planos estimados e reais foram diferenciados, incluindo os riscos de executar comandos para obter o plano real.
- Scans e recomendações de missing index deixaram de ser classificados automaticamente como problemas.
- Agregações diferenciam `COUNT(*)` de `COUNT(coluna)` e posicionam corretamente `WHERE` e `HAVING`.
- Chave composta foi diferenciada de índice composto e comparada com o uso de chave substituta mais restrição `UNIQUE`.
- View materializada foi contextualizada por SGBD; no SQL Server, foi apresentada como indexed view, com custos e restrições de manutenção.
- Tratamento de `NULL` passou a explicar lógica de três valores, propagação e diferenças entre `COALESCE` e `ISNULL`.
- Funções escalares, inline TVFs e multi-statement TVFs foram separadas, incluindo as limitações do scalar UDF inlining.
- O exemplo multitenant fictício foi substituído por chaves contendo `TenantId`, Row-Level Security e `SESSION_CONTEXT`.
- O desenho multitenant passou a considerar pooling, backups, restore, noisy neighbors, migrations e isolamento fora do banco.

## Validação automatizada

O workflow `.github/workflows/dotnet-build.yml` restaura as dependências e compila `InterviewQuestions.sln` em modo Release usando o SDK do .NET 10.

A solução é validada novamente após cada bloco incorporado. Alterações exclusivamente documentais também passam pelo mesmo workflow para garantir que a branch permaneça íntegra.

## Próxima etapa

Executar a revisão técnica, ortográfica e de consistência terminológica final em todo o repositório. Depois dessa revisão, avaliar se o pull request deve ser marcado como pronto para revisão.

## Convenções de tradução

- Termos técnicos amplamente usados podem manter o termo original entre parênteses na primeira ocorrência.
- Identificadores de código não serão traduzidos.
- Os comentários devem explicar a abordagem, sua complexidade de tempo e espaço e os principais casos extremos.
- Ajustes técnicos no código original devem ser documentados no pull request correspondente.
