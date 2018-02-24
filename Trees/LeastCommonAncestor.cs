using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static Node parent;
    static bool areBothFound;   
    
    static void Main(String[] args) {
        var root = new Node(1);
        var node2 = new Node(2);
        var node3 = new Node(3);
        var node4 = new Node(4);
        var node5 = new Node(5);
        var node6 = new Node(6);
        var node7 = new Node(7);
        var node8 = new Node(8);

        root.Left = node2;
        root.Right = node3;
        node2.Left = node4;
        node2.Right = node5;
        node3.Right = node6;
        node5.Left = node7;  
        node5.Right = node8;
        
        var ancestor = GetLeastCommonAncestor(root, node7, node8);
        Console.WriteLine(ancestor.Value);

    }
    
    static Node GetLeastCommonAncestor(Node root, Node a, Node b)
    {
        DFS(root, a, b);
        return parent;
    }
    
    static void DFS(Node node, Node a, Node b)
    {
        if(parent != null)
        {
            if(node.Value == a.Value || node.Value == b.Value)
            {
                areBothFound = true;
                return;
            }
        }
        
        if(node.Value == a.Value || node.Value == b.Value)
        {
            parent = node;
        }
        
        if(node.Left != null)
        {
            DFS(node.Left, a, b);
        }

        if(areBothFound)
        {
            return;
        } 
        
       if(parent != null && 
          node.Left != null && node.Left.Value == parent.Value)
        {
            parent = node;
        }
        
        if(node.Right != null)
        {
            DFS(node.Right, a, b);
        }
        
        if(areBothFound)
        {
            return;
        } 
        
        if(parent != null && 
           node.Right != null && node.Right.Value == parent.Value)
        {
            parent = node;
        }
    }
    
    class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }
    }
}
