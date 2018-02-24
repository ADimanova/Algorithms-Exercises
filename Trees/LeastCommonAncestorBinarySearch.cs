using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        var node4 = new Node(4);
        var node2 = new Node(2);
        var node1 = new Node(1);
        var node3 = new Node(3);
        var node6 = new Node(6);
        var node7 = new Node(7);
        
        node4.Left = node2;
        node4.Right = node7;
        node2.Left = node1;
        node2.Right = node3;
        node7.Left = node6;
        
        var node = FindCommonAncestor(node4, node2, node7);
        Console.WriteLine($"Ancestor: {node.Value}");
    }
    
    static Node FindCommonAncestor(Node n, Node a, Node b)
    {
        if(a.Value < n.Value && b.Value > n.Value || 
            a.Value > n.Value && b.Value < n.Value)
        {
            return n;
        }
        
        if(a.Value < n.Value) // same as b.Value < n.Value
        {
            return FindCommonAncestor(n.Left, a, b);
        }
        
        if(a.Value > n.Value) // same as b.Value < n.Value
        {
            return FindCommonAncestor(n.Right, a, b);
        }
        
        return null;
    }

    public class Node 
    {
        public Node(int value)
        {
            this.Value = value;
        }
        
        public int Value {get; set;}

        public Node Left {get; set;}
        
        public Node Right {get; set;}
    }
}
