using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        var nodeA = new Node("A");        
        var nodeB = new Node("B");
        var nodeC = new Node("C");
        var nodeD = new Node("D");        
        var nodeE = new Node("E");
        var nodeF = new Node("F");

        nodeA.Children.Add(nodeB);
        nodeB.Children.Add(nodeC);
        nodeC.Children.Add(nodeD);
        nodeD.Children.Add(nodeE);
        nodeE.Children.Add(nodeF);
        nodeF.Children.Add(nodeC);
                
        var white = new Dictionary<string, Node>()
        { 
            { nodeA.Value, nodeA},
            { nodeB.Value, nodeB},
            { nodeC.Value, nodeC},
            { nodeD.Value, nodeD},
            { nodeE.Value, nodeE},
            { nodeF.Value, nodeF}
        };
        
        var grey = new Dictionary<string, Node>();
        
        var result = IsThereACycle(white, grey);
        if(result == null)
        {
            Console.WriteLine("No cycle detected.");
        }
        else
        {
            Console.WriteLine(string.Join(" ", result.Select(r => r.Value)));
        }
    }
    
    static List<Node> IsThereACycle(Dictionary<string, Node> white, Dictionary<string, Node> grey)
    {
        var path = new Stack<Node>();
        while(white.Any())
        {     
            var node = white.First();
            var cycleFound = IsThereACycleUtil(node.Value, white, grey, path);
            if(cycleFound)
            {
                return GetCycleNodes(path);
            }
        }                  
        
        return null;
    }
    
    static List<Node> GetCycleNodes(Stack<Node> stack)
    {
        var cycleNode = stack.Pop();
        var result = new List<Node>();
        result.Add(cycleNode);
        foreach(var n in stack)
        {
            result.Add(n);
            if(cycleNode == n)
            {
                return result;
            }
        }   
        
        return null;
    }
    
    static bool IsThereACycleUtil(Node node, Dictionary<string, Node> white, Dictionary<string, Node> grey,         Stack<Node> path)
    {
        //Console.WriteLine(node.Value);
        if(grey.ContainsKey(node.Value))
        {
            path.Push(node);
            return true;
        }
        
        if(!white.ContainsKey(node.Value))
        {
            return false;
        }

        white.Remove(node.Value);
        path.Push(node);
        grey.Add(node.Value, node);
        
        foreach(var child in node.Children)
        {
            var isCycle = IsThereACycleUtil(child, white, grey, path);
            if(isCycle)
            {
                return true;
            }
        }
        
        grey.Remove(node.Value);  
        path.Push(node);
        return false;
    }
    
    public class Node 
    {
        public Node(string value)
        {
            this.Value = value;
            this.Children = new List<Node>();
        }
        
        public string Value {get; set;}
        
        public List<Node> Children {get; set;}
    }
}
