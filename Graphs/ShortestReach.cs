using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Solution {
    public static int NodeWeight = 6;
    
    static void Main(String[] args) {
        var testCases = int.Parse(Console.ReadLine());
        for(var i = 0; i < testCases; i++)
        {
            var graph = new Graph();
            FillGraph(graph);
            int sourceValue = int.Parse(Console.ReadLine()) - 1;
            var result = CalculateDistance(graph, graph.Nodes[sourceValue]); 
            PrintResult(result);
        }
    }
    
    public static void PrintResult(int[] array)
    {
        var builder = new StringBuilder();
        var lastElIndex = array.Length - 1;
        for(var i = 0; i < array.Length; i++)
        {
            if(array[i] != 0)
            {
                builder.Append(array[i]);
                if(i < lastElIndex)
                {
                    builder.Append(' ');
                }
            }
        }
        
        Console.WriteLine(builder.ToString());
    }
    
    public static int[] CalculateDistance(Graph graph, Node source)
    {
        var nodesCount = graph.Nodes.Count;
        var distances = new int[nodesCount];
        for(var i = 0; i < nodesCount; i++)
        {
            distances[i] = -1;
        }
        
        distances[source.Value] = 0;
        
        var queue = new Queue<Node>();
        queue.Enqueue(source);
        while(queue.Count > 0)
        {
            var node = queue.Dequeue();
            foreach(var child in node.Children)
            {
                if(distances[child.Value] == -1)
                {
                    distances[child.Value] = distances[node.Value] + NodeWeight;
                    queue.Enqueue(child);
                }           
            }           
        }
        
        return distances;
    }
    
    public static void FillGraph(Graph graph)
    {
        var parts = Console.ReadLine().Split(' ');
        var nodesCount = int.Parse(parts[0]);
        for(var j = 0; j < nodesCount; j++)
        {
            graph.AddNode(j);
        }

        var edgesCount = int.Parse(parts[1]);
        for(var j = 0; j < edgesCount; j++)
        {
            var nodesParts = Console.ReadLine().Split(' ');

            var firstNodeName = int.Parse(nodesParts[0]) - 1;
            var secondNodeName = int.Parse(nodesParts[1]) - 1;
            
            var firstNode = graph.Nodes[firstNodeName];
            var secondNode = graph.Nodes[secondNodeName];

            firstNode.Children.Add(secondNode);
            secondNode.Children.Add(firstNode);
        }
    }
    
    public class Graph
    {
        public Graph()
        {
            this.Nodes = new Dictionary<int, Node>();
        }
        
        public Dictionary<int, Node> Nodes { get; set; }
        
        public void AddNode(int value)
        {
            this.Nodes.Add(value, new Node(value));
        }
    }
    
    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Children = new List<Node>();
        }
        
        public int Value { get; set; }
        public List<Node> Children { get; set; }
    }
}
