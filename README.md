# 🧩 .NET Interview Questions – Complete Study Guide

> **A comprehensive collection of 130 interview questions for .NET developers**
> Covering **Arrays**, **Lists**, **Trees**, and **General .NET / C# / SQL** — with clean C# implementations, multiple solutions per problem, and full complexity analysis.

---

## 📖 Table of Contents

- [Overview](#-overview)
- [What's Inside](#-whats-inside)
- [Question Categories at a Glance](#-question-categories-at-a-glance)
- [Interview Question Types](#-interview-question-types)
- [Arrays — 20 Questions](#-arrays--20-questions)
- [Lists — 20 Questions](#-listst--20-questions)
- [Trees — 20 Questions](#-trees--20-questions)
- [General .NET / C# / SQL — 70 Questions](#-general-net--c--sql--70-questions)
- [Repository Structure](#-repository-structure)
- [How to Use](#-how-to-use)
- [Probability of Being Asked](#-probability-of-being-asked)
- [Key Data Structures Comparison](#-key-data-structures-comparison)
- [Common Algorithm Patterns](#-common-algorithm-patterns)
- [Big-O Complexity Cheat Sheet](#-big-o-complexity-cheat-sheet)
- [Interview Tips and Strategy](#-interview-tips--strategy)
- [Coverage and Confidence](#-coverage--confidence)
- [Author Notes](#-author-notes)

---

## 🔎 Overview

This repository is built for **.NET interview preparation** and contains:

| Category | Questions | Format | Focus |
|----------|-----------|--------|-------|
| **Arrays** | 20 | C# class implementations | Algorithms, manipulation, searching, sorting |
| **List\<T\>** | 20 | C# class implementations | Collections, LINQ, dynamic data |
| **Trees** | 20 | C# class implementations | Recursion, BST, traversals, tree properties |
| **General .NET** | 70 | Q&A with code examples | Language fundamentals, frameworks, SQL, best practices |

**Total: 130 interview questions** covering the most commonly asked topics in .NET coding interviews — from junior to mid-senior level.

---

## 📦 What's Inside

Every coding question (Arrays, Lists, Trees) includes:

- ✅ **Problem explanation** in the class summary
- ✅ **2–3 solutions** per problem (brute force → optimal)
- ✅ **Time & space complexity** analysis for each approach
- ✅ **Clean, commented C# code** ready to run
- ✅ **Edge case discussion** (empty inputs, nulls, duplicates, negatives)

The General .NET section provides:

- ✅ **Detailed answers** to conceptual and framework questions
- ✅ **Code examples** demonstrating key concepts
- ✅ **Coverage of Basic → Intermediate → Advanced → Framework-Specific → Testing & Best Practices → SQL**

---

## 🗂 Question Categories at a Glance

```
Interview Questions
│
├── 📁 Arrays (20 questions)
│   ├── Reversal, rotation, searching
│   ├── Frequency counting, duplicates
│   ├── Subarray problems (Kadane's, max product)
│   ├── Binary search, sorting, shuffling
│   └── Conceptual (jagged vs multidimensional, resize)
│
├── 📁 Lists (20 questions)
│   ├── Duplicates, sorting, reversing
│   ├── Merging, splitting, flattening
│   ├── Searching, frequency counting
│   ├── Contiguous sums, move zeros
│   └── Equality comparison, chunking
│
├── 📁 Trees (20 questions)
│   ├── DFS & BFS traversals
│   ├── Depth, balance, symmetry checks
│   ├── BST operations (insert, search, validate)
│   ├── Path sums, diameter, LCA
│   └── Serialize/deserialize, build from data
│
└── 📁 General .NET / C# / SQL (70 questions)
    ├── Basic (Q1–Q10): CLR, types, GC, namespaces
    ├── Intermediate (Q11–Q20): Polymorphism, LINQ, async/await
    ├── Advanced (Q21–Q30): Reflection, DI, middleware
    ├── Framework (Q31–Q40): MVC, Blazor, SignalR, caching
    ├── Testing (Q41–Q50): Unit testing, SOLID, CI/CD
    └── SQL (Q51–Q70): Joins, indexes, normalization, security
```

---

## 🎯 Interview Question Types

Understanding the **types of questions** you'll face helps you prepare strategically:

### 1. 🧠 Data Structure & Algorithm (DSA) Questions
> *""Write a function that...""*

These require you to **code a solution** on the spot. They test:
- Problem decomposition
- Algorithm design (brute force → optimized)
- Big-O analysis
- Edge case handling

**Covered by:** Arrays (20), Lists (20), Trees (20) sections

### 2. 💬 Conceptual / Theoretical Questions
> *""Explain the difference between...""*

These test your **understanding of language and platform fundamentals**:
- Value types vs. reference types
- Abstract class vs. interface
- Managed vs. unmanaged code
- Garbage collection internals

**Covered by:** General .NET (Q1–Q30)

### 3. 🏗 Framework & Architecture Questions
> *""How would you implement...""*

These test your **practical knowledge** of .NET ecosystem tools:
- ASP.NET Core middleware pipeline
- Entity Framework and ORM patterns
- Dependency Injection
- SignalR, Blazor, Web API versioning

**Covered by:** General .NET (Q31–Q40)

### 4. ✅ Testing & Best Practices Questions
> *""How do you ensure code quality...""*

These assess your **engineering maturity**:
- Unit testing and mocking
- SOLID principles
- Repository pattern
- CI/CD pipelines

**Covered by:** General .NET (Q41–Q50)

### 5. 🗄 SQL & Database Questions
> *""What is the difference between...""*

These test your **data layer knowledge**:
- JOINs, indexes, normalization
- Transactions and ACID properties
- Query optimization
- SQL injection prevention

**Covered by:** General .NET — SQL (Q51–Q70)

---

## 📚 Arrays — 20 Questions

Arrays are **one of the first topics in any coding interview** because they test fundamental problem-solving, loops, conditions, indexes, and serve as a basis for hashing, sorting, and algorithm design.

| # | Question | Key Concepts | File |
|---|----------|-------------|------|
| 1 | Array vs ArrayList vs List\<T\> | Type safety, generics, performance | `Array_ArrayList_List.cs` |
| 2 | Reverse an array | Two-pointer, in-place | `ReverseArray.cs` |
| 3 | Maximum product subarray | Dynamic programming, tracking min/max | `MaxProductSubarray.cs` |
| 4 | Remove duplicates from an array | HashSet, sorting | `RemoveDuplicates.cs` |
| 5 | Find the missing number (1 to N) | Sum formula, XOR | `FindMissingNumber.cs` |
| 6 | Find intersection of two arrays | HashSet, two-pointer | `FindIntersection.cs` |
| 7 | First non-repeating element | Dictionary, frequency counting | `FirstNonRepeatingElement.cs` |
| 8 | Rotate array by K steps | Reversal algorithm, modular | `RotateArray.cs` |
| 9 | Check if array is a palindrome | Two-pointer | `CheckPalindromeArray.cs` |
| 10 | Flatten a 2D array | Nested iteration, LINQ | `Flatten2DArray.cs` |
| 11 | Find majority element (> n/2) | Boyer-Moore voting | `MajorityElementFinder.cs` |
| 12 | Find all pairs with a given sum | HashSet, two-pointer | `FindPairsWithSum.cs` |
| 13 | Binary search | Iterative, recursive | `BinarySearchArray.cs` |
| 14 | Maximum subarray sum (Kadane's) | Dynamic programming | `MaxSubarraySum.cs` |
| 15 | Element frequency counter | Dictionary, LINQ GroupBy | `ElementFrequencyCounter.cs` |
| 16 | Jagged vs multidimensional arrays | Memory layout, performance | `JaggedVsMultidimensionalArray.cs` |
| 17 | Shuffle an array (Fisher-Yates) | Randomization, in-place | `ShuffleArray.cs` |
| 18 | Resize an array in C# | Array.Resize, copying | `ResizeArray.cs` |
| 19 | Sort custom objects | IComparer, LINQ OrderBy | `SortCustomObjects.cs` |
| 20 | Array operations time complexity | O(1) access, O(n) search | Conceptual |

---

## 📚 List\<T\> — 20 Questions

`List<T>` is the **most commonly used collection in .NET**, offering dynamic resizing, type safety with generics, and integration with LINQ.

| # | Question | Key Concepts | File |
|---|----------|-------------|------|
| 1 | Remove duplicates | HashSet, LINQ Distinct | `RemoveDuplicates.cs` |
| 2 | Find second largest element | Single-pass, sorting | `FindSecondLargest.cs` |
| 3 | Reverse a list | In-place, LINQ | `ReverseList.cs` |
| 4 | Sort a list (multiple approaches) | IComparer, LINQ, custom | `SortList.cs` |
| 5 | Element frequency counter | Dictionary, LINQ GroupBy | `ElementFrequencyCounter.cs` |
| 6 | Find common elements (intersection) | HashSet, LINQ Intersect | `FindCommonElements.cs` |
| 7 | Merge two sorted lists | Two-pointer merge | `MergeTwoLists.cs` |
| 8 | Find missing numbers in a range | HashSet, sequential check | `FindMissingNumbers.cs` |
| 9 | Rotate a list by K positions | Slice and concat, reversal | `RotateList.cs` |
| 10 | Shuffle a list (Fisher-Yates) | Randomization | `ShuffleList.cs` |
| 11 | Check if list is a palindrome | Two-pointer | `CheckPalindromeList.cs` |
| 12 | First non-repeating element | Dictionary, ordered scan | `FirstNonRepeatingElement.cs` |
| 13 | Group duplicate elements | Dictionary, LINQ GroupBy | `GroupDuplicates.cs` |
| 14 | Remove all occurrences of a value | RemoveAll, LINQ | `RemoveAllOccurrences.cs` |
| 15 | Find all pairs with a given sum | HashSet, brute force | `FindPairsWithSum.cs` |
| 16 | Split list into chunks | LINQ Chunk, manual slicing | `SplitListIntoChunks.cs` |
| 17 | Flatten nested lists | Recursion, SelectMany | `FlattenNestedLists.cs` |
| 18 | Max contiguous subarray sum | Kadane's algorithm | `MaxContiguousSum.cs` |
| 19 | Move all zeros to end | Two-pointer, partition | `MoveZerosToEnd.cs` |
| 20 | Compare list equality | SequenceEqual, set comparison | `CompareListEquality.cs` |

---

## 📚 Trees — 20 Questions

Trees test **recursive thinking**, **divide-and-conquer**, and appear in real-world applications like file systems, org charts, and DOM trees.

### 🌳 Tree Node Model

All binary tree problems share a minimal `TreeNode` class:

```csharp
public class TreeNode
{
    public int Value { get; set; }
    public TreeNode? Left { get; set; }
    public TreeNode? Right { get; set; }

    public TreeNode(int value) { Value = value; }
}
```

| # | Question | Key Concepts | File |
|---|----------|-------------|------|
| 1 | Depth-first traversal (pre/in/post) | Recursion, stack-based iterative | `DepthFirstTraversal.cs` |
| 2 | Breadth-first / level order traversal | Queue, BFS | `BreadthFirstTraversal.cs` |
| 3 | Maximum depth of binary tree | Recursion, DFS | `MaximumDepth.cs` |
| 4 | Minimum depth of binary tree | BFS (optimal), recursion | `MinimumDepth.cs` |
| 5 | Check if tree is balanced | Height comparison, DFS | `CheckBalancedTree.cs` |
| 6 | Check if two trees are identical | Recursive compare | `CheckIdenticalTrees.cs` |
| 7 | Invert (mirror) a binary tree | Recursive swap, BFS | `InvertBinaryTree.cs` |
| 8 | Validate BST | In-order check, min/max bounds | `ValidateBST.cs` |
| 9 | Search in a BST | Recursive, iterative | `SearchBST.cs` |
| 10 | Insert into a BST | Recursive, iterative | `InsertIntoBST.cs` |
| 11 | Find min/max in BST | Leftmost/rightmost node | `FindMinMaxBST.cs` |
| 12 | Lowest common ancestor | BST property, general tree | `LowestCommonAncestor.cs` |
| 13 | Diameter of binary tree | DFS, height tracking | `DiameterOfBinaryTree.cs` |
| 14 | Check if tree is symmetric | Mirror comparison | `CheckSymmetricTree.cs` |
| 15 | Serialize / deserialize tree | BFS, pre-order string | `SerializeDeserializeTree.cs` |
| 16 | Path sum (root-to-leaf = target) | DFS, backtracking | `PathSum.cs` |
| 17 | All root-to-leaf paths | DFS, path building | `RootToLeafPaths.cs` |
| 18 | Count total nodes & leaf nodes | Recursion, BFS | `CountNodes.cs` |
| 19 | Kth smallest in BST | In-order traversal | `KthSmallestInBST.cs` |
| 20 | Build tree from relationships | N-ary tree, org chart | `BuildTreeFromRelationships.cs` |

---

## 📚 General .NET / C# / SQL — 70 Questions

These conceptual questions cover the **.NET platform, C# language, ASP.NET Core framework, testing, and SQL** — essential for the non-coding portion of interviews.

### Basic (Q1–Q10)
| # | Question |
|---|----------|
| 1 | What is .NET? |
| 2 | Can you explain the Common Language Runtime (CLR)? |
| 3 | What is the difference between managed and unmanaged code? |
| 4 | Explain the basic structure of a C# program |
| 5 | What are Value Types and Reference Types in C#? |
| 6 | What is garbage collection in .NET? |
| 7 | Explain exception handling in C# |
| 8 | What are the different types of classes in C#? |
| 9 | What is a namespace and how is it used? |
| 10 | What is encapsulation? |

### Intermediate (Q11–Q20)
| # | Question |
|---|----------|
| 11 | Explain polymorphism and its types in C# |
| 12 | What are delegates and how are they used? |
| 13 | What is LINQ? Give an example |
| 14 | Abstract class vs interface — what's the difference? |
| 15 | How do you manage memory in .NET? |
| 16 | Explain threading in .NET |
| 17 | What is async/await and how does it work? |
| 18 | Describe Entity Framework and its advantages |
| 19 | What are extension methods? |
| 20 | How do you handle exceptions in a Task-returning method? |

### Advanced (Q21–Q30)
| # | Question |
|---|----------|
| 21 | What is reflection in .NET? |
| 22 | Explain middleware in ASP.NET Core |
| 23 | Describe Dependency Injection in .NET Core |
| 24 | What is the purpose of .NET Standard? |
| 25 | Differences: .NET Core vs .NET Framework vs Xamarin |
| 26 | How does GC work and how to optimize it? |
| 27 | What are attributes in C#? |
| 28 | Describe code compilation in .NET |
| 29 | What is the Global Assembly Cache (GAC)? |
| 30 | How to secure a web app in ASP.NET Core? |

### Framework-Specific (Q31–Q40)
| # | Question |
|---|----------|
| 31 | What is MVC? |
| 32 | Razor Pages vs MVC in ASP.NET Core |
| 33 | How to perform validations in ASP.NET Core? |
| 34 | Describe SignalR and its use cases |
| 35 | Benefits of Blazor over traditional web technologies |
| 36 | Web API versioning in ASP.NET Core |
| 37 | Role of IApplicationBuilder |
| 38 | What are Areas in ASP.NET Core? |
| 39 | Session management in ASP.NET Core |
| 40 | Implementing caching in ASP.NET Core |

### Testing & Best Practices (Q41–Q50)
| # | Question |
|---|----------|
| 41 | What is Unit Testing in .NET? |
| 42 | How to mock dependencies in unit tests? |
| 43 | Explain SOLID principles |
| 44 | What is CI/CD and how does it apply to .NET? |
| 45 | How to ensure C# code is secure? |
| 46 | Common .NET performance issues and solutions |
| 47 | Describe the Repository pattern |
| 48 | Database migrations in Entity Framework |
| 49 | Tools for debugging and profiling .NET apps |
| 50 | How to stay updated with .NET technologies? |

### SQL (Q51–Q70)
| # | Question |
|---|----------|
| 51 | INNER JOIN vs LEFT JOIN vs RIGHT JOIN vs FULL JOIN |
| 52 | Primary key vs unique key |
| 53 | Foreign keys and referential integrity |
| 54 | Normalization and normal forms |
| 55 | Clustered vs non-clustered index |
| 56 | Transactions and ACID properties |
| 57 | DELETE vs TRUNCATE vs DROP |
| 58 | Window functions in SQL |
| 59 | CTE vs subquery |
| 60 | Stored procedures — pros and cons |
| 61 | Detecting and preventing SQL injection |
| 62 | EXISTS vs IN operators |
| 63 | Indexing and identifying slow queries |
| 64 | EXPLAIN / QUERY PLAN statement |
| 65 | Aggregate functions, GROUP BY, HAVING |
| 66 | Composite keys |
| 67 | Materialized views vs regular views |
| 68 | Handling NULL values |
| 69 | Scalar functions vs table-valued functions |
| 70 | Schema design for multi-tenant applications |

---

## 📂 Repository Structure

```
InterviewQuestions/
│
├── InterviewQuestions.sln                 # Solution file
├── README.md                              # 📌 This file — global documentation
│
├── Arrays/                                # 20 array coding questions
│   ├── Program.cs
│   ├── Arrays.csproj
│   ├── ReverseArray.cs
│   ├── RotateArray.cs
│   ├── FindMissingNumber.cs
│   ├── MaxSubarraySum.cs
│   ├── ... (20 question files)
│   └── README.md                          # Array-specific guide
│
├── Lists/                                 # 20 List<T> coding questions
│   ├── Program.cs
│   ├── Lists.csproj
│   ├── RemoveDuplicates.cs
│   ├── MergeTwoLists.cs
│   ├── ... (20 question files)
│   └── README.md                          # List-specific guide
│
├── Trees/                                 # 20 tree coding questions
│   ├── Program.cs
│   ├── Trees.csproj
│   ├── TreeNode.cs                        # Shared node model
│   ├── DepthFirstTraversal.cs
│   ├── ValidateBST.cs
│   ├── ... (20 question files)
│   └── README.md                          # Tree-specific guide
│
└── dotnet_interview_questions-main/       # 70 conceptual .NET/C#/SQL Q&A
    └── README.md
```

Each coding question file is a **self-contained class** that:
- Explains the problem in the class summary
- Provides **2–3 solutions** (from brute force to optimal)
- Documents time and space complexity

---

## ⚡ How to Use

### Prerequisites
- **.NET 8 SDK** (or later)
- **Visual Studio 2022** / **Rider** / **VS Code with C# Dev Kit**

### Getting Started

1. **Clone the repository** and open `InterviewQuestions.sln`
2. Pick a topic folder: `Arrays/`, `Lists/`, or `Trees/`
3. Open any question file → read the **class summary** for the problem statement
4. Study solutions **in order** — they evolve from brute force to optimal
5. Uncomment usage examples in `Program.cs` or write your own to test
6. For conceptual questions, read `dotnet_interview_questions-main/README.md`

### Recommended Study Order

```
1. Arrays (foundation)      → Lists (builds on arrays)
2. Trees (recursive thinking)
3. General .NET Basics       → Intermediate → Advanced
4. Framework-Specific & SQL  → Testing & Best Practices
```

---

## 📊 Probability of Being Asked

### Coding Questions (Arrays / Lists / Trees)

| Priority | Likelihood | Topics |
|----------|-----------|--------|
| 🔴 **High** | **70–80%** | Reverse, Rotate, Missing Number, Remove Duplicates, First Non-Repeating, Palindrome, Max Subarray Sum, Pairs with Sum, Frequency Counting, DFS/BFS Traversals, Max Depth, Validate BST, Invert Tree, LCA, Balanced Tree |
| 🟡 **Medium** | **40–50%** | Max Product Subarray, Flatten, Merge Lists, Majority Element, Move Zeros, Binary Search, Diameter, Serialize/Deserialize, Kth Smallest, Split Chunks |
| 🟢 **Low** | **20–30%** | Jagged vs Multidimensional, Resize Array, Sort Custom Objects, Shuffle, Group Duplicates, Build Tree from Relationships |

### Conceptual Questions

| Priority | Likelihood | Topics |
|----------|-----------|--------|
| 🔴 **High** | **80–90%** | Value vs Reference types, async/await, SOLID, abstract vs interface, DI, GC, exception handling |
| 🟡 **Medium** | **50–60%** | LINQ, delegates, EF, threading, middleware, MVC, unit testing |
| 🟢 **Low** | **30–40%** | Reflection, GAC, .NET Standard, Blazor, Areas, SignalR |

💡 **Tip:** Focus on **🔴 High priority** questions first if preparing under time constraints.

---

## ⚖ Key Data Structures Comparison

| Feature | Array | List\<T\> | Binary Tree | BST |
|---------|-------|-----------|-------------|-----|
| **Access by index** | O(1) | O(1) | O(n) | O(n) |
| **Search** | O(n) | O(n) | O(n) | O(log n)* |
| **Insert (end)** | O(n)† | O(1)‡ | O(n) | O(log n)* |
| **Delete** | O(n) | O(n) | O(n) | O(log n)* |
| **Memory** | Contiguous | Contiguous | Nodes + pointers | Nodes + pointers |
| **Resizable** | ❌ | ✅ | ✅ | ✅ |
| **Ordered** | By index | By index | By structure | By value |

\* Average case for balanced BST; worst case is O(n) for skewed trees.
† Requires creating a new array.
‡ Amortized O(1); O(n) when internal array resizes.

---

## 🔄 Common Algorithm Patterns

These patterns appear repeatedly across all question types:

| Pattern | Description | Used In |
|---------|-------------|---------|
| **Two Pointers** | Start/end pointers moving inward | Reverse, Palindrome, Pairs with Sum, Remove Duplicates |
| **Sliding Window** | Fixed or variable window over data | Max Subarray Sum, Max Product |
| **Hash Map / Set** | O(1) lookups for frequency, existence | Frequency Counter, Missing Number, Intersection, Pairs |
| **Sorting + Scan** | Sort first, then linear scan | Remove Duplicates, Find Common, Merge |
| **Kadane's Algorithm** | Track running max/min subarray | Max Subarray Sum, Max Contiguous Sum |
| **Boyer-Moore Voting** | Find majority element in O(n)/O(1) | Majority Element |
| **Recursion / DFS** | Explore all branches depth-first | All tree problems, Flatten Nested |
| **BFS / Level Order** | Explore level by level | Breadth-first, Min Depth, Symmetric |
| **Binary Search** | Divide search space in half | Binary Search, Search BST |
| **Divide & Conquer** | Split problem, solve halves, merge | Max Subarray (alternative), Tree depth |
| **Backtracking** | Explore + undo for path finding | Path Sum, Root-to-Leaf Paths |

---

## 📈 Big-O Complexity Cheat Sheet

| Complexity | Name | Example |
|-----------|------|---------|
| **O(1)** | Constant | Array access by index, hash lookup |
| **O(log n)** | Logarithmic | Binary search, balanced BST operations |
| **O(n)** | Linear | Single pass through array/list, DFS/BFS |
| **O(n log n)** | Linearithmic | Efficient sorting (MergeSort, LINQ OrderBy) |
| **O(n²)** | Quadratic | Nested loops (brute force pairs, bubble sort) |
| **O(2ⁿ)** | Exponential | Recursive subsets, naive tree problems |

**Space complexity** matters too:
- **O(1)** = in-place (two-pointer, swapping)
- **O(n)** = extra array, hash set, recursion stack
- **O(h)** = tree recursion depth (h = height)

---

## 💡 Interview Tips & Strategy

### Before the Interview
- ✅ **Master the top 15 high-priority questions** across all categories
- ✅ Know at least **2 approaches** per problem (brute force + optimized)
- ✅ Practice explaining your **thought process out loud**
- ✅ Review **Big-O analysis** — interviewers always ask about complexity

### During the Interview
1. **Clarify the problem** — ask about constraints, edge cases, input size
2. **Start with brute force** — show your thinking, then optimize
3. **Explain as you code** — narrate your approach and trade-offs
4. **Test with examples** — walk through your code with sample input
5. **Discuss trade-offs** — time vs. space, readability vs. performance

### Edge Cases to Always Mention
| Data Structure | Edge Cases |
|----------------|------------|
| **Arrays / Lists** | Empty, single element, all duplicates, negative numbers, already sorted |
| **Trees** | Null root, single node, skewed (all left/right), very deep |
| **General** | Null/empty inputs, integer overflow, concurrent access |

### Optimization Progression
```
Brute Force (O(n²))
    → Sorting + Scan (O(n log n))
        → Hash Map (O(n) time, O(n) space)
            → Two Pointers / In-place (O(n) time, O(1) space)
```

---

## 📊 Coverage & Confidence

| If you master... | You get... |
|------------------|-----------|
| All 20 Array questions | **~90%** coverage of array coding interviews |
| All 20 List questions | **~90%** coverage of List\<T\> coding interviews |
| All 20 Tree questions | **~90%** coverage of tree coding interviews |
| All 70 .NET/C#/SQL questions | Strong foundation for conceptual rounds |
| **Everything combined** | **Ready for junior to mid-senior .NET interviews** |

Each coding problem is also excellent practice for **LeetCode Easy/Medium** problems.

---

## ✅ Author Notes

This collection is built for **.NET interview preparation**:

- Uses **C# 10+ syntax**
- Follows **clean coding practices**
- May avoid the newest C# features (like `[]` array initialization) for easier understanding
- Demonstrates **progressive optimization** (brute force → optimal)
- Each file is **self-contained** — no dependencies between question files

**If you practice all questions and understand the optimizations, you will handle the vast majority of .NET coding interview questions with confidence.**
