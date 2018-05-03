using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {

    static void Main(string[] args) {
        string[] gNodesEdges = Console.ReadLine().Split(' ');
        int gNodes = Convert.ToInt32(gNodesEdges[0]);
        int gEdges = Convert.ToInt32(gNodesEdges[1]);

        int[] gFrom = new int[gEdges];
        int[] gTo = new int[gEdges];
        int[] gWeight = new int[gEdges];

        for (int gItr = 0; gItr < gEdges; gItr++) {
            string[] gFromToWeight = Console.ReadLine().Split(' ');
            gFrom[gItr] = Convert.ToInt32(gFromToWeight[0]);
            gTo[gItr] = Convert.ToInt32(gFromToWeight[1]);
            gWeight[gItr] = Convert.ToInt32(gFromToWeight[2]);
        }

        long minSumOfWeights = MinSumOfWeightsInSubTree(gFrom, gTo, gWeight);
        Console.WriteLine(minSumOfWeights);
    }
    
    static long MinSumOfWeightsInSubTree(int[] from, int[] to, int[] weight){
        
        var edges = new List<Edge>();
        for(var i = 0; i < from.Length; i++){
            var edge = new Edge(from[i], to[i], weight[i]);
            edges.Add(edge);
        }
        
        edges = edges.OrderBy(c => c.Weight).ToList();
        
        var usedNodes = new DisjointSet();
        
        long weightSum = 0;
        foreach(var edge in edges){
            usedNodes.MakeSet(edge.From);
            usedNodes.MakeSet(edge.To);
            
            if(usedNodes.FindSet(edge.From) != usedNodes.FindSet(edge.To)){
                weightSum += edge.Weight;
                usedNodes.Union(edge.From, edge.To);
            }
        }
        
        return weightSum;
    }
    
    public class DisjointSet {
        
        private Dictionary<int, int> sets;
        
        public DisjointSet(){
            this.sets = new Dictionary<int, int>();
        }
                
        public int FindSet(int item){
            if(sets.ContainsKey(item)){
                var resultSet = sets[item];
                while(resultSet != -1){
                    item = resultSet;
                    resultSet = sets[item];
                }
                
                return item;
            }
            else {
                return -1;
            }
        }
        
        public bool MakeSet(int item){
            if(sets.ContainsKey(item)){
                return false;
            }
            
            sets.Add(item, -1);
            
            return true;
        }
        
        public void Union(int set1, int set2){
            var actualSet1 = FindSet(set1);
            var actualSet2 = FindSet(set2);
            
            if(actualSet1 != actualSet2){
                sets[actualSet1] = actualSet2;
            }
        }
    }
    
    public class Edge{
        public Edge(int from, int to, int weight){
            this.From = from;
            this.To = to;
            this.Weight = weight;
        }
        
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }
    }
}
