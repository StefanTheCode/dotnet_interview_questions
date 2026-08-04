# Questão 20 — Complexidade das operações com arrays

Arrays armazenam elementos em posições indexadas e possuem tamanho fixo. Essa estrutura oferece acesso direto muito eficiente, mas torna inserções, remoções e redimensionamentos mais custosos.

## Complexidades principais

Considere `n` como a quantidade de elementos do array.

| Operação | Tempo | Espaço adicional | Observação |
|---|---:|---:|---|
| Obter `Length` | O(1) | O(1) | O tamanho faz parte dos metadados do array. |
| Acessar ou alterar por índice | O(1) | O(1) | Exemplo: `values[index]`. |
| Percorrer todos os elementos | O(n) | O(1) | O espaço pode crescer quando o processamento produz outra coleção. |
| Buscar valor em array não ordenado | O(n) | O(1) | No pior caso, todos os elementos são examinados. |
| Busca binária em array ordenado | O(log n) | O(1) iterativa | A versão recursiva usa O(log n) de pilha. |
| Encontrar mínimo ou máximo | O(n) | O(1) | Sem informação auxiliar, todos os valores precisam ser comparados. |
| Clonar o array | O(n) | O(n) | Todos os elementos são copiados. |
| Redimensionar | O(n) | O(n) | Um novo array precisa ser alocado e preenchido. |
| Inserir no início ou no meio | O(n) | O(n) | Arrays não crescem; normalmente é necessário criar outro array e deslocar elementos. |
| Remover do início ou do meio | O(n) | O(n) | Também exige cópia ou deslocamento para outra estrutura. |
| Ordenar por comparação | O(n log n) | Depende do algoritmo | A complexidade exata de espaço depende da implementação escolhida. |
| Inverter in-place | O(n) | O(1) | A técnica de dois ponteiros realiza aproximadamente `n / 2` trocas. |

## Por que o acesso por índice é O(1)?

O runtime consegue calcular diretamente o endereço da posição desejada a partir da referência inicial do array, do tamanho de cada elemento e do índice informado. Não é necessário percorrer os elementos anteriores.

Isso não significa que todos os acessos terão exatamente o mesmo tempo físico. Cache da CPU, localização dos dados na memória e custo do tipo armazenado influenciam a duração real, mas não alteram a classificação assintótica O(1).

## Inserção e remoção

Um array não possui uma operação de inserção que aumente seu tamanho. Para inserir um elemento, geralmente é necessário:

1. criar um novo array;
2. copiar os elementos anteriores à posição;
3. inserir o novo valor;
4. copiar os elementos restantes.

O mesmo raciocínio vale para remoções. Quando inserções e remoções frequentes fazem parte do requisito, `List<T>` costuma ser mais adequada, embora inserções no início ou no meio de uma lista também possam exigir deslocamentos O(n).

## Array ordenado: benefício e custo

Manter os elementos ordenados permite usar busca binária com O(log n), mas existe um custo para obter ou preservar essa ordenação:

- ordenar inicialmente costuma custar O(n log n);
- inserir um novo valor na posição correta pode exigir O(n) para deslocar elementos;
- modificar valores pode invalidar a ordenação esperada.

Em uma entrevista, é importante explicar essa troca: a busca fica mais rápida, mas a manutenção da estrutura ordenada pode ficar mais cara.

## Casos extremos para mencionar

- array vazio;
- array com um único elemento;
- índice negativo ou maior que o último índice válido;
- valores duplicados;
- overflow ao somar ou multiplicar muitos valores `int`;
- mutação inesperada quando um método ordena ou altera o array recebido;
- consumo de memória ao criar cópias para preservar a entrada original.

## Resposta resumida para entrevista

> Arrays oferecem acesso por índice em O(1) e percurso ou busca linear em O(n). Como possuem tamanho fixo, redimensionamentos, inserções e remoções normalmente exigem a criação de outro array e custam O(n). Em arrays ordenados, a busca binária reduz a pesquisa para O(log n), mas ordenar ou manter a ordem também possui custo.
