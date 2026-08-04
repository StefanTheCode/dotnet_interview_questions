# Perguntas de entrevista sobre SQL — questões 51 a 60

Este documento complementa as [50 perguntas gerais de .NET e C#](./README.md) com o primeiro bloco de perguntas sobre bancos de dados relacionais.

> Os exemplos usam principalmente **SQL Server e T-SQL**. Conceitos como chaves, normalização, transações e junções são amplamente aplicáveis, mas detalhes de sintaxe, índices, valores nulos e comandos DDL podem variar entre SGBDs.

---

## 51. Qual é a diferença entre `INNER JOIN`, `LEFT JOIN`, `RIGHT JOIN` e `FULL OUTER JOIN`?

**Resposta:**

As junções combinam linhas de duas fontes de acordo com uma condição, normalmente uma relação entre chave primária e chave estrangeira.

- **`INNER JOIN`** retorna somente as combinações que atendem à condição nos dois lados.
- **`LEFT JOIN`** retorna todas as linhas da fonte à esquerda e, quando houver correspondência, os dados da direita. Sem correspondência, as colunas da direita recebem `NULL`.
- **`RIGHT JOIN`** é o equivalente espelhado do `LEFT JOIN`: preserva todas as linhas da fonte à direita. Em muitos times ele é evitado por legibilidade, pois pode ser reescrito invertendo as tabelas e usando `LEFT JOIN`.
- **`FULL OUTER JOIN`** preserva as linhas dos dois lados, combinando as correspondentes e preenchendo com `NULL` quando não houver par.

Considere:

```sql
CREATE TABLE Customers
(
    Id   INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Orders
(
    Id         INT PRIMARY KEY,
    CustomerId INT NULL,
    Product    NVARCHAR(100) NOT NULL
);
```

Exemplo com `LEFT JOIN`:

```sql
SELECT
    c.Id,
    c.Name,
    o.Product
FROM Customers AS c
LEFT JOIN Orders AS o
    ON o.CustomerId = c.Id;
```

Esse comando também retorna clientes sem pedidos. Um filtro sobre a tabela opcional deve ser colocado com cuidado: adicionar `WHERE o.Product = 'Monitor'` elimina as linhas sem correspondência e pode transformar, na prática, o resultado em algo equivalente a um `INNER JOIN`. Quando a intenção for preservar os clientes, o predicado pode pertencer à cláusula `ON`.

---

## 52. O que é uma chave primária e como ela difere de uma restrição `UNIQUE`?

**Resposta:**

Uma **chave primária** identifica unicamente cada linha da tabela. Ela pode ser formada por uma ou mais colunas e possui estas propriedades:

- seus valores não podem ser `NULL`;
- não pode haver duplicidade;
- uma tabela possui apenas uma restrição de chave primária, embora ela possa ser composta por várias colunas;
- pode ser referenciada por chaves estrangeiras.

Uma restrição **`UNIQUE`** também impede duplicidades, mas representa normalmente uma chave candidata ou uma regra de negócio, como e-mail, CPF ou código externo.

- uma tabela pode possuir várias restrições `UNIQUE`;
- o tratamento de `NULL` varia entre SGBDs;
- também pode envolver várias colunas;
- em SQL Server, tanto `PRIMARY KEY` quanto `UNIQUE` são normalmente implementadas por índices únicos.

```sql
CREATE TABLE Employees
(
    EmployeeId INT           NOT NULL,
    Email      NVARCHAR(320) NOT NULL,
    Document   CHAR(11)      NULL,

    CONSTRAINT PK_Employees
        PRIMARY KEY NONCLUSTERED (EmployeeId),

    CONSTRAINT UQ_Employees_Email
        UNIQUE (Email)
);
```

A chave primária não precisa obrigatoriamente ser o índice clustered. Essa escolha é física e específica do SGBD; não faz parte da definição lógica de chave primária.

---

## 53. O que são chaves estrangeiras e como elas garantem integridade referencial?

**Resposta:**

Uma **chave estrangeira** declara que um valor da tabela filha deve corresponder a uma chave válida da tabela pai, geralmente uma chave primária ou uma chave candidata protegida por `UNIQUE`.

```sql
CREATE TABLE Customers
(
    Id   INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Orders
(
    Id         INT PRIMARY KEY,
    CustomerId INT NOT NULL,
    Product    NVARCHAR(100) NOT NULL,

    CONSTRAINT FK_Orders_Customers
        FOREIGN KEY (CustomerId)
        REFERENCES Customers (Id)
);
```

A restrição impede, por exemplo:

- inserir um pedido para um cliente inexistente;
- atualizar `CustomerId` para um valor sem pai correspondente;
- remover um cliente ainda referenciado, salvo quando uma ação referencial permitir isso.

Ações comuns incluem:

- `NO ACTION` ou `RESTRICT`: bloqueia a alteração que quebraria a referência;
- `ON DELETE CASCADE`: remove também as linhas filhas;
- `ON DELETE SET NULL`: mantém a linha filha e remove a referência, desde que a coluna aceite `NULL`;
- `SET DEFAULT`: aplica o valor padrão, quando suportado e válido.

Essas ações devem ser escolhidas pelo significado do domínio. `CASCADE` não deve ser ativado apenas por conveniência. No SQL Server, criar uma chave estrangeira não cria automaticamente um índice na coluna filha; esse índice costuma ser importante para junções e para validar exclusões ou atualizações na tabela pai.

---

## 54. O que é normalização e quais são as principais formas normais?

**Resposta:**

**Normalização** é o processo de modelar tabelas e dependências para reduzir redundância e evitar anomalias de inserção, atualização e exclusão.

### Primeira Forma Normal — 1FN

- cada coluna armazena valores atômicos no contexto do modelo;
- não existem grupos repetidos na mesma linha;
- cada linha pode ser identificada de forma consistente.

Evite, por exemplo, armazenar vários produtos em uma única coluna separada por vírgulas.

### Segunda Forma Normal — 2FN

- a tabela está na 1FN;
- todo atributo não-chave depende da chave completa;
- elimina dependências parciais, problema relevante principalmente em chaves compostas.

### Terceira Forma Normal — 3FN

- a tabela está na 2FN;
- atributos não-chave não dependem de outros atributos não-chave;
- elimina dependências transitivas.

### Forma Normal de Boyce-Codd — BCNF

É uma versão mais rigorosa da 3FN: todo determinante deve ser uma chave candidata. Ela trata alguns cenários com múltiplas chaves candidatas que ainda podem apresentar redundância na 3FN.

### Formas superiores

- **4FN** trata dependências multivaloradas independentes;
- **5FN** trata dependências de junção e decomposições mais complexas.

Na prática, muitos sistemas transacionais buscam 3FN ou BCNF. A **desnormalização** pode ser deliberada para leitura, analytics ou desempenho, mas deve ser uma decisão medida, documentada e acompanhada de uma estratégia para manter consistência.

---

## 55. Qual é a diferença entre índice clustered e nonclustered?

**Resposta:**

No SQL Server, um índice **clustered** organiza o nível folha do índice com as próprias páginas de dados da tabela. Como os dados só podem estar organizados dessa forma uma vez, uma tabela possui no máximo um índice clustered. Uma tabela sem índice clustered é chamada de **heap**.

Um índice **nonclustered** é uma estrutura separada. Suas folhas contêm as chaves indexadas, colunas incluídas quando configuradas e um localizador para a linha de dados.

```sql
CREATE CLUSTERED INDEX CIX_Orders_CreatedAt_Id
    ON Orders (CreatedAt, Id);

CREATE NONCLUSTERED INDEX IX_Orders_CustomerId
    ON Orders (CustomerId)
    INCLUDE (Status, TotalAmount);
```

### Índice clustered

- adequado quando a chave favorece consultas por intervalo e ordenação;
- influencia os localizadores usados pelos índices nonclustered;
- deve ser escolhido considerando largura, estabilidade, crescimento e padrão de acesso da chave.

### Índice nonclustered

- pode haver vários por tabela;
- pode atender buscas, filtros, junções e ordenações específicas;
- `INCLUDE` permite cobrir uma consulta sem aumentar a chave lógica do índice;
- aumenta custo de armazenamento e de operações de escrita.

Uma chave primária é clustered por padrão em algumas situações do SQL Server, mas isso não é obrigatório. É possível declarar `PRIMARY KEY NONCLUSTERED` e criar o índice clustered em outra chave.

---

## 56. O que são transações e quais são as propriedades ACID?

**Resposta:**

Uma **transação** agrupa operações em uma unidade lógica de trabalho. O objetivo é garantir que alterações relacionadas sejam confirmadas juntas ou desfeitas juntas.

As propriedades **ACID** são:

- **Atomicidade:** todas as operações da transação são aplicadas ou nenhuma é.
- **Consistência:** regras, restrições e invariantes levam o banco de um estado válido para outro estado válido.
- **Isolamento:** transações concorrentes não devem observar estados intermediários incompatíveis com o nível de isolamento escolhido.
- **Durabilidade:** depois do `COMMIT`, as alterações sobrevivem a falhas conforme as garantias do sistema de persistência.

Exemplo em T-SQL:

```sql
SET XACT_ABORT ON;

BEGIN TRY
    BEGIN TRANSACTION;

    UPDATE Accounts
    SET Balance = Balance - 100.00
    WHERE Id = 1;

    UPDATE Accounts
    SET Balance = Balance + 100.00
    WHERE Id = 2;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;

    THROW;
END CATCH;
```

O nível de isolamento define quais fenômenos concorrentes podem ocorrer. Entre os níveis comuns estão `READ UNCOMMITTED`, `READ COMMITTED`, `REPEATABLE READ`, `SNAPSHOT` e `SERIALIZABLE`. Níveis mais fortes oferecem mais isolamento, mas podem elevar bloqueios, contenção ou uso de versionamento.

Transações devem ser curtas: não mantenha uma transação aberta durante chamadas de rede, interação humana ou processamento desnecessário.

---

## 57. Qual é a diferença entre `DELETE`, `TRUNCATE TABLE` e `DROP TABLE`?

**Resposta:**

Os três comandos removem dados ou objetos, mas têm contratos diferentes. Os detalhes abaixo são específicos do SQL Server.

| Característica | `DELETE` | `TRUNCATE TABLE` | `DROP TABLE` |
|---|---|---|---|
| Remove linhas específicas | Sim, com `WHERE` | Não | Não |
| Remove todas as linhas | Sim | Sim | Sim, junto com a tabela |
| Mantém a estrutura da tabela | Sim | Sim | Não |
| Aciona triggers de `DELETE` | Sim | Não | Não se aplica |
| Registro no log | Por alterações de linha | Principalmente desalocação de páginas | Alteração de metadados e desalocação |
| Reinicia `IDENTITY` | Não | Normalmente sim | O objeto deixa de existir |
| Pode participar de transação no SQL Server | Sim | Sim | Sim, respeitadas as limitações do objeto |

```sql
DELETE FROM Employees
WHERE DepartmentId = 10;

TRUNCATE TABLE StagingEmployees;

DROP TABLE ObsoleteEmployees;
```

`TRUNCATE TABLE` costuma usar menos recursos que um `DELETE` sem filtro, mas possui restrições: por exemplo, não pode truncar livremente uma tabela referenciada por determinadas chaves estrangeiras. Antes de usar `DROP`, confirme dependências, permissões, backups e estratégia de recuperação.

Não generalize comportamento de rollback, triggers ou reinicialização de sequência para todos os SGBDs; consulte a documentação da plataforma utilizada.

---

## 58. O que são funções de janela e quando elas devem ser usadas?

**Resposta:**

Funções de janela calculam valores sobre um conjunto de linhas relacionado à linha atual sem agrupar o resultado em uma única linha, como ocorre com `GROUP BY`.

A cláusula `OVER` pode definir:

- `PARTITION BY`: separa o conjunto em partições;
- `ORDER BY`: define a ordem lógica dentro da janela;
- `ROWS` ou `RANGE`: define o frame considerado pela função.

```sql
SELECT
    EmployeeId,
    DepartmentId,
    Salary,
    DENSE_RANK() OVER
    (
        PARTITION BY DepartmentId
        ORDER BY Salary DESC
    ) AS SalaryRank,
    SUM(Salary) OVER
    (
        PARTITION BY DepartmentId
        ORDER BY EmployeeId
        ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW
    ) AS RunningDepartmentTotal
FROM Employees;
```

Casos de uso comuns:

- ranking por grupo com `ROW_NUMBER`, `RANK` ou `DENSE_RANK`;
- totais acumulados e médias móveis;
- comparação com a linha anterior ou seguinte usando `LAG` e `LEAD`;
- identificação de primeiro ou último valor;
- top N por categoria;
- análise de intervalos e séries temporais.

`ROW_NUMBER` sempre gera uma sequência única. `RANK` deixa lacunas após empates, enquanto `DENSE_RANK` não deixa lacunas. Para resultados determinísticos, o `ORDER BY` da janela precisa fornecer um critério de desempate estável.

---

## 59. Como uma CTE funciona e qual é a diferença entre CTE e subconsulta?

**Resposta:**

Uma **Common Table Expression — CTE** é um conjunto de resultados nomeado e temporário, definido com `WITH` e válido para uma única instrução subsequente.

```sql
WITH SalesByCustomer AS
(
    SELECT
        CustomerId,
        SUM(Amount) AS TotalAmount
    FROM Sales
    GROUP BY CustomerId
)
SELECT
    CustomerId,
    TotalAmount
FROM SalesByCustomer
WHERE TotalAmount > 10000.00;
```

### CTE

- torna etapas complexas mais legíveis;
- pode ser referenciada pelo nome dentro da instrução;
- pode ser recursiva, sendo útil para hierarquias e grafos acíclicos controlados;
- no SQL Server, seu resultado não é materializado automaticamente;
- referências repetidas podem provocar nova execução da definição, dependendo do plano.

### Subconsulta

- fica embutida em `SELECT`, `FROM`, `WHERE`, `HAVING` ou outras expressões;
- pode ser mais direta para uma transformação pequena usada apenas uma vez;
- pode ser correlacionada com a consulta externa;
- não oferece, por si só, a mesma sintaxe para recursão.

CTE não é automaticamente mais rápida que subconsulta. O otimizador frequentemente produz planos equivalentes. Quando o resultado precisa ser reutilizado várias vezes, indexado, inspecionado em etapas ou materializado, uma tabela temporária pode ser mais adequada.

---

## 60. Quais são as vantagens e desvantagens de stored procedures?

**Resposta:**

Stored procedures são módulos executáveis armazenados no banco de dados. Elas podem receber parâmetros, executar várias instruções e controlar transações e permissões.

```sql
CREATE OR ALTER PROCEDURE dbo.GetOrdersByCustomer
    @CustomerId INT,
    @FromDate    DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        CustomerId,
        CreatedAt,
        Status,
        TotalAmount
    FROM dbo.Orders
    WHERE CustomerId = @CustomerId
      AND CreatedAt >= @FromDate
    ORDER BY CreatedAt DESC;
END;
```

### Vantagens

- encapsulam operações próximas dos dados;
- permitem conceder `EXECUTE` sem conceder acesso direto irrestrito às tabelas;
- reduzem duplicação quando vários consumidores precisam da mesma operação;
- podem reutilizar planos de execução;
- facilitam operações em lote e transações no servidor;
- podem reduzir tráfego entre aplicação e banco.

### Desvantagens

- aumentam o acoplamento ao dialeto e ao SGBD;
- podem espalhar regras de negócio entre aplicação e banco;
- exigem versionamento, revisão, testes e implantação junto às demais mudanças de schema;
- depuração e observabilidade podem ser mais difíceis;
- reutilização de plano não significa desempenho garantido;
- parâmetros e distribuição de dados podem causar planos inadequados, como em cenários de parameter sniffing;
- stored procedures extensas podem se tornar difíceis de manter.

Stored procedures não são automaticamente mais rápidas por serem “pré-compiladas”. O desempenho depende do plano escolhido, estatísticas, índices, cardinalidade, parâmetros, concorrência e desenho da consulta. Também não substituem consultas parametrizadas: SQL dinâmico dentro de uma procedure ainda deve usar parâmetros e validação apropriada.
