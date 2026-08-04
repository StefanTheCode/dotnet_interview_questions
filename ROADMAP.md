# Roteiro de atualização

Este documento acompanha a atualização da tradução brasileira com base no repositório original [`StefanTheCode/dotnet_interview_questions`](https://github.com/StefanTheCode/dotnet_interview_questions).

## Escopo

- Incorporar as 130 perguntas atualmente presentes no projeto original.
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
- [ ] Incorporar e revisar as 20 questões de árvores.
  - [x] Questões 1 a 10.
  - [ ] Questões 11 a 20.
- [ ] Incorporar e revisar as questões gerais de SQL, do número 51 ao 70.
- [ ] Executar revisão técnica, ortográfica e de consistência terminológica.
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

## Ajustes técnicos realizados nas questões 1 a 10 de árvores

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
- `Trees/Program.cs` contém exemplos representativos das dez questões.

## Validação automatizada

O workflow `.github/workflows/dotnet-build.yml` restaura as dependências e compila `InterviewQuestions.sln` em modo Release usando o SDK do .NET 10.

A solução é validada novamente após cada bloco incorporado.

## Próxima etapa

Incorporar as questões 11 a 20 do módulo de árvores, mantendo o mesmo padrão de tradução, revisão técnica, documentação e validação automatizada.

## Convenções de tradução

- Termos técnicos amplamente usados podem manter o termo original entre parênteses na primeira ocorrência.
- Identificadores de código não serão traduzidos.
- Os comentários devem explicar a abordagem, sua complexidade de tempo e espaço e os principais casos extremos.
- Ajustes técnicos no código original devem ser documentados no pull request correspondente.
