# Perguntas e respostas de entrevista sobre .NET e C#

Este documento reúne **50 perguntas conceituais sobre .NET, C#, ASP.NET Core, testes e práticas de engenharia de software**.

A tradução foi realizada com autorização do projeto original [`StefanTheCode/dotnet_interview_questions`](https://github.com/StefanTheCode/dotnet_interview_questions). As respostas foram revisadas para remover simplificações imprecisas, atualizar conceitos do .NET moderno e manter a terminologia consistente com o restante deste repositório.

> Conhecer respostas prontas não substitui experiência prática. Em uma entrevista, explique também decisões, limitações, alternativas e exemplos reais.

## Índice

### Fundamentos

1. O que é .NET?
2. O que é o Common Language Runtime — CLR?
3. Qual é a diferença entre código gerenciado e não gerenciado?
4. Qual é a estrutura básica de um programa em C#?
5. Qual é a diferença entre tipos de valor e tipos de referência?
6. O que é garbage collection no .NET?
7. Como funciona o tratamento de exceções em C#?
8. Quais modificadores e formatos de classe existem em C#?
9. O que é um namespace?
10. O que é encapsulamento?

### C# intermediário

11. O que é polimorfismo?
12. O que são delegates?
13. O que é LINQ?
14. Qual é a diferença entre classe abstrata e interface?
15. Como gerenciar memória e recursos em aplicações .NET?
16. Como funciona concorrência e threading no .NET?
17. Como `async` e `await` funcionam?
18. O que é Entity Framework Core?
19. O que são extension methods?
20. Como tratar exceções em métodos assíncronos?

### .NET avançado

21. O que é reflection?
22. O que é middleware no ASP.NET Core?
23. Como funciona injeção de dependência no .NET?
24. Qual é o propósito do .NET Standard?
25. Qual é a diferença entre .NET, .NET Framework e .NET MAUI?
26. Como o garbage collector funciona e como reduzir sua pressão?
27. O que são attributes em C#?
28. Como o código .NET é compilado e executado?
29. O que é o Global Assembly Cache — GAC?
30. Como proteger uma aplicação ASP.NET Core?

### ASP.NET Core

31. O que é MVC?
32. Qual é a diferença entre Razor Pages e MVC?
33. Como realizar validações no ASP.NET Core?
34. O que é SignalR?
35. Quais são os benefícios e limitações do Blazor?
36. Como versionar uma Web API?
37. Qual é o papel de `IApplicationBuilder` e `WebApplication`?
38. O que são Areas no ASP.NET Core?
39. Como gerenciar sessão no ASP.NET Core?
40. Como implementar cache no ASP.NET Core?

### Testes e práticas de engenharia

41. O que é teste unitário?
42. Como substituir dependências em testes?
43. O que são os princípios SOLID?
44. O que são CI e CD?
45. Como desenvolver código C# seguro?
46. Como investigar problemas de desempenho?
47. O que é o padrão Repository?
48. Como trabalhar com migrations do Entity Framework Core?
49. Quais ferramentas podem ser usadas para depuração e profiling?
50. Como se manter atualizado no ecossistema .NET?

---

## Fundamentos

### 1. O que é .NET?

**Resposta:**

.NET é uma plataforma de desenvolvimento composta por runtime, SDK, bibliotecas e frameworks de aplicação. Ela permite criar aplicações web, APIs, serviços, aplicações de desktop, mobile, cloud, IoT e jogos usando linguagens como C#, F# e Visual Basic.

Os principais componentes incluem:

- **runtime:** executa o código gerenciado;
- **bibliotecas base:** fornecem coleções, I/O, rede, criptografia, concorrência e outras APIs;
- **SDK:** oferece compilador, CLI, templates, restore, build, testes e publicação;
- **frameworks de aplicação:** como ASP.NET Core e .NET MAUI.

Desde o .NET 5, a implementação multiplataforma antes chamada de .NET Core passou a usar o nome **.NET**.

---

### 2. O que é o Common Language Runtime — CLR?

**Resposta:**

O CLR é o ambiente de execução do .NET. Ele carrega assemblies, verifica tipos, gerencia exceções, threads e memória, executa garbage collection e transforma Intermediate Language — IL — em código de máquina.

A execução pode utilizar:

- compilação **Just-In-Time — JIT**, durante a execução;
- compilação antecipada, como **ReadyToRun** ou **Native AOT**, em cenários compatíveis;
- otimizações em níveis, conhecidas como **tiered compilation**.

O CLR não torna um assembly automaticamente executável em qualquer dispositivo: o destino precisa possuir um runtime compatível ou receber uma publicação autocontida.

---

### 3. Qual é a diferença entre código gerenciado e não gerenciado?

**Resposta:**

**Código gerenciado** é executado sob os serviços do runtime .NET. O CLR controla aspectos como verificação de tipos, exceções, garbage collection e metadados.

**Código não gerenciado** é código nativo executado fora do modelo de gerenciamento do CLR, como bibliotecas C e C++. Ele pode possuir seu próprio runtime e suas próprias regras de alocação e liberação de memória.

Aplicações .NET podem interoperar com código nativo por mecanismos como P/Invoke e COM interop. Essa fronteira exige cuidados com:

- representação e cópia de dados;
- convenção de chamada;
- tempo de vida dos recursos;
- pinning de memória;
- tratamento de erros nativos.

---

### 4. Qual é a estrutura básica de um programa em C#?

**Resposta:**

Projetos modernos podem usar **top-level statements**, sem declarar explicitamente uma classe e um método `Main`:

```csharp
Console.WriteLine("Olá, mundo!");
```

O compilador gera o ponto de entrada necessário. A forma clássica continua válida:

```csharp
namespace Example;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Olá, mundo!");
    }
}
```

Um projeto normalmente também contém um arquivo `.csproj`, referências a pacotes ou projetos, namespaces e tipos organizados em arquivos `.cs`.

---

### 5. Qual é a diferença entre tipos de valor e tipos de referência?

**Resposta:**

A diferença principal é a **semântica de armazenamento e cópia**, não uma regra absoluta de “stack versus heap”.

- **Tipos de valor**, como `int`, `bool`, `enum` e `struct`, armazenam seus dados diretamente. Uma atribuição normalmente copia o valor completo.
- **Tipos de referência**, como classes, arrays, delegates e `string`, armazenam uma referência para um objeto. Uma atribuição copia a referência, não o objeto apontado.

```csharp
int first = 10;
int second = first;
second = 20;
// first continua 10.

var list1 = new List<int> { 1, 2 };
var list2 = list1;
list2.Add(3);
// list1 e list2 referenciam a mesma lista.
```

A localização física depende do contexto. Um tipo de valor pode estar dentro de um objeto no heap, e otimizações do runtime podem alterar detalhes de alocação.

---

### 6. O que é garbage collection no .NET?

**Resposta:**

Garbage collection — GC — é o gerenciamento automático da memória ocupada por objetos gerenciados que deixaram de ser alcançáveis por referências ativas.

O GC é geracional:

- **geração 0:** objetos recém-alocados e normalmente de vida curta;
- **geração 1:** área intermediária;
- **geração 2:** objetos de vida longa;
- **Large Object Heap — LOH:** objetos grandes, administrados com políticas específicas.

O GC libera memória gerenciada, mas não substitui a liberação determinística de recursos como arquivos, sockets, conexões e handles. Esses recursos devem ser encapsulados por `IDisposable` ou `IAsyncDisposable` e utilizados com `using` ou `await using`.

---

### 7. Como funciona o tratamento de exceções em C#?

**Resposta:**

C# usa `try`, `catch`, `finally` e `throw` para representar e tratar falhas excepcionais.

```csharp
try
{
    await ProcessAsync();
}
catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
{
    // Cancelamento esperado pelo chamador.
}
catch (IOException exception)
{
    logger.LogError(exception, "Falha de I/O");
    throw;
}
finally
{
    // Executado com sucesso ou falha.
}
```

Boas práticas:

- capture exceções específicas;
- não use exceções para fluxo normal esperado;
- não silencie falhas sem uma decisão explícita;
- use `throw;` para preservar o stack trace;
- registre contexto, evitando dados sensíveis;
- libere recursos com `using`, mesmo quando ocorrer uma exceção.

---

### 8. Quais modificadores e formatos de classe existem em C#?

**Resposta:**

Algumas formas comuns são:

- **`abstract`:** não pode ser instanciada e pode declarar membros abstratos;
- **`sealed`:** não pode ser herdada;
- **`static`:** não pode ser instanciada nem herdada e contém somente membros estáticos;
- **`partial`:** permite dividir a declaração entre arquivos;
- **genérica:** recebe parâmetros de tipo, como `Repository<T>`;
- **record class:** oferece semântica orientada a dados, igualdade por valor e suporte a expressões `with`.

Essas categorias podem se combinar quando permitido pela linguagem. Modificadores de acesso como `public`, `internal`, `protected` e `private` controlam a visibilidade.

---

### 9. O que é um namespace?

**Resposta:**

Um namespace organiza tipos e reduz colisões de nomes. Ele não representa necessariamente uma pasta nem cria isolamento de assembly.

```csharp
namespace Company.Billing.Payments;

public sealed class PaymentProcessor
{
}
```

Um tipo pode ser referenciado pelo nome totalmente qualificado ou importado com `using`. Aliases também podem resolver ambiguidades entre tipos com o mesmo nome.

---

### 10. O que é encapsulamento?

**Resposta:**

Encapsulamento consiste em proteger invariantes e esconder detalhes internos de uma abstração. O consumidor interage por uma API controlada, em vez de alterar livremente o estado.

```csharp
public sealed class BankAccount
{
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        Balance += amount;
    }
}
```

O objetivo não é apenas tornar campos privados, mas garantir que o objeto permaneça válido após cada operação pública.

---

## C# intermediário

### 11. O que é polimorfismo?

**Resposta:**

Polimorfismo permite usar uma abstração comum enquanto diferentes implementações fornecem comportamentos específicos.

Em C#, aparece principalmente por:

- sobrescrita de membros `virtual` ou `abstract` com `override`;
- implementação de interfaces;
- sobrecarga de métodos e operadores, resolvida em tempo de compilação;
- generics, que permitem algoritmos independentes do tipo concreto.

O despacho virtual acontece em runtime. Sobrecarga é selecionada pelo compilador com base nos tipos conhecidos no ponto da chamada.

---

### 12. O que são delegates?

**Resposta:**

Delegate é um tipo que representa referências para métodos com uma assinatura compatível. Ele permite callbacks, composição de comportamento, eventos e APIs funcionais.

```csharp
Func<int, int, int> operation = static (left, right) => left + right;
int result = operation(2, 3);
```

Delegates podem ser multicast. Ao combiná-los, os métodos são chamados na ordem registrada. Eventos usam delegates, mas restringem quem pode disparar ou substituir a lista de assinantes.

---

### 13. O que é LINQ?

**Resposta:**

Language Integrated Query — LINQ — fornece operadores de consulta integrados à linguagem para coleções, bancos de dados e outras fontes.

```csharp
IEnumerable<string> names = users
    .Where(user => user.IsActive)
    .OrderBy(user => user.Name)
    .Select(user => user.Name);
```

Pontos importantes:

- muitas operações sobre `IEnumerable<T>` usam execução adiada;
- materializações como `ToList` e `ToArray` executam a consulta;
- `IQueryable<T>` constrói uma expressão que um provider pode traduzir;
- nem todo código C# pode ser traduzido para SQL;
- múltiplas enumerações podem repetir trabalho ou consultas remotas.

---

### 14. Qual é a diferença entre classe abstrata e interface?

**Resposta:**

Uma **classe abstrata** pode compartilhar estado, construtores, campos e implementações entre tipos relacionados. Uma classe só pode herdar diretamente de uma classe base.

Uma **interface** define um contrato que pode ser implementado por tipos sem relação de herança. Uma classe ou struct pode implementar várias interfaces. Interfaces modernas podem conter implementações padrão, membros estáticos abstratos e outros recursos, mas continuam sem representar o estado de instância de uma classe base.

Use classe abstrata quando existe uma relação forte de especialização e comportamento compartilhado. Use interface para capacidades, contratos e baixo acoplamento.

---

### 15. Como gerenciar memória e recursos em aplicações .NET?

**Resposta:**

O runtime gerencia a memória dos objetos, mas o desenvolvedor ainda deve controlar padrões de alocação e recursos externos.

Práticas comuns:

- aplicar `using` ou `await using` a recursos descartáveis;
- evitar manter referências desnecessárias em caches, eventos e singletons;
- reduzir alocações em caminhos críticos somente após medição;
- usar `Span<T>`, `Memory<T>`, pooling ou structs quando houver benefício comprovado;
- evitar finalizers, salvo quando o tipo encapsula diretamente um recurso nativo;
- analisar dumps, contadores e traces antes de otimizar.

Chamar `GC.Collect()` manualmente raramente é a solução correta e pode prejudicar o desempenho.

---

### 16. Como funciona concorrência e threading no .NET?

**Resposta:**

Uma aplicação pode executar trabalho concorrente por threads dedicadas, Thread Pool, `Task`, operações assíncronas e primitivas de paralelismo.

Ferramentas comuns incluem:

- `Task` e `Task<T>`;
- `Parallel` e PLINQ para trabalho CPU-bound;
- `lock`, `Monitor`, `SemaphoreSlim`, `Mutex` e tipos interlocked;
- coleções concorrentes e channels;
- `CancellationToken` para cancelamento cooperativo.

Concorrência introduz riscos como race conditions, deadlocks, starvation e visibilidade de memória. Prefira estado imutável ou confinado e mantenha regiões críticas pequenas.

---

### 17. Como `async` e `await` funcionam?

**Resposta:**

`async` permite usar `await` e faz o compilador gerar uma máquina de estados. Quando a operação aguardada ainda não terminou, o método devolve o controle ao chamador e continua depois da conclusão.

```csharp
public async Task<string> DownloadAsync(
    HttpClient client,
    Uri uri,
    CancellationToken cancellationToken)
{
    return await client.GetStringAsync(uri, cancellationToken);
}
```

`async` não cria automaticamente uma nova thread. Operações de I/O podem permanecer aguardando sem ocupar uma thread. Trabalho CPU-bound pode ser paralelizado conscientemente, por exemplo com `Task.Run` fora de ambientes onde isso prejudique o escalonamento.

Evite `async void`, exceto em event handlers. Propague `CancellationToken` e não bloqueie tarefas com `.Result` ou `.Wait()`.

---

### 18. O que é Entity Framework Core?

**Resposta:**

Entity Framework Core — EF Core — é um Object-Relational Mapper — ORM — para .NET. Ele permite mapear entidades para um banco relacional, consultar com LINQ, rastrear alterações e persistir modificações.

Recursos incluem:

- `DbContext` e `DbSet<T>`;
- LINQ traduzido pelo provider;
- change tracking;
- migrations;
- transações e concorrência otimista;
- carregamento explícito, eager e, quando configurado, lazy loading.

EF Core reduz código repetitivo, mas não elimina a necessidade de compreender SQL, índices, cardinalidade, transações e planos de execução. Para leituras, avalie projeções e `AsNoTracking` quando o rastreamento não for necessário.

---

### 19. O que são extension methods?

**Resposta:**

Extension methods são métodos estáticos chamados com sintaxe de método de instância quando o primeiro parâmetro usa `this`.

```csharp
public static class StringExtensions
{
    public static bool HasValue(this string? value) =>
        !string.IsNullOrWhiteSpace(value);
}
```

Eles não alteram o tipo original, não acessam membros privados e são resolvidos estaticamente pelo compilador. Um membro de instância compatível tem prioridade sobre um extension method.

---

### 20. Como tratar exceções em métodos assíncronos?

**Resposta:**

Exceções de métodos que retornam `Task` ou `Task<T>` são observadas ao usar `await`.

```csharp
try
{
    await service.ExecuteAsync(cancellationToken);
}
catch (DomainException exception)
{
    logger.LogWarning(exception, "Operação rejeitada");
}
```

Em operações paralelas, `Task.WhenAll` permite aguardar o grupo. Mais de uma tarefa pode falhar; registre ou inspecione as tarefas quando for necessário conhecer todas as falhas.

Diferencie cancelamento de erro e preserve `OperationCanceledException` quando o token foi cancelado pelo chamador.

---

## .NET avançado

### 21. O que é reflection?

**Resposta:**

Reflection permite inspecionar assemblies, tipos, membros, attributes e metadados em runtime, além de criar objetos e invocar membros dinamicamente.

Casos de uso incluem serialização, containers de DI, frameworks de teste, mapeamento e descoberta de plugins.

Reflection oferece flexibilidade, mas reduz garantias em tempo de compilação, pode ter custo maior e exige atenção em aplicações com trimming ou Native AOT. Quando o caminho é crítico, considere cache de metadados, delegates compilados ou source generators.

---

### 22. O que é middleware no ASP.NET Core?

**Resposta:**

Middleware é um componente do pipeline HTTP. Cada componente pode executar lógica antes e depois do próximo middleware, encerrar o pipeline ou modificar request e response.

```csharp
app.Use(async (context, next) =>
{
    var startedAt = Stopwatch.GetTimestamp();
    await next(context);
    logger.LogInformation("Status {StatusCode}", context.Response.StatusCode);
});
```

A ordem é parte do comportamento da aplicação. Tratamento de exceções, arquivos estáticos, roteamento, autenticação, autorização e endpoints devem ser organizados segundo suas dependências.

---

### 23. Como funciona injeção de dependência no .NET?

**Resposta:**

Injeção de dependência separa a criação de objetos do uso de suas abstrações. O container nativo do .NET registra serviços e resolve seus grafos de dependência.

```csharp
builder.Services.AddSingleton<ISystemClock, SystemClock>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddTransient<IValidator<Order>, OrderValidator>();
```

Lifetimes comuns:

- **singleton:** uma instância por container;
- **scoped:** uma instância por escopo, normalmente uma requisição HTTP;
- **transient:** uma nova instância por resolução.

Evite capturar um serviço scoped dentro de um singleton. Construtores com dependências excessivas podem indicar responsabilidade demais, mesmo que o container consiga resolvê-los.

---

### 24. Qual é o propósito do .NET Standard?

**Resposta:**

.NET Standard é uma especificação de APIs que diferentes implementações do .NET se comprometeram a oferecer. Ele foi criado para facilitar bibliotecas compartilhadas entre .NET Framework, .NET Core, Xamarin e outras implementações.

Para aplicações e bibliotecas que usam apenas versões modernas do .NET, normalmente é preferível direcionar um Target Framework Moniker específico, como `net10.0`, ou usar multitargeting.

`netstandard2.0` ainda é relevante quando uma biblioteca precisa atender simultaneamente ao .NET Framework e ao .NET moderno. Não estão previstas novas versões do .NET Standard.

---

### 25. Qual é a diferença entre .NET, .NET Framework e .NET MAUI?

**Resposta:**

- **.NET:** implementação moderna, multiplataforma e de código aberto usada para novos serviços, APIs, aplicações web, console, cloud e vários outros tipos de aplicação.
- **.NET Framework:** implementação anterior, vinculada ao Windows e mantida principalmente para aplicações legadas que dependem de tecnologias específicas.
- **.NET MAUI:** framework de interface multiplataforma construído sobre o .NET para aplicações Android, iOS, macOS e Windows.

**Xamarin** foi a tecnologia móvel anterior. Seu suporte terminou, e projetos Xamarin existentes devem ser avaliados para migração ao .NET e ao .NET MAUI.

A escolha depende das plataformas, bibliotecas e tecnologias exigidas. Para novos backends, o .NET moderno é normalmente a opção padrão.

---

### 26. Como o garbage collector funciona e como reduzir sua pressão?

**Resposta:**

O GC encontra objetos alcançáveis a partir de raízes, recupera memória de objetos inalcançáveis e pode compactar áreas do heap. Coleções de gerações mais antigas costumam ser mais caras.

Para reduzir pressão de GC:

- diminua alocações somente em caminhos comprovadamente críticos;
- evite criar objetos temporários em loops intensivos;
- reutilize buffers com pools quando o ganho justificar a complexidade;
- evite promover objetos de vida curta mantendo referências desnecessárias;
- reduza pinning prolongado;
- descarte recursos externos corretamente;
- meça alocações e pausas com ferramentas de profiling.

Não presuma que structs são sempre mais rápidos: cópias grandes, boxing e uso incorreto também podem gerar custo.

---

### 27. O que são attributes em C#?

**Resposta:**

Attributes associam metadados declarativos a assemblies, tipos, membros, parâmetros e outros elementos.

```csharp
[Obsolete("Use ProcessAsync em vez deste método.")]
public void Process()
{
}
```

Frameworks podem consultar attributes por reflection ou processá-los em build time. Exemplos incluem configuração de serialização, validação, interoperabilidade e geração de código.

Um attribute não altera o comportamento sozinho; algum compilador, runtime, framework ou código da aplicação precisa interpretá-lo.

---

### 28. Como o código .NET é compilado e executado?

**Resposta:**

O compilador C# transforma o código-fonte em IL e metadados armazenados em assemblies `.dll` ou `.exe`. Na execução, o runtime carrega o assembly e produz código nativo.

Caminhos possíveis incluem:

- **JIT:** compila métodos conforme são executados;
- **tiered compilation:** recompila métodos quentes com otimizações adicionais;
- **ReadyToRun:** inclui código pré-compilado para reduzir trabalho inicial;
- **Native AOT:** produz um executável nativo com restrições de compatibilidade específicas.

A publicação também pode ser dependente do runtime instalado ou autocontida.

---

### 29. O que é o Global Assembly Cache — GAC?

**Resposta:**

O GAC é um repositório global de assemblies fortemente nomeados do **.NET Framework** no Windows. Ele permite compartilhar versões de assemblies entre aplicações instaladas na máquina.

O .NET moderno não usa o GAC como mecanismo padrão de dependências. Projetos SDK-style resolvem frameworks, projetos e pacotes NuGet por arquivos do projeto e artefatos de restore.

Em sistemas atuais, o GAC deve ser tratado principalmente como conhecimento de manutenção de aplicações .NET Framework legadas.

---

### 30. Como proteger uma aplicação ASP.NET Core?

**Resposta:**

Segurança deve ser aplicada em camadas:

- autenticação e autorização com políticas explícitas;
- HTTPS e configuração segura de cookies e headers;
- validação de entrada e codificação contextual de saída;
- proteção contra CSRF quando autenticação baseada em cookie for usada;
- consultas SQL parametrizadas;
- segredos fora do código-fonte;
- menor privilégio para aplicação, banco e infraestrutura;
- atualização de dependências e análise de vulnerabilidades;
- rate limiting e limites de tamanho e tempo;
- logs e auditoria sem expor credenciais ou dados pessoais.

Model binding ou validação de modelo não substituem autorização. O servidor deve verificar que o usuário pode executar a ação sobre o recurso específico.

---

## ASP.NET Core

### 31. O que é MVC?

**Resposta:**

Model-View-Controller separa responsabilidades de uma aplicação de interface:

- **Model:** dados, regras e objetos usados pela aplicação;
- **View:** apresentação;
- **Controller:** recebe a requisição, coordena o caso de uso e escolhe a resposta.

No ASP.NET Core MVC, controllers e actions usam routing, model binding, filtros e views Razor. MVC melhora organização, mas controllers devem permanecer finos e delegar regras de domínio ou aplicação a serviços apropriados.

---

### 32. Qual é a diferença entre Razor Pages e MVC?

**Resposta:**

**Razor Pages** organiza a aplicação por página. Cada arquivo `.cshtml` normalmente possui um `PageModel` com handlers como `OnGet` e `OnPost`.

**MVC** organiza a entrada por controllers e actions e é apropriado quando várias rotas compartilham comportamentos, filtros ou modelos de resposta.

As duas opções usam a infraestrutura do ASP.NET Core e podem coexistir. A escolha é de organização e adequação ao domínio, não de capacidade absoluta.

---

### 33. Como realizar validações no ASP.NET Core?

**Resposta:**

O model binding preenche os modelos e registra erros em `ModelState`. Data Annotations, `IValidatableObject`, validações customizadas ou bibliotecas especializadas podem declarar regras.

```csharp
public sealed class CreateUserRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; init; } = string.Empty;

    [Range(18, 120)]
    public int Age { get; init; }
}
```

A validação de entrada deve acontecer no servidor. Ela não substitui regras de domínio, autorização, constraints no banco ou validação de concorrência.

---

### 34. O que é SignalR?

**Resposta:**

SignalR é uma biblioteca para comunicação em tempo real entre servidor e clientes. Ela abstrai conexões persistentes e pode usar WebSockets, Server-Sent Events ou long polling conforme cliente e infraestrutura.

Casos de uso incluem chats, notificações, dashboards, acompanhamento de progresso e colaboração.

Hubs simplificam a chamada de métodos e o envio para usuários ou grupos. Em escala horizontal, é necessário considerar afinidade, backplane ou serviço gerenciado, além de autenticação, autorização e limites de mensagens.

---

### 35. Quais são os benefícios e limitações do Blazor?

**Resposta:**

Blazor permite construir componentes web com C# e Razor. Componentes podem usar renderização estática no servidor, interatividade no servidor, interatividade WebAssembly no cliente ou uma combinação por modos de renderização.

Benefícios:

- reutilização de conhecimento e bibliotecas .NET;
- componentes fortemente tipados;
- integração com ASP.NET Core;
- possibilidade de compartilhar componentes com aplicações Blazor Hybrid.

Trade-offs incluem tamanho inicial no cliente, latência e dependência de conexão no modo interativo de servidor, limites de APIs no navegador e necessidade eventual de JavaScript interop.

---

### 36. Como versionar uma Web API?

**Resposta:**

Versionamento permite evoluir contratos sem quebrar consumidores existentes. A versão pode ser informada por:

- segmento da rota;
- query string;
- header;
- media type.

A estratégia deve definir suporte, depreciação, documentação e observabilidade. Nem toda mudança exige uma nova versão: adicionar um campo opcional costuma ser compatível, enquanto remover ou reinterpretar campos pode quebrar clientes.

Bibliotecas de versionamento podem automatizar seleção de endpoints e documentação, mas não substituem governança de contrato nem testes de compatibilidade.

---

### 37. Qual é o papel de `IApplicationBuilder` e `WebApplication`?

**Resposta:**

`IApplicationBuilder` representa a construção do pipeline de middleware por métodos como `Use`, `Run` e `Map`.

No modelo de hospedagem moderno, `WebApplication` implementa as capacidades necessárias para configurar o pipeline e mapear endpoints:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
```

Classes `Startup` e métodos `Configure(IApplicationBuilder)` ainda podem aparecer em aplicações antigas ou em estilos compatíveis, mas os templates atuais usam `WebApplicationBuilder` e `WebApplication`.

---

### 38. O que são Areas no ASP.NET Core?

**Resposta:**

Areas particionam uma aplicação MVC em grupos funcionais, cada um com controllers, views e rotas próprias. São úteis em aplicações grandes, por exemplo para separar administração, faturamento e suporte.

```csharp
[Area("Admin")]
public sealed class DashboardController : Controller
{
    public IActionResult Index() => View();
}
```

Areas são uma técnica de organização da camada web. Elas não criam limites de segurança; autorização continua necessária.

---

### 39. Como gerenciar sessão no ASP.NET Core?

**Resposta:**

Session armazena dados associados a um identificador enviado normalmente por cookie. Os valores permanecem no servidor ou em um cache distribuído; o cookie contém o identificador, não todo o estado.

Em múltiplas instâncias, use armazenamento distribuído e configure proteção de dados de forma compartilhada quando necessário.

Sessão deve guardar poucos dados temporários. Não é adequada como fonte principal de verdade, mecanismo de autorização ou armazenamento de informações que precisam sobreviver indefinidamente.

---

### 40. Como implementar cache no ASP.NET Core?

**Resposta:**

Opções comuns incluem:

- `IMemoryCache` para dados locais ao processo;
- `IDistributedCache` para cache compartilhado;
- response caching ou output caching para respostas HTTP, conforme os requisitos;
- cache no cliente, CDN e reverse proxy por headers HTTP.

```csharp
public async Task<Product?> GetAsync(int id, CancellationToken token)
{
    return await cache.GetOrCreateAsync($"product:{id}", async entry =>
    {
        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
        return await repository.GetAsync(id, token);
    });
}
```

Defina expiração, invalidação, tolerância a dados obsoletos, comportamento em falhas e proteção contra cache stampede. Nunca armazene dados de usuários diferentes sob a mesma chave sem isolamento apropriado.

---

## Testes e práticas de engenharia

### 41. O que é teste unitário?

**Resposta:**

Teste unitário verifica uma unidade pequena e observável de comportamento, com execução rápida e resultado determinístico. Ele normalmente não depende de rede, relógio real, banco externo ou filesystem compartilhado.

```csharp
[Fact]
public void Deposit_ShouldIncreaseBalance()
{
    var account = new BankAccount();

    account.Deposit(100m);

    Assert.Equal(100m, account.Balance);
}
```

O teste deve verificar comportamento relevante, não a implementação interna. Integrações reais devem ser cobertas também por testes de integração, contrato, sistema ou end-to-end.

---

### 42. Como substituir dependências em testes?

**Resposta:**

Dependências podem ser substituídas por:

- **fake:** implementação funcional simplificada, como um repositório em memória;
- **stub:** fornece respostas predefinidas;
- **mock:** verifica interações esperadas;
- **spy:** registra chamadas para inspeção posterior.

Frameworks como Moq e NSubstitute ajudam, mas objetos manuais podem ser mais claros. Evite simular detalhes internos demais: testes excessivamente acoplados a chamadas quebram durante refatorações que não alteram o comportamento.

---

### 43. O que são os princípios SOLID?

**Resposta:**

- **Single Responsibility:** um módulo deve ter uma razão coerente para mudar.
- **Open/Closed:** o comportamento deve poder ser estendido sem exigir alterações espalhadas em código estável.
- **Liskov Substitution:** implementações de uma abstração devem respeitar seu contrato e expectativas.
- **Interface Segregation:** consumidores não devem depender de membros que não utilizam.
- **Dependency Inversion:** regras de alto nível devem depender de abstrações estáveis, não de detalhes voláteis.

SOLID são heurísticas de design, não metas isoladas. Aplicação mecânica pode produzir excesso de interfaces, classes e indireções.

---

### 44. O que são CI e CD?

**Resposta:**

**Continuous Integration — CI** integra alterações frequentemente e executa validações automáticas, como restore, build, análise estática e testes.

**Continuous Delivery** mantém o software em estado implantável e permite promover uma versão por decisão explícita.

**Continuous Deployment** automatiza também a implantação em produção quando todos os critérios são aprovados.

Um pipeline confiável deve ser reproduzível, rápido o suficiente para feedback e protegido por controles de segredo, permissões, rastreabilidade e ambientes.

---

### 45. Como desenvolver código C# seguro?

**Resposta:**

Práticas essenciais:

- validar dados nas fronteiras do sistema;
- parametrizar consultas e comandos;
- aplicar autenticação, autorização e menor privilégio;
- armazenar senhas com algoritmos próprios para password hashing;
- proteger segredos fora do repositório;
- usar criptografia e TLS por bibliotecas consolidadas;
- manter dependências e runtime atualizados;
- evitar desserialização insegura e exposição excessiva de dados;
- analisar ameaças, logs, rate limits e falhas de dependências.

Dependência injetada não é, por si só, mais segura. Segurança depende do desenho, configuração, implementação e operação.

---

### 46. Como investigar problemas de desempenho?

**Resposta:**

Comece por uma hipótese baseada em métricas, não por otimizações aleatórias.

Investigue:

- latência, throughput e taxa de erros;
- CPU, memória, GC e alocações;
- contenção, Thread Pool e bloqueios;
- I/O, chamadas remotas e filas;
- consultas, planos, índices e cardinalidade;
- logs, traces distribuídos e perfis;
- diferenças entre ambiente, carga e dados.

Use benchmarks para microcenários e testes de carga para comportamento sistêmico. Compare antes e depois e verifique se a otimização piorou legibilidade, corretude ou consumo em outra área.

---

### 47. O que é o padrão Repository?

**Resposta:**

Repository fornece uma abstração orientada ao domínio para acessar e persistir agregados ou coleções de objetos.

Benefícios possíveis:

- concentra consultas e regras de persistência relevantes;
- reduz dependência direta da camada de aplicação em detalhes de armazenamento;
- facilita substituição ou testes quando existe uma fronteira real.

Riscos:

- um `GenericRepository<T>` pode esconder capacidades úteis do ORM e produzir uma API limitada;
- abstrações podem apenas duplicar `DbSet<T>` e `DbContext`;
- retornar `IQueryable<T>` expõe detalhes de consulta para fora da fronteira.

No EF Core, `DbContext` já possui características de Unit of Work e Repository. Adicione outra camada quando ela representar uma abstração útil ao domínio, não apenas por regra arquitetural.

---

### 48. Como trabalhar com migrations do Entity Framework Core?

**Resposta:**

Migrations registram alterações de modelo e geram operações para evoluir o schema.

Comandos comuns:

```shell
dotnet ef migrations add AddOrders
dotnet ef migrations script --idempotent
dotnet ef database update
```

Boas práticas:

- revisar o código gerado e o SQL;
- versionar migrations no repositório;
- testar upgrade e, quando aplicável, rollback ou estratégia de correção;
- fazer backup e avaliar bloqueios, volume e duração;
- separar alterações incompatíveis em etapas de expansão e contração;
- aplicar em produção por um processo controlado, não necessariamente no startup de todas as instâncias.

Alterar o modelo não garante uma migration segura para grandes tabelas ou implantação sem downtime.

---

### 49. Quais ferramentas podem ser usadas para depuração e profiling?

**Resposta:**

Ferramentas comuns incluem:

- depuradores do Visual Studio, Visual Studio Code ou Rider;
- `dotnet-counters` para métricas em tempo real;
- `dotnet-trace` para traces;
- `dotnet-dump` para coleta e análise de dumps;
- PerfView e Windows Performance Recorder em cenários Windows;
- ferramentas como dotTrace e dotMemory;
- BenchmarkDotNet para microbenchmarks;
- OpenTelemetry e Application Performance Monitoring para produção.

Escolha a ferramenta conforme a pergunta: CPU, memória, exceções, bloqueios, GC, alocações ou latência distribuída exigem evidências diferentes.

---

### 50. Como se manter atualizado no ecossistema .NET?

**Resposta:**

Uma estratégia sustentável combina:

- documentação e blogs oficiais do .NET e ASP.NET Core;
- release notes, breaking changes e políticas de suporte;
- repositórios e issues oficiais no GitHub;
- conferências como .NET Conf e Microsoft Build;
- leitura de código-fonte, amostras e propostas de linguagem;
- atualização periódica de projetos pequenos para praticar migrations;
- comunidades técnicas, livros e artigos revisados criticamente.

Não acompanhe apenas novidades. Entenda também suporte, compatibilidade, segurança e custo operacional antes de adotar uma tecnologia em produção.
