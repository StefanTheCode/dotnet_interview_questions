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
- [ ] Incorporar e revisar as 20 questões de listas.
  - [x] Questões 1 a 10.
  - [ ] Questões 11 a 20.
- [ ] Incorporar e revisar as 20 questões de árvores.
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

- Pares duplicados removidos em todas as abordagens e somas protegidas contra overflow.
- Busca binária passou a validar a ordenação crescente exigida pelo algoritmo.
- Maior soma de subarray passou a usar `long` e a versão LINQ foi corrigida com prefixos de soma.
- Complexidade da seleção aleatória com rejeição corrigida para O(n log n) esperado.
- `Random` pode ser injetado para produzir testes e exemplos reproduzíveis.
- Redimensionamento passou a rejeitar tamanhos negativos explicitamente.
- Nulabilidade e critérios de desempate corrigidos na ordenação de objetos personalizados.
- Questão conceitual de complexidade criada como documento independente.
- `Program.cs` atualizado com exemplos executáveis do módulo completo.

## Ajustes técnicos realizados nas questões 1 a 10 de listas

- Todos os construtores passaram a validar argumentos nulos e usar cópias defensivas.
- Remoção de duplicados por ordenação passou a tratar listas vazias.
- Segundo maior valor passou a usar estado anulável, permitindo que `int.MinValue` seja um resultado válido.
- Bubble sort documentado com melhor caso O(n) devido à interrupção antecipada.
- Interseções com `HashSet` passaram a preservar uma ordem determinística.
- Complexidade da mesclagem que ordena as entradas corrigida para O(n log n + m log m).
- Sequência de número ausente passou a validar intervalo e duplicidades.
- Soma esperada do número ausente passou a usar `long` nos cálculos intermediários.
- Rotação passou a tratar listas vazias e valores negativos de `k`.
- Embaralhamento ingênuo documentado como O(n log n) esperado e `Random` tornou-se injetável.
- `Lists/Program.cs` atualizado com exemplos executáveis do primeiro bloco.

## Validação automatizada

O workflow `.github/workflows/dotnet-build.yml` restaura as dependências e compila `InterviewQuestions.sln` em modo Release usando o SDK do .NET 10.

A execução nº 31 foi concluída com sucesso após a inclusão das questões 1 a 10 de listas. As etapas de checkout, configuração do SDK, restauração das dependências e compilação da solução foram aprovadas.

## Próxima etapa

Incorporar as questões 11 a 20 do módulo de listas, mantendo o mesmo padrão de tradução, revisão técnica e documentação.

## Convenções de tradução

- Termos técnicos amplamente usados podem manter o termo original entre parênteses na primeira ocorrência.
- Identificadores de código não serão traduzidos.
- Os comentários devem explicar a abordagem, sua complexidade de tempo e espaço e os principais casos extremos.
- Ajustes técnicos no código original devem ser documentados no pull request correspondente.
