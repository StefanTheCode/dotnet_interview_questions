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
