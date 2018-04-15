using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int[] bfs(int n, int m, int[][] edges, int s) {
        
        var nodes = new Node[n];
        for(var i = 0; i < n; i++){
            nodes[i] = new Node(i);
        }
        
        for(var i = 0; i < edges.Length; i++){
            var firstNodeIndex = edges[i][0] - 1;
            var secondNodeIndex = edges[i][1] - 1;
            nodes[firstNodeIndex].Children.Add(nodes[secondNodeIndex]);
            nodes[secondNodeIndex].Children.Add(nodes[firstNodeIndex]);
        }
           
        var startNode = nodes[s - 1];
        
        var result = new int[n];
        
        
        var visited = new HashSet<Node>(); 
        var queue = new Queue<Tuple<Node, int>>();
        
        queue.Enqueue(Tuple.Create(startNode, 0));
        visited.Add(startNode);
        
        while(queue.Count > 0){
            var current = queue.Dequeue();
            result[current.Item1.Index] = current.Item2;
            foreach(var child in current.Item1.Children){
                if(!visited.Contains(child)){
                    queue.Enqueue(Tuple.Create(child, current.Item2 + 6));
                    visited.Add(child);
                }
            }
        }
        
        var endResult = new List<int>();
        for(var i = 0; i < result.Length; i++){
            if(i == s - 1){
                continue;
            }
            
            if(result[i] == 0){
                endResult.Add(-1);
            }
            else{
                endResult.Add(result[i]);
            }
        }
        
        return endResult.ToArray();
    }

    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < q; a0++){
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            int[][] edges = new int[m][];
            for(int edges_i = 0; edges_i < m; edges_i++){
               string[] edges_temp = Console.ReadLine().Split(' ');
               edges[edges_i] = Array.ConvertAll(edges_temp,Int32.Parse);
            }
            int s = Convert.ToInt32(Console.ReadLine());
            int[] result = bfs(n, m, edges, s);
            Console.WriteLine(String.Join(" ", result));
        }
    }
}

public class Node {
    public Node(int index){
        this.Index = index;
        this.Children = new List<Node>();
    }
    
    public int Index { get; set; }
    public List<Node> Children { get; set; }
}
