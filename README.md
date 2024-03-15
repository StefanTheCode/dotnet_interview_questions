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
