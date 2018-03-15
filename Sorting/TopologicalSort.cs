using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {

    static void Main(string[] args) {
        var graph = new Graph();
        var n_0 = graph.AddNode("0");
        var n_1 = graph.AddNode("1");
        var n_2 = graph.AddNode("2");
        var n_3 = graph.AddNode("3");
        var n_4 = graph.AddNode("4");
        var n_5 = graph.AddNode("5");

        graph.AddEdge(n_5, n_2);
        graph.AddEdge(n_5, n_0);
        graph.AddEdge(n_4, n_0);
        graph.AddEdge(n_4, n_1);
        graph.AddEdge(n_2, n_3);
        graph.AddEdge(n_3, n_1);
        
        var sortedNodes = graph.TopologicalSort();
        foreach(var node in sortedNodes)
        {
            Console.Write($"{node.Name} ");
        }
    }
    
    public class Graph
    {
        public Graph()
        {           
            this.Nodes = new List<Node>();
        }
        
        public List<Node> Nodes { get; set; }
        
        public Node AddNode(string value)
        {
            var newNode = new Node(value);
            this.Nodes.Add(newNode);
            
            return newNode;
        }
        
        public void AddEdge(Node source, Node destination)
        {
            source.AdjacencyList.Add(destination);
        }     
        
        public Stack<Node> TopologicalSort()
        {
            var stack = new Stack<Node>();
            var visited = new HashSet<Node>();
            
            for(var i = 0; i < this.Nodes.Count; i++)
            {
                var node = this.Nodes[i];
                if(!visited.Contains(node))
                {
                    TopologicalSortUtil(node, visited, stack);
                }
            }
            
            return stack;
        }
        
        public void TopologicalSortUtil(Node node, HashSet<Node> visited, Stack<Node> stack)
        {
            visited.Add(node);
            
            foreach(var adjNode in node.AdjacencyList)
            {
                if(!visited.Contains(adjNode))
                {
                    TopologicalSortUtil(adjNode, visited, stack);                    
                }
            }
            
            stack.Push(node);
        }
    } 
    
    public class Node
    {
        public Node(string value)
        {           
            this.Name = value;
            this.AdjacencyList = new List<Node>();
        }

        public string Name { get; set; }
        public List<Node> AdjacencyList  { get; set; }
    }
}
