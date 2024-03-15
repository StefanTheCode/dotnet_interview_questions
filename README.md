# .NET (C#) Interview Questions and Answers

## Basic

### 1. What is .NET?

**Answer:** .NET is a comprehensive development platform used for building a wide variety of applications, including web, mobile, desktop, and gaming. It supports multiple programming languages, such as C#, F#, and Visual Basic. .NET provides a large class library called Framework Class Library (FCL) and runs on a Common Language Runtime (CLR) which offers services like memory management, security, and exception handling.

### 2. Can you explain the Common Language Runtime (CLR)?

**Answer:** The CLR is a virtual machine component of the .NET framework that manages the execution of .NET programs. It provides important services such as memory management, type safety, exception handling, garbage collection, and thread management. The CLR converts Intermediate Language (IL) code into native machine code through a process called Just-In-Time (JIT) compilation. This ensures that .NET applications can run on any device or platform that supports the .NET framework.

### 3. What is the difference between managed and unmanaged code?

**Answer:** Managed code is executed by the CLR, which provides services like garbage collection, exception handling, and type checking. It's called "managed" because the CLR manages a lot of the functionalities that developers would otherwise need to implement themselves. Unmanaged code, on the other hand, is executed directly by the operating system, and all memory allocation, type safety, and security must be handled by the programmer. Examples of unmanaged code include applications written in C or C++.

### 4. Explain the basic structure of a C# program.

**Answer:** A basic C# program consists of the following elements:

- **Namespace declaration:** A way to organize code and control the scope of classes and methods in larger projects.
- **Class declaration:** Defines a new type with data members (fields, properties) and function members (methods, constructors).
- **Main method:** The entry point for the program where execution begins and ends.
- **Statements and expressions:** Perform actions with variables, calling methods, looping through collections, etc.

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

### 5. What are Value Types and Reference Types in C#?

**Answer:** In C#, data types are divided into two categories: Value Types and Reference Types. This distinction affects how values are stored and manipulated within memory.

- **Value Types:** Store data directly and are allocated on the stack. This means that when you assign one value type to another, a direct copy of the value is created. Basic data types (`int`, `double`, `bool`, etc.) and structs are examples of value types. Operations on value types are generally faster due to stack allocation.

- **Reference Types:** Store a reference (or pointer) to the actual data, which is allocated on the heap. When you assign one reference type to another, both refer to the same object in memory; changes made through one reference are reflected in the other. Classes, arrays, delegates, and strings are examples of reference types.

Here's a simple example to illustrate the difference:

```csharp
// Value type example
int a = 10;
int b = a;
b = 20;
Console.WriteLine(a); // Output: 10
Console.WriteLine(b); // Output: 20

// Reference type example
var list1 = new List<int> { 1, 2, 3 };
var list2 = list1;
list2.Add(4);
Console.WriteLine(list1.Count); // Output: 4
Console.WriteLine(list2.Count); // Output: 4
```

In the value type example, changing b does not affect a because b is a separate copy. In the reference type example, list2 is not a separate copy; it's another reference to the same list object as list1, so changes made through list2 are visible when accessing list1.

### 6. What is garbage collection in .NET?

**Answer:** Garbage collection (GC) in .NET is an automatic memory management feature that frees up memory used by objects that are no longer accessible in the program. It eliminates the need for developers to manually release memory, thereby reducing memory leaks and other memory-related errors. The GC operates on a separate thread and works in three phases: marking, relocating, and compacting. During the marking phase, it identifies which objects in the heap are still in use. During the relocating phase, it updates the references to objects that will be compacted. Finally, during the compacting phase, it reclaims the space occupied by the garbage objects and compacts the remaining objects to make memory allocation more efficient.

### 7. Explain the concept of exception handling in C#.

**Answer:** Exception handling in C# is a mechanism to handle runtime errors, allowing a program to continue running or fail gracefully instead of crashing. It is done using the try, catch, and finally blocks. The try block contains code that might throw an exception, while catch blocks are used to handle the exception. The finally block contains code that is executed whether an exception is thrown or not, often for cleanup purposes.

```csharp
try {
    // Code that may cause an exception
    int divide = 10 / 0;
}
catch (DivideByZeroException ex) {
    // Code to handle the exception
    Console.WriteLine("Cannot divide by zero. Please try again.");
}
finally {
    // Code that executes after try/catch, regardless of an exception
    Console.WriteLine("Operation completed.");
}
```

### 8. What are the different types of classes in C#?

**Answer:** In C#, classes can be categorized based on their functionality and accessibility:

- **Static classes:** Cannot be instantiated and can only contain static members.
- **Sealed classes:** Cannot be inherited from.
- **Abstract classes:** Cannot be instantiated and are meant to be inherited from.
- **Partial classes:** Allow the splitting of a class definition across multiple files.
- **Generic classes:** Allow the definition of classes with placeholders for the type of its fields, methods, parameters, etc.

Each type serves different purposes in the context of object-oriented programming and design patterns.

### 9. Can you describe what a namespace is and how it is used in C#?

**Answer:** A namespace in C# is used to organize code into a hierarchical structure. It allows the grouping of logically related classes, structs, interfaces, enums, and delegates. Namespaces help avoid naming conflicts by qualifying the uniqueness of each type. For example, the `System` namespace in .NET includes classes for basic system operations, such as console input/output, file reading/writing, and data manipulation.

```csharp
using System;

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
```

In this example, the System namespace is used to access the Console class, and MyApplication is a custom namespace for organizing the application's code. Namespaces are essential for managing the scope of names in larger programming projects to avoid name collisions.

### 10. What is encapsulation?

**Answer:** Encapsulation is a fundamental principle of object-oriented programming (OOP) that involves bundling the data (attributes) and methods (operations) that operate on the data into a single unit, or class, and restricting access to the internals of that class. This is typically achieved through the use of access modifiers such as `private`, `public`, `protected`, and `internal`. Encapsulation helps to protect an object's internal state from unauthorized access and modification by external code, promoting data integrity and security.

Encapsulation allows the internal representation of an object to be hidden from the outside, only allowing access through a public interface. This concept is also known as data hiding. By controlling how data is accessed and modified, encapsulation helps to reduce complexity and increase reusability of code.

Here is a simple example demonstrating encapsulation in C#:

```csharp
public class Person
{
    private string name; // Private field, encapsulated data

    public string Name // Public property, access to the name field
    {
        get { return name; }
        set { name = value; }
    }

    public Person(string name) // Constructor
    {
        this.name = name;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person("John");
        Console.WriteLine(person.Name); // Accessing name through a public property
    }
}
```

In this example, the name field of the Person class is encapsulated and only accessible via the Name property. This approach allows the Person class to control how the name field is accessed and modified, ensuring that any rules or validations about the data can be applied within the class itself.

### 11. Explain polymorphism and its types in C#.

**Answer:** Polymorphism is a core concept in object-oriented programming (OOP) that allows objects to be treated as instances of their parent class rather than their actual derived class. This enables methods to perform different tasks based on the object that invokes them, enhancing flexibility and enabling code reusability. In C#, polymorphism can be implemented in two ways: static (compile-time) polymorphism and dynamic (runtime) polymorphism.

- **Static Polymorphism:** Achieved through method overloading and operator overloading. It allows multiple methods or operators with the same name but different parameters to coexist, with the specific method or operator being invoked determined at compile time based on the arguments passed.

- **Dynamic Polymorphism:** Achieved through method overriding. It allows a method in a derived class to have the same name and signature as a method in its base class, but with different implementation details. The method that gets executed is determined at runtime, depending on the type of the object.

Here's an example demonstrating both types of polymorphism in C#:

```csharp
// Static Polymorphism (Method Overloading)
public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}

// Dynamic Polymorphism (Method Overriding)
public class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("The animal speaks");
    }
}

public class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Calculator calc = new Calculator();
        Console.WriteLine(calc.Add(2, 3)); // Calls the first Add method
        Console.WriteLine(calc.Add(2, 3, 4)); // Calls the second Add method

        Animal myAnimal = new Animal();
        myAnimal.Speak(); // Output: The animal speaks

        Dog myDog = new Dog();
        myDog.Speak(); // Output: Dog barks

        Animal mySecondAnimal = new Dog();
        mySecondAnimal.Speak(); // Output: Dog barks, demonstrating dynamic polymorphism
    }
}
```

In the example above, the Calculator class demonstrates static polymorphism through method overloading, allowing the Add method to be called with different numbers of parameters. The Animal and Dog classes illustrate dynamic polymorphism, where the Speak method in the Dog class overrides the Speak method in its base class, Animal. The type of polymorphism used depends on the object reference at runtime, showcasing polymorphism's flexibility in OOP.

### 12. What are delegates and how are they used in C#?

**Answer:** Delegates in C# are type-safe function pointers or references to methods with a specific parameter list and return type. They allow methods to be passed as parameters, stored in variables, and returned by other methods, which enables flexible and extensible programming designs such as event handling and callback methods. Delegates are particularly useful in implementing the observer pattern and designing frameworks or components that need to notify other objects about events or changes without knowing the specifics of those objects.

There are three main types of delegates in C#:
- **Single-cast delegates:** Point to a single method at a time.
- **Multicast delegates:** Can point to multiple methods on a single invocation list.
- **Anonymous methods/Lambda expressions:** Allow inline methods or lambda expressions to be used wherever a delegate is expected.

Here is an example demonstrating the use of delegates in C#:

```csharp
public delegate void Operation(int num);

class Program
{
    static void Main(string[] args)
    {
        Operation op = Double;
        op(5);  // Output: 10

        op = Triple;
        op(5);  // Output: 15

        // Multicast delegate
        op = Double;
        op += Triple; // Combines Double and Triple methods
        op(5);  // Output: 10 followed by 15
    }

    static void Double(int num)
    {
        Console.WriteLine($"{num} * 2 = {num * 2}");
    }

    static void Triple(int num)
    {
        Console.WriteLine($"{num} * 3 = {num * 3}");
    }
}
```

In this example, the Operation delegate is defined to point to any method that accepts an int and returns void. Initially, op is set to the Double method, demonstrating a single-cast delegate. It is then reassigned to the Triple method, and finally, it is used as a multicast delegate to call both Double and Triple methods in sequence. This demonstrates how delegates in C# provide a flexible mechanism for method invocation and can be used to implement event handlers and callbacks.

### 13. Describe what LINQ is and give an example of where it might be used.

**Answer:** LINQ (Language Integrated Query) is a powerful feature in C# that allows developers to write expressive, readable code to query and manipulate data. It provides a uniform way to query various data sources, such as collections in memory, databases (via LINQ to SQL, LINQ to Entities), XML documents (LINQ to XML), and more. LINQ queries offer three main benefits: they are strongly typed, offer compile-time checking, and support IntelliSense, which enhances developer productivity and code maintainability.

LINQ can be used in a variety of scenarios, including filtering, sorting, and grouping data. It supports both method syntax and query syntax, providing flexibility in how queries are expressed.

Here is a simple example demonstrating LINQ with a list of integers:

```csharp
using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Use LINQ to find all even numbers
        var evenNumbers = from num in numbers
                          where num % 2 == 0
                          select num;

        Console.WriteLine("Even numbers:");
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
}
```

In this example, a LINQ query is used to filter a list of integers, selecting only the even numbers. The query is expressed using LINQ's query syntax, which closely resembles SQL in its readability and structure. This demonstrates how LINQ makes it easier to work with collections and other data sources by abstracting the complexity of different data manipulation operations.

### 14. What is the difference between an abstract class and an interface?

**Answer:** In C#, both abstract classes and interfaces are types that enable polymorphism, allowing objects of different classes to be treated as objects of a common super class. However, they serve different purposes and have different rules:

- **Abstract Class:**
  - Can contain implementation of methods, properties, fields, or events.
  - Can have access modifiers (public, protected, etc.).
  - A class can inherit from only one abstract class (single inheritance).
  - Can contain constructors.
  - Used when different implementations of objects have common methods or properties that can share a common implementation.

- **Interface:**
  - Cannot contain implementations, only declarations of methods, properties, events, or indexers.
  - Members of an interface are implicitly public.
  - A class or struct can implement multiple interfaces (multiple inheritance).
  - Cannot contain fields or constructors.
  - Used to define a contract for classes without imposing inheritance hierarchies.

Here is an example illustrating the use of an abstract class and an interface:

```csharp
public abstract class Animal
{
    public abstract void Eat();
    public void Sleep()
    {
        Console.WriteLine("Sleeping");
    }
}

public interface IMovable
{
    void Move();
}

public class Dog : Animal, IMovable
{
    public override void Eat()
    {
        Console.WriteLine("Dog is eating");
    }

    public void Move()
    {
        Console.WriteLine("Dog is running");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dog myDog = new Dog();
        myDog.Eat();
        myDog.Sleep();
        myDog.Move();
    }
}
```

In this example, Animal is an abstract class that provides a default implementation of the Sleep method and an abstract Eat method that must be overridden. IMovable is an interface that defines a contract with a Move method that must be implemented. Dog inherits from Animal and implements IMovable, thereby fulfilling both the contract defined by the interface and extending the functionality provided by the abstract class.

### 15. How do you manage memory in .NET applications?

**Answer:** Memory management in .NET applications is primarily handled automatically by the Garbage Collector (GC), which provides a high-level abstraction for memory allocation and deallocation, ensuring that developers do not need to manually free memory. However, understanding and cooperating with the GC can help improve your application's performance and memory usage. Here are key aspects of memory management in .NET:

- **Garbage Collection:** Automatically reclaims memory occupied by unreachable objects, freeing developers from manually deallocating memory and helping to avoid memory leaks.

- **Dispose Pattern:** Implementing the `IDisposable` interface and the `Dispose` method allows for the cleanup of unmanaged resources (such as file handles, database connections, etc.) that the GC cannot reclaim automatically.

- **Finalizers:** Can be defined in classes to perform cleanup operations before the object is collected by the GC. However, overuse of finalizers can negatively impact performance, as it makes objects live longer than necessary.

- **Using Statements:** A syntactic sugar for calling `Dispose` on IDisposable objects, ensuring that resources are freed as soon as they are no longer needed, even if exceptions are thrown.

- **Large Object Heap (LOH) Management:** Large objects are allocated on a separate heap, and knowing how to manage large object allocations can help reduce memory fragmentation and improve performance.

Here is an example demonstrating the use of the `IDisposable` interface and `using` statement for resource management:

```csharp
public class ResourceHolder : IDisposable
{
    private bool disposed = false;

    // Simulate an unmanaged resource.
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
                // Dispose managed resources.
            }

            // Free unmanaged resources
            Marshal.FreeHGlobal(unmanagedResource);
            disposed = true;
        }
    }

    ~ResourceHolder()
    {
        Dispose(false);
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (ResourceHolder holder = new ResourceHolder())
        {
            // Use the resource
        } // Automatic disposal here
    }
}
```

In this example, ResourceHolder implements IDisposable to properly manage both managed and unmanaged resources. The using statement ensures that Dispose is called automatically, providing a robust pattern for resource management in .NET applications.

### 16. Explain the concept of threading in .NET.

**Answer:** Threading in .NET allows for the execution of multiple operations simultaneously within the same process. It enables applications to perform background tasks, UI responsiveness, and parallel computations, improving overall application performance and efficiency. The .NET framework provides several ways to create and manage threads:

- **System.Threading.Thread:** A low-level approach to create and manage threads directly. This class offers fine-grained control over thread behavior.

- **ThreadPool:** A collection of worker threads maintained by the .NET runtime, offering efficient execution of short-lived background tasks without the overhead of creating individual threads for each task.

- **Task Parallel Library (TPL):** Provides a higher-level abstraction over threading, using tasks that represent asynchronous operations. TPL uses the ThreadPool internally and supports features like task chaining, cancellation, and continuation.

- **async and await:** Keywords that simplify asynchronous programming, making it easier to write asynchronous code that's as straightforward as synchronous code.

Here is an example demonstrating the use of the `System.Threading.Thread` class:

```csharp
using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Thread thread = new Thread(new ThreadStart(DoWork));
        thread.Start();

        Console.WriteLine("Main thread does some work, then waits.");
        thread.Join();
        Console.WriteLine("Background thread has completed. Main thread ends.");
    }

    static void DoWork()
    {
        Console.WriteLine("Background thread is working.");
        Thread.Sleep(1000); // Simulates doing work
        Console.WriteLine("Background thread has finished.");
    }
}
```

In this example, a new thread is created and started to execute the DoWork method in parallel to the main thread. The main thread then waits for the background thread to complete using the Join method before it proceeds to finish. This demonstrates the basic use of threading to perform operations concurrently.

Using threads can significantly improve the responsiveness and performance of your application but also introduces complexity, such as the need for thread synchronization to avoid race conditions and deadlocks. Proper understanding and careful management are essential when working with threads in .NET.

### 17. What is async/await and how does it work?

**Answer:** In C#, `async` and `await` are keywords that simplify writing asynchronous code, making it more readable and maintainable. This feature allows developers to perform non-blocking operations without the complex code traditionally associated with asynchronous programming, such as callbacks or manual thread management. The `async` modifier indicates that a method is asynchronous and may contain one or more `await` expressions. The `await` keyword is applied to a task, indicating that the method should pause until the awaited task completes, allowing other operations to run concurrently without blocking the main thread.

Key points about async/await:
- Improves application responsiveness, particularly important for UI applications where long-running operations can freeze the user interface.
- Enables server applications to handle more concurrent requests by freeing up threads while waiting for operations to complete.
- Simplifies error handling in asynchronous code with try-catch blocks.

Here's a simple example demonstrating async/await:

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

In this example, DownloadContentAsync is an asynchronous method that downloads content from a web address. It uses await to asynchronously wait for the HTTP request to complete without blocking the main thread. The Main method is also marked with async and awaits the completion of DownloadContentAsync. This approach keeps the application responsive, as the thread that started the operation can perform other work while waiting for the HTTP request to complete.

Async/await simplifies asynchronous programming by allowing developers to write code that's both easy to read and maintain, resembling synchronous code while providing the benefits of asynchronous execution.

### 18. Describe the Entity Framework and its advantages.

**Answer:** Entity Framework (EF) is an open-source object-relational mapping (ORM) framework for .NET. It enables developers to work with databases using .NET objects, eliminating the need for most of the data-access code that developers usually need to write. Entity Framework provides a high-level abstraction over database connections and operations, allowing developers to perform CRUD (Create, Read, Update, Delete) operations without having to deal with the underlying database SQL commands directly.

Advantages of using Entity Framework include:
- **Increased Productivity:** Automatically generates classes based on database schemas, reducing the amount of manual coding required for data access.
- **Maintainability:** Changes to the database schema can be easily propagated to the code through migrations, helping maintain code and database schema synchronicity.
- **Support for LINQ:** Enables developers to use LINQ queries to access and manipulate data, providing a type-safe way to query databases that integrates with the C# language.
- **Database Agnostic:** EF can work with various databases, including SQL Server, MySQL, Oracle, and more, by changing the database provider with minimal changes to the code.
- **Caching, Lazy Loading, Eager Loading:** Offers built-in support for caching, and configurable loading options like lazy loading and eager loading, improving application performance.

Here is a simple example demonstrating the use of Entity Framework to query a database:

```csharp
using System;
using System.Linq;
using System.Data.Entity;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
}

public class Blog
{
    public int BlogId { get; set; }
    public string Name { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        using (var db = new BloggingContext())
        {
            // Create and save a new Blog
            Console.Write("Enter a name for a new Blog: ");
            var name = Console.ReadLine();
            var blog = new Blog { Name = name };
            db.Blogs.Add(blog);
            db.SaveChanges();

            // Display all Blogs from the database
            var query = from b in db.Blogs
                        orderby b.Name
                        select b;

            Console.WriteLine("All blogs in the database:");
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
```

In this example, BloggingContext is the database context that manages the database connection and provides DbSet properties for querying and saving instances of the Blog class. The example demonstrates creating a new Blog instance, saving it to the database, and then querying and displaying all blogs. Entity Framework handles all the database interactions, allowing the developer to work at a higher level of abstraction.

Entity Framework significantly simplifies data access in .NET applications, making it an essential tool for rapid development while ensuring applications are maintainable and scalable.

### 19. What are extension methods and where would you use them?

**Answer:** Extension methods in C# allow developers to add new methods to existing types without modifying, deriving from, or recompiling the original types. They are static methods defined in a static class, but called as if they were instance methods on the extended type. Extension methods provide a flexible way to extend the functionality of a class or interface.

To use extension methods, the static class containing the extension method must be in scope, which usually requires a `using` directive for the namespace of the class.

Advantages of using extension methods include:
- Enhancing the functionality of third-party libraries or built-in .NET types without access to the original source code.
- Keeping code cleaner and more readable by encapsulating complex operations into methods.
- Facilitating a fluent interface style of coding, which can make code more expressive.

Here is a simple example demonstrating how to define and use an extension method:

```csharp
using System;

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        // Extension method for the String class
        public static string ToPascalCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string[] words = input.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }
            return string.Join("", words);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string title = "the quick-brown fox";
        string pascalCaseTitle = title.ToPascalCase();
        Console.WriteLine(pascalCaseTitle); // Outputs: TheQuickBrownFox
    }
}
```

In this example, ToPascalCase is an extension method defined for the String class. It converts a given string to Pascal case format. To use this extension method, simply call it on a string instance, as shown in the Main method. This demonstrates how extension methods can add useful functionality to existing types in a clean and natural syntax.

Extension methods are a powerful feature for extending the capabilities of types, especially when direct modifications to the class are not possible or desirable.

### 20. How do you handle exceptions in a method that returns a Task?

**Answer:** In asynchronous programming with C#, when a method returns a `Task` or `Task<T>`, exceptions should be handled within the task to avoid unhandled exceptions that can crash the application. Exceptions thrown in a task are captured and placed on the returned task object. To handle these exceptions, you can use a try-catch block within the asynchronous method, or you can inspect the task after it has completed for any exceptions.

There are several approaches to handle exceptions in tasks:

1. **Inside the Asynchronous Method:**
   Use a try-catch block inside the async method to catch exceptions directly.

```csharp
public async Task PerformOperationAsync()
{
    try
    {
        // Async operation that may throw an exception
    }
    catch (Exception ex)
    {
        // Handle exception
    }
}
```

1. When Awaiting the Task:
Await the task inside a try-catch block to catch exceptions when the task is awaited.

```csharp

try
{
    await PerformOperationAsync();
}
catch (Exception ex)
{
    // Handle exception
}
```
