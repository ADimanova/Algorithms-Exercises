using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {

    static void Main(string[] args) {
        string[] treeNodesEdges = Console.ReadLine().Split(' ');
        int treeNodes = Convert.ToInt32(treeNodesEdges[0]);
        int treeEdges = Convert.ToInt32(treeNodesEdges[1]);
        
        var nodes = new Node[treeNodes];
        for(var i = 0; i < treeNodes; i++){
            nodes[i] = new Node() { Value = i + 1 };
        }
        
        for(var i = 0; i < treeEdges; i++){
            string[] edge = Console.ReadLine().Split(' ');
            var firstNodeIndex = Convert.ToInt32(edge[0]) - 1;
            var secondNodeIndex = Convert.ToInt32(edge[1]) - 1;
            nodes[secondNodeIndex].Children.Add(nodes[firstNodeIndex]);
        }
        
        
        var root = nodes[0];
        var result = Visit(root);
        Console.WriteLine(result.Item2);        
    }
    
    static Tuple<int, int> Visit(Node node){
        var removedEdges = 0;
        var currentNodeCount = 1;
        foreach(var child in node.Children){
            var childResult = Visit(child);
            if(childResult.Item1 % 2 == 0){
                removedEdges += 1;
                removedEdges += childResult.Item2;
            }
            else{
                currentNodeCount += childResult.Item1;
                removedEdges += childResult.Item2;
            }
        }
        
        return Tuple.Create(currentNodeCount, removedEdges);
    }
    
    public class Node{
        
        public Node(){
            Children = new List<Node>();
        }
        
        public int Value { get; set; }
        
        public List<Node> Children { get; set; }    
    }
}
