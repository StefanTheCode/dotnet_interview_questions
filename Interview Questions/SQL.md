# Perguntas de entrevista sobre SQL — questões 51 a 70

Este documento complementa as [50 perguntas gerais de .NET e C#](./README.md) com 20 perguntas sobre bancos de dados relacionais.

> Os exemplos usam principalmente **SQL Server e T-SQL**. Conceitos como chaves, normalização, transações, junções e agregações são amplamente aplicáveis, mas sintaxe, índices, valores nulos, materialização e comandos DDL variam entre SGBDs.

---

## 51. Qual é a diferença entre `INNER JOIN`, `LEFT JOIN`, `RIGHT JOIN` e `FULL OUTER JOIN`?

**Resposta:**

As junções combinam linhas de duas fontes de acordo com uma condição.

- **`INNER JOIN`** retorna somente combinações correspondentes nos dois lados.
- **`LEFT JOIN`** preserva todas as linhas da esquerda e preenche com `NULL` as colunas da direita quando não existe correspondência.
- **`RIGHT JOIN`** preserva todas as linhas da direita. Pode ser reescrito invertendo as fontes e usando `LEFT JOIN`, o que frequentemente melhora a legibilidade.
- **`FULL OUTER JOIN`** preserva as linhas dos dois lados, combinando as correspondentes e preenchendo com `NULL` quando não existe par.

```sql
SELECT
    c.Id,
    c.Name,
    o.Product
FROM dbo.Customers AS c
LEFT JOIN dbo.Orders AS o
    ON o.CustomerId = c.Id;
```

Um filtro aplicado em `WHERE` sobre a tabela opcional pode eliminar as linhas sem correspondência:

```sql
-- Na prática, elimina clientes sem pedidos.
WHERE o.Product = N'Monitor';
```

Quando a intenção é preservar todas as linhas da esquerda, avalie se o predicado deve ficar na cláusula `ON`.

---

## 52. O que é uma chave primária e como ela difere de uma restrição `UNIQUE`?

**Resposta:**

Uma **chave primária** identifica unicamente cada linha:

- não aceita `NULL`;
- não aceita duplicidades;
- pode ser simples ou composta;
- existe apenas uma restrição de chave primária por tabela;
- pode ser referenciada por chaves estrangeiras.

Uma restrição **`UNIQUE`** também impede duplicidades, mas normalmente representa uma chave candidata ou regra de negócio, como e-mail ou código externo.

- uma tabela pode ter várias restrições `UNIQUE`;
- pode envolver várias colunas;
- o comportamento de `NULL` varia entre SGBDs;
- no SQL Server, `PRIMARY KEY` e `UNIQUE` são normalmente apoiadas por índices únicos.

```sql
CREATE TABLE dbo.Employees
(
    EmployeeId INT           NOT NULL,
    Email      NVARCHAR(320) NOT NULL,

    CONSTRAINT PK_Employees
        PRIMARY KEY NONCLUSTERED (EmployeeId),

    CONSTRAINT UQ_Employees_Email
        UNIQUE (Email)
);
```

A chave primária não precisa ser o índice clustered. Essa é uma decisão física de indexação, não parte da definição lógica da chave.

---

## 53. O que são chaves estrangeiras e como elas garantem integridade referencial?

**Resposta:**

Uma **chave estrangeira** exige que um valor da tabela filha corresponda a uma chave válida da tabela pai, salvo quando a coluna aceita `NULL` e o valor armazenado é nulo.

```sql
CREATE TABLE dbo.Orders
(
    Id         INT PRIMARY KEY,
    CustomerId INT NOT NULL,

    CONSTRAINT FK_Orders_Customers
        FOREIGN KEY (CustomerId)
        REFERENCES dbo.Customers (Id)
);
```

A restrição impede referências órfãs durante inserções, atualizações e exclusões. Ações referenciais comuns incluem:

- `NO ACTION` ou `RESTRICT`;
- `ON DELETE CASCADE`;
- `ON DELETE SET NULL`;
- `SET DEFAULT`, quando suportado.

Essas ações devem refletir o domínio. `CASCADE` não deve ser usado apenas por conveniência.

No SQL Server, criar uma chave estrangeira não cria automaticamente um índice na coluna filha. Esse índice costuma ajudar junções e a verificação de alterações na tabela pai, mas deve ser avaliado de acordo com a carga.

---

## 54. O que é normalização e quais são as principais formas normais?

**Resposta:**

**Normalização** organiza tabelas e dependências para reduzir redundância e evitar anomalias de inserção, atualização e exclusão.

- **1FN:** valores atômicos no contexto do modelo e ausência de grupos repetidos.
- **2FN:** está na 1FN e cada atributo não-chave depende da chave completa; elimina dependências parciais.
- **3FN:** está na 2FN e não existem dependências transitivas entre atributos não-chave.
- **BCNF:** todo determinante é uma chave candidata.
- **4FN:** trata dependências multivaloradas independentes.
- **5FN:** trata dependências de junção e decomposições mais complexas.

Muitos sistemas transacionais buscam 3FN ou BCNF. A **desnormalização** pode ser deliberada para leitura, analytics ou desempenho, mas precisa ser medida, documentada e acompanhada de uma estratégia de consistência.

---

## 55. Qual é a diferença entre índice clustered e nonclustered?

**Resposta:**

No SQL Server, um índice **clustered** organiza o nível folha com as próprias páginas de dados. Uma tabela possui no máximo um índice clustered; sem ele, é uma **heap**.

Um índice **nonclustered** é uma estrutura separada. Suas folhas contêm as chaves, colunas incluídas e um localizador para a linha de dados.

```sql
CREATE CLUSTERED INDEX CIX_Orders_CreatedAt_Id
    ON dbo.Orders (CreatedAt, Id);

CREATE NONCLUSTERED INDEX IX_Orders_CustomerId
    ON dbo.Orders (CustomerId)
    INCLUDE (Status, TotalAmount);
```

Índices podem acelerar filtros, junções, ordenações e agregações, mas aumentam armazenamento e custo de `INSERT`, `UPDATE` e `DELETE`. A ordem das colunas de um índice composto importa, e `INCLUDE` pode cobrir consultas sem aumentar a chave lógica.

---

## 56. O que são transações e quais são as propriedades ACID?

**Resposta:**

Uma **transação** agrupa operações em uma unidade lógica de trabalho.

- **Atomicidade:** todas as operações são aplicadas ou nenhuma é.
- **Consistência:** restrições e invariantes levam o banco de um estado válido a outro.
- **Isolamento:** a concorrência respeita as garantias do nível de isolamento escolhido.
- **Durabilidade:** alterações confirmadas sobrevivem a falhas conforme as garantias do sistema.

```sql
SET XACT_ABORT ON;

BEGIN TRY
    BEGIN TRANSACTION;

    UPDATE dbo.Accounts
    SET Balance = Balance - 100.00
    WHERE Id = 1;

    UPDATE dbo.Accounts
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

Entre os níveis comuns estão `READ UNCOMMITTED`, `READ COMMITTED`, `REPEATABLE READ`, `SNAPSHOT` e `SERIALIZABLE`. Transações devem ser curtas para reduzir bloqueios, contenção e crescimento desnecessário do log ou do version store.

---

## 57. Qual é a diferença entre `DELETE`, `TRUNCATE TABLE` e `DROP TABLE`?

**Resposta:**

Os detalhes abaixo consideram SQL Server.

| Característica | `DELETE` | `TRUNCATE TABLE` | `DROP TABLE` |
|---|---|---|---|
| Remove linhas específicas | Sim, com `WHERE` | Não | Não |
| Remove todas as linhas | Sim | Sim | Sim, junto com a tabela |
| Mantém a estrutura | Sim | Sim | Não |
| Aciona triggers de `DELETE` | Sim | Não | Não se aplica |
| Registro principal | Alterações de linha | Desalocação de páginas | Metadados e desalocação |
| Reinicia `IDENTITY` | Não | Normalmente sim | O objeto deixa de existir |
| Pode participar de transação | Sim | Sim | Sim, respeitadas limitações |

```sql
DELETE FROM dbo.Employees
WHERE DepartmentId = 10;

TRUNCATE TABLE dbo.StagingEmployees;

DROP TABLE dbo.ObsoleteEmployees;
```

`TRUNCATE TABLE` possui restrições, incluindo relações com determinadas chaves estrangeiras. Comportamento transacional, triggers e sequências varia entre SGBDs.

---

## 58. O que são funções de janela e quando elas devem ser usadas?

**Resposta:**

Funções de janela calculam valores sobre linhas relacionadas à linha atual sem reduzir o resultado como um `GROUP BY`.

A cláusula `OVER` pode definir:

- `PARTITION BY`;
- `ORDER BY`;
- frames com `ROWS` ou `RANGE`.

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
    ) AS RunningTotal
FROM dbo.Employees;
```

Casos de uso incluem ranking, totais acumulados, médias móveis, top N por grupo e comparações com `LAG` e `LEAD`.

`ROW_NUMBER` não representa empate; `RANK` deixa lacunas após empates; `DENSE_RANK` não deixa lacunas. Para resultado determinístico, o `ORDER BY` da janela precisa de desempate estável.

---

## 59. Como uma CTE funciona e qual é a diferença entre CTE e subconsulta?

**Resposta:**

Uma **Common Table Expression — CTE** é um resultado nomeado, definido com `WITH`, válido para uma única instrução subsequente.

```sql
WITH SalesByCustomer AS
(
    SELECT
        CustomerId,
        SUM(Amount) AS TotalAmount
    FROM dbo.Sales
    GROUP BY CustomerId
)
SELECT CustomerId, TotalAmount
FROM SalesByCustomer
WHERE TotalAmount > 10000.00;
```

### CTE

- melhora a legibilidade de etapas complexas;
- pode ser recursiva;
- no SQL Server, não é materializada automaticamente;
- referências repetidas podem provocar nova execução da definição.

### Subconsulta

- fica embutida em `SELECT`, `FROM`, `WHERE`, `HAVING` ou outra expressão;
- pode ser mais direta quando usada uma única vez;
- pode ser correlacionada com a consulta externa.

CTE não é automaticamente mais rápida. Quando o resultado precisa ser reutilizado, indexado ou inspecionado em etapas, uma tabela temporária pode ser mais adequada.

---

## 60. Quais são as vantagens e desvantagens de stored procedures?

**Resposta:**

Stored procedures são módulos executáveis armazenados no banco.

```sql
CREATE OR ALTER PROCEDURE dbo.GetOrdersByCustomer
    @CustomerId INT,
    @FromDate    DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, CustomerId, CreatedAt, Status, TotalAmount
    FROM dbo.Orders
    WHERE CustomerId = @CustomerId
      AND CreatedAt >= @FromDate
    ORDER BY CreatedAt DESC;
END;
```

### Vantagens

- encapsulam operações próximas dos dados;
- permitem conceder `EXECUTE` sem liberar acesso irrestrito às tabelas;
- podem reduzir duplicação e tráfego entre aplicação e banco;
- permitem operações em lote e controle transacional no servidor;
- podem reutilizar planos de execução.

### Desvantagens

- aumentam o acoplamento ao SGBD;
- podem espalhar regras de negócio entre aplicação e banco;
- exigem versionamento, revisão, testes e implantação;
- podem dificultar depuração e observabilidade;
- estão sujeitas a planos inadequados, estatísticas desatualizadas e parameter sniffing.

Stored procedures não são automaticamente mais rápidas por serem “pré-compiladas”. SQL dinâmico dentro delas ainda precisa ser parametrizado.

---

## 61. Como detectar e prevenir SQL injection?

**Resposta:**

SQL injection ocorre quando dados externos são interpretados como parte da estrutura do comando SQL. A defesa principal é **separar código de dados**.

### Medidas preventivas

- usar consultas parametrizadas ou prepared statements;
- evitar concatenação ou interpolação direta em SQL;
- usar tipos e tamanhos de parâmetros coerentes com as colunas;
- aplicar privilégio mínimo à conta da aplicação;
- permitir apenas operações e objetos necessários;
- validar entradas segundo regras de domínio;
- restringir SQL dinâmico e parametrizá-lo com `sp_executesql`;
- manter logs, alertas e auditoria sem registrar segredos ou dados sensíveis;
- testar endpoints e consultas com análise estática, testes automatizados e ferramentas de segurança.

Exemplo inseguro:

```csharp
string sql =
    $"SELECT Id FROM dbo.Users WHERE Username = '{username}'";
```

Exemplo parametrizado:

```csharp
const string sql = """
    SELECT Id, Username
    FROM dbo.Users
    WHERE Username = @Username;
    """;

await using var command = new SqlCommand(sql, connection);
command.Parameters.Add("@Username", SqlDbType.NVarChar, 100).Value = username;
```

No EF Core, LINQ normalmente gera parâmetros. `FromSqlInterpolated` e a forma interpolada de `FromSql` parametrizam os valores inseridos, mas `FromSqlRaw` exige cuidado explícito. ORMs não tornam automaticamente seguro qualquer SQL construído manualmente.

Stored procedures também não impedem injection quando montam SQL dinâmico por concatenação.

---

## 62. Qual é a diferença entre `EXISTS` e `IN`?

**Resposta:**

Os dois podem expressar testes de associação, e o otimizador frequentemente transforma consultas equivalentes em planos semelhantes.

```sql
SELECT c.Id, c.Name
FROM dbo.Customers AS c
WHERE EXISTS
(
    SELECT 1
    FROM dbo.Orders AS o
    WHERE o.CustomerId = c.Id
);
```

```sql
SELECT c.Id, c.Name
FROM dbo.Customers AS c
WHERE c.Id IN
(
    SELECT o.CustomerId
    FROM dbo.Orders AS o
);
```

- **`EXISTS`** testa se a subconsulta produz pelo menos uma linha. É natural para subconsultas correlacionadas e semijoins.
- **`IN`** compara uma expressão com um conjunto de valores. É natural para listas pequenas ou subconsultas que retornam uma única coluna.
- não assuma que um deles é sempre mais rápido; compare planos, cardinalidade, índices e métricas reais.

A diferença crítica aparece com negação e `NULL`:

```sql
-- Pode retornar nenhum resultado se a subconsulta contiver NULL.
WHERE c.Id NOT IN (SELECT o.CustomerId FROM dbo.Orders AS o);
```

Por causa da lógica de três valores, `NOT IN` com `NULL` pode resultar em `UNKNOWN`. `NOT EXISTS` costuma expressar o anti-join com maior segurança:

```sql
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Orders AS o
    WHERE o.CustomerId = c.Id
);
```

---

## 63. Como os índices funcionam e como identificar consultas lentas?

**Resposta:**

Índices são estruturas auxiliares que reduzem o trabalho necessário para localizar, ordenar ou agregar dados. Em rowstore, árvores B+ são comuns; outros formatos incluem columnstore, índices filtrados, espaciais e full-text.

Um índice adequado depende de:

- predicados de igualdade e intervalo;
- colunas de junção;
- ordenação e agrupamento;
- seletividade e distribuição dos valores;
- ordem das colunas da chave;
- colunas necessárias para cobrir a consulta;
- custo adicional de escrita, armazenamento e manutenção.

Para investigar lentidão no SQL Server:

1. confirme duração, CPU, leituras lógicas, gravações, bloqueios e frequência;
2. use Query Store para histórico, regressões e variação de planos;
3. capture o plano real quando for seguro executar a consulta;
4. compare linhas estimadas e reais;
5. procure scans caros, lookups repetidos, sorts e hashes com spill, conversões implícitas, filtros não sargable e estimativas incorretas;
6. verifique estatísticas, índices, parâmetros, concorrência e waits;
7. teste a alteração com uma carga representativa.

```sql
SET STATISTICS IO ON;
SET STATISTICS TIME ON;

SELECT Id, CustomerId, CreatedAt
FROM dbo.Orders
WHERE CustomerId = 42
  AND CreatedAt >= '2026-01-01';
```

Um scan não é necessariamente ruim: ele pode ser a escolha correta quando grande parte da tabela precisa ser lida. Sugestões de “missing index” são pistas, não ordens; podem ignorar custos de escrita e sobreposição com índices existentes.

---

## 64. Para que servem `EXPLAIN` e os planos de execução?

**Resposta:**

O plano de execução mostra os operadores escolhidos pelo otimizador para acessar e combinar os dados.

- **Plano estimado:** compila a consulta sem executá-la e mostra estimativas.
- **Plano real:** executa a consulta e acrescenta métricas observadas, como quantidade real de linhas e, conforme a ferramenta, tempo e leituras por operador.

No SQL Server, o plano pode ser obtido pelo SSMS, `SET SHOWPLAN_XML`, `SET STATISTICS XML`, DMVs ou Query Store. PostgreSQL usa `EXPLAIN` e `EXPLAIN ANALYZE`; MySQL também possui `EXPLAIN` e variantes.

Ao analisar um plano, observe:

- diferença entre linhas estimadas e reais;
- algoritmos de junção;
- seeks, scans e key lookups;
- spills para `tempdb`;
- paralelismo e skew entre threads;
- conversões implícitas;
- sorts desnecessários;
- predicados residuais;
- memória concedida e utilizada;
- warnings e regressões de plano.

Os percentuais de custo no plano são **estimativas relativas dentro daquele plano**, não tempo real. Um operador com alto percentual não deve ser otimizado isoladamente sem medir o efeito total.

O plano real executa a instrução. Não o capture sem cuidado para comandos mutáveis ou consultas caras em produção.

---

## 65. O que são funções de agregação e como usar `GROUP BY`, `WHERE` e `HAVING`?

**Resposta:**

Funções de agregação resumem conjuntos de linhas. Exemplos:

- `COUNT(*)` conta linhas;
- `COUNT(ColumnName)` ignora `NULL` nessa coluna;
- `SUM` e `AVG` normalmente ignoram `NULL`;
- `MIN` e `MAX` retornam os extremos não nulos.

```sql
SELECT
    DepartmentId,
    COUNT(*) AS EmployeeCount,
    AVG(Salary) AS AverageSalary
FROM dbo.Employees
WHERE IsActive = 1
GROUP BY DepartmentId
HAVING COUNT(*) >= 5;
```

- **`WHERE`** filtra linhas antes da agregação.
- **`GROUP BY`** forma os grupos.
- **`HAVING`** filtra os grupos depois da agregação.

Predicados que não dependem da agregação devem, em geral, ficar em `WHERE`, permitindo reduzir os dados mais cedo. Colunas selecionadas que não participam de agregações precisam fazer parte do agrupamento, salvo regras específicas do SGBD.

A ordem lógica simplificada é: `FROM`/`JOIN`, `WHERE`, `GROUP BY`, `HAVING`, `SELECT`, `ORDER BY`.

---

## 66. O que é uma chave composta e quando usá-la?

**Resposta:**

Uma **chave composta** usa duas ou mais colunas para identificar unicamente uma linha.

```sql
CREATE TABLE dbo.CourseEnrollments
(
    TenantId  INT  NOT NULL,
    StudentId INT  NOT NULL,
    CourseId  INT  NOT NULL,
    EnrolledOn DATE NOT NULL,

    CONSTRAINT PK_CourseEnrollments
        PRIMARY KEY (TenantId, StudentId, CourseId)
);
```

É apropriada quando a identidade natural depende da combinação, como uma relação muitos-para-muitos ou um identificador que só é único dentro de um tenant.

### Vantagens

- expressa e impõe a regra de unicidade do domínio;
- pode evitar uma coluna substituta desnecessária;
- oferece uma chave de acesso útil quando a ordem coincide com os padrões de consulta.

### Custos

- amplia chaves estrangeiras que referenciam a tabela;
- aumenta largura de índices e junções;
- a ordem das colunas afeta quais consultas usam o índice eficientemente;
- alterações em uma chave natural podem ser difíceis.

É possível usar uma chave substituta e manter a regra natural com `UNIQUE`. A escolha deve considerar domínio, estabilidade, tamanho das chaves e padrões de acesso. Uma chave composta não deve ser confundida com qualquer índice composto: um índice pode ter várias colunas sem representar identidade.

---

## 67. O que é uma view materializada e como ela difere de uma view comum?

**Resposta:**

Uma **view comum** armazena a definição da consulta, não um conjunto independente de linhas. Ao consultá-la, o otimizador combina sua definição com a consulta externa.

Uma **view materializada** persiste o resultado ou uma estrutura física derivada, podendo reduzir o custo de leituras repetidas. Em troca, ela precisa ser atualizada ou mantida quando os dados-base mudam.

### Diferenças gerais

| Aspecto | View comum | View materializada |
|---|---|---|
| Resultado persistido | Não | Sim |
| Atualização | Reflete os dados-base na consulta | Imediata ou por refresh, conforme o SGBD |
| Custo de leitura | Recalcula conforme o plano | Pode reutilizar dados pré-computados |
| Custo de escrita | Sem manutenção física própria | Mantém ou atualiza a materialização |
| Risco de dados defasados | Não por materialização | Possível quando usa refresh periódico |

No PostgreSQL existe `CREATE MATERIALIZED VIEW` e atualização com `REFRESH MATERIALIZED VIEW`.

No SQL Server, o equivalente mais próximo é uma **indexed view**. Ela exige `WITH SCHEMABINDING`, funções determinísticas, opções de sessão específicas e primeiro um índice clustered único. Existem várias restrições sobre a definição.

```sql
CREATE VIEW dbo.SalesSummary
WITH SCHEMABINDING
AS
    SELECT
        CustomerId,
        COUNT_BIG(*) AS OrderCount,
        SUM(TotalAmount) AS TotalAmount
    FROM dbo.Orders
    GROUP BY CustomerId;
GO

CREATE UNIQUE CLUSTERED INDEX CIX_SalesSummary_CustomerId
    ON dbo.SalesSummary (CustomerId);
```

Indexed views podem acelerar consultas analíticas repetidas, mas aumentam o custo de escrita nas tabelas-base. Devem ser adotadas após medição e avaliação das restrições da plataforma.

---

## 68. Como tratar valores `NULL` em consultas e restrições?

**Resposta:**

`NULL` representa ausência ou valor desconhecido. SQL usa lógica de três valores: uma expressão pode resultar em `TRUE`, `FALSE` ou `UNKNOWN`.

Use:

```sql
WHERE ShippedAt IS NULL;
WHERE ShippedAt IS NOT NULL;
```

Não use `= NULL` ou `<> NULL`.

`COALESCE` retorna o primeiro argumento não nulo:

```sql
SELECT COALESCE(DisplayName, LegalName, N'Sem nome')
FROM dbo.Customers;
```

No SQL Server, `ISNULL` também substitui valores nulos, mas possui regras de tipo e nulabilidade diferentes de `COALESCE`. Avalie conversões e precedência de tipos.

### Restrições

- chave primária não aceita `NULL`;
- chave estrangeira pode aceitar `NULL` se a coluna permitir;
- `CHECK` e `UNIQUE` interagem com `NULL` de modo dependente do SGBD;
- `NOT NULL` deve ser usado quando a ausência não possui significado válido no domínio.

Cuidados frequentes:

- `COUNT(Column)` ignora `NULL`;
- `NOT IN` pode produzir `UNKNOWN` se o conjunto contiver `NULL`;
- `Column <> 0` não inclui linhas em que `Column` é `NULL`;
- concatenação e operações aritméticas podem propagar `NULL`, dependendo da função e configuração.

Não substitua automaticamente `NULL` por zero ou string vazia: são estados semanticamente diferentes.

---

## 69. Qual é a diferença entre funções escalares e table-valued functions?

**Resposta:**

No SQL Server, uma **função escalar** retorna um único valor. Uma **table-valued function — TVF** retorna um conjunto de linhas e pode participar da cláusula `FROM`.

Função escalar:

```sql
CREATE OR ALTER FUNCTION dbo.GetYearOnly
(
    @DateValue DATE
)
RETURNS INT
AS
BEGIN
    RETURN YEAR(@DateValue);
END;
```

Inline TVF:

```sql
CREATE OR ALTER FUNCTION dbo.GetHighValueOrders
(
    @MinimumTotal DECIMAL(18, 2)
)
RETURNS TABLE
AS
RETURN
(
    SELECT Id, CustomerId, TotalAmount
    FROM dbo.Orders
    WHERE TotalAmount >= @MinimumTotal
);
```

```sql
SELECT *
FROM dbo.GetHighValueOrders(1000.00);
```

### Categorias relevantes

- **Scalar UDF:** retorna um valor. Pode impor sobrecarga por linha; versões modernas do SQL Server conseguem inlinear funções elegíveis, mas isso não é garantido.
- **Inline TVF:** é baseada em uma única consulta e costuma ser integrada ao plano da consulta chamadora.
- **Multi-statement TVF:** preenche uma variável de tabela e pode ter estimativas menos precisas e maior custo.

Não esconda lógica cara em uma UDF apenas para tornar a consulta visualmente menor. Compare o plano e as métricas. Funções possuem restrições de efeitos colaterais e não substituem stored procedures para fluxos imperativos ou operações mutáveis.

---

## 70. Como projetar o banco de uma aplicação multitenant?

**Resposta:**

As três estratégias principais são:

### Banco e schema compartilhados

Todas as linhas usam um `TenantId`.

```sql
CREATE TABLE dbo.Orders
(
    TenantId   INT            NOT NULL,
    OrderId    BIGINT         NOT NULL,
    CustomerId BIGINT         NOT NULL,
    TotalAmount DECIMAL(18, 2) NOT NULL,

    CONSTRAINT PK_Orders
        PRIMARY KEY (TenantId, OrderId)
);
```

- maior densidade e operação centralizada;
- exige isolamento rigoroso em consultas, chaves, índices, caches e jobs;
- pode sofrer com noisy neighbors e distribuição desigual.

### Banco compartilhado, schema por tenant

- separação lógica maior;
- aumenta quantidade de objetos e complexidade de migrations;
- pode ser adequado para poucos tenants com customizações controladas.

### Banco por tenant

- maior isolamento, restore e customização independentes;
- eleva custo de provisionamento, observabilidade, pooling, migrations e operação em escala.

### Requisitos de projeto

- incluir `TenantId` em chaves únicas que representam unicidade por tenant;
- impedir referências entre tenants usando chaves estrangeiras compostas quando necessário;
- criar índices iniciados por `TenantId` quando isso corresponder aos filtros reais;
- nunca confiar somente em um filtro adicionado manualmente pela aplicação;
- aplicar autorização antes do acesso e considerar Row-Level Security;
- garantir que caches, filas, arquivos, logs e métricas também carreguem o contexto do tenant;
- planejar quotas, throttling, backups, restore, retenção, residência de dados e migração de tenants;
- automatizar migrations e observar falhas parciais;
- testar tentativas de acesso cruzado.

Exemplo conceitual de Row-Level Security no SQL Server:

```sql
CREATE FUNCTION Security.fn_TenantPredicate
(
    @TenantId INT
)
RETURNS TABLE
WITH SCHEMABINDING
AS
RETURN
(
    SELECT 1 AS IsAllowed
    WHERE @TenantId = CONVERT(INT, SESSION_CONTEXT(N'TenantId'))
);
GO

CREATE SECURITY POLICY Security.TenantPolicy
ADD FILTER PREDICATE Security.fn_TenantPredicate(TenantId)
    ON dbo.Orders,
ADD BLOCK PREDICATE Security.fn_TenantPredicate(TenantId)
    ON dbo.Orders AFTER INSERT
WITH (STATE = ON);
```

A aplicação define o contexto após abrir a conexão:

```sql
EXEC sys.sp_set_session_context
    @key = N'TenantId',
    @value = 42,
    @read_only = 1;
```

Em ambientes com connection pooling, o contexto de sessão precisa ser definido de forma confiável para cada uso da conexão. Row-Level Security reduz o risco de omissões, mas não substitui autenticação, autorização, privilégio mínimo, criptografia e testes de isolamento.
