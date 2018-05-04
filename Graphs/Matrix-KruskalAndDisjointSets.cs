using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        
        var edges = new List<Edge>();
        for(int a0 = 0; a0 < n-1; a0++){
            string[] tokens_x = Console.ReadLine().Split(' ');
            int x = Convert.ToInt32(tokens_x[0]);
            int y = Convert.ToInt32(tokens_x[1]);
            int z = Convert.ToInt32(tokens_x[2]);
            
            edges.Add(new Edge() { Value = z, To = x, From = y});
        }
        
        edges = edges.OrderByDescending(c => c.Value).ToList();
        var nodesToDisconnect = new HashSet<int>();
        for(int a0 = 0; a0 < k; a0++){
            int m = Convert.ToInt32(Console.ReadLine());
            nodesToDisconnect.Add(m);
        }
        
        var result = GetMinToDisconnectEdgeSum(edges, nodesToDisconnect);
        Console.WriteLine(result);
    }
    
    static long GetMinToDisconnectEdgeSum(List<Edge> edges, HashSet<int> nodesToDisconnect){
        var result = 0;
        
        var nodeSet = new DisjointSet(nodesToDisconnect);
        for(var i = 0; i < edges.Count; i++){
            var currentEdge = edges[i];
            nodeSet.MakeSet(currentEdge.To);
            nodeSet.MakeSet(currentEdge.From);
            
            if(nodeSet.HasMachine(currentEdge.To) && nodeSet.HasMachine(currentEdge.From)){
                result += currentEdge.Value;
            }
            else{
                nodeSet.Union(currentEdge.To, currentEdge.From);
            }
        }
        
        return result;
    }
    
    public class DisjointSet{
        private Dictionary<int, int> sets;
        private HashSet<int> setsWithMachines;
        
        public DisjointSet(HashSet<int> machines){
            this.sets = new Dictionary<int, int>();
            this.setsWithMachines = machines;
        }
        
        public bool MakeSet(int setMember){
            if(sets.ContainsKey(setMember)){
                return false;
            }
            
            sets.Add(setMember, -1);
            
            return true;
        }
        
        public int FindSet(int setMember){
            if(!sets.ContainsKey(setMember)){
                return -1;
            }
            
            var partOfSet = sets[setMember];
            if(partOfSet == -1){
                return setMember;
            }
            
            return FindSet(partOfSet);
        }
        
        public void Union(int setMember1, int setMember2){
            MakeSet(setMember1);
            MakeSet(setMember2);
            
            var partOfSet1 = FindSet(setMember1);
            var partOfSet2 = FindSet(setMember2);
            
            sets[partOfSet1] = partOfSet2;
            if(setsWithMachines.Contains(setMember1) || setsWithMachines.Contains(setMember2) || setsWithMachines.Contains(partOfSet1)){
                setsWithMachines.Add(partOfSet2);
            }            
        }
        
        public bool HasMachine(int setMember){
            var partOfSet = FindSet(setMember);
            return setsWithMachines.Contains(partOfSet);
        }
    }
    
    public class Edge{
        public int Value { get; set; }
        
        public int From { get; set; }
        
        public int To { get; set; }
    }
}
