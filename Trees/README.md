# 🧩 .NET Tree Interview Questions – Complete Guide

This repository contains **20 essential tree interview questions** for **.NET developers**.  
Each question comes with:  

- ✅ **Explanation** of the problem  
- ✅ **Multiple solutions** (recursive, iterative, and optimized)  
- ✅ **Performance analysis** (time & space complexity)  
- ✅ **Clean, commented C# class implementation**  

If an interviewer asks about **trees**, mastering these **20 questions** gives you **~90% coverage** of what's commonly asked in coding interviews.

---

## 📌 Why Trees?

Trees are **one of the most important data structures in coding interviews** because they:

1. Test **recursive thinking** and **divide-and-conquer** skills  
2. Cover **hierarchical data** found in real applications (org charts, file systems, menus)  
3. Include **Binary Search Trees** which combine searching, sorting, and tree traversal  
4. Appear in **system design** questions (DOM trees, category hierarchies, routing tables)  

Common tasks include **traversals, depth calculations, validation, path problems, and building trees from data**.

---

## 🎯 Probability of Being Asked

| Priority | Questions | Example Problems | Likelihood |
|---------|-----------|-----------------|-----------|
| **High** | DFS Traversals, BFS/Level Order, Max Depth, Validate BST, Invert Tree, LCA, Path Sum, Balanced Tree, Symmetric Tree | "Invert a binary tree", "Validate BST", "Find max depth" | **70–80%** |
| **Medium** | Min Depth, Insert/Search BST, Diameter, Serialize/Deserialize, Kth Smallest in BST, Root-to-Leaf Paths, Count Nodes | "Find kth smallest in BST", "Serialize a tree" | **40–50%** |
| **Low** | Find Min/Max in BST, Build Tree From Relationships, Zigzag Traversal | "Build an org chart from parent-child data" | **20–30%** |

💡 **Tip:**  
Focus on the **high priority questions first** if preparing under time constraints.

---

## 📂 Repository Structure

TreeInterviewQuestions/
│
├── TreeNode.cs                      (shared node model)
│
├── Q01_DepthFirstTraversal.cs
├── Q02_BreadthFirstTraversal.cs
├── Q03_MaximumDepth.cs
├── Q04_MinimumDepth.cs
├── Q05_CheckBalancedTree.cs
├── Q06_CheckIdenticalTrees.cs
├── Q07_InvertBinaryTree.cs
├── Q08_ValidateBST.cs
├── Q09_SearchBST.cs
├── Q10_InsertIntoBST.cs
├── Q11_FindMinMaxBST.cs
├── Q12_LowestCommonAncestor.cs
├── Q13_DiameterOfBinaryTree.cs
├── Q14_CheckSymmetricTree.cs
├── Q15_SerializeDeserializeTree.cs
├── Q16_PathSum.cs
├── Q17_RootToLeafPaths.cs
├── Q18_CountNodes.cs
├── Q19_KthSmallestInBST.cs
├── Q20_BuildTreeFromRelationships.cs
│
└── README.md


Each file is a **self-contained class** that:  
- Explains the problem in the class summary  
- Provides **2–3 solutions** (from brute force / recursive to optimal / iterative)  

---

## 🌳 Tree Node Model

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

Q20 (Build Tree from Relationships) introduces an `OrgNode` for N-ary trees — modeled as a real-world org chart / category tree.

---

## ⚡ How to Use

1. **Clone the repository** and open in **Visual Studio** or **Rider**.  
2. Open any question file, e.g., `Q07_InvertBinaryTree.cs`.  
3. Read the **class summary** for the problem statement.  
4. Check **solutions in order** to see the evolution from recursive to iterative to optimal.  
5. Build a small tree in a console app and call the methods to see results.  

**Example:**  
```csharp
var root = new TreeNode(4,
    new TreeNode(2, new TreeNode(1), new TreeNode(3)),
    new TreeNode(7, new TreeNode(6), new TreeNode(9)));

var depth = new MaximumDepth(root);
Console.WriteLine(depth.FindMaxDepthRecursive()); // 3
```

---

## 💡 Extra Interview Tips

- **Start with the recursive solution** — it's usually the most natural for trees.  
  - Interviewers want to see you **think recursively** first.  
- **Then offer the iterative version** to show you understand stacks/queues.  
- **Explain time and space complexity** of each approach.  
  - O(h) space for recursion, where h = tree height.  
  - O(n) space for BFS when the tree is wide.  
- **Mention edge cases**:  
  - Empty tree (null root)  
  - Single node tree  
  - Skewed tree (all left or all right children)  
  - Complete vs. sparse trees  
- **Know the difference** between:  
  - Binary Tree vs. Binary Search Tree  
  - Balanced vs. Unbalanced  
  - Complete vs. Full vs. Perfect trees  

---

## 📊 Coverage and Confidence

If you **master these 20 questions**:

- **90%** coverage of typical tree coding interviews  
- Strong understanding of **recursion, DFS, BFS, and BST operations**  
- Ready for **junior to mid-level .NET developer interviews**  
- Solid foundation for **LeetCode Easy/Medium tree problems**  

---

## 📚 Questions List

1. Depth-first traversal (preorder, inorder, postorder — recursive & iterative)  
2. Breadth-first traversal / level order traversal (flat, grouped, zigzag)  
3. Maximum depth of a binary tree  
4. Minimum depth of a binary tree  
5. Check if a binary tree is height-balanced  
6. Check if two binary trees are identical  
7. Invert (mirror) a binary tree  
8. Validate if a tree is a valid Binary Search Tree  
9. Search for a value in a BST  
10. Insert a value into a BST  
11. Find minimum and maximum value in a BST  
12. Lowest common ancestor (general tree + BST)  
13. Find the diameter of a binary tree  
14. Check if a binary tree is symmetric  
15. Serialize and deserialize a binary tree  
16. Path sum (does a root-to-leaf path equal a target?)  
17. Find all root-to-leaf paths  
18. Count total nodes and leaf nodes  
19. Find kth smallest element in a BST  
20. Build a tree from parent-child relationships (org chart / category tree)  
