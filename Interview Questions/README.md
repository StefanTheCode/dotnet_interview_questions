**Aviso:** Esta tradução foi feita com a devida autorização do repositório [GitHub de StefanTheCode](https://github.com/StefanTheCode).

**.NET (C#) Perguntas e Respostas de Entrevista**

Este documento contém uma coleção de 50 perguntas de entrevista relacionadas ao .NET e à linguagem de programação C#, com o objetivo de avaliar candidatos em vários níveis de expertise.

Para mais conteúdo como este, junte-se a mais de 15.500 engenheiros na minha [Newsletter TheCodeMan.net](https://thecodeman.net/?utm_source=github)

***Observação: Estas são apenas perguntas técnicas. Saber todas as respostas não garante sua aprovação na entrevista.***

---

## Básico

1. **O que é .NET?**  
2. **Você pode explicar o Common Language Runtime (CLR)?**  
3. **Qual é a diferença entre código gerenciado (managed) e não gerenciado (unmanaged)?**  
4. **Explique a estrutura básica de um programa em C#.**  
5. **O que são Value Types e Reference Types em C#?**  
6. **O que é garbage collection no .NET?**  
7. **Explique o conceito de tratamento de exceções (exception handling) em C#.**  
8. **Quais são os diferentes tipos de classes em C#?**  
9. **Descreva o que é um namespace e como ele é usado em C#.**  
10. **O que é encapsulamento?**

## Intermediário

11. **Explique polimorfismo e seus tipos em C#.**  
12. **O que são delegates e como são usados em C#?**  
13. **Descreva o que é LINQ e dê um exemplo de onde poderia ser usado.**  
14. **Qual a diferença entre uma classe abstrata e uma interface?**  
15. **Como você gerencia memória em aplicações .NET?**  
16. **Explique o conceito de threading no .NET.**  
17. **O que são async/await e como funcionam?**  
18. **Descreva o Entity Framework e suas vantagens.**  
19. **O que são extension methods e onde você os utilizaria?**  
20. **Como você trata exceções em um método que retorna uma Task?**

## Avançado

21. **O que é reflection no .NET e como você o utilizaria?**  
22. **Você pode explicar o conceito de middleware no ASP.NET Core?**  
23. **Descreva o padrão de Injeção de Dependência (DI) e como ele é implementado no .NET Core.**  
24. **Qual é o propósito do .NET Standard?**  
25. **Explique as diferenças entre .NET Core, .NET Framework e Xamarin.**  
26. **Como funciona a garbage collection no .NET e como otimizá-la?**  
27. **O que são atributos (attributes) em C# e como podem ser utilizados?**  
28. **Você pode descrever o processo de compilação de código no .NET?**  
29. **O que é o Global Assembly Cache (GAC) e quando deve ser usado?**  
30. **Como você protegeria (securizaria) uma aplicação web em ASP.NET Core?**

## Específico do Framework

31. **O que é MVC (Model-View-Controller)?**  
32. **Você pode explicar a diferença entre Razor Pages e MVC no ASP.NET Core?**  
33. **Como fazer validações no ASP.NET Core?**  
34. **Descreva o SignalR e seus casos de uso.**  
35. **Quais são os benefícios de usar Blazor em vez de tecnologias web tradicionais?**  
36. **Como implementar versionamento de Web API no ASP.NET Core?**  
37. **Explique o papel de IApplicationBuilder no ASP.NET Core.**  
38. **O que são Areas no ASP.NET Core e como você as utiliza?**  
39. **Como gerenciar sessões em aplicações ASP.NET Core?**  
40. **Descreva como implementar caching no ASP.NET Core.**

## Testes e Melhores Práticas

41. **O que é Teste Unitário (Unit Testing) em .NET?**  
42. **Como simular (mock) dependências em testes unitários usando .NET?**  
43. **Você pode explicar os princípios SOLID?**  
44. **O que é Integração Contínua/Implantação Contínua (CI/CD) e como se aplica ao desenvolvimento .NET?**  
45. **Como você garante que seu código C# seja seguro?**  
46. **Quais são alguns problemas comuns de desempenho em aplicações .NET e como você os resolve?**  
47. **Descreva o padrão de Repositório (Repository) e seus benefícios.**  
48. **Como você lida com migrações de banco de dados no Entity Framework?**  
49. **Quais ferramentas você usa para depurar e fazer perfil (profiling) de aplicações .NET?**  
50. **Como você se mantém atualizado com as últimas tecnologias e práticas .NET?**

---

## Básico

### 1. O que é .NET?

**Resposta:**  
.NET é uma plataforma de desenvolvimento abrangente para a criação de diversos tipos de aplicações, como web, mobile, desktop e jogos. Ela suporta várias linguagens de programação, como C#, F# e Visual Basic. O .NET fornece uma biblioteca de classes extensa, chamada Framework Class Library (FCL), e executa o código em um Common Language Runtime (CLR), que oferece serviços como gerenciamento de memória, segurança e tratamento de exceções.

---

### 2. Você pode explicar o Common Language Runtime (CLR)?

**Resposta:**  
O CLR é o componente de máquina virtual do .NET que gerencia a execução de programas .NET. Ele fornece serviços importantes como gerenciamento de memória, segurança de tipos, tratamento de exceções, garbage collection e gerenciamento de threads. O CLR converte o código em Linguagem Intermediária (IL) para código nativo de máquina por meio de um processo chamado compilação Just-In-Time (JIT). Isso garante que as aplicações .NET possam ser executadas em qualquer dispositivo ou plataforma que ofereça suporte ao .NET.

---

### 3. Qual é a diferença entre código gerenciado (managed) e não gerenciado (unmanaged)?

**Resposta:**  
- **Código gerenciado (managed):** É executado pelo CLR, que fornece serviços como garbage collection, tratamento de exceções e verificação de tipos. Esse código é chamado de “gerenciado” porque o CLR gerencia grande parte das funcionalidades que, de outra forma, o desenvolvedor precisaria implementar manualmente.  
- **Código não gerenciado (unmanaged):** É executado diretamente pelo sistema operacional. Nesse caso, todo o gerenciamento de memória, segurança de tipos e tratamento de exceções deve ser feito pelo programador. Exemplos incluem aplicações escritas em C ou C++ nativo.

---

### 4. Explique a estrutura básica de um programa em C#.

**Resposta:**  
Um programa básico em C# geralmente contém:

- **Declaração de namespace:** Uma forma de organizar o código e controlar o escopo de classes e métodos em projetos maiores.  
- **Declaração de classe:** Define um novo tipo com membros de dados (campos, propriedades) e membros de função (métodos, construtores).  
- **Método Main:** O ponto de entrada do programa, onde a execução começa e termina.  
- **Declarações e expressões:** Realizam ações, como manipular variáveis, chamar métodos, laços de repetição etc.

```csharp
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

---

### 5. O que são Value Types e Reference Types em C#?

**Resposta:**  
Em C#, os tipos de dados são divididos em duas categorias: Value Types (tipos de valor) e Reference Types (tipos de referência). Essa distinção afeta como os valores são armazenados e manipulados na memória.

- **Value Types (Tipos de Valor):** Armazenam diretamente os dados e são alocados na stack (pilha). Ao atribuir um tipo de valor a outro, é feita uma cópia do valor. Exemplos: `int`, `double`, `bool` e structs.  
- **Reference Types (Tipos de Referência):** Armazenam um ponteiro para o local onde o valor efetivamente reside na heap. Ao atribuir um tipo de referência a outro, ambos apontam para o mesmo objeto na memória. Exemplos: `class`, arrays, delegates e `string`.

Exemplo:

```csharp
// Exemplo de Value Type
int a = 10;
int b = a;
b = 20;
Console.WriteLine(a); // Saída: 10
Console.WriteLine(b); // Saída: 20

// Exemplo de Reference Type
var list1 = new List<int> { 1, 2, 3 };
var list2 = list1;
list2.Add(4);
Console.WriteLine(list1.Count); // Saída: 4
Console.WriteLine(list2.Count); // Saída: 4
```

---

### 6. O que é garbage collection no .NET?

**Resposta:**  
O garbage collection (GC) no .NET é um recurso de gerenciamento automático de memória que libera a memória utilizada por objetos que não são mais acessíveis no programa. Ele elimina a necessidade de o desenvolvedor liberar memória manualmente, reduzindo problemas como vazamentos de memória. O GC funciona em três fases: marcação (identifica objetos em uso), realocação (atualiza referências de objetos a serem mantidos) e compactação (recolhe e libera a memória dos objetos não utilizados).

---

### 7. Explique o conceito de tratamento de exceções (exception handling) em C#.

**Resposta:**  
O tratamento de exceções em C# é um mecanismo que lida com erros em tempo de execução, permitindo que o programa continue rodando ou falhe de forma controlada em vez de simplesmente encerrar de forma abrupta. Isso é feito com os blocos `try`, `catch` e `finally`. O bloco `try` contém o código que pode gerar uma exceção, enquanto `catch` trata a exceção e o `finally` executa instruções (como limpeza de recursos) independente de ter havido exceção ou não.

```csharp
try
{
    // Código que pode gerar exceção
    int divide = 10 / 0;
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Não é possível dividir por zero.");
}
finally
{
    Console.WriteLine("Operação finalizada.");
}
```

---

### 8. Quais são os diferentes tipos de classes em C#?

**Resposta:**  
Em C#, as classes podem ser categorizadas com base em sua funcionalidade e acessibilidade:

- **Static classes:** Não podem ser instanciadas e só contêm membros estáticos.  
- **Sealed classes:** Não podem ser herdadas.  
- **Abstract classes:** Não podem ser instanciadas, mas servem como base para outras classes.  
- **Partial classes:** Permitem que a definição de uma classe seja dividida em vários arquivos.  
- **Generic classes:** Definem classes com parâmetros de tipo, permitindo a criação de coleções e métodos fortemente tipados.

---

### 9. Descreva o que é um namespace e como ele é usado em C#.

**Resposta:**  
Um namespace em C# é usado para organizar e agrupar tipos (classes, structs, interfaces, enums, delegates) de forma hierárquica. Ele ajuda a evitar conflitos de nomes, permitindo que tipos com o mesmo nome coexistam em diferentes namespaces. Por exemplo, o namespace `System` contém classes para operações básicas do sistema, como entrada/saída de console, leitura/escrita de arquivos e manipulação de dados.

```csharp
using System;

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olá, Mundo!");
        }
    }
}
```

---

### 10. O que é encapsulamento?

**Resposta:**  
Encapsulamento é um princípio fundamental de Programação Orientada a Objetos (POO) que consiste em agrupar dados (atributos) e métodos (operações) em uma única unidade (classe), restringindo o acesso aos detalhes internos dessa classe. Geralmente, isso é feito com modificadores de acesso como `private`, `public`, `protected` e `internal`. O encapsulamento protege o estado interno de um objeto contra acessos e modificações indevidos, promovendo integridade dos dados.

Exemplo simples:

```csharp
public class Person
{
    private string name; // campo privado

    public string Name // propriedade pública
    {
        get { return name; }
        set { name = value; }
    }

    public Person(string name)
    {
        this.name = name;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person("João");
        Console.WriteLine(person.Name); // Acesso por propriedade
    }
}
```

---

## Intermediário

### 11. Explique polimorfismo e seus tipos em C#.

**Resposta:**  
Polimorfismo é um conceito central em POO que permite que objetos sejam tratados como instâncias de sua classe base, enquanto exibem comportamentos específicos de suas classes derivadas. Em C#, o polimorfismo pode ser:

- **Polimorfismo Estático (compile-time):** Conquistado por meio de sobrecarga de métodos (method overloading) e operadores (operator overloading).  
- **Polimorfismo Dinâmico (runtime):** Conquistado por meio de sobrescrita de métodos (method overriding) usando `virtual` e `override`.

Exemplo:

```csharp
// Polimorfismo Estático - Sobrecarga
public class Calculator
{
    public int Add(int a, int b) => a + b;
    public int Add(int a, int b, int c) => a + b + c;
}

// Polimorfismo Dinâmico - Sobrescrita
public class Animal
{
    public virtual void Speak() => Console.WriteLine("O animal faz um som.");
}

public class Dog : Animal
{
    public override void Speak() => Console.WriteLine("O cachorro late.");
}

class Program
{
    static void Main(string[] args)
    {
        // Polimorfismo Estático
        Calculator calc = new Calculator();
        Console.WriteLine(calc.Add(2, 3));
        Console.WriteLine(calc.Add(2, 3, 4));

        // Polimorfismo Dinâmico
        Animal a = new Animal();
        a.Speak();

        Animal d = new Dog();
        d.Speak();
    }
}
```

---

### 12. O que são delegates e como são usados em C#?

**Resposta:**  
Delegates em C# são ponteiros de função seguros, permitindo que métodos sejam passados como parâmetros ou armazenados em variáveis. Eles servem de base para eventos e callbacks, permitindo código mais flexível. Há três principais tipos de delegates:

- **Single-cast:** Aponta para um único método.  
- **Multicast:** Pode apontar para vários métodos na mesma lista de invocação.  
- **Expressões lambda e métodos anônimos:** Formas concisas de criar delegates sem definir métodos nomeados.

Exemplo:

```csharp
public delegate void Operation(int num);

class Program
{
    static void Main(string[] args)
    {
        Operation op = Double;
        op(5);  // Chama Double(5)

        op = Triple;
        op(5);  // Chama Triple(5)

        // Delegate multicast
        op = Double;
        op += Triple;
        op(5);  // Chama Double(5) e depois Triple(5)
    }

    static void Double(int num) => Console.WriteLine($"{num} * 2 = {num * 2}");
    static void Triple(int num) => Console.WriteLine($"{num} * 3 = {num * 3}");
}
```

---

### 13. Descreva o que é LINQ e dê um exemplo de onde poderia ser usado.

**Resposta:**  
LINQ (Language Integrated Query) é um recurso do C# que permite escrever consultas de forma expressiva e fortemente tipada para diferentes fontes de dados (coleções em memória, bancos de dados, XML etc.). Ele unifica o modo como dados são consultados, proporcionando benefícios como verificação em tempo de compilação e IntelliSense.

Exemplo simples de LINQ com lista de inteiros:

```csharp
using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var evenNumbers = from num in numbers
                          where num % 2 == 0
                          select num;

        Console.WriteLine("Números pares:");
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
}
```

---

### 14. Qual a diferença entre uma classe abstrata e uma interface?

**Resposta:**  
- **Classe Abstrata:**
  - Pode conter implementação de métodos, propriedades e campos.  
  - Pode ter modificadores de acesso (public, protected etc.).  
  - Só permite herança simples (uma classe só pode herdar de uma classe abstrata).  
  - Pode ter construtores (para inicialização interna).  
  - Ideal quando há métodos ou propriedades em comum que podem ser parcialmente implementados.

- **Interface:**
  - Não contém implementação — apenas declara membros.  
  - Todos os membros são implicitamente `public`.  
  - Uma classe ou struct pode implementar várias interfaces (herança múltipla de interfaces).  
  - Não contém campos nem construtores.  
  - Ideal para definir contratos sem impor detalhes de implementação.

Exemplo:

```csharp
public abstract class Animal
{
    public abstract void Eat();
    public void Sleep() => Console.WriteLine("Dormindo...");
}

public interface IMovable
{
    void Move();
}

public class Dog : Animal, IMovable
{
    public override void Eat() => Console.WriteLine("Cachorro comendo.");
    public void Move() => Console.WriteLine("Cachorro correndo.");
}
```

---

### 15. Como você gerencia memória em aplicações .NET?

**Resposta:**  
O gerenciamento de memória em aplicações .NET é principalmente automatizado pelo Garbage Collector (GC). No entanto, é importante entender boas práticas:

- **Garbage Collection:** O GC roda em segundo plano e libera memória de objetos que não estão mais em uso.  
- **Padrão Dispose:** Implementar `IDisposable` para liberar recursos não gerenciados (file handles, conexões de banco etc.).  
- **Finalizers:** Podem ser usados para limpeza, mas podem impactar performance se usados em excesso.  
- **Using Statements:** Chamadas automáticas a `Dispose()` ao final do bloco `using`.  
- **Menos alocações desnecessárias:** Minimizar instâncias supérfluas ou criação de grandes quantidades de objetos.

Exemplo de `IDisposable`:

```csharp
public class ResourceHolder : IDisposable
{
    private bool disposed = false;
    IntPtr unmanagedResource = Marshal.AllocHGlobal(100);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Liberar recursos gerenciados
            }
            Marshal.FreeHGlobal(unmanagedResource);
            disposed = true;
        }
    }

    ~ResourceHolder()
    {
        Dispose(false);
    }
}
```

---

### 16. Explique o conceito de threading no .NET.

**Resposta:**  
Threading no .NET permite a execução simultânea de múltiplas tarefas dentro do mesmo processo, melhorando a capacidade de resposta (responsiveness) e o desempenho de aplicações. Existem várias maneiras de criar e gerenciar threads:

- **System.Threading.Thread:** Criação e controle direto de threads.  
- **ThreadPool:** Conjunto de threads reutilizáveis mantidas pelo runtime.  
- **Task Parallel Library (TPL):** Abstrai o uso de threads por meio de `Task`, facilitando programação assíncrona.  
- **async/await:** Simplifica o código assíncrono, permitindo que seja escrito de forma mais clara.

Exemplo usando `System.Threading.Thread`:

```csharp
using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Thread thread = new Thread(DoWork);
        thread.Start();

        Console.WriteLine("Thread principal fazendo trabalho...");
        thread.Join();
        Console.WriteLine("Thread de segundo plano finalizada.");
    }

    static void DoWork()
    {
        Console.WriteLine("Thread de segundo plano em execução...");
        Thread.Sleep(1000);
        Console.WriteLine("Thread de segundo plano finalizada.");
    }
}
```

---

### 17. O que são async/await e como funcionam?

**Resposta:**  
`async` e `await` são palavras-chave que simplificam a programação assíncrona em C#. Um método `async` pode conter uma ou mais expressões `await`. Quando o código encontra `await` em uma `Task`, o fluxo assíncrono é liberado para que outras operações sejam executadas enquanto a `Task` não termina, evitando bloqueio de threads.

Exemplo:

```csharp
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string result = await DownloadContentAsync();
        Console.WriteLine(result);
    }

    static async Task<string> DownloadContentAsync()
    {
        using HttpClient client = new HttpClient();
        string result = await client.GetStringAsync("http://example.com");
        return result;
    }
}
```

Nesse exemplo, o método `DownloadContentAsync` realiza uma chamada HTTP de forma assíncrona, e `await` libera a thread até que a resposta esteja disponível.

---

### 18. Descreva o Entity Framework e suas vantagens.

**Resposta:**  
O Entity Framework (EF) é um ORM (Object-Relational Mapping) de código aberto para .NET, que permite aos desenvolvedores trabalhar com bancos de dados usando objetos .NET, sem precisar escrever a maior parte do código de acesso a dados (SQL).

**Vantagens:**  
- **Produtividade:** Reduz o código manual para acesso a dados.  
- **Manutenção facilitada:** Mapeamento de banco de dados e código sincronizados via migrações.  
- **Suporte a LINQ:** Consultas poderosas e fortemente tipadas.  
- **Independente de banco:** Pode ser usado com múltiplos SGBDs.  
- **Carregamento de dados (lazy, eager, explicit):** Diversas opções de performance.

Exemplo simples:

```csharp
public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
}

public class Blog
{
    public int BlogId { get; set; }
    public string Name { get; set; }
}

using (var db = new BloggingContext())
{
    var blog = new Blog { Name = "Meu Blog" };
    db.Blogs.Add(blog);
    db.SaveChanges();

    var query = from b in db.Blogs
                orderby b.Name
                select b;

    foreach (var item in query)
    {
        Console.WriteLine(item.Name);
    }
}
```

---

### 19. O que são extension methods e onde você os utilizaria?

**Resposta:**  
Extension methods permitem adicionar novos métodos a tipos existentes (inclusive tipos de terceiros) sem precisar modificar, herdar ou recompilar esses tipos. São definidos como métodos estáticos em uma classe estática, mas são chamados como se fossem métodos de instância do tipo estendido.

Exemplo:

```csharp
public static class StringExtensions
{
    public static string ToPascalCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        string[] words = input.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
        }
        return string.Join("", words);
    }
}

class Program
{
    static void Main()
    {
        string title = "o gato-branco saltou";
        Console.WriteLine(title.ToPascalCase()); // "OGatoBrancoSaltou"
    }
}
```

---

### 20. Como você trata exceções em um método que retorna uma Task?

**Resposta:**  
Em métodos assíncronos (`async`/`await`) que retornam `Task` ou `Task<T>`, as exceções são encapsuladas no objeto Task. Para tratá-las:

1. **Dentro do método assíncrono:** Use `try/catch` dentro do próprio método.  
2. **Ao fazer await:** Envolva a chamada `await` em um `try/catch`.  
3. **ContinueWith:** Use `task.ContinueWith` para capturar exceções na continuação.  
4. **Task.WhenAny:** Verifique se a task falhou (`IsFaulted`) após a conclusão.

Exemplo:

```csharp
public async Task<int> DivideAsync(int numerator, int denominator)
{
    return await Task.Run(() =>
    {
        if (denominator == 0)
            throw new DivideByZeroException("Denominador não pode ser zero.");
        return numerator / denominator;
    });
}

public async Task ExecuteAsync()
{
    try
    {
        int result = await DivideAsync(10, 0);
        Console.WriteLine($"Resultado: {result}");
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
}
```

---

## Avançado

### 21. O que é reflection no .NET e como você o utilizaria?

**Resposta:**  
Reflection é um recurso que permite inspecionar assemblies, tipos e seus membros (métodos, campos, propriedades, eventos) em tempo de execução. Também possibilita criar instâncias de tipos, invocar métodos e acessar propriedades dinamicamente. Pode ser usado para:

- Carregar assemblies e tipos dinamicamente.  
- Implementar navegadores de objetos ou depuradores.  
- Frameworks de injeção de dependência.  
- Leitura de atributos personalizados (custom attributes).

Exemplo simples:

```csharp
using System;
using System.Reflection;

public class MyClass
{
    public void MethodToInvoke() => Console.WriteLine("Método invocado.");
}

class Program
{
    static void Main()
    {
        Type myClassType = typeof(MyClass);
        object instance = Activator.CreateInstance(myClassType);
        MethodInfo methodInfo = myClassType.GetMethod("MethodToInvoke");
        methodInfo.Invoke(instance, null);
    }
}
```

---

### 22. Você pode explicar o conceito de middleware no ASP.NET Core?

**Resposta:**  
Middleware em ASP.NET Core são componentes que compõem o pipeline de requisição/resposta de uma aplicação. Cada componente pode executar alguma lógica e, em seguida, chamar o próximo componente ou encerrar o fluxo. Exemplos: autenticação, roteamento, tratamento de erros, log, etc.

Exemplo:

```csharp
public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("Antes do próximo middleware");
        await _next(context);
        Console.WriteLine("Depois do próximo middleware");
    }
}

public static class CustomMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomMiddleware>();
    }
}

// Em Startup.Configure
app.UseCustomMiddleware();
```

---

### 23. Descreva o padrão de Injeção de Dependência (DI) e como ele é implementado no .NET Core.

**Resposta:**  
A Injeção de Dependência (Dependency Injection) é um padrão que visa reduzir o acoplamento entre componentes, fornecendo dependências externas em vez de criá-las diretamente dentro das classes. No .NET Core, há um contêiner de DI embutido que permite registrar e resolver serviços.

- **Registrar Serviços:** Geralmente feito em `Startup.ConfigureServices()`.  
- **Resolver Serviços:** Através de injeção de construtor, injeção de método ou injeção de propriedade.

Exemplo:

```csharp
public interface IGreetingService
{
    string Greet(string name);
}

public class GreetingService : IGreetingService
{
    public string Greet(string name) => $"Olá, {name}!";
}

public class HomeController : Controller
{
    private readonly IGreetingService _greetingService;

    public HomeController(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    public IActionResult Index()
    {
        var greeting = _greetingService.Greet("Mundo");
        return Content(greeting);
    }
}

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddTransient<IGreetingService, GreetingService>();
    }

    // ...
}
```

---

### 24. Qual é o propósito do .NET Standard?

**Resposta:**  
O .NET Standard é uma especificação formal de APIs do .NET que devem estar disponíveis em todas as implementações .NET (por exemplo, .NET Framework, .NET Core, Xamarin). Seu objetivo é unificar a base de APIs para permitir que bibliotecas sejam escritas uma só vez e funcionem em várias plataformas .NET.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
  </PropertyGroup>
</Project>
```

---

### 25. Explique as diferenças entre .NET Core, .NET Framework e Xamarin.

**Resposta:**  
- **.NET Framework:** Implementação original do .NET, criada para Windows. Suporta Windows Forms, WPF, ASP.NET clássico. Recebe apenas atualizações de segurança e correções críticas.  
- **.NET Core (agora .NET 5+):** Multiplataforma (Windows, macOS, Linux), open source, modular e otimizado para aplicativos web, microserviços e cenários em nuvem.  
- **Xamarin:** Plataforma .NET para criar aplicativos móveis nativos em iOS, Android e Windows, usando C#. Permite compartilhamento de código entre plataformas.

---

### 26. Como funciona a garbage collection no .NET e como otimizá-la?

**Resposta:**  
A Garbage Collection (GC) no .NET roda automaticamente, localizando objetos não mais acessíveis e liberando sua memória. Usa um modelo de gerações (0, 1, 2) para otimizar a coleta:

1. **Marcar (Mark):** Identifica objetos que ainda estão em uso.  
2. **Compactar (Compact):** Remove os objetos não acessíveis, liberando espaço na heap.  
3. **Gerações:** Objetos de vida curta ficam na Gen 0; objetos de vida mais longa são promovidos para Gen 1 ou Gen 2.

**Otimizações:**

- Minimizar alocações desnecessárias.  
- Usar padrões de descarte (`IDisposable`) para recursos não gerenciados.  
- Reaproveitar objetos (pools).  
- Profilar o uso de memória e ajustar o código conforme necessário.

---

### 27. O que são atributos (attributes) em C# e como podem ser utilizados?

**Resposta:**  
Atributos em C# adicionam metadados declarativos ao código, utilizados pelo compilador ou em tempo de execução (via reflection). São usados para:

- Indicar como serializar ou validar campos.  
- Marcar classes ou métodos para testes unitários.  
- Controlar comportamento de frameworks (ASP.NET, WCF etc.).  
- Criar anotações personalizadas para ferramentas e bibliotecas.

Exemplo:

```csharp
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class MyCustomAttribute : Attribute
{
    public string Description { get; set; }
    public MyCustomAttribute(string description)
    {
        Description = description;
    }
}

[MyCustomAttribute("Descrição da classe.")]
public class MyClass
{
    [MyCustomAttribute("Descrição do método.")]
    public void MyMethod() { }
}
```

---

### 28. Você pode descrever o processo de compilação de código no .NET?

**Resposta:**  
1. **Código-fonte para IL:** O compilador (por exemplo, `csc.exe` para C#) converte o código para Intermediate Language (IL) e gera metadados.  
2. **IL para código nativo:** Em tempo de execução, o CLR faz a compilação Just-In-Time (JIT), convertendo IL em código de máquina específico da plataforma.  
3. **Execução:** O código nativo é executado no hardware do sistema, com o CLR fornecendo serviços como GC, segurança e verificação de tipos.

As instruções IL e os metadados são armazenados em assemblies (`.dll` ou `.exe`), que podem ser fortes (strong name) e colocados no GAC se desejado.

---

### 29. O que é o Global Assembly Cache (GAC) e quando deve ser usado?

**Resposta:**  
O GAC é um cache global de assemblies no .NET Framework que armazena assemblies compartilhados com nome forte (strong name). Ele:

- **Permite compartilhamento de assemblies** entre múltiplas aplicações.  
- **Requer strong name** (versão, chave pública, etc.).  
- **Suporta side-by-side** de diferentes versões do mesmo assembly.

Use o GAC para bibliotecas comuns e versionadas que precisam ser usadas por vários aplicativos no mesmo computador. Em .NET Core e .NET modernos (a partir do .NET 5), o GAC não é utilizado; é mais comum fazer implantação via NuGet/local.

---

### 30. Como você protegeria (securizaria) uma aplicação web em ASP.NET Core?

**Resposta:**  
Algumas estratégias para proteger aplicações ASP.NET Core:

1. **Autenticação e Autorização:** Usar Identity, JWT ou outros provedores.  
2. **Validação de Entrada:** Prevenir injeção de script (XSS) e SQL injection.  
3. **Proteção de Dados:** Usar HTTPS, encriptação de dados sensíveis.  
4. **Política de Cookies e CSRF:** Usar antiforgery tokens.  
5. **Configurações Seguras:** Proteger chaves e segredos com serviços como Azure Key Vault.

Exemplo simples (forçar HTTPS):

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    // ...
}
```

---

## Específico do Framework

### 31. O que é MVC (Model-View-Controller)?

**Resposta:**  
MVC é um padrão de arquitetura que separa a aplicação em três componentes:

- **Model:** Regras de negócio e acesso aos dados.  
- **View:** Camada de apresentação (UI).  
- **Controller:** Recebe entradas do usuário e coordena as interações entre Model e View.

Exemplo de um Controller básico:

```csharp
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
```

---

### 32. Você pode explicar a diferença entre Razor Pages e MVC no ASP.NET Core?

**Resposta:**  
- **MVC:** Usa Controllers para lidar com solicitações; cada Controller pode ter várias Actions.  
- **Razor Pages:** É mais focado em páginas, cada página tem seu próprio modelo de página (PageModel) com métodos `OnGet`, `OnPost`, etc. Ideal para aplicativos menores ou com abordagem orientada a páginas.

Exemplo de Razor Page:

```csharp
public class IndexModel : PageModel
{
    public void OnGet()
    {
        // Lógica de GET
    }
}
```

---

### 33. Como fazer validações no ASP.NET Core?

**Resposta:**  
ASP.NET Core suporta validação com **Data Annotations** e também com **Fluent Validation**. As Data Annotations são atributos aplicados às propriedades do modelo, como `[Required]`, `[Range]`, `[EmailAddress]` etc.

Exemplo:

```csharp
public class UserModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}
```

---

### 34. Descreva o SignalR e seus casos de uso.

**Resposta:**  
SignalR é uma biblioteca em tempo real para ASP.NET Core que usa transporte via WebSockets (ou fallback) para permitir comunicação bidirecional entre servidor e cliente. Casos de uso incluem:

- Aplicativos de chat em tempo real.  
- Dashboards com atualização em tempo real.  
- Colaboração multiusuário (documentos colaborativos).

Exemplo de Hub:

```csharp
public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
```

---

### 35. Quais são os benefícios de usar Blazor em vez de tecnologias web tradicionais?

**Resposta:**  
- **Código em C#:** Permite reusar lógica de .NET no frontend em vez de JavaScript.  
- **Ecossistema .NET:** Compartilhamento de bibliotecas e código.  
- **Renderização no lado do cliente (WebAssembly) ou servidor:** Flexibilidade de implantação.  
- **Produtividade:** Menos alternância entre C# e JS.

Exemplo simples de componente Blazor:

```csharp
@page "/counter"

<h3>Contador</h3>
<p>Valor: @count</p>
<button @onclick="IncrementCount">Incrementar</button>

@code {
    private int count = 0;
    private void IncrementCount() => count++;
}
```

---

### 36. Como implementar versionamento de Web API no ASP.NET Core?

**Resposta:**  
Utiliza-se o pacote de **API Versioning** do ASP.NET Core (`Microsoft.AspNetCore.Mvc.Versioning`). Permite gerenciar diferentes versões via URL, cabeçalho ou query string.

```csharp
services.AddApiVersioning(o =>
{
    o.ReportApiVersions = true;
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
});
```

---

### 37. Explique o papel de IApplicationBuilder no ASP.NET Core.

**Resposta:**  
`IApplicationBuilder` configura o pipeline de requisições. Em `Startup.Configure()`, você encadeia middlewares com métodos de extensão como `UseRouting()`, `UseAuthorization()`, etc.

Exemplo:

```csharp
public void Configure(IApplicationBuilder app)
{
    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(endpoints => endpoints.MapControllers());
}
```

---

### 38. O que são Areas no ASP.NET Core e como você as utiliza?

**Resposta:**  
Areas ajudam a organizar uma aplicação MVC em módulos, agrupando Controllers, Views e Models relacionados. Útil em aplicações grandes. Para usar:

1. Criar pasta `Areas/Admin/Controllers`, `Areas/Admin/Views` etc.  
2. Marcar o controller com `[Area("Admin")]`.  
3. Incluir a área na rota (por exemplo, `/{area=Admin}/{controller=Home}/{action=Index}`).

Exemplo:

```csharp
[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index() => View();
}
```

---

### 39. Como gerenciar sessões em aplicações ASP.NET Core?

**Resposta:**  
ASP.NET Core oferece `ISession` para gerenciar dados de sessão. É preciso configurar em `Startup`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSession();
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseSession();
    // ...
}
```

Uso:

```csharp
HttpContext.Session.SetString("User", "Admin");
string user = HttpContext.Session.GetString("User");
```

---

### 40. Descreva como implementar caching no ASP.NET Core.

**Resposta:**  
Há suporte para **Memory Cache** (em memória) e **Distributed Cache** (por exemplo, Redis). Para memória local:

```csharp
services.AddMemoryCache();

public class MyService
{
    private readonly IMemoryCache _cache;
    public MyService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public string GetData()
    {
        return _cache.GetOrCreate("cachedData", entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            return "Dados em cache";
        });
    }
}
```

---

## Testes e Melhores Práticas

### 41. O que é Teste Unitário (Unit Testing) em .NET?

**Resposta:**  
Teste unitário verifica partes específicas do código (métodos/classes) de forma isolada, garantindo que funcionem conforme esperado. Ferramentas comuns incluem MSTest, xUnit e NUnit.

Exemplo usando NUnit:

```csharp
[Test]
public void TestSum()
{
    int result = Calculator.Sum(2, 3);
    Assert.AreEqual(5, result);
}
```

---

### 42. Como simular (mock) dependências em testes unitários usando .NET?

**Resposta:**  
Utiliza-se bibliotecas como **Moq** para criar objetos falsos que simulam comportamentos de dependências:

```csharp
var mockRepo = new Mock<IRepository>();
mockRepo.Setup(repo => repo.GetData()).Returns("Mock Data");

// Injetar mock em classe que depende de IRepository
var service = new MyService(mockRepo.Object);
```

---

### 43. Você pode explicar os princípios SOLID?

**Resposta:**  
**SOLID** é um conjunto de princípios para escrever código mais limpo e sustentável:

1. **S**ingle Responsibility Principle (Responsabilidade Única)  
2. **O**pen/Closed Principle (Aberto para extensão, fechado para modificação)  
3. **L**iskov Substitution Principle (Subtipos devem ser substituíveis por seus tipos base)  
4. **I**nterface Segregation Principle (Muitas interfaces específicas em vez de uma interface geral)  
5. **D**ependency Inversion Principle (Depender de abstrações, não de implementações concretas)

---

### 44. O que é Integração Contínua/Implantação Contínua (CI/CD) e como se aplica ao desenvolvimento .NET?

**Resposta:**  
CI/CD é um conjunto de práticas que automatizam integração de código (build, testes) e implantação em produção. Isso assegura que cada commit seja testado e, se aprovado, possa ser implantado automaticamente, aumentando a velocidade e a confiabilidade no processo de desenvolvimento.

Exemplo de GitHub Actions:

```yaml
jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - name: Checkout Code
        uses: actions/checkout@v2
      - name: Build and Test
        run: dotnet test
```

---

### 45. Como você garante que seu código C# seja seguro?

**Resposta:**  
Boas práticas para segurança incluem:

- **Queries parametrizadas** para evitar SQL injection.  
- **Hash e salt de senhas** com algoritmos seguros (BCrypt, PBKDF2 etc.).  
- **Comunicação via HTTPS** para criptografar dados em trânsito.  
- **Validação de entrada** para evitar injeções de script (XSS).  
- **Gerenciamento de segredos** (não armazenar chaves em código; usar ferramentas como Azure Key Vault).

Exemplo de uso de parâmetro em SQL:

```csharp
using (SqlConnection conn = new SqlConnection("connectionString"))
{
    string query = "SELECT * FROM Users WHERE Id = @userId";
    using (SqlCommand cmd = new SqlCommand(query, conn))
    {
        cmd.Parameters.AddWithValue("@userId", userId);
        // ...
    }
}
```

---

### 46. Quais são alguns problemas comuns de desempenho em aplicações .NET e como você os resolve?

**Resposta:**  
Problemas comuns:

- **Vazamentos de memória:** Objetos não descartados corretamente.  
- **Consultas lentas:** Falta de otimização ou índices no banco.  
- **Excesso de alocação de objetos:** Pode gerar muita carga para o GC.  
- **Uso inadequado de I/O sincrono:** Pode bloquear threads.

Soluções:

- Usar `IDisposable` e `using` para liberar recursos.  
- Otimizar consultas e índices no banco.  
- Aplicar caching em áreas de acesso frequente.  
- Usar async/await para operações I/O.

Exemplo de caching:

```csharp
public class DataService
{
    private readonly IMemoryCache _cache;
    public DataService(IMemoryCache cache) => _cache = cache;

    public string GetData()
    {
        return _cache.GetOrCreate("cachedData", entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            return "Dados em cache";
        });
    }
}
```

---

### 47. Descreva o padrão de Repositório (Repository) e seus benefícios.

**Resposta:**  
O padrão de Repositório cria uma camada de abstração entre a lógica de negócio e a lógica de acesso a dados. Benefícios:

- **Separação de preocupações:** Acesso a dados fica isolado.  
- **Testabilidade:** Mais fácil criar mocks para testes unitários.  
- **Reutilização:** Lógica de acesso a dados centralizada.

Exemplo:

```csharp
public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();
    User GetUserById(int id);
}

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context) => _context = context;

    public IEnumerable<User> GetAllUsers() => _context.Users.ToList();
    public User GetUserById(int id) => _context.Users.Find(id);
}
```

---

### 48. Como você lida com migrações de banco de dados no Entity Framework?

**Resposta:**  
As migrações permitem evoluir o esquema do banco de dados mantendo os dados existentes. Os comandos comuns são:

1. **Criar migração:**
   ```shell
   dotnet ef migrations add InitialCreate
   ```
2. **Aplicar migração:**
   ```shell
   dotnet ef database update
   ```

---

### 49. Quais ferramentas você usa para depurar e fazer perfil (profiling) de aplicações .NET?

**Resposta:**  
Ferramentas populares incluem:

- **Visual Studio Debugger:** Depuração passo a passo.  
- **dotTrace:** Profiling de desempenho (CPU).  
- **BenchmarkDotNet:** Medir performance de trechos de código.  
- **dotMemory:** Detecção de vazamentos de memória.

Exemplo de BenchmarkDotNet:

```csharp
[MemoryDiagnoser]
public class PerformanceTests
{
    [Benchmark]
    public void TestMethod()
    {
        var list = new List<int>();
        for (int i = 0; i < 1000; i++)
        {
            list.Add(i);
        }
    }
}
```

---

### 50. Como você se mantém atualizado com as últimas tecnologias e práticas .NET?

**Resposta:**  
Algumas formas de se manter atualizado:

- **Acompanhar blogs oficiais da Microsoft (.NET Blog).**  
- **Participar de conferências e webinars** (por exemplo, .NET Conf, Microsoft Build).  
- **Comunidades online** (GitHub, Stack Overflow, Twitter).  
- **Estudar documentação oficial** e fazer projetos pessoais de prática.
