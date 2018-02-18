using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static void Main(String[] args) {
        var arr = new int[] {3, 2, 1, 5, 4, 6}; // yes
        //var arr = new int[] {3, 4, 5, 1, 2}; // no
        //var arr = new int[] {1, 3, 4, 2}; // no
        
        var root = CreateTree(arr);
        //var result = TraverseTree(root);
        var result = TraverseTreeRecursion(root);
        
        PrintResult(arr, result);
    }
    
    static void PrintResult(int[] arr, int[] result)
    {
        for(var i = 0; i < arr.Length; i++)
        {
            if(arr[i] != result[i])
            {
                Console.WriteLine("No");
                return;
            }
        }
        
        Console.WriteLine("Yes");
    }
    
    static int[] TraverseTreeRecursion(Node root)
    {
        // init collection for results
        var result = new List<int>();
        TreeRecurs(root, result);
        
        return result.ToArray();
    }
    
    static void TreeRecurs(Node node, List<int> result)
    {
        // add node's value to result
        // if node has left child, TreeRecurs(Left)
        // if node has right child, TreeRecurs(Right)
        
        result.Add(node.Value);
        
        if(node.Left != null)
        {
            TreeRecurs(node.Left, result);
        }
        
        if(node.Right != null)
        {
            TreeRecurs(node.Right, result);
        }
    }
    
    static int[] TraverseTree(Node root)
    {
        // create colection to keep result
        // create stack to keep items
        // add root to stack
        // while items in stack
            // pop item and save it to result
            // put it's right child in stack then its left child
                // if no right child, continue
                // if no left child, continue
        
        var result = new List<int>();
        var stack = new Stack<Node>();
        stack.Push(root);
        while(stack.Count > 0)
        {
            var node = stack.Pop();
            result.Add(node.Value);
            
            if(node.Right != null)
            {
                stack.Push(node.Right);
            }
            
            if(node.Left != null)
            {
                stack.Push(node.Left);
            }
        }
        
        return result.ToArray();
    }
    
    static Node CreateTree(int[] arr)
    {
        var rootVal = arr[0];
        var root = new Node(rootVal);
        var areAllValid = true;
        for(var i = 1; i < arr.Length; i++)
        {
            var isValid = root.AddChild(arr[i]);
            if(!isValid)
            {
                areAllValid = false;
                Console.WriteLine("No");
                break;
            }
        }
        
        if(areAllValid)
        {
            Console.WriteLine("Yes");            
        }
        return root;
    }
    
    class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }
        
        public int Value {get; set;}
        
        public Node Left {get; set;}
        public Node Right {get; set;}
        
        public bool AddChild(int value)
        {
            // value < Value; goest to left
                // if Left is occupied 
                    // Left.AddChild(value)
                // else Left = value
            // value > Value; goes to right
                // if Right is occupied
                    // Right.AddChild(value)
                // else Right = value
            
            
            // if item has right child and the new value is smaller than this nodes value
            // the traversal will return a different result than the original array
            if(this.Right != null && value < this.Value)
            {
                return false;
            }
            
            if(value < this.Value)
            {
                if(this.Left != null)
                {
                    this.Left.AddChild(value);
                }
                else 
                {
                    this.Left = new Node(value);
                }
            }
            
            if(value > this.Value)
            {
                if(this.Right != null)
                {
                    this.Right.AddChild(value);
                }
                else 
                {
                    this.Right = new Node(value);
                }
            }
            
            return true;
        }
    }
}
